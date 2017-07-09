using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public enum PowerDataPack_Send_CommandEnum:byte
    {
        #region 获取IP地址
        Send_GetIPAddress = 0x38,
        Receive_GetIPAddress = 0x39,
        #endregion

        #region 设置IP地址
        Send_SetIPAddress = 0x3a,
        Receive_SetIPAddress = 0x40,
        #endregion

        #region 控制分路开关
        Send_Switch = 0x41,
        Receive_Switch = 0x42,
        #endregion

        #region 定时设置
        Send_Timing = 0x49,
        Receive_Timing = 0x4a,
        #endregion

    }
}
