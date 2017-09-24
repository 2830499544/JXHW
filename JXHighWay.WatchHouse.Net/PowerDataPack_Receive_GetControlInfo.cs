using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Net.DataPack
{
    public struct PowerDataPack_Receive_GetControlInfo
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
        /// 漏保设备路数
        /// </summary>
        public byte LouBaoSBLS { get; set; }
        /// <summary>
        /// 分路路数
        /// </summary>
        public byte FenLuLS { get; set; }
        /// <summary>
        /// 漏保分路路数
        /// </summary>
        public byte LouBaoFLLS { get; set; }
        /// <summary>
        ///漏保插座路数
        /// </summary>
        public byte LouBaoCZLS { get; set; }
        /// <summary>
        /// 插座路数
        /// </summary>
        public byte ChaZhuoLS { get; set; }
        /// <summary>
        /// 预留
        /// </summary>
        public byte YuLiu1 { get; set; }
        public byte YuLie2 { get; set; }
        public byte YuLie3 { get; set; }
        public byte YuLie4 { get; set; }
        public byte YuLie5 { get; set; }



        /// <summary>
        /// 漏保设备规格
        /// </summary>
        public byte LouBaoSBGG1 { get; set; }
        /// <summary>
        /// 漏保设备规格
        /// </summary>
        public byte LouBaoSBGG2 { get; set; }

        /// <summary>
        /// 分路规格1
        /// </summary>
        public byte FenLuGG1 { get; set; }
        /// <summary>
        /// 分路规格2
        /// </summary>
        public byte FenLuGG2 { get; set; }


        /// <summary>
        /// 漏保分路规格1
        /// </summary>
        public byte LouBaoFLGG1 { get; set; }
        /// <summary>
        /// 漏保分路规格2
        /// </summary>
        public byte LouBaoFLGG2 { get; set; }


        /// <summary>
        /// 漏保插座规格1
        /// </summary>
        public byte LouBaoCZGG1 { get; set;  }
        /// <summary>
        /// 漏保插座规格2
        /// </summary>
        public byte LouBaoCZGG2 { get; set; }

        /// <summary>
        /// 插座规格1
        /// </summary>
        public byte ChaZuoGG1 { get; set; }
        /// <summary>
        /// 插座规格2
        /// </summary>
        public byte ChaZuoGG2 { get; set; }

        #region 预留
        public byte YuLiu6 { get; set; }
        public byte YuLie7 { get; set; }
        public byte YuLie8 { get; set; }
        public byte YuLie9 { get; set; }
        public byte YuLie10 { get; set; }
        public byte YuLiu11 { get; set; }
        public byte YuLie12 { get; set; }
        public byte YuLie13 { get; set; }
        public byte YuLie14 { get; set; }
        public byte YuLie15 { get; set; }
        #endregion

        #region 漏保设备型号
        public byte LouBaoSBXX1 { get; set; }
        public byte LouBaoSBXX2 { get; set; }
        public byte LouBaoSBXX3 { get; set; }
        public byte LouBaoSBXX4 { get; set; }
        public byte LouBaoSBXX5 { get; set; }
        public byte LouBaoSBXX6 { get; set; }
        public byte LouBaoSBXX7 { get; set; }
        public byte LouBaoSBXX8 { get; set; }
        public byte LouBaoSBXX9 { get; set; }
        public byte LouBaoSBXX10 { get; set; }
        public byte LouBaoSBXX11 { get; set; }
        public byte LouBaoSBXX12 { get; set; }
        public byte LouBaoSBXX13 { get; set; }
        public byte LouBaoSBXX14 { get; set; }
        public byte LouBaoSBXX15 { get; set; }
        public byte LouBaoSBXX16 { get; set; }
        public byte LouBaoSBXX17 { get; set; }
        public byte LouBaoSBXX18 { get; set; }
        public byte LouBaoSBXX19 { get; set; }
        public byte LouBaoSBXX20 { get; set; }
        #endregion

        #region 分路型号
        public byte FenLluXX1 { get; set; }
        public byte FenLluXX2 { get; set; }
        public byte FenLluXX3 { get; set; }
        public byte FenLluXX4 { get; set; }
        public byte FenLluXX5 { get; set; }
        public byte FenLluXX6 { get; set; }
        public byte FenLluXX7 { get; set; }
        public byte FenLluXX8 { get; set; }
        public byte FenLluXX9 { get; set; }
        public byte FenLluXX10 { get; set; }
        public byte FenLluXX11 { get; set; }
        public byte FenLluXX12 { get; set; }
        public byte FenLluXX13 { get; set; }
        public byte FenLluXX14 { get; set; }
        public byte FenLluXX15 { get; set; }
        public byte FenLluXX16 { get; set; }
        public byte FenLluXX17 { get; set; }
        public byte FenLluXX18 { get; set; }
        public byte FenLluXX19 { get; set; }
        public byte FenLluXX20 { get; set; }
        #endregion

        #region 漏保分路型号
        public byte LouBaoFLXX1 { get; set; }
        public byte LouBaoFLXX2 { get; set; }
        public byte LouBaoFLXX3 { get; set; }
        public byte LouBaoFLXX4 { get; set; }
        public byte LouBaoFLXX5 { get; set; }
        public byte LouBaoFLXX6 { get; set; }
        public byte LouBaoFLXX7 { get; set; }
        public byte LouBaoFLXX8 { get; set; }
        public byte LouBaoFLXX9 { get; set; }
        public byte LouBaoFLXX10 { get; set; }
        public byte LouBaoFLXX11 { get; set; }
        public byte LouBaoFLXX12 { get; set; }
        public byte LouBaoFLXX13 { get; set; }
        public byte LouBaoFLXX14 { get; set; }
        public byte LouBaoFLXX15 { get; set; }
        public byte LouBaoFLXX16 { get; set; }
        public byte LouBaoFLXX17 { get; set; }
        public byte LouBaoFLXX18 { get; set; }
        public byte LouBaoFLXX19 { get; set; }
        public byte LouBaoFLXX20 { get; set; }
        #endregion

        #region 漏保插坐型号
        public byte LouBaoCZXX1 { get; set; }
        public byte LouBaoCZXX2 { get; set; }
        public byte LouBaoCZXX3 { get; set; }
        public byte LouBaoCZXX4 { get; set; }
        public byte LouBaoCZXX5 { get; set; }
        public byte LouBaoCZXX6 { get; set; }
        public byte LouBaoCZXX7 { get; set; }
        public byte LouBaoCZXX8 { get; set; }
        public byte LouBaoCZXX9 { get; set; }
        public byte LouBaoCZXX10 { get; set; }
        public byte LouBaoCZXX11 { get; set; }
        public byte LouBaoCZXX12 { get; set; }
        public byte LouBaoCZXX13 { get; set; }
        public byte LouBaoCZXX14 { get; set; }
        public byte LouBaoCZXX15 { get; set; }
        public byte LouBaoCZXX16 { get; set; }
        public byte LouBaoCZXX17 { get; set; }
        public byte LouBaoCZXX18 { get; set; }
        public byte LouBaoCZXX19 { get; set; }
        public byte LouBaoCZXX20 { get; set; }
        #endregion

        #region 插座型号
        public byte ChaZhuoXX1 { get; set; }
        public byte ChaZhuoXX2 { get; set; }
        public byte ChaZhuoXX3 { get; set; }
        public byte ChaZhuoXX4 { get; set; }
        public byte ChaZhuoXX5 { get; set; }
        public byte ChaZhuoXX6 { get; set; }
        public byte ChaZhuoXX7 { get; set; }
        public byte ChaZhuoXX8 { get; set; }
        public byte ChaZhuoXX9 { get; set; }
        public byte ChaZhuoXX10 { get; set; }
        public byte ChaZhuoXX11 { get; set; }
        public byte ChaZhuoXX12 { get; set; }
        public byte ChaZhuoXX13 { get; set; }
        public byte ChaZhuoXX14 { get; set; }
        public byte ChaZhuoXX15 { get; set; }
        public byte ChaZhuoXX16 { get; set; }
        public byte ChaZhuoXX17 { get; set; }
        public byte ChaZhuoXX18 { get; set; }
        public byte ChaZhuoXX19 { get; set; }
        public byte ChaZhuoXX20 { get; set; }

        #endregion

        #region 预留
        public byte YuLiu16 { get; set; }
        public byte YuLie17 { get; set; }
        public byte YuLie18 { get; set; }
        public byte YuLie19 { get; set; }
        public byte YuLie20 { get; set; }
        public byte YuLiu21 { get; set; }
        public byte YuLie22 { get; set; }
        public byte YuLie23 { get; set; }
        public byte YuLie24 { get; set; }
        public byte YuLie25 { get; set; }
        public byte YuLiu26 { get; set; }
        public byte YuLie27 { get; set; }
        public byte YuLie28 { get; set; }
        public byte YuLie29 { get; set; }
        public byte YuLie30 { get; set; }
        public byte YuLiu31 { get; set; }
        public byte YuLie32 { get; set; }
        public byte YuLie33 { get; set; }
        public byte YuLie34 { get; set; }
        public byte YuLie35 { get; set; }

        //
        public byte YuLiu36 { get; set; }
        public byte YuLie37 { get; set; }
        public byte YuLie38 { get; set; }
        public byte YuLie39 { get; set; }
        public byte YuLie40 { get; set; }
        public byte YuLiu41 { get; set; }
        public byte YuLie42 { get; set; }
        public byte YuLie43 { get; set; }
        public byte YuLie44 { get; set; }
        public byte YuLie45 { get; set; }
        public byte YuLiu46 { get; set; }
        public byte YuLie47 { get; set; }
        public byte YuLie48 { get; set; }
        public byte YuLie49 { get; set; }
        public byte YuLie50 { get; set; }
        public byte YuLiu51 { get; set; }
        public byte YuLie52 { get; set; }
        public byte YuLie53 { get; set; }
        public byte YuLie54 { get; set; }
        public byte YuLie55 { get; set; }

        //
        public byte YuLiu56 { get; set; }
        public byte YuLie57 { get; set; }
        public byte YuLie58 { get; set; }
        public byte YuLie59 { get; set; }
        public byte YuLie60 { get; set; }
        public byte YuLiu61 { get; set; }
        public byte YuLie62 { get; set; }
        public byte YuLie63 { get; set; }
        public byte YuLie64 { get; set; }
        public byte YuLie65 { get; set; }
        public byte YuLiu66 { get; set; }
        public byte YuLie67 { get; set; }
        public byte YuLie68 { get; set; }
        public byte YuLie69 { get; set; }
        public byte YuLie70 { get; set; }
        public byte YuLiu71 { get; set; }
        public byte YuLie72 { get; set; }
        public byte YuLie73 { get; set; }
        public byte YuLie74 { get; set; }
        public byte YuLie75 { get; set; }

        //
        public byte YuLiu76 { get; set; }
        public byte YuLie77 { get; set; }
        public byte YuLie78 { get; set; }
        public byte YuLie79 { get; set; }
        public byte YuLie80 { get; set; }
        public byte YuLiu81 { get; set; }
        public byte YuLie82 { get; set; }
        public byte YuLie83 { get; set; }
        public byte YuLie84 { get; set; }
        public byte YuLie85 { get; set; }
        public byte YuLiu86 { get; set; }
        public byte YuLie87 { get; set; }
        public byte YuLie88 { get; set; }
        public byte YuLie89 { get; set; }
        public byte YuLie90 { get; set; }
        public byte YuLiu91 { get; set; }
        public byte YuLie92 { get; set; }
        public byte YuLie93 { get; set; }
        public byte YuLie94 { get; set; }
        public byte YuLie95 { get; set; }

        //
        public byte YuLiu96 { get; set; }
        public byte YuLie97 { get; set; }
        public byte YuLie98 { get; set; }
        public byte YuLie99 { get; set; }
        public byte YuLie100 { get; set; }
        public byte YuLiu101 { get; set; }
        public byte YuLie102 { get; set; }
        public byte YuLie103 { get; set; }
        public byte YuLie104 { get; set; }
        public byte YuLie105 { get; set; }
        public byte YuLiu106 { get; set; }
        public byte YuLie107 { get; set; }
        public byte YuLie108 { get; set; }
        public byte YuLie109 { get; set; }
        public byte YuLie110 { get; set; }
        public byte YuLiu111 { get; set; }
        public byte YuLie112 { get; set; }
        public byte YuLie113 { get; set; }
        public byte YuLie114 { get; set; }
        public byte YuLie115 { get; set; }
        #endregion
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
