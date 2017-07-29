using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public enum PowerDataPack_Receive_CommandEnum:byte
    {
        /// <summary>
        /// 电箱运行状态
        /// </summary>
        RunningStatus = 0xc9,
        /// <summary>
        /// 电源开关命令返回
        /// </summary>
        SwitchStatus =0x42,
        /// <summary>
        /// 上报配电箱事件
        /// </summary>
        Event = 0xca,
        /// <summary>
        /// 设置时间
        /// </summary>
        SetTime = 0x48,
        /// <summary>
        /// 获取时间
        /// </summary>
        GetTime = 0x62,
        /// <summary>
        /// 获取IP地址
        /// </summary>
        GetIPAddress = 0x39,
        /// <summary>
        /// 设置IP地址
        /// </summary>
        SetIPAddress = 0x40,
        /// <summary>
        ///设置开关参数设置 
        /// </summary>
        SetSwitchParam = 0x4c,
        /// <summary>
        /// 获取开关参数设置
        /// </summary>
        GetSwitchParam = 0x6C,
        /// <summary>
        ///定时设置 
        /// </summary>
        Timing = 0x4a,
    }
}
