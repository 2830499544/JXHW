using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class TimingInfo
    {
        public int DianYuanID { get; set; }
        public byte LuHao { get; set; }

        public byte LeiXing { get; set; }

        public byte ZhuHao { get; set; }

        public byte RenWuLX { get; set; }

        public byte ZhouQi { get; set; }

        public byte YunXuKZ { get; set; }

        public int TimeData { get; set; }
    }
}
