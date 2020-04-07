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


namespace Test1
{
    public partial class Default : Form
    {
        private Point mousePoint;
        public Default()
        {
            InitializeComponent();
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
                SoundPlayer wp = new SoundPlayer("../../sound/16478.wav");
                wp.PlaySync();
                //wav파일이 들어 있는 경로를 설정해주세요
            }
            else if (e.KeyCode == Keys.S)
            {

                this.WindowState = FormWindowState.Minimized;
            }
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
        //Bitmap bit;

        //protected override void OnLoad(EventArgs e)
        //{

        //    bit = new Bitmap("../../img/ogu.gif");

        //    ImageAnimator.Animate(bit, new EventHandler(this.OnFrameChanged));

        //    base.OnLoad(e);

        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{

        //    ImageAnimator.UpdateFrames();

        //    Graphics g = pictureBox1.CreateGraphics();

        //    g.DrawImage(this.bit, new Point(0, 0));

        //    base.OnPaint(e);

        //}

        //private void OnFrameChanged(object sender, EventArgs e)
        //{

        //    this.Invalidate();

        //}

    }
}
