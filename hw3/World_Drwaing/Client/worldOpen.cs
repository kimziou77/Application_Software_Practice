using Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using World_Drwaing;

namespace World_Drwaing
{
    public partial class worldOpen : Form
    {
        public worldOpen()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            world_Client wc = (world_Client)Owner;
            int port = int.Parse(txtPort.Text);
            if (txtID.Text.Length <= 0)
            {
                MessageBox.Show("ID를 입력해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Focus();
                return;

            }
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("잘못된 포트번호 입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
                return;
            }
            if (txtIP.Text.Length <= 0 || txtPort.Text.Length <= 0)
            {
                MessageBox.Show("빈칸을 채워주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            wc.IP = IPAddress.Parse(txtIP.Text);
            wc.PORT = int.Parse(txtPort.Text);
            wc.ID = txtID.Text;

            this.Close();
        }

        private void txtID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOpen_Click(sender, e);
        }
    }
}
