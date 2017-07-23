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
    public partial class WatchHouseConfigForm : Form
    {
        public WatchHouseConfigForm()
        {
            InitializeComponent();
        }


        private void button_Add_Click(object sender, EventArgs e)
        {
            int vGanTingID = 0;
            string vDianYuanID1 = "", vDianYuanID2="";
            string vOutInfo = "";
            if (!int.TryParse(textBox_GanTing_ID.Text, out vGanTingID))
            {
                MessageBox.Show("岗亭编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!int.TryParse(textBox_DY1_ID.Text, out vDianYuanID1))
            //{
            //    MessageBox.Show("电源1编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (!int.TryParse(textBox_DY2_ID.Text, out vDianYuanID2))
            //{
            //    MessageBox.Show("电源2编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            vDianYuanID1 = textBox_DY1_ID.Text;
            vDianYuanID2 = textBox_DY2_ID.Text;
            DataTable vSwitchTable1 = button_DY1_KaiGuan.Tag == null ? null : (DataTable)button_DY1_KaiGuan.Tag;
            DataTable vSwitchTable2 = button_DY2_KaiGuan.Tag == null ? null : (DataTable)button_DY2_KaiGuan.Tag;
            if (m_WatchHouseConfig.Add(vGanTingID, textBox_GanTing_MC.Text,
                comboBox_GanTing_LX.Text, textBox_LED_IP.Text, vDianYuanID1,vDianYuanID2, vSwitchTable1, vSwitchTable2, ref vOutInfo))
            {
                MessageBox.Show("增加岗亭数据成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView_List.DataSource = m_WatchHouseConfig.GetAll();
            }
            else
                MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (MessageBox.Show("是否确认删除岗亭", "信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
            {
                if (dataGridView_List.SelectedRows.Count > 0)
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
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            int vGanTingID = 0;
            string vDianYuanID1 = "", vDianYuanID2="";
            string vOutInfo = "";
            if (!int.TryParse(textBox_GanTing_ID.Text, out vGanTingID))
            {
                MessageBox.Show("岗亭编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!int.TryParse(textBox_DY1_ID.Text, out vDianYuanID1))
            //{
            //    MessageBox.Show("电源1编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (!int.TryParse(textBox_DY2_ID.Text, out vDianYuanID2))
            //{
            //    MessageBox.Show("电源2编号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            vDianYuanID1 = textBox_DY1_ID.Text;
            vDianYuanID2 = textBox_DY2_ID.Text;
            DataTable vSwitchTable1 = button_DY1_KaiGuan.Tag == null ? null : (DataTable)button_DY1_KaiGuan.Tag;
            DataTable vSwitchTable2 = button_DY2_KaiGuan.Tag == null ? null : (DataTable)button_DY2_KaiGuan.Tag;
            int vID = (int)dataGridView_List.SelectedRows[0].Cells["Column_ID"].Value;
            if (m_WatchHouseConfig.Update(vID, vGanTingID, textBox_GanTing_MC.Text,
                comboBox_GanTing_LX.Text, textBox_LED_IP.Text, vDianYuanID1, vDianYuanID2,vSwitchTable1, vSwitchTable2, ref vOutInfo))
            {
                MessageBox.Show("更新岗亭数据成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView_List.DataSource = m_WatchHouseConfig.GetAll();
            }
            else
                MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    

        private void dataGridView_List_SelectionChanged(object sender, EventArgs e)
        {
            if ( dataGridView_List.SelectedRows.Count>0)
            {
                button_DY1_KaiGuan.Tag = null;
                textBox_GanTing_ID.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_ID"].Value.ToString(); ;
                textBox_GanTing_MC.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_MC"].Value.ToString();
                comboBox_GanTing_LX.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_LX"].Value.ToString();
                textBox_GanTing_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_GanTing_IP"].Value.ToString();

                textBox_LED_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_LED_IP"].Value.ToString(); ;
                
                textBox_DY1_ID.Text = dataGridView_List.SelectedRows[0].Cells["Column_DianYuan_ID"].Value.ToString();
                textBox_DY1_IP.Text = dataGridView_List.SelectedRows[0].Cells["Column_DianYuan_IP"].Value.ToString();
            }
        }

        private void button_DY_KaiGuan_Click(object sender, EventArgs e)
        {
            string vDianYuanID = textBox_DY1_ID.Text;
            if ( CommHelper.IsMAC(vDianYuanID))
            {
                DataTable vSwitchTable = new DataTable();
                if (button_DY1_KaiGuan.Tag == null)
                    vSwitchTable = m_WatchHouseConfig.GetSwitchTable(vDianYuanID);
                else
                    vSwitchTable = (DataTable)button_DY1_KaiGuan.Tag;
                SwitchConfigForm vSwitchConfigForm = new SwitchConfigForm();
                vSwitchConfigForm.SwitchTable = vSwitchTable;
                vSwitchConfigForm.DianYuanID = vDianYuanID;
                vSwitchConfigForm.ShowDialog();
                button_DY1_KaiGuan.Tag = vSwitchTable;
            }
            else
                MessageBox.Show("请输入正确的电源ID", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_PowerIP_Click(object sender, EventArgs e)
        {
            if ( CommHelper.IsMAC( textBox_DY1_ID.Text ))
            {
                PowerIPConfigForm vPowerIPConfigForm = new PowerIPConfigForm();
                vPowerIPConfigForm.DianYuanID = textBox_DY1_ID.Text;
                vPowerIPConfigForm.ShowDialog();
            }
            else
                MessageBox.Show("请输入正确的电源ID", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox_GanTing_LX_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vSelectText = ((ComboBox)sender).Text;
            switch ( vSelectText )
            {
                case "出口":
                case "入口":
                    groupBox_Power1.Enabled = true;
                    groupBox_Power2.Enabled = false;
                    break;
                case "双向":
                    groupBox_Power1.Enabled = true;
                    groupBox_Power2.Enabled = true;
                    break;
            }
        }
        
        private void button_DY2_PowerIP_Click(object sender, EventArgs e)
        {
            if ( CommHelper.IsMAC( textBox_DY2_ID.Text ))
            {
                PowerIPConfigForm vPowerIPConfigForm = new PowerIPConfigForm();
                vPowerIPConfigForm.DianYuanID = textBox_DY2_ID.Text;
                vPowerIPConfigForm.ShowDialog();
            }
            else
                MessageBox.Show("请输入正确的电源ID", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_DY2_KaiGuan_Click(object sender, EventArgs e)
        {
            string vDianYuanID = textBox_DY2_ID.Text;
            if ( CommHelper.IsMAC( vDianYuanID))
            {
                DataTable vSwitchTable = new DataTable();
                if (button_DY2_KaiGuan.Tag == null)
                    vSwitchTable = m_WatchHouseConfig.GetSwitchTable(vDianYuanID);
                else
                    vSwitchTable = (DataTable)button_DY2_KaiGuan.Tag;
                SwitchConfigForm vSwitchConfigForm = new SwitchConfigForm();
                vSwitchConfigForm.SwitchTable = vSwitchTable;
                vSwitchConfigForm.DianYuanID = vDianYuanID;
                vSwitchConfigForm.ShowDialog();
                button_DY2_KaiGuan.Tag = vSwitchTable;
            }
            else
                MessageBox.Show("请输入正确的电源ID", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
