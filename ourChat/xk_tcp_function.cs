using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ourChat
{
    partial class mainWindow
    {
        //从流中读取
        protected string ReadFromStream(StreamReader strReader, int length = 2048)
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

        // input the message and output the response
        protected string CommunicateWithServer(string message)
        {
            if (flag_tcp_connected == false)
                return error_code[error_not_connect];
            if (server_tcp.Connected == false)
                InitClient();

            string result = SendMessageTo(netstr_server, message);
            if (result != "ok")
                return result;

            return GetResponse(strReader_server);
        }

        // return the response of the server, or error code
        public string GetResponse(StreamReader str)
        {
            try
            {
                Char[] buffer_char = new Char[2048];
                string result = "";
                while (result.Length == 0)
                {
                    str.Read(buffer_char, 0, buffer_char.Length);
                    result = (new string(buffer_char)).Replace("\0", "");
                }
                return result;
            }
            catch
            {
                //MessageBox.Show(e.Message);
                return error_code[error_exceed_timelimit];
            }
        }

        //return ok if successful sent, else return error code
        public string SendMessageTo(NetworkStream ntwStr, string command)
        {
            if (flag_tcp_connected == false)
                return error_code[error_not_connect];

            try
            {
                if (command == null || command.Length == 0)
                    return error_code[error_inv_input];

                Byte[] temp_byte = System.Text.Encoding.UTF8.GetBytes(command.ToCharArray());
                ntwStr.Write(temp_byte, 0, temp_byte.Length);
                return "ok";
            }
            catch
            {
                return error_code[error_exception_error];
            }
        }
    }
}
