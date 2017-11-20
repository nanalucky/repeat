namespace repeat
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.textBoxConfig = new System.Windows.Forms.TextBox();
            this.textBoxThreadNum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSetProxy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxStartTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxEndTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSazFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.textBoxRepeat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(997, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 82);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Enabled = false;
            this.textBoxAccount.Location = new System.Drawing.Point(997, 171);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(525, 28);
            this.textBoxAccount.TabIndex = 44;
            // 
            // textBoxConfig
            // 
            this.textBoxConfig.Enabled = false;
            this.textBoxConfig.Location = new System.Drawing.Point(997, 137);
            this.textBoxConfig.Name = "textBoxConfig";
            this.textBoxConfig.Size = new System.Drawing.Size(525, 28);
            this.textBoxConfig.TabIndex = 43;
            // 
            // textBoxThreadNum
            // 
            this.textBoxThreadNum.Enabled = false;
            this.textBoxThreadNum.Location = new System.Drawing.Point(893, 132);
            this.textBoxThreadNum.Name = "textBoxThreadNum";
            this.textBoxThreadNum.Size = new System.Drawing.Size(84, 28);
            this.textBoxThreadNum.TabIndex = 42;
            this.textBoxThreadNum.Text = "1";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(725, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 42);
            this.label10.TabIndex = 41;
            this.label10.Text = "ThreadNum";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSetProxy
            // 
            this.textBoxSetProxy.Enabled = false;
            this.textBoxSetProxy.Location = new System.Drawing.Point(203, 137);
            this.textBoxSetProxy.Name = "textBoxSetProxy";
            this.textBoxSetProxy.Size = new System.Drawing.Size(84, 28);
            this.textBoxSetProxy.TabIndex = 40;
            this.textBoxSetProxy.Text = "false";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(31, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 42);
            this.label8.TabIndex = 39;
            this.label8.Text = "SetProxy";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxStartTime
            // 
            this.textBoxStartTime.Enabled = false;
            this.textBoxStartTime.Location = new System.Drawing.Point(203, 202);
            this.textBoxStartTime.Name = "textBoxStartTime";
            this.textBoxStartTime.Size = new System.Drawing.Size(124, 28);
            this.textBoxStartTime.TabIndex = 38;
            this.textBoxStartTime.Text = "23:00:14";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(31, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 42);
            this.label1.TabIndex = 37;
            this.label1.Text = "开始时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(31, 38);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(147, 62);
            this.buttonRun.TabIndex = 36;
            this.buttonRun.Text = "运行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // textBoxEndTime
            // 
            this.textBoxEndTime.Enabled = false;
            this.textBoxEndTime.Location = new System.Drawing.Point(550, 202);
            this.textBoxEndTime.Name = "textBoxEndTime";
            this.textBoxEndTime.Size = new System.Drawing.Size(124, 28);
            this.textBoxEndTime.TabIndex = 46;
            this.textBoxEndTime.Text = "23:00:14";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(378, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 42);
            this.label2.TabIndex = 45;
            this.label2.Text = "结束时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSazFile
            // 
            this.textBoxSazFile.Enabled = false;
            this.textBoxSazFile.Location = new System.Drawing.Point(893, 202);
            this.textBoxSazFile.Name = "textBoxSazFile";
            this.textBoxSazFile.Size = new System.Drawing.Size(84, 28);
            this.textBoxSazFile.TabIndex = 48;
            this.textBoxSazFile.Text = "saz.saz";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(725, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 42);
            this.label3.TabIndex = 47;
            this.label3.Text = "SazFile";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(31, 257);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(1052, 591);
            this.richTextBoxStatus.TabIndex = 49;
            this.richTextBoxStatus.Text = "";
            // 
            // textBoxRepeat
            // 
            this.textBoxRepeat.Enabled = false;
            this.textBoxRepeat.Location = new System.Drawing.Point(550, 137);
            this.textBoxRepeat.Name = "textBoxRepeat";
            this.textBoxRepeat.Size = new System.Drawing.Size(84, 28);
            this.textBoxRepeat.TabIndex = 51;
            this.textBoxRepeat.Text = "true";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(378, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 42);
            this.label4.TabIndex = 50;
            this.label4.Text = "Repeat";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 898);
            this.Controls.Add(this.textBoxRepeat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.textBoxSazFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEndTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAccount);
            this.Controls.Add(this.textBoxConfig);
            this.Controls.Add(this.textBoxThreadNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxSetProxy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.TextBox textBoxConfig;
        private System.Windows.Forms.TextBox textBoxThreadNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSetProxy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.TextBox textBoxEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSazFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.Windows.Forms.TextBox textBoxRepeat;
        private System.Windows.Forms.Label label4;
    }
}

