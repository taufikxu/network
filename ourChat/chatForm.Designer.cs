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
        private void InitializeComponent_chatForm()
        {
            this.chatShow = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chatShow
            // 
            this.chatShow.Location = new System.Drawing.Point(12, 12);
            this.chatShow.Multiline = true;
            this.chatShow.Name = "chatShow";
            this.chatShow.Size = new System.Drawing.Size(353, 259);
            this.chatShow.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 277);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(353, 128);
            this.chatBox.TabIndex = 2;
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 462);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chatShow);
            this.Name = "chatForm";
            this.Text = "chatForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox chatShow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox chatBox;
    }
}