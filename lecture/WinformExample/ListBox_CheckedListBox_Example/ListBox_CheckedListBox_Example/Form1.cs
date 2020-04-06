using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox_CheckedListBox_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList2Checked_Click(object sender, EventArgs e)
        {
            if (lstLanguages.SelectedItem != null)
            {
                cklLanguages.Items.Add(lstLanguages.SelectedItem, false);
                lstLanguages.Items.Remove(lstLanguages.SelectedItem);
            }
        }

        private void btnChecked2List_Click(object sender, EventArgs e)
        {
            while (cklLanguages.CheckedItems.Count > 0)
            {
                string item = (string)cklLanguages.CheckedItems[0];
                lstLanguages.Items.Add(item);
                cklLanguages.Items.Remove(item);
            }
        }

        private void btnChecked2TextBox_Click(object sender, EventArgs e)
        {
            foreach(string item in cklLanguages.CheckedItems)
            {
                txtNote.Text += item + "\r\n";
            }
        }
    }
}
