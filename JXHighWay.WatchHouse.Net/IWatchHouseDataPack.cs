using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net
{
    interface IWatchHouseDataPack
    {
        /// <summary>
        /// 头
        /// </summary>
         byte Head { get; set; }
        /// <summary>
        /// 信息长度
        /// </summary>
         byte Length1 { get; set; }
         byte Length2 { get; set; }
        /// <summary>
        /// 协议版本号
        /// </summary>
        byte Ver1 { get; set; }
        byte Ver2 { get; set; }
        /// <summary>
        /// 登陆序号
        /// </summary>
        byte LoginSN1 { get; set; }
        byte LoginSN2 { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        byte SN1 { get; set; }
        byte SN2 { get; set; }
        /// <summary>
        /// 目标岗亭唯一ID
        /// </summary>
        byte WatchHouseID1 { get; set; }
        byte WatchHouseID2 { get; set; }
        byte WatchHouseID3 { get; set; }
        byte WatchHouseID4 { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        byte UserID1 { get; set; }
        byte UserID2 { get; set; }
        byte UserID3 { get; set; }
        byte UserID4 { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        byte Empty1 { get; set; }
        byte Empty2 { get; set; }
        byte Empty3 { get; set; }
        byte Empty4 { get; set; }


        /// <summary>
        /// 智慧系列设备
        /// </summary>
        byte ID_H { get; set; }
        /// <summary>
        /// ID
        /// </summary>
         byte ID_L { get; set; }
        /// <summary>
        /// 命令
        /// </summary>
         byte CMD { get; set; }
        /// <summary>
        /// 子命令
        /// </summary>
         byte SUB { get; set; }
        /// <summary>
        /// 校验
        /// </summary>
        byte Check1 { get; set; }
        byte Check2 { get; set; }
    }
}
