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
        MyDrawings md;


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
                    h_client.OnDrawingMessage += new handleClient.DrawingMessage(DrawPicture);
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
        private void DrawPicture(WorldPaint wp)
        {
            md.mylines = wp.mylines;
            md.mypencils = wp.mypencils;
            md.myrect = wp.myrect;
            md.mycircle = wp.mycircle;
            md.myshapes = wp.myshapes;
            md.nShape = wp.nShape;
        }
        #region 그림
        private void drawingBoard_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (md == null) return;

            for (int i = 0; i <= md.nShape; i++)
            {
                try
                {
                    switch (md.myshapes[i].type)
                    {
                        case ShapeType.PENCIL:
                            {
                                List<Point> draw = new List<Point>();

                                Pen monami = new Pen(md.myshapes[i].GetOutter());
                                monami.Width = md.myshapes[i].GetThick();

                                try
                                {
                                    foreach (Point paint in ((MyPencil)md.myshapes[i]).GetList())
                                    {
                                        Point tmp = paint;
                                        draw.Add(tmp);
                                    }
                                    e.Graphics.DrawLines(monami, draw.ToArray());
                                }
                                catch { }

                                break;
                            }
                        case ShapeType.LINE:
                            {
                                MyLines line = (MyLines)md.myshapes[i];
                                SolidBrush brush = new SolidBrush(line.GetOutter());
                                Pen pen = new Pen(brush);
                                pen.Width = line.GetThick();

                                Point p1 = line.getPoint1();

                                Point p2 = line.getPoint2();

                                e.Graphics.DrawLine(pen, p1, p2);
                                break;
                            }
                        case ShapeType.RECT:
                            {
                                Rectangle myrect = ((MyRect)md.myshapes[i]).GetRect();


                                if (!md.myrect[i].IsColored())
                                {
                                    SolidBrush brush = new SolidBrush(md.myshapes[i].GetInner());
                                    brush.Color = md.myshapes[i].GetInner();
                                    e.Graphics.FillRectangle(brush, myrect);
                                }
                                Pen pen = new Pen(md.myshapes[i].GetOutter());
                                pen.Width = md.myshapes[i].GetThick();

                                e.Graphics.DrawRectangle(pen, myrect);
                                break;
                            }
                        case ShapeType.CIRCLE:
                            {

                                Rectangle mycircle = ((MyCircle)md.myshapes[i]).getRectC();

                                if (!md.myshapes[i].IsColored())
                                {
                                    SolidBrush brush = new SolidBrush(md.myshapes[i].GetInner());
                                    brush.Color = md.myshapes[i].GetInner();
                                    e.Graphics.FillEllipse(brush, mycircle);
                                }
                                Pen pen = new Pen(md.myshapes[i].GetOutter());
                                pen.Width = md.myshapes[i].GetThick();
                                e.Graphics.DrawEllipse(pen, mycircle);
                                break;
                            }
                        default: { break; }
                    }
                }
                catch (Exception ex) { }
            }
        }
        #endregion
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
            else if (message.Equals("drawing"))
            {
                SendDrawingAll();
            }
            else
            {
                user_name = user_name.Substring(0, user_name.IndexOf("$"));
                //message = message.Substring(0, message.IndexOf("\r"));
                string displayMessage ="[ " + user_name + " ] : " + message;
                Message(displayMessage); // Server단에 출력
                SendMessageAll(message, user_name, true); // 모든 Client에게 전송
            }
        }

        public void SendDrawingAll()
        {
            foreach (var pair in clientList)
            {
                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                //if (message.Equals("leaveChat"))
                //    buffer = Encoding.Unicode.GetBytes(user_name + " 님이 퇴장했습니다.");
                //else
                //    buffer = Encoding.Unicode.GetBytes("[ " + user_name + " ] : " + message);
                
                //그림 정보 전달
                stream.Write(buffer, 0, buffer.Length); // 버퍼 쓰기
                stream.Flush();
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