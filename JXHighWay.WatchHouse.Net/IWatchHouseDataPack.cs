using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net
{
    interface IWatchHouseDataPack
    {
         byte ID_H { get; set; }
         byte ID_L { get; set; }
         byte CMD { get; set; }
         byte SUB { get; set; }
    }
}
