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

namespace ThreadLock
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

        private void showChar(char ch)
        {
            lock (this)
            {
                richTextBox1.Text += ch;
            }
        }

        private void thread1Show()
        {
            while (true)
            {
                showChar('a');
                Thread.Sleep(60);
            }
        }

        private void thread2Show()
        {
            while (true)
            {
                showChar('A');
                Thread.Sleep(20);
            }
        }

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(new ThreadStart(thread1Show));
            thread2 = new Thread(new ThreadStart(thread2Show));
            thread1.Start();
            thread2.Start();
            btnStartThread.Enabled = false;
            btnStopThread.Enabled = true;
        }

        private void btnStopThread_Click(object sender, EventArgs e)
        {
            thread1.Abort();
            thread2.Abort();
            btnStartThread.Enabled = true;
            btnStopThread.Enabled = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread1 != null) thread1.Abort();
            if (thread2 != null) thread2.Abort();
        }
    }
}
