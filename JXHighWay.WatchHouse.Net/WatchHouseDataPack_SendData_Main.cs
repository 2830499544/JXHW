using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net
{
    /// <summary>
    /// 发送数据包至智慧岗亭
    /// </summary>
    public struct WatchHouseDataPack_SendData_Main:IWatchHouseDataPack
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
        /// 协议版本号
        /// </summary>
        public byte Ver1 { get; set; }
        public byte Ver2 { get; set; }
        /// <summary>
        /// 登陆序号
        /// </summary>
        public byte LoginSN1 { get; set; }
        public byte LoginSN2 { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public byte SN1 { get; set; }
        public byte SN2 { get; set; }
        /// <summary>
        /// 目标岗亭唯一ID
        /// </summary>
        public byte WatchHouseID1 { get; set; }
        public byte WatchHouseID2 { get; set; }
        public byte WatchHouseID3 { get; set; }
        public byte WatchHouseID4 { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        public byte UserID1 { get; set; }
        public byte UserID2 { get; set; }
        public byte UserID3 { get; set; }
        public byte UserID4 { get; set; }
        /// <summary>
        /// 控制平板类型
        /// </summary>
        public byte PinBanLX { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public byte Empty1 { get; set; }
        public byte Empty2 { get; set; }
        public byte Empty3 { get; set; }

        /// <summary>
        /// 智慧系列设备
        /// Data[0]
        /// </summary>
        public byte ID_H{ get; set; }
        /// <summary>
        /// ID
        /// Data[1]
        /// </summary>
        public byte ID_L{ get; set; }
        /// <summary>
        /// 命令
        /// Data[2]
        /// </summary>
        public byte CMD{ get; set; }
        /// <summary>
        /// 子命令
        /// Data[3]
        /// </summary>
        public byte SUB{ get; set; }
        /// <summary>
        /// 数据
        /// Data[4]
        /// </summary>
        public byte Data { get; set; }

        #region 预留4字节
        public byte Kong1{ get; set; }
        public byte Kong2{ get; set; }
        public byte Kong3{ get; set; }
        public byte kong4{ get; set; }
        public byte Kong5 { get; set; }
        public byte Kong6 { get; set; }
        public byte Kong7 { get; set; }
        public byte Kong8 { get; set; }
        #endregion

        public byte Check1 { get; set; }
        public byte Check2 { get; set; }

    }
}
