using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.GanTing
{
    public class WatchHouseInfo
    {

        public int? ID { get; set; }
        public int? ShouFeiZhangID { get; set; }
        public int? GangTingID { get; set; }
        public String GangTingMC { get; set; }
        public String GangTingIP { get; set; }
        public int? GangTingDK { get; set; }
        public String GuanGaoPingIP { get; set; }
        public int? GuanGaoPDK { get; set; }
        public string DianYuan1ID { get; set; }
        public String DianYuan1IP { get; set; }
        public string DianYuan2ID { get; set; }
        public String DianYuan2IP { get; set; }
        public DateTime? TongXunSJ { get; set; }
        public string LeiXin { get; set; }
        public int GongHao { get; set; }
        public bool IsOnline { get; set; }
    }
}
