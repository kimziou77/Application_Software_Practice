using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    /// <summary>
    /// 지금까지 그려졌던 선들을 저장하는 클래스
    /// </summary>
    public class MyLines : MyShape
    {
        private Point[] point = new Point[2];
        public Pen LPen;
        public MyLines()
        {
            SetType(ShapeType.LINE);
            point[0] = new Point();
            point[1] = new Point();
        }
        //setter
        public void SetLine(Point[] r)
        {
            point[0] = r[0];
            point[1] = r[1];
        }
        public void setPoint(Point start, Point finish, Pen pen,int thick,Color outter)
        {
            SetColored(false);
            point[0] = start;
            point[1] = finish;
            LPen = pen;
            SetPen(pen);
            SetThick(thick);
            SetOutter(outter);
        }
        public void setPoint(Point start, Point finish, Pen pen, int thick, Color outter,Color inner)
        {
            SetColored(true);
            point[0] = start;
            point[1] = finish;
            LPen = pen;
            SetPen(pen);
            SetThick(thick);
            SetOutter(outter);
            SetInner(inner);
            
        }


        //getter
        public Point getPoint1()
        {
            return point[0];
        }
        public Point getPoint2()
        {
            return point[1];
        }
    }
}
