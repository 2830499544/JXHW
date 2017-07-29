using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Receive_GetSwitchParam
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
        /// 设备类型
        /// </summary>
        public byte SheBeiLX { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }
        /// <summary>
        /// 限定电能
        /// </summary>
        public byte XianDingDN1 { get; set; }
        public byte XianDingDN2 { get; set; }
        /// <summary>
        /// 限定功率
        /// </summary>
        public byte XianDingGL1 { get; set; }
        public byte XianDingGL2 { get; set; } 
        /// <summary>
        /// 电流容量值
        /// </summary>
        public byte DianLiuRLZ1 { get; set; }
        public byte DianLiuRLZ2 { get; set; }
        /// <summary>
        /// 超温保护值
        /// </summary>
        public byte ChaoWenBHZ1 { get; set; }
        public byte ChaoWenBHZ2 { get; set; }
        /// <summary>
        /// 超温预警值
        /// </summary>
        public byte ChaoWenYJZ1 { get; set; }
        public byte ChaoWenYJZ2 { get; set; }
        /// <summary>
        /// 过压上限
        /// </summary>
        public byte GuoYaSX1 { get; set; }
        public byte GuoYaSX2 { get; set; }
        /// <summary>
        /// 欠压下限
        /// </summary>
        public byte QianYaXX1 { get; set; }
        public byte QianYaXX2 { get; set; }
        /// <summary>
        /// 额定漏电动作电流
        /// </summary>
        public byte EDingLDDZDL1 { get; set; }
        public byte EDingLDDZDL2 { get; set; }
        /// <summary>
        /// 漏电流预警值
        /// </summary>
        public byte LouDianLYJZ1 { get; set; }
        public byte LouDianLYJZ2 { get; set; }
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
