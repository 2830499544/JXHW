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
                textBox_LuJing.Text =  vOpenFileDialog.FileName
            }
        }

        private void button_GenXing_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists( textBox_LuJing.Text) )
            {
                MessageBox.Show("文件不存在，请重新检查路径","信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            byte vBanBen1 = (byte)( ((int)numericUpDown_BanBen1.Value )>>0 );
            byte vBanBen2 = (byte)(((int)numericUpDown_BanBen2.Value) >> 0);
            byte vBanBen3 = (byte)(((int)numericUpDown_BanBen3.Value) >> 0);
            byte vBanBen4 = (byte)(((int)numericUpDown_BanBen4.Value) >> 0);
            byte[] vBanBenArray = new byte[] { vBanBen1,vBanBen2,vBanBen3,vBanBen4 };


        }
    }
}
