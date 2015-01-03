using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ourChat
{
    //本文件包括读写好友信息，添加删除好友，
    public partial class mainWindow
    {
        

       

        //许堃的函数
        bool shifou_zaixian_zyx(string num_search)
        {
            string result = CheckFriend(num_search);
            if (result == "off")
                return false;
            if (result.Length > 5 && result.Substring(0, 5) == "error")
                return false;

            return true;
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            if(flag_cancel)
            {
                this.Close();
            }
            if(flag_tcp_connected == false)
            {
                this.Close();
            }


            this.Hide();
            ////显示登陆窗口，并把用户名传到主窗口
            loginWindow login = new loginWindow(this);
            login.ShowDialog();
            if (login.myname == "")
                this.Close();
            else
                my_name = login.myname; 

            //my_name = "2012011514";
            //LogIn(my_name, "net2014");
            if (Directory.Exists("C:\\ProgramData\\ourchat\\" + my_name))
            {
                FileStream fs = File.Open("C:\\ProgramData\\ourchat\\" + my_name + "\\" + "friends.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                for (int i = 0; sr.Peek() >= 0; i++)
                {
                    string temp_name = sr.ReadLine();

                    if (CheckStringMeaningful(temp_name))
                        friend_list.Add(temp_name);
                }
                foreach (string x in friend_list)
                    tree_showfriends.Nodes.Add(x);
            }
            else
            {
                Directory.CreateDirectory("C:\\ProgramData\\ourchat\\" + my_name);
                FileStream fs = File.Create("C:\\ProgramData\\ourchat\\" + my_name + "\\" + "friends.txt");
                fs.Close();
            }
            if (!Directory.Exists("C:\\ProgramData\\ourchat\\" + my_name + "\\" + "pict"))
            {
                Directory.CreateDirectory("C:\\ProgramData\\ourchat\\" + my_name + "\\" + "pict");
            }
        }

        private void mainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileStream fs = File.Open("C:\\ProgramData\\ourchat\\" + my_name + "\\" + "friends.txt", FileMode.Create, FileAccess.Write);
            // nodetreetofile();将friend信息写到文件中
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            
            for (int i = 0; i < friend_list.Count; i++)
            {
                sw.WriteLine(friend_list[i]);
                sw.Flush();
            }
            sw.Close();
            fs.Close();

            foreach (chatForm chat in chatForm_list)
                chat.chat_flag = false;
            foreach (chatGroupWindow chat in chatGroup_list)
                chat.flag_chat = false;

            LogOut(my_name);
            CloseApp();
        }
    }
}
