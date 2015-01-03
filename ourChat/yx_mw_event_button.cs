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
    partial class mainWindow
    {
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_search_Click(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }

        private void button_search_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string num_search;
            bool on_line = false;
            num_search = textBox_search.Text;
            if (CheckStringMeaningful(num_search))
            {
                on_line = shifou_zaixian_zyx(num_search);
                if (on_line == true)
                {
                    MessageBox.Show(num_search + "在线", "状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(num_search + "离线", "状态", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("输入学号非法！");
            }
            tree_showfriends.SelectedNode = null;
        }
        private void chatstart_Click(object sender, EventArgs e)
        {
            if (tree_showfriends.SelectedNode == null)
            {
                MessageBox.Show("请选中要进行聊天的好友！");
            }
            else
            {
                string chatwith = tree_showfriends.SelectedNode.Text;
                if (chatwith == my_name)
                {
                    MessageBox.Show("无法与自己发起聊天！");
                    return;
                }
                string address = CheckFriend(chatwith);
                if (address.Length < 5 || address.Substring(0, 5) == "error")
                {
                    MessageBox.Show("当前好友不在线或无法发起会话");
                    return;
                }
                SetupChat(address, chatwith);
            }
            tree_showfriends.SelectedNode = null;
        }

        private void touxiang_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "选择图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    touxiang.Image = Image.FromFile(lvse.FileName);
                }
            }
            //label_touxiang.ForeColor = System.Drawing.Color.Transparent;
            this.Controls.Remove(label_touxiang);
        }

        private void videoButton_Click(object sender, EventArgs e)
        {
            if (tree_showfriends.SelectedNode == null)
            {
                MessageBox.Show("请选中要进行聊天的好友！");
            }
            else
            {
                string chatwith = tree_showfriends.SelectedNode.Text;
                if (chatwith == my_name)
                {
                    MessageBox.Show("无法与自己发起聊天！");
                    return;
                }
                string address = CheckFriend(chatwith);
                if (address.Length < 5 || address.Substring(0, 5) == "error")
                {
                    MessageBox.Show("当前好友不在线或无法发起会话");
                    return;
                }
                SetupVideo(address, chatwith);
            }
            tree_showfriends.SelectedNode = null;
            //videoForm t = new videoForm(10001, 10002, "127.0.0.1");
            //t.Show();
        }


        private void button_addf_Click(object sender, EventArgs e)
        {
            //不能添加自己
            if (textBox_search.Text == my_name)
            {
                MessageBox.Show("不能添加自己为好友!");
            }
            else
            {
                //判断是否已经添加
                if (this.friend_list.IndexOf(textBox_search.Text) == -1)
                {
                    if (!CheckStringMeaningful(textBox_search.Text))
                    {
                        MessageBox.Show("输入的好友学号非法！");
                        textBox_search.Text = "";
                        return;
                    }
                    basis = new TreeNode(textBox_search.Text);
                    this.tree_showfriends.Nodes.Add(basis);
                    this.friend_list.Add(textBox_search.Text);
                    textBox_search.Text = "";
                }
                else
                {
                    MessageBox.Show(textBox_search.Text + " 已经是您的好友", "不可重复添加", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            tree_showfriends.SelectedNode = null;
        }

        private void button_deletef_Click(object sender, EventArgs e)
        {
            if (tree_showfriends.SelectedNode == null)
            {
                MessageBox.Show("请先选中要删除的好友！");
            }
            else
            {
                string delete_name = tree_showfriends.SelectedNode.Text;
                DialogResult result = MessageBox.Show("是否确定将" + delete_name + "从好友列表中删除"
                    , "", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    this.friend_list.Remove(delete_name);
                    this.tree_showfriends.SelectedNode.Remove();
                }

                tree_showfriends.SelectedNode = null;
            }
        }

        private void button_chatg_Click(object sender, EventArgs e)
        {
            number_list = new List<string>();
            chatgroup_Add chatgroup_add = new chatgroup_Add(friend_list, number_list);
            chatgroup_add.ShowDialog();
            //将list转成string[]
            string[] temp = number_list.ToArray();
            SetupQunliao(temp);

        }
    }

}
