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
    public partial class SwitchConfigForm : Form
    {
        public WatchHouseConfigForm WatchHouseConfig { get; set; }

        public WatchHouseConfig WatchHouse { get; set; }
        public DataTable SwitchTable { get; set; }
        public string DianYuanID { get; set; }
        public SwitchConfigForm()
        {
            InitializeComponent();
        }


        private void SwitchConfigForm_Load(object sender, EventArgs e)
        {
            if ( SwitchTable != null )
            {
                DataView vDataView = SwitchTable.AsDataView();
                vDataView.Sort = "LuHao";
                dataGridView_Switch.AutoGenerateColumns = false;
                dataGridView_Switch.DataSource = vDataView;
                comboBox_LeiXing.SelectedIndex = 0;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            int vLuHao = (int)numericUpDown_LuHao.Value;
            DataRow[] vSelectRows =  SwitchTable.Select(string.Format("LuHao={0}",vLuHao));
            if (vSelectRows.Length == 0)
            {
                if (textBox_MingCheng.Text != "")
                {
                    DataRow vNewRow = SwitchTable.NewRow();
                    vNewRow["DianYuanID"] = DianYuanID;
                    vNewRow["LuHao"] = vLuHao;
                    vNewRow["MinCheng"] = textBox_MingCheng.Text;
                    vNewRow["LeiXing"] = comboBox_LeiXing.Text;
                    SwitchTable.Rows.Add(vNewRow);
                    //SwitchTable.AcceptChanges();
                }
                else
                    MessageBox.Show("请输入名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("存在相同的路号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if ( dataGridView_Switch.SelectedRows.Count>0  )
            {
                int vId = (int)dataGridView_Switch.SelectedRows[0].Cells["Column_ID"].Value;
                SwitchTable.Rows.Find(vId).Delete();
            }
            else
            {
                MessageBox.Show("请选择需要删除的开关", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if ( dataGridView_Switch.SelectedRows.Count >0)
            {
                if (textBox_MingCheng.Text != "")
                {
                    int vId = (int)dataGridView_Switch.SelectedRows[0].Cells["Column_ID"].Value;
                    DataRow vRow = SwitchTable.Rows.Find(vId);
                    int vLuHao = (int)numericUpDown_LuHao.Value;
                    vRow["LuHao"] = vLuHao;
                    vRow["MinCheng"] = textBox_MingCheng.Text;
                    vRow["LeiXing"] = comboBox_LeiXing.Text;
                    WatchHouseConfig.saveWatchHouseData();
                    //SwitchTable.AcceptChanges();
                }
                else
                    MessageBox.Show("请输入名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("没有选择的开关", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGridView_Switch_SelectionChanged(object sender, EventArgs e)
        {
            if ( dataGridView_Switch.SelectedRows.Count>0 )
            {
                int vLuHao = (int)dataGridView_Switch.SelectedRows[0].Cells["Column_LuHao"].Value;
                numericUpDown_LuHao.Value = vLuHao;

                string vMinCheng = (string)dataGridView_Switch.SelectedRows[0].Cells["Column_MinCheng"].Value;
                textBox_MingCheng.Text = vMinCheng;

                string vLeiXing = (string)dataGridView_Switch.SelectedRows[0].Cells["Column_LeiXing"].Value;
                comboBox_LeiXing.Text = vLeiXing;
            }
        }

        private async void button_Get_Click(object sender, EventArgs e)
        {
            PowerControl vPowerControl = new PowerControl();
            bool vResult = await vPowerControl.GetControlInfo(DianYuanID);
            if (vResult)
            {
                SwitchTable = WatchHouse.GetSwitchTable(DianYuanID);
                DataView vDataView = SwitchTable.AsDataView();
                vDataView.Sort = "LuHao";
                dataGridView_Switch.AutoGenerateColumns = false;
                dataGridView_Switch.DataSource = vDataView;
                MessageBox.Show("获取电源配置成功","信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("获取电源配置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
