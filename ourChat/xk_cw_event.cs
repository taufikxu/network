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
        private void toolStripButton_sendfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog filopen = new OpenFileDialog();
            if (filopen.ShowDialog() == DialogResult.OK)
            {
                string address = filopen.FileName;
                SendFile(netStream, address);
            }
        }

        private void chatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                chat_flag = false;
                if (flag_over_byme)
                    parent_window.SendMessageTo(myTcp.GetStream(), "qit");
            }
            catch { }
            
        }

        private void toolStripButton_shake_Click(object sender, EventArgs e)
        {
            parent_window.SendMessageTo(netStream, "shk");
            ShakeMyWindow();
        }

        PictureBox pict;
        private void toolStripButton_cut_Click(object sender, EventArgs e)
        {
            screen temp = new screen();
            temp.ShowDialog();
            pict = new PictureBox();

            if (temp.result)
            {
                //object store_temp = Clipboard.GetDataObject();
                Clipboard.SetDataObject(temp.bit_res);
                text_sender.Paste();
                //Clipboard.SetDataObject(store_temp);
            }
        }

        private void toolStripButton_pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "(*.jpg)(*.bmp)(*.gif)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image im = Image.FromFile(fd.FileName);
                //im.Width = 10;//new Size(50, 50);
                Clipboard.SetDataObject(im);
                text_sender.Paste();
            }
        }

    }
}
