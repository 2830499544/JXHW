using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源发送命令", "ID")]
    public struct PowerSendCMDEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("DianYuanID")]
        public string DianYuanID { get; set; }
        [ColumnAttrib("CMD")]
        public byte? CMD { get; set; }
        [ColumnAttrib("SN")]
        public byte? SN { get; set; }
        [ColumnAttrib("Data")]
        public byte[] Data { get; set; }
        [ColumnAttrib("SendTime")]
        public DateTime? SendTime { get; set; }
        [ColumnAttrib("State")]
        public bool? State { get; set; }
        [ColumnAttrib("IsSend")]
        public bool? IsSend { get; set; }
        [ColumnAttrib("IsReply")]
        public bool? IsReply { get; set; }
    }
}
