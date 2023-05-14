using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangulareaUnuiPoligon
{
    public partial class Form1 : Form
    {
        private static Random rnd = new Random();
        private static int width;
        private static int height;
        public Form1()
        {
            InitializeComponent();
            Graph.initGraph(pictureBox1);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
        }
        private int GetInputs()
        {
            string input = textBox1.Text;
            if (input == "")
            {
                return 0;
            }
            if (float.TryParse(input, out float n))
            {
                Graph.clearGraph();
                Eng.clear();

                for (int i = 0; i < n; i++)
                {
                    Eng.points.Add(new Point(rnd.Next(width), rnd.Next(height)));
                }
            }
            else
            {
                string[] line = textBox1.Text.Split(' ');
                float X = float.Parse(line[0]);
                float Y = float.Parse(line[1]);
                Eng.points.Add(new Point(X, Y));
            }
            return Eng.points.Count;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Eng.triangles.Count == 0)
            {
                return;
            }
            foreach (Triunghi triangle in Eng.triangles)
            {
                Color color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                triangle.Draw(color);
            }
            Graph.refreshGraph();
        }

        private void Desenare_Click(object sender, EventArgs e)
        {
            Graph.gfx.Clear(Color.White);
            Eng.clear();
            int n = int.Parse(textBox1.Text);
            if (n < 3) return;
            DrawPoly(n);
            Graph.refreshGraph();
        }
        private void DrawPoly(int n)
        {
            Eng.drawPolygon(Graph.gfx, n);
        }

        public static float Area(Point A, Point B, Point C)
        {
            return 0.5f * ((A.X * B.Y) + (B.X * C.Y) + (C.X * A.Y) - (C.X * B.Y) - (A.X * C.Y) - (A.Y * B.X));
        }

        private void Triangulare_Click(object sender, EventArgs e)
        {
            double area = 0;
            int count = Eng.points.Count;
            if (count < 3) return;
            if (count == 3) { area = Area(Eng.points[0], Eng.points[1], Eng.points[2]); return; }

            List<Point> points = Eng.points;
            List<int> indexList = new List<int>();

            for (int i = 0; i < points.Count; i++)
            {
                indexList.Add(i);
            }

            Point A;
            Point B;
            Point C;

            while (indexList.Count > 3)
            {
                for (int i = 0; i < indexList.Count; i++)
                {
                    int a = indexList[i];
                    int b = GetItem(indexList, i - 1);
                    int c = GetItem(indexList, i + 1);

                    A = points[a];
                    B = points[b];
                    C = points[c];

                    int clockwise = GetTurnType(A, B, C);
                    if (clockwise != -1) continue;

                    bool isEar = true;
                    for (int j = 0; j < points.Count; j++)
                    {
                        if (j == a || j == b || j == c)
                        {
                            continue;
                        }
                        if (IsPointInTriangle(points[j], A, B, C))
                        {
                            isEar = false;
                            break;
                        }
                    }
                    if (isEar)
                    {
                        Eng.triangles.Add(new Triunghi(A, B, C));

                        indexList.RemoveAt(i);

                        Pen pen = new Pen(Color.Green);
                        Graph.gfx.DrawLine(pen, C.X, C.Y, B.X, B.Y);
                        Graph.refreshGraph();
                        break;
                    }
                }
            }

            A = points[indexList[0]];
            B = points[indexList[1]];
            C = points[indexList[2]];
            Eng.triangles.Add(new Triunghi(A, B, C));

            foreach (Triunghi triangle in Eng.triangles)
            {
                area += Math.Abs(Area(triangle.A, triangle.B, triangle.C));

            }
        }
        private bool IsPointInTriangle(Point P, Point A, Point B, Point C)
        {
            float areaOfTriangle = Math.Abs(Area(A, B, C));
            float area_APB = Math.Abs(Area(A, P, B));
            float area_APC = Math.Abs(Area(A, P, C));
            float area_BPC = Math.Abs(Area(B, P, C));
            return areaOfTriangle == area_APB + area_APC + area_BPC;
        }
        public static T GetItem<T>(List<T> list, int index)
        {
            if (index >= list.Count)
            {
                return list[index % list.Count];
            }
            else if (index < 0)
            {
                return list[index % list.Count + list.Count];
            }
            else
            {
                return list[index];
            }
        }
        private int GetTurnType(Point a, Point b, Point c)
        {
            float area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            if (area < 0) return -1;
            if (area > 0) return 1;
            return 0;
        }
    }
}
