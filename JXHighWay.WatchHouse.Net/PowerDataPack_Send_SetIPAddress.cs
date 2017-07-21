using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Send_SetIPAddress
    {
        #region 网关
        public byte Gateway1 { get; set; }
        public byte Gateway2 { get; set; }
        public byte Gateway3 { get; set; }
        public byte Gateway4 { get; set; }
        #endregion

        #region 子网掩码
        public byte SubnetMask1 { get; set; }
        public byte SubnetMask2 { get; set; }
        public byte SubnetMask3 { get; set; }
        public byte SubnetMask4 { get; set; }
        #endregion

        #region IP地址
        public byte IPAddress1 { get; set; }
        public byte IPAddress2 { get; set; }
        public byte IPAddress3 { get; set; }
        public byte IPAddress4 { get; set; }
        #endregion

        #region 端口号
        public byte Port1 { get; set; }
        public byte Port2 { get; set; }
        #endregion

        #region MAC地址
        public byte MAC1 { get; set; }
        public byte MAC2 { get; set; }
        public byte MAC3 { get; set; }
        public byte MAC4 { get; set; }
        public byte MAC5 { get; set; }
        public byte MAC6 { get; set; }
        #endregion

        #region 服务器IP地址
        public byte ServerIPAddress1 { get; set; }
        public byte ServerIPAddress2 { get; set; }
        public byte ServerIPAddress3 { get; set; }
        public byte ServerIPAddress4 { get; set; }
        #endregion

        #region 服务器端口号
        public byte ServerPort1 { get; set; }
        public byte ServerPort2 { get; set; }
        #endregion

        /// <summary>
        /// 为1时表示开启，0时表示关闭
        /// </summary>
        public byte DHCP { get; set; }

    }

}
