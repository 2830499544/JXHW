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
        Dictionary<string, int> m_ClientMaxID = null;

        public PowerControl()
        {
            
            Config vConfig = new Config();
            Port = vConfig.PowerPort;
        }
        
        public void Start()
        {
            ReceiveQueue = new Queue<WHQueueModel>();
            m_ClientMaxID = new Dictionary<string, int>();
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
                if (vTempConfig.DianYuan1ID != null && vTempConfig.DianYuan1ID != "")
                {
                    m_ClientDict.Add(vTempConfig.DianYuan1ID, "");
                    m_ClientMaxID.Add(vTempConfig.DianYuan2ID, 0);
                }

                if (vTempConfig.DianYuan2ID != null && vTempConfig.DianYuan2ID != "")
                {
                    m_ClientDict.Add(vTempConfig.DianYuan2ID, "");
                    m_ClientMaxID.Add(vTempConfig.DianYuan2ID, 0);
                }
                
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

        public PowerIPConfigInfo GetIPConfig(string DianYuanID)
        {
            PowerIPConfigInfo vIPConfigResult = new PowerIPConfigInfo();

            PowerNetConfigEFModel vPowerNetConfigEFModel = new PowerNetConfigEFModel()
            {
                MAC = DianYuanID
            };

            PowerNetConfigEFModel[] vSelectResult = m_BasicDBClass_Send.SelectRecordsEx(vPowerNetConfigEFModel);
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                vIPConfigResult = new PowerIPConfigInfo()
                {
                    MAC = DianYuanID,
                    Gateway = vSelectResult[0].Gateway,
                    IPAddress = vSelectResult[0].IPAddress,
                    IsDHCP = vSelectResult[0].DHCP,
                    Port = vSelectResult[0].Port ?? 0,
                    ServerIPAddress = vSelectResult[0].ServerIPAddress,
                    ServerPort = vSelectResult[0].ServerPort ?? 0,
                    SubMask = vSelectResult[0].SubMask
                };
            }
            return vIPConfigResult;
        }

        public async Task<PowerIPConfigInfo> SendCMD_GetIP(string DianYuanID)
        {
            PowerIPConfigInfo vIPConfigResult = new PowerIPConfigInfo();
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_GetIPAddress);
            if (vResult)
            {
                PowerNetConfigEFModel vPowerNetConfigEFModel = new PowerNetConfigEFModel()
                {
                    MAC = DianYuanID
                };

                PowerNetConfigEFModel[] vSelectResult = m_BasicDBClass_Send.SelectRecordsEx(vPowerNetConfigEFModel);
                if (vSelectResult != null && vSelectResult.Length > 0)
                {
                    vIPConfigResult = new PowerIPConfigInfo()
                    {
                        MAC = DianYuanID,
                        Gateway = vSelectResult[0].Gateway,
                        IPAddress = vSelectResult[0].IPAddress,
                        IsDHCP = vSelectResult[0].DHCP,
                        Port = vSelectResult[0].Port ?? 0,
                        ServerIPAddress = vSelectResult[0].ServerIPAddress,
                        ServerPort = vSelectResult[0].ServerPort ?? 0,
                        SubMask = vSelectResult[0].SubMask
                    };
                }
            }
            return vIPConfigResult;
        }

        public async Task<bool> SendCMD_SetIP( string DianYuanID,PowerIPConfigInfo IPConfig )
        {
            byte[] vIPAddress = NetHelper.StringToBytes_IP(IPConfig.IPAddress );
            byte[] vSubMaksArray = NetHelper.StringToBytes_IP(IPConfig.SubMask);
            byte[] vGateway = NetHelper.StringToBytes_IP(IPConfig.Gateway);
            byte[] vMAC = NetHelper.StringToBytes_MAC(IPConfig.MAC);
            byte[] vServerIP = NetHelper.StringToBytes_IP(IPConfig.ServerIPAddress);


            PowerDataPack_Send_SetIPAddress vData = new PowerDataPack_Send_SetIPAddress()
            {
                IPAddress1 = vIPAddress[0],
                IPAddress2 = vIPAddress[1],
                IPAddress3 = vIPAddress[2],
                IPAddress4 = vIPAddress[3],

                SubnetMask1 = vSubMaksArray[0],
                SubnetMask2 = vSubMaksArray[1],
                SubnetMask3 = vSubMaksArray[2],
                SubnetMask4 = vSubMaksArray[3],

                Gateway1 = vGateway[0],
                Gateway2 = vGateway[1],
                Gateway3 = vGateway[2],
                Gateway4 = vGateway[3],

                MAC1 = vMAC[0],
                MAC2 = vMAC[1],
                MAC3 = vMAC[2],
                MAC4 = vMAC[3],
                MAC5 = vMAC[4],
                MAC6 = vMAC[5],

                ServerIPAddress1 = vServerIP[0],
                ServerIPAddress2 = vServerIP[1],
                ServerIPAddress3 = vServerIP[2],
                ServerIPAddress4 = vServerIP[3],

                Port1 = (byte)(IPConfig.Port >> 8),
                Port2 = (byte)(IPConfig.Port >> 0),

                ServerPort1 = (byte)(IPConfig.ServerPort >> 8),
                ServerPort2 = (byte)(IPConfig.ServerPort >> 0),

                DHCP = IPConfig.IsDHCP ? (byte)0x01 : (byte)0x00

            };
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.SetIPAddress, vData);
            if ( vResult )
            {
                PowerNetConfigEFModel vPowerNetConfigEFModel = new PowerNetConfigEFModel()
                {
                    DHCP = IPConfig.IsDHCP,
                    Gateway = IPConfig.Gateway,
                    IPAddress = IPConfig.IPAddress,
                    MAC = IPConfig.MAC,
                    Port = IPConfig.Port,
                    ServerIPAddress = IPConfig.ServerIPAddress,
                    ServerPort = IPConfig.ServerPort,
                    SubMask = IPConfig.SubMask
                };
                string vSql = string.Format("MAC='{0}'", IPConfig.MAC);
                m_BasicDBClass_Send.TransactionBegin();
                m_BasicDBClass_Send.DeleteRecordCustom<PowerNetConfigEFModel>(vSql);
                m_BasicDBClass_Send.InsertRecord(vPowerNetConfigEFModel);
                m_BasicDBClass_Send.TransactionCommit();

            }
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

        async Task<bool> asyncSendCommandToDB<T>(string dianYuanID, PowerDataPack_Send_CommandEnum command, T SendData)
        {
            return await Task.Run(() =>
            {
               // string vDataStr = System.Text.Encoding.Default.GetString(NetHelper.StructureToByte(SendData));
                PowerSendCMDEFModel vSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    State = false,
                    IsSend = false,
                    IsReply = false,
                    CMD = (byte)command,
                    DianYuanID = dianYuanID,
                    SendTime = DateTime.Now,
                    SN = NetHelper.MarkSN_Byte(),
                    Data = NetHelper.StructureToByte(SendData)
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

        async Task<bool> asyncSendCommandToDB(string dianYuanID, PowerDataPack_Send_CommandEnum command)
        {
            return await Task.Run(() =>
            {
                PowerSendCMDEFModel vSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    State = false,
                    IsSend = false,
                    IsReply = false,
                    CMD = (byte)command,
                    DianYuanID = dianYuanID,
                    SendTime = DateTime.Now,
                    SN = NetHelper.MarkSN_Byte()
                    //Data = NetHelper.StructureToByte(SendData)
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
                            switch (vReceiveData.Data[11])
                            {
                                //处理接收到的电源状态数据
                                case (byte)PowerDataPack_Receive_CommandEnum.RunningStatus:
                                    PowerDataPack_Receive_RunningStatus vDataPack1 = NetHelper.ByteToStructure<PowerDataPack_Receive_RunningStatus>(vReceiveData.Data);
                                    processorData_RunningStatus(vDataPack1, vReceiveData.IPAddress);
                                    break;
                                case (byte)PowerDataPack_Receive_CommandEnum.SwitchStatus://处理接收到回复电源开关状态数据
                                case (byte)PowerDataPack_Receive_CommandEnum.SetTime://设置时间
                                case (byte)PowerDataPack_Receive_CommandEnum.SwitchParam://开关参数设置
                                case (byte)PowerDataPack_Receive_CommandEnum.Timing: //定时设置
                                case (byte)PowerDataPack_Receive_CommandEnum.SetIPAddress: //设置IP地址
                                    PowerDataPack_Receive_ReplyCMD vDataPack2 = NetHelper.ByteToStructure<PowerDataPack_Receive_ReplyCMD>(vReceiveData.Data);
                                    processorData_ReplyCMD(PowerDataPack_Receive_CommandEnum.SwitchStatus, vDataPack2);
                                    break;
                                //电源上报事件
                                case (byte)PowerDataPack_Receive_CommandEnum.Event:
                                    PowerDataPack_Receive_Event vDataPack3 = NetHelper.ByteToStructure<PowerDataPack_Receive_Event>(vReceiveData.Data);
                                    processorData_Event(vDataPack3, vReceiveData.IPAddress);
                                    break;
                                //获取IP地址
                                case (byte)PowerDataPack_Receive_CommandEnum.GetIPAddress:
                                    PowerDataPack_Receive_GetIPAddress vDataPack4 = NetHelper.ByteToStructure<PowerDataPack_Receive_GetIPAddress>(vReceiveData.Data);
                                    processorData_GetIPAddress(vDataPack4);
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
                DianYuan1ID = "11" //测试数据
            };
        }


        string convertSwitchState(byte[] zhuanTai )
        {
            string vResult = "";
            string vZhuanTaiStr = BitConverter.ToString(zhuanTai);
            switch ( vZhuanTaiStr.ToUpper() )
            {
                case "00-00":
                    vResult = "关";
                    break;
                case "FF-00":
                    vResult = "开";
                    break;
                case "00-FF":
                    vResult = "开时关";
                    break;
                case "FF-FF":
                    vResult = "开时开";
                    break;
            }
            return vResult;
        }

        /// <summary>
        /// 转换开关类型
        /// </summary>
        /// <param name="leiXing"></param>
        /// <returns></returns>
        string convertSwitchLeiXing(byte leiXing)
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

        void processorData_GetIPAddress(PowerDataPack_Receive_GetIPAddress dataPack)
        {
            string vMAC = NetHelper.BytesToString_MAC(new byte[] { dataPack.MAC_1, dataPack.MAC_2, dataPack.MAC_3, dataPack.MAC_4,
                dataPack.MAC_5, dataPack.MAC_6 });
            PowerNetConfigEFModel vPowerNetConfigEFModel = new PowerNetConfigEFModel()
            {
                MAC = vMAC,
                DHCP = dataPack.DHCP == 0x01 ? true : false,
                Gateway = NetHelper.BytesToString_IP(new byte[] { dataPack.gateway1, dataPack.gateway2, dataPack.gateway3, dataPack.gateway4 }),
                IPAddress = NetHelper.BytesToString_IP(new byte[] { dataPack.IPAddress1, dataPack.IPAddress2, dataPack.IPAddress3, dataPack.IPAddress4 }),
                ServerIPAddress = NetHelper.BytesToString_IP(new byte[] { dataPack.ServerIPAddress1,dataPack.ServerIPAddress2,dataPack.ServerIPAddress3,dataPack.ServerIPAddress4 } ),
                SubMask = NetHelper.BytesToString_IP(new byte[] { dataPack.SubnetMask1,dataPack.SubnetMask2,dataPack.SubnetMask3,dataPack.SubnetMask4 } ),
                Port = BitConverter.ToInt16( new byte[]{ dataPack.Port2,dataPack.Port2 },0),
                ServerPort = BitConverter.ToInt16( new byte[] { dataPack.ServerPort2,dataPack.ServerPort1 },0)
            };
            try
            {
                m_BasicDBClass_Receive.TransactionBegin();
                m_BasicDBClass_Receive.DeleteRecordCustom<PowerNetConfigEFModel>(string.Format("MAC='{0}'", vMAC));
                m_BasicDBClass_Receive.InsertRecord(vPowerNetConfigEFModel);
                PowerSendCMDEFModel vPowerSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    IsReply = true,
                    State = true
                };
                string vSql = string.Format("DianYuanID={0} and CMD={1:D} and SN={2}", vMAC,(byte)PowerDataPack_Send_CommandEnum.Send_GetIPAddress, dataPack.SN);
                m_BasicDBClass_Receive.UpdateRecord(vPowerSendCMDEFModel, vSql);
                m_BasicDBClass_Receive.TransactionCommit();
            }
            catch
            {
                m_BasicDBClass_Receive.TransactionRollback();
            }
        }


        void processorData_ReplyCMD(PowerDataPack_Receive_CommandEnum comm, PowerDataPack_Receive_ReplyCMD dataPack)
        {
            string vSql = "";
            
            string vDianYuanID = BitConverter.ToString(new byte[] { dataPack.MAC1, dataPack.MAC2, dataPack.MAC3, dataPack.MAC4, dataPack.MAC5, dataPack.MAC6 });
            PowerSendCMDEFModel vPowerSendCMDEFModel = new PowerSendCMDEFModel()
            {
                IsReply = true,
                State = dataPack.State == 0x00 ? true : false
            };
            switch ( comm )
            {
                case PowerDataPack_Receive_CommandEnum.SwitchStatus:
                case PowerDataPack_Receive_CommandEnum.SetTime:
                    vSql = string.Format("DianYuanID={0} and CMD={1:D} and SN={2}", vDianYuanID, (byte)PowerDataPack_Send_CommandEnum.Switch, dataPack.SN);
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
                    DianYuanID = BitConverter.ToString( new byte[] { data.MAC1,data.MAC2,data.MAC3,data.MAC4,data.MAC5,data.MAC6 } ),
                    LeiXi = convertSwitchLeiXing(data.LeiXing),
                    LuHao = data.LuHao,
                    ShiJianLX = convertShiJianLX(data.ShiJinLX),
                    NeiRong = convertShiJianNR(data.ShiJinLX, data.ShiJianBM),
                    Time = DateTime.Now,
                };
                m_BasicDBClass_Receive.TransactionBegin();
                m_BasicDBClass_Receive.InsertRecord(vPowerEventEFModel);
                //更新电源数据开关状态
                switch (vPowerEventEFModel.NeiRong)
                {
                    case "本地开":
                    case "远程开":
                    case "定时开":
                    case "短路跳闸":
                    case "过载跳闸":
                    case "超功率跳闸":
                    case "电能用完跳闸":
                    case "超温跳闸":
                    case "过压跳闸":
                    case "欠压跳闸":
                    case "打火跳闸":
                    case "漏电跳闸":
                        string vSql1 = string.Format("update  `电源数据` set `ZhuanTai`='{0}'  where LuHao={1:D} and `ID` in ( select a.MaxID from "
                             + "(Select max(id) as MaxID From `电源数据` where DianYuanID = '{2}') a )", "开", vPowerEventEFModel.LuHao, vPowerEventEFModel.DianYuanID);
                        m_BasicDBClass_Receive.UpdateRecord(vSql1);
                        break;
                    case "本地关":
                    case "远程关":
                    case "定时关":
                        string vSql2 = string.Format("update  `电源数据` set `ZhuanTai`='{0}'  where LuHao={1:D} and `ID` in ( select a.MaxID from "
                             + "(Select max(id) as MaxID From `电源数据` where DianYuanID = '{2}') a )", "关", vPowerEventEFModel.LuHao, vPowerEventEFModel.DianYuanID);
                        m_BasicDBClass_Receive.UpdateRecord(vSql2);
                        break;
                }
                m_BasicDBClass_Receive.TransactionCommit();
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
                    DianLiu = BitConverter.ToInt16(new byte[] { vData.DianLiu2, vData.DianLiu1 }, 0),
                    DianYa = BitConverter.ToInt16(new byte[] { vData.DianYa2, vData.DianYa1 }, 0),
                    DianNeng = BitConverter.ToInt32(new byte[] { vData.DianNeng4, vData.DianNeng3, vData.DianNeng2, vData.DianNeng1 }, 0),
                    GongLuYinShu = BitConverter.ToInt16(new byte[] { vData.GongLuYS2, vData.GongLuYS1 }, 0),
                    LouDianLiu = BitConverter.ToInt16(new byte[] { vData.LouDianLiu2, vData.LouDianLiu1 }, 0),
                    LuHao = vData.LuHao,
                    PinLu = BitConverter.ToInt16(new byte[] { vData.PinLu2, vData.PinLu1 }, 0),
                    WenDu = BitConverter.ToInt16(new byte[] { vData.WenDu2, vData.WenDu1 }, 0),
                    WuGongGL = BitConverter.ToInt16(new byte[] { vData.WuGongGL2, vData.WuGongGL1 }, 0),
                    YouGongGL = BitConverter.ToInt16(new byte[] { vData.YouGongGL2, vData.YouGongGL1 }, 0),
                    LeiXing = convertSwitchLeiXing(vData.LeiXing),
                    DianYuanID = BitConverter.ToString(new byte[] { vData.MAC1, vData.MAC2, vData.MAC3, vData.MAC4, vData.MAC5, vData.MAC6 }),
                    ZhuanTai = convertSwitchState( new byte[] {vData.SwitchState1,vData.SwitchState2 } ),
                    Time = DateTime.Now
                     
                };
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    DianYuanTXSJ = DateTime.Now,
                    DianYuan1IP = IPAddress
                };
                m_BasicDBClass_Receive.TransactionBegin();
                int vID = m_BasicDBClass_Receive.InsertRecord(vModel);
                m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("DianYuan1ID='{0}'", vModel.DianYuanID));
                m_BasicDBClass_Receive.TransactionCommit();
                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.DianYuanID) )
                    m_ClientDict[vModel.DianYuanID] = IPAddress;
                //更新客户端最大ID字段
                if (m_ClientMaxID.ContainsKey(vModel.DianYuanID))
                    m_ClientMaxID[vModel.DianYuanID] = vID;
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
                            byte[] vMac = NetHelper.StringToBytes_MAC(vTempResult.DianYuanID);
                            PowerDataPack_Main vCommandDataPack = new PowerDataPack_Main()
                            {
                                Head = 0x5a,
                                Tail = 0x5b,
                                SN = NetHelper.MarkSN_Byte(),// 0x01,//vTempResult.SN ?? 0x00,
                                CMD = vTempResult.CMD ?? 0x00,
                                Addition = 0x00,
                                MAC1 = vMac[0],
                                MAC2 = vMac[1],
                                MAC3 = vMac[2],
                                MAC4 = vMac[3],
                                MAC5 = vMac[4],
                                MAC6 = vMac[5],
                            };
                            List<byte> vCMDDataPack = Helper.NetHelper.StructureToByte(vCommandDataPack).ToList();
                            if ( vTempResult.Data != null )
                            {
                                List<byte> vDataPack = vTempResult.Data.ToList();
                                vCMDDataPack.InsertRange(12, vDataPack);
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
