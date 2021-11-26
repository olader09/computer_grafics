using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing;

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

            public Point2D ToPoint2D()
            {
                return new Point2D(X, Y);
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

            public static implicit operator System.Drawing.Point(Point2D pointD)
            {
                return new System.Drawing.Point((int)Math.Round(pointD.X), (int)Math.Round(pointD.Y));
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

        public enum PlaneFillType { Texture, Color, Null }

        public class Texture
        {
            public Color[,] Value; 
        }

        // Side of a Figure3D
        public class Plane3D
        {
            public List<int> PointIndices { get; set; }
            public List<Color> VertexColors { get; set; }
            public List<(int, int)> TextureCoordinates { get; set; }
            public Point3D NormalVector { get; set; }
            public bool Visible { get; set; }
            public PlaneFillType PlaneFill { get; set; }
            public Image Texture { get; set; }

            public List<Plane3D> Triangulate()
            {
                if (PointIndices.Count == 3)
                    return new List<Plane3D>() { this };
                List<Plane3D> res = new List<Plane3D>();
                for (int i = 2; i < PointIndices.Count; ++i)
                {
                    var toAdd = new Plane3D();
                    toAdd.PointIndices = new List<int>() { PointIndices[0], PointIndices[i - 1], PointIndices[i] };
                    if (PlaneFill == PlaneFillType.Color)
                        toAdd.VertexColors = new List<Color>() { VertexColors[0], VertexColors[i - 1], VertexColors[i] };
                    else if (PlaneFill == PlaneFillType.Texture)
                        toAdd.TextureCoordinates = TextureCoordinates == null ? null : new List<(int, int)>() { TextureCoordinates[0], TextureCoordinates[i - 1], TextureCoordinates[i] };
                    toAdd.NormalVector = NormalVector;
                    toAdd.Visible = Visible;
                    toAdd.Texture = Texture;
                    res.Add(toAdd);
                }
                return res;
            }
        }

        public class Plane2D
        {
            public List<int> PointIndices { get; set; }
            public List<Color> VertexColors { get; set; }
            public List<(double, double)> TextureCoordinates { get; set; }
            public PlaneFillType PlaneFill { get; set; }
        }
    }
}
