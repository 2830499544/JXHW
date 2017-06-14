using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JXHighWay.WatchHouse.Net;
using System.Net;

namespace JXHighWay.WatchHouse.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SocketServer vSocketServer;
        private void button_OK_Click(object sender, EventArgs e)
        {
            //WatchHouseDataPack vWatchHouse = new WatchHouseDataPack();
            //byte[] vDtaPack = vWatchHouse.Send_KaiMen();
            //vSocketServer = new SocketServer(1024, 10);
            //vSocketServer.Start();

            SocketManager vSocketManager = new SocketManager(10,10);
            vSocketManager.ReceiveClientData += VSocketManager_ReceiveClientData;
            vSocketManager.Init();
            vSocketManager.Start(new IPEndPoint(IPAddress.Any, 1024));
            

            //vSocketManager.ReceiveClientData += VSocketManager_ReceiveClientData;

            //WatchHouseDataPack_Send_CommandEnmu aa = Net.WatchHouseDataPack_Send_CommandEnmu.GuanBaoJing;
            //WatchHouseDataPack_SendData_Main vMain = new WatchHouseDataPack_SendData_Main()
            //{
            //    ID_H = (byte)((int)aa >> 24),
            //    ID_L = (byte)((int)aa >> 16),
            //    CMD = (byte)((int)aa >> 8),
            //    SUB = (byte)(int)aa
            //};
        }

        private void VSocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        {
            throw new NotImplementedException();
        }

        //private void VSocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        //{
        //    //throw new NotImplementedException();
        //    Console.Write(string.Format("接收数据 ：{}", token.IPAddress), Convert.ToString(buff));

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            vSocketServer.Send(vSocketServer.SAEADict.First().Value, new byte[] { 0x00,0x00});
        }
    }
}
