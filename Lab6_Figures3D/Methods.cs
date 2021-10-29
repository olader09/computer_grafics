using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab6_Figures3D
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

        public static Line3D LineBy2Points(Point3D point, Point3D vector)
        {
            var p = new double[3] { point.X, point.Y, point.Z };
            var v = new double[3] { vector.X, vector.Y, vector.Z }; 
            return new Line3D(new(v[0], p[0]), new(v[1], p[1]), new(v[2], p[2]));
        }

        // Generates flat through point that is normal to a given line
        public static Flat3D NormalFlat(Line3D line, Point3D point)
        {
            var n = new double[3] { line.LX.K, line.LY.K, line.LZ.K };
            return new Flat3D(n[0], n[1], n[2], (-point.X * n[0]) + (-point.Y * n[1]) + (-point.Z * n[2]));
        }

        // We assume that point lays on vector line
        public static double GetDistanceInUnits(Edge3D vector, Point3D point)
        {
            var vecStart = vector.P1;
            var vecEnd = vector.P2;

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
    }
}
