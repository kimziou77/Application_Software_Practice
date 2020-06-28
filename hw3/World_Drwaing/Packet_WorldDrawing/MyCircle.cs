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
    [Serializable]
    public class MyCircle : MyShape
    {
        private Rectangle rectC;
        public MyCircle()
        {
            SetType(ShapeType.CIRCLE);
            rectC = new Rectangle();
        }

        public void setRectC(Point start, Point finish,int thick,Color outter)
        {
            SetColored(false);
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);
            SetThick(thick);
            SetOutter(outter);
        }
        public void SetRectC(Rectangle r)
        {
            rectC = r;
        }
        public void setRectC(Point start, Point finish,int thick,Color inner , Color outter)
        {
            SetColored(true);
            setRectC(start, finish,thick,outter);
            SetInner(inner);
            SetOutter(outter);
        }
        public Rectangle getRectC()
        {
            return rectC;
        }
    }
}
