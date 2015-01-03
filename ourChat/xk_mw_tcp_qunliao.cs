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
        void SetupQunliao(string[] client) 
        {
            if (client == null)
                return;

            List<string> client_name = new List<string>(0);
            List<TcpClient> client_tcp = new List<TcpClient>(0);
            int count = 1;//序号从1开始，0为服务器端

            client_name.Add(my_name);

            for(int i=0;i<client.Length;i++)
            {
                if (client[i] == my_name)
                    continue;

                if (client[i].Length != 10)
                {
                    MessageBox.Show( client[i] + "为无效用户名", "警告");
                    continue;
                }

                string temp = CheckFriend(client[i]);
                if (temp != "off" && temp.Length > 5 && temp.Substring(0, 5) != "error")
                    client_name.Add(client[i]);
                else if (MessageBox.Show(client[i] + "无法加入到群聊，是否重试？", "警告", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    i--;
                else
                    continue;

                int port = 8000;
                TcpClient active_tcp = null;
                while (port < 8005)
                {
                    try
                    {

                        active_tcp = new TcpClient(temp, port);
                        active_tcp.ReceiveTimeout = 500;

                        NetworkStream temp_netstr = (active_tcp.GetStream());
                        StreamReader temp_reader = new StreamReader(temp_netstr);

                        SendMessageTo(temp_netstr, "q"+ client[i] + "f" + my_name + count.ToString() );
                        string result = ReadFromStream(temp_reader);

                        if (result == "a" + client[i])
                            break;
                        else
                        {
                            if (result == "")
                                port++;
                        }
                    }
                    catch
                    {
                        port++;
                    }
                }
                if (port != 8005)
                {
                    client_tcp.Add(active_tcp);
                    count++;
                }
            }
            if (count == 1)
                return;
            foreach(TcpClient tcp in client_tcp)
            {
                SendMessageTo(tcp.GetStream(), count.ToString());
                foreach(string name in client_name)
                {
                    SendMessageTo(tcp.GetStream(), name);
                }
            }
            chatGroupWindow chat = new chatGroupWindow(client_name, client_tcp, this,0, true);
            chatGroup_list.Add(chat);

            ProcessDelegate_group showF = new ProcessDelegate_group(ShowGroup);

            this.Invoke(showF, new object[] { chat });
        }
    }
}
