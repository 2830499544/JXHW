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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            Config vConfig = new Config();
            textBox_IPAddress.Text = vConfig.DBSource;
            textBox_DB_Name.Text = vConfig.DBName;
            textBox_DB_Password.Text = vConfig.DBPassword;
            numericUpDown_DB_Port.Value = vConfig.DBPort;
            textBox_DB_UserName.Text = vConfig.DBUserName;

            numericUpDown_Power_Port.Value = vConfig.PowerPort;
            numericUpDown_WM_Port.Value = vConfig.WatchHousePort;

            textBox_Emplyee_Address.Text = vConfig.EmployeeUrl;
            textBox_Pic_Address.Text = vConfig.PicUrl;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (CommHelper.IsIPAddress(textBox_IPAddress.Text))
            {
                Config vConfig = new Config();
                vConfig.DBSource = textBox_IPAddress.Text;
                vConfig.DBName = textBox_DB_Name.Text;
                vConfig.DBPassword = textBox_DB_Password.Text;
                vConfig.DBPort = Convert.ToInt32(numericUpDown_DB_Port.Value);
                vConfig.DBUserName = textBox_DB_UserName.Text;

                vConfig.PowerPort = Convert.ToInt32(numericUpDown_Power_Port.Value);
                vConfig.WatchHousePort = Convert.ToInt32(numericUpDown_WM_Port.Value);

                vConfig.EmployeeUrl = textBox_Emplyee_Address.Text;
                vConfig.PicUrl = textBox_Pic_Address.Text;

                vConfig.Save();
                DialogResult = DialogResult.OK;
                MessageBox.Show("保存成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("请输入正确的IP地址", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
