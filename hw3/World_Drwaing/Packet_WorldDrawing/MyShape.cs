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
        private bool Colored;
        private Color inner;
        private Color outter;
        private Pen pen;
        int thick;

        #region setter
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
        public void SetThick(int thick)
        {
            this.thick = thick;
        }
        public void SetColored(bool colored)
        {
            this.Colored = colored;
        }
        #endregion

        #region Getter
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
            return thick;
        }
        public Pen GetPen()
        {
            return this.pen;
        }
        public bool IsColored()
        {
            return Colored;
        }
        #endregion
    }
}
