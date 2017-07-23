namespace JXHighWay.WatchHouse.Server
{
    partial class PowerIPConfigForm
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
            this.checkBox_DHCP = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_ServerPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Config = new System.Windows.Forms.Button();
            this.button_Get = new System.Windows.Forms.Button();
            this.textBox_IPAddress = new System.Windows.Forms.TextBox();
            this.textBox_SubMask = new System.Windows.Forms.TextBox();
            this.textBox_GateWay = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_GateWay);
            this.groupBox1.Controls.Add(this.textBox_SubMask);
            this.groupBox1.Controls.Add(this.textBox_IPAddress);
            this.groupBox1.Controls.Add(this.checkBox_DHCP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(323, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP配置";
            // 
            // checkBox_DHCP
            // 
            this.checkBox_DHCP.AutoSize = true;
            this.checkBox_DHCP.Location = new System.Drawing.Point(130, 105);
            this.checkBox_DHCP.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_DHCP.Name = "checkBox_DHCP";
            this.checkBox_DHCP.Size = new System.Drawing.Size(48, 16);
            this.checkBox_DHCP.TabIndex = 3;
            this.checkBox_DHCP.Text = "DHCP";
            this.checkBox_DHCP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "网关:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "子网掩码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_ServerIP);
            this.groupBox2.Controls.Add(this.numericUpDown_ServerPort);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 126);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(323, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器设置";
            // 
            // numericUpDown_ServerPort
            // 
            this.numericUpDown_ServerPort.Location = new System.Drawing.Point(128, 54);
            this.numericUpDown_ServerPort.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_ServerPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_ServerPort.Name = "numericUpDown_ServerPort";
            this.numericUpDown_ServerPort.Size = new System.Drawing.Size(80, 21);
            this.numericUpDown_ServerPort.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "服务器端口:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "服务器IP地址:";
            // 
            // button_Config
            // 
            this.button_Config.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Config;
            this.button_Config.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Config.Location = new System.Drawing.Point(202, 218);
            this.button_Config.Margin = new System.Windows.Forms.Padding(2);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(85, 38);
            this.button_Config.TabIndex = 9;
            this.button_Config.Text = "配　置";
            this.button_Config.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Config.UseVisualStyleBackColor = true;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // button_Get
            // 
            this.button_Get.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Info;
            this.button_Get.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Get.Location = new System.Drawing.Point(49, 218);
            this.button_Get.Margin = new System.Windows.Forms.Padding(2);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(85, 38);
            this.button_Get.TabIndex = 8;
            this.button_Get.Text = "获　取";
            this.button_Get.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // textBox_IPAddress
            // 
            this.textBox_IPAddress.Location = new System.Drawing.Point(130, 20);
            this.textBox_IPAddress.Name = "textBox_IPAddress";
            this.textBox_IPAddress.Size = new System.Drawing.Size(100, 21);
            this.textBox_IPAddress.TabIndex = 7;
            // 
            // textBox_SubMask
            // 
            this.textBox_SubMask.Location = new System.Drawing.Point(129, 50);
            this.textBox_SubMask.Name = "textBox_SubMask";
            this.textBox_SubMask.Size = new System.Drawing.Size(100, 21);
            this.textBox_SubMask.TabIndex = 8;
            // 
            // textBox_GateWay
            // 
            this.textBox_GateWay.Location = new System.Drawing.Point(128, 79);
            this.textBox_GateWay.Name = "textBox_GateWay";
            this.textBox_GateWay.Size = new System.Drawing.Size(100, 21);
            this.textBox_GateWay.TabIndex = 9;
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(128, 23);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_ServerIP.TabIndex = 7;
            // 
            // PowerIPConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 260);
            this.Controls.Add(this.button_Config);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PowerIPConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "电源IP配置";
            this.Load += new System.EventHandler(this.PowerIPConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ServerPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_DHCP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_ServerPort;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.TextBox textBox_GateWay;
        private System.Windows.Forms.TextBox textBox_SubMask;
        private System.Windows.Forms.TextBox textBox_IPAddress;
        private System.Windows.Forms.TextBox textBox_ServerIP;
    }
}