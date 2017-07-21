using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("电源网络配置", "ID")]
    public struct PowerNetConfigEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("MAC")]
        public String MAC { get; set; }
        [ColumnAttrib("IPAddress")]
        public String IPAddress { get; set; }
        [ColumnAttrib("SubMask")]
        public String SubMask { get; set; }
        [ColumnAttrib("Gateway")]
        public String Gateway { get; set; }
        [ColumnAttrib("Port")]
        public Int16? Port { get; set; }
        [ColumnAttrib("ServerIPAddress")]
        public String ServerIPAddress { get; set; }
        [ColumnAttrib("ServerPort")]
        public Int16? ServerPort { get; set; }
        [ColumnAttrib("DHCP")]
        public bool DHCP { get; set; }
    }

}
