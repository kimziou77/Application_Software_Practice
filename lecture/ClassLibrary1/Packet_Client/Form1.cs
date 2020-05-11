using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Net.Sockets;
using static ClassLibrary1.Packet;

namespace Packet_Client
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkStream;
        private TcpClient m_client;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        private bool m_bConnect = false;
        public Initialize m_initializeClass;
        public Login m_loginClass;

        public void Send()
        {
            this.m_networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkStream.Flush();
            for(int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            this.m_client = new TcpClient();
            try
            {
                this.m_client.Connect(this.txt_ip.Text, 7777);
            }
            catch
            {
                MessageBox.Show("접속 에러");
                return;
            }
            this.m_bConnect = true;
            this.m_networkStream = this.m_client.GetStream();
        }

        private void btn_init_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                return;
            }
            Initialize Init = new Initialize();
            Init.Type = (int)PacketType.초기화;
            Init.Data = Int32.Parse(this.txt_init.Text);
            Packet.Serialize(Init).CopyTo(this.sendBuffer,0);
            this.Send();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!this.m_bConnect)
            {
                return;
            }
            Login login = new Login();
            login.Type = (int)PacketType.로그인;
            login.m_strID = this.txt_login.Text;
            Packet.Serialize(login).CopyTo(this.sendBuffer, 0);
            this.Send();
        }
    }
}
