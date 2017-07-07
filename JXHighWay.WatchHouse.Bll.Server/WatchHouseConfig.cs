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
            string LedIP, int DianYuanID, DataTable SwitchInfoTable, ref string OutInfo)
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
            m_BasicDBClass.TransactionBegin();
            if (m_BasicDBClass.UpdateRecord(vWatchHouseConfigEFModel))
            {
                foreach (DataRow vTempSwitch in SwitchInfoTable.Rows)
                {
                    PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel()
                    {
                        ID = DBConvert.ToInt32(vTempSwitch["ID"]),
                        LeiXing = DBConvert.ToString(vTempSwitch["类型"]),
                        LuHao = DBConvert.ToString(vTempSwitch["路号"]),
                        MinCheng = DBConvert.ToString(vTempSwitch["名称"])
                    };

                    if (!m_BasicDBClass.UpdateRecord(vModel) )
                    {
                        vResult = false;
                        m_BasicDBClass.TransactionRollback();
                        break;
                    }
                    else
                        vResult = true;
                }
                if (vResult)
                    m_BasicDBClass.TransactionCommit();
            }
            else
            {
                OutInfo = "修改岗亭数据失败";
            }
            return vResult;
        }

        public bool Add(int GanTingID,string GanTingMC,string GanTingLX,
            string LedIP,int DianYuanID, DataTable SwitchInfoTable,
            ref string OutInfo )
        {
            bool vResult = false;
            if ( !findGanTing(GanTingID,DianYuanID) )
            {
                m_BasicDBClass.TransactionBegin();
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    GangTingID = GanTingID,
                    GangTingMC = GanTingMC,
                    GangTingLX = GanTingLX,
                    GuanGaoPingIP = LedIP,
                    DianYuanID = DianYuanID,
                    ShouFeiZhangID = 1
                };
                if ( m_BasicDBClass.InsertRecord(vWatchHouseConfigEFModel) > 0)
                {
                    foreach(DataRow vTempSwitch in SwitchInfoTable.Rows)
                    {
                        PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel()
                        {
                            DianYuanID = DianYuanID,
                            LeiXing = DBConvert.ToString( vTempSwitch["类型"] ),
                            LuHao = DBConvert.ToString(vTempSwitch["路号"]),
                            MinCheng = DBConvert.ToString(vTempSwitch["名称"])
                        };
                        if (m_BasicDBClass.InsertRecord(vModel) <= 0)
                        {
                            vResult = false;
                            m_BasicDBClass.TransactionRollback();
                            break;
                        }
                        else
                            vResult = true;
                    }
                    if (vResult)
                        m_BasicDBClass.TransactionCommit();
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
