using System;
using System.Drawing;

namespace TriangulareaUnuiPoligon
{
    public class Triunghi
    {
        public Point A;
        public Point B;
        public Point C;
        public Triunghi(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Triunghi(int idx1, int idx2, int idx3)
        {
            this.A = Eng.points[idx1];
            this.B = Eng.points[idx2];
            this.C = Eng.points[idx3];
        }
        public void Draw(Color color)
        {
            Pen pen = new Pen(color);
            SolidBrush sb = new SolidBrush(color);
            PointF[] pointf = new PointF[3];
            pointf[0] = new PointF(A.X, A.Y);
            pointf[1] = new PointF(B.X, B.Y);
            pointf[2] = new PointF(C.X, C.Y);
            Graph.gfx.FillPolygon(sb, pointf);
        }
    }
}