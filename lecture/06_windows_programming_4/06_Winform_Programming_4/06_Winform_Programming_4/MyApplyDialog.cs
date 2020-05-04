using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_Winform_Programming_4
{
    public partial class MyApplyDialog : Form
    {
        public event EventHandler Changed;
        public MyApplyDialog()
        {
            InitializeComponent();
            this.btnApply.Enabled = false;
        }
        private void Color_Scroll(object sneder, ScrollEventArgs e)
        {
            this.btnApply.Enabled = true;
            this.BackColor = Color.FromArgb(this.hsbRed.Value, this.hsbGreen.Value, this.hsbBlue.Value);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(Changed != null)
            {
                if (this.btnApply.Enabled == true)
                {
                    Changed(this, new EventArgs());
                }
            }
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if(Changed!= null)
            {
                Changed(this, new EventArgs());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
