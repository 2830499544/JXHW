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
                    Data = Data
                };
                int vID = m_BasicDBClass.InsertRecord(vSendCMDEFModel);
                //Thread.Sleep(1000);
                DateTime vStartTime = DateTime.Now;
                do
                {
                    WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClass.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
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
                    WatchHouseSendCMDEFModel vSelectResult = m_BasicDBClass.SelectRecordByPrimaryKeyEx<WatchHouseSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 1000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
            });
            return vResult;
        }

        public List<WatchHouseInfo> GetAllWatchHouseInfo()
        {
            WatchHouseConfigEFModel[] vWatchHouseInfoArray =  m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            List<WatchHouseInfo> vResut = new List<WatchHouseInfo>();
            foreach (WatchHouseConfigEFModel vTempWatchHouse in vWatchHouseInfoArray)
            {
                vResut.Add(new WatchHouseInfo()
                {
                    DianYuanDK = vTempWatchHouse.DianYuanDK,
                    DianYuanIP = vTempWatchHouse.DianYuanIP,
                    DianYuanLS = vTempWatchHouse.DianYuanLS,
                    GangTingDK = vTempWatchHouse.GangTingDK,
                    GangTingID = vTempWatchHouse.GangTingID,
                    GangTingIP = vTempWatchHouse.GangTingIP,
                    GangTingMC = vTempWatchHouse.GangTingMC,
                    GongHao = vTempWatchHouse.GongHao,
                    GuanGaoPDK = vTempWatchHouse.GuanGaoPDK,
                    GuanGaoPingIP = vTempWatchHouse.GuanGaoPingIP,
                    LeiXin = vTempWatchHouse.LeiXin,
                    ID = vTempWatchHouse.ID,
                    ShouFeiZhangID = vTempWatchHouse.ShouFeiZhangID,
                    TongXunSJ = vTempWatchHouse.GangTingTXSJ,
                    IsOnline = isOnline(vTempWatchHouse.GangTingTXSJ )
                });
            }
            return vResut;
        }

        bool isOnline(DateTime? tongXunSJ)
        {
            bool vResult = false;
            if (tongXunSJ!=null)
            {
                if ((DateTime.Now - tongXunSJ.Value).TotalSeconds < m_OfflineTime)
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
                vResult.DiNuan = vNewData.DiNuan == "闭" ? false : true;
                vResult.SheZhiWD = vNewData.CaiLuanKZWD ?? 0;
                vResult.YouNuanJQ = vNewData.YouNuanJQ == "闭" ? false : true;
                vResult.ZuoNuanJQ = vNewData.ZuoNuanJQ == "闭" ? false : true;
            }
            return vResult;
        }

        /// <summary>
        /// 门窗状态
        /// </summary>
        /// <param name="WatchHouseID">岗亭编号</param>
        /// <returns></returns>
        public MenChuangStateInfo MenChuangState(int WatchHouseID)
        {
            WathHouseDataEFModel vNewData = getNewData(WatchHouseID);
            MenChuangStateInfo vResult = new MenChuangStateInfo();
            if (vNewData.WatchHouseID != null)
            {
                vResult.BaoJinQi = vNewData.BaoJingQi=="闭"?false:true;
                vResult.Chuang = vNewData.Chuang == "闭" ? false : true;
                vResult.FengMu = vNewData.FengMu == "闭" ? false : true;
                vResult.FengMuDeng = vNewData.ChuangDeng == "闭" ? false : true;
                vResult.Men= vNewData.MenZhuanTai == "闭" ? false : true;
                vResult.ZiDonGChuang = false;//协议中暂不支持此数据
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
                vResult.IsOpen = vNewData.Deng == "闭" ? false : true;
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
                vResult.IsOpen = vNewData.KongTiao == "闭" ? false : true;
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
                vResutl.IsOpen = vNewData.XinFeng == "闭" ? false : true;
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
