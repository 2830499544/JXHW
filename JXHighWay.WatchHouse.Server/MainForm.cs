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

        private void button_OK_Click(object sender, EventArgs e)
        {
            try
            {
                m_WatchHouseControl.Start();
                m_PowerControl.Start();
                m_LEDControl.Start();

                button_Start.Enabled = false;
                button_Stop.Enabled = true;


            }
            catch(Exception ex)
            {
                Console.WriteLine( string.Format("错误信息:{0}", ex.Message) );
            }
            
        }
        WatchHouseControl m_WatchHouseControl;
        PowerControl m_PowerControl;
        LEDControl m_LEDControl;

        private void button1_Click(object sender, EventArgs e)
        {
            //vSocketServer.Send(vSocketServer.SAEADict.First().Value, new byte[] { 0x00,0x00});
            m_WatchHouseControl.Stop();
            m_PowerControl.Stop();
            m_LEDControl.Stop();
            button_Start.Enabled = true;
            button_Stop.Enabled = false;
        }

        private void ToolStripMenuItem_Setup_Employee_Click(object sender, EventArgs e)
        {
            EmployeeForm vEmployeeForm = new EmployeeForm();
            vEmployeeForm.ShowDialog();
        }

        private void button_Command_Click(object sender, EventArgs e)
        {

            Task<bool> vResult  = m_WatchHouseControl.AsyncSendCommandToDB(20010101, WatchHouseDataPack_Send_CommandEnmu.ChuShi);
            if (vResult.Result)
                MessageBox.Show("命令发送成功");
            else
                MessageBox.Show("命令发送失败");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_WatchHouseControl = new WatchHouseControl();
            m_PowerControl = new PowerControl();
            m_LEDControl = new LEDControl();
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

        //PowerControl vPowerControl;
        private void button1_Click_1(object sender, EventArgs e)
        {
            m_WatchHouseControl.AsyncUpdateGongHao(3611453);
            //string vZhuanTaiStr = Convert.ToString(0x02, 2);

            //byte[] aa = new byte[] { 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x31, 0x39, 0x32, 0x2E, 0x31, 0x36, 0x38, 0x2E, 0x30, 0x2E, 0x32, 0x3A, 0x39, 0x39, 0x2F, 0x41, 0x70, 0x70, 0x2F, 0x53, 0x58, 0x2E, 0x61, 0x70, 0x6B };
            //string ss = System.Text.Encoding.Default.GetString(aa);
            
            //vPowerControl = new PowerControl();
            //vPowerControl.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //vPowerControl.Send();
        }

        private void ToolStripMenuItem_Setup_Basic_Click(object sender, EventArgs e)
        {
            ConfigForm vConfigForm = new ConfigForm();
            vConfigForm.ShowDialog();
        }

        private async void ToolStripMenuItem_Synch_Pic_Click(object sender, EventArgs e)
        {
            Config vConfig = new Config();
            WatchHouseControl vWatchHouseControl = new WatchHouseControl();
            string vUrl = string.Format("http://{0}/Photo", vConfig.PicUrl);
            var vResult =await vWatchHouseControl.AsyncUpdateWatchHouseAllPic(vUrl);
            string vInfo = "";
            foreach ( var vTempResult in vResult)
            {
                vInfo += string.Format("岗亭名称:{0}  状态:{1}\r",vTempResult.Key,vTempResult.Value ? "成功" : "失败");
            }
            MessageBox.Show(vInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void ToolStripMenuItem_Synch_Employee_Click(object sender, EventArgs e)
        {
            Config vConfig = new Config();
            WatchHouseControl vWatchHouseControl = new WatchHouseControl();
            string vUrl = string.Format("http://{0}/EmployeeInfo", vConfig.EmployeeUrl);
            var vResult = await vWatchHouseControl.AsyncUpdateWatchHouseEmployeeInfo(vUrl);
            string vInfo = "";
            foreach (var vTempResult in vResult)
            {
                vInfo += string.Format("岗亭名称:{0}  状态:{1}\r", vTempResult.Key, vTempResult.Value?"成功":"失败");
            }
            MessageBox.Show(vInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToolStripMenuItem_App_Click(object sender, EventArgs e)
        {
            AppUpdateForm vAppUpdateForm = new AppUpdateForm();
            vAppUpdateForm.ShowDialog();
        }
    }
}
