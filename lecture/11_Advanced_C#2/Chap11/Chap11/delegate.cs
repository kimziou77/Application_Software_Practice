using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chap11
{
    public partial class Form1 : Form
    {

        public delegate void DelegatePlus();
        
        Thread thread;
        int num_lob = 1;
        public Form1()
        {
            InitializeComponent();
            button1.Click += button_Chain;
            //button1.Click += (sender, e) => (sender as Button).BackColor = System.Drawing.Color.Yellow;
        }
        private void button_Chain(object sender , EventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.Color.Blue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(LabelPlus));
            thread.Start();
            #region Delegate & Labmda
            ////delegate
            //thread = new Thread(new ThreadStart((MethodInvoker)(delegate ()
            //{
            //    label1.Text = (++num_lob).ToString();
            //})));

            ////lambda
            //thread = new Thread(new ThreadStart(() => {
            //    while (num_lob < 1000)
            //    {
            //        label1.Text = (++num_lob).ToString();
            //    }
            //}));
            #endregion
        }
        private void LabelPlus()
        {
            #region delegate
            while (num_lob < 1000)
            {
                //Cross-thread오류가 발생하게 됨.
                //메인스레드에서만 label을 수정할 수 있음!!

                //ver1
                //label1.text = (++num_lob).tostring();
                 
                ////ver2
                //DelegatePlus temp1 = lblLogPlus;
                //while (num_lob < 1000)
                //{
                //    //label1.Invoke(temp1, new object[] { });
                //    label1.Invoke((DelegatePlus)(lblLogPlus), new object[] { });
                //}

                //ver3
                DelegatePlus temp2 = new DelegatePlus(lblLogPlus);
                while (num_lob < 1000)
                {
                    //label1.Invoke(temp2, new object[] { });
                    label1.Invoke(new DelegatePlus(lblLogPlus), new object[] { });
                }

            }
            #endregion

            #region Anonymous FUnction
            ////ver1
            //DelegatePlus temp3 = delegate ()
            //{
            //    label1.Text = (++num_lob).ToString();
            //};
            //while (num_lob < 1000)
            //{
            //    label1.Invoke(temp3, new object[] { });
            //}
            ////ver2
            //while (num_lob < 1000)
            //{
            //    label1.Invoke((DelegatePlus)(delegate ()
            //    {
            //        label1.Text = (++num_lob).ToString();
            //    }), new object[] { });
            //}
            ////ver3
            //DelegatePlus temp4 = new DelegatePlus(delegate() {
            //    label1.Text = (++num_lob).ToString();
            //});
            //while (num_lob < 1000)
            //{
            //    label1.Invoke(temp4, new object[] { });
            //}
            ////ver4
            //while (num_lob < 1000)
            //{
            //    label1.Invoke(new DelegatePlus(delegate ()
            //    {
            //        label1.Text = (++num_lob).ToString();
            //    }), new object[] { });
            //}
            #endregion

        }
        public void lblLogPlus()
        {
            label1.Text = (++num_lob).ToString();
        }
    }
}
