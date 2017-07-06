using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("led数据", "ID")]
    public struct LEDDataEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("UserName")]
        public String UserName { get; set; }
        [ColumnAttrib("Text")]
        public String Text { get; set; }
        [ColumnAttrib("Pic")]
        public String Pic { get; set; }
        [ColumnAttrib("Video")]
        public String Video { get; set; }
        [ColumnAttrib("Time")]
        public DateTime? Time { get; set; }
    }

}
