using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class Config
    {
        #region 私有变量

        Configuration m_Configuration = null;
        /// <summary>
        /// 远程服务器地址
        /// </summary>

        public string DBSource { get; set; }
        public string DBName { get; set; }
        public int DBPort { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }

        public int RefreshTime { get; set; }
        public int OfflineTime { get; set; }

        public string TollStationName { get; set; }

        #endregion

        #region 构造
        public Config()
        {
            m_Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            DBSource = m_Configuration.AppSettings.Settings["DBSource"].Value;
            DBName = m_Configuration.AppSettings.Settings["DBName"].Value;
            DBPort = int.Parse(m_Configuration.AppSettings.Settings["DBPort"].Value);
            DBUserName = m_Configuration.AppSettings.Settings["DBUserName"].Value;
            DBPassword = m_Configuration.AppSettings.Settings["DBPassword"].Value;

            RefreshTime = int.Parse( m_Configuration.AppSettings.Settings["RefreshTime"].Value );
            OfflineTime = int.Parse(m_Configuration.AppSettings.Settings["OfflineTime"].Value);

            TollStationName = m_Configuration.AppSettings.Settings["TollStationName"].Value;

        }
        #endregion

        #region 公有方法
        public void Save()
        {
            //数据库配置
            m_Configuration.AppSettings.Settings["DBSource"].Value = DBSource;
            m_Configuration.AppSettings.Settings["DBName"].Value = DBName;
            m_Configuration.AppSettings.Settings["DBPort"].Value = DBPort.ToString();
            m_Configuration.AppSettings.Settings["DBUserName"].Value = DBUserName;
            m_Configuration.AppSettings.Settings["DBPassword"].Value = DBPassword;

            m_Configuration.AppSettings.Settings["RefreshTime"].Value = RefreshTime.ToString();
            m_Configuration.AppSettings.Settings["OfflineTime"].Value = OfflineTime.ToString();
            m_Configuration.AppSettings.Settings["TollStationName"].Value = TollStationName;
            m_Configuration.Save();
        }
        #endregion
    }
}
