using System;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电子工作牌记录", "ID")]
    public struct IDCardEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("GangTingID")]
        public int? GangTingID { get; set; }
        [ColumnAttrib("ShiJiang")]
        public DateTime? ShiJiang { get; set; }
        [ColumnAttrib("HuanBan")]
        public String HuanBan { get; set; }
        [ColumnAttrib("WeiYIID")]
        public int GongHao { get; set; }
    }
}
