namespace ourChat
{
    partial class chatgroup_Add
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
            this.checkedListBox_cgfriend = new System.Windows.Forms.CheckedListBox();
            this.button_done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox_cgfriend
            // 
            this.checkedListBox_cgfriend.CheckOnClick = true;
            this.checkedListBox_cgfriend.FormattingEnabled = true;
            this.checkedListBox_cgfriend.Location = new System.Drawing.Point(58, 24);
            this.checkedListBox_cgfriend.Name = "checkedListBox_cgfriend";
            this.checkedListBox_cgfriend.Size = new System.Drawing.Size(169, 164);
            this.checkedListBox_cgfriend.TabIndex = 0;
            this.checkedListBox_cgfriend.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_cgfriend_SelectedIndexChanged);
            // 
            // button_done
            // 
            this.button_done.Location = new System.Drawing.Point(102, 206);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(75, 23);
            this.button_done.TabIndex = 1;
            this.button_done.Text = "添加完成";
            this.button_done.UseVisualStyleBackColor = true;
            this.button_done.Click += new System.EventHandler(this.button_done_Click);
            // 
            // chatgroup_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 250);
            this.Controls.Add(this.button_done);
            this.Controls.Add(this.checkedListBox_cgfriend);
            this.Name = "chatgroup_Add";
            this.Text = "chatgroup_Add";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_cgfriend;
        private System.Windows.Forms.Button button_done;
    }
}