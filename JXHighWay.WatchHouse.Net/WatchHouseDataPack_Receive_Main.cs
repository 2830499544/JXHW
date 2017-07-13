using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net
{
    /// <summary>
    /// 接收智慧岗亭数据包(主)
    /// </summary>
    public struct WatchHouseDataPack_Receive_Main:IWatchHouseDataPack
    {
        /// <summary>
        /// 头
        /// [0]
        /// </summary>
        public byte Head { get; set; }
        /// <summary>
        /// 信息长度
        /// [1-2]
        /// </summary>
        public byte Length1 { get; set; }
        public byte Length2 { get; set; }
        /// <summary>
        /// 协议版本号
        /// [3-4]
        /// </summary>
        public byte Ver1 { get; set; }
        public byte Ver2 { get; set; }
        /// <summary>
        /// 登陆序号
        /// [5-6]
        /// </summary>
        public byte LoginSN1 { get; set; }
        public byte LoginSN2 { get; set; }

        /// <summary>
        /// 序列号
        /// [7-8]
        /// </summary>
        public byte SN1 { get; set; }
        public byte SN2 { get; set; }
        /// <summary>
        /// 目标岗亭唯一ID
        /// [9-12]
        /// </summary>
        public byte WatchHouseID1 { get; set; }
        public byte WatchHouseID2 { get; set; }
        public byte WatchHouseID3 { get; set; }
        public byte WatchHouseID4 { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// [13-16]
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
        /// [17-20]
        /// </summary>
        public byte Empty1 { get; set; }
        public byte Empty2 { get; set; }
        public byte Empty3 { get; set; }


        public byte ID_H{ get; set; }
        public byte ID_L{ get; set; }
        public byte CMD{ get; set; }
        public byte SUB{ get; set; }
        /// <summary>
        /// 门状态(0:开 1:关)
        /// Data[0]
        /// </summary>
        public byte MenZhuanTai{ get; set; }
        /// <summary>
        /// 电磁锁(0:开 1:关)
        /// Data[1]
        /// </summary>
        public byte DianChiSuo{ get; set; }
        /// <summary>
        /// 机械锁(0:开 1:关)
        /// Data[2]
        /// </summary>
        public byte JiXieSuo{ get; set; }
        /// <summary>
        /// 门状态(0:开 1:关)
        /// Data[3]
        /// </summary>
        public byte MenZhuanTai1{ get; set; }
        /// <summary>
        /// 报警器状态(0:关闭 1:开启)
        /// Data[4]
        /// </summary>
        public byte BaoJingQi{ get; set; }
        /// <summary>
        /// 窗(0:开 1:关)
        /// Data[5]
        /// </summary>
        public byte Chuang{ get; set; }
        /// <summary>
        /// 风幕状态(0:闭 1:开)
        /// Data[6]
        /// </summary>
        public byte FengMu{ get; set; }
        /// <summary>
        /// 窗灯状态(0:闭 1:开)
        /// Data[7]
        /// </summary>
        public byte ChuangDeng{ get; set; }
        /// <summary>
        /// 新风状态(0:闭 1:开)
        /// Data[8]
        /// </summary>
        public byte XinFeng{ get; set; }
        /// <summary>
        /// 灯(0:闭 1:开)
        /// Data[9]
        /// </summary>
        public byte Deng{ get; set; }
        /// <summary>
        /// 地暖(0:闭 1:开)
        /// Data[10]
        /// </summary>
        public byte DiNuan{ get; set; }
        /// <summary>
        /// 左暖脚器(0:闭 1:开)
        /// Data[11]
        /// </summary>
        public byte ZuoNuanJQ{ get; set; }
        /// <summary>
        /// 右暖脚器(0:闭 1:开)
        /// Data[12]
        /// </summary>
        public byte YouNuanJQ{ get; set; }
        /// <summary>
        /// 室内温度(灯板)
        /// Data[13-14]
        /// </summary>
        public byte ShiLeiWD1{ get; set; }
        public byte ShiLeiWD2 { get; set; }
        /// <summary>
        /// 室内湿度(0->100)
        /// Data[15]
        /// </summary>
        public byte ShiLeiSD{ get; set; }
        /// <summary>
        /// 空调(0:闭 1:开)
        /// Data[16]
        public byte KongTiao{ get; set; }
        /// <summary>
        /// </summary>
        /// 空调工作模式(1:空调工作模式 2:自动模式 3：制冷模式 4:除湿模式 5:制热模式 6:送风模式)
        /// Data[17]
        /// </summary>
        public byte KongTiaoGZMS{ get; set; }
        /// <summary>
        /// 空调工作风量(0:低风 1:中风 2:高风)
        /// Data[18]
        /// </summary>
        public byte KongTiaoGZFL{ get; set; }
        /// <summary>
        /// 空气质量(1:优 2：良 3:轻度污染 4：中度污染 5：重度污染 6:严重污染)
        /// Data[19]
        /// </summary>
        public byte KongQiZL{ get; set; }
        /// <summary>
        /// 新风系统空气质量(0->255)
        /// Data[20]
        /// </summary>
        public byte XinFengXTKQZL{ get; set; }
        /// <summary>
        /// 空
        /// Data[21]
        /// </summary>
        public byte Kong{ get; set; }
        /// <summary>
        /// 采暖控制当前设置的温度
        /// Data[22]
        /// </summary>
        public byte CaiLuanKZWD{ get; set; }
        /// <summary>
        /// 采暖控制外部传感器温度
        /// Data[23-24]
        /// </summary>
        public byte CaiLuanKZWBWD1{ get; set; }
        public byte CaiLuanKZWBWD2 { get; set; }
        /// <summary>
        /// 采暖控制地表传感器温度
        /// Data[25-26]
        /// </summary>
        public byte CaiLuanKZDBWD1{ get; set; }
        public byte CaiLuanKZDBWD2{ get; set; }
        ///<summary>
        ///电流监控
        ///Bit.0
        ///Bit.1
        ///Bit.2 AC220 1 有电， 0 无电
        ///Bit.3 地热电流 1 有效，0 无效
        ///Bit.4 左暖脚器电流 1 有效，0 无效
        ///Bit.5 右暖脚器电流 1 有效，0 无效
        ///Bit.6 前窗帘电流 1 有效，0 无效
        ///Bit.7 右窗帘电流 1 有效，0 无效
        ///Data[27]
        /// </summary>
        public byte DianLiuJK{ get; set; }
        /// <summary>
        ///门控传感器状态
        ///Bit.0 1 sensor1 有效
        ///Bit.1 1 sensor2 有效
        ///Bit.2 1 sensor3 有效
        ///Bit.3 1 sensor4 有效
        ///Data[28]
        /// </summary>
        public byte MenKongCKQ{ get; set; }
        /// <summary>
        /// 窗控传感器状态
        ///Bit.0 1 sensor1 有效
        ///Bit.1 1 sensor2 有效
        ///Bit.2 1 sensor3 有效
        ///Bit.3 1 sensor4 有效
        ///Data[29]
        /// </summary>
        public byte ChuangKongCKQ{ get; set; }
        /// <summary>
        ///工控机输出IO状态
        ///0 无效，1 有效
        ///Bit.0 落栏杆
        ///Bit.1 抬栏杆
        ///Bit.2 通行灯-红灯
        ///Bit.3 通行灯-绿灯
        ///Bit.4 雨棚灯-红灯
        ///Bit.5 雨棚灯-绿灯
        ///Bit.6 报警
        ///Bit.7 备用
        ///Data[30]
        /// </summary>
        public byte GongKongJSC{ get; set; }
        /// <summary>
        /// 工控机输入IO状态
        /// 0 无效，1 有效
        ///Bit.0
        ///Bit.1
        ///Bit.2
        ///Bit.3
        ///Bit.4
        ///Bit.5 手动报警
        ///Bit.6 前线圈
        ///Bit.7 后线圈
        ///Data[31]
        /// </summary>
        public byte GongKongJSR{ get; set; }
        /// <summary>
        /// 灯光亮度(25%->100%)
        /// Data[32]
        /// </summary>
        public byte DengGuanLD{ get; set; }
        /// <summary>
        /// 新风等级(1->5)
        /// Data[33]
        /// </summary>
        public byte XinFengDJ{ get; set; }
        /// <summary>
        /// 新风温度
        /// Data[34-35]
        /// </summary>
        public byte XinFengWD1{ get; set; }
        public byte XinFengWD2 { get; set; }
        /// <summary>
        /// 入口风APM(千分比)
        /// Data[36-37]
        /// </summary>
        public byte RuKouFAPM1{ get; set; }
        public byte RuKouFAPM2{ get; set; }
        /// <summary>
        /// 室内出口风APM(千分比)
        /// Data[38-39]
        /// </summary>
        public byte ChuKouAPM1{ get; set; }
        public byte ChuKouAPM2{ get; set; }

        public byte Check1 { get; set; }
        public byte Check2 { get; set; }
    }
}
