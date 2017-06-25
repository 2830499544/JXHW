using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class XinFengStateModel
    {
        public bool IsOpen { get; set; }
        public int DengJi { get; set; }
        public int WenDu { get; set; }
        public int ShiDu { get; set; }
        public int RuKouAPM { get; set; }
        public int ChuKouAPM { get; set; }
    }
}
