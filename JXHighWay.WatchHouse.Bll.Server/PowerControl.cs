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
            byte vResult = new byte();
            for (int i = 1; i < dataPack.Length - 1; i++)
            {
                vResult += dataPack[i];
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

                            //处理接收到的岗亭状态数据
                            if (vReceiveData.Data[5] == (byte)PowerDataPack_Receive_CommandEnum.RunningStatus)
                            {
                                PowerDataPack_Receive_RunningStatus vDataPack = Helper.NetHelper.ByteToStructure<PowerDataPack_Receive_RunningStatus>(vReceiveData.Data);
                                processorData_RunningStatus(vDataPack, vReceiveData.IPAddress);
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
        void processorData_RunningStatus(PowerDataPack_Receive_RunningStatus vData, string IPAddress)
        {
           try
            {
                PowerDataEFModel vModel = new PowerDataEFModel()
                {
                    DianLiu = Convert.ToInt16(new byte[] { vData.DianLiu2, vData.DianLiu1 }),
                    DianYa = Convert.ToInt16(new byte[] { vData.DianYa2, vData.DianYa1 }),
                    DianNeng = Convert.ToInt32(new byte[] { vData.DianNeng4, vData.DianNeng3, vData.DianNeng2, vData.DianNeng1 }),
                    GongLuYinShu = Convert.ToInt16(new byte[] { vData.GongLuYS2, vData.GongLuYS1 }),
                    LouDianLiu = Convert.ToInt16(new byte[] { vData.LouDianLiu2, vData.LouDianLiu1 }),
                    LuHao = vData.LuHao,
                    PinLu = Convert.ToInt16(new byte[] { vData.PinLu2, vData.PinLu1 }),
                    WenDu = Convert.ToInt16(new byte[] { vData.WenDu2, vData.WenDu1 }),
                    WuGongGL = Convert.ToInt16(new byte[] { vData.WuGongGL2, vData.WuGongGL1 }),
                    YouGongGL = Convert.ToInt16(new byte[] { vData.YouGongGL2, vData.YouGongGL1 }),
                    LeiXing = convertDianYuanLeiXing(vData.LeiXing)
                };
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    DianYuanTXSJ = DateTime.Now,
                    DianYuanIP = IPAddress
                };
                m_BasicDBClass_Receive.TransactionBegin();
                m_BasicDBClass_Receive.InsertRecord(vModel);
                m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("DianYuanID={0}", vModel.DianYuanID));
                m_BasicDBClass_Receive.TransactionCommit();
                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.DianYuanID.Value) )
                    m_ClientDict[vModel.DianYuanID.Value] = IPAddress;
            }
            catch(Exception ex)
            {
                Console.WriteLine( string.Format("插入数据至[岗亭数据表]中发生异常，异常信息为:{0}",ex.Message));
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
                        AsyncUserToken vAsyncUserToken = findAsyncUserToken(vTempResult.DianYuanID.Value);
                        if (vAsyncUserToken != null)
                        {
                            PowerDataPack_Main vCommandDataPack = new PowerDataPack_Main()
                            {
                                Head = 0x5a,
                                Tail = 0x5b,
                                SN = vTempResult.SN ?? 0x00,
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
                            vCMDDataPack[1] = vLength[0];
                            vCMDDataPack[2] = vLength[1];
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
