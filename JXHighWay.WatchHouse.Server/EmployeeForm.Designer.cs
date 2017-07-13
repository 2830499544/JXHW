namespace JXHighWay.WatchHouse.Server
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox_Photo = new System.Windows.Forms.PictureBox();
            this.button_Photo = new System.Windows.Forms.Button();
            this.textBox_CardNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_JobNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Sex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_EmployeeInfo = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_XingMing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_XingBie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GongHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_KaHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Photo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EmployeeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox_Photo);
            this.groupBox1.Controls.Add(this.button_Photo);
            this.groupBox1.Controls.Add(this.textBox_CardNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_JobNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Sex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "员工信息";
            // 
            // pictureBox_Photo
            // 
            this.pictureBox_Photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Photo.Location = new System.Drawing.Point(323, 34);
            this.pictureBox_Photo.Name = "pictureBox_Photo";
            this.pictureBox_Photo.Size = new System.Drawing.Size(393, 143);
            this.pictureBox_Photo.TabIndex = 10;
            this.pictureBox_Photo.TabStop = false;
            // 
            // button_Photo
            // 
            this.button_Photo.Location = new System.Drawing.Point(440, 191);
            this.button_Photo.Name = "button_Photo";
            this.button_Photo.Size = new System.Drawing.Size(164, 38);
            this.button_Photo.TabIndex = 9;
            this.button_Photo.Text = "更换照片";
            this.button_Photo.UseVisualStyleBackColor = true;
            this.button_Photo.Click += new System.EventHandler(this.button_Photo_Click);
            // 
            // textBox_CardNo
            // 
            this.textBox_CardNo.Location = new System.Drawing.Point(117, 172);
            this.textBox_CardNo.Name = "textBox_CardNo";
            this.textBox_CardNo.Size = new System.Drawing.Size(172, 28);
            this.textBox_CardNo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "卡  号：";
            // 
            // textBox_JobNo
            // 
            this.textBox_JobNo.Location = new System.Drawing.Point(117, 129);
            this.textBox_JobNo.Name = "textBox_JobNo";
            this.textBox_JobNo.Size = new System.Drawing.Size(172, 28);
            this.textBox_JobNo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "工  号：";
            // 
            // comboBox_Sex
            // 
            this.comboBox_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Sex.FormattingEnabled = true;
            this.comboBox_Sex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBox_Sex.Location = new System.Drawing.Point(117, 86);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(172, 26);
            this.comboBox_Sex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "性  别：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(117, 34);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(172, 28);
            this.textBox_Name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓  名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_EmployeeInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 354);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "员工列表";
            // 
            // dataGridView_EmployeeInfo
            // 
            this.dataGridView_EmployeeInfo.AllowUserToAddRows = false;
            this.dataGridView_EmployeeInfo.AllowUserToDeleteRows = false;
            this.dataGridView_EmployeeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_EmployeeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_XingMing,
            this.Column_XingBie,
            this.Column_GongHao,
            this.Column_KaHao,
            this.Column_Photo});
            this.dataGridView_EmployeeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_EmployeeInfo.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_EmployeeInfo.MultiSelect = false;
            this.dataGridView_EmployeeInfo.Name = "dataGridView_EmployeeInfo";
            this.dataGridView_EmployeeInfo.ReadOnly = true;
            this.dataGridView_EmployeeInfo.RowTemplate.Height = 30;
            this.dataGridView_EmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_EmployeeInfo.Size = new System.Drawing.Size(722, 327);
            this.dataGridView_EmployeeInfo.TabIndex = 0;
            this.dataGridView_EmployeeInfo.SelectionChanged += new System.EventHandler(this.dataGridView_EmployeeInfo_SelectionChanged);
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 30;
            // 
            // Column_XingMing
            // 
            this.Column_XingMing.DataPropertyName = "XingMing";
            this.Column_XingMing.HeaderText = "姓名";
            this.Column_XingMing.Name = "Column_XingMing";
            this.Column_XingMing.ReadOnly = true;
            // 
            // Column_XingBie
            // 
            this.Column_XingBie.DataPropertyName = "XingBie";
            this.Column_XingBie.HeaderText = "性别";
            this.Column_XingBie.Name = "Column_XingBie";
            this.Column_XingBie.ReadOnly = true;
            this.Column_XingBie.Width = 60;
            // 
            // Column_GongHao
            // 
            this.Column_GongHao.DataPropertyName = "GongHao";
            this.Column_GongHao.HeaderText = "工号";
            this.Column_GongHao.Name = "Column_GongHao";
            this.Column_GongHao.ReadOnly = true;
            this.Column_GongHao.Width = 120;
            // 
            // Column_KaHao
            // 
            this.Column_KaHao.DataPropertyName = "KaHao";
            this.Column_KaHao.HeaderText = "卡号";
            this.Column_KaHao.Name = "Column_KaHao";
            this.Column_KaHao.ReadOnly = true;
            this.Column_KaHao.Width = 120;
            // 
            // Column_Photo
            // 
            this.Column_Photo.DataPropertyName = "ZhaoPian";
            this.Column_Photo.HeaderText = "照片";
            this.Column_Photo.Name = "Column_Photo";
            this.Column_Photo.ReadOnly = true;
            this.Column_Photo.Visible = false;
            // 
            // button_Update
            // 
            this.button_Update.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Update;
            this.button_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Update.Location = new System.Drawing.Point(516, 600);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(117, 56);
            this.button_Update.TabIndex = 4;
            this.button_Update.Text = "更　新";
            this.button_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Del
            // 
            this.button_Del.Image = ((System.Drawing.Image)(resources.GetObject("button_Del.Image")));
            this.button_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Del.Location = new System.Drawing.Point(303, 600);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(117, 56);
            this.button_Del.TabIndex = 3;
            this.button_Del.Text = "删　除";
            this.button_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Add
            // 
            this.button_Add.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Add;
            this.button_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add.Location = new System.Drawing.Point(90, 600);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(117, 56);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "增　加";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 664);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工设置";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Photo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EmployeeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_Photo;
        private System.Windows.Forms.TextBox textBox_CardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_JobNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Sex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_EmployeeInfo;
        private System.Windows.Forms.PictureBox pictureBox_Photo;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_XingMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_XingBie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GongHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_KaHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Photo;
    }
}