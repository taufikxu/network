namespace ourChat
{
    partial class videoForm
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
            this.shot_u = new System.Windows.Forms.Button();
            this.yours = new System.Windows.Forms.PictureBox();
            this.shot_m = new System.Windows.Forms.Button();
            this.mine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.yours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mine)).BeginInit();
            this.SuspendLayout();
            // 
            // shot_u
            // 
            this.shot_u.Location = new System.Drawing.Point(121, 274);
            this.shot_u.Name = "shot_u";
            this.shot_u.Size = new System.Drawing.Size(75, 23);
            this.shot_u.TabIndex = 3;
            this.shot_u.Text = "抓取";
            this.shot_u.UseVisualStyleBackColor = true;
            this.shot_u.Click += new System.EventHandler(this.button1_Click);
            // 
            // yours
            // 
            this.yours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yours.Location = new System.Drawing.Point(12, 12);
            this.yours.Name = "yours";
            this.yours.Size = new System.Drawing.Size(320, 240);
            this.yours.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.yours.TabIndex = 4;
            this.yours.TabStop = false;
            // 
            // shot_m
            // 
            this.shot_m.Location = new System.Drawing.Point(462, 274);
            this.shot_m.Name = "shot_m";
            this.shot_m.Size = new System.Drawing.Size(75, 23);
            this.shot_m.TabIndex = 5;
            this.shot_m.Text = "抓取";
            this.shot_m.UseVisualStyleBackColor = true;
            this.shot_m.Click += new System.EventHandler(this.shot_m_Click);
            // 
            // mine
            // 
            this.mine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mine.Location = new System.Drawing.Point(338, 12);
            this.mine.Name = "mine";
            this.mine.Size = new System.Drawing.Size(320, 240);
            this.mine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mine.TabIndex = 6;
            this.mine.TabStop = false;
            // 
            // videoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 316);
            this.Controls.Add(this.mine);
            this.Controls.Add(this.shot_m);
            this.Controls.Add(this.yours);
            this.Controls.Add(this.shot_u);
            this.Name = "videoForm";
            this.Text = "video";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.videoForm_FormClosing);
            this.Load += new System.EventHandler(this.videoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mine)).EndInit();
            this.ResumeLayout(false);

        }


        private void InitiallizeCamera()
        {
            //this.yours = new AForge.Controls.VideoSourcePlayer();
            //this.mine = new AForge.Controls.VideoSourcePlayer();
            //// 
            //// mine
            //// 
            //this.mine.Location = new System.Drawing.Point(338, 12);
            //this.mine.Name = "mine";
            //this.mine.Size = new System.Drawing.Size(320, 240);
            //this.mine.TabIndex = 2;
            //this.mine.Text = "mine";
            //this.mine.VideoSource = null;
            //this.mine.NewFrame += sender_Handle;

            //this.Controls.Add(this.mine);

        }
        
        
        #endregion

        private System.Windows.Forms.Button shot_u;
        private System.Windows.Forms.PictureBox yours;
        private System.Windows.Forms.Button shot_m;
        private System.Windows.Forms.PictureBox mine;
    }
}