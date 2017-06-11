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
        public byte Data{ get; set; }

        #region 预留8字节
        public byte Kong1{ get; set; }
        public byte Kong2{ get; set; }
        public byte Kong3{ get; set; }
        public byte kong4{ get; set; }
        public byte Kong5{ get; set; }
        public byte Kong6{ get; set; }
        public byte Kong7{ get; set; }
        public byte Kong8{ get; set; }
        #endregion

    }
}
