using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("저장되었습니다.");
        }
    }
}
