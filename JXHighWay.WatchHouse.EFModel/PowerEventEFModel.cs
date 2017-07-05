using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源事件", "ID")]
    public struct PowerEventEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DianYuanID")]
        public int? DianYuanID { get; set; }
        [ColumnAttrib("LuHao")]
        public int? LuHao { get; set; }
        [ColumnAttrib("LeiXi")]
        public String LeiXi { get; set; }
        [ColumnAttrib("NeiRong")]
        public String NeiRong { get; set; }
        [ColumnAttrib("Time")]
        public DateTime? Time { get; set; }

    }

}
