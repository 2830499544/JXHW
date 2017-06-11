using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace JXHighWay.WatchHouse.Net
{
    /// <summary>
    /// 智慧岗亭数据采集
    /// </summary>
    public class WatchHouse
    {
        public WatchHouse()
        {

        }

        #region 发送
        /// <summary>
        /// 开门
        /// </summary>
        /// <returns></returns>
        public byte[] Send_KaiMen()
        {
            WatchHouseDataPack_Send_CommandEnmu vKaiMenComm = WatchHouseDataPack_Send_CommandEnmu.KaiMen;
            WatchHouseDataPack_SendData_Main vSendData = new WatchHouseDataPack_SendData_Main()
            {
                ID_H = (byte)((int)vKaiMenComm >> 24),
                ID_L = (byte)((int)vKaiMenComm >> 16),
                CMD = (byte)((int)vKaiMenComm >> 8),
                SUB = (byte)(int)vKaiMenComm
            };
        }
        #endregion
    }
}
