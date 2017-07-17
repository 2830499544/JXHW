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
        public string DianYuanID { get; set; }
        [ColumnAttrib("LuHao")]
        public int? LuHao { get; set; }
        [ColumnAttrib("MinCheng")]
        public String MinCheng { get; set; }
        [ColumnAttrib("LeiXing")]
        public String LeiXing { get; set; }

        [ColumnAttrib("XianDingDN")]
        public short? XianDingDN { get; set; }

        [ColumnAttrib("XianDingGL")]
        public short? XianDingGL { get; set; }

        [ColumnAttrib("DianLiuLLZ")]
        public short? DianLiuLLZ { get; set; }

        [ColumnAttrib("ChaoWenBHZ")]
        public short? ChaoWenBHZ { get; set; }

        [ColumnAttrib("ChaoWenYJZ")]
        public short? ChaoWenYJZ { get; set; }

        [ColumnAttrib("GuoYaSX")]
        public short? GuoYaSX { get; set; }

        [ColumnAttrib("QianYaXX")]
        public short? QianYaXX { get; set; }

        [ColumnAttrib("EDingLDDZDL")]
        public short? EDingLDDZDL { get; set; }

        [ColumnAttrib("LouDianLYJZ")]
        public short? LouDianLYJZ { get; set; }

    }
}
