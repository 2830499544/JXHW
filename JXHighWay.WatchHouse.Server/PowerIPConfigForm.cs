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

namespace JXHighWay.WatchHouse.Server
{
    public partial class PowerIPConfigForm : Form
    {
        public PowerIPConfigForm()
        {
            InitializeComponent();
        }

        public string DianYuanID { get; set; }
        public string MAC { get; set; }

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

        private async void button_Config_Click(object sender, EventArgs e)
        {
            PowerControl vPowerControl = new PowerControl();
            PowerIPConfigInfo vPowerIPConfigInfo = new PowerIPConfigInfo()
            {
                Gateway = maskedTextBox_GateWay.Text,
                IPAddress = maskedTextBox_IPAddress.Text,
                IsDHCP = checkBox_DHCP.Checked,
                MAC = MAC,
                ServerPort = Convert.ToInt16(numericUpDown_ServerPort.Value),
                ServerIPAddress = maskedTextBox_ServerIP.Text,
                SubMask = maskedTextBox_SubMask.Text,
            };
            bool vResult = await vPowerControl.SendCMD_SetIP(DianYuanID, vPowerIPConfigInfo);
            if (vResult)
                MessageBox.Show("配置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("配置失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void button_Get_Click(object sender, EventArgs e)
        {
            PowerControl vPowerControl = new PowerControl();
            PowerIPConfigInfo vPowerIPConfigInfo =  await vPowerControl.SendCMD_GetIP(DianYuanID);
            maskedTextBox_GateWay.Text = vPowerIPConfigInfo.Gateway;
            maskedTextBox_IPAddress.Text = vPowerIPConfigInfo.IPAddress;
            checkBox_DHCP.Checked = vPowerIPConfigInfo.IsDHCP;
            numericUpDown_ServerPort.Value = vPowerIPConfigInfo.ServerPort;
            maskedTextBox_ServerIP.Text = vPowerIPConfigInfo.ServerIPAddress;
            maskedTextBox_SubMask.Text = vPowerIPConfigInfo.SubMask;
        }
    }
}
