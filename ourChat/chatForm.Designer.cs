namespace ourChat
{
    partial class chatForm
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
            this.components = new System.ComponentModel.Container();
            this.text_viewer = new System.Windows.Forms.RichTextBox();
            this.text_sender = new System.Windows.Forms.RichTextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_sendfile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_pic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_cut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_shake = new System.Windows.Forms.ToolStripButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // text_viewer
            // 
            this.text_viewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.text_viewer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.text_viewer.Location = new System.Drawing.Point(12, 12);
            this.text_viewer.Name = "text_viewer";
            this.text_viewer.Size = new System.Drawing.Size(461, 234);
            this.text_viewer.TabIndex = 0;
            this.text_viewer.Text = "";
            // 
            // text_sender
            // 
            this.text_sender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.text_sender.ForeColor = System.Drawing.SystemColors.WindowText;
            this.text_sender.Location = new System.Drawing.Point(12, 291);
            this.text_sender.Name = "text_sender";
            this.text_sender.Size = new System.Drawing.Size(461, 95);
            this.text_sender.TabIndex = 1;
            this.text_sender.Text = "";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(369, 392);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 39);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click_1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_sendfile,
            this.toolStripButton_pic,
            this.toolStripButton_cut,
            this.toolStripButton_shake});
            this.toolStrip1.Location = new System.Drawing.Point(44, 248);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(219, 40);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_sendfile
            // 
            this.toolStripButton_sendfile.AutoSize = false;
            this.toolStripButton_sendfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_sendfile.Image = global::ourChat.Properties.Resources.sendfile1;
            this.toolStripButton_sendfile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_sendfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_sendfile.Name = "toolStripButton_sendfile";
            this.toolStripButton_sendfile.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton_sendfile.Text = "toolStripButton_sendfile";
            this.toolStripButton_sendfile.ToolTipText = "发送文件";
            this.toolStripButton_sendfile.Click += new System.EventHandler(this.toolStripButton_sendfile_Click);
            // 
            // toolStripButton_pic
            // 
            this.toolStripButton_pic.AutoSize = false;
            this.toolStripButton_pic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_pic.Image = global::ourChat.Properties.Resources.sendpic1;
            this.toolStripButton_pic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_pic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_pic.Name = "toolStripButton_pic";
            this.toolStripButton_pic.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton_pic.ToolTipText = "发送图片";
            this.toolStripButton_pic.Click += new System.EventHandler(this.toolStripButton_pic_Click);
            // 
            // toolStripButton_cut
            // 
            this.toolStripButton_cut.AutoSize = false;
            this.toolStripButton_cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_cut.Image = global::ourChat.Properties.Resources.cut21;
            this.toolStripButton_cut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_cut.Name = "toolStripButton_cut";
            this.toolStripButton_cut.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton_cut.ToolTipText = "截屏";
            this.toolStripButton_cut.Click += new System.EventHandler(this.toolStripButton_cut_Click);
            // 
            // toolStripButton_shake
            // 
            this.toolStripButton_shake.AutoSize = false;
            this.toolStripButton_shake.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_shake.Image = global::ourChat.Properties.Resources.shake;
            this.toolStripButton_shake.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_shake.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_shake.Name = "toolStripButton_shake";
            this.toolStripButton_shake.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton_shake.Text = "toolStripButton1";
            this.toolStripButton_shake.ToolTipText = "窗口抖动";
            this.toolStripButton_shake.Click += new System.EventHandler(this.toolStripButton_shake_Click);
            // 
            // chatForm
            // 
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(485, 443);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.text_sender);
            this.Controls.Add(this.text_viewer);
            this.Name = "chatForm";
            this.Activated += new System.EventHandler(this.chatForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.chatForm_FormClosed);
            this.Load += new System.EventHandler(this.chatForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //public System.Windows.Forms.TextBox chatShow;
        public System.Windows.Forms.RichTextBox text_viewer;
        private System.Windows.Forms.RichTextBox text_sender;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_sendfile;
        private System.Windows.Forms.ToolStripButton toolStripButton_pic;
        private System.Windows.Forms.ToolStripButton toolStripButton_cut;
        private System.Windows.Forms.ToolStripButton toolStripButton_shake;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}