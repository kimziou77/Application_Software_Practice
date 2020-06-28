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
using System.IO;
using System.Threading;

namespace Client
{
    public partial class world_Client : Form
    {
        public string ID;
        public IPAddress IP;
        public int PORT;

        TcpClient clientSocket = new TcpClient(); //소켓
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;

        Packet packet;

        double ratio = 1.0F;
        Point clickPoint;
        Point zoomPoint;
        Point movePoint;
        Point imgPoint;

        MyDrawings md;
        
        public world_Client()
        {
            InitializeComponent();
            drawingBoard.MouseWheel
                += new MouseEventHandler(drawingBoard_MouseWheel);
            //img = new Bitmap(WindowsFormsApplication12.Properties.Resources.Penguins);
            imgPoint = new Point(drawingBoard.Width / 2, drawingBoard.Height / 2);
            //imgRect = new Rectangle(0, 0, img.Width, img.Height);
            ratio = 1.0;
            clickPoint = imgPoint;

        }


        private void world_Client_Load(object sender, EventArgs e)
        {
            OpenModal();
            Connect();
            SetupVar();
        }
        void Connect()
        {
            try
            {
                clientSocket.Connect(IP, PORT);
                stream = clientSocket.GetStream();
            }
            catch(Exception ex)
            {
                MessageBox.Show("서버가 실행중이 아닙니다.", "연결실패!");
                Application.Exit();
            }
            Message("채팅서버에 연결되었습니다");
            byte[] buffer = Encoding.UTF8.GetBytes(ID+"$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }
        private void GetMessage() // 메세지 받기
        {
            while (true)
            {
                try
                {
                    stream = clientSocket.GetStream();
                    int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                    byte[] buffer = new byte[BUFFERSIZE];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                    Message(message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Disconnect();
                    break;
                }
                
            }
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
        public void Disconnect()
        {
            try
            {
                byte[] buffer = Encoding.Unicode.GetBytes("leaveChat" + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            catch{  }
            
            Application.ExitThread();
            Environment.Exit(0);
        }

        #region toolbar
        private void tools_Click(object sender, EventArgs e)
        {
            string name = sender.ToString();
            if (name.Equals("Pencil"))
            {
                md.pencil = true;
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
                md.pencil = false;
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
                md.pencil = false;
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
                md.pencil = false;
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
                md.pencil = false;
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
            //chatBoard.Text = md.MyDrawingInfo();
        }

        private void lines_Click(object sender, EventArgs e)
        {
            int name = int.Parse(sender.ToString());
            switch (name)
            {
                case 1:
                    md.pen.Width = 1;
                    md.thick = 1;
                    line1.Checked = true;
                    line2.Checked = false;
                    line3.Checked = false;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 2:
                    md.pen.Width = 2;
                    md.thick = 2;
                    line1.Checked = false;
                    line2.Checked = true;
                    line3.Checked = false;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 3:
                    md.pen.Width = 3;
                    md.thick = 3;
                    line1.Checked = false;
                    line2.Checked = false;
                    line3.Checked = true;
                    line4.Checked = false;
                    line4.Checked = false;
                    break;
                case 4:
                    md.pen.Width = 4;
                    md.thick = 4;
                    line1.Checked = false;
                    line2.Checked = false;
                    line3.Checked = false;
                    line4.Checked = true;
                    line4.Checked = false;
                    break;
                case 5:
                    md.pen.Width = 5;
                    md.thick = 5;
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
            //chatBoard.Text = md.MyDrawingInfo();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (btnFill.Checked)
            {
                btnFill.BackColor = Color.White;
                btnFill.ForeColor = Color.Black;
                btnFill.Checked = false;
            }
            else
            {
                btnFill.BackColor = Color.LightGray;
                btnFill.ForeColor = Color.Blue;
                btnFill.Checked = true;
            }
        }
        private void btnColor1_Click(object sender, EventArgs e)
        {
            //inner Color
            cld.Color = btnColor1.BackColor;
            cld.ShowDialog();
            btnColor1.BackColor = cld.Color;

            if (!btnFill.Checked)
                chatBoard.Text = "채우기 버튼을 누르고 다시 시도하세요";
            md.inner = btnColor1.BackColor;
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            //outter Color
            cld.Color = btnColor2.BackColor;
            cld.ShowDialog();
            btnColor2.BackColor = cld.Color;
            md.pen.Color = btnColor2.BackColor;
            md.outter = btnColor2.BackColor;
        }

        #endregion

        #region drawing 마우스 이벤트
        private void drawingBoard_MouseWheel(object sender, MouseEventArgs e)
        {
            int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (ratio == 1)
            {
                zoomPoint = e.Location;
                lbZoom.Text = zoomPoint.X + " ," + zoomPoint.Y;
            }
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

            drawingBoard.Invalidate();
        }
        private void drawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (ratio != 1)
            {
                md.start.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - e.X) / ratio);
                md.start.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - e.Y) / ratio);
            }
            else
            {
                md.start = e.Location;
            }

            clickPoint = e.Location;
            movePoint = e.Location;
            txtCP.Text = clickPoint.X + " , " + clickPoint.Y;
        }
        private void drawingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if ((md.start.X == 0) && (md.start.Y == 0)) return;

            if (ratio != 1)
            {
                md.finish.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - e.X) / ratio);
                md.finish.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - e.Y) / ratio);
            }
            else
            {
                md.finish = e.Location;
            }

