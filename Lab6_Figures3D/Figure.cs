using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
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

    // Side of a Figure3D
    public class Plane3D
    {
        public List<Point3D> Value { get; set; }

        public Plane3D(List<Point3D> list)
        {
            Value = new List<Point3D>(list);
        }
    }

    public class Plane2D
    {
        public List<Point2D> Value { get; set; }

        public Plane2D(List<Point2D> list)
        {
            Value = new List<Point2D>(list);
        }
    }

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

    public class Figure3D
    {
        public List<Point3D> Points;
        public List<Edge3D> Lines;
        public List<Plane3D> Planes;

        // In world coordinates 
        public Point3D Center { get; set; }

        public Figure3D() { }

        public Figure3D(List<Edge3D> lines)
        {
            Lines = new List<Edge3D>(lines);
        }
    }

    public class Line2D
    {
        public double K, B; 

        public Line2D(double k, double b) { K = k; B = b; }
    }

    // Line in 3D
    public class Line3D
    {
        // public double 
    }

    // Surface like line but in 3D
    public class Flat3D
    {
        public double X, Y, Z, A; 
    }

    // Flat with coordinates
    public class CFlat3D: Flat3D
    {
        public Edge3D I, J; 
    }
}
