using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace ourChat
{
    public partial class chatGroupWindow : Form
    {
        List<string> list_member;
        List<TcpClient> list_tcp;

        public bool flag_chat;
        bool flag_server;
        mainWindow parent_window;
        int sequence;
        TcpClient client_tcp;

        public chatGroupWindow()
        {
            InitializeComponent();
        }
        public chatGroupWindow(TcpClient tcp, int seq, mainWindow parent)
        {
            InitializeComponent();
            client_tcp = tcp;
            sequence = seq;
            flag_server = false;
            parent_window = parent;
            flag_chat = true;
            list_member = new List<string>(0);

           
        }
      
        public chatGroupWindow(List<string> member, List<TcpClient> tcps, mainWindow parent, int seq, bool flag_server = false)
        {
            InitializeComponent();
            list_member = member;
            //更新群成员列表
            foreach (string name in list_member)
            {
                if (!listBox_chatgroup.Items.Contains(name))
                    listBox_chatgroup.Items.Add(name);
            }
            list_tcp = tcps;
            parent_window = parent;
            flag_chat = true;
            this.flag_server = flag_server;
            this.sequence = seq;

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chatGroupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag_chat = false;
            if(flag_server)
            {
                foreach(TcpClient tcp in list_tcp)
                {
                    parent_window.SendMessageTo(tcp.GetStream(), "ext");
                }
            }
            else
            {
                parent_window.SendMessageTo(client_tcp.GetStream(), "qit" + sequence.ToString());
            }
        }

        private void chatGroupWindow_Load(object sender, EventArgs e)
        {

            if (flag_server == true)
            {
                //client_tcp = tcps[seq];

                Thread mainThread;
                mainThread = new Thread(new ParameterizedThreadStart(this.ChatServerFunction));
                mainThread.SetApartmentState(ApartmentState.STA);
                mainThread.Start();
            }
            else
            {
                Thread mainThread;
                mainThread = new Thread(new ParameterizedThreadStart(this.ChatFunction));
                mainThread.SetApartmentState(ApartmentState.STA);
                mainThread.Start();
            }
            //int a = 0;
        }

        
    }
}
