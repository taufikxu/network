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
        static void InitListener()
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
                    InitListener();
                }
                else
                {
                    MessageBox.Show(e.Message);
                    flag_tcp_connected = false;

                }
            }
        }
        static void InitTcp()
        {
            try
            {
                tClient = new TcpClient(server_adress, server_port);
                netStr = tClient.GetStream();
                strReader = new StreamReader(netStr);

                tClient.ReceiveTimeout = 1000;

                InitListener();

                flag_tcp_connected = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                flag_tcp_connected = false;
            }
        }
        static void CloseTcp()
        {
            
            try
            {
                if (flag_tcp_connected == false)
                    return;

                tClient.Close();
                netStr.Close();
                strReader.Close();

                tListener.Stop();

                flag_tcp_connected = false;
                flag_tcp_listened = false;
            }
            catch
            {
                CloseTcp();
            }
        }

        //return ok if successful sent, else return error code
        static string CommandMessage(string command)
        {
            if (flag_tcp_connected == false)
                return error_code[error_not_connect];

            try
            {
                if (command == null || command.Length == 0)
                    return error_code[error_inv_input];

                Byte[] temp_byte = System.Text.Encoding.UTF8.GetBytes(command.ToCharArray());
                netStr.Write(temp_byte, 0, temp_byte.Length);
                return "ok";
            }
            catch
            {
                return error_code[error_exception_error];
            }
        }

        // return the response of the server, or error code
        static string GetResponse()
        {
            try
            {
                Char[] buffer_char = new Char[2048];
                strReader.Read(buffer_char, 0, buffer_char.Length);

                return (new string(buffer_char)).Replace("\0", "");
            }
            catch
            {
                return error_code[error_exceed_timelimit];
            }
        }

        // input the message and output the response
        static string CommunicateWithServer(string message)
        {
            if (flag_tcp_connected == false)
                return error_code[error_not_connect];

            string result = CommandMessage(message);
            if(result != "ok")
                return result;

            return GetResponse();
        }

        //if successful, return "ok", else return the error code
        static string LogOut(string name)
        {
            string result = CommunicateWithServer("logout"+name);
            if (result == "loo")
                return "ok";
            else
                return result;
        }

        //if successful, return "ok", else return the Server response,"Incorrect possword"
        static string LogIn(string name, string code)
        {
            string result = CommunicateWithServer(name + "_" + code);
            if (result == "lol")
                return "ok";
            else
                return result;
        }

        //if online, return "xxx.xxx.xxx.xx", else return "off", when error, return error code
        static string CheckFriend(string name)
        {
            string result = CommunicateWithServer("q" + name);
            if (result == "n")
                return "off";
            else
                return result;
        }
    }
}
