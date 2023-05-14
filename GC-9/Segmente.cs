using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_9
{
    internal class Segmente
    {
        public PointF Start;
        public PointF End;
        public Segmente(Point S, Point E)
        {
            Start = S; End = E;
        }
        public Segmente(PointF S, PointF E)
        {
            Start = S; End = E;
        }
    }
}
