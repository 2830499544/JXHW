using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.Net;
using System.Net;
using System.Collections;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Helper;
using MXKJ.DBMiddleWareLib;
using System.Threading;
using JXHighWay.WatchHouse.Net.DataPack;
using System.IO;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WatchHouseControl:BasicControl
    {


        bool m_IsRun = false;
        BasicDBClass m_BasicDBClassSelect = null;

        public WatchHouseControl( )
        {
            Config vConfig = new Config();
            Port = vConfig.WatchHousePort;
            m_BasicDBClassSelect = new BasicDBClass(DataBaseType.MySql);
        }

        public void Start()
        {
            ReceiveQueue = new Queue<WHQueueModel>();

            m_SocketManager = new SocketManager(MaxConnNum, BufferSize);
            m_SocketManager.ClientNumberChange += M_SocketManager_ClientNumberChange;
            m_SocketManager.ReceiveClientData += M_SocketManager_ReceiveClientData;
            m_SocketManager.Init();
            m_SocketManager.Start(new IPEndPoint(IPAddress.Any, Port));
            m_IsRun = true;
            //初始化岗亭信息
            initWathchHouse();

            //处理接收到的数据
            asyncProcessorDataData();

            //处理数据库中的发送指令
            asyncProcessorDBSendCMD();
        }

        /// <summary>
        /// 初始化岗亭信息
        /// </summary>
        void initWathchHouse()
        {
            WatchHouseConfigEFModel[] vWatchHouseConfig= m_BasicDBClass_Receive.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach(WatchHouseConfigEFModel vTempConfig in vWatchHouseConfig)
            {
                m_ClientDict.Add(vTempConfig.GangTingID.Value, "");
            }
        }

        public void Stop()
        {
            m_SocketManager.Stop();
            ReceiveQueue.Clear();
            m_IsRun = false;
        }

        private void M_SocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        {
            if (buff.Length > 0 && buff[0] == 0x02)
            {
                ReceiveQueue.Enqueue(new WHQueueModel(buff, token.IPAddress.ToString()));
                Console.WriteLine(string.Format("收到一组数据,IP地址({0}):{1}", token.IPAddress.ToString(),BitConverter.ToString(buff)));
            }
            //throw new NotImplementedException();
        }

        private void M_SocketManager_ClientNumberChange(int num, AsyncUserToken token)
        {

            //throw new NotImplementedException();
        }


        #region 更新所有岗亭的图片、工号信息

        /// <summary>
        /// 更新所有岗亭工号信息
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, bool>> AsyncUpdateWatchHouseEmployeeInfo(string Url)
        {
            Dictionary<string, bool> vResult = new Dictionary<string, bool>();

            string vPath = System.Environment.CurrentDirectory;
            vPath = string.Format(@"{0}\EmployeeInfo\1.txt", vPath);
            byte[] vSN = NetHelper.MarkSN();
            createEmployeeInfo(vPath, vSN);

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClassSelect.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                List<byte> vDataPack = new List<byte>();
                //增加序号
                vDataPack.AddRange(vSN);
                //增加文件地址
                vDataPack.AddRange(System.Text.Encoding.Default.GetBytes(vPath));

                foreach (WatchHouseConfigEFModel vTempWatchHouseConfigEFModel in vSelectResult)
                {
                    bool vDBResult = await AsyncSendCommandToDB(vTempWatchHouseConfigEFModel.GangTingID ?? 0, WatchHouseDataPack_Send_CommandEnmu.YuanGongXX, vDataPack.ToArray());
                    vResult.Add(vTempWatchHouseConfigEFModel.GangTingMC, vDBResult);
                }
            }
            return vResult;
        }


        void createEmployeeInfo(string filePath,byte[] sn )
        {
            FileStream vFile = new FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter vStreamWriter = new StreamWriter(vFile, new System.Text.UnicodeEncoding());
            vStreamWriter.WriteLine("START");
            vStreamWriter.WriteLine(string.Format("Version=", BitConverter.ToString(sn)));

            EmployeeEFModel[] vEmployeeEFModel = m_BasicDBClassSelect.SelectAllRecordsEx<EmployeeEFModel>();
            if (vEmployeeEFModel != null)
            {
                vStreamWriter.WriteLine( string.Format("DATASum={0}", vEmployeeEFModel.Length));
                foreach(EmployeeEFModel vTempEmployeeEFMode in vEmployeeEFModel)
                {
                    vStreamWriter.WriteLine(string.Format("{0}={1}", vTempEmployeeEFMode.KaHao, vTempEmployeeEFMode.GongHao));
                }
            }
            vStreamWriter.WriteLine("End");
            vStreamWriter.Flush();
            vStreamWriter.Close();
            //vFile.Flush();
            //vFile.Close();
        }


        /// <summary>
        /// 更新所有的岗亭的图片
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, bool>> AsyncUpdateWatchHouseAllPic( string Url)
        {
            Dictionary<string, bool> vResult = new Dictionary<string, bool>();

            EmployeeEFModel[] vEmployeeEFModel = m_BasicDBClassSelect.SelectAllRecordsEx<EmployeeEFModel>();
            if (vEmployeeEFModel!=null)
            {
                List<byte> vDataPack = new List<byte>();
                //序号
                byte[] vSN = NetHelper.MarkSN();
                vDataPack.AddRange(vSN);

                //总数
                byte[] vCount = BitConverter.GetBytes((short)vEmployeeEFModel.Length);
                vDataPack.AddRange(vCount);

                foreach (EmployeeEFModel vTempEmployeeEFModel in vEmployeeEFModel)
                {
                    byte[] vGongHao = BitConverter.GetBytes( vTempEmployeeEFModel.GongHao??0 );
                    vDataPack.AddRange(vGongHao);
                }
                
                //Url地址
                byte[] vUrl = System.Text.Encoding.Default.GetBytes(Url);
                vDataPack.AddRange(vUrl);

                WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClassSelect.SelectAllRecordsEx<WatchHouseConfigEFModel>();
                if (vSelectResult != null && vSelectResult.Length > 0)
                {
                    foreach (WatchHouseConfigEFModel vTempWatchHouseConfigEFModel in vSelectResult)
                    {
                         bool vDBResult = await AsyncSendCommandToDB(vTempWatchHouseConfigEFModel.GangTingID??0, WatchHouseDataPack_Send_CommandEnmu.GenXingTP, vDataPack.ToArray());
                        vResult.Add(vTempWatchHouseConfigEFModel.GangTingMC, vDBResult);
                    }
                }
            }
            return vResult;
        }
        #endregion

        #region 发送指令

        /// <summary>
        /// 发送同步图片命令
        /// </summary>
        /// <returns></returns>
        //public async void SendSynchPicCMD( int GangTingID)
        //{
        //    await Task.Run(() =>
        //    {
        //        while (m_IsRun)
        //        {
        //            AsyncUserToken vAsyncUserToken = findAsyncUserToken(GangTingID);
        //            if (vAsyncUserToken != null)
        //            {
        //                byte[] vSN = NetHelper.MarkSN();
        //                WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
        //                {
        //                    Head = 0x02,
        //                    Length1 = 0x00,//长度固定为35
        //                    Length2 = 0x23,
        //                    Ver1 = 0x00,
        //                    Ver2 = 0x00,
        //                    LoginSN1 = 0x00,
        //                    LoginSN2 = 0x01,
        //                    SN1 = vSN[0],
        //                    SN2 = vSN[1],
        //                    WatchHouseID1 = (byte)(vTempResult.GangTingID.Value >> 24),
        //                    WatchHouseID2 = (byte)(vTempResult.GangTingID.Value >> 16),
        //                    WatchHouseID3 = (byte)(vTempResult.GangTingID.Value >> 8),
        //                    WatchHouseID4 = (byte)(vTempResult.GangTingID.Value >> 0),
        //                    UserID1 = (byte)(vTempResult.GangTingID.Value >> 24),
        //                    UserID2 = (byte)(vTempResult.GangTingID.Value >> 16),
        //                    UserID3 = (byte)(vTempResult.GangTingID.Value >> 8),
        //                    UserID4 = (byte)(vTempResult.GangTingID.Value >> 0),
        //                    ID_H = vTempResult.ID_H.Value,
        //                    ID_L = vTempResult.ID_L.Value,
        //                    CMD = vTempResult.CMD.Value,
        //                    SUB = vTempResult.SUB.Value,
        //                    Data = vTempResult.Data ?? 0x00
        //                };
        //                byte[] vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
        //                byte[] vCheckCode = calcCheckCode(vByteArray);
        //                vCommandDataPack.Check1 = vCheckCode[0];
        //                vCommandDataPack.Check2 = vCheckCode[1];
        //                vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
        //                m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
        //                Console.WriteLine("发送命令数据包,IP地址({0}):{1}", vAsyncUserToken.IPAddress.ToString(), BitConverter.ToString(vByteArray));
        //                //更新数据库状态
        //            }
        //        }
        //    });
        //}

        async void asyncProcessorDBSendCMD()
        {
            await Task.Run(() =>
            {
                while (m_IsRun)
                {
                    WatchHouseSendCMDEFModel vModel = new WatchHouseSendCMDEFModel()
                    {
                        IsSend = false
                    };
                    var vSelectResult = m_BasicDBClass_Send.SelectRecordsEx(vModel);
                    foreach (WatchHouseSendCMDEFModel vTempResult in vSelectResult)
                    {
                        AsyncUserToken vAsyncUserToken = findAsyncUserToken(vTempResult.GangTingID.Value);
                        if (vAsyncUserToken != null)
                        {
                            byte[] vSN = BitConverter.GetBytes(vTempResult.SN??0);
                            List<byte> vDataPack = System.Text.Encoding.Default.GetBytes(vTempResult.Data).ToList();
                            byte[] vByteArray = null;
                            vByteArray = processorDBSendCMD_JoinData(vTempResult, vDataPack);
                            //WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
                            //{
                            //    Head = 0x02,
                            //    Length1 = 0x00,//长度固定为35
                            //    Length2 = 0x23,
                            //    Ver1 = 0x00,
                            //    Ver2 = 0x00,
                            //    LoginSN1 = 0x00,
                            //    LoginSN2 = 0x01,
                            //    SN1 = vSN[0],
                            //    SN2 = vSN[1],
                            //    WatchHouseID1 = (byte)(vTempResult.GangTingID.Value>>24),
                            //    WatchHouseID2 = (byte)(vTempResult.GangTingID.Value >>16),
                            //    WatchHouseID3 = (byte)(vTempResult.GangTingID.Value >>8),
                            //    WatchHouseID4 = (byte)(vTempResult.GangTingID.Value >> 0),
                            //    UserID1 = (byte)(vTempResult.GangTingID.Value>>24),
                            //    UserID2 = (byte)(vTempResult.GangTingID.Value >>16),
                            //    UserID3 = (byte)(vTempResult.GangTingID.Value >>8),
                            //    UserID4 = (byte)(vTempResult.GangTingID.Value >>0),
                            //    ID_H = vTempResult.ID_H.Value,
                            //    ID_L = vTempResult.ID_L.Value,
                            //    CMD = vTempResult.CMD.Value,
                            //    SUB = vTempResult.SUB.Value,
                            //    Data = vTempResult.Data??0x00
                            //};
                            //byte[] vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                            //byte[] vCheckCode = calcCheckCode(vByteArray);
                            //vCommandDataPack.Check1 = vCheckCode[0];
                            //vCommandDataPack.Check2 = vCheckCode[1];
                            //vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                            m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
                            Console.WriteLine("发送命令数据包,IP地址({0}):{1}", vAsyncUserToken.IPAddress.ToString(), BitConverter.ToString(vByteArray));
                            //更新数据库状态
                            vModel.IsSend = true;
                            vModel.ID = vTempResult.ID;
                            m_BasicDBClass_Send.UpdateRecord<WatchHouseSendCMDEFModel>(vModel);
                        }
                    }
                }
            });
        }

        byte[] processorDBSendCMD_JoinData(WatchHouseSendCMDEFModel vTempResult, List<byte> dataPack)
        {
            byte[] vSN = BitConverter.GetBytes(vTempResult.SN ?? 0);
            //List<byte> vDataPack = System.Text.Encoding.Default.GetBytes(vTempResult.Data).ToList();
            WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
            {
                Head = 0x02,
                //Length1 = 0x00,//长度固定为35
                //Length2 = 0x23,
                Ver1 = 0x00,
                Ver2 = 0x00,
                LoginSN1 = 0x00,
                LoginSN2 = 0x01,
                SN1 = vSN[0],
                SN2 = vSN[1],
                WatchHouseID1 = (byte)(vTempResult.GangTingID.Value >> 24),
                WatchHouseID2 = (byte)(vTempResult.GangTingID.Value >> 16),
                WatchHouseID3 = (byte)(vTempResult.GangTingID.Value >> 8),
                WatchHouseID4 = (byte)(vTempResult.GangTingID.Value >> 0),
                UserID1 = (byte)(vTempResult.GangTingID.Value >> 24),
                UserID2 = (byte)(vTempResult.GangTingID.Value >> 16),
                UserID3 = (byte)(vTempResult.GangTingID.Value >> 8),
                UserID4 = (byte)(vTempResult.GangTingID.Value >> 0),
                ID_H = vTempResult.ID_H.Value,
                ID_L = vTempResult.ID_L.Value,
                CMD = vTempResult.CMD.Value,
                SUB = vTempResult.SUB.Value,
                Data = dataPack == null ? (byte)0x00 : dataPack[0]
            };
            List<byte> vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack).ToList();
            if (dataPack == null)
                vByteArray.Insert(21, 0x00);
            else
                vByteArray.InsertRange(21, dataPack);
            //长度
            byte[] vLength = BitConverter.GetBytes((short)vByteArray.Count);
            vByteArray[1] = vLength[0];
            vByteArray[2] = vLength[1];
            //校验码
            byte[] vCheckCode = calcCheckCode(vByteArray.ToArray());
            vByteArray[vByteArray.Count-1] = vCheckCode[0];
            vByteArray[vByteArray.Count-1] = vCheckCode[1];
            //vCommandDataPack.Check1 = vCheckCode[0];
            //vCommandDataPack.Check2 = vCheckCode[1];
            //vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
            return vByteArray.ToArray();
        }

        public async Task<bool> AsyncSendCommand(int WatchHouseID,WatchHouseDataPack_Send_CommandEnmu Command )
        {
            bool vResult = false;
            await Task.Run(() =>
            {
                AsyncUserToken vAsyncUserToken = findAsyncUserToken(WatchHouseID);
                if (vAsyncUserToken != null)
                {
                    byte[] vSN = NetHelper.MarkSN();
                    WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
                    {
                        Head = 0x20,
                        Length1 = 0x00,//长度固定为35
                        Length2 = 0x23,
                        Ver1 = 0x00,
                        Ver2 = 0x00,
                        LoginSN1 = 0x00,
                        LoginSN2 = 0x01,
                        SN1 = vSN[0],
                        SN2 = vSN[1],
                        WatchHouseID1 = (byte)(WatchHouseID>>24),
                        WatchHouseID2 = (byte)(WatchHouseID >>16),
                        WatchHouseID3 = (byte)(WatchHouseID >>8),
                        WatchHouseID4 = (byte)(WatchHouseID >>0),
                        UserID1 = 0x00,
                        UserID2 = 0x00,
                        UserID3 = 0x00,
                        UserID4 = 0x00,
                        ID_H = (byte)((int)Command >> 24),
                        ID_L = (byte)((int)Command >> 16),
                        CMD = (byte)((int)Command >> 8),
                        SUB = (byte)((int)Command >> 0)
                    };
                    byte[] vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                    byte[] vCheckCode = calcCheckCode(vByteArray);
                    vCommandDataPack.Check1 = vCheckCode[0];
                    vCommandDataPack.Check2 = vCheckCode[1];
                    vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                    m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
                    Console.WriteLine(string.Format("发送命令:{0}", BitConverter.ToString(vByteArray)));
                  
                }
             
            });
            return vResult;
        }

        public async Task<bool> AsyncSendCommandToDB(int WatchHouseID, 
            WatchHouseDataPack_Send_CommandEnmu Command,byte[] DataPack)
        {
            bool vResult = false;
            await Task.Run(() =>
            {
                WatchHouseSendCMDEFModel vSendCMDEFModel = new WatchHouseSendCMDEFModel()
                {
                    GangTingID = WatchHouseID,
                    ID_H = (byte)((int)Command >> 24),
                    ID_L = (byte)((int)Command >> 16),
                    CMD = (byte)((int)Command >> 8),
                    SUB = (byte)((int)Command >> 0),
                    SendTime = DateTime.Now,
                    SN = BitConverter.ToInt16(NetHelper.MarkSN(), 0),
                    State = false,
                    Data = System.Text.Encoding.Default.GetString(DataPack)
                };
                int vID = m_BasicDBClass_Receive.InsertRecord(vSendCMDEFModel);
                Thread.Sleep(1000);
                WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClass_Receive.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
                vResult = vSelectResult.State ?? false;
                vSendCMDEFModel = new WatchHouseSendCMDEFModel()
                {
                    ID = vID,
                    State = false
                };
                m_BasicDBClass_Receive.UpdateRecord(vSendCMDEFModel);
            });
            return vResult;
        }

        public async Task<bool> AsyncSendCommandToDB(int WatchHouseID, WatchHouseDataPack_Send_CommandEnmu Command)
        {
            bool vResult = false;
            await Task.Run(() =>
            {
                WatchHouseSendCMDEFModel vSendCMDEFModel = new WatchHouseSendCMDEFModel()
                {
                    GangTingID = WatchHouseID,
                    ID_H = (byte)((int)Command >> 24),
                    ID_L = (byte)((int)Command >> 16),
                    CMD = (byte)((int)Command >> 8),
                    SUB = (byte)((int)Command >> 0),
                    SendTime = DateTime.Now,
                    SN = BitConverter.ToInt16( NetHelper.MarkSN(),0 ),
                    State = false
                };
                int vID = m_BasicDBClass_Receive.InsertRecord(vSendCMDEFModel);
                Thread.Sleep(1000);
                WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClass_Receive.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
                vResult = vSelectResult.State??false;
                vSendCMDEFModel = new WatchHouseSendCMDEFModel()
                {
                    ID = vID,
                    State = false
                };
                m_BasicDBClass_Receive.UpdateRecord(vSendCMDEFModel);
            });
            return vResult;
        }

        /// <summary>
        /// 计算校验码
        /// </summary>
        /// <param name="dataPack"></param>
        /// <returns></returns>
         byte[] calcCheckCode(byte[] dataPack)
        {
            byte[] vResult = new byte[2];
            var vCalcResult=0x0000;
            for( int i=0;i<dataPack.Length-2;i++)
            {
                vCalcResult += dataPack[i];
            }
            vResult[0] = (byte)(vCalcResult >> 8);
            vResult[1] = (byte)(vCalcResult >> 0);
            return vResult;
        }

        #endregion


        #region 处理接收到的数据
        /// <summary>
        /// 异步处理数据
        /// </summary>
        async void asyncProcessorDataData()
        {
            await processorData();
        }

        /// <summary>
        /// 转换空调工作模式(0:自动模式 1:制冷模式 2:除湿模式 3:制热模式 4:送风模式)
        /// </summary>
        /// <param name="GZMS"></param>
        /// <returns></returns>
        string convertKongTiaoGZMS(byte GZMS)
        {
            string vResult = "";
            switch ( GZMS )
            {
                case 0:
                    vResult = "自动模式";
                    break;
                case 1:
                    vResult = "制冷模式";
                    break;
                case 2:
                    vResult = "除湿模式";
                    break;
                case 3:
                    vResult = "制热模式";
                    break;
                case 4:
                    vResult = "送风模式";
                    break;
            }
            return vResult;
        }


        /// <summary>
        /// 转换工作风量
        /// </summary>
        /// <param name="GZFL"></param>
        /// <returns></returns>
        string convertKongTiaoGZFL(byte GZFL)
        {
            string vResult = "";
            switch ( GZFL )
            {
                case 0:
                    vResult = "低风";
                    break;
                case 1:
                    vResult = "中风";
                    break;
                case 2:
                    vResult = "高风";
                    break;
            }
            return vResult;
        }

        string convertKongQiZL(byte ZL)
        {
            string vResult = "";
            switch (ZL)
            {
                case 1:
                    vResult = "优";
                    break;
                case 2:
                    vResult = "良";
                    break;
                case 3:
                    vResult = "轻度污染";
                    break;
                case 4:
                    vResult = "中度污染";
                    break;
                case 5:
                    vResult = "重度污染";
                    break;
                case 6:
                    vResult = "严重污染";
                    break;
            }
            return vResult;
        }

        string convertDianLiuJK(byte DianLiu)
        {
            string vResult = "";
            return vResult;
        }

        string convertMenKongCKQ(byte MenKong)
        {
            string vResult = "";
            return vResult;
        }

        string convertChuangKongCKQ(byte ChuangKong)
        {
            string vResult = "";
            return vResult;
        }

        string convertGongKongJSC(byte GongKongJSC)
        {
            string vResult = "";
            return vResult;
        }

        string convertGongKongJSR(byte GongKongJSR)
        {
            string vResult = "";
            return vResult;
        }

        private Task processorData()
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
                           if ( vReceiveData.Data[23]==0x10 && vReceiveData.Data[24] == 0x20 )
                            {
                                //byte[] vCheckCode = calcCheckCode(vReceiveData.Data);
                                WatchHouseDataPack_Receive_Main vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Main>(vReceiveData.Data);
                                processorData_Receive(vDataPack, vReceiveData.IPAddress);
                            }

                           //门禁记录
                            if (vReceiveData.Data[23] == 0x00 && vReceiveData.Data[24] == 0x21)
                            {
                                WatchHouseDataPack_Receive_DoorGuard vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_DoorGuard>(vReceiveData.Data);
                                processorData_DoorGuard(vDataPack);
                            }

                            //电子工作牌
                            if (vReceiveData.Data[23] == 0x00 && vReceiveData.Data[24] == 0x22)
                            {
                                WatchHouseDataPack_Receive_IDCard vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_IDCard>(vReceiveData.Data);
                                processorData_IDCard(vDataPack);
                            }

                            //处理发送命令的返回
                            if (vReceiveData.Data[21]==0x02 && ( vReceiveData.Data[22]==0x02 || vReceiveData.Data[22]==0x03 
                            || vReceiveData.Data[22] == 0x04 || vReceiveData.Data[22] == 0x05 || 
                            vReceiveData.Data[22] == 0x0c || vReceiveData.Data[22] == 0x10 ))
                            {
                                WatchHouseDataPack_SendData_Main vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_SendData_Main>(vReceiveData.Data);
                                processorData_ReturnCMD(vDataPack, vReceiveData.IPAddress);
                            }

                            //处理图片更新命令返回
                            if (vReceiveData.Data[21] == 0x02 && vReceiveData.Data[22] == 0x01 && vReceiveData.Data[23] == 0x10 && vReceiveData.Data[23] == 0x02)
                            {
                                WatchHouseDataPack_Receive_Pic vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Pic>(vReceiveData.Data);
                                processorData_ReturnPic(vDataPack, vReceiveData.IPAddress);
                            }

                            //处理员工信息更新命令返回
                            if (vReceiveData.Data[21] == 0x02 && vReceiveData.Data[22] == 0x01 && vReceiveData.Data[23] == 0x10 && vReceiveData.Data[23] == 0x03)
                            {
                                WatchHouseDataPack_Receive_Pic vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Pic>(vReceiveData.Data);
                                processorData_ReturnPic(vDataPack, vReceiveData.IPAddress);
                            }


                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine( string.Format("处理数据报时发生异常,错误信息{0}",ex.Message));
                    }
                }
            });
        }
        void processorData_IDCard(WatchHouseDataPack_Receive_IDCard vData)
        {
            IDCardEFModel vModel = new IDCardEFModel()
            {
                GangTingID = BitConverter.ToInt32( new byte[] { vData.WatchHouseID1, vData.WatchHouseID2, vData.WatchHouseID3, vData.WatchHouseID4 },0 ),
                ShiJiang = DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                HuanBan = vData.HuanBan == 0x01?"换班":"",
                WeiYIID= vData.UniqID
            };
            m_BasicDBClass_Receive.InsertRecord(vModel);
        }


        void processorData_DoorGuard(WatchHouseDataPack_Receive_DoorGuard vData)
        {
            DoorGuardEFModel vModel = new DoorGuardEFModel()
            {
                GangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID1, vData.WatchHouseID2, vData.WatchHouseID3, vData.WatchHouseID4 },0),
                //20170503155601
                ShiJiang = DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                KaiHao = vData.KaHao0,
                DongZuo = vData.MenZhuangTai==0?"关闭":"开门"
            };
            m_BasicDBClass_Receive.InsertRecord(vModel);
        }

        void processorData_ReturnCMD(WatchHouseDataPack_SendData_Main vData, string IPAddress)
        {
            int vGangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0);
            short vSN = BitConverter.ToInt16(new byte[] { vData.SN1, vData.SN2 }, 0);
            WatchHouseSendCMDEFModel vSendCMDModel = new WatchHouseSendCMDEFModel()
            {
                State = vData.Data == 0x5a ? true : false,
                IsReply = true
                
            };
            m_BasicDBClass_Return.UpdateRecord(vSendCMDModel, string.Format("GangTingID={0} and SN={1} and IsSend=1", vGangTingID, vSN));
        }

        void processorData_ReturnPic(WatchHouseDataPack_Receive_Pic vData, string IPAddress)
        {
            int vGangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0);
            short vSN = BitConverter.ToInt16(new byte[] { vData.SN1, vData.SN2 }, 0);
            WatchHouseSendCMDEFModel vSendCMDModel = new WatchHouseSendCMDEFModel()
            {
                State = vData.Data3 == 0x5a ? true : false,
                IsReply = true

            };
            m_BasicDBClass_Return.UpdateRecord(vSendCMDModel, string.Format("GangTingID={0} and SN={1} and IsSend=1", vGangTingID, vSN));
        }

        void processorData_Receive(WatchHouseDataPack_Receive_Main vData,string IPAddress)
        {
            try
            {
                WathHouseDataEFModel vModel = new WathHouseDataEFModel()
                {
                    WatchHouseID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0),
                    MenZhuanTai = vData.MenZhuanTai == 0 ? "开" : "关",
                    DianChiSuo = vData.DianChiSuo == 0 ? "开" : "关",
                    JiXieSuo = vData.JiXieSuo == 0 ? "开" : "关",
                    BaoJingQi = vData.BaoJingQi == 0 ? "闭" : "开",
                    Chuang = vData.Chuang == 0 ? "开" : "关",
                    FengMu = vData.FengMu == 0 ? "闭" : "开",
                    ChuangDeng = vData.ChuangDeng == 0 ? "闭" : "开",
                    XinFeng = vData.XinFeng == 0 ? "闭" : "开",
                    Deng = vData.Deng == 0 ? "闭" : "开",
                    DiNuan = vData.DiNuan == 0 ? "闭" : "开",
                    ZuoNuanJQ = vData.ZuoNuanJQ == 0 ? "闭" : "开",
                    YouNuanJQ = vData.YouNuanJQ == 0 ? "闭" : "开",
                    ShiLeiWD = BitConverter.ToInt16(new byte[] { vData.ShiLeiWD2, vData.ShiLeiWD1 }, 0),
                    ShiLeiSD = vData.ShiLeiSD,
                    KongTiao = vData.KongTiao == 0 ? "闭" : "开",
                    KongTiaoGZMS = convertKongTiaoGZMS(vData.KongTiaoGZMS),
                    KongTiaoGZFL = convertKongTiaoGZFL(vData.KongTiaoGZFL),
                    KongQiZL = convertKongQiZL(vData.KongQiZL),
                    XinFengXTKQZL = vData.XinFengXTKQZL,
                    XinFengDJ = vData.XinFengDJ,
                    XinFengWD = BitConverter.ToInt16(new byte[] { vData.XinFengWD2, vData.XinFengWD1 }, 0),
                    RuKouAPM = BitConverter.ToInt16(new byte[] { vData.RuKouFAPM2, vData.RuKouFAPM1 }, 0),
                    ChuKouAPM = BitConverter.ToInt16(new byte[] { vData.ChuKouAPM2, vData.ChuKouAPM1 }, 0),
                    CaiLuanKZWD = vData.CaiLuanKZWD,
                    CaiLuanKZWBWD = BitConverter.ToInt16(new byte[] { vData.CaiLuanKZWBWD2, vData.CaiLuanKZWBWD1 }, 0),
                    CaiLuanKZDBWD = BitConverter.ToInt16(new byte[] { vData.CaiLuanKZDBWD2, vData.CaiLuanKZDBWD1 }, 0),
                    DianLiuJK = convertDianLiuJK(vData.DianLiuJK),
                    MenKongCKQ = convertMenKongCKQ(vData.MenKongCKQ),
                    ChuangKongCKQ = convertChuangKongCKQ(vData.ChuangKongCKQ),
                    GongKongJSC = convertGongKongJSC(vData.GongKongJSC),
                    GongKongJSR = convertGongKongJSR(vData.GongKongJSR),
                    DengGuanLD = vData.DengGuanLD,
                    XieRuSJ = DateTime.Now
                };
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    GangTingTXSJ = DateTime.Now,
                    GangTingIP = IPAddress
                };
                m_BasicDBClass_Receive.TransactionBegin();
                m_BasicDBClass_Receive.InsertRecord(vModel);
                m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("GangTingID={0}", vModel.WatchHouseID));
                m_BasicDBClass_Receive.TransactionCommit();
                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.WatchHouseID.Value) )
                    m_ClientDict[vModel.WatchHouseID.Value] = IPAddress;
            }
            catch(Exception ex)
            {
                Console.WriteLine( string.Format("插入数据至[岗亭数据表]中发生异常，异常信息为:{0}",ex.Message));
            }
        }
    #endregion
    }
}
