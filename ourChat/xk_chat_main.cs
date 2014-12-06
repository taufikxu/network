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
    partial class mainWindow
    {
        //聊天的主程序。
        void ChatWithFriend()
        {
            int numb = AskNewThread();
            if (numb == -1)
                return;

            TcpClient chatTcp = chat_tcp[numb];
            NetworkStream chatNtr = chatTcp.GetStream();
            StreamReader chatReader = new StreamReader(chatNtr);

            string check = ReadFromStream(chatReader);
            string store;
            string chat_name = "";

            if (CheckInfo(check, chatTcp, chatNtr, numb,ref chat_name) == false)
                return;

            chatForm myForm = new chatForm(ref netstr_server, this, 0, chat_name);
            ProcessDelegate showF = new ProcessDelegate(ShowForm);
            ProcessDelegate addTxt = new ProcessDelegate(AddContent);
            this.Invoke(showF, new object[] { myForm });

            while (chat_flag_occupied[numb] == true)
            {
                store = ReadFromStream(chatReader);
                if (store == "")
                    continue;

                chat_receive[numb] += ProcessString(store);
                this.Invoke(addTxt, new object[] { myForm });
            }
        }



        //监听的主程序
        void ListenThread()
        {
            TcpClient chat_obj;
            Thread chat_thr;

            while (flag_listening == true)
            {
                if (!tListener.Pending())
                    continue;

                chat_obj = tListener.AcceptTcpClient();
                chat_obj.ReceiveTimeout = 500;

                chat_flag_occupied.Add(true);
                chat_flag_notprocess.Add(true);
                chat_flag_setbyme.Add(false);
                chat_tcp.Add(chat_obj);
                chat_receive.Add("");
                chat_send.Add("");

                chat_thr = new Thread(new ThreadStart(ChatWithFriend));
                chat_thread.Add(chat_thr);
                chat_thr.Start();

            }

            tListener.Stop();
        }



        //发起聊天的主程序
        string SetupChat(string serv_addr, string temp_name, int port = 8000)
        {
            TcpClient active_tcp = null;
            while (port < 65535)
            {
                active_tcp = new TcpClient(serv_addr, port);
                active_tcp.ReceiveTimeout = 500;

                NetworkStream temp_netstr = (active_tcp.GetStream());
                StreamReader temp_reader = new StreamReader(temp_netstr);

                SendMessageTo(temp_netstr, "c" + temp_name + "f" + my_name);
                string result = GetResponse(temp_reader);

                if (result == "a" + temp_name)
                    break;

                port++;
            }
            if (port == 65535)
                return error_code[error_not_online];

            Thread temp_thread = new Thread(new ThreadStart(ChatWithFriend));
            chat_flag_notprocess.Add(true);
            chat_flag_occupied.Add(true);
            chat_flag_setbyme.Add(true);
            chat_receive.Add("");
            chat_send.Add(temp_name);
            chat_tcp.Add(active_tcp);
            chat_thread.Add(temp_thread);

            temp_thread.Start();
            return "ok";
        }



        void ShowForm(chatForm toShow)
        {
            toShow.Show();
        }

        void AddContent(chatForm cform)
        {
            cform.chatShow.Text += chat_receive[cform.sequence];
        }


    }
}
