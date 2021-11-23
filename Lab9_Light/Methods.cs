using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using FigureParts.Point;
using FigureParts.Edge;
using GeometricPrimitives.ParametricLine;
using GeometricPrimitives.CanonicFlat;
using System.Drawing;

namespace GeometricFunctions
{
    public static class Methods
    {
        public static double DeltaX3D(Point3D p1, Point3D p2) => Abs(p1.X - p2.X);
        public static double DeltaY3D(Point3D p1, Point3D p2) => Abs(p1.Y - p2.Y);
        public static double DeltaZ3D(Point3D p1, Point3D p2) => Abs(p1.Z - p2.Z);

        public static double Point3DDistance(Point3D p1, Point3D p2)
        {
            return Sqrt(Pow(DeltaX3D(p1, p2), 2) + Pow(DeltaY3D(p1, p2), 2) + Pow(DeltaZ3D(p1, p2), 2));
        }

        public static Line3D LineByPointAndVector(Point3D point, Point3D vector)
        {
            var p = new double[3] { point.X, point.Y, point.Z };
            var v = new double[3] { vector.X, vector.Y, vector.Z }; 
            return new Line3D(new Line2D(v[0], p[0]), new Line2D(v[1], p[1]), new Line2D(v[2], p[2]));
        }

        // Generates flat through point that is normal to a given line
        public static Flat3D NormalFlat(Line3D line, Point3D point)
        {
            var vec = new Point3D(line.LX.K, line.LY.K, line.LZ.K);
            return FlatByPointAndVector(point, vec);
        }

        // We assume that point lays on vector line
        public static double GetDistanceInUnits(Edge3D edge, Point3D point)
        {
            var vecStart = edge.P1;
            var vecEnd = edge.P2;

            var vec = vecEnd - vecStart;
            var new_p = point - vecStart;

            if (vec.X > double.Epsilon)
                return new_p.X / vec.X;
            else if (vec.Y > double.Epsilon)
                return new_p.Y / vec.Y;
            else if (vec.Z > double.Epsilon)
                return new_p.Z / vec.Z;
            else return 0; 
        }
 

        public static Flat3D FlatByPointAndVector(Point3D point, Point3D vector)
        {
            var n = new double[3] { vector.X, vector.Y, vector.Z };
            return new Flat3D(n[0], n[1], n[2], (-point.X * n[0]) + (-point.Y * n[1]) + (-point.Z * n[2]));
        }

        public static Point3D VectorProd((Point3D, Point3D) l1, (Point3D, Point3D) l2)
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

        public static Point3D CrossProduct(Point3D v1, Point3D v2)
        {
            var vec = Accord.Math.Vector3.Cross(new Accord.Math.Vector3((float)v1.X, (float)v1.Y, (float)v1.Z), new Accord.Math.Vector3((float)v2.X, (float)v2.Y, (float)v2.Z));
            return new Point3D(vec.X, vec.Y, vec.Z);
        }

        public static double CosBetweenVectors(Point3D p1, Point3D p2)
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

        public static Point FromDouble(Point3D point)
        {
            return new Point((int)point.X, (int)point.Y);
        }

        public static Point PointOnRealScreen(Point3D point, int screenWidth, int screenHeight, int scale)
        {
            return new Point(
                (int)(screenWidth / 2 + point.X * scale),
                (int)(screenHeight / 2 - point.Y * scale)
            ); ;
        }

        public static List<(int, int, Color)> RasterTriangle()
        {
            throw new NotImplementedException("TODO");
        }
    }
}
