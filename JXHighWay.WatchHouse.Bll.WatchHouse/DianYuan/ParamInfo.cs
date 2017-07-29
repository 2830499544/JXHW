using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class ParamInfo
    {
        /// <summary>
        /// 电源ID
        /// </summary>
        public string DianYuanID { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public int LuHao { get; set; }
        /// <summary>
        /// 限定电能
        /// </summary>
        public short XianDingDN { get; set; }
        /// <summary>
        /// 限定功率
        /// </summary>
        public short XianDingGL { get; set; }
        /// <summary>
        /// 电流容量值
        /// </summary>
        public short DianLiuLLZ { get; set; }
        /// <summary>
        /// 超温保护值
        /// </summary>
        public UInt16 ChaoWenBHZ { get; set; }
        /// <summary>
        /// 超温预警值
        /// </summary>
        public UInt16 ChaoWenYJZ { get; set; }
        /// <summary>
        /// 过压上限
        /// </summary>
        public short GuoYaSX { get; set; }
        /// <summary>
        /// 欠压下线
        /// </summary>
        public short QianYaXX { get; set; }
        /// <summary>
        /// 额定漏电动作电流
        /// </summary>
        public short EDingLDDZDL { get; set; }
        /// <summary>
        /// 漏电流预警值
        /// </summary>
        public short LouDianLYJZ { get; set; }

    }
}
