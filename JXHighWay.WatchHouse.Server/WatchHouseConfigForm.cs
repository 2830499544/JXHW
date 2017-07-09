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
    public partial class WatchHouseConfigForm : Form
    {
        public WatchHouseConfigForm()
        {
            InitializeComponent();
        }

        
        private void button_Add_Click(object sender, EventArgs e)
        {
            int vGanTingID = 0;
            int vDianYuanID = 0;
            string vOutInfo = "";
            if (  int.TryParse( textBox_GanTing_ID.Text,out vGanTingID)
                && int.TryParse(textBox_DY_ID.Text,out vDianYuanID)  )
            {
                DataTable vSwitchTable = button_DY_KaiGuan.Tag == null ? null : (DataTable)button_DY_KaiGuan.Tag;
                if (m_WatchHouseConfig.Add(vGanTingID, textBox_GanTing_MC.Text,
                    comboBox_GanTing_LX.Text, textBox_LED_IP.Text, vDianYuanID, vSwitchTable, ref vOutInfo))
                {
                    MessageBox.Show("增加岗亭数据成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView_List.DataSource = m_WatchHouseConfig.GetAll();
                }
                else
                    MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("岗亭编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        WatchHouseConfig m_WatchHouseConfig;
        private void WatchHouseConfigForm_Load(object sender, EventArgs e)
        {
            m_WatchHouseConfig = new WatchHouseConfig();
            DataTable vTable = m_WatchHouseConfig.GetAll();
            dataGridView_List.AutoGenerateColumns = false;
            dataGridView_List.DataSource = vTable;
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if ( dataGridView_List.SelectedRows.Count>0)
            {
                int vID = (int)dataGridView_List.SelectedRows[0].Cells["Column_ID"].Value;
                if (m_WatchHouseConfig.Del(vID))
                {
                    MessageBox.Show("岗亭删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((DataTable)dataGridView_List.DataSource).Rows.Find(vID).Delete();
                    ((DataTable)dataGridView_List.DataSource).AcceptChanges();
                }
                else
                    MessageBox.Show("岗亭删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("请选择需要删除的岗亭", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            int vGanTingID = 0;
            int vDianYuanID = 0;
            string vOutInfo = "";
            if (int.TryParse(textBox_GanTing_ID.Text, out vGanTingID)
                && int.TryParse(textBox_DY_ID.Text, out vDianYuanID))
            {
                DataTable vSwitchTable = button_DY_KaiGuan.Tag == null ? null : (DataTable)button_DY_KaiGuan.Tag;
                int vID = (int)dataGridView_List.SelectedRows[0].Cells["Column_ID"].Value;
                if (m_WatchHouseConfig.Update(vID, vGanTingID, textBox_GanTing_MC.Text,
                    comboBox_GanTing_LX.Text, textBox_LED_IP.Text, vDianYuanID, vSwitchTable, ref vOutInfo))
                {
                    MessageBox.Show("增加岗亭数据成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView_List.DataSource = m_WatchHouseConfig.GetAll();
                }
                else
                    MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("岗亭编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_List_SelectionChanged(object sender, EventArgs e)
        {
            if ( dataGridView_List.SelectedRows.Count>0)
            {
                button_DY_KaiGuan.Tag = null;
                textBox_GanTing_ID.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_ID"].Value.ToString(); ;
                textBox_GanTing_MC.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_MC"].Value.ToString();
                comboBox_GanTing_LX.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_LX"].Value.ToString();
                textBox_GanTing_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_IP"].Value.ToString();

                textBox_LED_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_LED_IP"].Value.ToString(); ;
                
                textBox_DY_ID.Text = dataGridView_List.SelectedRows[0].Cells["Column_DianYuan_ID"].Value.ToString();
                textBox_DY_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_DianYuan_IP"].Value.ToString();
            }
        }

        private void button_DY_KaiGuan_Click(object sender, EventArgs e)
        {
            int vDianYuanID = textBox_DY_ID.Text == "" ? 0 : int.Parse(textBox_DY_ID.Text);
            DataTable vSwitchTable = new DataTable();
            if (button_DY_KaiGuan.Tag == null)
                vSwitchTable = m_WatchHouseConfig.GetSwitchTable(vDianYuanID);
            else
                vSwitchTable = (DataTable)textBox_DY_ID.Tag;
            SwitchConfigForm vSwitchConfigForm = new SwitchConfigForm();
            vSwitchConfigForm.SwitchTable = vSwitchTable;
            vSwitchConfigForm.DianYuanID = vDianYuanID;
            vSwitchConfigForm.ShowDialog();
            button_DY_KaiGuan.Tag = vSwitchTable;
        }
    }
}
