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
            this.maskedTextBox_GateWay = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_SubMask = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_IPAddress = new System.Windows.Forms.MaskedTextBox();
            this.checkBox_DHCP = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown_ServerPort = new System.Windows.Forms.NumericUpDown();
            this.maskedTextBox_ServerIP = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Config = new System.Windows.Forms.Button();
            this.button_Get = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ServerPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox_GateWay);
            this.groupBox1.Controls.Add(this.maskedTextBox_SubMask);
            this.groupBox1.Controls.Add(this.maskedTextBox_IPAddress);
            this.groupBox1.Controls.Add(this.checkBox_DHCP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(431, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP配置";
            // 
            // maskedTextBox_GateWay
            // 
            this.maskedTextBox_GateWay.Location = new System.Drawing.Point(172, 100);
            this.maskedTextBox_GateWay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox_GateWay.Mask = "999.999.999.999";
            this.maskedTextBox_GateWay.Name = "maskedTextBox_GateWay";
            this.maskedTextBox_GateWay.PromptChar = ' ';
            this.maskedTextBox_GateWay.Size = new System.Drawing.Size(133, 25);
            this.maskedTextBox_GateWay.TabIndex = 6;
            this.maskedTextBox_GateWay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_IPAddress_KeyDown);
            // 
            // maskedTextBox_SubMask
            // 
            this.maskedTextBox_SubMask.Location = new System.Drawing.Point(172, 64);
            this.maskedTextBox_SubMask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox_SubMask.Mask = "999.999.999.999";
            this.maskedTextBox_SubMask.Name = "maskedTextBox_SubMask";
            this.maskedTextBox_SubMask.PromptChar = ' ';
            this.maskedTextBox_SubMask.Size = new System.Drawing.Size(133, 25);
            this.maskedTextBox_SubMask.TabIndex = 5;
            this.maskedTextBox_SubMask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_IPAddress_KeyDown);
            // 
            // maskedTextBox_IPAddress
            // 
            this.maskedTextBox_IPAddress.Location = new System.Drawing.Point(172, 25);
            this.maskedTextBox_IPAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox_IPAddress.Mask = "999.999.999.999";
            this.maskedTextBox_IPAddress.Name = "maskedTextBox_IPAddress";
            this.maskedTextBox_IPAddress.PromptChar = ' ';
            this.maskedTextBox_IPAddress.Size = new System.Drawing.Size(133, 25);
            this.maskedTextBox_IPAddress.TabIndex = 4;
            this.maskedTextBox_IPAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_IPAddress_KeyDown);
            // 
            // checkBox_DHCP
            // 
            this.checkBox_DHCP.AutoSize = true;
            this.checkBox_DHCP.Location = new System.Drawing.Point(173, 131);
            this.checkBox_DHCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_DHCP.Name = "checkBox_DHCP";
            this.checkBox_DHCP.Size = new System.Drawing.Size(61, 19);
            this.checkBox_DHCP.TabIndex = 3;
            this.checkBox_DHCP.Text = "DHCP";
            this.checkBox_DHCP.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(119, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "网关:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "子网掩码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP地址:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown_ServerPort);
            this.groupBox2.Controls.Add(this.maskedTextBox_ServerIP);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 157);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(431, 106);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器设置";
            // 
            // numericUpDown_ServerPort
            // 
            this.numericUpDown_ServerPort.Location = new System.Drawing.Point(170, 67);
            this.numericUpDown_ServerPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_ServerPort.Name = "numericUpDown_ServerPort";
            this.numericUpDown_ServerPort.Size = new System.Drawing.Size(107, 25);
            this.numericUpDown_ServerPort.TabIndex = 6;
            // 
            // maskedTextBox_ServerIP
            // 
            this.maskedTextBox_ServerIP.Location = new System.Drawing.Point(170, 31);
            this.maskedTextBox_ServerIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.maskedTextBox_ServerIP.Mask = "999.999.999.999";
            this.maskedTextBox_ServerIP.Name = "maskedTextBox_ServerIP";
            this.maskedTextBox_ServerIP.PromptChar = ' ';
            this.maskedTextBox_ServerIP.Size = new System.Drawing.Size(133, 25);
            this.maskedTextBox_ServerIP.TabIndex = 5;
            this.maskedTextBox_ServerIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBox_IPAddress_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "服务器端口:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "服务器IP地址:";
            // 
            // button_Config
            // 
            this.button_Config.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Config;
            this.button_Config.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Config.Location = new System.Drawing.Point(269, 272);
            this.button_Config.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(113, 47);
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
            this.button_Get.Location = new System.Drawing.Point(65, 272);
            this.button_Get.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Get.Name = "button_Get";
            this.button_Get.Size = new System.Drawing.Size(113, 47);
            this.button_Get.TabIndex = 8;
            this.button_Get.Text = "获　取";
            this.button_Get.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Get.UseVisualStyleBackColor = true;
            this.button_Get.Click += new System.EventHandler(this.button_Get_Click);
            // 
            // PowerIPConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 325);
            this.Controls.Add(this.button_Config);
            this.Controls.Add(this.button_Get);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PowerIPConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "电源IP配置";
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
        private System.Windows.Forms.MaskedTextBox maskedTextBox_GateWay;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_SubMask;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_IPAddress;
        private System.Windows.Forms.NumericUpDown numericUpDown_ServerPort;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ServerIP;
        private System.Windows.Forms.Button button_Get;
        private System.Windows.Forms.Button button_Config;
    }
}