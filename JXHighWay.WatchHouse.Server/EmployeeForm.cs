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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void button_Photo_Click(object sender, EventArgs e)
        {
            OpenFileDialog vOpenFileDialog = new OpenFileDialog();
            vOpenFileDialog.Multiselect = false;
            vOpenFileDialog.Filter = "Jpg files (*.jpg)|*.jpg";
            if ( vOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Photo.Image = Image.FromFile( vOpenFileDialog.FileName );
                pictureBox_Photo.Tag = vOpenFileDialog.FileName;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {

        }
    }
}
