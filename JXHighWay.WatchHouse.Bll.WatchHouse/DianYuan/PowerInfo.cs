using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class PowerInfo
    {
        /// <summary>
        /// 路号
        /// </summary>
        public int LuHao { get; set; }
        /// <summary>
        /// 开关名称
        /// </summary>
        public string MingCheng { get; set; }
        /// <summary>
        /// 电流
        /// </summary>
        public double DianLiu { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public double DianYa { get; set; }
        /// <summary>
        /// 电能
        /// </summary>
        public double DianNeng { get; set; }
        /// <summary>
        /// 有功功率
        /// </summary>
        public double YouGongGL { get; set; }
        /// <summary>
        /// 无功功率
        /// </summary>
        public double WuGongGL { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public double WenDu { get; set; }
        /// <summary>
        /// 功率因素
        /// </summary>
        public double GongLuYinShu { get; set; }
        /// <summary>
        /// 漏电流
        /// </summary>
        public double LouDianLiu { get; set; }
        /// <summary>
        /// 频率
        /// </summary>
        public double PinLu { get; set; }
        /// <summary>
        /// 开关状态
        /// </summary>
        public bool ZhuangTai { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? ShiJian { get; set; }
        /// <summary>
        /// 时间(字符)
        /// </summary>
        public string ShiJianStr { get; set; }
    }
}
