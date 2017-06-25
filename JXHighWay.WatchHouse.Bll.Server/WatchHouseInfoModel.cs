using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WatchHouseInfoModel
    {

        public int? ID { get; set; }
        public int? ShouFeiZhangID { get; set; }
        public int? GangTingID { get; set; }
        public String GangTingMC { get; set; }
        public String GangTingIP { get; set; }
        public int? GangTingDK { get; set; }
        public String GuanGaoPingIP { get; set; }
        public int? GuanGaoPDK { get; set; }
        public String DianYuanIP { get; set; }
        public int? DianYuanDK { get; set; }
        public int? DianYuanLS { get; set; }
        public DateTime? TongXunSJ { get; set; }
        public string LeiXin { get; set; }
        public string GongHao { get; set; }
    }
}
