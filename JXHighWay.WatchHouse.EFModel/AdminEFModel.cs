using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("管理员", "ID")]
    public struct AdminEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("ZhangHao")]
        public String ZhangHao { get; set; }
        [ColumnAttrib("MiMa")]
        public String MiMa { get; set; }
        [ColumnAttrib("GangTingGZ")]
        public bool? GangTingGZ { get; set; }
        [ColumnAttrib("LEDGongZhi")]
        public bool? LEDGongZhi { get; set; }
        [ColumnAttrib("DianYuanGZ")]
        public bool? DianYuanGZ { get; set; }
    }
}
