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
            point[0] = new Point();
            point[1] = new Point();
        }
        //setter
        public void setPoint(Point start, Point finish, Pen pen)
        {
            point[0] = start;
            point[1] = finish;
            LPen = pen;
            SetPen(pen);
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
