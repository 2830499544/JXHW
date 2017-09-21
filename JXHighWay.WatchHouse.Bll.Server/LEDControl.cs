using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;
using System.Net.NetworkInformation;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class LEDControl: BasicControl
    {
        bool m_IsRun = false;
        List<WatchHouseConfigEFModel> m_LedInfoList = new List<WatchHouseConfigEFModel>();
        public LEDControl()
        {
            WatchHouseConfigEFModel[] vWatchHouseData = m_BasicDBClass_Send.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            //m_LedInfoList.AddRange(WatchHouseConfigEFModel);
        }

        public void Start()
        {

        }

        bool ping(string ip)
        {
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ip);
            if (pingReply.Status == IPStatus.Success)
                return true;
            else
                return false;
        }

        //Task pingLed()
        //{
        //    return Task.Run(() =>
        //    {
        //        foreach(WatchHouseInfoModel vTempHouse in m_LedInfoList)
        //        {
        //            vTempHouse.
        //        }
        //    });
        //}
            
    }
}
