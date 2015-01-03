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
    }
}
