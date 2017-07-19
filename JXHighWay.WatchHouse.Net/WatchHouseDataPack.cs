using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using JXHighWay.WatchHouse.Helper;

namespace JXHighWay.WatchHouse.Net
{
    /// <summary>
    /// 智慧岗亭数据采集
    /// </summary>
    public class WatchHouseDataPack
    {
        /// <summary>
        /// 帧头
        /// </summary>
        const byte DataPack_Head = 0x20;
        /// <summary>
        /// 协议版本号
        /// </summary>
        const short DataPack_Ver = 0x0001;
        /// <summary>
        /// 目标岗亭唯一ID
        /// </summary>
        public int DataPack_WatchHouseID { get; set; }
        /// <summary>
        /// 用户唯一ID
        /// </summary>
        public int DataPack_UserID { get; set; }

        public WatchHouseDataPack()
        {

        }

        /// <summary>
        /// 计算校验值
        /// </summary>
        /// <returns></returns>
        short calcCheck(byte[] dataPack)
        {
            short vCheck = 0x0000;
            foreach( byte vTempDataPack in dataPack)
            {
                vCheck += vTempDataPack;
            }
            return vCheck;
        }


        #region 发送
        /// <summary>
        /// 开门
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiMen()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiMen;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关门
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanMen()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanMen;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 上锁
        /// </summary>
        /// <returns></returns>
        public byte[] Send_ShangShuo()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.ShangShuo;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开锁
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiShuo()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiShuo;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开报警
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiBaoJing()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiBaoJing;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关报警
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanBaoJing()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanBaoJing;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        public byte[] Send_KaiChuang()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiChuang_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关窗
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanChaugn()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanChaugn_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开风幕
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiFengMu()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiFengMu_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关风幕
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanFengMu()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanFengMu_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开窗灯
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiChuangDeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiChuangDeng_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关窗灯
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanChuangDeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanChuangDeng_Qian;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开新风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiXinFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiXinFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关新风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanXinFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanXinFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 调节风量
        /// </summary>
        /// <param name="FengLian"></param>
        /// <returns></returns>
        public byte[] Send_TiaoJieFL(byte FengLian)
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand,
                Data = FengLian
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开灯
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiDeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiDeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关灯
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanDeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanDeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 设置亮度
        /// </summary>
        /// <param name="LiangDu"></param>
        /// <returns></returns>
        public byte[] Send_SheZhiLD(byte LiangDu)
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.SheZhiLD;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand,
                Data = LiangDu
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开空调
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiKongTiao()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiKongTiao;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关空调
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanKongTiao()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanKongTiao;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 制冷
        /// </summary>
        /// <returns></returns>
        public byte[] Send_ZhiLeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.ZhiLeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 除湿
        /// </summary>
        /// <returns></returns>
        public byte[] Send_ChuShi()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.ChuShi;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 制热
        /// </summary>
        /// <returns></returns>
        public byte[] Send_ZhiLe()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.ZhiLe;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 送风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_SongFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.SongFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 低风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_DiFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.DiFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 中风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_ZhongFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.ZhongFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 高风
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GaoFeng()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GaoFeng;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 设置温度
        /// </summary>
        /// <param name="WeiDu">温度值</param>
        /// <returns></returns>
        public byte[] Send_SheZhiWD(byte WenDu)
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.SheZhiWD;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand,
                Data = WenDu
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开地暖
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiDiNuan()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiDiNuan;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关地暖
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanDiNuan()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanDiNuan;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开右暖脚
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiYouNJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiYouNJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关右暖脚
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanYouNJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanYouNJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 开左暖脚
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiZuoNJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.KaiZuoNJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 关左暖脚
        /// </summary>
        /// <returns></returns>
        public byte[] Send_GuanZuoNJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.GuanZuoNJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 前窗帘上升
        /// </summary>
        /// <returns></returns>
        public byte[] Send_QianChuanLSS()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.QianChuanLSS;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 前窗帘下降
        /// </summary>
        /// <returns></returns>
        public byte[] Send_QianChuanLXJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.QianChuanLXJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 右窗帘上升
        /// </summary>
        /// <returns></returns>
        public byte[] Send_YouChuanLSS()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.YouChuanLSS;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 右窗帘下降
        /// </summary>
        /// <returns></returns>
        public byte[] Send_YouChuanLXJ()
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.YouChuanLXJ;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 调节室温
        /// </summary>
        /// <param name="WenDu"></param>
        /// <returns></returns>
        public byte[] Send_TiaoJieSW(byte WenDu)
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand,
                Data = WenDu
            };
            return NetHelper.StructureToByte(vSendData);
        }

        /// <summary>
        /// 显示指定工作牌号
        /// </summary>
        /// <param name="PaiHao">工作牌号</param>
        /// <returns></returns>
        public byte[] Send_XianShiGZPH(byte[] PaiHao)
        {
            WatchHouseDataPack_Send_CommandEnmu vCommand = WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vCommand >> 24),
                ID_L = (byte)((int)vCommand >> 16),
                CMD = (byte)((int)vCommand >> 8),
                SUB = (byte)(int)vCommand,
                Data = PaiHao.Length >= 1 ? PaiHao[0] : (byte)0x00,
                Kong1 = PaiHao.Length >= 2 ? PaiHao[1] : (byte)0x00,
                Kong2 = PaiHao.Length >= 3 ? PaiHao[2] : (byte)0x00,
            };
            return NetHelper.StructureToByte(vSendData);
        }

        #endregion

        #region 接收数据
        /// <summary>
        /// 接收岗亭数据(主)
        /// </summary>
        /// <param name="dataPack">数据包</param>
        /// <returns></returns>
        public WatchHouseDataPack_Receive_Main Receive_Main(byte[] dataPack )
        {
            WatchHouseDataPack_Receive_Main vResult = new WatchHouseDataPack_Receive_Main();
            short vCheck = calcCheck(dataPack);
            if ( dataPack[dataPack.Length-1]== (byte)vCheck>>8 && dataPack[dataPack.Length - 2] == (byte)vCheck >> 0)
            {
                vResult = NetHelper.ByteToStructure<WatchHouseDataPack_Receive_Main>(dataPack);
            }
            return vResult;
        }

        /// <summary>
        /// 接收岗亭数据(门禁)
        /// </summary>
        /// <param name="dataPack">数据包</param>
        /// <returns></returns>
        public WatchHouseDataPack_Receive_DoorGuard Receive_DoorGuard(byte[] dataPack)
        {
            WatchHouseDataPack_Receive_DoorGuard vResult = new WatchHouseDataPack_Receive_DoorGuard();
            short vCheck = calcCheck(dataPack);
            if (dataPack[dataPack.Length - 1] == (byte)vCheck >> 8 && dataPack[dataPack.Length - 2] == (byte)vCheck >> 0)
            {
                vResult = NetHelper.ByteToStructure<WatchHouseDataPack_Receive_DoorGuard>(dataPack);
            }
            return vResult;
        }

        /// <summary>
        /// 接收岗亭数据(电子工牌)
        /// </summary>
        /// <param name="dataPack">数据包</param>
        /// <returns></returns>
        public WatchHouseDataPack_Receive_IDCard Receive_IDCard(byte[] dataPack)
        {
            WatchHouseDataPack_Receive_IDCard vResult = new WatchHouseDataPack_Receive_IDCard();
            short vCheck = calcCheck(dataPack);
            if (dataPack[dataPack.Length - 1] == (byte)vCheck >> 8 && dataPack[dataPack.Length - 2] == (byte)vCheck >> 0)
            {
                vResult = NetHelper.ByteToStructure<WatchHouseDataPack_Receive_IDCard>(dataPack);
            }
            return vResult;
        }
        #endregion

    }
}
