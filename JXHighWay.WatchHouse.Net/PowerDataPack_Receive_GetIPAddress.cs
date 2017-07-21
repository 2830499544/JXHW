using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Receive_GetIPAddress
    {
        /// <summary>
        /// 头
        /// </summary>
        public byte Head { get; set; }
        /// <summary>
        /// 信息长度
        /// </summary>
        public byte Length1 { get; set; }
        public byte Length2 { get; set; }

        /// <summary>
        /// MAC地址
        /// </summary>
        public byte MAC1 { get; set; }
        public byte MAC2 { get; set; }
        public byte MAC3 { get; set; }
        public byte MAC4 { get; set; }
        public byte MAC5 { get; set; }
        public byte MAC6 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public byte SN { get; set; }
        /// <summary>
        /// 附加码
        /// </summary>
        public byte Addition { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public byte CMD { get; set; }

        #region 数据区域
        #region 网关
        public byte gateway1 { get; set; }
        public byte gateway2 { get; set; }
        public byte gateway3 { get; set; }
        public byte gateway4 { get; set; }
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
        public byte MAC_1 { get; set; }
        public byte MAC_2 { get; set; }
        public byte MAC_3 { get; set; }
        public byte MAC_4 { get; set; }
        public byte MAC_5 { get; set; }
        public byte MAC_6 { get; set; }
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
        #endregion

        /// <summary>
        /// 检验和
        /// </summary>
        public byte Check { get; set; }
        /// <summary>
        /// 尾
        /// </summary>
        public byte Tail { get; set; }
    }
}
