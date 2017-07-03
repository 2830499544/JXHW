using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Send_Switch
    {
        /// <summary>
        /// 设备类型 0:漏保 1:分路 2:分路(带漏保) 3:漏保插座 4:普插座
        /// </summary>
        public byte SheBeiLX { get; set; }

        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }

        /// <summary>
        /// 开关 0:跳闸(关闸) 1:合闸(开闸)
        /// </summary>
        public byte Switch { get; set; }
    }
}
