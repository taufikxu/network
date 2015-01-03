using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    partial class chatForm
    {
        string ProcessString(string str)
        {
            return str.Substring(3);
        }

        public void ReceiveFile(StreamReader str, string filename, int len)
        {
            //filename += "1";
            BinaryReader br = new BinaryReader(myTcp.GetStream());
            FileStream fs = File.Open(filename, FileMode.Create);

            byte[] temp = new byte[2048];
            int count = 0;
            int step;
            int break_thre = 0;

            while (count < len && chat_flag && break_thre < 100)
            {
                try
                {
                    step = br.Read(temp, 0, 2048);
                    count += step;
                    fs.Write(temp, 0, step);
                    parent_window.SendMessageTo(myTcp.GetStream(), count.ToString());
                }
                catch { break_thre++; }
            }
            fs.Close();

            return;
        }
        public void SendFile(NetworkStream netStream, string filename, bool image = false)
        {
            StreamReader temp_reader = new StreamReader(netStream);
            FileStream fstream = File.OpenRead(filename);
            BinaryReader br = new BinaryReader(fstream);

            byte[] buffer = new byte[2048];

            main_function_flag = false;
            if (!image)
                parent_window.SendMessageTo(netStream, "fil" + "\r" + filename + "\r" + "len" + "\r" + fstream.Length.ToString() + "\r");

            while (true && chat_flag)
            {
                string result = parent_window.ReadFromStream(temp_reader);
                if (result == "ok")
                {
                    int counter = 0;
                    int step;
                    while (counter < fstream.Length)
                    {
                        step = fstream.Read(buffer, 0, 2048);
                        netStream.Write(buffer, 0, step);
                        netStream.Flush();
                        counter += step;

                        while (true && chat_flag)
                        {
                            string result_rec = parent_window.ReadFromStream(temp_reader);
                            if (result_rec == counter.ToString())
                                break;
                        }
                    }
                    break;
                }
                if (result == "Nok")
                {
                    MessageBox.Show("对方拒绝接收！");
                }

            }
            fstream.Close();
            main_function_flag = true;
            return;
        }


    }
}
