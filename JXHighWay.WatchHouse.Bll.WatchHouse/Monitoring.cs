using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Helper;

namespace JXHighWay.WatchHouse.Bll.WatchHouse
{
    public class Monitoring
    {
        BasicDBClass m_BasicDBClass = null;
        public Monitoring()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass( DataBaseType.MySql);
        }

        public List<WatchHouseInfoModel> GetAllWatchHouseInfo()
        {
            WatchHouseConfigEFModel[] vWatchHouseInfoArray =  m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            List<WatchHouseInfoModel> vResut = new List<WatchHouseInfoModel>();
            foreach (WatchHouseConfigEFModel vTempWatchHouse in vWatchHouseInfoArray)
            {
                vResut.Add(new WatchHouseInfoModel()
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
                    TongXunSJ = vTempWatchHouse.TongXunSJ
                });
            }
            return vResut;
        }

        public DengGuanStateModel DuangGuanState( int WatchHouseID)
        {
            DengGuanStateModel vResult = new DengGuanStateModel();
            string vSql = string.Format( "Select *  From `岗亭数据` where WatchHouseID={0} order by id desc limit 1",WatchHouseID);
            WathHouseDataEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<WathHouseDataEFModel>(vSql);
            if (vSelectResult!=null && vSelectResult.Length>0)
            {
                vResult.IsOpen = vSelectResult[0].Deng == "闭" ? false : true;
                vResult.LianDu = vSelectResult[0].DengGuanLD.Value;
            }
            return vResult;
        }

    }
}
