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
            this.textBox_GeYan = new System.Windows.Forms.TextBox();
            this.comboBox_XingJi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_XingMing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_XingBie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GongHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_KaHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_XingJi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GeYan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Photo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_EmployeeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_GeYan);
            this.groupBox1.Controls.Add(this.comboBox_XingJi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(485, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "员工信息";
            // 
            // textBox_GeYan
            // 
            this.textBox_GeYan.Location = new System.Drawing.Point(313, 23);
            this.textBox_GeYan.Multiline = true;
            this.textBox_GeYan.Name = "textBox_GeYan";
            this.textBox_GeYan.Size = new System.Drawing.Size(141, 74);
            this.textBox_GeYan.TabIndex = 14;
            // 
            // comboBox_XingJi
            // 
            this.comboBox_XingJi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_XingJi.FormattingEnabled = true;
            this.comboBox_XingJi.Items.AddRange(new object[] {
            "一星",
            "二星",
            "三星",
            "四星",
            "五星"});
            this.comboBox_XingJi.Location = new System.Drawing.Point(90, 180);
            this.comboBox_XingJi.Name = "comboBox_XingJi";
            this.comboBox_XingJi.Size = new System.Drawing.Size(116, 20);
            this.comboBox_XingJi.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "格  言：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 183);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "星  级：";
            // 
            // pictureBox_Photo
            // 
            this.pictureBox_Photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Photo.Location = new System.Drawing.Point(264, 102);
            this.pictureBox_Photo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Photo.Name = "pictureBox_Photo";
            this.pictureBox_Photo.Size = new System.Drawing.Size(190, 96);
            this.pictureBox_Photo.TabIndex = 10;
            this.pictureBox_Photo.TabStop = false;
            // 
            // button_Photo
            // 
            this.button_Photo.Location = new System.Drawing.Point(313, 204);
            this.button_Photo.Margin = new System.Windows.Forms.Padding(2);
            this.button_Photo.Name = "button_Photo";
            this.button_Photo.Size = new System.Drawing.Size(109, 25);
            this.button_Photo.TabIndex = 9;
            this.button_Photo.Text = "更换照片";
            this.button_Photo.UseVisualStyleBackColor = true;
            this.button_Photo.Click += new System.EventHandler(this.button_Photo_Click);
            // 
            // textBox_CardNo
            // 
            this.textBox_CardNo.Location = new System.Drawing.Point(90, 139);
            this.textBox_CardNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_CardNo.Name = "textBox_CardNo";
            this.textBox_CardNo.Size = new System.Drawing.Size(116, 21);
            this.textBox_CardNo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "卡  号：";
            // 
            // textBox_JobNo
            // 
            this.textBox_JobNo.Location = new System.Drawing.Point(89, 98);
            this.textBox_JobNo.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_JobNo.Name = "textBox_JobNo";
            this.textBox_JobNo.Size = new System.Drawing.Size(116, 21);
            this.textBox_JobNo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
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
            this.comboBox_Sex.Location = new System.Drawing.Point(89, 62);
            this.comboBox_Sex.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(116, 20);
            this.comboBox_Sex.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "性  别：";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(89, 23);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(116, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓  名：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_EmployeeInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 238);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(485, 236);
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
            this.Column_Photo,
            this.Column_XingJi,
            this.Column_GeYan});
            this.dataGridView_EmployeeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_EmployeeInfo.Location = new System.Drawing.Point(2, 16);
            this.dataGridView_EmployeeInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_EmployeeInfo.MultiSelect = false;
            this.dataGridView_EmployeeInfo.Name = "dataGridView_EmployeeInfo";
            this.dataGridView_EmployeeInfo.ReadOnly = true;
            this.dataGridView_EmployeeInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_EmployeeInfo.RowTemplate.Height = 30;
            this.dataGridView_EmployeeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_EmployeeInfo.Size = new System.Drawing.Size(481, 218);
            this.dataGridView_EmployeeInfo.TabIndex = 0;
            this.dataGridView_EmployeeInfo.SelectionChanged += new System.EventHandler(this.dataGridView_EmployeeInfo_SelectionChanged);
            // 
            // button_Update
            // 
            this.button_Update.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Update;
            this.button_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Update.Location = new System.Drawing.Point(344, 476);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(78, 37);
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
            this.button_Del.Location = new System.Drawing.Point(202, 476);
            this.button_Del.Margin = new System.Windows.Forms.Padding(2);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(78, 37);
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
            this.button_Add.Location = new System.Drawing.Point(60, 476);
            this.button_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(78, 37);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "增　加";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
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
            this.Column_XingMing.Width = 80;
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
            // 
            // Column_KaHao
            // 
            this.Column_KaHao.DataPropertyName = "KaHao";
            this.Column_KaHao.HeaderText = "卡号";
            this.Column_KaHao.Name = "Column_KaHao";
            this.Column_KaHao.ReadOnly = true;
            // 
            // Column_Photo
            // 
            this.Column_Photo.DataPropertyName = "ZhaoPian";
            this.Column_Photo.HeaderText = "照片";
            this.Column_Photo.Name = "Column_Photo";
            this.Column_Photo.ReadOnly = true;
            this.Column_Photo.Visible = false;
            // 
            // Column_XingJi
            // 
            this.Column_XingJi.DataPropertyName = "XingJi";
            this.Column_XingJi.HeaderText = "星级";
            this.Column_XingJi.Name = "Column_XingJi";
            this.Column_XingJi.ReadOnly = true;
            this.Column_XingJi.Width = 80;
            // 
            // Column_GeYan
            // 
            this.Column_GeYan.DataPropertyName = "GeYan";
            this.Column_GeYan.HeaderText = "格言";
            this.Column_GeYan.Name = "Column_GeYan";
            this.Column_GeYan.ReadOnly = true;
            this.Column_GeYan.Visible = false;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 517);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_XingJi;
        private System.Windows.Forms.TextBox textBox_GeYan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_XingMing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_XingBie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GongHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_KaHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Photo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_XingJi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GeYan;
    }
}