
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

//本文件包括发起群聊
namespace ourChat
{
    partial class mainWindow
    {
        List<string> number_list;       //群聊的好友
        private void tree_showfriends_DoubleClick(object sender, EventArgs e)
        {
            // if(tree_showfriends.SelectedNode !=)

        }

       
        private void tree_showfriends_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }



        bool CheckStringMeaningful(string friend)
        {
            try
            {
                int temp = Convert.ToInt32(friend);
                if (temp < 2019000000 && temp > 2005000000)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }

}
