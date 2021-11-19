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

    public class Figure3D
    {
        public List<Point3D> Points;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        // Contains planes as list of points 
        public List<List<int>> Planes;

        // Normal vectors for planes
        public List<Point3D> NormalVectors;

        public Point3D CameraVector;

        public List<Color> colors;

        public List<List<int>> VF = new(); 

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
            set { Center = value; }
        }

        public Figure3D() 
        {
            Points = new();
            Lines = new();
            Planes = new();
            NormalVectors = new();
            NormalVectors = new();
            AddingNormalVector();

        }

        public Figure3D(List<Point3D> points, List<(int, int)> lines)
        {
            Points = new(points);
            Lines = new(lines);
            NormalVectors = new();
            AddingNormalVector();
        }

        public Figure3D(List<Point3D> points, List<(int, int)> lines, List<List<int>> planes): this(points, lines)
        {
            Planes = new(planes); 
        }

        public Figure3D(Figure3D other) 
        {
            Points = new(other.Points);
            Lines = new(other.Lines);
            Planes = new(other.Planes);
            NormalVectors = new();
            VF = other.VF == null ? null : new(other.VF);
            colors = other.colors == null ? null : new(other.colors);
            AddingNormalVector();
        }

        public static (string, Figure3D) Download(string file)
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
            for (int i = 0; i < planesCount; ++i)
            {
                var line = text[lineCounter++].Split(' ');
                List<int> planePoints = new(); 
                foreach (var plPoint in line)
                {
                    planePoints.Add(int.Parse(plPoint)); 
                }
                f.Planes.Add(planePoints);
            }
            Random r = new Random();

            f.colors = f.Planes.Select(x => Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255))).ToList();
            return (name, f);
        }

        public static void Save(Figure3D figure, string name)
        {
            using (var sw = File.CreateText(name + ".txt"))
            {
                sw.WriteLine(name);
                sw.WriteLine(figure.Points.Count);
                foreach (var point in figure.Points)
                    sw.WriteLine(string.Join(' ', point.X, point.Y, point.Z));
                sw.WriteLine(figure.Lines.Count); 
                foreach (var line in figure.Lines)
                    sw.WriteLine(string.Join(' ', line.Item1, line.Item2));
                sw.WriteLine(figure.Planes.Count);
                foreach (var plane in figure.Planes)
                    sw.WriteLine(string.Join(' ', plane));
            }
        }

        public Point3D VectorProd((Point3D, Point3D) l1, (Point3D, Point3D) l2)
        {

            //double ax = l1.LX.B, ay = l1.LY.B, az = l1.LZ.B,
            //      bx = l2.LX.B, by = l2.LY.B, bz = l2.LZ.B;

            double ax = (l1.Item2.X - l1.Item1.X), ay = (l1.Item2.Y - l1.Item1.Y), az = (l1.Item2.Z - l1.Item1.Z),
                   bx = (l2.Item2.X - l2.Item1.X), by = (l2.Item2.Y - l2.Item1.Y), bz = (l2.Item2.Z - l2.Item1.Z);
            var res = new Point3D((ay * bz - az * by),
                                  -(ax * bz - az * bx),
                                  (ax * by - ay * bx));
            return res;
        }

        public void AddingNormalVector()
        {
            foreach (var plane in Planes)
            {
                NormalVectors.Add(VectorProd((Points[plane[0]], Points[plane[1]]),
                                             (Points[plane[0]], Points[plane[2]])));
            }
        }

        public double CosBetweenVectors(Point3D p1, Point3D p2)
        {
            double x1 = p1.X, y1 = p1.Y, z1 = p1.Z,
                   x2 = p2.X, y2 = p2.Y, z2 = p2.Z;
           // double lengthVec = (Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1) * Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2));
            double res;
            //if (lengthVec != 0)
            res = (x1 * x2 + y1 * y2 + z1 * z2) / (Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1) * Math.Sqrt(x2 * x2 + y2 * y2 + z2 * z2));
            // return Math.Cos(Math.PI - Math.Acos(res));
            return res;
        }
        public void RemovingNonFacePlanes()
        {
            List<List<int>> NotFasesPlanes = new List<List<int>>();
            List<List<int>> FasesPlanes = new List<List<int>>();

            for (int i = 0; i < NormalVectors.Count; i++)
            {
                if (CosBetweenVectors(CameraVector, NormalVectors[i]) > 0)
                {
                    // NotFasesPlanes.Add(Planes[i]);
                    FasesPlanes.Add(Planes[i]);
                }
                else
                {
                    NotFasesPlanes.Add(Planes[i]);
                }
            }
               
            if (Planes.Count - FasesPlanes.Count == 1) // для тетраэдра - вид сверху, рисуем всё
                return;
            /*else if (Planes.Count - FasesPlanes.Count == 2) // если две нелицевых грани - одно ребро не рисуем
            {
                var InvisibleLine = NotFasesPlanes[0].Intersect(NotFasesPlanes[1]).ToList();
                Lines.Remove((InvisibleLine[0], InvisibleLine[1]));
            }*/
            else if (Planes.Count - FasesPlanes.Count > 1)
            {
                List<(int, int)> smt =  new List<(int, int)>();
                foreach (var line in Lines)
                {
                    foreach (var plane in FasesPlanes)
                    {
                        if (plane.Contains(line.Item1) && plane.Contains(line.Item2))
                        {
                            smt.Add(line);
                            break;
                        }
                    }
                }
                Lines.Clear();
                Lines = smt;
                //foreach (var x in smt)
                  //  Lines.Add(x);
            }

            VF = new(FasesPlanes); 
        }
    }

    public class Figure2D
    {
        public List<Point2D> Points;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        // Contains planes as list of points 
        public List<List<int>> Planes;

        // Normal vectors for planes
        public List<Point2D> NormalVectors;

        // In world coordinates 
        public Point2D Center { get; set; }

        public Figure2D()
        {
            Points = new();
            Lines = new();
            Planes = new();
        }

        public Figure2D(List<Point2D> points, List<(int, int)> lines)
        {
            Points = new(points);
            Lines = new(lines);
        }

        public Figure2D(List<Point2D> points, List<(int, int)> lines, List<List<int>> planes) : this(points, lines)
        {
            Planes = new(planes);
        }
    }
}
