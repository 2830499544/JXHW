using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源时间配置", "ID")]
    public struct PowerTimeConfigEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DianYuanID")]
        public String DianYuanID { get; set; }
        [ColumnAttrib("Time")]
        public int? Time { get; set; }
    }
}
