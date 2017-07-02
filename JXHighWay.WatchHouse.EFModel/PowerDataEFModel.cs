using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源数据", "ID")]
    public struct PowerDataEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("LeiXing")]
        public string LeiXing { get; set; }
        [ColumnAttrib("DianYuanID")]
        public int? DianYuanID { get; set; }
        [ColumnAttrib("LuHao")]
        public int? LuHao { get; set; }
        [ColumnAttrib("DianYa")]
        public int? DianYa { get; set; }
        [ColumnAttrib("DianLiu")]
        public int? DianLiu { get; set; }
        [ColumnAttrib("DianNeng")]
        public int? DianNeng { get; set; }
        [ColumnAttrib("YouGongGL")]
        public int? YouGongGL { get; set; }
        [ColumnAttrib("WuGongGL")]
        public int? WuGongGL { get; set; }
        [ColumnAttrib("WenDu")]
        public int? WenDu { get; set; }
        [ColumnAttrib("GongLuYinShu")]
        public int? GongLuYinShu { get; set; }
        [ColumnAttrib("LouDianLiu")]
        public int? LouDianLiu { get; set; }
        [ColumnAttrib("PinLu")]
        public int? PinLu { get; set; }
    }

}
