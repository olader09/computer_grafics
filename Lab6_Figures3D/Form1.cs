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
        Camera camera = new Camera();
        public (int, int) size = (800, 400);

        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics();
            figures.Add(new F4());

            // var r = Projections.ParallelPoint(new Point3D(1, 2, -1), new Flat3D(3, -1, 2, -27));
            figures.Add(new Coord());
            figures.Add(new Grid());

            RedrawObjects();
        }

        public void RedrawObjects()
        {
            g.Clear(DefaultBackColor);
            var fs = camera.GetFigures(figures);
            var res = new List<Figure2D>();
            foreach (var f in fs)
            {
                var newF = new Figure2D();
                newF.Lines = f.Lines;
                newF.Planes = f.Planes;
                newF.Points = new List<Point2D>();
                foreach (var p in f.Points)
                {
                    var newP = new Point2D(p.X * size.Item1, p.Y * size.Item2);
                    newF.Points.Add(newP);
                }
                // Scaling to real screen
                // newF.Points = newF.Points.Select(p => new Point2D(p.X / camera.Width * size.Item1, p.Y / camera.Height * size.Item2)).ToList();
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
                var p1 = From3D(f.Points[l.Item1]);
                var p2 = From3D(f.Points[l.Item2]); 
                g.DrawLine(new Pen(Color.Black), p1, p2);
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
                case 'R':
                    RedrawObjects();
                    break; 
            };
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
        }

        private void CameraMove(Point3D vector)
        {
            camera.Location += vector;
            camera.View += vector;
            camera.I += vector;
            camera.J += vector;
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            var vector = camera.View - camera.Location;
            vector /= 4;
            CameraMove(vector);
            RedrawObjects(); 
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            var vector = camera.Location - camera.View;
            vector /= 4;
            CameraMove(vector);
            RedrawObjects();
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            var vector = camera.J - camera.View;
            vector /= 4;
            CameraMove(vector);
            RedrawObjects();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            var vector = camera.I - camera.View;
            vector /= 4;
            CameraMove(vector);
            RedrawObjects();
        }

        private void ProjectionButton_Click(object sender, EventArgs e)
        {
            switch (camera.Projection)
            {
                case ProjectionType.Parallel:
                    camera.Projection = ProjectionType.Central;
                    ProjectionButton.Text = "Projection type : Central";
                    RedrawObjects();
                    break;

                case ProjectionType.Central:
                    camera.Projection = ProjectionType.Parallel;
                    ProjectionButton.Text = "Projection type : Parallel";
                    RedrawObjects();
                    break;
            }
        }
    }
}
