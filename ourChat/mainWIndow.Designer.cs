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
            this.SuspendLayout();
            // 
            // strShow
            // 
            this.strShow.Location = new System.Drawing.Point(25, 27);
            this.strShow.Multiline = true;
            this.strShow.Name = "strShow";
            this.strShow.Size = new System.Drawing.Size(326, 300);
            this.strShow.TabIndex = 0;
            this.strShow.TextChanged += new System.EventHandler(this.strShow_TextChanged);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 370);
            this.Controls.Add(this.strShow);
            this.Name = "mainWindow";
            this.Text = "mainWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox strShow;
    }
}

