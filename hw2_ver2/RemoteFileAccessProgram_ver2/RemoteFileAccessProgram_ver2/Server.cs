using PacketDefine;
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
using static PacketDefine.Class1;

namespace RemoteFileAccessProgram_ver2
{
    public partial class Server : Form
    {
        bool DEBUGGING = false;

        public Server()
        {
            InitializeComponent();
        }
        #region 변수
        IPAddress IP; int PORT;

        //Server Client Members
        public NetworkStream m_Stream;
        private TcpListener m_listener;
        public bool m_bConnect = false;
        public bool m_bStop = false;
        Packet packet;

        long bufferSize = 1024 * 4;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        //Server members
        private Thread m_thServer;          //서버스레드
        #endregion

        #region 서버
        public void ServerStart()
        {
            if (DEBUGGING) Message("[+] ServerStart");
            try
            {
                IP = IPAddress.Parse(txtIP.Text);
                PORT = int.Parse(txtPort.Text);

                if (!m_bConnect)
                    Message("클라이언트 접속 대기중...");

                m_listener = new TcpListener(IP, PORT);
                m_listener.Start();
                m_bStop = true;

                while (m_bStop)
                {
                    if (DEBUGGING) Message("[+] m_bStop");
                    TcpClient client = m_listener.AcceptTcpClient();
                    if (client.Connected)//연결된게 맞다면
                    {
                        m_bConnect = true;//사용중 on
                        Message("클라이언트 접속");
                        m_Stream = client.GetStream();//손님의 동선을 파악한다.
                    }
                    while (m_bConnect)//접속된것이 확인되는 동안.
                    {
                        if (DEBUGGING) Message("[+] m_bConnect");
                        try
                        {
                            m_Stream.Read(readBuffer, 0, 1024 * 4); //클라이언트로부터 전달된 패킷을 받는다.
                        }
                        catch//읽는것이 실패했다면
                        {
                            Message("클라이언트로부터 전달된 패킷을 읽는것에 실패하였습니다.");
                            m_bConnect = false;
                            continue;
                        }
                        packet = (Packet)Packet.Desserialize(readBuffer);//Desserialize

                        switch ((int)packet.Type)//패킷타입에 따른 동작.
                        {
                            case (int)PacketType.INIT:
                                {
                                    PacketInit();
                                    break;
                                }
                            case (int)PacketType.FILE_INFO:
                                {
                                    PacketFileInfo(ref packet);
                                    break;
                                }
                            case (int)PacketType.DOWNLOAD:
                                {
                                    PacketDownload(ref packet);
                                    break;
                                }
                            case (int)PacketType.MESSAGE:
                                {
                                    Messenger ms = (Messenger)packet;
                                    Message(ms.msg);
                                    break;
                                }
                            case (int)PacketType.EXIT:
                                {
                                    Disconnect();
                                    break;
                                }
                            default:
                                {
                                    Message("알 수 없는 패킷");
                                    break;
                                }
                        }
                        if (DEBUGGING) Message("[-] m_bConnect");
                    }
                    if (DEBUGGING) Message("[-] m_bStop");
                }
                if (DEBUGGING) Message("[-] ServerStart");
            }
            catch (ThreadAbortException ex)
            {
                Message("Server가 이미 Stop된 상태");
                return;
            }
            catch (Exception ex)
            {
                m_bStop = true;
                Message("SeverStart() Error : " + ex.Message);
                Message(ex.StackTrace);
                ServerStop();
                return;
            }
        }
        #endregion

        #region 서버연결/해제함수
        public void ServerStop()
        {
            if (DEBUGGING) Message("[+] ServerStop");

            m_bStop = false;
            m_bConnect = false;
            m_listener.Stop();
            m_Stream.Close();//stream 닫기

            m_thServer.Abort();

            btnServerOn.Text = "서버켜기";
            btnServerOn.ForeColor = Color.Black;

            Message("서버 Stop...");
            if (DEBUGGING) Message("[-] ServerStop");

        }
        public void Disconnect()
        {
            if (DEBUGGING) Message("[+] Disconnect");

            m_bConnect = false;
            Message("클라이언트 연결 해제...");
            if (DEBUGGING) Message("[-] Disconnect");
        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bConnect)
            {
                Disconnect();
                ServerStop();
            }

        }
        #endregion

        #region 패킷함수들
        public void PacketFileInfo(ref Packet packet)
        {
            if (DEBUGGING) Message("[+] PacketFileInfo");
            File_Info fi = (File_Info)packet;

            DirectoryInfo di = new DirectoryInfo(fi.path);
            DirectoryInfo[] di_under = di.GetDirectories();
            FileInfo[] fiArray = di.GetFiles();

            ((File_Info)packet).fiArray = fiArray;
            ((File_Info)packet).diArray = di_under;
            try
            {
                Packet.Serialize(packet).CopyTo(sendBuffer, 0);
                //아하 sendBuffer가 너무 작아서 일어나는 문제구나..
                Send();
            }
            catch
            {
                MessageBox.Show("파일이 너무 많아서 info용량때메 오류가 나는 듯");
            }
            

            if (DEBUGGING) Message("[-] PacketFileInfo");
        }
        public void PacketInit()
        {
            if (DEBUGGING) Message("[+] PacketInit");
            Message("초기화 데이터 요청...");
            byte[] InitPath = Encoding.UTF8.GetBytes(txtPath.Text);
            m_Stream.Write(InitPath, 0, InitPath.Length);

            if (DEBUGGING) Message("[-] PacketInit");

        }
        public void PacketDownload(ref Packet packet)
        {
            DownFile df = (DownFile)packet;
            Message(df.name + " 파일을 다운로드합니다...");

            df.fi = new FileInfo(df.ServerPath);
            df.size = df.fi.Length;

            Thread file_Send = new Thread(new ParameterizedThreadStart(fileSend));
            file_Send.Start(packet);
        }
        void fileSend(Object packet)
        {
            DownFile df = (DownFile)packet;
            // 파일 스트림 생성
            FileStream file = new FileStream(df.ServerPath, FileMode.Open);
            BinaryReader br = new BinaryReader(file);
            try
            {
                //파일 size만큼 버퍼를 만들어 복사 후 전송
                byte[] bytesFile = new byte[df.size];
                bytesFile = br.ReadBytes((int)bytesFile.Length);
                m_Stream.Write(bytesFile, 0, bytesFile.Length);
                m_Stream.Flush();

            }
            catch(Exception ex)
            {
                Message("파일전송실패 : "+ ex.Message);
                return;
            }
            finally
            {
                file.Close();
                br.Close();
            }
            Message("파일전송성공");
            
        }
        #endregion

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                string message = msg + "\r\n";
                txtLog.Text += message;
            }));
        }
        public void Send()
        {
            if (DEBUGGING) Message("[+] Send");

            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();
            for (int i = 0; i < bufferSize; i++)
            {
                this.sendBuffer[i] = 0;
            }
            if (DEBUGGING) Message("[-] Send");

        }

        #region 서버 버튼 2개
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
            int port = int.Parse(txtPort.Text);
            if (port < 0 || port > 65535)
            {
                MessageBox.Show("잘못된 포트번호 입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
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
                m_bStop = true;
                ServerStop();
            }
        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowser.SelectedPath;
                txtLog.Text += txtPath.Text + "로 경로가 수정되었습니다.\r\n";
            }
        }
        #endregion

    }
}
