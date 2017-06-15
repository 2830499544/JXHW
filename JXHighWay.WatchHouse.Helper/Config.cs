using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace JXHighWay.WatchHouse.Helper
{
    public class Config
    {
        #region 私有变量

        Configuration m_Configuration = null;
        /// <summary>
        /// 远程服务器地址
        /// </summary>
        public int WatchHousePort { get; set; }

        public string DBSource { get; set; }
        public string DBName { get; set; }
        public int DBPort { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }

        #endregion


        #region 构造
        public Config()
        {
            m_Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            WatchHousePort = int.Parse( m_Configuration.AppSettings.Settings["WatchHousePort"].Value );
            DBSource = m_Configuration.AppSettings.Settings["DBSource"].Value;
            DBName = m_Configuration.AppSettings.Settings["DBName"].Value;
            DBPort = int.Parse( m_Configuration.AppSettings.Settings["DBPort"].Value );
            DBUserName = m_Configuration.AppSettings.Settings["DBUserName"].Value;
            DBPassword = m_Configuration.AppSettings.Settings["DBPassword"].Value;

        }
        #endregion

        #region 公有方法
        public void Save()
        {
            //远程服务器
            m_Configuration.AppSettings.Settings["WatchHousePort"].Value = WatchHousePort.ToString();

            m_Configuration.AppSettings.Settings["DBSource"].Value = DBSource;
            m_Configuration.AppSettings.Settings["DBName"].Value = DBName;
            m_Configuration.AppSettings.Settings["DBPort"].Value = DBPort.ToString();
            m_Configuration.AppSettings.Settings["DBUserName"].Value = DBUserName;
            m_Configuration.AppSettings.Settings["DBPassword"].Value = DBPassword;
        }
        #endregion
    }
}
