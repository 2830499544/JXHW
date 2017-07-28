using JXHighWay.WatchHouse.Bll.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JXHighWay.WatchHouse.Server
{
    public partial class AppUpdateForm : Form
    {
        public AppUpdateForm()
        {
            InitializeComponent();
        }

        private void button_TuiChu_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_LiuLang_Click(object sender, EventArgs e)
        {
            OpenFileDialog vOpenFileDialog = new OpenFileDialog();
            vOpenFileDialog.Filter = "APK files (*.apk)|*.apk";
            if (  vOpenFileDialog.ShowDialog() == DialogResult.OK )
            {
                textBox_LuJing.Text = vOpenFileDialog.FileName;
            }
        }

        private async void button_GenXing_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists( textBox_LuJing.Text) )
            {
                MessageBox.Show("文件不存在，请重新检查路径","信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            byte vBanBen1 = (byte)(((int)numericUpDown_BanBen1.Value) >> 0);
            byte vBanBen2 = (byte)(((int)numericUpDown_BanBen2.Value) >> 0);
            byte vBanBen3 = (byte)(((int)numericUpDown_BanBen3.Value) >> 0);
            byte vBanBen4 = (byte)(((int)numericUpDown_BanBen4.Value) >> 0);
            byte[] vBanBenArray = new byte[] { vBanBen1,vBanBen2,vBanBen3,vBanBen4 };

            Config vConfig = new Config();
            WatchHouseControl vWatchHouseControl = new WatchHouseControl();
            var vResult = await vWatchHouseControl.AsyncUpdateWatchHouseApp(textBox_LuJing.Text, vBanBenArray,
                checkBox_QiangZhi.Checked,vConfig.AppUrl);
            string vInfo = "";
            foreach (var vTempResult in vResult)
            {
                vInfo += string.Format("岗亭名称:{0}  状态:{1}\r", vTempResult.Key, vTempResult.Value ? "成功" : "失败");
            }
            MessageBox.Show(vInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
