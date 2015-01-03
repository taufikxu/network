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
    public partial class chatForm : Form
    {
        private TcpClient myTcp;
        private NetworkStream netStream;
        private StreamReader strReader;

        private string my_name;
        private string chat_name;
        private mainWindow parent_window;
        public bool chat_flag;
        private bool flag_over_byme;

        private string str_to_append;

        private bool main_function_flag;

        //委托信息
        public delegate void ProcessDelegate(string to_append);


        public int sequence;
        public chatForm()
        {
            InitializeComponent();
        }
        public chatForm(TcpClient chatTcp, mainWindow parent, int numb, string cname)
        {
            InitializeComponent();

            parent_window = parent;

            myTcp = chatTcp;
            netStream = chatTcp.GetStream();
            strReader = new StreamReader(netStream);

            sequence = numb;
            chat_name = cname;

            my_name = parent.my_name;

            chat_flag = true;
            main_function_flag = true;
            flag_over_byme = true;

            Thread mainThread;
            mainThread = new Thread(new ParameterizedThreadStart(this.ChatFunction));
            mainThread.SetApartmentState(ApartmentState.STA);
            mainThread.Start();
        }
        ~chatForm()
        {
            chat_flag = false;
        }

        private void chatForm_Load(object sender, EventArgs e)
        {
            this.Text = "正在与" + chat_name + "聊天中";//题头显示聊天人
        }

        private void chatForm_Activated(object sender, EventArgs e)
        {
            this.text_sender.Focus();//以发送框为焦点
        }

        private void button_send_Click_1(object sender, EventArgs e)
        {
            //object temp_store = Clipboard.GetDataObject();
            //Clipboard.Clear();
            try
            {
                int counter = 0;
                try
                {
                    for (int i = 0; i < text_sender.TextLength; i++)
                    {
                        text_sender.Select(i, 1);
                        RichTextBoxSelectionTypes rtype = text_sender.SelectionType;
                        if (rtype == RichTextBoxSelectionTypes.Object)
                        {
                            main_function_flag = false;
                            try
                            {
                                text_sender.Copy();
                                Image im = Clipboard.GetImage();
                                if (im != null)
                                {
                                    AppendText(my_name, "");
                                    Clipboard.SetDataObject(im);
                                    text_viewer.Paste();
                                    text_viewer.ScrollToCaret();
                                    Clipboard.Clear();
                                    counter++;

                                    im.Save(@"C:\ProgramData\ourchat\" + my_name + "\\pict" + "\\" + im.GetHashCode().ToString() + ".bmp");
                                    FileStream fs_temp = File.Open(@"C:\ProgramData\ourchat\" + my_name + "\\pict" + "\\" + im.GetHashCode().ToString() + ".bmp", FileMode.Open);
                                    
                                    long len = fs_temp.Length;
                                    parent_window.SendMessageTo(netStream, "pic" + "\r" + im.GetHashCode().ToString() + "\r" + len.ToString());
                                    fs_temp.Close();
                                    fs_temp.Dispose();

                                    SendFile(netStream, @"C:\ProgramData\ourchat\" + my_name + "\\pict" + "\\" + im.GetHashCode().ToString() + ".bmp", true);
                                }
                            }
                            catch { }
                            main_function_flag = true; 
                            
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("含有非法字符，无法发送");
                }
               

                if(counter < text_sender.TextLength)
                {
                    //每次发送消息前找到要发送消息的ip和端口号  
                    string message = "mes" + text_sender.Text;
                    message = message.Trim();
                    parent_window.SendMessageTo(netStream, message);
                    string temp_string = text_sender.Text + "\r\n";
                    text_sender.Text = "";
                    AppendText(my_name, temp_string);
                }

                text_sender.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("对方好友已下线，无法进行聊天！！");
                this.Close();                
                return;
            }

            //Clipboard.SetDataObject(temp_store, true);

                        
        }

        private void chatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            chat_flag = false;
        }

        

        

        

        

        

        

        

       

       







    }
}
