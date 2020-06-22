using Packet_WorldDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Packet_WorldDrawing.Class1;

namespace World_Drwaing
{

    public partial class WorldServer : Form
    {
        public IPAddress IP;
        public int PORT;
        public WorldServer server;

        Dictionary<string, User> connectedUser;//id별 user관리
        
        public WorldServer()
        {
            InitializeComponent();
        }

        private void WorldServer_Load(object sender, EventArgs e)
        {
            TcpClient TcpClient = new TcpClient();
            server = this;
            OpenModal();
            connectedUser = new Dictionary<string, User>();
        }

        private void ServerStart(object sender, FormClosedEventArgs e)
        {
            try
            {
                while (true)
                {
                    TcpListener listener = new TcpListener(IP, PORT);
                    listener.Start();//Close();
                    TcpClient client = listener.AcceptTcpClient();
                    User user = new User(client);//해당 클라이언트 작업용 스레드 스타트
                    user.ReturnToText += new User.appendText(UpdateText);
                    connectedUser.Add(user.id, user);
                    MessageBox.Show("연결 성공 ㅋㅋ");
                    //here to read and Do Something with client ID
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void Send(string id)//해당 id에게 Send
        {
            connectedUser[id].Send();
        }

        private void UpdateText(string str)
        {
            chattingLog.Text += str + "\r\n";
        }

        private void OpenModal()
        {
            worldOpen wo = new worldOpen();
            wo.Owner = this;
            wo.ShowDialog();
            wo.FormClosed += ServerStart;
        }

        private void WorldServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dictionary<string, User>.KeyCollection ids = connectedUser.Keys;

            //foreach(string id in ids)
            //{
            //    connectedUser[id].networkStream.Close();
            //    connectedUser[id].workingThread.Abort();
            //}
        }
    }

    public class User
    {
        public delegate void appendText(string text);
        public event appendText ReturnToText;
        private void labelToText()
        {
            ReturnToText("연결");
        }

        TcpClient client;
        public Thread workingThread;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        public NetworkStream networkStream;

        public string id;
        Packet packet;
        public Socket WorkingSocket;
        public readonly int BufferSize;
        public User(TcpClient client)
        {
            this.client = client;
            networkStream = client.GetStream();
            //id 읽어오기
            workingThread = new Thread(new ThreadStart(working));

        }
        public void working()
        {

        }
        void packetInit(Packet packet)
        {
            Init p = (Init)packet;
            this.id = p.id;
            //send drawing info to client
            WorldPaint paint = new WorldPaint();

        }
        public void Message(string msg)
        {
            //this.Invoke(new MethodInvoker(delegate ()
            //{
            //    string message = msg + "\r\n";
            //    txtLog.Text += message;
            //}));
        }
        public void Send()
        {
            this.networkStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.networkStream.Flush();
            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }
        ~User()
        {
            networkStream.Close();
            client.Close();
        }
    }
}
