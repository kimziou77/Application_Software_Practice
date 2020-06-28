using Packet_WorldDrawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Packet_WorldDrawing.Class1;

namespace World_Drwaing
{
    class handleClient
    {
        TcpClient clientSocket = null;
        public Dictionary<TcpClient, string> clientList = null;

        public void startClient(TcpClient clientSocket, Dictionary<TcpClient, string> clientList)
        {
            this.clientSocket = clientSocket;
            this.clientList = clientList;

            Thread t_hanlder = new Thread(doChat);
            t_hanlder.IsBackground = true;
            t_hanlder.Start();

        }

        public delegate void MessageDisplayHandler(string message, string user_name);
        public event MessageDisplayHandler OnReceived;

        public delegate void DisconnectedHandler(TcpClient clientSocket);
        public event DisconnectedHandler OnDisconnected;

        public delegate void DrawingMessage(WorldPaint md);
        public event DrawingMessage OnDrawingMessage;

        private void doChat()
        {
            NetworkStream stream = null;
            try
            {
                byte[] buffer = new byte[1024*100];
                string msg = string.Empty;
                int bytes = 0;
                int MessageCount = 0;
                stream = clientSocket.GetStream();

                while (true)
                {
                    MessageCount++;
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    msg = Encoding.Unicode.GetString(buffer, 0, bytes);
                    msg = msg.Substring(0, msg.IndexOf("$"));
                    if (msg.Equals("이미지전송"))
                    {
                        try
                        {
                            bytes = stream.Read(buffer, 0, buffer.Length);
                        }
                        catch(Exception ex) { MessageBox.Show(ex.Message); }
                        Packet packet = (Packet)Packet.Desserialize(buffer);

                        WorldPaint wp = (WorldPaint)packet;
                        
                        OnDrawingMessage(wp);

                        //받고나서
                        //모두에게 뿌리기
                    }
                    if (OnReceived != null)
                        OnReceived(msg, clientList[clientSocket].ToString());
                }
            }
            catch (SocketException se)
            {
                Trace.WriteLine(string.Format("doChat - SocketException : {0}", se.Message));

                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("doChat - Exception : {0}", ex.Message));
                if (clientSocket != null)
                {
                    if (OnDisconnected != null)
                        OnDisconnected(clientSocket);

                    clientSocket.Close();
                    stream.Close();
                }
            }
        }


    }
}
