using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphics_Practice
{
    public partial class Snowman : Form
    {
        private Random rand;
        private int X, Y;
        Pen whitePen = new Pen(Color.White, 2);


        private void Snowman_Load(object sender, EventArgs e)
        {
            //눈사람을 그릴 좌표 설정
            X = (int)this.Width / 2;
            Y = (int)this.Height - 140;
            //랜덤객체 시드 초기화
            DateTime currentTime = DateTime.Now;
            rand = new Random(currentTime.Millisecond);
            //타이머 셋팅
            timer1.Interval = 2000;
            timer1.Enabled = true;
        }

        private void Snowman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //빨간생 모자를 그릴 펜과 브러쉬
            Pen redPen = new Pen(Color.IndianRed);
            SolidBrush redBr = new SolidBrush(Color.IndianRed);
            //눈사람을 그릴 화이트 브러쉬
            SolidBrush whiteBr = new SolidBrush(Color.White);

            //3단 눈사람
            g.FillEllipse(whiteBr, X, Y, 100, 100);
            Y -= 80; X += 10;
            g.FillEllipse(whiteBr, X, Y, 80, 80);
            Y -= 60; X += 10;
            g.FillEllipse(whiteBr, X, Y, 60, 60);

            //모자
            g.DrawLine(redPen, X - 10, Y, X + 70, Y);
            g.FillRectangle(redBr, X + 10, Y - 40, 40, 40);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < 400; i++)
            {
                X = rand.Next(1, this.Width);
                Y = rand.Next(1, this.Height);
                g.DrawLine(whitePen, X, Y, X + 1, Y + 1);
            }
        }

        public Snowman()
        {
            InitializeComponent();
            this.BackColor = Color.Black;

        }
    }
}

