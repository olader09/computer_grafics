using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Figure
{
    using FigureParts.Point;
    using FigureParts.Plane;
    using GeometricFunctions;
    using GeometricPrimitives.CanonicFlat;
    using FigureParts.Edge;

    public class Figure3D
    {
        public string Tag;

        public Color LinesColor;

        public List<Point3D> Points;

        public List<Point3D> NormalPoints;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        public List<bool> LinesVisibility;

        // Contains planes as list of points 
        public List<Plane3D> Planes;

        // In world coordinates 
        public Point3D Center
        {
            get
            {
                var p = new Point3D(0, 0, 0);
                foreach (var point in Points)
                {
                    p.X += point.X; p.Y += point.Y; p.Z += point.Z;
                }
                return p / Points.Count;
            }
        }

        public Figure3D()
        {
            Points = new List<Point3D>();
            Lines = new List<(int, int)>();
            Planes = new List<Plane3D>();
            LinesVisibility = new List<bool>();
            LinesColor = Color.Black;
            NormalPoints = new List<Point3D>();
            Tag = null;
        }

        public Figure3D(Figure3D other)
        {
            Points = new List<Point3D>(other.Points);
            Lines = new List<(int, int)>(other.Lines);
            Planes = new List<Plane3D>(other.Planes);
            LinesVisibility = new List<bool>(other.LinesVisibility);
            LinesColor = other.LinesColor;
            NormalPoints = new List<Point3D>(other.NormalPoints);
            Tag = other.Tag;
        }

        public static (string, Figure3D) DownloadTXT(string file)
        {
            Figure3D f = new Figure3D();
            var text = File.ReadAllLines(file);
            int lineCounter = 0;
            string name = text[lineCounter++];
            int pointsCount = int.Parse(text[lineCounter++]);
            for (int i = 0; i < pointsCount; ++i)
            {
                var pCoords = text[lineCounter++].Split(' ');
                f.Points.Add(new Point3D(double.Parse(pCoords[0]), double.Parse(pCoords[1]), double.Parse(pCoords[2])));
            }
            int linesCount = int.Parse(text[lineCounter++]);
            for (int i = 0; i < linesCount; ++i)
            {
                var line = text[lineCounter++].Split(' ');
                f.Lines.Add((int.Parse(line[0]), int.Parse(line[1])));
            }
            int planesCount = int.Parse(text[lineCounter++]);
            Random r = new Random();
            for (int i = 0; i < planesCount; ++i)
            {
                var line = text[lineCounter++].Split(' ');
                List<int> planePoints = new List<int>();
                foreach (var plPoint in line)
                {
                    planePoints.Add(int.Parse(plPoint));
                }
                var p = new Plane3D();
                p.PointIndices = planePoints;
                p.VertexColors = new List<Color>();
                foreach (var _ in p.PointIndices)
                {
                    var R = 255; // r.Next(0, 255);
                    var G = 0; // r.Next(0, 255);
                    var B = 0; // r.Next(0, 255);
                    p.VertexColors.Add(Color.FromArgb(R, G, B));
                }
                p.PlaneFill = PlaneFillType.Color;
                p.Texture = Figure3D.Textures["puchkin"];
                p.TextureCoordinates = new List<(int, int)>() { (10, 200), (10, 10), (200, 10), (200, 200) };
                f.Planes.Add(p);
            }
            f.LinesVisibility = new List<bool>();
            f.LinesColor = Color.Black;
            f.NormalPoints = new List<Point3D>(f.Points);
            f.Tag = "Figure";
            foreach (var _ in f.Lines)
                f.LinesVisibility.Add(false);
            return (name, f);
        }

        public static void SaveTXT(Figure3D figure, string name)
        {
            using (var sw = File.CreateText(name + ".txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(figure.Points.Count);
                foreach (var point in figure.Points)
                    sw.WriteLine(string.Join(" ", point.X, point.Y, point.Z));
                sw.WriteLine(figure.Lines.Count);
                foreach (var line in figure.Lines)
                    sw.WriteLine(string.Join(" ", line.Item1, line.Item2));
                sw.WriteLine(figure.Planes.Count);
                foreach (var plane in figure.Planes)
                    sw.WriteLine(string.Join(" ", plane));
            }
        }

        public void Shift(Point3D vector)
        {
            Points = Points.Select(p => Transform.Shift(p, vector)).ToList();
        }

        public void Scale(Point3D from, double coef)
        {
            Points = Points.Select(p => Transform.Scale(p, from, coef)).ToList();
        }

        public void Rotate(Edge3D edge, double angle)
        {
            Points = Points.Select(p => Transform.RotateAroundLine(edge, p, angle)).ToList();
        }

        public void SetNormalVectors()
        {
            foreach (var plane in Planes)
                plane.NormalVector =
                    Methods.CrossProduct(
                        Points[plane.PointIndices[1]] - Points[plane.PointIndices[0]],
                        Points[plane.PointIndices[plane.PointIndices.Count - 1]] - Points[plane.PointIndices[0]]);

            for (int i = 0; i < Points.Count; ++i)
            {
                var norm = new Point3D(0, 0, 0);
                int count = 0;
                foreach (var plane in Planes)
                    foreach (var ind in plane.PointIndices)
                        if (ind == i)
                        {
                            norm += plane.NormalVector;
                            ++count;
                        }
                NormalPoints[i] = norm / count;
            }
        }

        public void MarkPlanesAsFaceOrNonFace()
        {
            foreach (var plane in Planes)
                plane.Visible = plane.NormalVector.Z < 0;

            foreach (var plane in Planes.Where(x => x.Visible))
            {
                for (int y = 0; y < plane.PointIndices.Count - 1; ++y)
                {
                    var pair1 = (plane.PointIndices[y], plane.PointIndices[y + 1]);
                    var f1 = Lines.FindIndex(x => x == pair1 || x == (pair1.Item2, pair1.Item1));
                    if (f1 != -1)
                        LinesVisibility[f1] = true;
                }

                var pair = (plane.PointIndices[plane.PointIndices.Count - 1], plane.PointIndices[0]);
                var f = Lines.FindIndex(x => x == pair || x == (pair.Item2, pair.Item1));
                if (f != -1)
                    LinesVisibility[f] = true;
            }
        }

        public static Dictionary<string, Image> Textures = new Dictionary<string, Image>()
        {
           // ["obama"] = Bitmap.FromFile("obm.png"),
            // ["putin"] = Bitmap.FromFile("ptn.png"),
            ["puchkin"] = Bitmap.FromFile("pck.png"),
        };
    }

    public class Figure2D
    {
        public List<Point2D> Points;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        // Contains planes as list of points 
        public List<Plane2D> Planes;

        // Normal vectors for planes
        public List<Point2D> NormalVectors;

        // In world coordinates 
        public Point2D Center { get; set; }

        public Figure2D()
        {
            Points = new List<Point2D>();
            Lines = new List<(int, int)>();
            Planes = new List<Plane2D>();
        }

        public Figure2D(Figure2D other)
        {
            Points = new List<Point2D>(other.Points);
            Lines = new List<(int, int)>(other.Lines);
            Planes = new List<Plane2D>(other.Planes);
        }
    }

    public class Coord : Figure3D
    {
        public Coord()
        {
            var O = new Point3D(0, 0, 0);
            var X = new Point3D(10, 0, 0);
            var Y = new Point3D(0, 10, 0);
            var Z = new Point3D(0, 0, 10);
            Points.AddRange(new List<Point3D>() { O, X, Y, Z });
            Lines = new List<(int, int)>()
            {
                (0, 1),
                (0, 2),
                (0, 3),
            };
            Tag = "Coord";
        }
    }

    public class Grid : Figure3D
    {
        public Grid()
        {
            var i = 0;
            for (int x = -7; x < 8; ++x)
            {
                var p1 = new Point3D(x, -7, 0);
                var p2 = new Point3D(x, 7, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }

            for (int y = -7; y < 8; ++y)
            {
                var p1 = new Point3D(-7, y, 0);
                var p2 = new Point3D(7, y, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }

            Tag = "Grid";
        }
    }

    public class LightBulb : Figure3D
    {
        public LightBulb(Point3D location)
        {
            Points.Add(location);
            Tag = "Bulb";
        }
    }
}
