using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    public class MyRect : MyShape
    {
        private Rectangle rect;

        public MyRect()
        {
            rect = new Rectangle();
        }
        public void setRect(Point start, Point finish ,Pen pen)
        {
            Colored = false;
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(start.Y - finish.Y);
            rect.Width = Math.Abs(start.X - finish.X);
            SetPen(pen);
        }
        public void setRect(Point start, Point finish, Pen pen, Color inner, Color outter)
        {
            Colored = true;
            setRect(start, finish, pen);
            SetInner(inner);
            SetOutter(outter);
        }
        public Rectangle GetRect()
        {
            return rect;
        }
    }
}
