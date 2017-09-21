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

        [ColumnAttrib("GuanGaoPing1IP")]
        public String GuanGaoPing1IP { get; set; }
        [ColumnAttrib("GuanGao1DK")]
        public int? GuanGao1DK { get; set; }
        [ColumnAttrib("GuanGao1Gao")]
        public int? GuanGao1Gao { get; set; }
        [ColumnAttrib("GuanGao1Kuang")]
        public int? GuanGao1Kuang { get; set; }


        [ColumnAttrib("GuanGaoPing2IP")]
        public String GuanGaoPing2IP { get; set; }
        [ColumnAttrib("GuanGao2Gao")]
        public int? GuanGao2Gao { get; set; }
        [ColumnAttrib("GuanGao2Kuang")]
        public int? GuanGao2Kuang { get; set; }


        [ColumnAttrib("DianYuan1ID")]
        public string DianYuan1ID { get; set; }

        [ColumnAttrib("DianYuan1IP")]
        public String DianYuan1IP { get; set; }

        [ColumnAttrib("DianYuan2ID")]
        public string DianYuan2ID { get; set; }

        [ColumnAttrib("DianYuan2IP")]
        public String DianYuan2IP { get; set; }

        [ColumnAttrib("GangTingTXSJ")]
        public DateTime? GangTingTXSJ { get; set; }

        [ColumnAttrib("DianYuanTXSJ")]
        public DateTime? DianYuanTXSJ { get; set; }

        [ColumnAttrib("GuanGao1TXSJ")]
        public DateTime? GuanGao1TXSJ { get; set; }

        [ColumnAttrib("GuanGao2TXSJ")]
        public DateTime? GuanGao2TXSJ { get; set; }

        [ColumnAttrib("LeiXin")]
        public string LeiXin { get; set; }
        [ColumnAttrib("GongHao")]
        public int? GongHao { get; set; }
        [ColumnAttrib("OrderID")]
        public int? OrderID { get; set; }


    }
}
