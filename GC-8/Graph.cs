using System.Drawing;
using System.Windows.Forms;

namespace TriangulareaUnuiPoligon
{
    public static class Graph
    {
        public static Bitmap bmp;
        public static Graphics gfx;
        public static PictureBox display;
        public static int resx, resy;
        public static Color backColor = Color.White;
        public static void initGraph(PictureBox Display)
        {
            display = Display;
            bmp = new Bitmap(display.Width, display.Height);
            gfx = Graphics.FromImage(bmp);
            resx = display.Width;
            resy = display.Height;
            clearGraph();
            refreshGraph();
        }
        public static void clearGraph()
        {
            gfx.Clear(backColor);
        }
        public static void refreshGraph()
        {
            display.Image = bmp;
        }
    }
}