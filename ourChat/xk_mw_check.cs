using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ourChat
{
    partial class mainWindow
    {
        private bool CheckInfo(string check, TcpClient chatTcp, NetworkStream chatNtr, int sequence, ref string chat_name)
        {

            if (chat_flag_setbyme[sequence] == false)
            {
                if (check == "" || check.Length < 22 || check.Substring(0, 11) != "c" + my_name)
                {
                    SendMessageTo(chatNtr, "n" + my_name);
                    CloseOneTcp(chatTcp);
                    RemoveAccordItem(sequence);
                    return false;
                }

                chat_name = check.Substring(12);
                if (chat_name.Length != 10 || check[11] != 'f')
                {
                    SendMessageTo(chatNtr, "n" + my_name);
                    CloseOneTcp(chatTcp);
                    RemoveAccordItem(sequence);
                    return false;
                }

                SendMessageTo(chatNtr, "a" + my_name);
            }
            else
            {
                chat_name = chat_send[sequence];
            }
            return true;
        }

        private int CheckQunInfo(string check, TcpClient chatTcp, NetworkStream chatNtr, int sequence, ref string chat_name)
        {
            if (chat_flag_setbyme[sequence] == false)
            {
                if (check == "" || check.Length < 23 || check.Substring(1, 10) != my_name)
                    return -1;

                if(check.Substring(0,1) != "q")
                    return -1;

                chat_name = check.Substring(13);
                if (chat_name.Length != 10 || check[11] != 'f')
                    return -1;

                SendMessageTo(chatNtr, "a" + my_name);
                return Convert.ToInt32(check.Substring(22, 1));
            }
            else
            {
                chat_name = chat_send[sequence];
                return -1;
            }
        }


        
    }
}
