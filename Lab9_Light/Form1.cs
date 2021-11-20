using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Rendering.RenderingPipeline;
using Cam;
using Figure;

namespace Lab9_Light
{
    public enum Act { CameraMove, ObjectMove, NoAction }

    public partial class Form1 : Form
    {
        public int iname = 1;
        public Camera camera;
        public Dictionary<string, Figure3D> figures;
        public string selectedFigure;
        public Graphics graphics;
        public Action RENDER;
        public Act action;

        public Form1()
        {
            InitializeComponent();
            camera = new Camera();
            figures = new Dictionary<string, Figure3D>();
            figures.Add("Coord", new Coord());
            figures.Add("Grid", new Grid());
            graphics = Canvas.CreateGraphics();
            // RENDER = FullCarcassPipeline;
            RENDER = FaceCarcassPipeline;
            action = Act.NoAction;
        }

        public void FullCarcassPipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            f = GetProjectedFigures(f);
            DrawFullCarcass(f, graphics, Canvas.Width, Canvas.Height);
        }

        public void FaceCarcassPipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            //f.ForEach(x => { x.SetNormalVectors(); x.MarkPlanesAsFaceOrNonFace(); });
            CutNonFacePlanes(f);
            f = GetProjectedFigures(f);
            DrawFaceCarcass(f, graphics, Canvas.Width, Canvas.Height);
        }

        private void AddFigureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files(*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var figure = Figure3D.DownloadTXT(open.FileName);
                var name = figure.Item1;
                if (figures.ContainsKey(name))
                    name += iname++;
                figures.Add(name, figure.Item2);
                SceneFigures.Items.Add(figure.Item1);
                RENDER();
            }
        }

        private void HandleKey(object sender, KeyPressEventArgs e)
        {
            if (action == Act.NoAction)
            {
                switch (e.KeyChar)
                {
                    case 'c':
                        action = Act.CameraMove;
                        ActionLabel.Text = "Action: Camera movement";
                        break;
                    case 'o':
                        action = Act.ObjectMove;
                        ActionLabel.Text = "Action: Object movement";
                        break;
                }
            }
            else if (action == Act.CameraMove)
            {
                switch (e.KeyChar)
                {
                    // MOVE

                    case 's':
                        camera.MoveBack();
                        break;
                    case 'w':
                        camera.MoveForward();
                        break;
                    case 'a':
                        camera.MoveLeft();
                        break;
                    case 'd':
                        camera.MoveRight();
                        break;
                    case 'q':
                        camera.MoveUp();
                        break;
                    case 'e':
                        camera.MoveDown();
                        break;


                    // TURN

                    case 'i':
                        camera.TurnDown();
                        break;
                    case 'k':
                        camera.TurnUp();
                        break;
                    case 'j':
                        camera.TurnLeft();
                        break;
                    case 'l':
                        camera.TurnRight();
                        break;
                    case 'o':
                        camera.TurnClockwise();
                        break;
                    case 'u':
                        camera.TurnClockfool();
                        break;

                    case 'x':
                        action = Act.NoAction;
                        ActionLabel.Text = "Action: No Action";
                        break;
                }

                RENDER();
            }
            else if (action == Act.ObjectMove)
            {
                var x = new FigureParts.Point.Point3D(0.1, 0, 0);
                var y = new FigureParts.Point.Point3D(0, 0.1, 0);
                var z = new FigureParts.Point.Point3D(0, 0, 0.1);
                var o = new FigureParts.Point.Point3D(0, 0, 0);

                var tx = new FigureParts.Edge.Edge3D(o, x);
                var ty = new FigureParts.Edge.Edge3D(o, y);
                var tz = new FigureParts.Edge.Edge3D(o, z);

                switch (e.KeyChar)
                {
                    // MOVE

                    case 's':
                        figures[selectedFigure].Shift(x);
                        break;
                    case 'w':
                        figures[selectedFigure].Shift(-x);
                        break;
                    case 'a':
                        figures[selectedFigure].Shift(y);
                        break;
                    case 'd':
                        figures[selectedFigure].Shift(-y);
                        break;
                    case 'q':
                        figures[selectedFigure].Shift(z);
                        break;
                    case 'e':
                        figures[selectedFigure].Shift(-z);
                        break;


                    // TURN

                    case 'i':
                        figures[selectedFigure].Rotate(tx, 5);
                        break;
                    case 'k':
                        figures[selectedFigure].Rotate(tx, -5);
                        break;
                    case 'j':
                        figures[selectedFigure].Rotate(ty, 5);
                        break;
                    case 'l':
                        figures[selectedFigure].Rotate(ty, -5);
                        break;
                    case 'o':
                        figures[selectedFigure].Rotate(tz, 5);
                        break;
                    case 'u':
                        figures[selectedFigure].Rotate(tz, -5);
                        break;

                    case 'x':
                        action = Act.NoAction;
                        ActionLabel.Text = "Action: No Action";
                        break;
                }

                RENDER();
            }

            e.Handled = true;
        }

        private void SceneFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFigure = (string)SceneFigures.SelectedItem;
            if (selectedFigure == null)
                return;
            figures[selectedFigure].LinesColor = Color.Red;
            foreach (var f in figures.Where(x => x.Key != selectedFigure).Select(x => x.Value))
                f.LinesColor = Color.Black;
            RENDER();
        }
    }

    public class Set<T> where T : IComparable<T>
    {
        private T[] Elements;

        public bool AddElem(T elem)
        {
            bool b = false;
            foreach (var e in Elements)
                if (e.Equals(elem))
                    b = true;
            if (!b)
                Elements.Append(elem);
            return b;
        }

        public bool RemoveElem(T elem)
        {
            bool b = false;
            int found = 0;
            foreach (var e in Elements)
                if (e.Equals(elem))
                    b = true;
                else ++found;
            if (b)
                Elements[found] = default(T);
            return b;
        }

        public Set()
        {
            Elements = new T[0];
        }
    }
}
