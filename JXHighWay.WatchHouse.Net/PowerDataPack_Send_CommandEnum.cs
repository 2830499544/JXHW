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
        /// 设置开关参数设置
        /// </summary>
        SetSwitchParam = 0x4b,
        /// <summary>
        /// 获取开关参数设置
        /// </summary>
        GetSwitchParam = 0x6B,

        /// <summary>
        /// 时间设置
        /// </summary>
        SetTime = 0x47,
        /// <summary>
        /// 获取时间
        /// </summary>
        GetTime = 0x61,
        /// <summary>
        /// 查询配电箱设备信息
        /// </summary>
        GetControlInfo = 0X6D
    }
}
