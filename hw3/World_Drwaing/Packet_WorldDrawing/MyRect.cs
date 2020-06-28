using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
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
            SetType(ShapeType.RECT);
            rect = new Rectangle();
        }
        public void setRect(Point start, Point finish ,Pen pen,int thick,Color outter)
        {
            SetColored(false);
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(start.Y - finish.Y);
            rect.Width = Math.Abs(start.X - finish.X);
            SetPen(pen);
            SetThick(thick);
            SetOutter(outter);
        }
        public void SetRect(Rectangle r)
        {
            rect = r;
        }
        public void setRect(Point start, Point finish, Pen pen,int thick,  Color outter, Color inner)
        {
            SetColored(true);
            setRect(start, finish, pen,thick,outter);
            SetInner(inner);
            SetOutter(outter);
        }
        public Rectangle GetRect()
        {
            return rect;
        }
    }
}
