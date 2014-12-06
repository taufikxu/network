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
        //将对应项移除。一般用于
        void RemoveAccordItem(int numb)
        {
            chat_flag_notprocess.RemoveAt(numb);
            chat_flag_occupied.RemoveAt(numb);
            chat_flag_setbyme.RemoveAt(numb);

            chat_receive.RemoveAt(numb);
            chat_send.RemoveAt(numb);
            chat_thread.RemoveAt(numb);
            chat_tcp.RemoveAt(numb);
            
        }

        //对整个工程进行初始化或关闭
        protected void InitApp()
        {
            server_adress = "166.111.180.60";
            server_port = 8000;
            listen_port = 8000;

            InitTcp();
            InitThread();
        }
        protected void CloseApp()
        {

            CloseMainThread();

            for (int i = 0; i < chat_thread.Count; i++)
                CloseOneThread(i);
            foreach (TcpClient tcp in chat_tcp)
                CloseOneTcp(tcp);

            CloseMainTcp();
        }


        //if successful, return "ok", else return the error code
        protected string LogOut(string name)
        {
            string result = CommunicateWithServer("logout"+name);
            if (result == "loo")
                return "ok";
            else
                return result;
        }

        //if successful, return "ok", else return the Server response,"Incorrect possword"
        protected string LogIn(string name, string code)
        {
            string result = CommunicateWithServer(name + "_" + code);
            if (result == "lol")
                return "ok";
            else
                return result;
        }

        //if online, return "xxx.xxx.xxx.xx", else return "off", when error, return error code
        protected string CheckFriend(string name)
        {
            string result = CommunicateWithServer("q" + name);
            if (result == "n")
                return "off";
            else
                return result;
        }


    }
}
