﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public enum WatchHouseDataPack_Receive_CommandEnmu
    {
        #region 门控(0x0202)
        /// <summary>
        /// 开门
        /// </summary>
        KaiMen = 0x02021001,
        /// <summary>
        /// 关门
        /// </summary>
        GuanMen = 0x02021002,
        /// <summary>
        /// 上锁
        /// </summary>
        ShangShuo = 0x02021003,
        /// <summary>
        /// 开锁
        /// </summary>
        KaiShuo = 0x02021004,
        /// <summary>
        /// 开报警
        /// </summary>
        KaiBaoJing = 0x02021005,
        /// <summary>
        /// 关报警
        /// </summary>
        GuanBaoJing = 0x02021006,
        #endregion

        #region 窗控(0x0203)
        /// <summary>
        /// 开窗
        /// </summary>
        KaiChuang = 0x02031001,
        /// <summary>
        /// 关窗
        /// </summary>
        GuanChaugn = 0x02031002,
        /// <summary>
        /// 开风幕
        /// </summary>
        KaiFengMu = 0x02031003,
        /// <summary>
        /// 关风幕
        /// </summary>
        GuanFengMu = 0x02031004,
        /// <summary>
        /// 开窗灯
        /// </summary>
        KaiChuangDeng = 0x02031005,
        /// <summary>
        /// 关窗灯
        /// </summary>
        GuanChuangDeng = 0x02031006,
        #endregion

        #region 新风(0x0204)
        /// <summary>
        /// 开新风
        /// </summary>
        KaiXinFeng = 0x02041001,
        /// <summary>
        /// 关新风
        /// </summary>
        GuanXinFeng = 0x02041002,
        /// <summary>
        /// 调节风量
        /// </summary>
        TiaoJieFL = 0x02041003,
        #endregion

        #region 灯与空调(0x0205)
        /// <summary>
        /// 开灯
        /// </summary>
        KaiDeng = 0x02051001,
        /// <summary>
        /// 关灯
        /// </summary>
        GuanDeng = 0x02051002,
        /// <summary>
        /// 设置亮度
        /// </summary>
        SheZhiLD = 0x02051003,
        /// <summary>
        /// 开空调
        /// </summary>
        KaiKongTiao = 0x02051004,
        /// <summary>
        /// 关空调
        /// </summary>
        GuanKongTiao = 0x02051005,
        /// <summary>
        /// 制冷
        /// </summary>
        ZhiLeng = 0x02051006,
        /// <summary>
        /// 除湿
        /// </summary>
        ChuShi = 0x02051007,
        /// <summary>
        /// 制热
        /// </summary>
        ZhiLe = 0x02051008,
        /// <summary>
        /// 送风
        /// </summary>
        SongFeng = 0x02051009,
        /// <summary>
        /// 自动
        /// </summary>
        ZhiDong = 0x0205100e,
        /// <summary>
        /// 低风
        /// </summary>
        DiFeng = 0x0205100a,
        /// <summary>
        /// 中风
        /// </summary>
        ZhongFeng = 0x0205100b,
        /// <summary>
        /// 高风
        /// </summary>
        GaoFeng = 0x0205100c,
        /// <summary>
        /// 设置温度
        /// </summary>
        SheZhiWD = 0x0205100d,
        #endregion

        #region 采暖控制(0x020C)
        /// <summary>
        /// 开地暖
        /// </summary>
        KaiDiNuan = 0x020C1001,
        /// <summary>
        /// 关地暖
        /// </summary>
        GuanDiNuan = 0x020C1002,
        /// <summary>
        /// 开右暖脚
        /// </summary>
        KaiYouNJ = 0x020C1003,
        /// <summary>
        /// 关右暖脚
        /// </summary>
        GuanYouNJ = 0x020C1004,
        /// <summary>
        /// 开左暖脚
        /// </summary>
        KaiZuoNJ = 0x020C1005,
        /// <summary>
        /// 关左暖脚
        /// </summary>
        GuanZuoNJ = 0x020C1006,
        /// <summary>
        /// 前窗帘上升
        /// </summary>
        QianChuanLSS = 0x020C1007,
        /// <summary>
        /// 前窗帘下降
        /// </summary>
        QianChuanLXJ = 0x020C1008,
        /// <summary>
        /// 右窗帘上升
        /// </summary>
        YouChuanLSS = 0x020C1009,
        /// <summary>
        /// 右窗帘下降
        /// </summary>
        YouChuanLXJ = 0x020C100a,
        /// <summary>
        /// 调节室温
        /// </summary>
        TiaoJieSW = 0x020C100b,
        #endregion

        #region 电子工作牌
        /// <summary>
        /// 显示指定工作牌号
        /// </summary>
        XianShiGZPH = 0x02101001,
        #endregion

        #region 其它
        /// <summary>
        /// 接收岗亭工作状态数据
        /// </summary>
        GongZuoSJ = 0x02011020,
        /// <summary>
        /// 门禁记录
        /// </summary>
        MenJingJL = 0x02010021,
        /// <summary>
        /// 切换电子工作牌
        /// </summary>
        DianZhiGHP = 0x02010022,
        /// <summary>
        /// 更新图片数据
        /// </summary>
        TuPianGX = 0x02011002,
        /// <summary>
        /// 工号更新
        /// </summary>
        GongHaoGX = 0x02011003,
        /// <summary>
        /// App更新
        /// </summary>
        AppGenXing = 0x02011005
        #endregion



    }
}
