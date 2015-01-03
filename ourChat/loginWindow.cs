using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ourChat
{
    public partial class loginWindow : Form
    {
        public string myname;

        private mainWindow parent_window;


        public loginWindow(mainWindow parent)
        {
            InitializeComponent();
            parent_window = parent;
            myname = "";
        }


        private void label1_Click_1(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string key = textBox_key.Text;
            if (name != "" && key != "")
            {
                if (CheckKey(name, key))
                {
                    myname = name;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密码错误！！", "输入不符要求", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请填写用户名和密码！", "输入不符要求", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label_quit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

    
       
        bool CheckKey(string name, string key)
        {
            string result = parent_window.LogIn(name, key);
            if (result == "ok")
                return true;
            else
                return false;
        }

        //按回车键
        private void loginWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(this.ActiveControl.Name == "textBox_name")
                {
                    textBox_key.Focus();
                }
                else if(this.ActiveControl.Name == "textBox_key")
                {
                    label1_Click_1(sender, e);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int x = rd.Next(-2,2);
            this.Opacity += (double)x/100;
        }
    }

    
}
