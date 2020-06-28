using Packet_WorldDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        TcpListener server = null; //서버
        TcpClient clientSocket = null; //소켓
        static int counter = 0;// 사용자 수
        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        public WorldServer()
        {
            InitializeComponent();
        }

        private void WorldServer_Load(object sender, EventArgs e)
        {
            TcpClient TcpClient = new TcpClient();
            OpenModal();
            Thread t = new Thread(InitSocket);
            t.IsBackground = true;
            t.Start();
        }
        private void InitSocket()
        {
            server = new TcpListener(IP, PORT);
            clientSocket = default(TcpClient);
            server.Start();
            Message("서버가 시작되었습니다");
            while (true)
            {
                try
                {
                    clientSocket = server.AcceptTcpClient();
                    counter++;

                    NetworkStream stream = clientSocket.GetStream();
                    byte[] buffer = new byte[1024]; //buffer

                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string user_name = Encoding.UTF8.GetString(buffer, 0, bytes);

                    clientList.Add(clientSocket, user_name);//client List에 추가
                    user_name = user_name.Substring(0, user_name.Length - 1);
                    Message(user_name + "님이 입장했습니다.");
                    SendMessageAll(user_name + "님이 입장했습니다", "", false);
                    handleClient h_client = new handleClient();//클라이언트 추가
                    h_client.OnReceived += new handleClient.MessageDisplayHandler(OnReceived);
                    h_client.OnDisconnected += new handleClient.DisconnectedHandler(h_client_OnDisconnected);
                    h_client.startClient(clientSocket, clientList);
                }
                catch (SocketException se) { break; }
                catch (Exception ex) { break; }
            }
            clientSocket.Close();   //client 소켓 닫기
            server.Stop();          //server 종료
        }


        void h_client_OnDisconnected(TcpClient clientSocket) // cleint 접속 해제 핸들러
        {
            if (clientList.ContainsKey(clientSocket))
                clientList.Remove(clientSocket);
        }
        private void OnReceived(string message, string user_name) // cleint로 부터 받은 데이터
        {
            if (message.Equals("leaveChat"))
            {
                user_name = user_name.Substring(0, user_name.Length - 1);
                string displayMessage = user_name + "님이 퇴장하였습니다.";
                Message(displayMessage);
                SendMessageAll("leaveChat", user_name, true);
                counter--;

            }
            else
            {
                user_name = user_name.Substring(0, user_name.IndexOf("$"));
                //message = message.Substring(0, message.IndexOf("\r"));
                string displayMessage = user_name + " : " + message;
                Message(displayMessage); // Server단에 출력
                SendMessageAll(message, user_name, true); // 모든 Client에게 전송
            }
        }

        public void SendMessageAll(string message, string user_name, bool flag)
        {
            foreach (var pair in clientList)
            {
                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                if (flag)
                {
                    if (message.Equals("leaveChat"))
                        buffer = Encoding.Unicode.GetBytes(user_name + " 님이 퇴장했습니다.");
                    else
                        buffer = Encoding.Unicode.GetBytes("[ " + user_name + " ] : " + message);
                }
                else
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }
                stream.Write(buffer, 0, buffer.Length); // 버퍼 쓰기
                stream.Flush();
            }
        }

        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                string message = msg + "\r\n";
                chattingLog.Text += message;
            }));
            chattingLog.ScrollToCaret();
        }

        private void OpenModal()
        {
            worldOpen wo = new worldOpen();
            wo.Owner = this;
            wo.ShowDialog();
            //wo.FormClosed += ServerStart;
        }
    }
}