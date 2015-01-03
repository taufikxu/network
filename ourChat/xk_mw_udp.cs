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
    partial class mainWindow
    {
        byte udp_numb;
        public delegate void udpDelegate(videoForm form);
        void udpShowForm(videoForm form)
        {
            form.Show();
        }

        void UDPListening(object no_use)
        {
            int port = 10000;
            UdpClient u_listener = new UdpClient(port);
            IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, port);

            udpDelegate udpShow = new udpDelegate(udpShowForm);

            while (flag_listening)
            {
                if (u_listener.Client.Available == 0)
                    continue;
               
                byte[] data = u_listener.Receive(ref ipendpoint);
                UdpClient udp = new UdpClient(ipendpoint.Address.ToString(), 10000 + data[0]);
                udp_numb++;
                byte listen = udp_numb;
                byte[] s_data = new byte[] { listen };
                udp.Send(s_data, 1);

                udp.Close();

                videoForm video = new videoForm(listen, data[0], ipendpoint.Address.ToString());
                this.Invoke(udpShow, new object[] { video });
                //video.Show();
            }
        }

        void SetupVideo(string ip, string name)
        {
            UdpClient udp = new UdpClient(ip, 10000);
            udpDelegate udpShow = new udpDelegate(udpShowForm);

            udp_numb++;
            int listen = udp_numb;
            byte[] t = new byte[] { udp_numb };
            udp.Send(t, 1);
            UdpClient listener = new UdpClient(10000 + listen);

            int counter = 0;
            while (counter < 10000) 
            {
                if (listener.Client.Available == 0)
                {
                    counter++;
                    continue;
                }
                    

                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 0);
                byte[] numb = listener.Receive(ref ipEnd);

                listener.Close();

                videoForm video = new videoForm(listen, numb[0], ip);
                video.Show();
                break;
            }
            if(counter == 10000)
            {
                MessageBox.Show("无法发起连接");
            }
        }

        
    }
}
