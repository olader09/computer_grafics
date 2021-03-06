using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace Lab6_Figures3D
{
    #region Point

    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Point3D other)
        {
            X = other.X;
            Y = other.Y;
            Z = other.Z;
        }

        public static Point3D operator +(Point3D one, Point3D other)
        {
            return new Point3D(one.X + other.X, one.Y + other.Y, one.Z + other.Z);
        }

        public static Point3D operator -(Point3D one, Point3D other)
        {
            return new Point3D(one.X - other.X, one.Y - other.Y, one.Z - other.Z);
        }

        public static Point3D operator * (Point3D p, double d)
        {
            return new Point3D(p.X * d, p.Y * d, p.Z * d); 
        }

        public static Point3D operator /(Point3D p, double d)
        {
            return new Point3D(p.X / d, p.Y / d, p.Z / d);
        }

        public static Point3D operator -(Point3D p)
        {
            return new Point3D(-p.X, -p.Y, -p.Z);
        }

        public override string ToString()
        {
            return $"{X:00.00} {Y:00.00} {Z:00.00}";
        }
    }

    public struct Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Point2D operator +(Point2D one, Point2D other)
        {
            return new Point2D(one.X + other.X, one.Y + other.Y);
        }
    }

    #endregion

    #region Edge

    // Edge3D of Figure3D
    public class Edge3D
    {
        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }

        public Edge3D(Point3D p1, Point3D p2)
        {
            P1 = new Point3D(p1.X, p1.Y, p1.Z);
            P2 = new Point3D(p2.X, p2.Y, p2.Z);
        }
    }

    public class Edge2D
    {
        public Point2D P1 { get; set; }
        public Point2D P2 { get; set; }

        public Edge2D(Point2D p1, Point2D p2)
        {
            P1 = new Point2D(p1.X, p1.Y);
            P2 = new Point2D(p2.X, p2.Y);
        }
    }

    #endregion

    #region Figure

    public class Figure3D
    {
        public List<Point3D> Points;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        // Contains planes as list of points 
        public List<List<int>> Planes;

        // Normal vectors for planes
        public List<Point3D> NormalVectors; 

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
            AddingNormalVector();
        }

        public Figure3D(Figure3D other)
        {
            Points = new(other.Points);
            Lines = new(other.Lines);
            Planes = new(other.Planes);
            NormalVectors = new(other.NormalVectors);
            AddingNormalVector();
        }

        public Figure3D(List<Point3D> points, List<(int, int)> lines)
        {
            Points = new(points);
            Lines = new(lines); 
        }

        public Figure3D(List<Point3D> points, List<(int, int)> lines, List<List<int>> planes): this(points, lines)
        {
            Planes = new(planes); 
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
        public Point3D VectorProd((Point3D,Point3D) l1, (Point3D, Point3D) l2)
        {

            //double ax = l1.LX.B, ay = l1.LY.B, az = l1.LZ.B,
            //      bx = l2.LX.B, by = l2.LY.B, bz = l2.LZ.B;

            double ax = (l1.Item2.X - l1.Item1.X), ay = (l1.Item2.Y - l1.Item1.Y), az = (l1.Item2.Z - l1.Item1.Z),
                   bx = (l2.Item2.X - l2.Item1.X), by = (l2.Item2.Y - l2.Item1.Y), bz = (l2.Item2.Z - l2.Item1.Z);
            return new Point3D(ay * bz - az * by,
                               -(ax * bz - az * bx),
                               ax * by - ay * bx);
        }

        public void AddingNormalVector()
        {
            foreach (var plane in Planes)
            {
                NormalVectors.Add(VectorProd((Points[plane[0]], Points[plane[1]]),
                                             (Points[plane[1]], Points[plane[2]])));
            }
        }
    }

    public class Figure2D
    {
        public List<(bool, Point2D)> Points;

        // Indexes in list of Points
        public List<(int, int)> Lines;

        // Contains planes as list of points 
        public List<List<int>> Planes;

        // In world coordinates 
        public Point2D Center { get; set; }

        public Figure2D()
        {
            Points = new();
            Lines = new();
            Planes = new();
        }

        public Figure2D(List<(bool, Point2D)> points, List<(int, int)> lines)
        {
            Points = new(points);
            Lines = new(lines);
        }

        public Figure2D(List<(bool, Point2D)> points, List<(int, int)> lines, List<List<int>> planes) : this(points, lines)
        {
            Planes = new(planes);
        }
    }

    #endregion

    #region Line

    public class Line2D
    {
        public double K, B; 

        public Line2D(double k, double b) { K = k; B = b; }
    }

    // Line in 3D
    public class Line3D
    {
        public Line2D LX, LY, LZ;  
        public Line3D(Line2D lx, Line2D ly, Line2D lz)
        {
            LX = lx;
            LY = ly;
            LZ = lz; 
        }
    }

    #endregion

    #region Flat

    // Surface like line but in 3D
    public class Flat3D
    {
        public double X, Y, Z, A; 

        public Flat3D(double x, double y, double z, double a)
        {
            X = x;
            Y = y;
            Z = z;
            A = a; 
        }
    }

    #endregion
}
