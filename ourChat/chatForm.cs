using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ourChat
{
    public partial class chatForm : Form
    {
        private NetworkStream netStream;
        private string my_name;
        private string chat_name;
        private mainWindow parent_window;

        public int sequence;
        public chatForm(ref NetworkStream send_stream, mainWindow parent, int numb, string cname)
        {
            InitializeComponent_chatForm();

            parent_window = parent;

            netStream = send_stream;
            sequence = numb;
            chat_name = cname;

            my_name = parent.my_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = chatBox.Text;
            chatBox.Text = "";

            parent_window.SendMessageTo(netStream, temp);
        }
    }
}
