using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("岗亭配置", "ID")]
    public struct WatchHouseConfigEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("ShouFeiZhangID")]
        public int? ShouFeiZhangID { get; set; }
        [ColumnAttrib("GangTingID")]
        public int? GangTingID { get; set; }
        [ColumnAttrib("GangTingMC")]
        public String GangTingMC { get; set; }
        [ColumnAttrib("GangTingIP")]
        public String GangTingIP { get; set; }
        [ColumnAttrib("GangTingDK")]
        public int? GangTingDK { get; set; }
        [ColumnAttrib("GangTingLX")]
        public string GangTingLX { get; set; }
        [ColumnAttrib("GuanGaoPingIP")]
        public String GuanGaoPingIP { get; set; }
        [ColumnAttrib("GuanGaoPDK")]
        public int? GuanGaoPDK { get; set; }

        [ColumnAttrib("DianYuan1ID")]
        public string DianYuan1ID { get; set; }

        [ColumnAttrib("DianYuan1IP")]
        public String DianYuan1IP { get; set; }

        //[ColumnAttrib("DianYuan1DK")]
        //public int? DianYuan1DK { get; set; }

        //[ColumnAttrib("DianYuan1LS")]
        //public int? DianYuan1LS { get; set; }

        [ColumnAttrib("DianYuan2ID")]
        public string DianYuan2ID { get; set; }

        [ColumnAttrib("DianYuan2IP")]
        public String DianYuan2IP { get; set; }

        //[ColumnAttrib("DianYuan2DK")]
        //public int? DianYuan2DK { get; set; }

        //[ColumnAttrib("DianYuan2LS")]
        //public int? DianYuan2LS { get; set; }

        [ColumnAttrib("GangTingTXSJ")]
        public DateTime? GangTingTXSJ { get; set; }
        [ColumnAttrib("DianYuanTXSJ")]
        public DateTime? DianYuanTXSJ { get; set; }
        [ColumnAttrib("LeiXin")]
        public string LeiXin { get; set; }
        [ColumnAttrib("GongHao")]
        public string GongHao { get; set; }
        [ColumnAttrib("OrderID")]
        public int? OrderID { get; set; }


    }
}
