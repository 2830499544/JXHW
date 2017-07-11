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

    public  struct PowerDataPack_Send_SwitchParam
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
        /// 标识码
        /// </summary>
        public byte BiaoShiMa { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public byte Data1 { get; set; }
        public byte Data2 { get; set; }

    }
}
