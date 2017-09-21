using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;
using System.Net.NetworkInformation;
using System.Threading;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class LEDControl: BasicControl
    {
        bool m_IsRun = false;
        WatchHouseConfigEFModel[] m_LedInfoList;
        public LEDControl()
        {
            m_LedInfoList = m_BasicDBClass_Send.SelectAllRecordsEx<WatchHouseConfigEFModel>();
        }

        public void Start()
        {
            m_IsRun = true;
            asyncPingLed();
        }

        public void Stop()
        {
            m_IsRun = false;
        }

        async void asyncPingLed()
        {
            await pingLed();
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

        Task pingLed()
        {
            return Task.Run(() =>
            {
                while (m_IsRun)
                {
                    foreach (WatchHouseConfigEFModel vTempHouse in m_LedInfoList)
                    {
                        if (vTempHouse.GuanGaoPing1IP != null && vTempHouse.GuanGaoPing1IP != "")
                        {
                            if (ping(vTempHouse.GuanGaoPing1IP))
                            {
                                WatchHouseConfigEFModel vEFModel = new WatchHouseConfigEFModel()
                                {
                                    ID = vTempHouse.ID,
                                    GuanGao1TXSJ = DateTime.Now
                                };
                                m_BasicDBClass_Send.UpdateRecord(vEFModel);
                            }
                        }

                        if (vTempHouse.GuanGaoPing2IP != null && vTempHouse.GuanGaoPing2IP != "")
                        {
                            if (ping(vTempHouse.GuanGaoPing2IP))
                            {
                                WatchHouseConfigEFModel vEFModel = new WatchHouseConfigEFModel()
                                {
                                    ID = vTempHouse.ID,
                                    GuanGao2TXSJ = DateTime.Now
                                };
                                m_BasicDBClass_Send.UpdateRecord(vEFModel);
                            }
                        }
                    }
                    Thread.Sleep(60000);//间隔时间1分钟
                }
            });
        }

    }
}
