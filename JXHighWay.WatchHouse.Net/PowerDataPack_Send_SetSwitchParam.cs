using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{

    public enum PowerDataPack_Send_SwitchParam_CommandEnum : byte
    {
        /// <summary>
        /// 限定电能
        /// </summary>
        XianDingDN = 0x00,
        /// <summary>
        /// 限定功率
        /// </summary>
        XianDingGL = 0x01,
        /// <summary>
        /// 电流容量值
        /// </summary>
        DianLiuLLZ = 0x02,
        /// <summary>
        /// 超温保护值
        /// </summary>
        ChaoWenBHZ = 0x03,
        /// <summary>
        /// 超温预警值
        /// </summary>
        ChaoWenYJZ = 0x04,
        /// <summary>
        /// 过压上限
        /// </summary>
        GuoYaSX = 0x05,
        /// <summary>
        /// 欠压下限
        /// </summary>
        QianYaXX = 0x06,
        /// <summary>
        /// 额定漏电动作电流
        /// </summary>
        EDingLDDZDL = 0x07,
        /// <summary>
        /// 漏电流预警值
        /// </summary>
        LouDianLYJZ = 0x08
    }

    public  struct PowerDataPack_Send_SetSwitchParam
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
    }
}
