using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationTest
{
    public partial class MainForm : Form
    {
        public bool[] cb = new bool[5];
        public ListView listview;
        public MainForm()
        {
            InitializeComponent();
            listview = lsvMain;
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            inputForm inputForm = new inputForm();
            inputForm.Owner = this;
            inputForm.ShowDialog();
            inputForm.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ListView lvTemp = listview;

            ViewForm viewForm = new ViewForm();
            viewForm.Owner = this;


            viewForm.ShowDialog();
            viewForm.Close();
        }

        private void cbKor_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private void cbKor_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cb[0])
                cb[0] = false;
            else
                cb[0] = true;
        }

        private void cbEng_CheckedChanged(object sender, EventArgs e)
        {
            if (cb[1])
                cb[1] = false;
            else
                cb[1] = true;
        }

        private void cbMath_CheckedChanged(object sender, EventArgs e)
        {
            if (cb[2])
                cb[2] = false;
            else
                cb[2] = true;
        }

        private void cbSoc_CheckedChanged(object sender, EventArgs e)
        {
            if (cb[3])
                cb[3] = false;
            else
                cb[3] = true;
        }

        private void cbSci_CheckedChanged(object sender, EventArgs e)
        {
            if (cb[4])
                cb[4] = false;
            else
                cb[4] = true;
        }
    }
}
