using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingNotepad
{
    public partial class Drawing : Form
    {
        //폼에서 사용할 변수들
        private bool line;
        private bool rect;
        private bool circle;

        private Point start;//도형 시작점
        private Point finish;//도형 끝 점

        private Pen pen;
        private int nline;
        private int nrect;
        private int ncircle;

        private int i;          
        private int thick;      //선 두께
        private bool isSolid;   //선 종류 (실선,점선)

        private MyLines[] mylines;
        private MyRect[] myrect;
        private MyCircle[] mycircle;
        public Drawing()
        {
            InitializeComponent();
            SetupVar();
        }

        private void SetupVar()
        {
            i = 0;
            thick = 1;
            isSolid = true;
            line = false;
            rect = false;
            circle = false;
            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(Color.Black);

            mylines = new MyLines[100];
            myrect = new MyRect[100];
            mycircle = new MyCircle[100];

            nline = 0;
            nrect = 0;
            ncircle = 0;
            line0Button.Pushed = true;
            line1Button.Pushed = false;
            line2Button.Pushed = false;
            line3Button.Pushed = false;
            SetupMine(); //선, 사각형, 원의 저장 클래스 초기화.
        }

        private void SetupMine()
        {
            for (int i = 0; i < 100; i++)
                mylines[i] = new MyLines();
            for (int i = 0; i < 100; i++)
                myrect[i] = new MyRect();
            for (int i = 0; i < 100; i++)
                mycircle[i] = new MyCircle();
        }


        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if(e.Button == newButton)//새로만들기
            {
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = false;
                this.line3Button.Pushed = false;//점선 false
                SetupVar(); //폼에서 사용할 변수들을 다시 초기화
                panel1.Refresh();//Panel을 refresh 하게 된다.
                  
            }
            if(e.Button == lineButton)//선 버튼
            {
                line = true;
                rect = false;
                circle = false;
                this.lineButton.Pushed = true;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = false;
            }
            if (e.Button == rectButton)//사각형 버튼
            {
                line = false;
                rect = true;
                circle = false;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = true;
                this.circleButton.Pushed = false;
            }
            if (e.Button == circleButton)//원 버튼
            {
                line = false;
                rect = false;
                circle = true;
                this.lineButton.Pushed = false;
                this.rectButton.Pushed = false;
                this.circleButton.Pushed = true;
            }
            if (e.Button == line0Button)//굵기 1 기본 실선 버튼
            {
                thick = 1;
                this.line0Button.Pushed = true;
                this.line1Button.Pushed = false;
                this.line2Button.Pushed = false;
            }
            
            if (e.Button == line1Button)//굵기 3
            {
                thick = 3;
                this.line0Button.Pushed = false;
                this.line1Button.Pushed = true;
                this.line2Button.Pushed = false;
            }
            if (e.Button == line2Button)//굵기 5
            {
                thick = 5;
                this.line0Button.Pushed = false;
                this.line1Button.Pushed = false;
                this.line2Button.Pushed = true;
            }


            if (e.Button == line3Button)//점선
            {
                if (line3Button.Pushed)
                {
                    line3Button.Pushed = false;
                    isSolid = true;
                }
                else
                {
                    line3Button.Pushed = true;
                    isSolid = false;
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            start.X = e.X;      start.Y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((start.X == 0) && (start.Y == 0)) return;
            finish.X = e.X;     finish.Y = e.Y;

            if (line == true)
                mylines[nline].setPoint(start, finish, thick, isSolid);
            if (rect == true)
                myrect[nrect].setRect(start, finish, thick, isSolid);
            if (circle == true)
                mycircle[ncircle].setRectC(start, finish, thick, isSolid);
            panel1.Invalidate(true);
            panel1.Update();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (line == true) nline++;
            if (rect == true) nrect++;
            if (circle == true) ncircle++;
            start.X = 0;
            start.Y = 0;
            finish.X = 0;
            finish.Y = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //부드럽게 그려줌
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //현재 저장된 선, 사각형, 원 그리기
            for (i = 0; i <= nline; i++)
            {
                if (!mylines[i].getSolid())
                {
                    pen.Width = mylines[i].getThick();
                    pen.DashStyle = DashStyle.Dot;
                }
                else
                {
                    pen.Width = mylines[i].getThick();
                    pen.DashStyle = DashStyle.Solid;
                }
                e.Graphics.DrawLine(pen, mylines[i].getPoint1(), mylines[i].getPoint2());
            }

            for (i = 0; i <= nrect; i++)
            {
                if (!myrect[i].getSolid())
                {
                    pen.Width = myrect[i].getThick();
                    pen.DashStyle = DashStyle.Dot;
                }
                else
                {
                    pen.Width = myrect[i].getThick();
                    pen.DashStyle = DashStyle.Solid;
                }
                e.Graphics.DrawRectangle(pen, myrect[i].getRect());
            }

            for (i = 0; i <= ncircle; i++)
            {
                if (!mycircle[i].getSolid())
                {
                    pen.Width = mycircle[i].getThick();
                    pen.DashStyle = DashStyle.Dot;
                }
                else
                {
                    pen.Width = mycircle[i].getThick();
                    pen.DashStyle = DashStyle.Solid;
                }
                e.Graphics.DrawEllipse(pen, mycircle[i].getRectC());
            }
            //pen.Width = thick;
            //pen.DashStyle = DashStyle.Solid;

        }
    }
}
