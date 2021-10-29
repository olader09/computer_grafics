using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Figures3D
{
    public partial class Form1 : Form
    {
        public List<Figure3D> figures = new List<Figure3D>();
        public int selectedFigure = -1;
        public void Next() => selectedFigure = selectedFigure == figures.Count - 1 ? 0 : (selectedFigure + 1);
        public Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics(); 
            var size = (800, 400); 
            Camera camera = new Camera();
            figures.Add(new F4());


            var fs = camera.GetFigures(figures);
            var res = new List<Figure2D>(); 
            foreach (var f in fs)
            {
                var newF = f; 
                // Scaling to real screen
                newF.Points = newF.Points.Select(p => new Point2D(p.X / camera.Width * size.Item1, p.Y / camera.Height * size.Item2)).ToList();
                res.Add(newF);
            }
            ShowFigures(res);
        }

        public Point From3D(Point2D p)
        {
            return new Point(
                (int)(p.X + (Canvas.Width / 2.0)), 
                (int)(Canvas.Height / 2.0 - p.Y)
                ); 
        }

        public void ShowF(Figure2D f)
        {
            foreach (var l in f.Lines)
            {
                g.DrawLine(new Pen(Color.Black), From3D(f.Points[l.Item1]), From3D(f.Points[l.Item2]));
            }
        }

        public void ShowFigures(List<Figure2D> list)
        {
            foreach (var f in list)
                ShowF(f); 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs ke)
        {
            switch (ke.KeyChar)
            {

            };
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }
    }
}
