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
        string ProcessString(string str)
        {
            
            return "mes"+str;
        }

        void ReceiveFile()
        {
            return;
        }

        void SendFile(NetworkStream netStream, string filename)
        {

            return;
        }
    }
}
