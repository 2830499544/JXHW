using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源开关配置", "ID")]
    public struct PowerSwithConfigEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DianYuanID")]
        public int? DianYuanID { get; set; }
        [ColumnAttrib("LuHao")]
        public String LuHao { get; set; }
        [ColumnAttrib("MinCheng")]
        public String MinCheng { get; set; }
        [ColumnAttrib("LeiXing")]
        public String LeiXing { get; set; }
    }
}
