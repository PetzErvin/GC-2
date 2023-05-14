using System.Collections.Generic;
using System.Drawing;

namespace TriangulareaUnuiPoligon
{
    public static class Eng
    {
        public static List<Point> points = new List<Point>();
        public static List<Triunghi> triangles = new List<Triunghi>();
        public static List<Point> hull = new List<Point>();
        public static void draw(Graphics gfx)
        {
            drawPoints(gfx);
            drawLines(gfx);
        }
        public static void drawPolygon(Graphics gfx, int laturi)
        {
            Poligon.draw(gfx, laturi);
        }
        public static void drawPoints(Graphics gfx)
        {
            foreach (Point p in points)
                p.draw(gfx);
        }
        public static void DrawHull(Graphics gfx)
        {
            Color color = Color.Red;
            Pen pen = new Pen(color);

            //draw hull lines
            for (int i = 0; i < hull.Count - 1; i++)
            {
                hull[i].drawColor = color;
                hull[i].fillColor = color;
                gfx.DrawLine(pen, hull[i].X, hull[i].Y, hull[i + 1].X, hull[i + 1].Y);
            }
            hull[hull.Count - 1].drawColor = color;
            hull[hull.Count - 1].fillColor = color;
            gfx.DrawLine(pen, hull[hull.Count - 1].X, hull[hull.Count - 1].Y, hull[0].X, hull[0].Y);

            //draw hull points
            foreach (Point p in hull)
                p.draw(gfx);
        }
        private static void DrawMyLine(List<Point> points1, int idx1, List<Point> points2, int idx2, Color lineColor)
        {
            Pen pen = new Pen(lineColor);
            Graph.gfx.DrawLine(pen, points1[idx1].X, points1[idx1].Y, points2[idx2].X, points2[idx2].Y);
        }
        private static void DrawMyLine(int idx1, int idx2, Color lineColor)
        {
            DrawMyLine(points, idx1, points, idx2, lineColor);
        }
        private static void DrawMyLine(int idx1, int idx2)
        {
            DrawMyLine(idx1, idx2, Color.Black);
        }
        public static void drawLines(Graphics gfx)
        {
            for (int i = 0; i < points.Count - 1; i++)
                gfx.DrawLine(Pens.Black, points[i].X, points[i].Y, points[i + 1].X, points[i + 1].Y);
            gfx.DrawLine(Pens.Black, points[points.Count - 1].X, points[points.Count - 1].Y, points[0].X, points[0].Y);
        }
        public static void remove()
        {
            points.RemoveAt(points.Count - 1);
        }
        public static void clear()
        {
            points.Clear();
            hull.Clear();
            triangles.Clear();
        }
    }
}