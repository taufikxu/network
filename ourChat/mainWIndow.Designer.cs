namespace ourChat
{
    partial class mainWindow
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
            this.strShow = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // strShow
            // 
            this.strShow.Location = new System.Drawing.Point(25, 27);
            this.strShow.Multiline = true;
            this.strShow.Name = "strShow";
            this.strShow.Size = new System.Drawing.Size(326, 300);
            this.strShow.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.strShow);
            this.Name = "mainWindow";
            this.Text = "mainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox strShow;
        private System.Windows.Forms.Button button1;
    }
}

