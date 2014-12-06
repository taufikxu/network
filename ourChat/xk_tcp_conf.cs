using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace ourChat
{
    public partial class mainWindow
    {
        //初始化或关闭对应的TCP连接
        void InitListener()
        {
            try
            {
                if (flag_tcp_listened == true)
                    tListener.Stop();

                tListener = new TcpListener(IPAddress.Any, listen_port);
                tListener.Start();

                flag_tcp_listened = true;
            }
            catch (Exception e)
            {
                if (e.Message == "通常每个套接字地址(协议/网络地址/端口)只允许使用一次。")
                {
                    if (server_port == 65535)
                    {
                        flag_tcp_listened = false;
                    }
                    listen_port++;
                    InitListener();
                }
                else
                {
                    MessageBox.Show(e.Message);
                    flag_tcp_connected = false;
                }
            }
        }
        void InitClient()
        {
            try
            {
                server_tcp = new TcpClient(server_adress, server_port);
                netstr_server = server_tcp.GetStream();
                strReader_server = new StreamReader(netstr_server);

                server_tcp.ReceiveTimeout = 1000;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                flag_tcp_connected = false;
            }
        }
        void InitTcp()
        {
            flag_tcp_connected = true;
            InitClient();
            InitListener();
        }
        void CloseOneTcp(TcpClient tcp)
        {
            try
            {
                if (tcp == null)
                    return;
                tcp.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                CloseOneTcp(tcp);
            }
        }
        void CloseMainTcp()
        {
            try
            {
                if (flag_tcp_connected == false)
                    return;

                server_tcp.Close();
                netstr_server.Close();
                strReader_server.Close();

                tListener.Stop();

                flag_tcp_connected = false;
                flag_tcp_listened = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                CloseMainTcp();
            }
        }


       
       
    }
}
