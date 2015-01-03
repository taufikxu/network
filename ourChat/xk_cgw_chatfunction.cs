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
    partial class chatGroupWindow
    {
        public delegate void ProcessDelegate(string to_append);
        void AddChatMember(string no_use)
        {
            if(no_use == "")
            {
                foreach (string member in list_member)
                {
                    listBox_chatgroup.Items.Add(member);
                }
            }
            else
            {
                listBox_chatgroup.Items.Add(no_use);
            }
           
        }
        private void ChatFunction(object no_use)
        {
            string store;
            NetworkStream netstr = client_tcp.GetStream();
            StreamReader strReader = new StreamReader(netstr);

            ProcessDelegate addTxt = new ProcessDelegate(AddContent);
            ProcessDelegate closeThis = new ProcessDelegate(CloseForm);
            ProcessDelegate AddMember = new ProcessDelegate(AddChatMember);
            ProcessDelegate removeit = new ProcessDelegate(RemoveItems);

            string num_str ="";
            while(num_str == "")
                num_str= parent_window.ReadFromStream(strReader, 1);

            int num = Convert.ToInt32(num_str);
            for (int i = 0; i < num; i++)
            {
                string temp = parent_window.ReadFromStream(strReader, 10);
                list_member.Add(temp);
            }
            //Thread.Sleep(10);
            this.Invoke(AddMember, new object[] { "" });

            while (flag_chat == true)
            {
                store = parent_window.ReadFromStream(strReader);
                if (store.Length < 3)
                    continue;

                if (store.Substring(0, 3) == "mes")
                {
                    this.Invoke(addTxt, new object[] { store.Substring(3) });
                }

                if(store.Substring(0,3) == "qit")
                {
                    try
                    {
                        int seq = Convert.ToInt32(store.Substring(3, 1));
                        this.Invoke(removeit, new object[] { list_member[seq] });
                    }
                    catch { }
                }
                if(store.Substring(0,3) == "ext")
                {
                    MessageBox.Show("群主已将群聊终结");
                    if(!this.IsDisposed)
                        this.Invoke(closeThis, new object[] { "" });
                }
            }
        }
        private void ChatServerFunction(object no_use)
        {
            string store = "";
            List<StreamReader> strReader = new List<StreamReader>(0);
            foreach(TcpClient tcp in list_tcp)
            {
                strReader.Add(new StreamReader(tcp.GetStream()));
            }

            ProcessDelegate addTxt = new ProcessDelegate(AddContent);
            ProcessDelegate closeThis = new ProcessDelegate(CloseForm);
            ProcessDelegate removeit = new ProcessDelegate(RemoveItems);

            while (flag_chat == true)
            {

                foreach(StreamReader reader in strReader)
                {
                    store = parent_window.ReadFromStream(reader);
                    if (store.Length > 3)
                        break;
                }

                if (store.Length < 3)
                    continue;

                if (store.Substring(0, 3) == "mes")
                {
                    try
                    {
                        this.Invoke(addTxt, new object[] { store.Substring(3) });

                        int seq = Convert.ToInt32(store.Substring(3, 1));
                        for (int i = 0; i < list_tcp.Count; i++)
                        {
                            if (i != seq - 1)
                            {
                                parent_window.SendMessageTo(list_tcp[i].GetStream(), store);
                            }
                        }
                    }
                    catch { }
                    
                }
                if(store.Substring(0,3) == "qit")
                {
                    try
                    {
                        int seq = Convert.ToInt32(store.Substring(3, 1));
                        //listBox_chatgroup.Items.Remove(list_member[seq-1]);
                        //listBox_chatgroup.Items.RemoveAt(seq - 1);
                        this.Invoke(removeit, new object[] { list_member[seq] });
                        if(listBox_chatgroup.Items.Count > 1)
                        {
                            for (int i = 0; i < list_tcp.Count; i++)
                            {
                                if (i != seq - 1)
                                {
                                    parent_window.SendMessageTo(list_tcp[i].GetStream(), store);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < list_tcp.Count; i++)
                            {
                                if (i != seq - 1)
                                {
                                    parent_window.SendMessageTo(list_tcp[i].GetStream(), "ext");
                                }
                            }
                            MessageBox.Show("所有人均已退出群聊！");
                            this.Invoke(closeThis, new object[]{""});
                        }                        
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        void AddContent(string to_append)
        {
            int seq = Convert.ToInt32(to_append.Substring(0,1));
            AppendText(list_member[seq], to_append.Substring(1));
            this.text_sender.Text = "";

            to_append = "";
        }
        void CloseForm(string no_use)
        {
            this.Close();
        }
        void RemoveItems(string name)
        {
            listBox_chatgroup.Items.Remove(name);
        }
        private void AppendText(string name, string content)
        {
            if (text_viewer.TextLength != 0)//判断text_viewer是否为空，如果不为空，则换行
            {
                text_viewer.AppendText("\r\n");
            }
            int length = text_viewer.TextLength;//保存已有内容的长度
            text_viewer.Select(length, 0);//选取最后一个插入符
            text_viewer.SelectionColor = Color.Blue;//这样可以显示姓名日期与所发文本不一样色，是不是很酷炫？
            text_viewer.AppendText(name + " " + DateTime.Now.ToString() + "\r\n");
            text_viewer.SelectionColor = Color.Black;//恢复为黑色
            //content = content.Remove(content.LastIndexOf(@"\par"), 4);//删除最后一个换行符
            //text_viewer.SelectedRtf = content;//将rtf文本输入到text_viewer中被选中的地方
            text_viewer.AppendText(content);

            text_viewer.Focus();
            text_viewer.ScrollToCaret();//让滚动条拉到最低处
            text_sender.Focus();

        }

        private void button_sendg_Click(object sender, EventArgs e)
        {
            string temp = this.text_sender.Text;
            AppendText(parent_window.my_name, temp);
            text_sender.Text = "";

            if(flag_server == false)
            {
                parent_window.SendMessageTo(client_tcp.GetStream(), "mes"+sequence.ToString() + temp);
            }
            else
            {
                foreach (TcpClient tcp in list_tcp)
                {
                    parent_window.SendMessageTo(tcp.GetStream(), "mes" + "0" + temp);
                }
            }
        }
    }
}
