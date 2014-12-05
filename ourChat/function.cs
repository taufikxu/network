using System;
using System.Collections.Generic;
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
    partial class mainWindow
    {
        static void InitListener()
        {
            try
            {
                if(flag_tcp_listened == true)
                    tListener.Stop();

                tListener = new TcpListener(IPAddress.Any, listen_port);
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
                server_tcp = new TcpClient(server_adress, server_port);
                netstr_server = server_tcp.GetStream();
                strReader_server = new StreamReader(netstr_server);

                server_tcp.ReceiveTimeout = 1000;

                InitListener();

                flag_tcp_connected = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                flag_tcp_connected = false;
            }
        }
        static void InitThread()
        {
            listen_thread = new Thread(new ThreadStart(ListenThread));
            chat_tcp = new List<TcpClient>(0);
            chat_thread = new List<Thread>(0);
            chat_notprocess = new List<bool>(0);
            chat_occupied = new List<bool>(0);
            chat_receive = new List<string>(0);

            flag_listening = true;
            listen_thread.Start();
            
            for (int i = 0; i < chat_notprocess.Count; i++)
                chat_notprocess[i] = false;

            for (int i = 0; i < chat_occupied.Count; i++)
                chat_occupied[i] = false;
        }
        static void CloseOneTcp(TcpClient tcp)
        {
            try
            {
                if (tcp == null)
                    return;
                tcp.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                CloseOneTcp(tcp);
            }
        }
        static void CloseMainTcp()
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
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                CloseMainTcp();
            }
        }
        static void CloseOneThread(int num_toend)
        {
            try
            {
                chat_occupied[num_toend] = false;
                //while (chat_thread[num_toend].IsAlive) ;
                
                chat_thread[num_toend].Abort();
                chat_thread[num_toend].Join();

                chat_occupied.RemoveAt(num_toend);
                chat_thread.RemoveAt(num_toend);
                chat_tcp.RemoveAt(num_toend);

                chat_receive.RemoveAt(num_toend);
            }
            catch
            {
                
            }
        }
        static void CloseMainThread()
        {
            try
            {
                flag_listening = false;
                listen_thread.Abort();
                listen_thread.Join();
                return;
            }
            catch
            {

            }
        }

        static void RemoveAccordItem(int numb)
        {
            chat_notprocess.RemoveAt(numb);
            chat_occupied.RemoveAt(numb);
            chat_receive.RemoveAt(numb);
        }

        static string ReadFromStream(StreamReader strReader, int length=2048)
        {
            if (strReader == null)
                return "";

            char[] buffer = new char[length];

          
            try
            {
                strReader.Read(buffer, 0, buffer.Length);
                return (new string(buffer)).Replace("\0", "");
            }
            catch
            {
                return "";
            }

        }

        static void InitApp()
        {
            InitTcp();
            InitThread();
        }
        static void CloseApp()
        {
            CloseMainThread();

            for (int i = 0; i < chat_thread.Count; i++)
                CloseOneThread(i);
            foreach (TcpClient tcp in chat_tcp)
                CloseOneTcp(tcp);

            CloseMainTcp();
            chat_occupied = null;
            chat_notprocess = null;
        }

        //找到未处理的线程进行处理。
        static int AskNewThread()
        {
            int counter = chat_notprocess.Count-1;
            for (; counter >= 0;counter-- )
            {
                if (chat_notprocess[counter] == false)
                    continue;
                else
                    return counter;
            }
            return -1;
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
                netstr_server.Write(temp_byte, 0, temp_byte.Length);
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
                string result = "";
                while (result.Length == 0)
                {
                    strReader_server.Read(buffer_char, 0, buffer_char.Length);
                    result = (new string(buffer_char)).Replace("\0", "");
                }
                return result;
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

        static void ChatWithFriend()
        {
            int numb = AskNewThread();
            if (numb == -1)
                return;

            TcpClient chatTcp = chat_tcp[numb];
            NetworkStream chatNtr = chatTcp.GetStream();
            StreamReader chatReader = new StreamReader(chatNtr);

            string check = ReadFromStream(chatReader);
            if(check == "" || check.Substring(0, 11)!= "c"+my_name)
            {
                
            }

            while(chat_occupied[numb] == true)
            {
                
            }

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

        //the main task of listening
        static void ListenThread()
        {
            TcpClient chat_obj;
            Thread chat_thr;
            
            while(flag_listening == true)
            {
                if(! tListener.Pending())
                    continue;
                InitChatForm();

                chat_obj = tListener.AcceptTcpClient();
                //chat_obj = tClient;
                chat_obj.ReceiveTimeout = 500;
                chat_occupied.Add(true);
                chat_notprocess.Add(true);
                chat_tcp.Add(chat_obj);

                chat_thr = new Thread(new ThreadStart(ChatWithFriend));
                chat_thread.Add(chat_thr);
                chat_thr.Start();

                chat_receive.Add("");

                //flag_listen = false;
            }

            tListener.Stop();
        }

        static void InitChatForm()
        {
            return;
        }
    }
}
