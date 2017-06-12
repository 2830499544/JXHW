using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net
{
    /// <summary>
    /// 接收智慧岗亭数据包(门禁)
    /// </summary>
    public struct WatchHouseDataPack_Receive_DoorGuard:IWatchHouseDataPack
    {
        /// <summary>
        /// 头
        /// </summary>
         public byte Head { get; set; }
        /// <summary>
        /// 信息长度
        /// </summary>
         public short Length { get; set; }
        /// <summary>
        /// 协议版本号
        /// </summary>
         public short Ver { get; set; }
        /// <summary>
        /// 登陆序号
        /// </summary>
         public short LoginSN { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
         public short SN { get; set; }
        /// <summary>
        /// 目标岗亭唯一ID
        /// </summary>
         public int WatchHouseID { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 预留字段
        /// </summary>
        public int Empty { get; set; }


        public byte ID_H { get; set; }
        public byte ID_L { get; set; }
        public byte CMD { get; set; }
        public byte SUB { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[0]
        /// </summary>
        public byte DateTime0 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[1]
        /// </summary>
        public byte DateTime1 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[2]
        /// </summary>
        public byte DateTime2 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[3]
        /// </summary>
        public byte DateTime3 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[4]
        /// </summary>
        public byte DateTime4 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[5]
        /// </summary>
        public byte DateTime5 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[6]
        /// </summary>
        public byte DateTime6 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[7]
        /// </summary>
        public byte DateTime7 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[8]
        /// </summary>
        public byte DateTime8 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[9]
        /// </summary>
        public byte DateTime9 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[10]
        /// </summary>
        public byte DateTime10 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[11]
        /// </summary>
        public byte DateTime11 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[12]
        /// </summary>
        public byte DateTime12 { get; set; }
        /// <summary>
        /// 日期时间(20170503155601)
        /// Data[13]
        /// </summary>
        public byte DateTime13 { get; set; }
        /// <summary>
        /// 开门模式(0:用户卡号 1:密码开门)
        /// Data[14]
        /// </summary>
        public byte KaiMenMS { get; set; }
        /// <summary>
        /// 卡号或以‘*’代替密码
        /// Data[14]
        /// </summary>
        public byte KaHao0 { get; set; }
        /// <summary>
        /// 卡号或以‘*’代替密码
        /// Data[15]
        /// </summary>
        public byte KaHao1 { get; set; }
        /// <summary>
        /// 卡号或以‘*’代替密码
        /// Data[16]
        /// </summary>
        public byte KaHao2 { get; set; }
        /// <summary>
        /// 卡号或以‘*’代替密码
        /// Data[17]
        /// </summary>
        public byte KaHao3 { get; set; }
        /// <summary>
        /// 卡号或以‘*’代替密码
        /// Data[18]
        /// </summary>
        public byte KaHao4 { get; set; }
        /// <summary>
        /// 门状态(0:关闭 1：开门)
        /// Data[19]
        /// </summary>
        public byte MenZhuangTai { get; set; }
        /// <summary>
        /// 校验
        /// </summary>
        public short Check { get; set; }
    }
}
