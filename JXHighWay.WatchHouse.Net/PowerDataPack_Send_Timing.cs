using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    /// <summary>
    /// 定时设置
    /// </summary>
    public class PowerDataPack_Send_Timing
    {
        /// <summary>
        /// 设备类型 (0漏保 1分路 2分路（带漏保）3漏保插座 4普插座 5MESH节点)
        /// </summary>
        public byte LeiXing { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }
        /// <summary>
        /// 组号
        /// </summary>
        public byte ZhuHao { get; set; }
        /// <summary>
        /// 任务类型(0关 1开 2漏电实验)
        /// </summary>
        public byte RenWuLX { get; set; }
        /// <summary>
        /// 周期类型(0单次 1每天 3每周 4每月)
        /// </summary>
        public byte ZhouQi { get; set; }
        /// <summary>
        /// 允许控制(0禁止 1允许)
        /// </summary>
        public byte YunXuKZ { get; set; }
        #region 时间数据
        public byte TimeData1 { get; set; }
        public byte TimeData2 { get; set; }
        public byte TimeData3 { get; set; }
        public byte TimeData4 { get; set; }
        #endregion
    }
}
