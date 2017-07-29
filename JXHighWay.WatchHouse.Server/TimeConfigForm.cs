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
using JXHighWay.WatchHouse.Helper;

namespace JXHighWay.WatchHouse.Server
{
    public partial class TimeConfigForm : Form
    {
        public TimeConfigForm()
        {
            InitializeComponent();
        }

        public string DianYuanID { get; set; }

        private async void button_Refresh_Click(object sender, EventArgs e)
        {
            PowerControl vPowerControl = new PowerControl();
            int vTime = await vPowerControl.SendCMD_GetTime(DianYuanID);
            DateTime vDateTime =  CommHelper.TimestampToDateTime(vTime);
            label_Time.Text = vDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            if ( vTime == 0  )
                MessageBox.Show("获取时间失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("获取时间成功", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void button_Synch_Click(object sender, EventArgs e)
        {
            PowerControl vPowerControl = new PowerControl();
            int vTime = CommHelper.DateTimeToTimestamp(DateTime.Now);
            bool vResult= await vPowerControl.SendCMD_SetTime(DianYuanID, vTime);
            if (vResult)
            {
                MessageBox.Show("时间同步成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                MessageBox.Show("时间同步失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
