using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public enum PowerDataPack_Send_CommandEnum:byte
    {
        /// <summary>
        /// 获取IP地址
        /// </summary>
        Send_GetIPAddress = 0x38,

        /// <summary>
        /// 设置IP地址
        /// </summary>
        SetIPAddress = 0x3a,

        /// <summary>
        /// 控制分路开关
        /// </summary>
        Switch = 0x41,

        /// <summary>
        /// 定时设置
        /// </summary>
        Timing = 0x49,

        /// <summary>
        /// 开关参数设置
        /// </summary>
        SwitchParam = 0x45,

        /// <summary>
        /// 时间设置
        /// </summary>
        SetTime = 0x47,
    }
}
