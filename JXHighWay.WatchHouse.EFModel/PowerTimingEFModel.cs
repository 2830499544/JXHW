using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源定时配置", "ID")]
    public struct PowerTimingEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DianYuanID")]
        public int? DianYuanID { get; set; }
        [ColumnAttrib("LeiXing")]
        public byte? LeiXing { get; set; }
        [ColumnAttrib("LuHao")]
        public byte? LuHao { get; set; }
        [ColumnAttrib("ZhuHao")]
        public byte? ZhuHao { get; set; }
        [ColumnAttrib("RenWuLX")]
        public byte? RenWuLX { get; set; }
        [ColumnAttrib("ZhouQi")]
        public byte? ZhouQi { get; set; }
        [ColumnAttrib("YunXuKZ")]
        public byte? YunXuKZ { get; set; }
        [ColumnAttrib("TimeData")]
        public int? TimeData { get; set; }
    }

}
