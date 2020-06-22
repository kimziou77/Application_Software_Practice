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
        public bool line;
        public bool rect;
        public bool circle;

        public Point start;//도형 시작점
        public Point finish;//도형 끝 점

        public Pen pen;
        public int nline;
        public int nrect;
        public int ncircle;

        public Color outter;

        public MyLines[] mylines;
        public MyRect[] myrect;
        public MyCircle[] mycircle;


        public MyDrawings()
        {
            SetUpValue();
        }
        MyDrawings(MyDrawings md)
        {

        }
        void SetUpValue()
        {
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
            SetUpMine();
        }
        void SetUpMine()//선, 사각형, 원의 저장 클래스 초기화.
        {
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
            s += "line : " + line.ToString() + "\r\n";
            s += "rect : " + rect.ToString() + "\r\n";
            s += "circle : " + circle.ToString() + "\r\n";
            s += "start : " + start.ToString()
              +" finish :  "+finish.ToString()+"\r\n";
            s += "pen : " + pen.Color.ToString() + "\r\n";
            s += "nline : " + nline.ToString()
              + " nrect :  " + nrect.ToString()
              + " ncircle : " + ncircle.ToString() +"\r\n";
            s += "thick : " + pen.Width.ToString() + "\r\n";

            return s;
        }

        public void SetMyLine()
        {
            mylines[nline].setPoint(start, finish, pen);
        }


        public void SetMyRect()
        {
            myrect[nrect].setRect(start, finish, pen);
        }
        public void SetMyRect(Color inner)
        {
            myrect[nrect].setRect(start, finish, pen, inner, outter);
        }


        public void SetMyCircle()
        {
            mycircle[ncircle].setRectC(start, finish, pen);
        }
        public void SetMyCircle(Color inner)
        {
            mycircle[ncircle].setRectC(start, finish, pen, inner, outter);
        }
    }
}

