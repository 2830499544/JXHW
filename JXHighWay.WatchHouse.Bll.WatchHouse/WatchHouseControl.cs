using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.Net;
using System.Net;
using JXHighWay.WatchHouse.Helper;
using System.Collections;
using JXHighWay.WatchHouse.EFModel;
using MXKJ.DBMiddleWareLib;
using System.Threading;

namespace JXHighWay.WatchHouse.Bll.WatchHouse
{
    public class WatchHouseControl
    {
        SocketManager m_SocketManager;
        BasicDBClass m_BasicDBClass;
        /// <summary>
        /// 接收岗亭状态数据队列
        /// </summary>
        public Queue<WHQueueModel> ReceiveQueue { get; set; }
        /// <summary>
        /// 接收已发送命令的返回状态队列
        /// </summary>
        List<SendCMDModel> m_ReturSendCMDList { get; set; }
        //List<AsyncUserToken> ClientList { get; set; }
        /// <summary>
        /// 收费站字典表
        /// </summary>
        Dictionary<int, string> m_ClientDict { get; set; }
        readonly int Port;
        /// <summary>
        /// 缓冲区大小
        /// </summary>
        const int BufferSize= 1024;
        /// <summary>
        /// 最大连接数
        /// </summary>
        const int MaxConnNum = 100;

        bool m_IsRun = false;

