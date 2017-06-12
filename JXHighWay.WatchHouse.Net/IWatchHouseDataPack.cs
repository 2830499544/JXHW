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
         short Length { get; set; }
        /// <summary>
        /// 协议版本号
        /// </summary>
         short Ver { get; set; }
        /// <summary>
        /// 登陆序号
        /// </summary>
         short LoginSN { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
         short SN { get; set; }
        /// <summary>
        /// 目标岗亭唯一ID
        /// </summary>
         int WatchHouseID { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// </summary>
         int UserID { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
         int Empty { get; set; }


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
        short Check { get; set; }
    }
}
