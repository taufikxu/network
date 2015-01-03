namespace ourChat
{
    partial class chatGroupWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatGroupWindow));
            this.text_viewer = new System.Windows.Forms.RichTextBox();
            this.text_sender = new System.Windows.Forms.RichTextBox();
            this.button_sendg = new System.Windows.Forms.Button();
            this.listBox_chatgroup = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_viewer
            // 
            this.text_viewer.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.text_viewer.Location = new System.Drawing.Point(31, 110);
            this.text_viewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_viewer.Name = "text_viewer";
            this.text_viewer.Size = new System.Drawing.Size(545, 263);
            this.text_viewer.TabIndex = 0;
            this.text_viewer.Text = "";
            // 
            // text_sender
            // 
            this.text_sender.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.text_sender.Location = new System.Drawing.Point(29, 398);
            this.text_sender.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.text_sender.Name = "text_sender";
            this.text_sender.Size = new System.Drawing.Size(545, 119);
            this.text_sender.TabIndex = 1;
            this.text_sender.Text = "";
            // 
            // button_sendg
            // 
            this.button_sendg.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_sendg.Location = new System.Drawing.Point(477, 545);
            this.button_sendg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_sendg.Name = "button_sendg";
            this.button_sendg.Size = new System.Drawing.Size(100, 38);
            this.button_sendg.TabIndex = 2;
            this.button_sendg.Text = "发送";
            this.button_sendg.UseVisualStyleBackColor = true;
            this.button_sendg.Click += new System.EventHandler(this.button_sendg_Click);
            // 
            // listBox_chatgroup
            // 
            this.listBox_chatgroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listBox_chatgroup.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_chatgroup.FormattingEnabled = true;
            this.listBox_chatgroup.ItemHeight = 22;
            this.listBox_chatgroup.Location = new System.Drawing.Point(609, 162);
            this.listBox_chatgroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox_chatgroup.Name = "listBox_chatgroup";
            this.listBox_chatgroup.Size = new System.Drawing.Size(177, 114);
            this.listBox_chatgroup.TabIndex = 3;
            this.listBox_chatgroup.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(604, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "群成员";
            // 
            // chatGroupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 619);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_chatgroup);
            this.Controls.Add(this.button_sendg);
            this.Controls.Add(this.text_sender);
            this.Controls.Add(this.text_viewer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "chatGroupWindow";
            this.Text = "chatGroupWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chatGroupWindow_FormClosing);
            this.Load += new System.EventHandler(this.chatGroupWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox text_viewer;
        private System.Windows.Forms.RichTextBox text_sender;
        private System.Windows.Forms.Button button_sendg;
        private System.Windows.Forms.ListBox listBox_chatgroup;
        private System.Windows.Forms.Label label1;
    }
}