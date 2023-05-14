using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GC_6
{
    internal class Segment
    {
        public PointF Start;
        public PointF End;
        public double lenght;
        public Segment(Point S, Point E)
        {
            Start = S; End = E;
            lenght = Math.Sqrt(Math.Pow(E.X - S.X,2) + Math.Pow(E.Y - S.Y,2));
        }
        public Segment(PointF S, PointF E)
        {
            Start = S; End = E;
            lenght = Math.Sqrt(Math.Pow(E.X - S.X, 2) + Math.Pow(E.Y - S.Y, 2));
        }
    }
}
