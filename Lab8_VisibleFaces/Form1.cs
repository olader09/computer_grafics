using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab6_Figures3D;

namespace Lab8_VisibleFaces
{
    public partial class Form1 : Form
    {
        public enum Action { NoAction, AddFigure, MoveCamera }

        SceneFigures figures = new();
        public (string, Figure3D) currentFigure;
        public Action action;
        Graphics g;
        Camera cam = new();
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics(); 
            //figures.AddFigure("Grid", new Grid());
            figures.AddFigure("Coord", new Coord());
            RedrawObjects(); 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'n':
                    currentFigure = figures.NextFigure(); 
                    break;

                case 'w':
                    if (action == Action.MoveCamera)
                        cam.MoveForward();
                    break;

                case 'a':
                    if (action == Action.NoAction)
                        action = Action.AddFigure;
                    else if (action == Action.MoveCamera)
                        cam.MoveLeft(); 
                    break;

                case 's':
                    if (action == Action.MoveCamera)
                        cam.MoveBackward();
                    break;

                case 't':
                    if (action == Action.AddFigure)
                    {
                        figures.AddFigure("Tetrahedron" + ++i, new F4());
                        action = Action.NoAction; 
                    }
                    break;

                case 'd':
                    if (action == Action.MoveCamera)
                        cam.MoveRight();
                    else if (action == Action.NoAction)
                        figures.DeleteFigure(); 
                    break;

                case 'm':
                    if (action == Action.NoAction)
                        action = Action.MoveCamera;
                    else if (action == Action.MoveCamera)
                        action = Action.NoAction;
                    break; 
            }
            RedrawObjects(); 
        }

        public void RedrawObjects(string selectedFigure = null)
        {
            g.Clear(DefaultBackColor);

            var fs = new List<(bool, Figure3D)>();
            foreach (var f in figures.GetFigures())
                fs.Add((f.Item1 == selectedFigure, cam.GetFigureInViewCoordinates(f.Item2)));

            var res = new List<(bool, Figure2D)>();
            foreach (var f in fs)
            {
                var newF = new Figure2D();
                newF.Lines = f.Item2.Lines;
                newF.Planes = f.Item2.Planes;
                newF.Points = new List<(bool, Point2D)>();
                foreach (var p in f.Item2.Points)
                {
                    var newP = cam.Project(p);
                    newF.Points.Add(newP);
                }
                // Scaling to real screen
                // newF.Points = newF.Points.Select(p => new Point2D(p.X / camera.Width * size.Item1, p.Y / camera.Height * size.Item2)).ToList();
                res.Add((f.Item1, newF));
            }
            ShowFigures(res);
        }

        public void ShowF(bool color, Figure2D f)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            Pen pen = new Pen(color ? Color.Red : Color.Black);
            foreach (var l in f.Lines)
            {
                var ch1 = f.Points[l.Item1];
                var ch2 = f.Points[l.Item2];
                if (!ch1.Item1 || !ch2.Item1)
                    continue;
                var p1 = From3D(ch1.Item2);
                var p2 = From3D(ch2.Item2);
                g.DrawLine(pen, p1, p2);
            }
        }

        public void ShowFigures(List<(bool, Figure2D)> list)
        {
            foreach (var f in list)
                ShowF(f.Item1, f.Item2);
        }

        public Point From3D(Point2D p)
        {
            return new Point(
                (int)(p.X + (Canvas.Width / 2.0)),
                (int)(Canvas.Height / 2.0 - p.Y)
                );
        }
    }
}
