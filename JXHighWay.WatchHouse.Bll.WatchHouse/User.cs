using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class User
    {
        BasicDBClass m_BasicDBClass = null;
        public User()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        public bool Login(string UserName,string Password,ref bool GangTing,ref bool DianYuan,ref bool LED)
        {
            bool vResult = false;
            AdminEFModel vAdminEFModel = new AdminEFModel()
            {
                 ZhangHao = UserName
            };
            AdminEFModel[] AdminEFModel = m_BasicDBClass.SelectRecordsEx(vAdminEFModel);
            if (AdminEFModel!=null && AdminEFModel.Length>0)
            {
                if (AdminEFModel[0].MiMa == Password)
                {
                    vResult = true;
                    GangTing = AdminEFModel[0].GangTingGZ ?? false;
                    DianYuan = AdminEFModel[0].DianYuanGZ ?? false;
                    LED = AdminEFModel[0].LEDGongZhi ?? false;
                }
            }
            return vResult;
        }

    }
}
