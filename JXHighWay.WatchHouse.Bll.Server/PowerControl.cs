using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.Net.DataPack;
using JXHighWay.WatchHouse.Net;
using System.Net;
using JXHighWay.WatchHouse.EFModel;

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
                m_ClientDict.Add(vTempConfig.DianYuanID, "");
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
                                case (byte)PowerDataPack_Receive_CommandEnum.SwitchStatus:
                                    PowerDataPack_Receive_ReplyCMD vDataPack2 = Helper.NetHelper.ByteToStructure<PowerDataPack_Receive_ReplyCMD>(vReceiveData.Data);
                                    processorData_ReplyCMD(PowerDataPack_Receive_CommandEnum.SwitchStatus, vDataPack2);
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
                    DianYuanIP = IPAddress
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
