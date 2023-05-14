using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TriangulareaUnuiPoligon
{
    public class Poligon
    {
        public static Random rnd = new Random();
        public Poligon()
        {
        }
        public static void drawPoints(Graphics gfx)
        {
            foreach (Point p in Eng.points)
                p.draw(gfx);
        }
        public static void drawLines(Graphics gfx)
        {
            Color color = Color.FromArgb(rnd.Next(250), rnd.Next(250), rnd.Next(250));
            Pen pen = new Pen(color);
            for (int i = 0; i < Eng.points.Count - 1; i++)
                gfx.DrawLine(pen, Eng.points[i].X, Eng.points[i].Y, Eng.points[i + 1].X, Eng.points[i + 1].Y);
            gfx.DrawLine(pen, Eng.points[Eng.points.Count - 1].X, Eng.points[Eng.points.Count - 1].Y, Eng.points[0].X, Eng.points[0].Y);
        }
        public static PointF[] MakePolygon()
        {
            PointF[] pointFs = new PointF[Eng.points.Count];
            for (int i = 0; i < pointFs.Length; i++)
            {
                pointFs[i] = new PointF(Eng.points[i].X, Eng.points[i].Y);
            }
            return pointFs;
        }
        public static PointF[] GeneratePolygon(PointF c, int n, float l)
        {
            PointF[] p = new PointF[n];
            float uc = (float)(Math.PI * 2) / (float)n;
            for (int i = 0; i < n; i++)
            {
                float x = c.X + l * (float)Math.Cos(uc * i);
                float y = c.Y + l * (float)Math.Sin(uc * i);
                p[i] = new PointF(x, y);
            }
            return p;
        }
        public static PointF[] GeneratePolygon(PointF c, int n)
        {
            int min = rnd.Next(80, 100);
            int max = rnd.Next(200, 350);
            PointF[] p = new PointF[n];
            float uc = (float)(Math.PI * 2) / (float)n;
            for (int i = 0; i < n; i++)
            {
                float l = rnd.Next(min, max);
                float x = (int)(c.X + l * (float)Math.Cos(uc * i));
                float y = (int)(c.Y + l * (float)Math.Sin(uc * i));
                p[i] = new PointF(x, y);
            }
            return p;
        }
        public static void draw(Graphics gfx, int laturi)
        {
            PointF c = new PointF(Graph.resx / 2, Graph.resy / 2);
            PointF[] p = GeneratePolygon(c, laturi);
            gfx.FillPolygon(new SolidBrush(Color.LightGray), p);
            MakeListFrom(p);
        }
        private static void MakeListFrom(PointF[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                Point point = new Point(p[i].X, p[i].Y);
                Eng.points.Add(point);
            }
        }
    }
}
