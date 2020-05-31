using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingNotepad
{
    /// <summary>
    /// 지금까지 그려졌던 원들을 저장하는 클래스
    /// </summary>
    class MyCircle
    {
        private Rectangle rectC;
        private int thick;
        private bool isSolid;
        public MyCircle()
        {
            rectC = new Rectangle();
            thick = 1;
            isSolid = true;
        }

        public void setRectC(Point start, Point finish, int thick, bool isSolid)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);
            this.thick = thick;
            this.isSolid = isSolid;
        }

        //getter
        public Rectangle getRectC()
        {
            return rectC;
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
