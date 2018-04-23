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

namespace ThreadTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private Thread thread1 = null;
        private Thread thread2 = null;

        private void MainForm_Load(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(counter1));
            thread2 = new Thread(new ThreadStart(counter2));
            thread1.Start();
            thread2.Start();
        }

        //线程1计算方法
        private void counter1()
        {
            while (true)
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    textBox1.Text = i.ToString();
                }
                Thread.Sleep(3000);
            }
        }

        //线程2计算方法
        private void counter2()
        {
            while (true)
            {
                int i;
                for (i = 0; i < 1000; i++)
                {
                    textBox2.Text = i.ToString();
                }
                Thread.Sleep(3000);
            }
        }

        private void btnStopThread_Click(object sender, EventArgs e)
        {
            if (thread1.IsAlive)
            {
                thread1.Abort();
            }
            if (thread2.IsAlive)
            {
                thread2.Abort();
            }
            btnStopThread.Enabled = false;
        }
    }
}
