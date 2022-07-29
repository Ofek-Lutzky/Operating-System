using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThrashingGenerator
{
    public partial class Form1 : Form
    {

        private bool increaseCpu = true;
        //private int[,] DataTable = new int[128, 256];
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            increaseCpu = true;
            int i = 0;
            while (i<15)
            {
                Thread T = new Thread(pageFualt);
                T.Start();
                i++;
            }
        }

        private void pageFualt()
        {
            while (increaseCpu)
            {
                int[,] DataTable = new int[1500, 1500];
                //MessageBox.Show(Thread.CurrentThread.ToString());
                for (int i = 0; i < 1500; i++)
                {
                    for (int j = 0; j < 1500; j++)
                    {
                        DataTable[j, i] = 0;
                    }
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            increaseCpu = false;
        }
    }
}
