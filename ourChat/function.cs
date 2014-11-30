using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.IO;

namespace ourChat
{
    partial class mainWindow
    {
        static void init_listener()
        {
            try
            {
                if(flag_tcp_listened == true)
                    tListener.Stop();
                tListener = new TcpListener(listen_port);
                tListener.Start();
                flag_tcp_listened = true;
            }
            catch(Exception e)
            {
                if (e.Message == "通常每个套接字地址(协议/网络地址/端口)只允许使用一次。")
                {
                    if (server_port == 65535)
                    {
                        flag_tcp_listened = false;
                    }
                    listen_port++;
                    init_listener();
                }
                else
                {
                    MessageBox.Show(e.Message);
                    flag_tcp_connected = false;

                }
            }
        }
        static void init_tcp()
        {
            try
            {
                tClient = new TcpClient(server_adress, server_port);
                netStr = tClient.GetStream();
                strReader = new StreamReader(netStr);

                tClient.ReceiveTimeout = 1000;
                flag_tcp_connected = true;

                init_listener();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                flag_tcp_connected = false;
            }
        }

        static void close_tcp()
        {
            try
            {
                if (flag_tcp_connected == false)
                    return;

                tClient.Close();
                netStr.Close();
                strReader.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        static string command_message(string command)
        {
            if (flag_tcp_connected == false)
                return "not ok";

            try
            {
                if (command == null || command.Length == 0)
                    return "not ok";

                Byte[] temp_byte = System.Text.Encoding.ASCII.GetBytes(command.ToCharArray());
                netStr.Write(temp_byte, 0, temp_byte.Length);
                return "ok";
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return "not ok";
            }
        }
    }
}
