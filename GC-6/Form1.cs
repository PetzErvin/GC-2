using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GC_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool enableDrawing;
        public List<PointF> points = new List<PointF>();
        public Graphics g;
        public Bitmap btm;
        public int n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (n > 1)
            {
                g.DrawLine(new Pen(Color.Black), points[points.Count - 1], points[0]);
                pictureBox1.Image = btm;
                enableDrawing = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            enableDrawing = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (enableDrawing)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                PointF aux = me.Location;
                    points.Add(aux);
                    //g.DrawEllipse(new Pen(Color.Black), aux.X, aux.Y, 20, 20);
                    n++;
                    if (n > 1)
                        g.DrawLine(new Pen(Color.White), points[points.Count - 2], points[points.Count - 1]);
                    g.FillEllipse(new SolidBrush(Color.Red), aux.X, aux.Y, 20, 20);
                    g.DrawString(n.ToString(), new Font(FontFamily.GenericSerif, 15), new SolidBrush(Color.Black), aux.X, aux.Y);
                    pictureBox1.Image = btm;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 2; i < n - 1; i++)
            {
                g.DrawLine(new Pen(Color.White), points[0], points[i]);
            }
            pictureBox1.Image = btm;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            points.Clear();
            g.Clear(Color.LightSteelBlue);
            pictureBox1.Image = btm;
            enableDrawing = true;
            n = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int n = rnd.Next(5, 10);

            Point[] p = new Point[n];
            Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(btm);
            Pen pen = new Pen(Color.Gray, 2);
            int x, y;

            for (int i = 0; i < n; i++)
            {
                x = rnd.Next(0, pictureBox1.Width);
                y = rnd.Next(0, pictureBox1.Height);
                p[i] = new Point(x, y);
            }
            for (int i = 0; i < p.Length; i++)
            {
                g.DrawEllipse(new Pen(Color.Black), p[i].X, p[i].Y, 10, 10);
            }
            
            pictureBox1.Image = btm;
            List<Segment> allSegmente = new List<Segment>();
            List<Segment> segmente = new List<Segment>();
            segmente.Add(new Segment(p[0],p[1]));
            for (int i = 0; i < p.Length - 1; i++)
            {
                for (int k = i+1; k < p.Length; k++)
                {
                    allSegmente.Add(new Segment(p[i], p[k]));
                }
            }

            for (int i = 0; i < allSegmente.Count - 1; i++)
            {
                for (int j = i + 1; j < allSegmente.Count; j++)
                {
                    if(allSegmente[i].lenght > allSegmente[j].lenght)
                    {
                        Segment aux = allSegmente[j];
                        allSegmente[j] = allSegmente[i];
                        allSegmente[i] = aux;
                    }
                }
            }
            segmente.Add(new Segment(p[0],p[1]));
            for (int i = 0; i < allSegmente.Count; i++)
            {                   
                    bool valid = true;
                    for (int j = 0; j < segmente.Count; j++)
                    {
                        if (IntersectWith(allSegmente[i], segmente[j])) valid = false;
                    }
                    if (valid)
                        segmente.Add(allSegmente[i]);
                
            }
            for (int i = 0; i < segmente.Count; i++)
            {
                g.DrawLine(new Pen(Color.Blue), segmente[i].Start, segmente[i].End);
            }

            pictureBox1.Image = btm;
        }

        private bool IntersectWith(Segment seg, Segment segment)
        {
            if (Determinant(segment.Start, segment.End, seg.Start) * Determinant(segment.Start, segment.End, seg.End) <= 0)
                if (Determinant(seg.Start, seg.End, segment.Start) * Determinant(seg.Start, seg.End, segment.End) <= 0)
                    return true;
            return false;
        }
        float Determinant(PointF A, PointF B, PointF C)
        {
            return A.X * B.Y + B.X * C.Y + A.Y * C.X - B.Y * C.X - A.X * C.Y - A.Y * B.X;
        }
    }
}
