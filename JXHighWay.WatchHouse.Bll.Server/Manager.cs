using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;
using MXKJ.DBMiddleWareLib;
using System.Data;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class Manager
    {
        BasicDBClass m_BasicDBClass = null;

        public Manager()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        bool findZhangHao( string zhangHao)
        {
            ManagerEFModel vManagerEFModel = new ManagerEFModel()
            {
                ZhangHao = zhangHao
            };
            return m_BasicDBClass.SelectRecordsEx(vManagerEFModel).Length > 0 ? true : false;
        }

        public bool Add(string ZhangHao,string MiMa,
            bool GangTingGZ,bool LEDGongZhi,bool DianYuanGZ,ref string OutInfo)
        {
            bool vResult = false;
            if (!findZhangHao(ZhangHao))
            {
                ManagerEFModel vManagerEFModel = new ManagerEFModel()
                {
                    ZhangHao = ZhangHao,
                    MiMa = MiMa,
                    DianYuanGZ = DianYuanGZ,
                    GangTingGZ = GangTingGZ,
                    LEDGongZhi = LEDGongZhi
                };
                vResult = m_BasicDBClass.InsertRecord(vManagerEFModel) > 0 ? true : false;
            }
            else
            {
                OutInfo = "管理员帐号重复";
            }
            return vResult;
        }

        public bool Del(int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey<ManagerEFModel>(ID);
        }

        public DataTable GetAll()
        {
            return m_BasicDBClass.SelectAllRecords<ManagerEFModel>();
        }
        

        public bool Update(int ID,string ZhangHao, string MiMa,
            bool GangTingGZ, bool LEDGongZhi, bool DianYuanGZ,ref string OutInfo )
        {
            bool vResult = false;
            string vSql = string.Format( "Select *From `管理员` Where ID<>{0} and ZhangHao='{1}'",ID,ZhangHao );
            ManagerEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<ManagerEFModel>(vSql);
            if (vSelectResult==null || vSelectResult.Length==0)
            {
                ManagerEFModel vManagerEFModel = new ManagerEFModel()
                {
                    ZhangHao = ZhangHao,
                    MiMa = MiMa,
                    DianYuanGZ = DianYuanGZ,
                    GangTingGZ = GangTingGZ,
                    LEDGongZhi = LEDGongZhi,
                    ID = ID
                };
                vResult = m_BasicDBClass.UpdateRecord(vManagerEFModel);
            }
            else
            {
                OutInfo = "管理员帐号重复";
            }
            return vResult;
        }


    }
}
