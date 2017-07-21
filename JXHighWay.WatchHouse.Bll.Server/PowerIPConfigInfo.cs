using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class PowerIPConfigInfo
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 子网掩码
        /// </summary>
        public string SubMask { get; set; } = "255.255.255.0";
        /// <summary>
        /// 网关
        /// </summary>
        public string Gateway { get; set; } = "0.0.0.0";
        /// <summary>
        /// 端口号
        /// </summary>
        public short Port { get; set; } = 5000;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MAC { get; set; }
        /// <summary>
        /// 服务器IP
        /// </summary>
        public string ServerIPAddress { get; set; }
        /// <summary>
        /// 端务器端口号
        /// </summary>
        public short ServerPort { get; set; } = 6000;

        public bool IsDHCP { get; set; } = false;
    }
}
