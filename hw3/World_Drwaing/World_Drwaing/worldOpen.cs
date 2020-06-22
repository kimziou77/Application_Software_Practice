using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            WorldServer ws = (WorldServer)Owner;
            int port = int.Parse(txtPort.Text);

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

            ws.IP = IPAddress.Parse(txtIP.Text);
            ws.PORT = port;
            this.Close();
        }

        private void worldOpen_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
