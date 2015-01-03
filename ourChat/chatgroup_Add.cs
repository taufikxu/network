using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace ourChat
{
    public partial class chatgroup_Add : Form
    {
        List<string> list_number;       //群聊的好友
        public chatgroup_Add()
        {
            InitializeComponent();
        }
        public chatgroup_Add(List<string> friends, List<string> number)
        {
            InitializeComponent();
            list_number = number;
            int count = friends.Count;
            for(int i = 0; i < count; i++)
            {
                checkedListBox_cgfriend.Items.Add(friends[i]);
            }
        }

        
        private void checkedListBox_cgfriend_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_done_Click(object sender, EventArgs e)
        {
            int count = checkedListBox_cgfriend.Items.Count;
            string newf;
           // int newn;
            for (int i = 0; i < count; i++ )
            {
                if (checkedListBox_cgfriend.GetItemChecked(i))
                {
                    //newf = checkedListBox_cgfriend.GetItemText(i);
                    //newn = Convert.ToInt32(checkedListBox_cgfriend.GetItemText(i));
                    //newf = (checkedListBox_cgfriend.SelectedItems[i] as ListBoxItem).Content.ToString();
                    newf = checkedListBox_cgfriend.Items[i].ToString();
                    list_number.Add(newf);
                   /* if (list_number.IndexOf(newf) == -1)
                    {
                        list_number.Add(newf);
                    }
                    else 
                    {
                        MessageBox.Show(newf + " 已经在群里", "不可重复添加", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }*/
                }
            }
            this.Close();
        }
    }
}
