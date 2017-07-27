using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("员工信息", "ID")]
    public struct EmployeeEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("XingMing")]
        public String XingMing { get; set; }
        [ColumnAttrib("XingBie")]
        public String XingBie { get; set; }
        [ColumnAttrib("GongHao")]
        public int? GongHao { get; set; }
        [ColumnAttrib("KaHao")]
        public String KaHao { get; set; }
        [ColumnAttrib("ZhaoPian")]
        public String ZhaoPian { get; set; }
        [ColumnAttrib("XingJi")]
        public String XingJi { get; set; }
        [ColumnAttrib("GeYan")]
        public String GeYan { get; set; }
    }

}