            //Hand
            if (toolHand.Checked)
            {
                int deltaX = movePoint.X - e.X;
                int deltaY = movePoint.Y - e.Y;
                movePoint = e.Location;
                for (int i = 0; i <= md.nPencil; i++)
                {
                    if (md.mypencils[i].GetPen() == null) break;
                    List<Point> draw = new List<Point>();

                    foreach (Point paint in md.mypencils[i].GetList())
                    {
                        Point tmp = paint;

                        tmp.X = paint.X - deltaX;
                        tmp.Y = paint.Y - deltaY;
                        draw.Add(tmp);
                    }
                    md.mypencils[i].SetList(draw);
                }
                for (int i = 0; i <= md.nline; i++)
                {
                    if (md.mylines[i].GetPen() == null) break;
                    Point p1 = md.mylines[i].getPoint1();
                    Point p2 = md.mylines[i].getPoint2();
                    Point[] ps = new Point[2];
                    Point np1 = new Point(p1.X - deltaX, p1.Y - deltaY);
                    Point np2 = new Point(p2.X - deltaX, p2.Y - deltaY);
                    ps[0] = np1;
                    ps[1] = np2;
                    md.mylines[i].SetLine(ps);
                }
                for (int i = 0; i <= md.nrect; i++)
                {
                    if (md.myrect[i].GetPen() == null) break;
                    Rectangle myrect = md.myrect[i].GetRect();
                    myrect.X = myrect.X - (deltaX);
                    myrect.Y = myrect.Y - (deltaY);
                    md.myrect[i].SetRect(myrect);
                }
                for (int i = 0; i <= md.ncircle; i++)
                {
                    if (md.mycircle[i].GetPen() == null) break;
                    Rectangle mycircle = md.mycircle[i].getRectC();
                    mycircle.X = mycircle.X - (deltaX);
                    mycircle.Y = mycircle.Y - (deltaY);
                    md.mycircle[i].SetRectC(mycircle);
                }
            }

