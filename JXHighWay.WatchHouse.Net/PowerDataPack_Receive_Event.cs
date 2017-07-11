using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public class PowerDataPack_Receive_Event
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

        #region 数据区域
        /// <summary>
        /// 设备类型 0漏保 1分路 2分路(带漏保) 3漏保插座 4 普插座
        /// </summary>
        public byte LeiXing { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }
        /// <summary>
        /// 事件类型
        /// </summary>
        public byte ShiJinLX { get; set; }
        /// <summary>
        /// 事件编码
        /// </summary>
        public byte ShiJianBM { get; set; }
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
