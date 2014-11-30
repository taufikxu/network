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
using System.IO;


namespace ourChat
{
    public partial class mainWindow : Form
    {

        public mainWindow()
        {
            InitializeComponent();
            TcpListener tlis = new TcpListener(8000);
            InitTcp();

            string result = LogIn("2012011514", "net2014");
            result = CheckFriend("2012011514");
            result = LogOut("2012011514");

            CloseTcp();

        }
    }
}
