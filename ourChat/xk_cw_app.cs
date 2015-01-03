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
    partial class chatForm
    {
        void ShakeMyWindow()
        {
            this.Activate();
            Point store = this.Location;
            Random ran = new Random();
            for (int i = 0; i < 50; i++)
            {
                int x = (ran.Next() % 10) - 5;
                int y = (ran.Next() % 10) - 5;
                this.Location = new Point(store.X + x, store.Y + y);
                Thread.Sleep(10);
            }
            this.Location = store;
        }


    }
}
