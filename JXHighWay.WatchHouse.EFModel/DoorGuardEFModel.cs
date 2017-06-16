using System;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("门禁记录", "ID")]
    public struct DoorGuardEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("GangTingID")]
        public int? GangTingID { get; set; }
        [ColumnAttrib("ShiJiang")]
        public DateTime? ShiJiang { get; set; }
        [ColumnAttrib("KaiHao")]
        public int? KaiHao { get; set; }
        [ColumnAttrib("DongZuo")]
        public String DongZuo { get; set; }
    }
}
