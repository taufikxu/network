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
        
        private void ChatFunction(object no_use)
        {
            string store;
            ProcessDelegate addTxt = new ProcessDelegate(AddContent);
            ProcessDelegate close_form = new ProcessDelegate(CloseForm);
            ProcessDelegate shakewindow = new ProcessDelegate(ShakeWindow);
            ProcessDelegate paste = new ProcessDelegate(AddPict);

            while (chat_flag == true)
            {
                if (main_function_flag == false)
                    continue;

                store = parent_window.ReadFromStream(strReader);
                if (store == "")
                    continue;
                if (store.Length < 3)
                    continue;

                if (store.Substring(0, 3) == "mes")
                {
                    str_to_append = ProcessString(store);
                    this.Invoke(addTxt, new object[] { str_to_append });
                }
                if(store.Substring(0,3) == "pic")
                {
                    string[] info = store.Split('\r');
                    int len = Convert.ToInt32(info[2]);
                    string filname = @"C:\ProgramData\ourchat\" + my_name + "\\pict" + "\\" + info[1] + ".bmp";

                    Thread.Sleep(1000);
                    parent_window.SendMessageTo(netStream, "ok");
                    ReceiveFile(strReader, filname, len);

                    Image im = Image.FromFile(filname);
                    Clipboard.SetDataObject(im);
                    this.Invoke(paste, new object[] { "" });
                }
                if (store.Substring(0, 3) == "fil")
                {
                    //store = parent_window.ReadFromStream(strReader);

                    string[] info = store.Split('\r');
                    int len = Convert.ToInt32(info[3]);
                    string fname = Path.GetFileName(info[1]);
                    FolderBrowserDialog floder = new FolderBrowserDialog();

                    if(MessageBox.Show("是否接收文件？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (DialogResult.Cancel == floder.ShowDialog())
                        {
                            parent_window.SendMessageTo(netStream, "Nok");
                            continue;
                        }
                    }
                    else
                    {
                        parent_window.SendMessageTo(netStream, "Nok");
                        continue;
                    }

                    parent_window.SendMessageTo(netStream, "ok");
                    ReceiveFile(strReader, floder.SelectedPath + "\\" +fname, len);
                }
                if (store.Substring(0, 3) == "shk")
                {
                    this.Invoke(shakewindow, new object[] { "" });
                }
                if(store.Substring(0,3) == "qit")
                {
                    MessageBox.Show("对话结束！");
                    flag_over_byme = false;
                    this.Invoke(close_form, new object[] { "" });
                }
            }
        }

        void AddContent(string to_append)
        {
            AppendText(chat_name, to_append);
            to_append = "";
        }
        void CloseForm(string nouse)
        {
            this.Close();
        }
        void ShakeWindow(string nouse)
        {
            ShakeMyWindow();
        }
        void AddPict(string nouse)
        {
            AppendText(chat_name, "");
            text_viewer.Paste();
            text_viewer.ScrollToCaret();
        }
    }
}
