using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void True_click(object sender, EventArgs e)
        {
            MessageBox.Show(txtNote.SelectedText);
        }

        private void False_click(object sender, EventArgs e)
        {
            txtNote.SelectAll();
            txtNote.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(rb1.Text, txtNote.Font.Size, txtNote.Font.Style);
            txtNote.Font = f;
        }

    }
}
