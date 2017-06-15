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

namespace JXHighWay.WatchHouse.Bll.WatchHouse
{
    public class WHCollectionData
    {
        SocketManager m_SocketManager;
        BasicDBClass m_BasicDBClass;
        public Queue<WHQueueModel> ReceiveQueue { get; set; }
        List<AsyncUserToken> ClientList { get; set; }
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

        public WHCollectionData( )
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
            //处理接收到的数据
            asyncProcessorDataData();

        }

        void initWathchHouse()
        {
            m_BasicDBClass.SelectAllRecords<>
        }

        /// <summary>
        /// 异步处理数据
        /// </summary>
        async void asyncProcessorDataData()
        {
            await processorData();
        }


        public void Stop()
        {
            m_SocketManager.Stop();
            ReceiveQueue.Clear();
            m_IsRun = false;
        }

        private void M_SocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        {
            if ( buff.Length>0 && buff[0]==0x20)
            {
                ReceiveQueue.Enqueue(new WHQueueModel(buff, token.IPAddress.ToString()));
            }
            //throw new NotImplementedException();
        }

        private void M_SocketManager_ClientNumberChange(int num, AsyncUserToken token)
        {
            
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 转换空调工作模式(1:空调工作模式 2:自动模式 3：制冷模式 4:除湿模式 5:制热模式 6:送风模式)
        /// </summary>
        /// <param name="GZMS"></param>
        /// <returns></returns>
        string convertKongTiaoGZMS(byte GZMS)
        {
            string vResult = "";
            switch ( GZMS )
            {
                case 1:
                    vResult = "空调工作模式";
                    break;
                case 2:
                    vResult = "自动模式";
                    break;
                case 3:
                    vResult = "制冷模式";
                    break;
                case 4:
                    vResult = "除湿模式";
                    break;
                case 5:
                    vResult = "制热模式";
                    break;
                case 6:
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
                            WatchHouseDataPack_Receive_Main vDataPack_Main = Helper.NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Main>(vData.Data);
                            WathHouseDataEFModel vModel = new WathHouseDataEFModel()
                            {
                                WatchHouseID = vDataPack_Main.WatchHouseID,
                                MenZhuanTai = vDataPack_Main.MenZhuanTai == 0 ? "开" : "关",
                                DianChiSuo = vDataPack_Main.DianChiSuo == 0 ? "开" : "关",
                                JiXieSuo = vDataPack_Main.JiXieSuo == 0 ? "开" : "关",
                                BaoJingQi = vDataPack_Main.BaoJingQi == 0 ? "关闭" : "开启",
                                Chuang = vDataPack_Main.Chuang == 0 ? "开" : "关",
                                FengMu = vDataPack_Main.FengMu == 0 ? "闭" : "开",
                                ChuangDeng = vDataPack_Main.ChuangDeng == 0 ? "闭" : "开",
                                XinFeng = vDataPack_Main.XinFeng == 0 ? "闭" : "开",
                                Deng = vDataPack_Main.Deng == 0 ? "闭" : "开",
                                DiNuan = vDataPack_Main.DiNuan == 0 ? "闭" : "开",
                                ZuoNuanJQ = vDataPack_Main.ZuoNuanJQ == 0 ? "闭" : "开",
                                YouNuanJQ = vDataPack_Main.YouNuanJQ == 0 ? "闭" : "开",
                                ShiLeiWD = vDataPack_Main.ShiLeiWD,
                                ShiLeiSD = vDataPack_Main.ShiLeiSD,
                                KongTiao = vDataPack_Main.KongTiao == 0 ? "闭" : "开",
                                KongTiaoGZMS = convertKongTiaoGZMS(vDataPack_Main.KongTiaoGZMS),
                                KongTiaoGZFL = convertKongTiaoGZFL(vDataPack_Main.KongTiaoGZFL),
                                KongQiZL = convertKongQiZL(vDataPack_Main.KongQiZL),
                                XinFengXTKQZL = vDataPack_Main.XinFengXTKQZL,
                                CaiLuanKZWD = vDataPack_Main.CaiLuanKZWD,
                                CaiLuanKZWBWD = vDataPack_Main.CaiLuanKZWBWD,
                                CaiLuanKZDBWD = vDataPack_Main.CaiLuanKZDBWD,
                                DianLiuJK = convertDianLiuJK(vDataPack_Main.DianLiuJK),
                                MenKongCKQ = convertMenKongCKQ(vDataPack_Main.MenKongCKQ),
                                ChuangKongCKQ = convertChuangKongCKQ(vDataPack_Main.ChuangKongCKQ),
                                GongKongJSC = convertGongKongJSC(vDataPack_Main.GongKongJSC),
                                GongKongJSR = convertGongKongJSR(vDataPack_Main.GongKongJSR),
                                DengGuanLD = vDataPack_Main.DengGuanLD
                            };
                            m_BasicDBClass.InsertRecord(vModel);
                        }
                    }
                    catch
                    {

                    }
                }
            });
        }
    }
}
