using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;

namespace ourChat
{
    partial class mainWindow
    {
        /// <summary>
        /// my information
        /// </summary>
        public string my_name;


        /// <summary>
        /// variables for tcp connection, including listener, tcpClient and etc.
        /// </summary>
        string server_adress;
        int server_port;
        int listen_port;
        bool flag_cancel;


        bool flag_tcp_connected;
        TcpClient server_tcp;
        NetworkStream netstr_server;
        StreamReader strReader_server;

        bool flag_tcp_listened;
        TcpListener tListener;

        //thread 
        Thread listen_thread;
        bool flag_listening;
        List<Thread> chat_thread;
        List<TcpClient> chat_tcp;
        public List<bool> chat_flag_occupied;
        List<bool> chat_flag_notprocess;
        List<bool> chat_flag_setbyme;
        List<string> chat_receive;
        List<string> chat_send;

        List<chatForm> chatForm_list;
        List<chatGroupWindow> chatGroup_list;

        /// <summary>
        /// error code for debuging and messagebox
        /// </summary>
        static public string[] error_code = new string[] { "error not connected", "error invalide input", "error exception", "error exceed time limited", "error not online or not reachable" };
        public const int error_not_connect = 0;
        public const int error_inv_input = 1;
        public const int error_exception_error = 2;
        public const int error_exceed_timelimit = 3;
        public const int error_not_online = 4;

        ///<summary>
        ///信息的前缀
        ///</summary>
        static string[] chat_prefix = new string[] { "mes", "fil", "pic", "emo" };
        const int prefix_mess = 0;
        const int prefix_file = 1;
        const int prefix_pict = 2;
        const int prefix_motion = 3;

        //委托信息
        public delegate void ProcessDelegate(chatForm aa);
        public delegate void ProcessDelegate_group(chatGroupWindow aa);
    
        
    }
}
