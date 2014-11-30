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
using System.Net.Sockets;


namespace ourChat
{
    public partial class mainWindow : Form
    {

        public mainWindow()
        {
            InitializeComponent();
            TcpListener tlis = new TcpListener(8000);
            tlis.Start();

            init_tcp();            
        }
    }
}
