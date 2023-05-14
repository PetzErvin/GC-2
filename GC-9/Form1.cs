using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GC_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 0;
        bool enableDrawing;
        Bitmap btm;
        Bitmap btm2;
        Graphics g;
        Graphics g2;
        public List<PointF> points = new List<PointF>();
        public List<PointF> pointsordered = new List<PointF>();
        List<Segmente> diagonale = new List<Segmente>();
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (n > 1)
            {
                g.DrawLine(new Pen(Color.Black), points[points.Count - 1], points[0]);
                pictureBox1.Image = btm;
                enableDrawing = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (enableDrawing)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                PointF aux = me.Location;
                points.Add(aux);
                n++;
                if (n > 1)
                { g.DrawLine(new Pen(Color.Black), points[points.Count - 2], points[points.Count - 1]); }
                 //g2.DrawLine(new Pen(Color.Black), points[points.Count - 2], points[points.Count - 1]); }
                g.FillEllipse(new SolidBrush(Color.Gray), aux.X, aux.Y, 20, 20);
                g.DrawString(n.ToString(), new Font(FontFamily.GenericSerif, 15), new SolidBrush(Color.Black), aux.X, aux.Y);
                pictureBox1.Image = btm;
            }
        }
        private void Copy(List<PointF> pointscopy, List<PointF> points)
        {
            foreach (var el in points)
                pointscopy.Add(el);
        }

        private void partitionare_button_Click(object sender, EventArgs e)
        {
            Copy(pointsordered, points);
            Order(pointsordered);
            /*for (int i = 0; i < pointsordered.Count; i++)
            {
                g2.FillEllipse(new SolidBrush(Color.Gray), pointsordered[i].X, pointsordered[i].Y, 20, 20);
                g2.DrawString((i+1).ToString(), new Font(FontFamily.GenericSerif, 15), new SolidBrush(Color.Black), pointsordered[i].X, pointsordered[i].Y);
            }*/
            //pictureBox2.Image = btm2;
            for (int i = 0; i < points.Count; i++)
            {
                if(UnghiReflex(i))
                {
                    //g.FillEllipse(new SolidBrush(Color.Yellow), points[i].X, points[i].Y, 20, 20);
                    if (points[(i-1+n)%n].Y > points[i].Y && points[(i + 1) % n].Y > points[i].Y) // sub varf
                    {
                        //g.FillEllipse(new SolidBrush(Color.Purple), points[i].X, points[i].Y, 20, 20);
                        int find = findPointAbove(i);
                        if (find != -1)
                        { 
                            g.DrawLine(new Pen(Color.Blue), points[i], points[points.IndexOf(pointsordered[find])]);
                            g.FillEllipse(new SolidBrush(Color.Red), points[i].X, points[i].Y, 20, 20);
                            //g.DrawString(n.ToString(), new Font(FontFamily.GenericSerif, 15), new SolidBrush(Color.Black), points[i].X, points[i].Y);

                        }
                    }
                    else
                    if (points[(i - 1 + n)% n].Y < points[i].Y && points[(i + 1) % n].Y < points[i].Y) // deasupra varf
                    {
                        //g.FillEllipse(new SolidBrush(Color.Pink), points[i].X, points[i].Y, 20, 20);
                        int find = findPointBelow(i);
                        if (find != -1)
                        { 
                            g.DrawLine(new Pen(Color.Blue), points[i], points[points.IndexOf(pointsordered[find])]); 
                            g.FillEllipse(new SolidBrush(Color.Red), points[i].X, points[i].Y, 20, 20);
                            //g.DrawString(n.ToString(), new Font(FontFamily.GenericSerif, 15), new SolidBrush(Color.Black), points[i].X, points[i].Y);

                        }
                    }
                }
            }
            pictureBox1.Image = btm;
        }

        private int findPointBelow(int i)
        {
            int limit = pointsordered.IndexOf(points[i]);
            for (int j = limit; j < pointsordered.Count; j++)
            {
                if(IsDiagonal(limit,j))
                { return j; }
            }
            return -1;
        }

        private int findPointAbove(int i)
        {
            int limit = pointsordered.IndexOf(points[i]);
            for (int j = limit; j >= 0; j--)
            {
                if (IsDiagonal(limit, j))
                { return j; }
            }
            return -1;
        }

        private bool UnghiReflex(int i)
        {
            if (Determinant(points[(i - 1 + n )%n], points[i], points[(i + 1) % n]) <= 0)
                return true;
            return false;
        }

        private void Order(List<PointF> pointsordered)
        {
            int min;
            for (int i = 0; i < pointsordered.Count - 1; i++)
            {
                min = i;
                for (int j = i+1; j < pointsordered.Count; j++)
                {
                    if ((pointsordered[min].Y > pointsordered[j].Y) || (pointsordered[min].Y == pointsordered[j].Y && pointsordered[min].X > pointsordered[j].X) )
                        min = j; 
                }
                if (min != i)
                    Swap(min, i, pointsordered);
            }
        }

        private void Swap(int min, int i, List<PointF> points)
        {
            min = min % n;
            PointF p = points[min];
            points[min] = points[i];
            points[i] = p;
        }

        float Determinant(PointF A, PointF B, PointF C)
        {
            return A.X * B.Y + B.X * C.Y + A.Y * C.X - B.Y * C.X - A.X * C.Y - A.Y * B.X;
        }
        private bool IsDiagonal(int p1, int p2)
        {
            p1 = points.IndexOf(pointsordered[p1]);
            p2 = points.IndexOf(pointsordered[p2]);
            return EsteInPoligon(p1, p2) && !(IntersecteazaLaturaNeincidenta(new Segmente(points[p1], points[p2]))) && !(IntersecteazaDiagonaleAnterioare(new Segmente(points[p1], points[p2])));
        }
        private bool EsteInPoligon(int i, int j)
        {
            //if (EsteVarfConvex(i))
            {
                if (Determinant(points[i], points[j % n], points[(i + 1) % n]) < 0 && Determinant(points[i], points[(i - 1 + n) % n], points[j % n]) < 0)
                    return true;
            }
            return false;
        }

        private bool EsteVarfConvex(int i)
        {
            if (Determinant(points[(i - 1 + points.Count) % points.Count], points[i], points[(i + 1 + points.Count) % points.Count]) > 0)
                return true;
            return false;
        }
        private bool IntersectWith(Segmente seg, Segmente segment)
        {
            if (seg.Start != segment.Start && seg.Start != segment.End && seg.End != segment.Start && seg.End != segment.End)
                if (Determinant(segment.Start, segment.End, seg.Start) * Determinant(segment.Start, segment.End, seg.End) <= 0)
                    if (Determinant(seg.Start, seg.End, segment.Start) * Determinant(seg.Start, seg.End, segment.End) <= 0)
                        return true;
            return false;
        }

        private bool IntersecteazaDiagonaleAnterioare(Segmente aux)
        {
            for (int i = 0; i < diagonale.Count; i++)
            {
                if (aux != diagonale[i])
                    if (IntersectWith(aux, diagonale[i]))
                        return true;
            }

            return false;
        }

        private bool IntersecteazaLaturaNeincidenta(Segmente aux)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (aux.Start != points[i] && aux.Start != points[i + 1] && aux.End != points[i] && aux.End != points[i + 1])
                    if (IntersectWith(aux, new Segmente(points[i], points[i + 1])))
                        return true;
            }

            if (aux.Start != points[0] && aux.Start != points[0] && aux.End != points[points.Count - 1] && aux.End != points[points.Count - 1])
                if (IntersectWith(aux, new Segmente(points[0], points[points.Count - 1])))
                    return true;
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //btm2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g = Graphics.FromImage(btm);
            //g2 = Graphics.FromImage(btm2);
            enableDrawing = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
