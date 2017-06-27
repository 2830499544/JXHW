namespace JXHighWay.WatchHouse.Server
{
    partial class ManagerForm
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
            this.groupBox_LED = new System.Windows.Forms.GroupBox();
            this.checkBox_DianYuan = new System.Windows.Forms.CheckBox();
            this.checkBox_LED = new System.Windows.Forms.CheckBox();
            this.checkBox_GangTin = new System.Windows.Forms.CheckBox();
            this.textBox_MiMa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ZhanHao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ZhenJia = new System.Windows.Forms.Button();
            this.button_ShangChu = new System.Windows.Forms.Button();
            this.button_XiuGai = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_MangerInfo = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ZhangHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_GangTingGZ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_LEDGongZhi = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column_DianYuanGZ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox_LED.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MangerInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_LED
            // 
            this.groupBox_LED.Controls.Add(this.checkBox_DianYuan);
            this.groupBox_LED.Controls.Add(this.checkBox_LED);
            this.groupBox_LED.Controls.Add(this.checkBox_GangTin);
            this.groupBox_LED.Controls.Add(this.textBox_MiMa);
            this.groupBox_LED.Controls.Add(this.label2);
            this.groupBox_LED.Controls.Add(this.textBox_ZhanHao);
            this.groupBox_LED.Controls.Add(this.label1);
            this.groupBox_LED.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_LED.Location = new System.Drawing.Point(0, 0);
            this.groupBox_LED.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_LED.Name = "groupBox_LED";
            this.groupBox_LED.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_LED.Size = new System.Drawing.Size(591, 174);
            this.groupBox_LED.TabIndex = 0;
            this.groupBox_LED.TabStop = false;
            this.groupBox_LED.Text = "管理员信息";
            // 
            // checkBox_DianYuan
            // 
            this.checkBox_DianYuan.AutoSize = true;
            this.checkBox_DianYuan.Location = new System.Drawing.Point(358, 130);
            this.checkBox_DianYuan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_DianYuan.Name = "checkBox_DianYuan";
            this.checkBox_DianYuan.Size = new System.Drawing.Size(70, 22);
            this.checkBox_DianYuan.TabIndex = 6;
            this.checkBox_DianYuan.Text = "电源";
            this.checkBox_DianYuan.UseVisualStyleBackColor = true;
            // 
            // checkBox_LED
            // 
            this.checkBox_LED.AutoSize = true;
            this.checkBox_LED.Location = new System.Drawing.Point(250, 130);
            this.checkBox_LED.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_LED.Name = "checkBox_LED";
            this.checkBox_LED.Size = new System.Drawing.Size(61, 22);
            this.checkBox_LED.TabIndex = 5;
            this.checkBox_LED.Text = "LED";
            this.checkBox_LED.UseVisualStyleBackColor = true;
            // 
            // checkBox_GangTin
            // 
            this.checkBox_GangTin.AutoSize = true;
            this.checkBox_GangTin.Location = new System.Drawing.Point(144, 130);
            this.checkBox_GangTin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_GangTin.Name = "checkBox_GangTin";
            this.checkBox_GangTin.Size = new System.Drawing.Size(70, 22);
            this.checkBox_GangTin.TabIndex = 4;
            this.checkBox_GangTin.Text = "岗亭";
            this.checkBox_GangTin.UseVisualStyleBackColor = true;
            // 
            // textBox_MiMa
            // 
            this.textBox_MiMa.Location = new System.Drawing.Point(240, 86);
            this.textBox_MiMa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_MiMa.Name = "textBox_MiMa";
            this.textBox_MiMa.Size = new System.Drawing.Size(222, 28);
            this.textBox_MiMa.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "管理员密码:";
            // 
            // textBox_ZhanHao
            // 
            this.textBox_ZhanHao.Location = new System.Drawing.Point(240, 32);
            this.textBox_ZhanHao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_ZhanHao.Name = "textBox_ZhanHao";
            this.textBox_ZhanHao.Size = new System.Drawing.Size(222, 28);
            this.textBox_ZhanHao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "管理员帐号:";
            // 
            // button_ZhenJia
            // 
            this.button_ZhenJia.Location = new System.Drawing.Point(36, 414);
            this.button_ZhenJia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ZhenJia.Name = "button_ZhenJia";
            this.button_ZhenJia.Size = new System.Drawing.Size(112, 48);
            this.button_ZhenJia.TabIndex = 1;
            this.button_ZhenJia.Text = "增　加";
            this.button_ZhenJia.UseVisualStyleBackColor = true;
            this.button_ZhenJia.Click += new System.EventHandler(this.button_ZhenJia_Click);
            // 
            // button_ShangChu
            // 
            this.button_ShangChu.Location = new System.Drawing.Point(230, 414);
            this.button_ShangChu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_ShangChu.Name = "button_ShangChu";
            this.button_ShangChu.Size = new System.Drawing.Size(112, 48);
            this.button_ShangChu.TabIndex = 2;
            this.button_ShangChu.Text = "删　除";
            this.button_ShangChu.UseVisualStyleBackColor = true;
            this.button_ShangChu.Click += new System.EventHandler(this.button_ShangChu_Click);
            // 
            // button_XiuGai
            // 
            this.button_XiuGai.Location = new System.Drawing.Point(422, 414);
            this.button_XiuGai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_XiuGai.Name = "button_XiuGai";
            this.button_XiuGai.Size = new System.Drawing.Size(112, 48);
            this.button_XiuGai.TabIndex = 3;
            this.button_XiuGai.Text = "修　改";
            this.button_XiuGai.UseVisualStyleBackColor = true;
            this.button_XiuGai.Click += new System.EventHandler(this.button_XiuGai_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_MangerInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 174);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(591, 219);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "管理员列表";
            // 
            // dataGridView_MangerInfo
            // 
            this.dataGridView_MangerInfo.AllowUserToAddRows = false;
            this.dataGridView_MangerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MangerInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_ZhangHao,
            this.Column_GangTingGZ,
            this.Column_LEDGongZhi,
            this.Column_DianYuanGZ});
            this.dataGridView_MangerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_MangerInfo.Location = new System.Drawing.Point(4, 25);
            this.dataGridView_MangerInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_MangerInfo.Name = "dataGridView_MangerInfo";
            this.dataGridView_MangerInfo.ReadOnly = true;
            this.dataGridView_MangerInfo.RowTemplate.Height = 23;
            this.dataGridView_MangerInfo.Size = new System.Drawing.Size(583, 190);
            this.dataGridView_MangerInfo.TabIndex = 0;
            // 
            // Column_ID
            // 
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 50;
            // 
            // Column_ZhangHao
            // 
            this.Column_ZhangHao.HeaderText = "帐号";
            this.Column_ZhangHao.Name = "Column_ZhangHao";
            this.Column_ZhangHao.ReadOnly = true;
            this.Column_ZhangHao.Width = 130;
            // 
            // Column_GangTingGZ
            // 
            this.Column_GangTingGZ.HeaderText = "岗亭";
            this.Column_GangTingGZ.Name = "Column_GangTingGZ";
            this.Column_GangTingGZ.ReadOnly = true;
            this.Column_GangTingGZ.Width = 50;
            // 
            // Column_LEDGongZhi
            // 
            this.Column_LEDGongZhi.HeaderText = "LED";
            this.Column_LEDGongZhi.Name = "Column_LEDGongZhi";
            this.Column_LEDGongZhi.ReadOnly = true;
            this.Column_LEDGongZhi.Width = 50;
            // 
            // Column_DianYuanGZ
            // 
            this.Column_DianYuanGZ.HeaderText = "电源";
            this.Column_DianYuanGZ.Name = "Column_DianYuanGZ";
            this.Column_DianYuanGZ.ReadOnly = true;
            this.Column_DianYuanGZ.Width = 50;
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 484);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button_XiuGai);
            this.Controls.Add(this.button_ShangChu);
            this.Controls.Add(this.button_ZhenJia);
            this.Controls.Add(this.groupBox_LED);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员设置";
            this.Load += new System.EventHandler(this.ManagerForm_Load);
            this.groupBox_LED.ResumeLayout(false);
            this.groupBox_LED.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MangerInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_LED;
        private System.Windows.Forms.Button button_ZhenJia;
        private System.Windows.Forms.Button button_ShangChu;
        private System.Windows.Forms.Button button_XiuGai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ZhanHao;
        private System.Windows.Forms.CheckBox checkBox_GangTin;
        private System.Windows.Forms.TextBox textBox_MiMa;
        private System.Windows.Forms.CheckBox checkBox_LED;
        private System.Windows.Forms.CheckBox checkBox_DianYuan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_MangerInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ZhangHao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_GangTingGZ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_LEDGongZhi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_DianYuanGZ;
    }
}