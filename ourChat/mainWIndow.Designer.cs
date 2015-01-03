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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.tree_showfriends = new System.Windows.Forms.TreeView();
            this.chatstart = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_addf = new System.Windows.Forms.Button();
            this.button_deletef = new System.Windows.Forms.Button();
            this.button_chatg = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.发起对话ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.touxiang = new System.Windows.Forms.PictureBox();
            this.label_touxiang = new System.Windows.Forms.Label();
            this.videoButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touxiang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // tree_showfriends
            // 
            this.tree_showfriends.BackColor = System.Drawing.Color.LightCyan;
            this.tree_showfriends.Cursor = System.Windows.Forms.Cursors.Default;
            this.tree_showfriends.Font = new System.Drawing.Font("隶书", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tree_showfriends.ForeColor = System.Drawing.Color.Black;
            this.tree_showfriends.Location = new System.Drawing.Point(16, 194);
            this.tree_showfriends.Name = "tree_showfriends";
            this.tree_showfriends.Size = new System.Drawing.Size(139, 306);
            this.tree_showfriends.TabIndex = 3;
            this.tree_showfriends.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_showfriends_AfterSelect);
            this.tree_showfriends.DoubleClick += new System.EventHandler(this.tree_showfriends_DoubleClick);
            // 
            // chatstart
            // 
            this.chatstart.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chatstart.Location = new System.Drawing.Point(171, 322);
            this.chatstart.Margin = new System.Windows.Forms.Padding(2);
            this.chatstart.Name = "chatstart";
            this.chatstart.Size = new System.Drawing.Size(85, 26);
            this.chatstart.TabIndex = 4;
            this.chatstart.Text = "发起会话";
            this.chatstart.UseVisualStyleBackColor = true;
            this.chatstart.Click += new System.EventHandler(this.chatstart_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(121, 149);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(100, 21);
            this.textBox_search.TabIndex = 7;
            this.textBox_search.Text = "输入要查找的学号";
            this.textBox_search.Click += new System.EventHandler(this.textBox_search_Click);
            // 
            // button_addf
            // 
            this.button_addf.BackColor = System.Drawing.Color.Transparent;
            this.button_addf.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_addf.Location = new System.Drawing.Point(171, 259);
            this.button_addf.Name = "button_addf";
            this.button_addf.Size = new System.Drawing.Size(85, 26);
            this.button_addf.TabIndex = 9;
            this.button_addf.Text = "添加好友";
            this.button_addf.UseVisualStyleBackColor = false;
            this.button_addf.Click += new System.EventHandler(this.button_addf_Click);
            // 
            // button_deletef
            // 
            this.button_deletef.BackColor = System.Drawing.Color.Transparent;
            this.button_deletef.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_deletef.Location = new System.Drawing.Point(171, 291);
            this.button_deletef.Name = "button_deletef";
            this.button_deletef.Size = new System.Drawing.Size(85, 25);
            this.button_deletef.TabIndex = 11;
            this.button_deletef.Text = "删除好友";
            this.button_deletef.UseVisualStyleBackColor = false;
            this.button_deletef.Click += new System.EventHandler(this.button_deletef_Click);
            // 
            // button_chatg
            // 
            this.button_chatg.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_chatg.Location = new System.Drawing.Point(171, 383);
            this.button_chatg.Name = "button_chatg";
            this.button_chatg.Size = new System.Drawing.Size(85, 28);
            this.button_chatg.TabIndex = 12;
            this.button_chatg.Text = "发起群聊";
            this.button_chatg.UseVisualStyleBackColor = true;
            this.button_chatg.Click += new System.EventHandler(this.button_chatg_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发起对话ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 发起对话ToolStripMenuItem
            // 
            this.发起对话ToolStripMenuItem.Name = "发起对话ToolStripMenuItem";
            this.发起对话ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.发起对话ToolStripMenuItem.Text = "发起对话";
            // 
            // touxiang
            // 
            this.touxiang.BackColor = System.Drawing.Color.Transparent;
            this.touxiang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.touxiang.ContextMenuStrip = this.contextMenuStrip1;
            this.touxiang.Location = new System.Drawing.Point(43, 24);
            this.touxiang.Name = "touxiang";
            this.touxiang.Size = new System.Drawing.Size(88, 76);
            this.touxiang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.touxiang.TabIndex = 13;
            this.touxiang.TabStop = false;
            this.touxiang.Click += new System.EventHandler(this.touxiang_Click);
            // 
            // label_touxiang
            // 
            this.label_touxiang.AutoSize = true;
            this.label_touxiang.BackColor = System.Drawing.Color.Transparent;
            this.label_touxiang.Location = new System.Drawing.Point(50, 58);
            this.label_touxiang.Name = "label_touxiang";
            this.label_touxiang.Size = new System.Drawing.Size(77, 12);
            this.label_touxiang.TabIndex = 14;
            this.label_touxiang.Text = "双击设置头像";
            // 
            // videoButton
            // 
            this.videoButton.Font = new System.Drawing.Font("华文楷体", 12F);
            this.videoButton.Location = new System.Drawing.Point(171, 351);
            this.videoButton.Margin = new System.Windows.Forms.Padding(2);
            this.videoButton.Name = "videoButton";
            this.videoButton.Size = new System.Drawing.Size(85, 26);
            this.videoButton.TabIndex = 15;
            this.videoButton.Text = "发起视频";
            this.videoButton.UseVisualStyleBackColor = true;
            this.videoButton.Click += new System.EventHandler(this.videoButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(251, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(16, 149);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 39);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(227, 149);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 29);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(350, 561);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.videoButton);
            this.Controls.Add(this.label_touxiang);
            this.Controls.Add(this.touxiang);
            this.Controls.Add(this.button_chatg);
            this.Controls.Add(this.button_deletef);
            this.Controls.Add(this.button_addf);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.chatstart);
            this.Controls.Add(this.tree_showfriends);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainWindow";
            this.Text = "mainWindow";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainWindow_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.touxiang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tree_showfriends;
        private System.Windows.Forms.Button chatstart;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_addf;
        private System.Windows.Forms.Button button_deletef;
        private System.Windows.Forms.Button button_chatg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 发起对话ToolStripMenuItem;
        private System.Windows.Forms.PictureBox touxiang;
        private System.Windows.Forms.Label label_touxiang;
        private System.Windows.Forms.Button videoButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        
    }
}

