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
            my_name = "2012011514";

            InitApp();

        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseApp();
        }

    }
}
