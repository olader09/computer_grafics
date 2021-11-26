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
using GeometricFunctions;

namespace Room
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
        public Func<Figure3D, Figure3D> projector;
        public int picSize = 200;
        public double[,] ZBuffer;
        public Color[,] CBuffer;
        public Bitmap bmp;
        public int ind; 

        private List<FloatingHorizon.functionType> functions;

        private double F1(double x, double y) => 1 / (1 + x * x) + 1 / (1 + y * y);
        private double SinCos(double x, double y) => Math.Sin(x) * Math.Cos(y);
        private double F3(double x, double y) => (x * x + 3 * y * y) * Math.Exp(-(x * x + y * y));
        private double F4(double x, double y) => Math.Exp(-(x * x + y * y) / 8) * Math.Sin(x * x) + Math.Cos(y * y);
        private double F5(double x, double y) => x * y * y * Math.Exp(-(x*x + y*y)/3);

        public Form1()
        {
            InitializeComponent();
            camera = new Camera();
            figures = new Dictionary<string, Figure3D>();
            figures.Add("Coord", new Coord());
            figures.Add("Grid", new Grid());
            figures.Add("Light", new LightBulb(new FigureParts.Point.Point3D(2, 2, 2)));
            SceneFigures.Items.Add((string)"Light");
            graphics = Canvas.CreateGraphics();
            // RENDER = FullCarcassPipeline;
            RENDER = FaceCarcassPipeline;
            action = Act.NoAction;
            projector = Projections.ProjectP1;
            ZBuffer = new double[Canvas.Width, Canvas.Height];
            CBuffer = new Color[Canvas.Width, Canvas.Height];
            functions = new List<FloatingHorizon.functionType>() { F1, SinCos, F3, F4, F5 };
            listBox1.Items.AddRange(new object[] { "F1", "SinCos", "F3", "F4", "F5" });
        }

        public void FullCarcassPipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            f = GetProjectedFigures(f, projector);
            DrawFullCarcass(f, graphics, Canvas.Width, Canvas.Height, picSize);
        }

        public void FaceCarcassPipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            //f.ForEach(x => { x.SetNormalVectors(); x.MarkPlanesAsFaceOrNonFace(); });
            CutNonFacePlanes(f);
            //TextBox.Text = string.Join("\n", f[2].Planes.Select(x => x.NormalVector.ToString())); 
            f = GetProjectedFigures(f, projector);
            DrawFaceCarcass(f, graphics, Canvas.Width, Canvas.Height, picSize);
        }

        public void ZBufferPipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            CutNonFacePlanes(f);
            RestoreBuffers();
            f = GetProjectedFigures(f, projector);
            DrawZBuffer(f, ZBuffer, CBuffer, Canvas.Width, Canvas.Height, picSize);

            var b = new Bitmap(Canvas.Width, Canvas.Height);

            using (var fb = new GraphFunc.FastBitmap(b))
            {
                for (int i = 0; i < Canvas.Width; ++i)
                    for (int j = 0; j < Canvas.Height; ++j)
                        fb.SetPixel(new Point(i, j), CBuffer[i, j]);
            }

            Canvas.Image = b;
        }

        public void ShadePipeline()
        {
            graphics.Clear(DefaultBackColor);
            var f = GetFiguresInViewCoordinates(figures.Values.ToList(), camera.GetView());
            CutNonFacePlanes(f);
            RestoreBuffers();
            f = GetProjectedFigures(f, projector);
            DrawShade(f, ZBuffer, CBuffer, Canvas.Width, Canvas.Height, picSize);

            var b = new Bitmap(Canvas.Width, Canvas.Height);
            // {
            using (var fb = new GraphFunc.FastBitmap(b))
            {
                for (int i = 0; i < Canvas.Width; ++i)
                    for (int j = 0; j < Canvas.Height; ++j)
                        fb.SetPixel(new Point(i, j), CBuffer[i, j]);
                Canvas.Image = b;
            }
            Canvas.Refresh();


            Figure3D bulb = new Figure3D(figures["Light"]);
            bulb.Points = bulb.Points.Select(p => Matrix.To3DPoint(Matrix.Point(p) * camera.GetView())).ToList();
            bulb = projector(bulb);
            var point = Methods.PointOnRealScreen(bulb.Center, Canvas.Width, Canvas.Height, picSize);
            var z = bulb.Center.Z;
            if (z < 0) return;
            var radius = 50 / (1 + (float)z);
            graphics.DrawEllipse(new Pen(Color.Red, 1.5f), point.X - radius / 2, point.Y - radius / 2, radius, radius);
        }

        public void HorizonPipeline()
        {
            graphics.Clear(DefaultBackColor);
            FloatingHorizon.HorizonDrawer hd = new FloatingHorizon.HorizonDrawer(Canvas.Width, Canvas.Height);
            hd.InitializeHorizonDrawer();
            hd.Draw(graphics, functions[ind]);
        }

        public void RestoreBuffers()
        {
            for (int i = 0; i < Canvas.Width; ++i)
                for (int j = 0; j < Canvas.Height; ++j)
                {
                    ZBuffer[i, j] = double.MaxValue;
                    CBuffer[i, j] = DefaultBackColor;
                }
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
                if (selectedFigure == null)
                    return;

                var x = new FigureParts.Point.Point3D(0.2, 0, 0);
                var y = new FigureParts.Point.Point3D(0, 0.2, 0);
                var z = new FigureParts.Point.Point3D(0, 0, 0.2);
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

                    // SCALE
                    case 'm':
                        figures[selectedFigure].Scale(figures[selectedFigure].Center, 1.1);
                        break;

                    case 'n':
                        figures[selectedFigure].Scale(figures[selectedFigure].Center, 0.9);
                        break;

                    case 't':
                        figures[selectedFigure].Planes.ForEach(p =>
                        {
                            if (p.PlaneFill == FigureParts.Plane.PlaneFillType.Color)
                                p.PlaneFill = FigureParts.Plane.PlaneFillType.Texture;
                        });
                        break;

                    case 'c':
                        figures[selectedFigure].Planes.ForEach(p => p.PlaneFill = FigureParts.Plane.PlaneFillType.Color);
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

        private void radioButtonParallel_CheckedChanged(object sender, EventArgs e)
        {
            projector = Projections.ProjectParallel;
            RENDER();
        }

        private void radioButtonCentralP1_CheckedChanged(object sender, EventArgs e)
        {
            projector = Projections.ProjectP1;
            RENDER();
        }

        private void CamSize_ValueChanged(object sender, EventArgs e)
        {
            picSize = (int)CamSize.Value;
            RENDER();
        }

        private void CarcassRB_CheckedChanged(object sender, EventArgs e)
        {
            RENDER = FullCarcassPipeline;
            RENDER();
        }

        private void FaceCarcassRB_CheckedChanged(object sender, EventArgs e)
        {
            RENDER = FaceCarcassPipeline;
            RENDER();
        }

        private void ZBufferRB_CheckedChanged(object sender, EventArgs e)
        {
            RENDER = ZBufferPipeline;
            RENDER();
        }

        private void ShadeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RENDER = ShadePipeline;
            RENDER();
        }

        private void HorizonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RENDER = HorizonPipeline;
            RENDER();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ind = listBox1.SelectedIndex;
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
