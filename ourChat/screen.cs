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
    public partial class screen : Form
    {
        bool flag;
        public bool result;
        Bitmap bit;
        Graphics g;

        public Bitmap bit_res;

        public screen()
        {
            InitializeComponent();

            bit = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(bit);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bit.Size);
            pictureBox1.Size = this.Size;
            flag = true;
            result = false;
            bit_res = null;
        }

        private void screen_DragDrop(object sender, DragEventArgs e)
        {
            this.Close();
        }

        private void screen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
            if (e.KeyChar == '\r')
            {
                //pictureBox1.Image.Save("aa.bmp");
                bit_res = new Bitmap(pictureBox1.Image);
                result = true;
                this.Close();
            }
        }

        private void screen_Resize(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Size = this.Size;
                refresh();
            }
            catch { }
           
        }

        private void refresh()
        {
            Point p = pictureBox1.PointToScreen(new Point(0, 0));
            //p.Y -= pictureBox1.Height;
            Size s = new Size();
            s.Height = (p.Y + pictureBox1.Size.Height > bit.Size.Height) ? (bit.Size.Height - p.Y) : pictureBox1.Size.Height;
            s.Width = (p.X + pictureBox1.Size.Width > bit.Size.Width) ? (bit.Size.Width - p.X) : pictureBox1.Size.Width;


            //pictureBox1.Image.Dispose();
            pictureBox1.Image = bit.Clone(new Rectangle(p, s), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        }

        private void screen_Move(object sender, EventArgs e)
        {
            if (flag)
            {
                try
                {
                    refresh();
                }
                catch
                { }
            }
        }
    }
}
