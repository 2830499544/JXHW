using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using JXHighWay.WatchHouse.Bll.Client.LED;

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

        //LED广告屏配置
        //文字
        public LEDChannelInfo[] LedTextArray { get; set; } = new LEDChannelInfo[0];
        //图片
        public LEDChannelInfo[] LedPicArray { get; set; } = new LEDChannelInfo[0];
        //视频
        public LEDChannelInfo[] LedVideoArray { get; set; } = new LEDChannelInfo[0];

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

            RefreshTime = int.Parse(m_Configuration.AppSettings.Settings["RefreshTime"].Value);
            OfflineTime = int.Parse(m_Configuration.AppSettings.Settings["OfflineTime"].Value);
            TollStationName = m_Configuration.AppSettings.Settings["TollStationName"].Value;

            //LED文字
            List<LEDChannelInfo> vLedTextList = new List<LEDChannelInfo>();
            for (int i = 1; i <= 10; i++)
            {
                string[] vLedTextArray = m_Configuration.AppSettings.Settings[string.Format("LedText{0}", i)].Value.Split('|');
                if ( vLedTextArray.Length==4)
                {
                    vLedTextList.Add(new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Text,
                        Content = vLedTextArray[0],
                        HoldTime = int.Parse(vLedTextArray[1]),
                        InEff = int.Parse(vLedTextArray[2]),
                        OutEff = int.Parse(vLedTextArray[3])
                    });
                }
            }
            LedTextArray = vLedTextList.ToArray();

            //LED图片
            List<LEDChannelInfo> vLedPicList = new List<LEDChannelInfo>();
            for (int i = 1; i <= 4; i++)
            {
                string[] vLedPicArray = m_Configuration.AppSettings.Settings[string.Format("LedPic{0}", i)].Value.Split('|');
                if (vLedPicArray.Length == 4)
                {
                    vLedPicList.Add(new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Image,
                        Content = vLedPicArray[0],
                        HoldTime = int.Parse(vLedPicArray[1]),
                        InEff = int.Parse(vLedPicArray[2]),
                        OutEff = int.Parse(vLedPicArray[3])
                    });
                }
            }
            LedPicArray = vLedPicList.ToArray();


            //LED视频
            List<LEDChannelInfo> vLedVideoList = new List<LEDChannelInfo>();
            for (int i = 1; i <= 4; i++)
            {
                string[] vLedVideoArray = m_Configuration.AppSettings.Settings[string.Format("LedVideo{0}", i)].Value.Split('|');
                if (vLedVideoArray.Length == 4)
                {
                    vLedVideoList.Add(new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Image,
                        Content = vLedVideoArray[0],
                        HoldTime = int.Parse(vLedVideoArray[1]),
                        InEff = int.Parse(vLedVideoArray[2]),
                        OutEff = int.Parse(vLedVideoArray[3])
                    });
                }
            }
            LedVideoArray = vLedVideoList.ToArray();
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

            //LED文字
            int i = 1;
            foreach (LEDChannelInfo vTempLedText in LedTextArray)
            {
                if (i <= 10)
                {
                    m_Configuration.AppSettings.Settings[string.Format("LedText{0}", i)].Value = string.Format("{0}|{1}|{2}|{3}", vTempLedText.Content, vTempLedText.HoldTime, vTempLedText.InEff, vTempLedText.OutEff);
                }
                else
                    break;
                i++;
            }

            //LED图片
            i = 1;
            foreach (LEDChannelInfo vTempLedPic in LedPicArray)
            {
                if (i <= 4)
                {
                    m_Configuration.AppSettings.Settings[string.Format("LedPic{0}", i)].Value = string.Format("{0}|{1}|{2}|{3}", vTempLedPic.Content, vTempLedPic.HoldTime, vTempLedPic.InEff, vTempLedPic.OutEff);
                }
                else
                    break;
                i++;
            }

            //LED视频
            i = 1;
            foreach (LEDChannelInfo vTempLedVideo in LedVideoArray)
            {
                if (i <= 4)
                {
                    m_Configuration.AppSettings.Settings[string.Format("LedVideo{0}", i)].Value = string.Format("{0}|{1}|{2}|{3}", vTempLedVideo.Content, vTempLedVideo.HoldTime, vTempLedVideo.InEff, vTempLedVideo.OutEff);
                }
                else
                    break;
                i++;
            }


            m_Configuration.Save();
        }
        
        #endregion
    }
}