        public WatchHouseControl( )
        {
            Config vConfig = new Config();
            Port = vConfig.WatchHousePort;
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        public void Start()
        {
            ReceiveQueue = new Queue<WHQueueModel>();

            m_SocketManager = new SocketManager(MaxConnNum, BufferSize);
            m_SocketManager.ClientNumberChange += M_SocketManager_ClientNumberChange;
            m_SocketManager.ReceiveClientData += M_SocketManager_ReceiveClientData;
            m_SocketManager.Init();
            m_SocketManager.Start(new IPEndPoint(IPAddress.Any, 1024));
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
            WatchHouseConfigEFModel[] vWatchHouseConfig= m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach(WatchHouseConfigEFModel vTempConfig in vWatchHouseConfig)
            {
                m_ClientDict.Add(vTempConfig.ShouFeiZhangID.Value, "");
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
            }
            //throw new NotImplementedException();
        }

        private void M_SocketManager_ClientNumberChange(int num, AsyncUserToken token)
        {

            //throw new NotImplementedException();
        }

        #region 发送指令

        async void asyncProcessorDBSendCMD()
        {
            await Task.Run(() =>
            {
                while (m_IsRun)
                {
                    SendCMDEFModel vModel = new SendCMDEFModel()
                    {
                        State = 0
                    };
                    var vSelectResult = m_BasicDBClass.SelectRecordsEx(vModel);
                    foreach (SendCMDEFModel vTempResult in vSelectResult)
                    {
                        AsyncUserToken vAsyncUserToken = findAsyncUserToken(vTempResult.GangTingID.Value);
                        if (vAsyncUserToken != null)
                        {
                            WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
                            {
                                Head = 0x20,
                                Length = 0x23,//长度固定为35
                                Ver = 0x0000,
                                LoginSN = 0x0001,
                                SN = markSN(),
                                WatchHouseID = vTempResult.GangTingID.Value,
                                UserID = vTempResult.GangTingID.Value,
                                ID_H = vTempResult.ID_H.Value,
                                ID_L = vTempResult.ID_L.Value,
                                CMD = vTempResult.CMD.Value,
                                SUB = vTempResult.SUB.Value
                            };
                            byte[] vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                            short vCheckCode = calcCheckCode(vByteArray);
                            vCommandDataPack.Check = vCheckCode;
                            vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                            m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
                            Thread.Sleep(1000);//睡眼1秒等待岗亭返回数据
                            var vFindResult = m_ReturSendCMDList.Where(x => x.GangTingID == vCommandDataPack.WatchHouseID && x.ID_H == vCommandDataPack.ID_H &&
                            x.ID_H == vCommandDataPack.ID_L && x.SN == vCommandDataPack.SN).FirstOrDefault();
                            if (vFindResult != null)
                            {
                                vModel = new SendCMDEFModel()
                                {
                                    ID = vTempResult.ID,
                                    State = vFindResult.State==true?(short)1:(short)0
                                };
                                m_BasicDBClass.UpdateRecord(vModel);
                            }
                        }
                    }
                }
            });
        }


        public async Task<bool> AsyncSendCommand(int WatchHouseID,WatchHouseDataPack_Send_CommandEnmu Command )
        {
            bool vResult = false;
            await Task.Run(() =>
            {
                AsyncUserToken vAsyncUserToken = findAsyncUserToken(WatchHouseID);
                if (vAsyncUserToken != null)
                {
                    WatchHouseDataPack_SendData_Main vCommandDataPack = new WatchHouseDataPack_SendData_Main()
                    {
                        Head = 0x20,
                        Length = 0x23,//长度固定为35
                        Ver = 0x0000,
                        LoginSN = 0x0001,
                        SN = 0x0002,
                        WatchHouseID = WatchHouseID,
                        UserID = WatchHouseID,
                        ID_H = (byte)((int)Command >> 24),
                        ID_L = (byte)((int)Command >> 16),
                        CMD = (byte)((int)Command >> 8),
                        SUB = (byte)((int)Command >> 0)
                    };
                    byte[] vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                    short vCheckCode = calcCheckCode(vByteArray);
                    vCommandDataPack.Check = vCheckCode;
                    vByteArray = Helper.NetHelper.StructureToByte(vCommandDataPack);
                    m_SocketManager.SendMessage(vAsyncUserToken, vByteArray);
                    Thread.Sleep(1000);//睡眼1秒等待岗亭返回数据
                    var vFindResult = m_ReturSendCMDList.Where(x => x.GangTingID == vCommandDataPack.WatchHouseID && x.ID_H == vCommandDataPack.ID_H &&
                    x.ID_H == vCommandDataPack.ID_L && x.SN == vCommandDataPack.SN).FirstOrDefault();
                    if (vFindResult != null)
                        vResult = vFindResult.State;
                }
             
            });
            return vResult;
        }

        public async Task<bool> AsyncSendCommandToDB(int WatchHouseID, WatchHouseDataPack_Send_CommandEnmu Command)
        {
            bool vResult = false;
            await Task.Run(() =>
            {
                SendCMDEFModel vSendCMDEFModel = new SendCMDEFModel()
                {
                    GangTingID = WatchHouseID,
                    ID_H = (byte)((int)Command >> 24),
                    ID_L = (byte)((int)Command >> 16),
                    CMD = (byte)((int)Command >> 8),
                    SUB = (byte)((int)Command >> 0),
                    SendTime = DateTime.Now,
                    SN = markSN(),
                    State = 0
                };
                int vID = m_BasicDBClass.InsertRecord(vSendCMDEFModel);
                Thread.Sleep(1000);
                SendCMDEFModel vSelectResult = m_BasicDBClass.SelectRecordByPrimaryKeyEx<SendCMDEFModel>(vID);
                vResult = vSelectResult.State == 1 ? true : false;
                vSendCMDEFModel = new SendCMDEFModel()
                {
                    ID = vID,
                    State = 3
                };
                m_BasicDBClass.UpdateRecord(vSendCMDEFModel);
            });
            return vResult;
        }

        short markSN()
        {
            byte[] vResult = new byte[2];
            Random vRD = new Random();
            vRD.NextBytes(vResult);
            return Convert.ToInt16( vResult);
        }

         short calcCheckCode(byte[] dataPack)
        {
            short vResult = 0;
            for( int i=0;i<dataPack.Length-2;i++)
            {
                vResult += dataPack[i];
            }
            return vResult;
        }

        AsyncUserToken findAsyncUserToken(int WatchHouseID)
        {
            string vIPAddress = m_ClientDict[WatchHouseID];
            return m_SocketManager.ClientList.Where(m => m.IPAddress.ToString() == vIPAddress).FirstOrDefault();
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
                            if (vReceiveData.Data[21]==0x20 && vReceiveData.Data[22]==0x02 || vReceiveData.Data[22]==0x03 
                            || vReceiveData.Data[22] == 0x04 || vReceiveData.Data[22] == 0x05 || vReceiveData.Data[22] == 0x0c || vReceiveData.Data[22] == 0x10)
                            {
                                WatchHouseDataPack_SendData_Main vDataPack = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_SendData_Main>(vReceiveData.Data);
                                processorData_ReturnCMD(vDataPack, vReceiveData.IPAddress);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            });
        }
        void processorData_IDCard(WatchHouseDataPack_Receive_IDCard vData)
        {
            IDCardEFModel vModel = new IDCardEFModel()
            {
                GangTingID = vData.WatchHouseID,
                ShiJiang = DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                HuanBan = vData.HuanBan == 0x01?"换班":"",
                WeiYIID= vData.UniqID
            };
            m_BasicDBClass.InsertRecord(vModel);
        }


