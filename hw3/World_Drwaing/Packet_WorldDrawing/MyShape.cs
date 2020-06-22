using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    public class MyShape
    {
        public bool Colored;
        private Color inner;
        private Color outter;
        private Pen pen;

        public void SetInner(Color inner)
        {
            this.inner = inner;
        }
        public void SetOutter(Color outter)
        {
            this.outter = outter;
        }
        public void SetPen(Pen pen)
        {
            this.pen = pen;
        }
        public Color GetInner()
        {
            return inner;
        }
        public Color GetOutter()
        {
            return outter;
        }
        public int GetThick()
        {
            return (int)pen.Width;
        }
        public Pen GetPen()
        {
            return pen;
        }
    }
}
