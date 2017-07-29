using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Send_GetSwitchParam
    {
        /// <summary>
        /// 设备类型
        /// </summary>
        public byte SheBeiLX { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }

    }
}
