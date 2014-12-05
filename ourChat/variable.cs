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
        /// my information
        /// </summary>
        static string my_name;


        /// <summary>
        /// variables for tcp connection, including listener, tcpClient and etc.
        /// </summary>
        static string server_adress = "166.111.180.60";
        static int server_port = 8000;
        static int listen_port = 8000;

        static bool flag_tcp_connected;
        static TcpClient server_tcp;
        static NetworkStream netstr_server;
        static StreamReader strReader_server;

        static bool flag_tcp_listened;
        static TcpListener tListener;

        //thread 
        static Thread listen_thread;
        static bool flag_listening;
        static List<Thread> chat_thread;
        static List<TcpClient> chat_tcp;
        static List<bool> chat_occupied;
        static List<bool> chat_notprocess;
        static List<string> chat_receive;

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
