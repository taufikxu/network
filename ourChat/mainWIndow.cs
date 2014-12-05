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

        public mainWindow()
        {
            InitializeComponent();

            InitApp();
            //chat_notprocess.Add(true);
            //chat_occupied.Add(true);
            //chat_tcp.Add(tClient);

            //Byte[] temp_byte = System.Text.Encoding.UTF8.GetBytes("2012011514_net2014");
            //netStr.Write(temp_byte, 0, temp_byte.Length);
            string result = CommunicateWithServer("logout2012011514");

            //while (true) ;

        }

        private void strShow_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseApp();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }

    }
}
