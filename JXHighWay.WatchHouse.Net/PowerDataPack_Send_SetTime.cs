using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Send_SetTime
    {
        /// <summary>
        /// 时区(-12<=X<=+12)
        /// </summary>
        public byte ShiQu { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public byte Time1 { get; set; }
        public byte Time2 { get; set; }
        public byte Time3 { get; set; }
        public byte Time4 { get; set; }
    }
}
