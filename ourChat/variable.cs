using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.IO;

namespace ourChat
{
    partial class mainWindow
    {
        static string server_adress = "166.111.180.60";
        static int server_port = 8000;
        static int listen_port = 8000;

        static bool flag_tcp_connected;
        static TcpClient tClient;
        static NetworkStream netStr;
        static StreamReader strReader;

        static bool flag_tcp_listened;
        static TcpListener tListener;

    }
}
