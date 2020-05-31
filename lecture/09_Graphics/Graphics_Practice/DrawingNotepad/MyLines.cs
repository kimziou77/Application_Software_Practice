using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DrawingNotepad
{
    /// <summary>
    /// 지금까지 그려졌던 선들을 저장하는 클래스
    /// </summary>
    class MyLines
    {
        private Point[] point = new Point[2];
        private int thick;
        private bool isSolid;
        public MyLines()
        {
            point[0] = new Point();
            point[1] = new Point();
            thick = 1;
            isSolid = true;
        }

        //setter
        public void setPoint(Point start, Point finish, int thick, bool isSolid)
        {
            point[0] = start;
            point[1] = finish;
            this.thick = thick;
            this.isSolid = isSolid;
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
        public int getThick()
        {
            return thick;
        }
        public bool getSolid()
        {
            return isSolid;
        }
    }
}
