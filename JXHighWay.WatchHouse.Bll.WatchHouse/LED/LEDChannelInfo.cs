using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.LED
{
    /// <summary>
    /// 频道节目信息
    /// </summary>
    public class LEDChannelInfo
    {
        /// <summary>
        /// 节目类型
        /// </summary>
        public LEDChanneTypeEnum ChannelType { get; set; }
        /// <summary>
        /// 节目内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 显示效果
        /// </summary>
        public int InEff { get; set; }
        /// <summary>
        /// 清屏效果
        /// </summary>
        public int OutEff { get; set; }
        /// <summary>
        /// 停留时间
        /// </summary>
        public int HoldTime { get; set; }
    }
}
