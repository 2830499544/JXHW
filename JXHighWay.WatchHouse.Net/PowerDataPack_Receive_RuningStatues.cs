using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Receive_RunningStatus
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
        /// MAC地址
        /// </summary>
        public byte MAC1 { get; set; }
        public byte MAC2 { get; set; }
        public byte MAC3 { get; set; }
        public byte MAC4 { get; set; }
        public byte MAC5 { get; set; }
        public byte MAC6 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public byte SN { get; set; }


        /// <summary>
        /// 附加码
        /// </summary>
        public byte Addition { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public byte CMD { get; set; }

        #region 数据区域
        /// <summary>
        /// 设备类型 0漏保 1分路 2分路(带漏保) 3漏保插座 4 普插座
        /// </summary>
        public byte LeiXing { get; set; }

        /// <summary>
        /// 开关状态
        /// </summary>
        public byte SwitchState1 { get; set; }
        public byte SwitchState2 { get; set; }
        /// <summary>
        /// 路号
        /// </summary>
        public byte LuHao { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public byte DianYa1 { get; set; }
        public byte DianYa2 { get; set; }

        /// <summary>
        /// 电流
        /// </summary>
        public byte DianLiu1 { get; set; }
        public byte DianLiu2 { get; set; }

        /// <summary>
        /// 电能
        /// </summary>
        public byte DianNeng1 { get; set; }
        public byte DianNeng2 { get; set; }
        public byte DianNeng3 { get; set; }
        public byte DianNeng4 { get; set; }
        /// <summary>
        /// 有功功率
        /// </summary>
        public byte YouGongGL1 { get; set; }
        public byte YouGongGL2 { get; set; }

        /// <summary>
        /// 无功功率
        /// </summary>
        public byte WuGongGL1 { get; set; }
        public byte WuGongGL2 { get; set; }
        
        /// <summary>
        /// 温度
        /// </summary>
        public byte WenDu1 { get; set; }
        public byte WenDu2 { get; set; }

        /// <summary>
        /// 功率因素
        /// </summary>
        public byte GongLuYS1 { get; set; }
        public byte GongLuYS2 { get; set; }

        /// <summary>
        /// 漏电流
        /// </summary>
        public byte LouDianLiu1 { get; set; }
        public byte LouDianLiu2 { get; set; }

        /// <summary>
        /// 频率
        /// </summary>
        public byte PinLu1 { get; set; }
        public byte PinLu2 { get; set; }
        #endregion

        /// <summary>
        /// 检验和
        /// </summary>
        public byte Check { get; set; }
        /// <summary>
        /// 尾
        /// </summary>
        public byte Tail { get; set; }

    }
}
