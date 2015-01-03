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
        void InitThread()
        {
            listen_thread = new Thread(new ThreadStart(ListenThread));
            chat_tcp = new List<TcpClient>(0);
            chat_thread = new List<Thread>(0);

            chat_flag_notprocess = new List<bool>(0);
            chat_flag_occupied = new List<bool>(0);
            chat_flag_setbyme = new List<bool>(0);

            chat_receive = new List<string>(0);
            chat_send = new List<string>(0);

            flag_listening = true;
            listen_thread.Start();

            Thread mainThread;
            mainThread = new Thread(new ParameterizedThreadStart(this.UDPListening));
            mainThread.SetApartmentState(ApartmentState.STA);
            mainThread.Start();

        }
        void CloseOneThread(int num_toend)
        {
            try
            {
                chat_flag_occupied[num_toend] = false;
                //while (chat_thread[num_toend].IsAlive) ;

                chat_thread[num_toend].Abort();
                chat_thread[num_toend].Join();

                
                chat_flag_notprocess.RemoveAt(num_toend);
                chat_flag_setbyme.RemoveAt(num_toend);
                chat_thread.RemoveAt(num_toend);
                chat_tcp.RemoveAt(num_toend);
                chat_flag_occupied.RemoveAt(num_toend);

                chat_receive.RemoveAt(num_toend);
                chat_send.RemoveAt(num_toend);
            }
            catch
            {

            }
        }
        void CloseMainThread()
        {
            try
            {
                flag_listening = false;
                listen_thread.Abort();
                listen_thread.Join();
                return;
            }
            catch
            {

            }
        }


        //找到未处理的线程进行处理。
        int AskNewThread()
        {
            int counter = chat_flag_notprocess.Count - 1;
            for (; counter >= 0; counter--)
            {
                if (chat_flag_notprocess[counter] == false)
                    continue;
                else
                {
                    chat_flag_notprocess[counter] = false;
                    return counter;
                }

            }
            return -1;
        }
    }
}
