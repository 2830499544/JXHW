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
using JXHighWay.WatchHouse.Bll.Server;
using System.Net;
using System.Runtime.InteropServices;

namespace JXHighWay.WatchHouse.Server
{
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SocketServer vSocketServer;
        SocketManager vSocketManager;
        private void button_OK_Click(object sender, EventArgs e)
        {
            //WatchHouseDataPack vWatchHouse = new WatchHouseDataPack();
            //byte[] vDtaPack = vWatchHouse.Send_KaiMen();
            //vSocketServer = new SocketServer(1024, 10);
            //vSocketServer.Start();

            //vSocketManager = new SocketManager(10,1024);
            //vSocketManager.ReceiveClientData += VSocketManager_ReceiveClientData;
            //vSocketManager.Init();
            //vSocketManager.Start(new IPEndPoint(IPAddress.Any, 10008));

            //vSocketManager.ReceiveClientData += VSocketManager_ReceiveClientData;

            //WatchHouseDataPack_Send_CommandEnmu aa = Net.WatchHouseDataPack_Send_CommandEnmu.GuanBaoJing;
            //WatchHouseDataPack_SendData_Main vMain = new WatchHouseDataPack_SendData_Main()
            //{
            //    ID_H = (byte)((int)aa >> 24),
            //    ID_L = (byte)((int)aa >> 16),
            //    CMD = (byte)((int)aa >> 8),
            //    SUB = (byte)(int)aa
            //};

            //byte a = 1;
            //int size = Marshal.SizeOf(a);
            //aa vDataPack = new aa();
            WatchHouseDataPack_Receive_Main vDataPack = new WatchHouseDataPack_Receive_Main();
            int size = Marshal.SizeOf(vDataPack);
            try
            {
                vWatchHouseControl.Start();
                button_Start.Enabled = false;
                button_Stop.Enabled = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine( string.Format("错误信息:{0}", ex.Message) );
            }
            
        }
        WatchHouseControl vWatchHouseControl;

        private void VSocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        {
            Console.WriteLine(string.Format("接收数据:IP->{0} 数据->{1}", token.IPAddress, System.Text.Encoding.Default.GetString(buff)));
            vSocketManager.SendMessage(token, System.Text.Encoding.Default.GetBytes("ISOK"));
        }

        //private void VSocketManager_ReceiveClientData(AsyncUserToken token, byte[] buff)
        //{
        //    //throw new NotImplementedException();
        //    Console.Write(string.Format("接收数据 ：{}", token.IPAddress), Convert.ToString(buff));

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //vSocketServer.Send(vSocketServer.SAEADict.First().Value, new byte[] { 0x00,0x00});
            vWatchHouseControl.Stop();
            button_Start.Enabled = false;
            button_Stop.Enabled = true;
        }

        private void ToolStripMenuItem_Setup_Employee_Click(object sender, EventArgs e)
        {
            EmployeeForm vEmployeeForm = new EmployeeForm();
            vEmployeeForm.ShowDialog();
        }

        private void button_Command_Click(object sender, EventArgs e)
        {

            Task<bool> vResult  = vWatchHouseControl.AsyncSendCommandToDB(20010101, WatchHouseDataPack_Send_CommandEnmu.ChuShi);
            if (vResult.Result)
                MessageBox.Show("命令发送成功");
            else
                MessageBox.Show("命令发送失败");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vWatchHouseControl = new WatchHouseControl();
        }

        private void ToolStripMenuItem_Setup_Administrator_Click(object sender, EventArgs e)
        {
            ManagerForm vManagerForm = new ManagerForm();
            vManagerForm.ShowDialog();
        }

        private void ToolStripMenuItem_Setup_WatchHouse_Click(object sender, EventArgs e)
        {
            WatchHouseConfigForm vWatchHouseConfigForm = new WatchHouseConfigForm();
            vWatchHouseConfigForm.ShowDialog();
        }

        PowerControl vPowerControl;
        private void button1_Click_1(object sender, EventArgs e)
        {
            vPowerControl = new PowerControl();
            vPowerControl.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vPowerControl.Send();
        }
    }
}
