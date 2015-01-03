using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ourChat
{
    public partial class IP_Port : Form
    {
        public string ip;
        public int port;
        public bool flag;
        public IP_Port()
        {
            InitializeComponent();
            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckIP();
        }

        private void IP_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                CheckIP();
            }
            else if(e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void CheckIP()
        {
            try
            {
                IPAddress IPadress;
                ip = IP.Text;
                port = Convert.ToInt32(Port.Text);
                if (IPAddress.TryParse(ip, out IPadress))
                {
                    if (port > 1000)
                    {
                        flag = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("端口号输入不合法！");
                        Port.Text = "";
                        Port.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("IP地址输入不合法！");
                    IP.Text = "";
                    Port.Text = "";
                    IP.Focus();
                }
            }
            catch 
            {
                MessageBox.Show("输入不合法！");
                IP.Text = "";
                Port.Text = "";
                IP.Focus();
            }   
        }
    }
}
