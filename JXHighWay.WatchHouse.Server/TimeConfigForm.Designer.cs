namespace JXHighWay.WatchHouse.Server
{
    partial class TimeConfigForm
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
            this.label_Time = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_Synch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_Time);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 61);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "时间信息";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(137, 28);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(17, 12);
            this.label_Time.TabIndex = 2;
            this.label_Time.Text = "无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前电源控制器时间:";
            // 
            // button_Refresh
            // 
            this.button_Refresh.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Info;
            this.button_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Refresh.Location = new System.Drawing.Point(26, 76);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(78, 37);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "刷　新";
            this.button_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_Synch
            // 
            this.button_Synch.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Synch;
            this.button_Synch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Synch.Location = new System.Drawing.Point(181, 76);
            this.button_Synch.Margin = new System.Windows.Forms.Padding(2);
            this.button_Synch.Name = "button_Synch";
            this.button_Synch.Size = new System.Drawing.Size(78, 37);
            this.button_Synch.TabIndex = 8;
            this.button_Synch.Text = "同　步";
            this.button_Synch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Synch.UseVisualStyleBackColor = true;
            this.button_Synch.Click += new System.EventHandler(this.button_Synch_Click);
            // 
            // TimeConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 130);
            this.Controls.Add(this.button_Synch);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimeConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "时间配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_Synch;
    }
}