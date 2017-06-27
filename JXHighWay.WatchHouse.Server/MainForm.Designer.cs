namespace JXHighWay.WatchHouse.Server
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
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Setup = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_WatchHouse = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Setup_Administrator = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(110, 236);
            this.button_Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(112, 52);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "开　始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(294, 236);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(112, 52);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "停　止";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Setup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 32);
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
            this.ToolStripMenuItem_Setup.Size = new System.Drawing.Size(58, 28);
            this.ToolStripMenuItem_Setup.Text = "设置";
            // 
            // ToolStripMenuItem_Setup_Employee
            // 
            this.ToolStripMenuItem_Setup_Employee.Name = "ToolStripMenuItem_Setup_Employee";
            this.ToolStripMenuItem_Setup_Employee.Size = new System.Drawing.Size(210, 30);
            this.ToolStripMenuItem_Setup_Employee.Text = "人员设置";
            this.ToolStripMenuItem_Setup_Employee.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_Employee_Click);
            // 
            // ToolStripMenuItem_Setup_WatchHouse
            // 
            this.ToolStripMenuItem_Setup_WatchHouse.Name = "ToolStripMenuItem_Setup_WatchHouse";
            this.ToolStripMenuItem_Setup_WatchHouse.Size = new System.Drawing.Size(210, 30);
            this.ToolStripMenuItem_Setup_WatchHouse.Text = "岗亭设置";
            this.ToolStripMenuItem_Setup_WatchHouse.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_WatchHouse_Click);
            // 
            // ToolStripMenuItem_Setup_Administrator
            // 
            this.ToolStripMenuItem_Setup_Administrator.Name = "ToolStripMenuItem_Setup_Administrator";
            this.ToolStripMenuItem_Setup_Administrator.Size = new System.Drawing.Size(210, 30);
            this.ToolStripMenuItem_Setup_Administrator.Text = "管理员设置";
            this.ToolStripMenuItem_Setup_Administrator.Click += new System.EventHandler(this.ToolStripMenuItem_Setup_Administrator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智慧岗亭数据采集";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

