using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public class PowerDataPack_Receive_ReplyCMD
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
        /// <summary>
        /// 命令回复状态 0:成功 1:失败
        /// </summary>
        public byte State { get; set; }
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
