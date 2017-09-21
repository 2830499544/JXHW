using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Net;
using JXHighWay.WatchHouse.Helper;
using System.Threading;
using System.Net.NetworkInformation;

namespace JXHighWay.WatchHouse.Bll.Client.GanTing
{
    public class WatchHouseMonitoring:BasicMonitoring
    {

        public WatchHouseMonitoring()
        {
            
        }

        public async Task<bool> AsyncSendCommandToDB(int WatchHouseID, WatchHouseDataPack_Send_CommandEnmu Command,byte Data)
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
                    IsSend = false,
                    IsReply = false,
                    Data = new byte[] { Data }
                };
                int vID = m_BasicDBClass.InsertRecord(vSendCMDEFModel);
                //Thread.Sleep(1000);
                DateTime vStartTime = DateTime.Now;
                do
                {
                    WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClassSelect.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 1000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
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
                    SN = BitConverter.ToInt16(NetHelper.MarkSN(), 0),
                    State = false,
                    IsSend = false,
                    IsReply = false
                };
                int vID = m_BasicDBClass.InsertRecord(vSendCMDEFModel);
                //Thread.Sleep(1000);
                DateTime vStartTime = DateTime.Now;
                do
                {
                    
                    WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClassSelect.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 1000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
            });
            return vResult;
        }


        /// <summary>
        /// 获取当前工作的工号信息
        /// </summary>
        /// <param name="GangTingID"></param>
        /// <returns></returns>
        public GongHaoPaiInfo GetGongHaoPaiInfo(int GangTingID)
        {
            GongHaoPaiInfo vResult = new GongHaoPaiInfo();
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = GangTingID
            };
            WatchHouseConfigEFModel vSelectResult = m_BasicDBClassSelect.SelectRecordsEx(vWatchHouseConfigEFModel).FirstOrDefault();
            if (vSelectResult.GongHao != null)
            {
                EmployeeEFModel vEmployeeEFModel = new EmployeeEFModel()
                {
                    GongHao = vSelectResult.GongHao
                };
                EmployeeEFModel vSelectResult1 = m_BasicDBClassSelect.SelectRecordsEx(vEmployeeEFModel).FirstOrDefault();
                if (vSelectResult1.XingMing != null)
                {
                    vResult = new GongHaoPaiInfo()
                    {
                        XinMing = vSelectResult1.XingMing,
                        GeYan = vSelectResult1.GeYan,
                        XingJi = vSelectResult1.XingJi,
                        GonHao = vSelectResult1.GongHao.Value

                    };
                }
            }
            return vResult;
        }

        public void GetWatchHouseState( int GangTingID,ref bool GangTingState,
            ref bool DianYuanState,ref bool LedState )
        {
            WatchHouseInfo vResult = new WatchHouseInfo();
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                 GangTingID = GangTingID
            };

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClassSelect.SelectRecordsEx(vWatchHouseConfigEFModel);
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                if (vSelectResult[0].GangTingTXSJ != null &&
                    (DateTime.Now - vSelectResult[0].GangTingTXSJ.Value).TotalSeconds < m_OfflineTime)
                    GangTingState = true;
                if (vSelectResult[0].DianYuanTXSJ != null &&
                    (DateTime.Now - vSelectResult[0].DianYuanTXSJ.Value).TotalSeconds < m_OfflineTime)
                    DianYuanState = true;
                if ( (vSelectResult[0].GuanGao1TXSJ != null &&
                    (DateTime.Now - vSelectResult[0].GuanGao1TXSJ.Value).TotalSeconds < m_OfflineTime) ||
                    (vSelectResult[0].GuanGao2TXSJ != null &&
                    (DateTime.Now - vSelectResult[0].GuanGao2TXSJ.Value).TotalSeconds < m_OfflineTime) )
                    LedState = true;
            }
        }

        public List<WatchHouseInfo> GetAllWatchHouseInfo()
        {
            WatchHouseConfigEFModel[] vWatchHouseInfoArray =  m_BasicDBClass.SelectCustomEx<WatchHouseConfigEFModel>("SELECT *From 岗亭配置 order by OrderID ,GangTingMC");
            List<WatchHouseInfo> vResut = new List<WatchHouseInfo>();
            foreach (WatchHouseConfigEFModel vTempWatchHouse in vWatchHouseInfoArray)
            {
                vResut.Add(new WatchHouseInfo()
                {
                    DianYuan1ID = vTempWatchHouse.DianYuan1ID,
                    DianYuan1IP = vTempWatchHouse.DianYuan1IP,
                    DianYuan2ID = vTempWatchHouse.DianYuan2ID,
                    DianYuan2IP = vTempWatchHouse.DianYuan2IP,
                    GangTingDK = vTempWatchHouse.GangTingDK,
                    GangTingID = vTempWatchHouse.GangTingID,
                    GangTingIP = vTempWatchHouse.GangTingIP,
                    GangTingMC = vTempWatchHouse.GangTingMC,
                    GongHao = vTempWatchHouse.GongHao??0,
                    GuanGaoPDK = vTempWatchHouse.GuanGao1DK,
                    GuanGaoPing1IP = vTempWatchHouse.GuanGaoPing1IP,
                    GuanGaoPing2IP = vTempWatchHouse.GuanGaoPing2IP,
                    LeiXin = vTempWatchHouse.GangTingLX,
                    ID = vTempWatchHouse.ID,
                    ShouFeiZhangID = vTempWatchHouse.ShouFeiZhangID,
                    TongXunSJ = vTempWatchHouse.GangTingTXSJ,
                    IsOnline = isOnline(vTempWatchHouse.GangTingTXSJ, vTempWatchHouse.DianYuanTXSJ)
                });
            }
            return vResut;
        }

        /// <summary>
        /// 判断设备是否在线
        /// </summary>
        /// <param name="GangTingTXSJ"></param>
        /// <param name="DianYuanTXSJ"></param>
        /// <returns></returns>
        bool isOnline(DateTime? GangTingTXSJ, DateTime? DianYuanTXSJ)
        {
            bool vResult = false;
            if (GangTingTXSJ != null && DianYuanTXSJ!=null)
            {
                if ((DateTime.Now - GangTingTXSJ.Value).TotalSeconds < m_OfflineTime && (DateTime.Now - DianYuanTXSJ.Value).TotalSeconds < m_OfflineTime)
                    vResult = true;

            }

            return vResult;
        }


        public DiNuanStateInfo DiNuan(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            DiNuanStateInfo vResult = new DiNuanStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.DanQianWD = vNewData.CaiLuanKZWBWD??0;
                vResult.DiNuan = vNewData.DiNuan == "关" ? false : true;
                vResult.SheZhiWD = vNewData.CaiLuanKZWD ?? 0;
                vResult.YouNuanJQ = vNewData.YouNuanJQ == "关" ? false : true;
                vResult.ZuoNuanJQ = vNewData.ZuoNuanJQ == "关" ? false : true;
            }
            return vResult;
        }

        /// <summary>
        /// 门窗状态(单向)
        /// </summary>
        /// <param name="WatchHouseID">岗亭编号</param>
        /// <returns></returns>
        public MenChuangStateInfo MenChuangState(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            MenChuangStateInfo vResult = new MenChuangStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.BaoJinQi = vNewData.BaoJingQi=="关"?false:true;
                vResult.Men = vNewData.MenZhuanTai == "关" ? false : true;
                vResult.Shuo = vNewData.DianChiSuo == "关" ? false : true;

                vResult.Chuang = vNewData.Chuang == "关" ? false : true;
                vResult.FengMu = vNewData.FengMu == "关" ? false : true;
                vResult.FengMuDeng = vNewData.ChuangDeng == "关" ? false : true;
                vResult.ZiDonGChuang = false;//协议中暂不支持此数据
            }
            return vResult;
        }

        public MenChuangStateInfo MenChuangStateSX(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            MenChuangStateInfo vResult = new MenChuangStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.BaoJinQi = vNewData.BaoJingQi == "关" ? false : true;
                vResult.Men = vNewData.MenZhuanTai == "关" ? false : true;
                vResult.Shuo = vNewData.DianChiSuo == "关" ? false : true;

                vResult.Chuang = vNewData.Chuang == "关" ? false : true;
                vResult.FengMu = vNewData.FengMu == "关" ? false : true;
                vResult.FengMuDeng = vNewData.ChuangDeng == "关" ? false : true;
                vResult.ZiDonGChuang = false;//协议中暂不支持此数据

                vResult.Chuang2 = vNewData.Chuang2 == "开" ? true : false;
                vResult.FengMu2 = vNewData.FengMu2 == "开" ? true : false;
                vResult.FengMuDeng2 = vNewData.ChuangDeng2 == "开" ? true : false;
                vResult.ZiDonGChuang2 = false;//协议中暂不支持此数据
            }
            return vResult;
        }

        /// <summary>
        /// 灯光状态
        /// </summary>
        /// <param name="WatchHouseID"></param>
        /// <returns></returns>
        public DengGuanStateInfo DuangGuanState(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            DengGuanStateInfo vResult = new DengGuanStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.IsOpen = vNewData.Deng == "关" ? false : true;
                vResult.LianDu = vNewData.DengGuanLD.Value;
            }
            return vResult;
        }

        /// <summary>
        /// 空调状态
        /// </summary>
        /// <param name="WatchHouseID"></param>
        /// <returns></returns>
        public KongTiaoStateInfo KongTiaoState(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            KongTiaoStateInfo vResult = new KongTiaoStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.IsOpen = vNewData.KongTiao == "关" ? false : true;
                vResult.FengShu = vNewData.KongTiaoGZFL;
                vResult.MoShi = vNewData.KongTiaoGZMS;
                vResult.ShiLeiWD = vNewData.ShiLeiWD ?? 0;
            }
            return vResult;
        }

        public XinFengStateInfo XinFengState( int WatchHouseID )
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            XinFengStateInfo vResutl = new XinFengStateInfo();
            if ( vNewData.WatchHouseID != null )
            {
                vResutl.IsOpen = vNewData.XinFeng == "关" ? false : true;
                vResutl.ChuKouAPM = vNewData.ChuKouAPM??0;
                vResutl.RuKouAPM = vNewData.RuKouAPM??0;
                vResutl.WenDu = vNewData.XinFengWD ?? 0;
                vResutl.ShiDu = vNewData.ShiLeiSD ?? 0;
            }
            return vResutl;
        }

        WathHouseDataEFModel getNewData(int watchHouseID)
        {
            WathHouseDataEFModel vResult = new WathHouseDataEFModel();
            string vSql = string.Format("Select *  From `岗亭数据` where WatchHouseID={0} order by id desc limit 1", watchHouseID);
            WathHouseDataEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<WathHouseDataEFModel>(vSql);
            if (vSelectResult != null && vSelectResult.Length > 0)
                vResult = vSelectResult[0];
            return vResult;
        }

    }
}
