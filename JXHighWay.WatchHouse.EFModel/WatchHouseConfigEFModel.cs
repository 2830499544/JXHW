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
        [ColumnAttrib("DianYuanID")]
        public int? DianYuanID { get; set; }
        [ColumnAttrib("DianYuanIP")]
        public String DianYuanIP { get; set; }
        [ColumnAttrib("DianYuanDK")]
        public int? DianYuanDK { get; set; }
        [ColumnAttrib("DianYuanLS")]
        public int? DianYuanLS { get; set; }
        [ColumnAttrib("GangTingTXSJ")]
        public DateTime? GangTingTXSJ { get; set; }
        [ColumnAttrib("DianYuanTXSJ")]
        public DateTime? DianYuanTXSJ { get; set; }
        [ColumnAttrib("LeiXin")]
        public string LeiXin { get; set; }
        [ColumnAttrib("GongHao")]
        public string GongHao { get; set; }

    }
}