            //채우기
            if (btnFill.Checked)
                md.Colored = true;
            else
                md.Colored = false;
            if (md.pencil == true)
                md.SetMyPencil();
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
            if (md.pencil == true) md.nPencil++;
            if (md.line == true) md.nline++;
            if (md.rect == true) md.nrect++;
            if (md.circle == true) md.ncircle++;
            md.start.X = 0;
            md.start.Y = 0;
            md.finish.X = 0;
            md.finish.Y = 0;
            //chatBoard.Text = md.MyDrawingInfo();
            clickPoint.X = e.X;
            clickPoint.Y = e.Y;
            txtCP.Text = clickPoint.X + " , " + clickPoint.Y;
        }
        #endregion

        #region 그림
        private void drawingBoard_Paint(object sender, PaintEventArgs e)
        {
            //chatBoard.Text = md.MyDrawingInfo();
            //부드럽게 그려줌
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //chatting.Text = md.nline.ToString() + " " + md.nrect.ToString() + " " + md.ncircle.ToString() ;

            //현재 저장된 선, 사각형, 원 그리기
            for(int i = 0; i <= md.nPencil; i++)
            {
                if (md.mypencils[i].GetPen() == null) break;
                List<Point> draw= new List<Point>();
                Pen monami = md.mypencils[i].GetPen();
                monami.Width = md.mypencils[i].GetThick();
                monami.Color = md.mypencils[i].GetOutter();
                try
                {
                    foreach(Point paint in md.mypencils[i].GetList())
                    {
                        Point tmp = paint;
                        tmp.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - paint.X) * ratio);
                        tmp.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - paint.Y) * ratio);
                        draw.Add(tmp);
                    }
                    e.Graphics.DrawLines(monami, draw.ToArray());
                }
                catch { }

            }
            for (int i = 0; i <= md.nline; i++)
            {
                if (md.mylines[i].GetPen() == null) break;

                md.mylines[i].LPen.Width = md.mylines[i].GetThick();
                md.mylines[i].LPen.Color = md.mylines[i].GetOutter();

                Point p1 = md.mylines[i].getPoint1();
                p1.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - p1.X) * ratio);
                p1.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - p1.Y) * ratio);

                Point p2 = md.mylines[i].getPoint2();
                p2.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - p2.X) * ratio);
                p2.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - p2.Y) * ratio);

                e.Graphics.DrawLine(md.mylines[i].LPen , p1, p2);
            }

            for (int i = 0; i <= md.nrect; i++)
            {
                if (md.myrect[i].GetPen() == null) break;
                Rectangle myrect = md.myrect[i].GetRect();

                myrect.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - myrect.X) * ratio);
                myrect.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - myrect.Y) * ratio);
                myrect.Width = (int)Math.Round(myrect.Width*ratio);
                myrect.Height = (int)Math.Round(myrect.Height * ratio);
                
                if (!md.myrect[i].IsColored())
                {
                    SolidBrush brush = new SolidBrush(md.myrect[i].GetInner());
                    brush.Color = md.myrect[i].GetInner();
                    e.Graphics.FillRectangle(brush, myrect);
                }

                Pen tmpPen = md.myrect[i].GetPen();
                tmpPen.Width = md.myrect[i].GetThick();
                tmpPen.Color = md.myrect[i].GetOutter();
                e.Graphics.DrawRectangle(tmpPen, myrect);
            }
            for (int i = 0; i <= md.ncircle; i++)
            {
                if (md.mycircle[i].GetPen() == null) break;

                Rectangle mycircle = md.mycircle[i].getRectC();

                mycircle.X = zoomPoint.X - (int)Math.Round((zoomPoint.X - mycircle.X) * ratio);
                mycircle.Y = zoomPoint.Y - (int)Math.Round((zoomPoint.Y - mycircle.Y) * ratio);
                mycircle.Width = (int)Math.Round(mycircle.Width * ratio);
                mycircle.Height = (int)Math.Round(mycircle.Height * ratio);

                if (!md.mycircle[i].IsColored())
                {
                    SolidBrush brush = new SolidBrush(md.mycircle[i].GetInner());
                    brush.Color = md.mycircle[i].GetInner();
                    e.Graphics.FillEllipse(brush, mycircle);
                }
                Pen tmpPen2 = md.mycircle[i].GetPen();
                tmpPen2.Width = md.mycircle[i].GetThick();
                tmpPen2.Color = md.mycircle[i].GetOutter();
                e.Graphics.DrawEllipse(tmpPen2, mycircle);
            }
            //chatBoard.Text = md.MyDrawingInfo();
        }
        #endregion


        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                chatting.Focus();
                byte[] buffer = Encoding.Unicode.GetBytes(chatting.Text + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                chatting.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Disconnect();
                Close();
            }
            
        }
        private void chatting_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // 엔터키 눌렀을 때
            {
                chatting.Text = chatting.Text.Substring(0, chatting.Text.Length - 1);
                btnSend_Click(this, e);
            }
        }
        private void world_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                string message = msg + "\r\n";
                chatBoard.Text += message;
            }));
        }
    }
    
}
