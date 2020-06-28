using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet_WorldDrawing
{
    [Serializable]
    public class MyPencil : MyShape
    {
        private List<Point> pointList;
        public MyPencil()
        {
            SetType(ShapeType.PENCIL);
            pointList = new List<Point>();
        }
        public void setPencil(Point current, int thick, Color outter)
        {
            SetColored(false);
            SetThick(thick);
            SetOutter(outter);
            pointList.Add(current);
        }
        public List<Point> GetList()
        {
            return pointList;
        }
        public void SetList(List<Point> newList)
        {
            pointList = newList;
        }
    }
}
