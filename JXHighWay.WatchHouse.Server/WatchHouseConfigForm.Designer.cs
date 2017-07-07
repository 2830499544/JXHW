namespace JXHighWay.WatchHouse.Server
{
    partial class WatchHouseConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_GanTing_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_GanTing_LX = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_GanTing_MC = new System.Windows.Forms.TextBox();
            this.textBox_GanTing_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_LED_IP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_DY_IP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_DY_ID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView_List = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GanTing_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GanTing_MC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GanTing_LX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GanTing_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LED_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DianYuan_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_DianYuan_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_DY_KaiGuan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_GanTing_IP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_GanTing_LX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_GanTing_MC);
            this.groupBox1.Controls.Add(this.textBox_GanTing_ID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1006, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "岗亭配置";
            // 
            // textBox_GanTing_IP
            // 
            this.textBox_GanTing_IP.Location = new System.Drawing.Point(450, 66);
            this.textBox_GanTing_IP.Name = "textBox_GanTing_IP";
            this.textBox_GanTing_IP.ReadOnly = true;
            this.textBox_GanTing_IP.Size = new System.Drawing.Size(200, 28);
            this.textBox_GanTing_IP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP:";
            // 
            // comboBox_GanTing_LX
            // 
            this.comboBox_GanTing_LX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GanTing_LX.FormattingEnabled = true;
            this.comboBox_GanTing_LX.Items.AddRange(new object[] {
            "入口",
            "出口"});
            this.comboBox_GanTing_LX.Location = new System.Drawing.Point(135, 68);
            this.comboBox_GanTing_LX.Name = "comboBox_GanTing_LX";
            this.comboBox_GanTing_LX.Size = new System.Drawing.Size(200, 26);
            this.comboBox_GanTing_LX.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型:";
            // 
            // textBox_GanTing_MC
            // 
            this.textBox_GanTing_MC.Location = new System.Drawing.Point(450, 20);
            this.textBox_GanTing_MC.Name = "textBox_GanTing_MC";
            this.textBox_GanTing_MC.Size = new System.Drawing.Size(200, 28);
            this.textBox_GanTing_MC.TabIndex = 3;
            // 
            // textBox_GanTing_ID
            // 
            this.textBox_GanTing_ID.Location = new System.Drawing.Point(135, 20);
            this.textBox_GanTing_ID.Name = "textBox_GanTing_ID";
            this.textBox_GanTing_ID.Size = new System.Drawing.Size(200, 28);
            this.textBox_GanTing_ID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_LED_IP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1006, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED屏配置";
            // 
            // textBox_LED_IP
            // 
            this.textBox_LED_IP.Location = new System.Drawing.Point(135, 20);
            this.textBox_LED_IP.Name = "textBox_LED_IP";
            this.textBox_LED_IP.Size = new System.Drawing.Size(200, 28);
            this.textBox_LED_IP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "IP:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_DY_KaiGuan);
            this.groupBox3.Controls.Add(this.textBox_DY_IP);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_DY_ID);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1006, 64);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "电源配置";
            // 
            // textBox_DY_IP
            // 
            this.textBox_DY_IP.Location = new System.Drawing.Point(450, 20);
            this.textBox_DY_IP.Name = "textBox_DY_IP";
            this.textBox_DY_IP.ReadOnly = true;
            this.textBox_DY_IP.Size = new System.Drawing.Size(200, 28);
            this.textBox_DY_IP.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(410, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "IP:";
            // 
            // textBox_DY_ID
            // 
            this.textBox_DY_ID.Location = new System.Drawing.Point(135, 20);
            this.textBox_DY_ID.Name = "textBox_DY_ID";
            this.textBox_DY_ID.Size = new System.Drawing.Size(200, 28);
            this.textBox_DY_ID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "编号:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_List);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1006, 231);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "岗亭列表";
            // 
            // dataGridView_List
            // 
            this.dataGridView_List.AllowUserToAddRows = false;
            this.dataGridView_List.AllowUserToDeleteRows = false;
            this.dataGridView_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_GanTing_ID,
            this.Column_GanTing_MC,
            this.Column_GanTing_LX,
            this.Column_GanTing_IP,
            this.Column_LED_IP,
            this.Column_DianYuan_ID,
            this.Column_DianYuan_IP});
            this.dataGridView_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_List.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_List.Name = "dataGridView_List";
            this.dataGridView_List.ReadOnly = true;
            this.dataGridView_List.RowTemplate.Height = 30;
            this.dataGridView_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_List.Size = new System.Drawing.Size(1000, 204);
            this.dataGridView_List.TabIndex = 0;
            this.dataGridView_List.SelectionChanged += new System.EventHandler(this.dataGridView_List_SelectionChanged);
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 50;
            // 
            // Column_GanTing_ID
            // 
            this.Column_GanTing_ID.DataPropertyName = "GangTingID";
            this.Column_GanTing_ID.HeaderText = "岗亭编号";
            this.Column_GanTing_ID.Name = "Column_GanTing_ID";
            this.Column_GanTing_ID.ReadOnly = true;
            this.Column_GanTing_ID.Width = 120;
            // 
            // Column_GanTing_MC
            // 
            this.Column_GanTing_MC.DataPropertyName = "GangTingMC";
            this.Column_GanTing_MC.HeaderText = "岗亭名称";
            this.Column_GanTing_MC.Name = "Column_GanTing_MC";
            this.Column_GanTing_MC.ReadOnly = true;
            this.Column_GanTing_MC.Width = 120;
            // 
            // Column_GanTing_LX
            // 
            this.Column_GanTing_LX.DataPropertyName = "GangTingLX";
            this.Column_GanTing_LX.HeaderText = "岗亭类型";
            this.Column_GanTing_LX.Name = "Column_GanTing_LX";
            this.Column_GanTing_LX.ReadOnly = true;
            this.Column_GanTing_LX.Width = 120;
            // 
            // Column_GanTing_IP
            // 
            this.Column_GanTing_IP.DataPropertyName = "GangTingIP";
            this.Column_GanTing_IP.HeaderText = "岗亭IP";
            this.Column_GanTing_IP.Name = "Column_GanTing_IP";
            this.Column_GanTing_IP.ReadOnly = true;
            this.Column_GanTing_IP.Width = 125;
            // 
            // Column_LED_IP
            // 
            this.Column_LED_IP.DataPropertyName = "GuanGaoPingIP";
            this.Column_LED_IP.HeaderText = "LED屏幕IP";
            this.Column_LED_IP.Name = "Column_LED_IP";
            this.Column_LED_IP.ReadOnly = true;
            this.Column_LED_IP.Width = 125;
            // 
            // Column_DianYuan_ID
            // 
            this.Column_DianYuan_ID.DataPropertyName = "DianYuanID";
            this.Column_DianYuan_ID.HeaderText = "电源编号";
            this.Column_DianYuan_ID.Name = "Column_DianYuan_ID";
            this.Column_DianYuan_ID.ReadOnly = true;
            this.Column_DianYuan_ID.Width = 120;
            // 
            // Column_DianYuan_IP
            // 
            this.Column_DianYuan_IP.DataPropertyName = "DianYuanIP";
            this.Column_DianYuan_IP.HeaderText = "电源IP";
            this.Column_DianYuan_IP.Name = "Column_DianYuan_IP";
            this.Column_DianYuan_IP.ReadOnly = true;
            this.Column_DianYuan_IP.Width = 125;
            // 
            // button_Update
            // 
            this.button_Update.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Update;
            this.button_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Update.Location = new System.Drawing.Point(729, 465);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(117, 56);
            this.button_Update.TabIndex = 8;
            this.button_Update.Text = "更　新";
            this.button_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Del
            // 
            this.button_Del.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Del;
            this.button_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Del.Location = new System.Drawing.Point(435, 465);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(117, 56);
            this.button_Del.TabIndex = 7;
            this.button_Del.Text = "删　除";
            this.button_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Add
            // 
            this.button_Add.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Add;
            this.button_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add.Location = new System.Drawing.Point(153, 465);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(117, 56);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "增　加";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_DY_KaiGuan
            // 
            this.button_DY_KaiGuan.Location = new System.Drawing.Point(729, 17);
            this.button_DY_KaiGuan.Name = "button_DY_KaiGuan";
            this.button_DY_KaiGuan.Size = new System.Drawing.Size(117, 41);
            this.button_DY_KaiGuan.TabIndex = 10;
            this.button_DY_KaiGuan.Text = "开关配置";
            this.button_DY_KaiGuan.UseVisualStyleBackColor = true;
            // 
            // WatchHouseConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 538);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WatchHouseConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "岗亭配置";
            this.Load += new System.EventHandler(this.WatchHouseConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_GanTing_LX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_GanTing_MC;
        private System.Windows.Forms.TextBox textBox_GanTing_ID;
        private System.Windows.Forms.TextBox textBox_GanTing_IP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_LED_IP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_DY_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DY_IP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView_List;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_LX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LED_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DianYuan_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DianYuan_IP;
        private System.Windows.Forms.Button button_DY_KaiGuan;
    }
}