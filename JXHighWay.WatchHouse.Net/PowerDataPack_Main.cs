using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Main
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
