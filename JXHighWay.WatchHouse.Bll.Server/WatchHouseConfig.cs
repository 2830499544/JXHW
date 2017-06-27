using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WatchHouseConfig
    {
        BasicDBClass m_BasicDBClass = null;
        public WatchHouseConfig()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        bool findGanTing(int GangTingID,int DianYuanID)
        {
            string vSql = string.Format("Select *From `岗亭配置` Where GangTingID={0} or DianYuanID={1}", GangTingID, DianYuanID);
            return m_BasicDBClass.SelectCustomEx<WatchHouseConfigEFModel>(vSql).Length > 0 ? true : false;
        }

        public DataTable GetAll()
        {
            return m_BasicDBClass.SelectAllRecords<WatchHouseConfigEFModel>();
        }

        public bool Del(int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey(ID);
        }

        public bool Update(int ID, int GanTingID, string GanTingMC, string GanTingLX,
            string LedIP, int DianYuanID, ref string OutInfo)
        {
            bool vResult = false;
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = GanTingID,
                GangTingMC = GanTingMC,
                GangTingLX = GanTingLX,
                GuanGaoPingIP = LedIP,
                DianYuanID = DianYuanID,
                ID = ID
            };
            if (m_BasicDBClass.UpdateRecord(vWatchHouseConfigEFModel))
            {
                vResult = true;
            }
            else
            {
                OutInfo = "增加岗亭数据失败";
            }
            return vResult;
        }

        public bool Add(int GanTingID,string GanTingMC,string GanTingLX,
            string LedIP,int DianYuanID,ref string OutInfo )
        {
            bool vResult = false;
            if ( !findGanTing(GanTingID,DianYuanID) )
            {
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    GangTingID = GanTingID,
                    GangTingMC = GanTingMC,
                    GangTingLX = GanTingLX,
                    GuanGaoPingIP = LedIP,
                    DianYuanID = DianYuanID
                };
                if ( m_BasicDBClass.InsertRecord(vWatchHouseConfigEFModel) > 0)
                {
                    vResult = true;
                }
                else
                {
                    OutInfo = "增加岗亭数据失败";
                }
            }
            else
            {
                OutInfo = "存在相同编号的岗亭或者电源";
            }
            return vResult;
        }
    }
}
