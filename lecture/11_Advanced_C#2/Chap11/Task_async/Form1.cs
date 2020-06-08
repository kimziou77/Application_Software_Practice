using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async private void btnStart_Click(object sender, EventArgs e)
        {
            ulong t1 = await Task<ulong>.Factory.StartNew(() =>
            {
                ulong acc = 0; ulong n = 10001;
                for (ulong i = 0; i < n; i++)
                {
                    for (ulong j = 0; j < n; j++)
                        acc += i * j + 1;
                    lblLog.Invoke((MethodInvoker)(() => lblLog.Text = string.Format("{0:N0}", acc)));
                    pbLog.Invoke((MethodInvoker)(() => pbLog.Value = Convert.ToInt32(i * 100.0 / n)));
                }
                return acc;
            });
            lblLog.Text = string.Format("{0:N0}", t1);
        }
    }
}
