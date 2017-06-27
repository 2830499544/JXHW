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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button_ZhenJia_Click(object sender, EventArgs e)
        {
            if (textBox_ZhanHao.Text != "" && textBox_MiMa.Text != "")
            {
                string vOutInfo = "";
                if (m_Manager.Add(textBox_ZhanHao.Text, textBox_MiMa.Text, checkBox_GangTin.Checked,
                    checkBox_LED.Checked, checkBox_DianYuan.Checked, ref vOutInfo))
                {
                    MessageBox.Show("增加管理员成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView_MangerInfo.DataSource = m_Manager.GetAll();
                }
                else
                {
                    MessageBox.Show("增加管理员失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入用户名和密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Manager m_Manager = null;
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            m_Manager = new Manager();
            dataGridView_MangerInfo.AutoGenerateColumns = false;
            dataGridView_MangerInfo.DataSource = m_Manager.GetAll();
        }

        private void button_ShangChu_Click(object sender, EventArgs e)
        {
            if ( dataGridView_MangerInfo.SelectedRows.Count>0 )
            {
                int vID = (int)dataGridView_MangerInfo.SelectedRows[0].Cells["Column_ID"].Value;
                if ( m_Manager.Del(vID) )
                    MessageBox.Show("管理员删除成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("管理员删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("请选择一个管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_XiuGai_Click(object sender, EventArgs e)
        {
            if (dataGridView_MangerInfo.SelectedRows.Count > 0)
            {
                if (textBox_ZhanHao.Text != "" && textBox_MiMa.Text != "")
                {
                    int vID = (int)dataGridView_MangerInfo.SelectedRows[0].Cells["Column_ID"].Value;
                    string vOutInfo = "";
                    if (m_Manager.Update(vID,textBox_ZhanHao.Text, textBox_MiMa.Text, checkBox_GangTin.Checked,
                        checkBox_LED.Checked, checkBox_DianYuan.Checked, ref vOutInfo))
                    {
                        MessageBox.Show("更新管理员成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView_MangerInfo.DataSource = m_Manager.GetAll();
                    }
                    else
                    {
                        MessageBox.Show("更新管理员失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("请输入用户名和密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选择一个管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
