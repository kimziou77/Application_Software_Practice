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

namespace _07_winform_programming5
{
    public partial class ThreadExample : Form
    {
        private Thread m_threadPlus;
        private Thread m_threadMinus;

        private int m_nValue = 0;
        private int m_nPlusCount = 0;
        private int m_nMinusCount = 0;

        public delegate void DelegateShowText(string strlabel, string strText);
        public DelegateShowText DelegateShowtextInstance;
        public ThreadExample()
        {
            DelegateShowtextInstance = new DelegateShowText(this.ShowText);
            InitializeComponent();
        }
        private void ShowText(string strLabel, string strText)
        {
            switch(strLabel){
                case "label1":
                    label1.Text = strText;
                    break;
                case "label2":
                    label2.Text = strText;
                    break;
                case "label3":
                    label3.Text = strText;
                    break;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            m_threadPlus = new Thread(new ThreadStart(ThreadPlus));
            m_threadMinus = new Thread(new ThreadStart(ThreadMinus));

            m_threadPlus.Start();
            m_threadMinus.Start();
        }
        private void ThreadPlus()
        {
            //while (m_nPlusCount < 1000)
            //{
            //    int nValue = m_nValue + 1;
            //    Thread.Sleep(1);
            //    m_nValue = nValue;
            //    label1.Text = Convert.ToString(m_nValue);
            //    m_nPlusCount++;
            //    label2.Text = Convert.ToString(m_nPlusCount);
            //}
            lock (this)
            {
                while (m_nPlusCount < 1000)
                {
                    int nValue = m_nValue + 1;
                    Thread.Sleep(1);
                    m_nValue = nValue;
                    Invoke(DelegateShowtextInstance, new object[] { "label1", Convert.ToString(m_nValue) });
                    m_nPlusCount++;
                    Invoke(DelegateShowtextInstance, new object[] { "label2", Convert.ToString(m_nPlusCount) });

                }
            }
            


        }
        private void ThreadMinus()
        {
            // Example 1
            //while (m_nMinusCount > -1000)
            //{
            //    int nValue = m_nValue - 1;
            //    Thread.Sleep(1);
            //    m_nValue = nValue;
            //    label1.Text = Convert.ToString(m_nValue);
            //    m_nMinusCount--;
            //    label3.Text = Convert.ToString(m_nMinusCount);
            //}

            // Example 2 ->3(lock추가)
            lock (this)
            {
                while (m_nMinusCount > -1000)
                {
                    int nValue = m_nValue - 1;
                    Thread.Sleep(1);
                    m_nValue = nValue;
                    Invoke(DelegateShowtextInstance, new object[] { "label1", Convert.ToString(m_nValue) });
                    m_nMinusCount--;
                    Invoke(DelegateShowtextInstance, new object[] { "label3", Convert.ToString(m_nMinusCount) });
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (m_threadPlus.IsAlive == true)
                m_threadPlus.Abort();
            if (m_threadMinus.IsAlive == true)
                m_threadMinus.Abort();
        }
    }
}
