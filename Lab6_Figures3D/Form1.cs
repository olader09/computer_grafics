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
        public int i = 1; 
        public Dictionary<string, Figure3D> figures = new();
        public Figure3D currentFigure;
        public string selectedFigure = null;
        // public void Next() => selectedFigure = selectedFigure == figures.Count - 1 ? 0 : (selectedFigure + 1);
        public Graphics g;
        Camera camera = new Camera();

        public Point3D transformPoint;
        public Line3D transformLine;
        public Flat3D transformFlat;
        public double transformAngle;
        public double transformCoef; 

        public Form1()
        {
            InitializeComponent();
            FiguresList.Items.AddRange(new object[] { "Tetrahedron", "Cube", "Octahedron", "Dodecahedron", "Icosahedron" });
            SceneFiguresList.SelectionMode = SelectionMode.One;
            g = Canvas.CreateGraphics();
            ScreenWidth.Value = 2;
            ScreenHeight.Value = 1;
            Focus.Value = 1; 
            ScreenWidth.DecimalPlaces = ScreenHeight.DecimalPlaces = Focus.DecimalPlaces = 1;
            ScreenWidth.Increment = ScreenHeight.Increment = Focus.Increment = 0.1m;
            camera.Resolution = (Canvas.Width, Canvas.Height); 
            //figures.Add(new F4());

            // var r = Projections.ParallelPoint(new Point3D(1, 2, -1), new Flat3D(3, -1, 2, -27));
            figures.Add("Coord", new Coord());
            figures.Add("Grid", new Grid());

            //RedrawObjects();
            /*var pp = new Point3D(1, 1, 1);
            var old = camera.GetIJCoordinates(pp);
            BackwardButton_Click(new object(), new EventArgs());
            var new_ = camera.GetIJCoordinates(pp); */
            /*var p1 = Projections.ParallelPoint(pp, new Flat3D(0, 0, 1, -2));
            var p2 = Projections.ParallelPoint(pp, new Flat3D(0, 0, 1, -2.25));*/
        }

        public void RedrawObjects(string selectedFigure = null)
        {
            g.Clear(DefaultBackColor);
            var fs = new List<(bool, Figure2D)>(); 
            foreach (var f in figures)
            {
                fs.Add((f.Key == selectedFigure, camera.GetFigure2D(f.Value)));
            }
            var res = new List<(bool, Figure2D)>();
            foreach (var f in fs)
            {
                var newF = new Figure2D();
                newF.Lines = f.Item2.Lines;
                newF.Planes = f.Item2.Planes;
                newF.Points = new List<Point2D>();
                foreach (var p in f.Item2.Points)
                {
                    var newP = camera.ToRealScreen(p);
                    newF.Points.Add(newP);
                }
                // Scaling to real screen
                // newF.Points = newF.Points.Select(p => new Point2D(p.X / camera.Width * size.Item1, p.Y / camera.Height * size.Item2)).ToList();
                res.Add((f.Item1, newF));
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

        public void ShowF(bool color, Figure2D f)
        {
            Pen pen = new Pen(color ? Color.Red : Color.Black);
            foreach (var l in f.Lines)
            {
                var p1 = From3D(f.Points[l.Item1]);
                var p2 = From3D(f.Points[l.Item2]); 
                g.DrawLine(pen, p1, p2);
            }
        }

        public void ShowFigures(List<(bool, Figure2D)> list)
        {
            foreach (var f in list)
                ShowF(f.Item1, f.Item2); 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs ke)
        {
            switch (ke.KeyChar)
            {
                case 'r':
                    RedrawObjects();
                    break; 
            };
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            var vector = camera.View - camera.Location;
            vector /= 4;
            camera.Shift(vector);
            RedrawObjects(selectedFigure); 
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            var vector = camera.Location - camera.View;
            vector /= 4;
            camera.Shift(vector);
            RedrawObjects(selectedFigure);
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            var vector = camera.J - camera.View;
            vector /= 4;
            camera.Shift(vector);
            RedrawObjects(selectedFigure);
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            var vector = camera.View - camera.J;
            vector /= 4;
            camera.Shift(vector);
            RedrawObjects(selectedFigure);
        }

        private void ProjectionButton_Click(object sender, EventArgs e)
        {
            switch (camera.Projection)
            {
                case ProjectionType.Parallel:
                    camera.Projection = ProjectionType.Central;
                    ProjectionButton.Text = "Projection type : Central";
                    break;

                case ProjectionType.Central:
                    camera.Projection = ProjectionType.Parallel;
                    ProjectionButton.Text = "Projection type : Parallel";
                    break;
            }

            RedrawObjects(selectedFigure);
        }

        private void ScreenWidth_ValueChanged(object sender, EventArgs e)
        {
            camera.Width = (double)ScreenWidth.Value;
            RedrawObjects(selectedFigure); 
        }

        private void ScreenHeight_ValueChanged(object sender, EventArgs e)
        {
            camera.Height = (double)ScreenHeight.Value;
            RedrawObjects(selectedFigure);
        }

        private void Focus_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PointGB_Enter(object sender, EventArgs e)
        {

        }

        private void AddFigureButton_Click(object sender, EventArgs e)
        {
            if ((string)FiguresList.SelectedItem == null)
                return; 

            Figure3D fig = new Figure3D();
            var name = (string)FiguresList.SelectedItem; 
            switch (name)
            {
                case "Tetrahedron":
                    fig = new F4();
                    break;
                /*case "Cube":
                    fig = new F6();
                    break;
                case "Octahedron":
                    fig = new F8();
                    break;
                case "Dodecahedron":
                    fig = new F12();
                    break;
                case "Icosahedron":
                    fig = new F20();
                    break;*/
            }
            string figName = (string)FiguresList.SelectedItem + i++;
            figures.Add(figName, fig);
            SceneFiguresList.Items.Add(figName);
            RedrawObjects(selectedFigure);
        }

        private void SceneFiguresList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFigure = (string)SceneFiguresList.SelectedItem;
            RedrawObjects(selectedFigure);
        }

        private void GetTransformPoint()
        {
            transformPoint = new Point3D((double)NumericPointX.Value, (double)NumericPointY.Value, (double)NumericPointZ.Value);
        }

        private void GetTransformLine()
        {

        }

        private void GetTransformFlat()
        {

        }

        private void GetTransformAngle()
        {

        }

        private void GetTransformCoef()
        {

        }

        private void ScaleButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == null)
                return; 

            GetTransformPoint();
            GetTransformCoef();
            Figure3D old = figures[selectedFigure];
            old.Points = new(old.Points.Select(p => Transform.Scale(p, transformPoint, transformCoef)));
        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == null)
                return;

            GetTransformPoint();
            Figure3D old = figures[selectedFigure];
            old.Points = new(old.Points.Select(p => Transform.Shift(p, transformPoint)));
        }

        private void ReflectButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == null)
                return;

            GetTransformFlat();
            Figure3D old = figures[selectedFigure];
            old.Points = new(old.Points.Select(p => Transform.Reflect(transformFlat, p)));
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == null)
                return;

            GetTransformLine();
            GetTransformAngle(); 
            Figure3D old = figures[selectedFigure];
            old.Points = new(old.Points.Select(p => Transform.RotateAroundLine(transformLine, p, transformAngle)));

        }
    }
}
