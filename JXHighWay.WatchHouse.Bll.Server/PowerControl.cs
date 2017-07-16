using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.Net.DataPack;
using JXHighWay.WatchHouse.Net;
using System.Net;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Helper;
using System.Threading;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class PowerControl:BasicControl
    {
        bool m_IsRun = false;
    

        public PowerControl()
        {
            Config vConfig = new Config();
            Port = vConfig.PowerPort;
        }
        
        public void Start()
        {
            ReceiveQueue = new Queue<WHQueueModel>();
            initPower();
            m_IsRun = true;

            m_SocketManager = new SocketManager(MaxConnNum, BufferSize);
            m_SocketManager.ReceiveClientData += M_SocketManager_ReceiveClientData;
            m_SocketManager.Init();
            m_SocketManager.Start(new IPEndPoint(IPAddress.Any, Port));

            //异步处理接收到的数据
            asyncProcessorRecieveData();

            //处理数据库中的待发送命令
            asyncProcessorDBSendCMD();

        }

        public void Stop()
        {
            m_IsRun = false;
            m_SocketManager.Stop();
            m_SocketManager = null;
        }


        private void M_SocketManager_ReceiveClientData(Net.AsyncUserToken token, byte[] buff)
        {
            if (buff.Length > 0 && buff[0] == 0x5a)
            {
                ReceiveQueue.Enqueue(new WHQueueModel(buff, token.IPAddress.ToString()));
                Console.WriteLine(string.Format("收到一组数据,IP地址({0}):{1}", token.IPAddress.ToString(), BitConverter.ToString(buff)));
            }
        }

        /// <summary>
        /// 初始化电源信息
        /// </summary>
        void initPower()
        {
            WatchHouseConfigEFModel[] vWatchHouseConfig = m_BasicDBClass_Receive.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach (WatchHouseConfigEFModel vTempConfig in vWatchHouseConfig)
            {
                m_ClientDict.Add(vTempConfig.DianYuan1ID??0, "");
            }
        }

        byte calcCheckCode(byte[] dataPack)
        {
            byte[] vResult = new byte[2];
            var vCalcResult = 0x0000;
            for (int i = 1; i < dataPack.Length - 2; i++)
            {
                vCalcResult += dataPack[i];
            }
            vResult[0] = (byte)(vCalcResult >> 8);
            vResult[1] = (byte)(vCalcResult >> 0);
            return vResult[1];
        }
        public async Task<bool> SendCMD_SetIP( int DianYuanID,string IPAddress,string Mask,string Gateway,bool DHCP,
            string ServerIP,short Port )
        {
            PowerDataPack_Send_SetIPAddress vData = new PowerDataPack_Send_SetIPAddress()
            {
                 DHCP = DHCP?(byte)0x01:(byte)0x00,
                 
            };
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_SetIPAddress, vData);
            return vResult;
        }

        public void Send()
        {
            PowerDataPack_Main vSendDataPack = new PowerDataPack_Main()
            {
                Head = 0x5a,
                SN = 0x01,
                Addition = 0x00,
                CMD = (byte)PowerDataPack_Send_CommandEnum.Send_GetIPAddress,
                Tail = 0x5b,
                Length1 = 0x00,
                Length2 = 0x08
            };
            byte[] vDataPackBytes = Helper.NetHelper.StructureToByte(vSendDataPack);
            vSendDataPack.Check = calcCheckCode(vDataPackBytes);
            vDataPackBytes = Helper.NetHelper.StructureToByte(vSendDataPack);
            Console.WriteLine(BitConverter.ToString(vDataPackBytes));
            m_SocketManager.SendMessage(m_SocketManager.ClientList[0], vDataPackBytes);
        }

        async Task<bool> asyncSendCommandToDB<T>(int dianYuanID, PowerDataPack_Send_CommandEnum command, T SendData)
        {
            return await Task.Run(() =>
            {
                string vDataStr = System.Text.Encoding.Default.GetString(NetHelper.StructureToByte(SendData));
                PowerSendCMDEFModel vSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    State = false,
                    IsSend = false,
                    IsReply = false,
                    CMD = (byte)command,
                    DianYuanID = dianYuanID,
                    SendTime = DateTime.Now,
                    SN = NetHelper.MarkSN_Byte(),
                    Data = vDataStr
                };
                
                int vID = m_BasicDBClass_Send.InsertRecord(vSendCMDEFModel);

                DateTime vStartTime = DateTime.Now;
                bool vResult = false;
                do
                {
                    PowerSendCMDEFModel vSelectResult = m_BasicDBClass_Send.SelectRecordByPrimaryKeyEx<PowerSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 2000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
                //m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSendCMDEFModel>(vID);
                return vResult;
            });
        }

        #region 处理接收到的数据
        async void asyncProcessorRecieveData()
        {
            await processorReceiveData();
        }

        private Task processorReceiveData()
        {
            return Task.Run(() =>
            {
                while (m_IsRun)
                {
                    try
                    {
                        if (ReceiveQueue.Count > 0)
                        {
                            WHQueueModel vReceiveData = ReceiveQueue.Dequeue();
                            switch (vReceiveData.Data[5])
                            {
                                //处理接收到的电源状态数据
                                case (byte)PowerDataPack_Receive_CommandEnum.RunningStatus:
                                    PowerDataPack_Receive_RunningStatus vDataPack1 = Helper.NetHelper.ByteToStructure<PowerDataPack_Receive_RunningStatus>(vReceiveData.Data);
                                    processorData_RunningStatus(vDataPack1, vReceiveData.IPAddress);
                                    break;
                                //处理接收到电源开关状态数据
                                case (byte)PowerDataPack_Receive_CommandEnum.SwitchStatus:
                                    PowerDataPack_Receive_ReplyCMD vDataPack2 = Helper.NetHelper.ByteToStructure<PowerDataPack_Receive_ReplyCMD>(vReceiveData.Data);
                                    processorData_ReplyCMD(PowerDataPack_Receive_CommandEnum.SwitchStatus, vDataPack2);
                                    break;
                                //电源上报事件
                                case (byte)PowerDataPack_Receive_CommandEnum.Event:
                                    PowerDataPack_Receive_Event vDataPack3 = Helper.NetHelper.ByteToStructure<PowerDataPack_Receive_Event>(vReceiveData.Data);
                                    processorData_Event(vDataPack3, vReceiveData.IPAddress);
                                    break;
                            }
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("处理数据报时发生异常,错误信息{0}", ex.Message));
                    }
                }
            });
        }


        /// <summary>
        /// 更新电源最后通讯时间
        /// </summary>
        /// <param name="dianYuanID"></param>
        void updateTongXunSJ(int dianYuanID )
        {
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                DianYuanTXSJ = DateTime.Now,
                DianYuan1ID = 11
            };
        }

        string convertDianYuanLeiXing(byte leiXing)
        {
            string vResult = "";
            switch ( leiXing)
            {
                case 0x00:
                    vResult = "漏保";
                    break;
                case 0x01:
                    vResult = "分路";
                    break;
                case 0x02:
                    vResult = "分路(带漏保)";
                    break;
                case 0x03:
                    vResult = "漏保插座";
                    break;
                case 0x04:
                    vResult = "普插座";
                    break;
            }
            return vResult;
        }

        /// <summary>
        /// 转换事情类型
        /// </summary>
        /// <returns></returns>
        string convertShiJianLX(byte shiJianLeiXing)
        {
            string vResult = "";
            switch (shiJianLeiXing)
            {
                case 0x00:
                    vResult = "操作类";
                    break;
                case 0x01:
                    vResult = "报警类";
                    break;
                case 0x02:
                    vResult = "故障类";
                    break;
            }
            return vResult;
        }

        string convertShiJianNR(byte shiJianLeiXing,byte shiJianNR)
        {
            string vResult = "";
            switch (shiJianLeiXing)
            {
                case 0x00:
                    switch (shiJianNR)
                    {
                        case 0x00:
                            vResult = "无效";
                            break;
                        case 0x01:
                            vResult = "远程关";
                            break;
                        case 0x02:
                            vResult = "远程关";
                            break;
                        case 0x03:
                            vResult = "远程开";
                            break;
                        case 0x04:
                            vResult = "本地开";
                            break;
                        case 0x05:
                            vResult = "定时关";
                            break;
                        case 0x06:
                            vResult = "定时开";
                            break;
                        case 0x07:
                            vResult = "手动漏电试验有效";
                            break;
                        case 0x08:
                            vResult = "手动漏电试验失效";
                            break;
                        case 0x09:
                            vResult = "远程漏电试验有效";
                            break;
                        case 0x0A:
                            vResult = "远程漏电试验失效";
                            break;
                        case 0x0B:
                            vResult = "定时漏电试验有效";
                            break;
                        case 0x0C:
                            vResult = "定时漏电试验失效";
                            break;
                    }
                    break;
                case 0x01:
                    switch(shiJianNR)
                    {
                        case 0x00:
                            vResult = "无效";
                            break;
                        case 0x01:
                            vResult = "短路跳闸";
                            break;
                        case 0x02:
                            vResult = "过载跳闸";
                            break;
                        case 0x03:
                            vResult = "超功率跳闸";
                            break;
                        case 0x04:
                            vResult = "电能用完跳闸";
                            break;
                        case 0x05:
                            vResult = "超温跳闸";
                            break;
                        case 0x06:
                            vResult = "过压跳闸";
                            break;
                        case 0x07:
                            vResult = "欠压跳闸";
                            break;
                        case 0x08:
                            vResult = "打火跳闸";
                            break;
                        case 0x09:
                            vResult = "漏电跳闸";
                            break;
                        case 0x0a:
                            vResult = "过压预警";
                            break;
                        case 0x0b:
                            vResult = "欠压预警";
                            break;
                        case 0x0C:
                            vResult = "超温预警";
                            break;
                        case 0x0D:
                            vResult = "漏电预警";
                            break;
                        case 0x0E:
                            vResult = "过载预警";
                            break;
                        case 0x0F:
                            vResult = "超功率预警";
                            break;
                        case 0x10:
                            vResult = "电能将用完";
                            break;
                    }
                    break;
                case 0x02:
                    switch (shiJianNR)
                    {
                        case 0x00:
                            vResult = "无效";
                            break;
                        case 0x01:
                            vResult = "通信错误";
                            break;
                        case 0x02:
                            vResult = "数据异常";
                            break;
                        case 0x03:
                            vResult = "触点开关异常";
                            break;
                    }
                    break;
            }
            return vResult;
        }

        void processorData_ReplyCMD(PowerDataPack_Receive_CommandEnum comm, PowerDataPack_Receive_ReplyCMD dataPack)
        {
            string vSql = "";
            PowerSendCMDEFModel vPowerSendCMDEFModel = new PowerSendCMDEFModel()
            {
                IsReply = true,
                State = dataPack.State == 0x00 ? true : false
            };
            switch ( comm)
            {
                case PowerDataPack_Receive_CommandEnum.SwitchStatus:
                    vSql = string.Format("DianYuanID={0} and CMD={1:D} and SN={2}", 11, 0x41, dataPack.SN);
                    break;
            }

            if (vSql != "")
                m_BasicDBClass_Return.UpdateRecord(vPowerSendCMDEFModel, vSql);
        }

        void processorData_Event(PowerDataPack_Receive_Event data,string IPAddress)
        {
            try
            {
                PowerEventEFModel vPowerEventEFModel = new PowerEventEFModel()
                {
                    DianYuanID = data.Addition,
                    LeiXi = convertDianYuanLeiXing(data.LeiXing),
                    LuHao = data.LuHao,
                    ShiJianLX = convertShiJianLX(data.ShiJinLX),
                    NeiRong = convertShiJianNR(data.ShiJinLX, data.ShiJianBM),
                    Time = DateTime.Now
                };
                m_BasicDBClass_Receive.InsertRecord(vPowerEventEFModel);
            }
            catch( Exception ex)
            {
                Console.WriteLine(string.Format("插入数据至[电源事件表]中发生异常，异常信息为:{0}", ex.Message));
            }
        }

        void processorData_RunningStatus(PowerDataPack_Receive_RunningStatus vData, string IPAddress)
        {
           try
            {
                PowerDataEFModel vModel = new PowerDataEFModel()
                {
                    DianLiu = BitConverter.ToInt16(new byte[] { vData.DianLiu2, vData.DianLiu1 },0),
                    DianYa = BitConverter.ToInt16(new byte[] { vData.DianYa2, vData.DianYa1 },0),
                    DianNeng = BitConverter.ToInt32(new byte[] { vData.DianNeng4, vData.DianNeng3, vData.DianNeng2, vData.DianNeng1 },0),
                    GongLuYinShu = BitConverter.ToInt16(new byte[] { vData.GongLuYS2, vData.GongLuYS1 },0),
                    LouDianLiu = BitConverter.ToInt16(new byte[] { vData.LouDianLiu2, vData.LouDianLiu1 },0),
                    LuHao = vData.LuHao,
                    PinLu = BitConverter.ToInt16(new byte[] { vData.PinLu2, vData.PinLu1 },0),
                    WenDu = BitConverter.ToInt16(new byte[] { vData.WenDu2, vData.WenDu1 },0),
                    WuGongGL = BitConverter.ToInt16(new byte[] { vData.WuGongGL2, vData.WuGongGL1 },0),
                    YouGongGL = BitConverter.ToInt16(new byte[] { vData.YouGongGL2, vData.YouGongGL1 },0),
                    LeiXing = convertDianYuanLeiXing(vData.LeiXing)
                };
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    DianYuanTXSJ = DateTime.Now,
                    DianYuan1IP = IPAddress
                };
                m_BasicDBClass_Receive.TransactionBegin();
                m_BasicDBClass_Receive.InsertRecord(vModel);
                m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("DianYuanID={0}", vModel.DianYuanID??0));
                m_BasicDBClass_Receive.TransactionCommit();
                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.DianYuanID.Value) )
                    m_ClientDict[vModel.DianYuanID.Value] = IPAddress;
            }
            catch(Exception ex)
            {
                Console.WriteLine( string.Format("插入数据至[电源数据表]中发生异常，异常信息为:{0}",ex.Message));
            }
        }
        #endregion

        #region 处理需要发送的数据
        async void asyncProcessorDBSendCMD()
        {
            await Task.Run(() =>
            {
                while (m_IsRun)
                {
                    PowerSendCMDEFModel vModel = new PowerSendCMDEFModel()
                    {
                        IsSend = false
                    };
                    var vSelectResult = m_BasicDBClass_Send.SelectRecordsEx(vModel);
                    foreach (PowerSendCMDEFModel vTempResult in vSelectResult)
                    {
                        //AsyncUserToken vAsyncUserToken = findAsyncUserToken(vTempResult.DianYuanID.Value);
                        AsyncUserToken vAsyncUserToken = null;
                        if (m_SocketManager.ClientList.Count > 0)
                            vAsyncUserToken = m_SocketManager.ClientList[0];
                        if (vAsyncUserToken != null)
                        {
                            PowerDataPack_Main vCommandDataPack = new PowerDataPack_Main()
                            {
                                Head = 0x5a,
                                Tail = 0x5b,
                                SN = 0x01,//vTempResult.SN ?? 0x00,
                                CMD = vTempResult.CMD ?? 0x00,
                                Addition = 0x00
                            };
                            List<byte> vCMDDataPack = Helper.NetHelper.StructureToByte(vCommandDataPack).ToList();
                            if ( vTempResult.Data != null )
                            {
                                List<byte> vDataPack = System.Text.Encoding.Default.GetBytes(vTempResult.Data).ToList();
                                vCMDDataPack.InsertRange(6, vDataPack);
                            }
                            byte[] vLength = BitConverter.GetBytes((short)vCMDDataPack.Count);
                            //包长度
                            vCMDDataPack[1] = vLength[1];
                            vCMDDataPack[2] = vLength[0];
                            //校验和 
                            vCMDDataPack[vCMDDataPack.Count-2] = calcCheckCode(vCMDDataPack.ToArray());

                            m_SocketManager.SendMessage(vAsyncUserToken, vCMDDataPack.ToArray());
                            Console.WriteLine("发送命令数据包,IP地址({0}):{1}", vAsyncUserToken.IPAddress.ToString(), BitConverter.ToString(vCMDDataPack.ToArray()));
                            //更新数据库状态
                            vModel.IsSend = true;
                            vModel.ID = vTempResult.ID;
                            m_BasicDBClass_Send.UpdateRecord<PowerSendCMDEFModel>(vModel);
                        }
                    }
                }
            });
        }
        #endregion
    }
}
