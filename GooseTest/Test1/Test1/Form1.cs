using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Test1
{
    public partial class Default : Form
    {
        int move_num = -1; //이미지갱신을 위한 tick
        int dir = (int)BearMove.FRONT; //방향

        private Point mousePoint;
        public Default()
        {
            InitializeComponent();
            MoveTimer.Interval = 500;

            MoveTimer.Start();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);

        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //여기에 통신부분들어가면 좋을 것 같음
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                consoleeee.Text = file.ToString();
            }
        }



        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        // 마우스 클릭시 먼저 선언된 mousePoint변수에 현재 마우스 위치값이 들어갑니다.

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        // 클릭상태로 마우스를 이동시 이동한 만큼에서 윈도우 위치값을 빼게됩니다.

        private void form_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Default f = new Default();
            f.Show();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void NoticeForm_KeyDown(object sender, KeyEventArgs e) {
            
            if (e.KeyCode == Keys.Escape) {
                ESC_timer.Start();
            }
            else if(e.KeyCode == Keys.A)
            {
                Thread t = new Thread(new ThreadStart(Howling));
                t.Start();
                //wav파일이 들어 있는 경로를 설정해주세요
            }
            else if (e.KeyCode == Keys.S)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
        void Howling()
        {
            SoundPlayer wp = new SoundPlayer("../../sound/16478.wav");
            wp.PlaySync();
        }
        private void ESC_timer_Tick(object sender, EventArgs e)
        {
            //EscTimeDisplay.Text = (int.Parse(EscTimeDisplay.Text) + 1).ToString();
        }


        private void Default_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Escape:
                    EscTimeDisplay.Text = (int.Parse(EscTimeDisplay.Text) + 1).ToString();
                    break;
                default:
                    EscTimeDisplay.Text = "0";
                    break;

            }

        }

        private void Default_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ESC_timer.Stop();
                EscTimeDisplay.Text = "0";

                ESC_timer.Dispose();
            }
        }

        private void EscTimeDisplay_TextChanged(object sender, EventArgs e)
        {
            if (EscTimeDisplay.Text.Equals("10"))
            {
                this.Close();
            }

        }

        private void Default_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)

            {

                this.Visible = false; //창을 보이지 않게 한다.

                this.ShowIcon = false; //작업표시줄에서 제거.

                TDB_notify_icon.Visible = true; //트레이 아이콘을 표시한다.

            }
        }

        private void TDB_notify_icon_DoubleClick(object sender, EventArgs e)
        {
            //Notify Icon을 더블클릭했을시 일어나는 이벤트.

            this.Visible = true;

            this.ShowIcon = true;

            TDB_notify_icon.Visible = false; //트레이 아이콘을 숨긴다.
            this.WindowState = FormWindowState.Normal;
        }

        enum BearMove { FRONT,RIGHT,BACK,LEFT,STAND};
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            Image now = pictureBox2.Image;
            Image [,] images =new Image[4,4];
            int speed = 8;
            #region Front Image
            images[0,0]= Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front1.png");
            images[0,1]= Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front2.png");
            images[0,2]= Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front3.png");
            images[0,3]= Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front4.png");
            #endregion
            #region Right Image
            images[1, 0] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Right1.png");
            images[1, 1] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Right2.png");
            images[1, 2] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Right3.png");
            images[1, 3] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Right4.png");
            #endregion
            #region Back Image
            images[2, 0] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Back1.png");
            images[2, 1] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Back2.png");
            images[2, 2] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Back3.png");
            images[2, 3] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Back4.png");
            #endregion
            #region Left Image
            images[3, 0] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Left1.png");
            images[3, 1] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Left2.png");
            images[3, 2] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Left3.png");
            images[3, 3] = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Left4.png");
            #endregion
            move_num++; move_num %= 4;

            switch (dir)
            {
                case (int)BearMove.FRONT:
                    Location = new Point(this.Location.X, this.Location.Y + speed);
                    break;
                case (int)BearMove.RIGHT:
                    Location = new Point(this.Location.X + speed, this.Location.Y);
                    break;
                case (int)BearMove.BACK:
                    Location = new Point(this.Location.X, this.Location.Y - speed);
                    break;
                case (int)BearMove.LEFT:
                    Location = new Point(this.Location.X - speed, this.Location.Y - speed);
                    break;
                default:
                    break;

            }
            if (dir > 3) return;
            switch (move_num)
            {
                case 0:
                    pictureBox2.Image = images[dir,0];
                    break;
                case 1:
                    pictureBox2.Image = images[dir, 1];
                    break;
                case 2:
                    pictureBox2.Image = images[dir, 2];
                    break;
                case 3:
                    pictureBox2.Image = images[dir, 3];
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Random r = new Random();
            dir = r.Next(0, 5);  // 최소 min 값 부터 최대 max - 1 까지
        }
    }
}