        void processorData_DoorGuard(WatchHouseDataPack_Receive_DoorGuard vData)
        {
            DoorGuardEFModel vModel = new DoorGuardEFModel()
            {
                GangTingID = vData.WatchHouseID,
                //20170503155601
                ShiJiang = DateTime.Parse(string.Format("{0:D}{1:D}{2:D}{3:D}-{4:D}{5:D}-{6:D}{7:D} {8:D}{9:D}:{10:D}{11:D}:{12:D}{13:D}",
                vData.DateTime0, vData.DateTime1, vData.DateTime2, vData.DateTime3, vData.DateTime4, vData.DateTime5, vData.DateTime6,
                vData.DateTime7, vData.DateTime8, vData.DateTime9, vData.DateTime10, vData.DateTime11, vData.DateTime12, vData.DateTime13)),
                KaiHao = vData.KaHao0,
                DongZuo = vData.MenZhuangTai==0?"关闭":"开门"
            };
            m_BasicDBClass.InsertRecord(vModel);
        }

        void processorData_ReturnCMD(WatchHouseDataPack_SendData_Main vData,string IPAddress)
        {
            m_ReturSendCMDList.Add(new SendCMDModel()
            {
                GangTingID = vData.WatchHouseID,
                ID_H = vData.ID_H,
                ID_L = vData.ID_L,
                CMD = vData.CMD,
                SUB = vData.SUB,
                SN = vData.SN,
                State = vData.Data == 0x5a ? true : false
            });
        }

        void processorData_Receive(WatchHouseDataPack_Receive_Main vData,string IPAddress)
        {
            WathHouseDataEFModel vModel = new WathHouseDataEFModel()
            {
                WatchHouseID = vData.WatchHouseID,
                MenZhuanTai = vData.MenZhuanTai == 0 ? "开" : "关",
                DianChiSuo = vData.DianChiSuo == 0 ? "开" : "关",
                JiXieSuo = vData.JiXieSuo == 0 ? "开" : "关",
                BaoJingQi = vData.BaoJingQi == 0 ? "关闭" : "开启",
                Chuang = vData.Chuang == 0 ? "开" : "关",
                FengMu = vData.FengMu == 0 ? "闭" : "开",
                ChuangDeng = vData.ChuangDeng == 0 ? "闭" : "开",
                XinFeng = vData.XinFeng == 0 ? "闭" : "开",
                Deng = vData.Deng == 0 ? "闭" : "开",
                DiNuan = vData.DiNuan == 0 ? "闭" : "开",
                ZuoNuanJQ = vData.ZuoNuanJQ == 0 ? "闭" : "开",
                YouNuanJQ = vData.YouNuanJQ == 0 ? "闭" : "开",
                ShiLeiWD = vData.ShiLeiWD,
                ShiLeiSD = vData.ShiLeiSD,
                KongTiao = vData.KongTiao == 0 ? "闭" : "开",
                KongTiaoGZMS = convertKongTiaoGZMS(vData.KongTiaoGZMS),
                KongTiaoGZFL = convertKongTiaoGZFL(vData.KongTiaoGZFL),
                KongQiZL = convertKongQiZL(vData.KongQiZL),
                XinFengXTKQZL = vData.XinFengXTKQZL,
                CaiLuanKZWD = vData.CaiLuanKZWD,
                CaiLuanKZWBWD = vData.CaiLuanKZWBWD,
                CaiLuanKZDBWD = vData.CaiLuanKZDBWD,
                DianLiuJK = convertDianLiuJK(vData.DianLiuJK),
                MenKongCKQ = convertMenKongCKQ(vData.MenKongCKQ),
                ChuangKongCKQ = convertChuangKongCKQ(vData.ChuangKongCKQ),
                GongKongJSC = convertGongKongJSC(vData.GongKongJSC),
                GongKongJSR = convertGongKongJSR(vData.GongKongJSR),
                DengGuanLD = vData.DengGuanLD
            };
            m_BasicDBClass.InsertRecord(vModel);
            m_ClientDict[vModel.WatchHouseID.Value] = IPAddress;
        }
    #endregion
    }
}
