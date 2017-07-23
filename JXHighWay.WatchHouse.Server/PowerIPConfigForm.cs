using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JXHighWay.WatchHouse.Bll.Server;
using System.Text.RegularExpressions;
using JXHighWay.WatchHouse.Helper;

namespace JXHighWay.WatchHouse.Server
{
    public partial class PowerIPConfigForm : Form
    {
        public PowerIPConfigForm()
        {
            InitializeComponent();
        }

        public string DianYuanID { get; set; }
        //public string MAC { get; set; }

        PowerControl m_PowerControl = null;

        private void maskedTextBox_IPAddress_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox vMaskedTextBox = (MaskedTextBox)sender;
            if (e.KeyCode == Keys.Decimal)
            {
                int pos = vMaskedTextBox.SelectionStart;
                int max = (vMaskedTextBox.MaskedTextProvider.Length - vMaskedTextBox.MaskedTextProvider.EditPositionCount);
                int nextField = 0;

                for (int i = 0; i < vMaskedTextBox.MaskedTextProvider.Length; i++)
                {
                    if (!vMaskedTextBox.MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                        nextField = i;
                }
                nextField += 1;

                vMaskedTextBox.SelectionStart = nextField;
            }
        }

        bool verifyIPAddress()
        {
            bool vResult = false;
            if (CommHelper.IsIPAddress(textBox_IPAddress.Text))
                vResult = true;
            else
                MessageBox.Show("IP地址输入错误", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (CommHelper.IsIPAddress(textBox_SubMask.Text))
                vResult = true;
            else
                MessageBox.Show("子网掩码输入错误", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (CommHelper.IsIPAddress(textBox_GateWay.Text))
                vResult = true;
            else
                MessageBox.Show("网关输入错误", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (CommHelper.IsIPAddress(textBox_ServerIP.Text))
                vResult = true;
            else
                MessageBox.Show("服务器IP地址输入错误", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return vResult;
        }

        private async void button_Config_Click(object sender, EventArgs e)
        {
            if (verifyIPAddress())
            {
                m_PowerControl = new PowerControl();
                PowerIPConfigInfo vPowerIPConfigInfo = new PowerIPConfigInfo()
                {
                    Gateway = textBox_GateWay.Text,
                    IPAddress = textBox_IPAddress .Text,
                    IsDHCP = checkBox_DHCP.Checked,
                    MAC = DianYuanID,
                    ServerPort = Convert.ToInt16(numericUpDown_ServerPort.Value),
                    ServerIPAddress = textBox_ServerIP.Text,
                    SubMask = textBox_SubMask.Text,
                };
                bool vResult = await m_PowerControl.SendCMD_SetIP(DianYuanID, vPowerIPConfigInfo);
                if (vResult)
                    MessageBox.Show("配置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("配置失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button_Get_Click(object sender, EventArgs e)
        {
            m_PowerControl = new PowerControl();
            PowerIPConfigInfo vPowerIPConfigInfo =  await m_PowerControl.SendCMD_GetIP(DianYuanID);
            textBox_GateWay.Text = vPowerIPConfigInfo.Gateway;
            textBox_IPAddress.Text = vPowerIPConfigInfo.IPAddress;
            checkBox_DHCP.Checked = vPowerIPConfigInfo.IsDHCP;
            numericUpDown_ServerPort.Value = vPowerIPConfigInfo.ServerPort;
            textBox_ServerIP.Text = vPowerIPConfigInfo.ServerIPAddress;
            textBox_SubMask.Text = vPowerIPConfigInfo.SubMask;
        }

        
        private void PowerIPConfigForm_Load(object sender, EventArgs e)
        {
            m_PowerControl = new PowerControl();
            PowerIPConfigInfo vPowerIPConfigInfo = m_PowerControl.GetIPConfig(DianYuanID);
            textBox_GateWay.Text = vPowerIPConfigInfo.Gateway;
            textBox_IPAddress.Text = vPowerIPConfigInfo.IPAddress;
            checkBox_DHCP.Checked = vPowerIPConfigInfo.IsDHCP;
            numericUpDown_ServerPort.Value = vPowerIPConfigInfo.ServerPort;
            textBox_ServerIP.Text = vPowerIPConfigInfo.ServerIPAddress;
            textBox_SubMask.Text = vPowerIPConfigInfo.SubMask;
        }
    }
}
