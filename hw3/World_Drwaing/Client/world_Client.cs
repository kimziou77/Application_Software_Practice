using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using World_Drwaing;
using Packet_WorldDrawing;
using System.Drawing.Drawing2D;
using static Packet_WorldDrawing.Class1;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class world_Client : Form
    {
        public string ID;
        public IPAddress IP;
        public int PORT;

        TcpClient client = new TcpClient();
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];
        public NetworkStream networkStream;
        Packet packet;

        private double ratio = 1.0F;
        private Point zoomPoint;
        
        MyDrawings md;
        
        public world_Client()
        {
            InitializeComponent();
        }
        private void world_Client_Load(object sender, EventArgs e)
        {
            OpenModal();
            SetupVar();
        }
        private void OpenModal()
        {
            worldOpen wo = new worldOpen();//얘를 모달창으로 띄워줬다가
            wo.Owner = this;
            //wo.FormClosed += Connect;
            wo.ShowDialog();
            wo.Close();
        }
        private void SetupVar()
        {
            md = new MyDrawings();
            //서버에서 받아온 정보로 wp정보 갱신하기
        }
        public void Connect(object sender, FormClosedEventArgs e)
        {
            try
            {
                client.Connect(IP, PORT);
            }
            catch(Exception ee)
            {
                MessageBox.Show("connect failed");
                this.Close();
                return;
            }
            networkStream = client.GetStream();
            FirstInit();
        }
        public void FirstInit()
        {
            Init Init = new Init(ID);
            Init.Type = (int)PacketType.INIT;//request init to server
            Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
            Send();

            networkStream.Read(readBuffer, 0, 1024 * 4);
            packet = (Packet)Packet.Desserialize(readBuffer);
            //Get drawing info from server
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
        public void Disconnect()
        {
            networkStream.Close();
            client.Close();
        }

        #region toolbar
        private void tools_Click(object sender, EventArgs e)
        {
            string name = sender.ToString();
            if (name.Equals("Pencil"))
            {
                md.line = false;
                md.rect = false;
                md.circle = false;

                toolHand.Checked = false;
                toolPencil.Checked = true;
                toolLine.Checked = false;
                toolCircle.Checked = false;
                toolRect.Checked = false;
            }
            else if (name.Equals("Line"))
            {
                md.line = true;
                md.rect = false;
                md.circle = false;

                toolHand.Checked = false;
                toolPencil.Checked = false;
                toolLine.Checked = true;
                toolCircle.Checked = false;
                toolRect.Checked = false;
            }
            else if (name.Equals("Circle"))
            {
                md.line = false;
                md.rect = false;
                md.circle = true;

                toolHand.Checked = false;
                toolPencil.Checked = false;
                toolLine.Checked = false;
                toolCircle.Checked = true;
                toolRect.Checked = false;
            }
            else if (name.Equals("Rect"))
            {
                md.line = false;
                md.rect = true;
                md.circle = false;

                toolHand.Checked = false;
                toolPencil.Checked = false;
                toolLine.Checked = false;
                toolCircle.Checked = false;
                toolRect.Checked = true;
            }
            else if (name.Equals("Hand"))
            {
                md.line = false;
                md.rect = false;
                md.circle = false;

                toolHand.Checked = true;
                toolPencil.Checked = false;
                toolLine.Checked = false;
                toolCircle.Checked = false;
                toolRect.Checked = false;
            }
            else
            {
                MessageBox.Show("[!] tools_Click : Unknown Tool");
            }
            chatBoard.Text = md.MyDrawingInfo();
        }

        private void lines_Click(object sender, EventArgs e)
        {
            int name = int.Parse(sender.ToString());
            switch (name)
            {
                case 1:
                    md.pen.Width = 1;
                    line1.Checked = true;
                    line2.Checked = false;
                    line3.Checked = false;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 2:
                    md.pen.Width = 2;
                    line1.Checked = false;
                    line2.Checked = true;
                    line3.Checked = false;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 3:
                    md.pen.Width = 3;
                    line1.Checked = false;
                    line2.Checked = false;
                    line3.Checked = true;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 4:
                    md.pen.Width = 4;
                    line1.Checked = false;
                    line2.Checked = false;
                    line3.Checked = false;
                    line4.Checked = true;
                    line4.Checked = false;
                    break;
                case 5:
                    md.pen.Width = 5;
                    line1.Checked = false;
                    line2.Checked = false;
                    line3.Checked = false;
                    line4.Checked = false;
                    line4.Checked = true;
                    break;
                default:
                    MessageBox.Show("[!] lines_Click : Unknown Line");
                    break;
            }
            chatBoard.Text = md.MyDrawingInfo();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (btnFill.Checked)
            {
                btnFill.BackColor = Color.White;
                btnFill.Checked = false;
            }
            else
            {
                btnFill.BackColor = Color.LightGray;
                btnFill.Checked = true;
            }
        }
        private void btnColor1_Click(object sender, EventArgs e)
        {
            //inner Color
            cld.Color = btnColor1.BackColor;
            cld.ShowDialog();
            btnColor1.BackColor = cld.Color;

            if (btnFill.Checked)
                md.outter = btnColor1.BackColor;
            else
                chatBoard.Text = "채우기 버튼을 누르고 다시 시도하세요";
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            //outter Color
            cld.Color = btnColor2.BackColor;
            cld.ShowDialog();
            btnColor2.BackColor = cld.Color;
            md.pen.Color = btnColor2.BackColor;
        }

        #endregion

        #region drawing 마우스 이벤트
        private void drawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            md.start.X = e.X; md.start.Y = e.Y;
        }
        private void drawingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if ((md.start.X == 0) && (md.start.Y == 0)) return;

            md.finish.X = e.X; md.finish.Y = e.Y;

            if (md.line == true)
                md.SetMyLine();
            if (md.rect == true)
                md.SetMyRect();
            if (md.circle == true)
                md.SetMyCircle();

            drawingBoard.Invalidate(true);
            drawingBoard.Update();
        }
        private void drawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (md.line == true) md.nline++;
            if (md.rect == true) md.nrect++;
            if (md.circle == true) md.ncircle++;
            md.start.X = 0;
            md.start.Y = 0;
            md.finish.X = 0;
            md.finish.Y = 0;
            chatBoard.Text = md.MyDrawingInfo();

        }
        #endregion

        #region 그림
        private void drawingBoard_Paint(object sender, PaintEventArgs e)
        {
            chatBoard.Text = md.MyDrawingInfo();
            //부드럽게 그려줌
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //chatting.Text = md.nline.ToString() + " " + md.nrect.ToString() + " " + md.ncircle.ToString() ;

            //현재 저장된 선, 사각형, 원 그리기
            for (int i = 0; i <= md.nline; i++)
            {
                if (md.mylines[i].GetPen() == null) break;

                //chatting.Text += " line  "+i+" : " + md.mylines[i].GetPen().Color;
                e.Graphics.DrawLine(md.mylines[i].LPen, md.mylines[i].getPoint1(), md.mylines[i].getPoint2());
                //왜 도중에 색이 바뀔까?
            }

            for (int i = 0; i <= md.nrect; i++)
            {
                if (md.myrect[i].GetPen() == null) break;
                //chatting.Text += " rect : " + md.myrect[i].GetPen().Color;
                if (md.myrect[i].Colored)
                {
                    SolidBrush brush = new SolidBrush(md.myrect[i].GetInner());
                    e.Graphics.FillRectangle(brush, md.myrect[i].GetRect());
                    
                }
                e.Graphics.DrawRectangle(md.myrect[i].GetPen(), md.myrect[i].GetRect());
            }
            for (int i = 0; i <= md.ncircle; i++)
            {
                if (md.mycircle[i].GetPen() == null) break;
                e.Graphics.DrawEllipse(md.mycircle[i].GetPen(), md.mycircle[i].getRectC());
            }

            chatBoard.Text = md.MyDrawingInfo();
            //chatBoard.Text += "그림 갱신 완료\r\n";
        }
        #endregion


        void zoomHandler(object sender, MouseEventArgs e)
        {
            //#region 줌 초기화
            //drawingBoard.MouseWheel += new MouseEventHandler(zoomHandler);
            //zoomPoint = new Point(drawingBoard.Width / 2, drawingBoard.Height / 2);
            //drawingBoard.Invalidate();//??
            //#endregion
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

            //PictureBox pb = (PictureBox)sender;
            Panel pn = (Panel)sender;

            if (lines > 0)
            {
                ratio *= 1.1F;
                if (ratio > 10.0) ratio = 10.0;
            }
            else if (lines < 0)
            {
                ratio *= 0.9F;
                if (ratio < 1) ratio = 1;
            }
            //모든 도형들을 기준으로 확대 해야 하는건가
            drawingBoard.Invalidate();
        }


        private void world_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Packet pk = new Packet();
            pk.Type = (int)PacketType.EXIT;
            Packet.Serialize(pk).CopyTo(this.sendBuffer, 0);
            Send();
        }


    }
    
}
