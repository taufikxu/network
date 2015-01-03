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


using AForge.Video.DirectShow;

namespace ourChat
{
    public partial class videoForm : Form
    {
        private FilterInfoCollection videoDevices;
        private AForge.Controls.VideoSourcePlayer myCamera;
        int listen_numb;
        int send_numb;
        string ip;
        Bitmap my_video;
        UdpClient sender;

        bool flag_closed;

        public videoForm(int listen, int send, string ip_obj)
        {
            InitializeComponent();
            this.listen_numb = 10000 + listen;
            this.send_numb = 10000 + send;
            this.ip = ip_obj;
            sender = new UdpClient(this.ip, send_numb);
            flag_closed = false;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Bitmap im = new Bitmap(yours.Image);
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "(*.bmp)|*.bmp";
            if(file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                im.Save(file.FileName);
            }

        }

        private void videoForm_Load(object sender, System.EventArgs e)
        {
            //InitiallizeCamera();

            myCamera = new AForge.Controls.VideoSourcePlayer();
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new Size(320, 240);
            videoSource.DesiredFrameRate = 1;
            myCamera.VideoSource = videoSource;
            myCamera.NewFrame += sender_Handle;
            myCamera.Start();

            Thread mainThread;
            mainThread = new Thread(new ParameterizedThreadStart(this.udpListening));
            mainThread.SetApartmentState(ApartmentState.STA);
            mainThread.Start();
        }

        void sender_Handle(object obj, ref Bitmap aa)
        {
            byte[] im = ImgToByt(aa);
            sender.Send(im, im.Length);
            mine.Image = aa;
            //yours.Image = aa;
        }

        public delegate void pbDelegate(PictureBox form);
        void pbRefresh(PictureBox form)
        {
            form.Image.Save("aa.bmp");
            form.Refresh();
        }
        void udpListening(object no_use)
        {
            UdpClient listener = new UdpClient(listen_numb);
            IPEndPoint ipend = new IPEndPoint(IPAddress.Any, listen_numb);

            pbDelegate refresh = new pbDelegate(pbRefresh);

            while(!flag_closed)
            {
                try
                {
                    if (listener.Client.Available == 0)
                        continue;

                    byte[] im = listener.Receive(ref ipend);
                    if (ipend.Address.ToString() == this.ip)
                    {
                        Image img = BytToImg(im);
                        yours.Image = img;
                        //img.Save("a.bmp");
                        if (!flag_closed)
                            this.Invoke(refresh, new object[] { yours });
                    }
                }
                catch { }
            }
        }

        private void videoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myCamera.Stop();
            flag_closed = true;
            Thread.Sleep(10);
        }

        private void shot_m_Click(object sender, EventArgs e)
        {
            Bitmap im = myCamera.GetCurrentVideoFrame();
            if(im == null)
            {
                MessageBox.Show("无法读取到图片！");
                return;
            }
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "(*.bmp)|*.bmp";
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                im.Save(file.FileName);
            }
        }


    }
}
