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
        RunningStatus = 0xc9
    }
}
