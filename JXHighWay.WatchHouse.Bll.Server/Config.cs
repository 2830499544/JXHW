using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace JXHighWay.WatchHouse.Bll.Server
{
    public class Config
    {
        #region 私有变量

        Configuration m_Configuration = null;
        /// <summary>
        /// 岗亭监听端口
        /// </summary>
        public int WatchHousePort { get; set; }
        /// <summary>
        /// 电源监听端口
        /// </summary>
        public int PowerPort { get; set; }

        public string DBSource { get; set; }
        public string DBName { get; set; }
        public int DBPort { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }

        public string PicUrl { get; set; }
        public string EmployeeUrl { get; set; }

        public string AppUrl { get; set; }

        #endregion

        #region 构造
        public Config()
        {
            m_Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            WatchHousePort = int.Parse( m_Configuration.AppSettings.Settings["WatchHousePort"].Value );
            PowerPort = int.Parse(m_Configuration.AppSettings.Settings["PowerPort"].Value);
            DBSource = m_Configuration.AppSettings.Settings["DBSource"].Value;
            DBName = m_Configuration.AppSettings.Settings["DBName"].Value;
            DBPort = int.Parse( m_Configuration.AppSettings.Settings["DBPort"].Value );
            DBUserName = m_Configuration.AppSettings.Settings["DBUserName"].Value;
            DBPassword = m_Configuration.AppSettings.Settings["DBPassword"].Value;
            PicUrl = m_Configuration.AppSettings.Settings["PicUrl"].Value;
            EmployeeUrl = m_Configuration.AppSettings.Settings["EmployeeUrl"].Value;
            AppUrl = m_Configuration.AppSettings.Settings["AppUrl"].Value;
        }
        #endregion

        #region 公有方法
        public void Save()
        {
            //监听端口
            m_Configuration.AppSettings.Settings["WatchHousePort"].Value = WatchHousePort.ToString();
            m_Configuration.AppSettings.Settings["PowerPort"].Value = PowerPort.ToString();

            m_Configuration.AppSettings.Settings["DBSource"].Value = DBSource;
            m_Configuration.AppSettings.Settings["DBName"].Value = DBName;
            m_Configuration.AppSettings.Settings["DBPort"].Value = DBPort.ToString();
            m_Configuration.AppSettings.Settings["DBUserName"].Value = DBUserName;
            m_Configuration.AppSettings.Settings["DBPassword"].Value = DBPassword;

            m_Configuration.AppSettings.Settings["PicUrl"].Value = PicUrl;
            m_Configuration.AppSettings.Settings["EmployeeUrl"].Value = EmployeeUrl;
            m_Configuration.AppSettings.Settings["AppUrl"].Value = AppUrl;

            m_Configuration.Save();
        }
        #endregion
    }
}
