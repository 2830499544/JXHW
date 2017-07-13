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
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            Config vConfig = new Config();
            textBox_DB_Address.Text = vConfig.DBSource;
            textBox_DB_Name.Text = vConfig.DBName;
            textBox_DB_Password.Text = vConfig.DBPassword;
            numericUpDown_DB_Port.Value = vConfig.DBPort;
            textBox_DB_UserName.Text = vConfig.DBUserName;

            numericUpDown_Power_Port.Value = vConfig.PowerPort;
            numericUpDown_WM_Port.Value = vConfig.WatchHousePort;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Config vConfig = new Config();
            vConfig.DBSource = textBox_DB_Address.Text;
            vConfig.DBName = textBox_DB_Name.Text;
            vConfig.DBPassword = textBox_DB_Password.Text;
            vConfig.DBPort = Convert.ToInt32( numericUpDown_DB_Port.Value );
            vConfig.DBUserName = textBox_DB_UserName.Text;

            vConfig.PowerPort = Convert.ToInt32( numericUpDown_Power_Port.Value ) ;
            vConfig.WatchHousePort = Convert.ToInt32( numericUpDown_WM_Port.Value ) ;
            vConfig.Save();
        }
    }
}
