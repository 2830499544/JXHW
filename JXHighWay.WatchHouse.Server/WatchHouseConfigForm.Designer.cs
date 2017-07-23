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
            this.groupBox_Power1 = new System.Windows.Forms.GroupBox();
            this.button_DY1_PowerIP = new System.Windows.Forms.Button();
            this.button_DY1_KaiGuan = new System.Windows.Forms.Button();
            this.textBox_DY1_IP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_DY1_ID = new System.Windows.Forms.TextBox();
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
            this.groupBox_Power2 = new System.Windows.Forms.GroupBox();
            this.button_DY2_PowerIP = new System.Windows.Forms.Button();
            this.button_DY2_KaiGuan = new System.Windows.Forms.Button();
            this.textBox_DY2_IP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_DY2_ID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_Power1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List)).BeginInit();
            this.groupBox_Power2.SuspendLayout();
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(685, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "岗亭配置";
            // 
            // textBox_GanTing_IP
            // 
            this.textBox_GanTing_IP.Location = new System.Drawing.Point(300, 44);
            this.textBox_GanTing_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GanTing_IP.Name = "textBox_GanTing_IP";
            this.textBox_GanTing_IP.ReadOnly = true;
            this.textBox_GanTing_IP.Size = new System.Drawing.Size(135, 21);
            this.textBox_GanTing_IP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP:";
            // 
            // comboBox_GanTing_LX
            // 
            this.comboBox_GanTing_LX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_GanTing_LX.FormattingEnabled = true;
            this.comboBox_GanTing_LX.Items.AddRange(new object[] {
            "入口",
            "出口",
            "双向"});
            this.comboBox_GanTing_LX.Location = new System.Drawing.Point(90, 45);
            this.comboBox_GanTing_LX.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_GanTing_LX.Name = "comboBox_GanTing_LX";
            this.comboBox_GanTing_LX.Size = new System.Drawing.Size(135, 20);
            this.comboBox_GanTing_LX.TabIndex = 5;
            this.comboBox_GanTing_LX.SelectedIndexChanged += new System.EventHandler(this.comboBox_GanTing_LX_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "类型:";
            // 
            // textBox_GanTing_MC
            // 
            this.textBox_GanTing_MC.Location = new System.Drawing.Point(300, 13);
            this.textBox_GanTing_MC.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GanTing_MC.Name = "textBox_GanTing_MC";
            this.textBox_GanTing_MC.Size = new System.Drawing.Size(135, 21);
            this.textBox_GanTing_MC.TabIndex = 3;
            // 
            // textBox_GanTing_ID
            // 
            this.textBox_GanTing_ID.Location = new System.Drawing.Point(90, 13);
            this.textBox_GanTing_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_GanTing_ID.Name = "textBox_GanTing_ID";
            this.textBox_GanTing_ID.Size = new System.Drawing.Size(135, 21);
            this.textBox_GanTing_ID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "名称:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_LED_IP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 70);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(685, 37);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LED屏配置";
            // 
            // textBox_LED_IP
            // 
            this.textBox_LED_IP.Location = new System.Drawing.Point(90, 13);
            this.textBox_LED_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_LED_IP.Name = "textBox_LED_IP";
            this.textBox_LED_IP.Size = new System.Drawing.Size(135, 21);
            this.textBox_LED_IP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "IP:";
            // 
            // groupBox_Power1
            // 
            this.groupBox_Power1.Controls.Add(this.button_DY1_PowerIP);
            this.groupBox_Power1.Controls.Add(this.button_DY1_KaiGuan);
            this.groupBox_Power1.Controls.Add(this.textBox_DY1_IP);
            this.groupBox_Power1.Controls.Add(this.label7);
            this.groupBox_Power1.Controls.Add(this.textBox_DY1_ID);
            this.groupBox_Power1.Controls.Add(this.label6);
            this.groupBox_Power1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Power1.Location = new System.Drawing.Point(0, 107);
            this.groupBox_Power1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Power1.Name = "groupBox_Power1";
            this.groupBox_Power1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Power1.Size = new System.Drawing.Size(685, 43);
            this.groupBox_Power1.TabIndex = 2;
            this.groupBox_Power1.TabStop = false;
            this.groupBox_Power1.Text = "电源配置1";
            // 
            // button_DY1_PowerIP
            // 
            this.button_DY1_PowerIP.Location = new System.Drawing.Point(569, 11);
            this.button_DY1_PowerIP.Margin = new System.Windows.Forms.Padding(2);
            this.button_DY1_PowerIP.Name = "button_DY1_PowerIP";
            this.button_DY1_PowerIP.Size = new System.Drawing.Size(78, 27);
            this.button_DY1_PowerIP.TabIndex = 11;
            this.button_DY1_PowerIP.Text = "IP配置";
            this.button_DY1_PowerIP.UseVisualStyleBackColor = true;
            this.button_DY1_PowerIP.Click += new System.EventHandler(this.button_PowerIP_Click);
            // 
            // button_DY1_KaiGuan
            // 
            this.button_DY1_KaiGuan.Location = new System.Drawing.Point(456, 12);
            this.button_DY1_KaiGuan.Margin = new System.Windows.Forms.Padding(2);
            this.button_DY1_KaiGuan.Name = "button_DY1_KaiGuan";
            this.button_DY1_KaiGuan.Size = new System.Drawing.Size(78, 27);
            this.button_DY1_KaiGuan.TabIndex = 10;
            this.button_DY1_KaiGuan.Text = "开关配置";
            this.button_DY1_KaiGuan.UseVisualStyleBackColor = true;
            this.button_DY1_KaiGuan.Click += new System.EventHandler(this.button_DY_KaiGuan_Click);
            // 
            // textBox_DY1_IP
            // 
            this.textBox_DY1_IP.Location = new System.Drawing.Point(300, 13);
            this.textBox_DY1_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DY1_IP.Name = "textBox_DY1_IP";
            this.textBox_DY1_IP.ReadOnly = true;
            this.textBox_DY1_IP.Size = new System.Drawing.Size(135, 21);
            this.textBox_DY1_IP.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "IP:";
            // 
            // textBox_DY1_ID
            // 
            this.textBox_DY1_ID.Location = new System.Drawing.Point(90, 13);
            this.textBox_DY1_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DY1_ID.Name = "textBox_DY1_ID";
            this.textBox_DY1_ID.Size = new System.Drawing.Size(135, 21);
            this.textBox_DY1_ID.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "编号:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView_List);
            this.groupBox4.Location = new System.Drawing.Point(0, 197);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(683, 225);
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
            this.dataGridView_List.Location = new System.Drawing.Point(2, 16);
            this.dataGridView_List.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView_List.Name = "dataGridView_List";
            this.dataGridView_List.ReadOnly = true;
            this.dataGridView_List.RowHeadersVisible = false;
            this.dataGridView_List.RowTemplate.Height = 30;
            this.dataGridView_List.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_List.Size = new System.Drawing.Size(679, 207);
            this.dataGridView_List.TabIndex = 0;
            this.dataGridView_List.SelectionChanged += new System.EventHandler(this.dataGridView_List_SelectionChanged);
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 30;
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
            this.Column_GanTing_IP.Width = 120;
            // 
            // Column_LED_IP
            // 
            this.Column_LED_IP.DataPropertyName = "GuanGaoPingIP";
            this.Column_LED_IP.HeaderText = "LED屏幕IP";
            this.Column_LED_IP.Name = "Column_LED_IP";
            this.Column_LED_IP.ReadOnly = true;
            this.Column_LED_IP.Width = 150;
            // 
            // Column_DianYuan_ID
            // 
            this.Column_DianYuan_ID.DataPropertyName = "DianYuan1ID";
            this.Column_DianYuan_ID.HeaderText = "电源编号";
            this.Column_DianYuan_ID.Name = "Column_DianYuan_ID";
            this.Column_DianYuan_ID.ReadOnly = true;
            this.Column_DianYuan_ID.Width = 120;
            // 
            // Column_DianYuan_IP
            // 
            this.Column_DianYuan_IP.DataPropertyName = "DianYuan1IP";
            this.Column_DianYuan_IP.HeaderText = "电源IP";
            this.Column_DianYuan_IP.Name = "Column_DianYuan_IP";
            this.Column_DianYuan_IP.ReadOnly = true;
            this.Column_DianYuan_IP.Width = 120;
            // 
            // button_Update
            // 
            this.button_Update.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Update;
            this.button_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Update.Location = new System.Drawing.Point(520, 441);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(78, 37);
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
            this.button_Del.Location = new System.Drawing.Point(293, 441);
            this.button_Del.Margin = new System.Windows.Forms.Padding(2);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(78, 37);
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
            this.button_Add.Location = new System.Drawing.Point(77, 441);
            this.button_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(78, 37);
            this.button_Add.TabIndex = 6;
            this.button_Add.Text = "增　加";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // groupBox_Power2
            // 
            this.groupBox_Power2.Controls.Add(this.button_DY2_PowerIP);
            this.groupBox_Power2.Controls.Add(this.button_DY2_KaiGuan);
            this.groupBox_Power2.Controls.Add(this.textBox_DY2_IP);
            this.groupBox_Power2.Controls.Add(this.label8);
            this.groupBox_Power2.Controls.Add(this.textBox_DY2_ID);
            this.groupBox_Power2.Controls.Add(this.label9);
            this.groupBox_Power2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Power2.Location = new System.Drawing.Point(0, 150);
            this.groupBox_Power2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Power2.Name = "groupBox_Power2";
            this.groupBox_Power2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Power2.Size = new System.Drawing.Size(685, 43);
            this.groupBox_Power2.TabIndex = 3;
            this.groupBox_Power2.TabStop = false;
            this.groupBox_Power2.Text = "电源配置2";
            // 
            // button_DY2_PowerIP
            // 
            this.button_DY2_PowerIP.Location = new System.Drawing.Point(569, 11);
            this.button_DY2_PowerIP.Margin = new System.Windows.Forms.Padding(2);
            this.button_DY2_PowerIP.Name = "button_DY2_PowerIP";
            this.button_DY2_PowerIP.Size = new System.Drawing.Size(78, 27);
            this.button_DY2_PowerIP.TabIndex = 11;
            this.button_DY2_PowerIP.Text = "IP配置";
            this.button_DY2_PowerIP.UseVisualStyleBackColor = true;
            this.button_DY2_PowerIP.Click += new System.EventHandler(this.button_DY2_PowerIP_Click);
            // 
            // button_DY2_KaiGuan
            // 
            this.button_DY2_KaiGuan.Location = new System.Drawing.Point(456, 12);
            this.button_DY2_KaiGuan.Margin = new System.Windows.Forms.Padding(2);
            this.button_DY2_KaiGuan.Name = "button_DY2_KaiGuan";
            this.button_DY2_KaiGuan.Size = new System.Drawing.Size(78, 27);
            this.button_DY2_KaiGuan.TabIndex = 10;
            this.button_DY2_KaiGuan.Text = "开关配置";
            this.button_DY2_KaiGuan.UseVisualStyleBackColor = true;
            this.button_DY2_KaiGuan.Click += new System.EventHandler(this.button_DY2_KaiGuan_Click);
            // 
            // textBox_DY2_IP
            // 
            this.textBox_DY2_IP.Location = new System.Drawing.Point(300, 13);
            this.textBox_DY2_IP.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DY2_IP.Name = "textBox_DY2_IP";
            this.textBox_DY2_IP.ReadOnly = true;
            this.textBox_DY2_IP.Size = new System.Drawing.Size(135, 21);
            this.textBox_DY2_IP.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "IP:";
            // 
            // textBox_DY2_ID
            // 
            this.textBox_DY2_ID.Location = new System.Drawing.Point(90, 13);
            this.textBox_DY2_ID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_DY2_ID.Name = "textBox_DY2_ID";
            this.textBox_DY2_ID.Size = new System.Drawing.Size(135, 21);
            this.textBox_DY2_ID.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "编号:";
            // 
            // WatchHouseConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 495);
            this.Controls.Add(this.groupBox_Power2);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox_Power1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WatchHouseConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "岗亭配置";
            this.Load += new System.EventHandler(this.WatchHouseConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_Power1.ResumeLayout(false);
            this.groupBox_Power1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_List)).EndInit();
            this.groupBox_Power2.ResumeLayout(false);
            this.groupBox_Power2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox_Power1;
        private System.Windows.Forms.TextBox textBox_LED_IP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_DY1_ID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_DY1_IP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView_List;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_DY1_KaiGuan;
        private System.Windows.Forms.Button button_DY1_PowerIP;
        private System.Windows.Forms.GroupBox groupBox_Power2;
        private System.Windows.Forms.Button button_DY2_PowerIP;
        private System.Windows.Forms.Button button_DY2_KaiGuan;
        private System.Windows.Forms.TextBox textBox_DY2_IP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_DY2_ID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_MC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_LX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_GanTing_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LED_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DianYuan_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DianYuan_IP;
    }
}