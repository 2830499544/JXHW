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
    public partial class EmployeeForm : Form
    {
        Employee m_Employee;
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void button_Photo_Click(object sender, EventArgs e)
        {
            OpenFileDialog vOpenFileDialog = new OpenFileDialog();
            vOpenFileDialog.Multiselect = false;
            vOpenFileDialog.Filter = "Png files (*.png)|*.png";
            if ( vOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Photo.Image = Image.FromFile( vOpenFileDialog.FileName );
                pictureBox_Photo.Tag = vOpenFileDialog.FileName;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if ( textBox_Name.Text == "")
            {
                MessageBox.Show("请输入员工姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int vJobNo = 0;
            if (!int.TryParse(textBox_JobNo.Text, out vJobNo))
            {
                MessageBox.Show("工号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string vOutInfo = "";
            string vPhotoPath = pictureBox_Photo.Tag==null?"":(string)pictureBox_Photo.Tag;
            if (m_Employee.Add(textBox_Name.Text, comboBox_Sex.Text, vJobNo, textBox_CardNo.Text,comboBox_XingJi.Text,
                textBox_GeYan.Text, vPhotoPath, ref vOutInfo))
            {
                MessageBox.Show("新增员工信息成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView_EmployeeInfo.DataSource = m_Employee.GetAllEmplyees();
            }
            else
                MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            comboBox_Sex.Text = "男";
            comboBox_XingJi.Text = "一星";
            m_Employee = new Employee();
            DataTable vEmplyeeTable = m_Employee.GetAllEmplyees();
            dataGridView_EmployeeInfo.AutoGenerateColumns = false;
            dataGridView_EmployeeInfo.DataSource = vEmplyeeTable;
            
            pictureBox_Photo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认删除", "信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && 
                dataGridView_EmployeeInfo.SelectedRows.Count>0 )
            {
                int vID = (int)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_ID"].Value;
                if (m_Employee.Del(vID))
                {
                    MessageBox.Show("删除员工成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView_EmployeeInfo.DataSource = m_Employee.GetAllEmplyees();
                }
                else
                    MessageBox.Show("删除员工失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("请选择需要删除的员工", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_EmployeeInfo_SelectionChanged(object sender, EventArgs e)
        {
            if ( dataGridView_EmployeeInfo.SelectedRows.Count > 0 )
            {
                textBox_Name.Text = (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_XingMing"].Value;
                comboBox_Sex.Text = (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_XingBie"].Value;
                textBox_JobNo.Text = dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_GongHao"].Value.ToString();
                textBox_CardNo.Text = (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_KaHao"].Value;
                comboBox_XingJi.Text = (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_XingJi"].Value;
                textBox_GeYan.Text = (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_GeYan"].Value;
                string vPhotoPath = string.Format(@"{0}\Photo\{1}", System.Environment.CurrentDirectory, (string)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_Photo"].Value);
                if (System.IO.File.Exists(vPhotoPath))
                {
                    pictureBox_Photo.Image = Image.FromFile(vPhotoPath);
                    pictureBox_Photo.Tag = vPhotoPath;
                }
                else
                {
                    pictureBox_Photo.Image = null;
                    pictureBox_Photo.Tag = null;
                    
                }
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text == "")
            {
                MessageBox.Show("请输入员工姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int vJobNo = 0;
            if ( !int.TryParse(textBox_JobNo.Text,out vJobNo) )
            {
                MessageBox.Show("工号必须为数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int vID = (int)dataGridView_EmployeeInfo.SelectedRows[0].Cells["Column_ID"].Value;
            string vOutInfo = "";
            string vPhotoPath = pictureBox_Photo.Tag == null ? "" : (string)pictureBox_Photo.Tag;
            if (m_Employee.Update(vID, textBox_Name.Text, comboBox_Sex.Text, vJobNo, textBox_CardNo.Text, vPhotoPath,comboBox_XingJi.Text,textBox_GeYan.Text))
            {
                MessageBox.Show("更新员工信息成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView_EmployeeInfo.DataSource = m_Employee.GetAllEmplyees();
            }
            else
                MessageBox.Show(vOutInfo, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void button_Synch_Click(object sender, EventArgs e)
        {
            WatchHouseControl vWatchHouseControl = new WatchHouseControl();
            Dictionary<string,bool> vResult = await vWatchHouseControl.AsyncUpdateWatchHouseAllPic("");
            string vMessageInfo = "";
            foreach (var vTemp in vResult)
            {
                vMessageInfo += string.Format("岗亭名称：{0}  更新状态：{1}", vTemp.Key, vTemp.Value ? "成功" : "失败");
            }
            MessageBox.Show(vMessageInfo, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
