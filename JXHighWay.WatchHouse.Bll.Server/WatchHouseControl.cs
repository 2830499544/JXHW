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
using System.Data;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WatchHouseControl:BasicControl
    {
        new Dictionary<int, string> m_ClientDict = null;
        Dictionary<int, int> m_ClientMaxID = null;

        bool m_IsRun = false;
        BasicDBClass m_BasicDBClassSelect = null;

        public WatchHouseControl( )
        {
            Config vConfig = new Config();
            Port = vConfig.WatchHousePort;
            m_BasicDBClassSelect = new BasicDBClass(DataBaseType.MySql);
            m_ClientDict = new Dictionary<int, string>();
            m_ClientMaxID = new Dictionary<int, int>();
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
                m_ClientDict.Add(vTempConfig.GangTingID??0, "");
                m_ClientMaxID.Add(vTempConfig.GangTingID ??0,0);
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
                string vOutInfo = string.Format("岗亭收到一组数据,IP地址({0}):{1}", token.IPAddress.ToString(), BitConverter.ToString(buff));
                Console.WriteLine(vOutInfo);
                LogHelper.WriteLog_Debug(typeof(WatchHouseControl), vOutInfo);
            }
            //throw new NotImplementedException();
        }

        private void M_SocketManager_ClientNumberChange(int num, AsyncUserToken token)
        {

            //throw new NotImplementedException();
        }


        #region 更新所有岗亭的图片、工号信息、App

        public async Task<Dictionary<string, bool>> AsyncUpdateWatchHouseApp(string AppPath,byte[] Ver,
            bool Update,string Url)
        {
            Dictionary<string, bool> vResult = new Dictionary<string, bool>();

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClassSelect.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                //拷贝文件
                string vPath = System.Environment.CurrentDirectory;
                string vFileName = AppPath.Remove(0, AppPath.LastIndexOf('\\')+1);
                File.Copy(AppPath, string.Format(@"{0}\App\{1}", vPath, vFileName),true);

                List<byte> vDataPack = new List<byte>();
                //增加序号
                vDataPack.AddRange(Ver);
                //增加文件地址
                string vDownUrl = string.Format(@"{0}/{1}", Url, vFileName);
                vDataPack.AddRange(System.Text.Encoding.Default.GetBytes(vDownUrl));
                //是否强制更新
                vDataPack.Add(Update ?(byte)0x01 :(byte)0x00);

                foreach (WatchHouseConfigEFModel vTempWatchHouseConfigEFModel in vSelectResult)
                {
                    bool vDBResult = await AsyncSendCommandToDB(vTempWatchHouseConfigEFModel.GangTingID ?? 0, WatchHouseDataPack_Send_CommandEnmu.GenXingApp, vDataPack.ToArray());
                    vResult.Add(vTempWatchHouseConfigEFModel.GangTingMC, vDBResult);
                }
            }
            return vResult;
        }

        /// <summary>
        /// 更新所有岗亭工号信息
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, bool>> AsyncUpdateWatchHouseEmployeeInfo(string Url)
        {
            Dictionary<string, bool> vResult = new Dictionary<string, bool>();

            string vPath = System.Environment.CurrentDirectory;
            vPath = string.Format(@"{0}\EmployeeInfo\CardAndWork.txt", vPath);
            byte[] vSN = NetHelper.MarkSN();
            createEmployeeInfo(vPath, vSN);

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClassSelect.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                List<byte> vDataPack = new List<byte>();
                //增加序号
                vDataPack.AddRange(vSN);
                //增加文件地址
                string vDownUrl = string.Format(@"{0}/CardAndWork.txt", Url);
                vDataPack.AddRange(System.Text.Encoding.Default.GetBytes(vDownUrl));

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
            StreamWriter vStreamWriter = new StreamWriter(vFile, new System.Text.UTF8Encoding());
            vStreamWriter.WriteLine("START");
            vStreamWriter.WriteLine(string.Format("Version=99", BitConverter.ToString(sn)));

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


        public async void AsyncUpdateGongHao(int GongHao)
        {
            byte[] vGongHao = BitConverter.GetBytes(GongHao);
            byte[] vDataPack = new byte[] { vGongHao[3], vGongHao[2],vGongHao[1],vGongHao[0] };
            bool vDBResult = await AsyncSendCommandToDB(20010902, WatchHouseDataPack_Send_CommandEnmu.XiangShiGongHao, vDataPack);
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
                vDataPack.Add(vCount[1]);
                vDataPack.Add(vCount[0]);

                foreach (EmployeeEFModel vTempEmployeeEFModel in vEmployeeEFModel)
                {
                    byte[] vGongHao = BitConverter.GetBytes( vTempEmployeeEFModel.GongHao??0 );
                    vDataPack.AddRange( new byte[] { vGongHao[3], vGongHao[2], vGongHao[1], vGongHao[0] });
                }
                
                //Url地址
                byte[] vUrl = System.Text.Encoding.UTF8.GetBytes(Url);
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

        protected AsyncUserToken findAsyncUserToken(int id)
        {
            AsyncUserToken vResult = null;
            if (m_ClientDict.ContainsKey(id))
            {
                string vIPAddress = m_ClientDict[id];
                vResult = m_SocketManager.ClientList.Where(m => m.IPAddress.ToString() == vIPAddress).FirstOrDefault();
            }

            return vResult;
        }

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
                            //List<byte> vDataPack = System.Text.Encoding.UTF8.GetBytes(vTempResult.Data??"").ToList();
                            List<byte> vDataPack = vTempResult.Data==null? new List<byte>():vTempResult.Data.ToList();
                            byte[] vByteArray = null;
                            vByteArray = processorDBSendCMD_JoinData(vTempResult, vDataPack);
                            m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
                            string vOutInfo = string.Format("岗亭发送命令数据包,IP地址({0}):{1}", vAsyncUserToken.IPAddress.ToString(), BitConverter.ToString(vByteArray));
                            Console.WriteLine(vOutInfo);
                            LogHelper.WriteLog_Debug(typeof(WatchHouseControl), vOutInfo);
                            //更新数据库状态
                            vModel.IsSend = true;
                            vModel.ID = vTempResult.ID;
                            m_BasicDBClass_Send.UpdateRecord<WatchHouseSendCMDEFModel>(vModel);
                        }
                    }
                    Thread.Sleep(100);
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
                Data = dataPack.Count==0 ? (byte)0x00 : dataPack[0]
            };
            List<byte> vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack).ToList();
            if (dataPack.Count > 1)
            {
                //bool vv = vByteArray.Remove(vByteArray[25]);
                vByteArray.RemoveAt(25);
                vByteArray.InsertRange(25, dataPack);
            }

            //if (dataPack.Count == 0)
            //    vByteArray.Insert(21, 0x00);
            //else
            //    vByteArray.InsertRange(21, dataPack);
            //长度
            byte[] vLength = BitConverter.GetBytes((short)vByteArray.Count-1);
            vByteArray[1] = vLength[1];
            vByteArray[2] = vLength[0];
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
                    string vOutInfo = string.Format("岗亭发送命令:{0}", BitConverter.ToString(vByteArray));
                    Console.WriteLine( vOutInfo);
                    LogHelper.WriteLog_Debug(typeof(WatchHouseControl), vOutInfo);
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
                    Data = DataPack,
                    IsReply = false,
                    IsSend = false
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

                            int vReceiveCMD = BitConverter.ToInt32(new byte[] { vReceiveData.Data[24], vReceiveData.Data[23], vReceiveData.Data[22], vReceiveData.Data[21] },0 );
                            switch( vReceiveCMD)
                            {
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiMen: //开门
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanMen: //关门
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ShangShuo: //上锁
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiShuo: //开锁
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiBaoJing: //开报警
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanBaoJing: //关报警
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiChuang: //开窗
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanChaugn: //关窗
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiFengMu: //开风幕
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanFengMu://关风幕
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiChuangDeng://开窗灯
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanChuangDeng://关窗灯
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiXinFeng://开新风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanXinFeng://关新风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.TiaoJieFL://调节风量
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiDeng://开灯
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanDeng://关灯
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.SheZhiLD://设置亮度
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiKongTiao://开空调
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanKongTiao://关空调
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiLeng://制冷
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ChuShi: //除湿
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiLe: //制热
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.SongFeng://送风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiDong: //自动
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.DiFeng: //低风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhongFeng://中风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GaoFeng://高风
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.SheZhiWD://设置温度
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiDiNuan://开地暖
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanDiNuan://关地暖
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiYouNJ://开右暖脚
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanYouNJ://关右暖脚
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiZuoNJ://开左暖脚
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanZuoNJ://关左暖脚
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.QianChuanLSS://前窗帘上升
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.QianChuanLXJ://前窗帘下降
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.YouChuanLSS://右窗帘上升
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.YouChuanLXJ://右窗帘下降
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.TiaoJieSW://调节室温
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.XianShiGZPH://指定显示工作片号
                                    WatchHouseDataPack_SendData_Main vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_SendData_Main>(vReceiveData.Data);
                                    processorData_ReturnCMD(vDataPack, vReceiveData.IPAddress, vReceiveCMD);
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GongZuoSJ://岗亭返回的工作数据
                                    switch(vReceiveData.Data[17])
                                    {
                                        case 0x00://安卓单向岗亭
                                            WatchHouseDataPack_Receive_Main vDataPack1 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Main>(vReceiveData.Data);
                                            processorData_Receive(vDataPack1, vReceiveData.IPAddress);
                                            break;
                                        case 0x01://安卓双向岗亭 
                                            WatchHouseDataPack_Receive_MainSX vDataPack6 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_MainSX>(vReceiveData.Data);
                                            processorData_ReceiveSX(vDataPack6, vReceiveData.IPAddress);
                                            break;
                                    }
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.MenJingJL://门禁记录
                                    WatchHouseDataPack_Receive_DoorGuard vDataPack2 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_DoorGuard>(vReceiveData.Data);
                                    processorData_DoorGuard(vDataPack2);
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.DianZhiGHP://电子工作牌
                                    WatchHouseDataPack_Receive_IDCard vDataPack3 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_IDCard>(vReceiveData.Data);
                                    processorData_IDCard(vDataPack3);
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.TuPianGX://图片更新 
                                    WatchHouseDataPack_Receive_Pic vDataPack4 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Pic>(vReceiveData.Data);
                                    processorData_ReturnPic(vDataPack4, vReceiveData.IPAddress);
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.GongHaoGX://工号更新
                                    WatchHouseDataPack_Receive_Pic vDataPack5 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Pic>(vReceiveData.Data);
                                    processorData_ReturnPic(vDataPack5, vReceiveData.IPAddress);
                                    break;
                                case (int)WatchHouseDataPack_Receive_CommandEnmu.AppGenXing://App更新
                                    WatchHouseDataPack_Receive_App vDataPack7 = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_App>(vReceiveData.Data);
                                    processorData_ReturnApp(vDataPack7, vReceiveData.IPAddress);
                                    break;
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch(Exception ex)
                    {
                        string vOutInfo = string.Format("岗亭处理数据报时发生异常,错误信息{0}", ex.Message);
                        Console.WriteLine(vOutInfo);
                        LogHelper.WriteLog_Error(typeof(WatchHouseControl), vOutInfo);
                    }
                }
            });
        }
        void processorData_IDCard(WatchHouseDataPack_Receive_IDCard vData)
        {
            IDCardEFModel vModel = new IDCardEFModel()
            {
                GangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0),
                ShiJiang = DateTime.Now,// DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                //vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                //vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                HuanBan = vData.HuanBan == 0x01 ? "换班" : "下班",
                GongHao = BitConverter.ToInt32( new byte[] { vData.GongHao4, vData.GongHao3, vData.GongHao2, vData.GongHao1 },0 )//  vData.UniqID
            };
            m_BasicDBClass_Receive.TransactionBegin();
            m_BasicDBClass_Receive.InsertRecord(vModel);
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel();
            if (vModel.HuanBan == "换班")
                vWatchHouseConfigEFModel.GongHao = vModel.GongHao;
            else
                vWatchHouseConfigEFModel.GongHao = 0;
            string vSql = string.Format("GangTingID={0}", vModel.GangTingID);
            m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, vSql);
            m_BasicDBClass_Receive.TransactionCommit();
        }


        void processorData_DoorGuard(WatchHouseDataPack_Receive_DoorGuard vData)
        {
            DoorGuardEFModel vModel = new DoorGuardEFModel()
            {
                GangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0),
                //20170503155601
                //ShiJiang = DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                //vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                //vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                //KaiHao = vData.KaHao0,
                KaiHao = BitConverter.ToInt32(new byte[] { vData.KaHao3, vData.KaHao2, vData.KaHao1, vData.KaHao0 },0),
                ShiJiang = DateTime.Now,
                MoShi = vData.KaiMenMS==0x00?"用户卡号":"密码开门",
                DongZuo = vData.MenZhuangTai==0?"关闭":"开门"
            };
            m_BasicDBClass_Receive.InsertRecord(vModel);
        }

        void processorData_ReturnCMD(WatchHouseDataPack_SendData_Main vData, string IPAddress,
            int Command)
        {
            int vGangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0);
            short vSN = BitConverter.ToInt16(new byte[] { vData.SN1, vData.SN2 }, 0);
            WatchHouseSendCMDEFModel vSendCMDModel = new WatchHouseSendCMDEFModel()
            {
                State = vData.Data == 0x5a ? true : false,
                IsReply = true
                
            };
            if (vSendCMDModel.State??false)
            {
                if (m_ClientMaxID.ContainsKey(vGangTingID) )
                {
                    WathHouseDataEFModel vModel = new WathHouseDataEFModel()
                    {
                        ID = m_ClientMaxID[vGangTingID]
                    };
                    switch( Command )
                    {
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiMen: //开门
                            vModel.MenZhuanTai = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanMen: //关门
                            vModel.MenZhuanTai = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ShangShuo: //上锁
                            vModel.DianChiSuo = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiShuo: //开锁
                            vModel.DianChiSuo = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiBaoJing: //开报警
                            vModel.BaoJingQi = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanBaoJing: //关报警
                            vModel.BaoJingQi = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiChuang: //开窗
                            vModel.Chuang = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanChaugn: //关窗
                            vModel.Chuang = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiFengMu: //开风幕
                            vModel.FengMu = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanFengMu://关风幕
                            vModel.FengMu = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiChuangDeng://开窗灯
                            vModel.ChuangDeng = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanChuangDeng://关窗灯
                            vModel.ChuangDeng = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiXinFeng://开新风
                            vModel.XinFeng = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanXinFeng://关新风
                            vModel.XinFeng = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.TiaoJieFL://调节风量

                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiDeng://开灯
                            vModel.Deng = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanDeng://关灯
                            vModel.Deng = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.SheZhiLD://设置亮度
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiKongTiao://开空调
                            vModel.KongTiao = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanKongTiao://关空调
                            vModel.KongTiao = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiLeng://制冷
                            vModel.KongTiaoGZMS = "制冷模式";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ChuShi: //除湿
                            vModel.KongTiaoGZMS = "除湿模式";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiLe: //制热
                            vModel.KongTiaoGZMS = "制热模式";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.SongFeng://送风
                            vModel.KongTiaoGZMS = "送风模式";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhiDong: //自动
                            vModel.KongTiaoGZMS = "自动模式";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.DiFeng: //低风
                            vModel.KongTiaoGZFL = "低风";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.ZhongFeng://中风
                            vModel.KongTiaoGZFL = "中风";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GaoFeng://高风
                            vModel.KongTiaoGZFL = "高风";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.SheZhiWD://设置温度
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiDiNuan://开地暖
                            vModel.DiNuan = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanDiNuan://关地暖
                            vModel.DiNuan = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiYouNJ://开右暖脚
                            vModel.YouNuanJQ = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanYouNJ://关右暖脚
                            vModel.YouNuanJQ = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.KaiZuoNJ://开左暖脚
                            vModel.ZuoNuanJQ = "开";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.GuanZuoNJ://关左暖脚
                            vModel.ZuoNuanJQ = "关";
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.QianChuanLSS://前窗帘上升
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.QianChuanLXJ://前窗帘下降
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.YouChuanLSS://右窗帘上升
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.YouChuanLXJ://右窗帘下降
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.TiaoJieSW://调节室温
                            break;
                        case (int)WatchHouseDataPack_Receive_CommandEnmu.XianShiGZPH://指定显示工作片号
                            break;
                    }
                    m_BasicDBClass_Return.UpdateRecord<WathHouseDataEFModel>(vModel);
                }
            }
            m_BasicDBClass_Return.UpdateRecord(vSendCMDModel, string.Format("GangTingID={0} and SN={1} and IsSend=1", vGangTingID, vSN));
        }


        void processorData_ReturnApp(WatchHouseDataPack_Receive_App vData, string IPAddress)
        {
            int vGangTingID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0);
            short vSN = BitConverter.ToInt16(new byte[] { vData.SN1, vData.SN2 }, 0);
            WatchHouseSendCMDEFModel vSendCMDModel = new WatchHouseSendCMDEFModel()
            {
                State = vData.JieGuo == 0x5a ? true : false,
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
                //State = vData.Data3 == 0x5a ? true : false,
                State = true,
                IsReply = true

            };
            m_BasicDBClass_Return.UpdateRecord(vSendCMDModel, string.Format("GangTingID={0} and SN={1} and IsSend=1", vGangTingID, vSN));
        }

        /// <summary>
        /// 处理岗亭上报数据(双向)
        /// </summary>
        /// <param name="vData">数据</param>
        /// <param name="IPAddress">IP地址</param>
        void processorData_ReceiveSX(WatchHouseDataPack_Receive_MainSX vData, string IPAddress)
        {
            try
            {
                WathHouseDataEFModel vModel = new WathHouseDataEFModel()
                {
                    WatchHouseID = BitConverter.ToInt32(new byte[] { vData.WatchHouseID4, vData.WatchHouseID3, vData.WatchHouseID2, vData.WatchHouseID1 }, 0),
                    MenZhuanTai = vData.MenZhuanTai == 0 ? "开" : "关",
                    DianChiSuo = vData.DianChiSuo == 0 ? "开" : "关",
                    JiXieSuo = vData.JiXieSuo == 0 ? "开" : "关",
                    BaoJingQi = vData.BaoJingQi == 0 ? "关" : "开",
                    //前窗、前风幕、前窗灯
                    Chuang = vData.QianChuang == 0 ? "开" : "关",
                    FengMu = vData.QianFengMu == 0 ? "关" : "开",
                    ChuangDeng = vData.QianChuangDeng == 0 ? "关" : "开",
                    //后窗、后风幕、后窗灯
                    Chuang2 = vData.HouChuang == 0 ? "开" : "关",
                    FengMu2 = vData.HouFengMu == 0 ? "关" : "开",
                    ChuangDeng2 = vData.HouChuangDeng == 0 ? "关" : "开",

                    XinFeng = vData.XinFeng == 0 ? "关" : "开",
                    Deng = vData.Deng == 0 ? "关" : "开",
                    DiNuan = vData.DiNuan == 0 ? "关" : "开",
                    ZuoNuanJQ = vData.ZuoNuanJQ == 0 ? "关" : "开",
                    YouNuanJQ = vData.YouNuanJQ == 0 ? "关" : "开",
                    ShiLeiWD = BitConverter.ToInt16(new byte[] { vData.ShiLeiWD2, vData.ShiLeiWD1 }, 0),
                    ShiLeiSD = vData.ShiLeiSD,
                    KongTiao = vData.KongTiao == 0 ? "关" : "开",
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
                    //前窗控传感器、前工控机输出、前工控机输入
                    ChuangKongCKQ = convertChuangKongCKQ(vData.QianChuangKongCKQ),
                    GongKongJSC = convertGongKongJSC(vData.QianGongKongJSC),
                    GongKongJSR = convertGongKongJSR(vData.QianGongKongJSR),
                    //后窗控传感器、后工控机输出、后工控机输入
                    ChuangKongCKQ2 = convertChuangKongCKQ(vData.HouChuangKongCKQ),
                    GongKongJSC2 = convertGongKongJSC(vData.HouGongKongJSC),
                    GongKongJSR2 = convertGongKongJSR(vData.HouGongKongJSR),

                    DengGuanLD = vData.DengGuanLD,
                    XieRuSJ = DateTime.Now
                };
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    GangTingTXSJ = DateTime.Now,
                    GangTingIP = IPAddress
                };
                m_BasicDBClass_Receive.TransactionBegin();
                int vMaxID = m_BasicDBClass_Receive.InsertRecord(vModel);
                if (vMaxID != 0)
                {
                    m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("GangTingID={0}", vModel.WatchHouseID));
                    m_BasicDBClass_Receive.TransactionCommit();
                    if (m_ClientMaxID.ContainsKey(vModel.WatchHouseID.Value))
                        m_ClientMaxID[vModel.WatchHouseID.Value] = vMaxID;

                }
                else
                    m_BasicDBClass_Receive.TransactionRollback();

                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.WatchHouseID.Value))
                    m_ClientDict[vModel.WatchHouseID.Value] = IPAddress;
            }
            catch (Exception ex)
            {
                string vOutInfo = string.Format("插入数据至[岗亭数据表]中发生异常，异常信息为:{0}", ex.Message);
                Console.WriteLine(vOutInfo);
                LogHelper.WriteLog_Error(typeof(WatchHouseControl), vOutInfo);
            }
        }

        /// <summary>
        /// 处理岗亭上报数据(单向)
        /// </summary>
        /// <param name="vData">数据</param>
        /// <param name="IPAddress">岗亭IP地址</param>
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
                    BaoJingQi = vData.BaoJingQi == 0 ? "关" : "开",
                    Chuang = vData.Chuang == 0 ? "开" : "关",
                    FengMu = vData.FengMu == 0 ? "关" : "开",
                    ChuangDeng = vData.ChuangDeng == 0 ? "关" : "开",
                    XinFeng = vData.XinFeng == 0 ? "关" : "开",
                    Deng = vData.Deng == 0 ? "关" : "开",
                    DiNuan = vData.DiNuan == 0 ? "关" : "开",
                    ZuoNuanJQ = vData.ZuoNuanJQ == 0 ? "关" : "开",
                    YouNuanJQ = vData.YouNuanJQ == 0 ? "关" : "开",
                    ShiLeiWD = BitConverter.ToInt16(new byte[] { vData.ShiLeiWD2, vData.ShiLeiWD1 }, 0),
                    ShiLeiSD = vData.ShiLeiSD,
                    KongTiao = vData.KongTiao == 0 ? "关" : "开",
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
                int vMaxID = m_BasicDBClass_Receive.InsertRecord(vModel);
                if (vMaxID != 0)
                {
                    m_BasicDBClass_Receive.UpdateRecord(vWatchHouseConfigEFModel, string.Format("GangTingID={0}", vModel.WatchHouseID));
                    m_BasicDBClass_Receive.TransactionCommit();
                    if (m_ClientMaxID.ContainsKey(vModel.WatchHouseID.Value))
                        m_ClientMaxID[vModel.WatchHouseID.Value] = vMaxID;

                }
                else
                    m_BasicDBClass_Receive.TransactionRollback();

                //更新客户端字典表
                if (m_ClientDict.ContainsKey(vModel.WatchHouseID.Value) )
                    m_ClientDict[vModel.WatchHouseID.Value] = IPAddress;
            }
            catch(Exception ex)
            {
                string vOutInfo = string.Format("插入数据至[岗亭数据表]中发生异常，异常信息为:{0}", ex.Message);
                Console.WriteLine(vOutInfo);
                LogHelper.WriteLog_Error(typeof(WatchHouseControl), vOutInfo);
            }
        }
    #endregion
    }
}
