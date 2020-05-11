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
using System.Threading;
using static ClassLibrary1.Packet;

namespace Packet_Server
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpListener m_listener;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        private bool m_bClientOn = false;
        private Thread m_thread;
        public Initialize m_initializeClass;
        public Login m_loginClass;

        public void RUN()
        {
            this.m_listener = new TcpListener(7777);
            this.m_listener.Start();
            if (!this.m_bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_server_state.AppendText("클라이언트 접속 대기중\n");
                }));
            }
            TcpClient client = this.m_listener.AcceptTcpClient();
            if (client.Connected)
            {
                this.m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_server_state.AppendText("클라이언트 접속\n");
                }));
                m_networkstream = client.GetStream();
            }
            int nRead = 0;
            while (this.m_bClientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bClientOn = false;
                    this.m_networkstream = null;
                }
                Packet packet = (Packet)Packet.Deserialize(this.readBuffer);
                switch ((int)packet.Type)
                {
                    case (int)PacketType.초기화:
                        {
                            this.m_initializeClass = (Initialize)Packet.Deserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("패킷 전송 성공. " + "Initialize Class Data is " + this.m_initializeClass.Data + "\n");
                            }));
                            break;
                        }
                    case (int)PacketType.로그인:
                        {
                            this.m_loginClass = (Login)Packet.Deserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                this.txt_server_state.AppendText("패킷 전송 성공. " + "Login Class data is"+this.m_loginClass.m_strID+"\n");
                            }));
                            break;
                        }
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_thread = new Thread(new ThreadStart(RUN));
            m_thread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_listener.Stop();
            this.m_networkstream.Close();
            this.m_thread.Abort();
        }
    }
}
