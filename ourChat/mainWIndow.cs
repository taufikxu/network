using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;


namespace ourChat
{
    public partial class mainWindow : Form
    {


        public static TreeNode basis;//好友列表的根节点
        public static TreeNode[] friends;//好友节点数组

        List<string> friend_list;

        public mainWindow()
        {
            InitializeComponent();
            
            InitApp();

            udp_numb = 0;
            friend_list = new List<string>();
            chatForm_list = new List<chatForm>(0);
            chatGroup_list = new List<chatGroupWindow>(0);

        }

        private void mainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.ActiveControl == textBox_search)
                {
                    pictureBox3_Click(sender, e);
                }
            }
        }

    }
}
