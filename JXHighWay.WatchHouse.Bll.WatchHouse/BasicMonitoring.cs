using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class BasicMonitoring
    {
        protected BasicDBClass m_BasicDBClass = null;
        protected BasicDBClass m_BasicDBClassInsert = null;
        protected BasicDBClass m_BasicDBClassUpdate = null;
        protected BasicDBClass m_BasicDBClassDelete = null;
        protected int m_OfflineTime = 10;

        public BasicMonitoring()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_OfflineTime = vConfig.OfflineTime;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
            m_BasicDBClassInsert = new BasicDBClass(DataBaseType.MySql);
            m_BasicDBClassUpdate = new BasicDBClass(DataBaseType.MySql);
            m_BasicDBClassDelete = new BasicDBClass(DataBaseType.MySql);
        }
    }
}
