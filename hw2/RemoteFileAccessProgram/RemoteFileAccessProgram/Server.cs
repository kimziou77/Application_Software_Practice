using PacketClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteFileAccessProgram
{
    public partial class Server : Form
    {

        IPAddress IP; int PORT;

        //Server Client Members
        public NetworkStream m_Stream;
        private TcpListener m_listener;
        public bool m_bConnect = false;
        public bool m_bStop = false;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        //Server members 
        private Thread m_thServer;          //서버스레드
        TcpClient client;
        //client members
        //Initialize m_initializeClass;


        #region 서버시작
        private void btnServerOn_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length <= 0)
            {
                MessageBox.Show("경로가 설정되어있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtIP.Text.Length <= 0 || txtPort.Text.Length <= 0)
            {
                MessageBox.Show("빈칸을 채워주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btnServerOn.Text == "서버켜기")
            {
                m_thServer = new Thread(new ThreadStart(ServerStart));
                m_thServer.Start();
                btnServerOn.Text = "서버멈춤";
                btnServerOn.ForeColor = Color.Red;
            }
            else
            {
                ServerStop();
            }
        }

        public void ServerStart()
        {
            try
            {
                IP = IPAddress.Parse(txtIP.Text);
                PORT = int.Parse(txtPort.Text);
                
                if (!m_bConnect)
                {
                    Message("클라이언트 접속 대기중...");
                }

                m_listener = new TcpListener(IP, PORT);
                m_listener.Start();
                m_bStop = true;

                while (m_bStop)
                {
                    client = m_listener.AcceptTcpClient();
                    if (client.Connected)//연결된게 맞다면
                    {
                        m_bConnect = true;//사용중 on
                        Message("클라이언트 접속");
                        m_Stream = client.GetStream();//손님의 동선을 파악한다.
                    }

                    int nRead = 0;

                    while (m_bConnect)//접속된것이 확인되는 동안.
                    {
                        try
                        {
                            nRead = 0;
                            nRead = m_Stream.Read(readBuffer, 0, 1024 * 4); //클라이언트로부터 전달된 패킷을 받는다.
                        }
                        catch//읽는것이 실패했다면
                        {
                            Message("클라이언트로부터 전달된 패킷을 읽는것에 실패하였습니다.");
                            Disconnect();
                        }
                        Packet packet = (Packet)Packet.Desserialize(readBuffer);//Desserialize

                        switch ((int)packet.Type)//패킷타입에 따른 동작.
                        {
                            case (int)PacketType.INIT:
                                {
                                    PacketInit();
                                    break;
                                }
                            case (int)PacketType.Select:
                                {
                                    PacketSelect();
                                    break;
                                }
                            case (int)PacketType.Expand:
                                {
                                    PacketExpand(packet);
                                    break;
                                }
                            case (int)PacketType.EXIT:
                                {
                                    PacketExit();
                                    break;
                                }
                            case (int)PacketType.PLUS:
                                {
                                    PacketPlus(packet);
                                    break;
                                }
                            case (int)PacketType.FILE_INFO:
                                {
                                    PacketFileInfo(packet);
                                    break;
                                }
                            case (int)PacketType.MESSAGE:
                                {
                                    Messenger ms = (Messenger)packet;
                                    Message(ms.msg);
                                    break;
                                }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Message("SeverStart Error "+ex.Message);
                ServerStop();
                return;
            }
        }
        #endregion
        private void PacketFileInfo(Packet packet)
        {
            File_Info fInfo = (File_Info)packet;
            fInfo.Set_File_Info();
            Packet.Serialize(fInfo).CopyTo(this.sendBuffer, 0);
            Send();
            //파일 정보 보내기
        }
        private void PacketPlus(Packet packet)
        {
            Plus plus = (Plus)packet;
            plus.SetLength(plus.GetPath());
            Packet.Serialize(plus).CopyTo(this.sendBuffer, 0);
            Send();
        }
        private void PacketExit()
        {
            Message("클라이언트 연결 해제...");
            Disconnect();
        }
        private void PacketExpand(Packet packet)
        {
            Message("BeforeExpand 데이터 요청...");
            PacketFileInfo(packet);
            //client에 directory info 전달해주기.

        }
        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();
            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }
        private void PacketInit()
        {
            //왜 이걸 전역변수로 하는거지?
            Message("초기화 데이터 요청...");
            //m_initializeClass = (Initialize)Packet.Desserialize(readBuffer);

            byte[] InitPath = Encoding.UTF8.GetBytes(txtPath.Text);
            //초기 path를 클라이언트에게 전달한다.//그럴필요없이 바로 다른 동작함수 호출해줘도 될듯?
            m_Stream.Write(InitPath, 0, InitPath.Length);

            //이제 여기서 클라이언트로 설정된 경로로부터 트리노드를 전송해야 됨.
        }
        private void PacketSelect()
        {
            //m_sendDataClass = (SendData)Packet.Desserialize(this.readBuffer);
            //버퍼로부터 보내온 형식으로 형변환한다.
            Message("BeforeSelect 데이터 요청...");


        }

        #region 수정안해도됨
        public Server()
        {
            InitializeComponent();
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }


        public void ServerStop()
        {
            m_bStop = false;
            m_bConnect = false;
            if(m_listener!=null)
                m_listener.Stop();
            m_Stream.Close();//stream 닫기
            m_thServer.Abort();

            btnServerOn.Text = "서버켜기";
            btnServerOn.ForeColor = Color.Black;
            Message("ServerStop...");
        }
        public void Disconnect()
        {
            m_bConnect = false;
            m_Stream.Close();//stream 닫기

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowser.SelectedPath;
                txtLog.Text += txtPath.Text + "로 경로가 수정되었습니다.\r\n";
            }
        }
        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                string message = msg + "\r\n";
                txtLog.Text += message;
            }));
        }
        #endregion
    }
}
