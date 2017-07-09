namespace JXHighWay.WatchHouse.Server
{
    partial class SwitchConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SwitchConfigForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_LeiXing = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MingCheng = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_LuHao = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Switch = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LuHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_MinCheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_LeiXing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LuHao)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Switch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_LeiXing);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_MingCheng);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDown_LuHao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "开关信息";
            // 
            // comboBox_LeiXing
            // 
            this.comboBox_LeiXing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LeiXing.FormattingEnabled = true;
            this.comboBox_LeiXing.Items.AddRange(new object[] {
            "分路",
            "分路(带漏保)",
            "漏保",
            "漏保插座",
            "普插座"});
            this.comboBox_LeiXing.Location = new System.Drawing.Point(375, 22);
            this.comboBox_LeiXing.Name = "comboBox_LeiXing";
            this.comboBox_LeiXing.Size = new System.Drawing.Size(121, 20);
            this.comboBox_LeiXing.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "类型:";
            // 
            // textBox_MingCheng
            // 
            this.textBox_MingCheng.Location = new System.Drawing.Point(189, 22);
            this.textBox_MingCheng.Name = "textBox_MingCheng";
            this.textBox_MingCheng.Size = new System.Drawing.Size(126, 21);
            this.textBox_MingCheng.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "名称:";
            // 
            // numericUpDown_LuHao
            // 
            this.numericUpDown_LuHao.Location = new System.Drawing.Point(61, 22);
            this.numericUpDown_LuHao.Name = "numericUpDown_LuHao";
            this.numericUpDown_LuHao.Size = new System.Drawing.Size(65, 21);
            this.numericUpDown_LuHao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路号:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_Switch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 233);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "开关列表";
            // 
            // dataGridView_Switch
            // 
            this.dataGridView_Switch.AllowUserToAddRows = false;
            this.dataGridView_Switch.AllowUserToDeleteRows = false;
            this.dataGridView_Switch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Switch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_LuHao,
            this.Column_MinCheng,
            this.Column_LeiXing});
            this.dataGridView_Switch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Switch.Location = new System.Drawing.Point(3, 17);
            this.dataGridView_Switch.Name = "dataGridView_Switch";
            this.dataGridView_Switch.ReadOnly = true;
            this.dataGridView_Switch.RowTemplate.Height = 23;
            this.dataGridView_Switch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Switch.Size = new System.Drawing.Size(514, 213);
            this.dataGridView_Switch.TabIndex = 0;
            this.dataGridView_Switch.SelectionChanged += new System.EventHandler(this.dataGridView_Switch_SelectionChanged);
            // 
            // Column_ID
            // 
            this.Column_ID.DataPropertyName = "ID";
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Visible = false;
            // 
            // Column_LuHao
            // 
            this.Column_LuHao.DataPropertyName = "LuHao";
            this.Column_LuHao.HeaderText = "路号";
            this.Column_LuHao.Name = "Column_LuHao";
            this.Column_LuHao.ReadOnly = true;
            this.Column_LuHao.Width = 60;
            // 
            // Column_MinCheng
            // 
            this.Column_MinCheng.DataPropertyName = "MinCheng";
            this.Column_MinCheng.HeaderText = "名称";
            this.Column_MinCheng.Name = "Column_MinCheng";
            this.Column_MinCheng.ReadOnly = true;
            this.Column_MinCheng.Width = 150;
            // 
            // Column_LeiXing
            // 
            this.Column_LeiXing.DataPropertyName = "LeiXing";
            this.Column_LeiXing.HeaderText = "类型";
            this.Column_LeiXing.Name = "Column_LeiXing";
            this.Column_LeiXing.ReadOnly = true;
            // 
            // button_Update
            // 
            this.button_Update.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Update;
            this.button_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Update.Location = new System.Drawing.Point(345, 297);
            this.button_Update.Margin = new System.Windows.Forms.Padding(2);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(78, 37);
            this.button_Update.TabIndex = 7;
            this.button_Update.Text = "更　新";
            this.button_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // button_Del
            // 
            this.button_Del.Image = ((System.Drawing.Image)(resources.GetObject("button_Del.Image")));
            this.button_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Del.Location = new System.Drawing.Point(215, 297);
            this.button_Del.Margin = new System.Windows.Forms.Padding(2);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(78, 37);
            this.button_Del.TabIndex = 6;
            this.button_Del.Text = "删　除";
            this.button_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Del.UseVisualStyleBackColor = true;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // button_Add
            // 
            this.button_Add.Image = global::JXHighWay.WatchHouse.Server.Properties.Resources.Add;
            this.button_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add.Location = new System.Drawing.Point(81, 297);
            this.button_Add.Margin = new System.Windows.Forms.Padding(2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(78, 37);
            this.button_Add.TabIndex = 5;
            this.button_Add.Text = "增　加";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // SwitchConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 345);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SwitchConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开关配置";
            this.Load += new System.EventHandler(this.SwitchConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LuHao)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Switch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_LuHao;
        private System.Windows.Forms.TextBox textBox_MingCheng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_LeiXing;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_Switch;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LuHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MinCheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_LeiXing;
    }
}