using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using System.IO;

namespace ourChat
{
    partial class mainWindow
    {
        /// <summary>
        /// variables for tcp connection, including listener, tcpClient and etc.
        /// </summary>
        static string server_adress = "166.111.180.60";
        static int server_port = 8000;
        static int listen_port = 8000;

        static bool flag_tcp_connected;
        static TcpClient tClient;
        static NetworkStream netStr;
        static StreamReader strReader;

        static bool flag_tcp_listened;
        static TcpListener tListener;

        //thread 
        static Thread listen_thread;
        static TcpClient[] chat_tcp;
        static bool[] chat_occupied;
        static int chat_cap;
        static int chat_used;

        /// <summary>
        /// error code for debuging and messagebox
        /// </summary>
        static string[] error_code = new string[] { "error not connected", "error invalide input", "error exception", "error exceed time limited" };
        const int error_not_connect = 0;
        const int error_inv_input = 1;
        const int error_exception_error = 2;
        const int error_exceed_timelimit = 3;

    }
}
