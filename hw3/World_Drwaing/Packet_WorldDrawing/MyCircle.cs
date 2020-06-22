using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    /// <summary>
    /// 지금까지 그려졌던 원들을 저장하는 클래스
    /// </summary>
    public class MyCircle : MyShape
    {
        private Rectangle rectC;
        public MyCircle()
        {
            rectC = new Rectangle();
        }

        public void setRectC(Point start, Point finish, Pen pen)
        {
            Colored = false;
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);
            SetPen(pen);
        }

        public void setRectC(Point start, Point finish, Pen pen,Color inner , Color outter)
        {
            Colored = true;
            setRectC(start, finish, pen);
            SetInner(inner);
            SetOutter(outter);
        }
        public Rectangle getRectC()
        {
            return rectC;
        }
    }
}
