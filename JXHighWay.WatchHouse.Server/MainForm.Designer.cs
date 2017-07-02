﻿namespace JXHighWay.WatchHouse.Server
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Setup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_WatchHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_Administrator = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Setup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(345, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_Setup
            // 
            this.ToolStripMenuItem_Setup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Setup_Employee,
            this.ToolStripMenuItem_Setup_WatchHouse,
            this.ToolStripMenuItem_Setup_Administrator});
            this.ToolStripMenuItem_Setup.Name = "ToolStripMenuItem_Setup";
            this.ToolStripMenuItem_Setup.Size = new System.Drawing.Size(44, 22);
            this.ToolStripMenuItem_Setup.Text = "设置";
            // 
            // ToolStripMenuItem_Setup_Employee
            // 
            this.ToolStripMenuItem_Setup_Employee.Name = "ToolStripMenuItem_Setup_Employee";
            this.ToolStripMenuItem_Setup_Employee.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem_Setup_Employee.Text = "人员设置";
            this.ToolStripMenuItem_Setup_Employee.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_Employee_Click);
            // 
            // ToolStripMenuItem_Setup_WatchHouse
            // 
            this.ToolStripMenuItem_Setup_WatchHouse.Name = "ToolStripMenuItem_Setup_WatchHouse";
            this.ToolStripMenuItem_Setup_WatchHouse.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem_Setup_WatchHouse.Text = "岗亭设置";
            this.ToolStripMenuItem_Setup_WatchHouse.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_WatchHouse_Click);
            // 
            // ToolStripMenuItem_Setup_Administrator
            // 
            this.ToolStripMenuItem_Setup_Administrator.Name = "ToolStripMenuItem_Setup_Administrator";
            this.ToolStripMenuItem_Setup_Administrator.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItem_Setup_Administrator.Text = "管理员设置";
            this.ToolStripMenuItem_Setup_Administrator.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_Administrator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(345, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // button_Stop
            // 
            this.button_Stop.Enabled = false;
            this.button_Stop.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Stop;
            this.button_Stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Stop.Location = new System.Drawing.Point(186, 157);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(82, 44);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "停　止";
            this.button_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Start
            // 
            this.button_Start.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Start;
            this.button_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Start.Location = new System.Drawing.Point(52, 157);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(82, 44);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "开　始";
            this.button_Start.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 213);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智慧岗亭数据采集";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setup;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setup_Employee;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setup_WatchHouse;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Setup_Administrator;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
