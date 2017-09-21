namespace JXHighWay.WatchHouse.Server
{
    partial class ConfigForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.numericUpDown_DB_Port = new System.Windows.Forms.NumericUpDown();
            this.textBox_DB_Password = new System.Windows.Forms.TextBox();
            this.textBox_DB_UserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DB_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_Power_Port = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_WM_Port = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Emplyee_Address = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Pic_Address = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DB_Port)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Power_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WM_Port)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(381, 186);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox_IPAddress);
            this.tabPage1.Controls.Add(this.numericUpDown_DB_Port);
            this.tabPage1.Controls.Add(this.textBox_DB_Password);
            this.tabPage1.Controls.Add(this.textBox_DB_UserName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_DB_Name);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(373, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库参数";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Location = new System.Drawing.Point(110, 19);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.Size = new System.Drawing.Size(163, 21);
            this.textBox_IPAddress.TabIndex = 9;
            // 
            // numericUpDown_DB_Port
            // 
            this.numericUpDown_DB_Port.Location = new System.Drawing.Point(110, 76);
            this.numericUpDown_DB_Port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_DB_Port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_DB_Port.Name = "numericUpDown_DB_Port";
            this.numericUpDown_DB_Port.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown_DB_Port.TabIndex = 10;
            // 
            // textBox_DB_Password
            // 
            this.textBox_DB_Password.Location = new System.Drawing.Point(110, 132);
            this.textBox_DB_Password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DB_Password.Name = "textBox_DB_Password";
            this.textBox_DB_Password.Size = new System.Drawing.Size(163, 21);
            this.textBox_DB_Password.TabIndex = 9;
            // 
            // textBox_DB_UserName
            // 
            this.textBox_DB_UserName.Location = new System.Drawing.Point(110, 105);
            this.textBox_DB_UserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DB_UserName.Name = "textBox_DB_UserName";
            this.textBox_DB_UserName.Size = new System.Drawing.Size(163, 21);
            this.textBox_DB_UserName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "密码:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "端口:";
            // 
            // textBox_DB_Name
            // 
            this.textBox_DB_Name.Location = new System.Drawing.Point(110, 48);
            this.textBox_DB_Name.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DB_Name.Name = "textBox_DB_Name";
            this.textBox_DB_Name.Size = new System.Drawing.Size(163, 21);
            this.textBox_DB_Name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "库名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.numericUpDown_Power_Port);
            this.tabPage2.Controls.Add(this.numericUpDown_WM_Port);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox_Emplyee_Address);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox_Pic_Address);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(373, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其它参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(285, 123);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "/EmployeeInfo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(112, 122);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "http://";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(285, 88);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "/Photo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 88);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "http://";
            // 
            // numericUpDown_Power_Port
            // 
            this.numericUpDown_Power_Port.Location = new System.Drawing.Point(115, 50);
            this.numericUpDown_Power_Port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_Power_Port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_Power_Port.Name = "numericUpDown_Power_Port";
            this.numericUpDown_Power_Port.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown_Power_Port.TabIndex = 9;
            // 
            // numericUpDown_WM_Port
            // 
            this.numericUpDown_WM_Port.Location = new System.Drawing.Point(115, 18);
            this.numericUpDown_WM_Port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_WM_Port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_WM_Port.Name = "numericUpDown_WM_Port";
            this.numericUpDown_WM_Port.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown_WM_Port.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "电源监听端口:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "岗亭监听端口:";
            // 
            // textBox_Emplyee_Address
            // 
            this.textBox_Emplyee_Address.Location = new System.Drawing.Point(159, 119);
            this.textBox_Emplyee_Address.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Emplyee_Address.Name = "textBox_Emplyee_Address";
            this.textBox_Emplyee_Address.Size = new System.Drawing.Size(122, 21);
            this.textBox_Emplyee_Address.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "员工信息地址:";
            // 
            // textBox_Pic_Address
            // 
            this.textBox_Pic_Address.Location = new System.Drawing.Point(159, 84);
            this.textBox_Pic_Address.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Pic_Address.Name = "textBox_Pic_Address";
            this.textBox_Pic_Address.Size = new System.Drawing.Size(122, 21);
            this.textBox_Pic_Address.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "图片信息地址:";
            // 
            // button_Exit
            // 
            this.button_Exit.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Exit;
            this.button_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Exit.Location = new System.Drawing.Point(201, 190);
            this.button_Exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(78, 38);
            this.button_Exit.TabIndex = 8;
            this.button_Exit.Text = "退　出";
            this.button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Save
            // 
            this.button_Save.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.save;
            this.button_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Save.Location = new System.Drawing.Point(75, 190);
            this.button_Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(78, 38);
            this.button_Save.TabIndex = 7;
            this.button_Save.Text = "保　存";
            this.button_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 234);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "基本参数";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DB_Port)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Power_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_WM_Port)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DB_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_DB_Password;
        private System.Windows.Forms.TextBox textBox_DB_UserName;
        private System.Windows.Forms.TextBox textBox_Emplyee_Address;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Pic_Address;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_Power_Port;
        private System.Windows.Forms.NumericUpDown numericUpDown_WM_Port;
        private System.Windows.Forms.NumericUpDown numericUpDown_DB_Port;
        private System.Windows.Forms.TextBox textBox_IPAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}