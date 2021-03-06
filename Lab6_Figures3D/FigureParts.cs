using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureParts
{
    namespace Point
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

            public static Point3D operator *(Point3D p, double d)
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

    }

    namespace Edge
    {
        using Point; 

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
    }

    namespace Plane
    {
        using FigureParts.Point; 

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
    }
}
