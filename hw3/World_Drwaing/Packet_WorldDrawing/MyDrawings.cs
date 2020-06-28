using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    public class MyDrawings
    {
        //폼에서 사용할 변수들
        public bool Colored;
        public bool pencil;
        public bool line;
        public bool rect;
        public bool circle;

        public Point start;//도형 시작점
        public Point finish;//도형 끝 점

        public Pen pen;

        public int nPencil;
        public int nline;
        public int nrect;
        public int ncircle;
        public int thick;

        public Color inner;
        public Color outter;


        public MyLines[] mylines;
        public MyRect[] myrect;
        public MyCircle[] mycircle;
        public MyPencil[] mypencils;

        public MyDrawings()
        {
            SetUpValue();
        }
        MyDrawings(MyDrawings md)
        {

        }
        void SetUpValue()
        {
            thick = 1;
            pencil = true;
            line = false;
            rect = false;
            circle = false;

            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(Color.Black);

            outter = Color.Black;
            inner = Color.White;
            mypencils = new MyPencil[100];
            mylines = new MyLines[100];
            myrect = new MyRect[100];
            mycircle = new MyCircle[100];

            nPencil = 0;
            nline = 0;
            nrect = 0;
            ncircle = 0;
            SetUpMine();
        }
        void SetUpMine()//선, 사각형, 원의 저장 클래스 초기화.
        {
            for (int i = 0; i < 100; i++)
                mypencils[i] = new MyPencil();
            for (int i = 0; i < 100; i++)
                mylines[i] = new MyLines();
            for (int i = 0; i < 100; i++)
                myrect[i] = new MyRect();
            for (int i = 0; i < 100; i++)
                mycircle[i] = new MyCircle();
        }

        public string  MyDrawingInfo()
        {
            string s = "";
            s += "start : " + start.ToString()
              +" finish :  "+finish.ToString()+"\r\n";
            s += "pen : " + pen.Color.ToString() + "\r\n";
            s += "inner : " + inner.ToString()
              + " outter : " + outter.ToString() + "\r\n";
            s += "Colored ? " + Colored.ToString() + "\r\n";
            s += "nline : " + nline.ToString()
              + " nrect :  " + nrect.ToString()
              + " ncircle : " + ncircle.ToString()
              + " npencil : " + nPencil.ToString() +"\r\n";
            s += "thick : " + pen.Width.ToString() + "\r\n";

            return s;
        }

        public void SetMyPencil()
        {
            mypencils[nPencil].setPencil(finish,pen, thick, outter);
        }
        public void SetMyLine()
        {
            if(!Colored)
                mylines[nline].setPoint(start, finish, pen,thick,outter);
            else
                mylines[nline].setPoint(start, finish, pen, thick, outter,inner);
        }

        public void SetMyRect()
        {
            if(!Colored)
                myrect[nrect].setRect(start, finish, pen,thick,outter);
            else
            {
                myrect[nrect].setRect(start, finish, pen, thick, outter, inner);
            }
        }
        public void SetMyRect(Color inner)
        {
            if(!Colored)
                myrect[nrect].setRect(start, finish, pen, thick, outter);
            else
                myrect[nrect].setRect(start, finish, pen, thick, outter,inner);
        }

        public void SetMyCircle()
        {
            if(!Colored)
                mycircle[ncircle].setRectC(start, finish, pen,thick, outter);
            else
                mycircle[ncircle].setRectC(start, finish, pen, thick, inner, outter);
        }

    }
}

