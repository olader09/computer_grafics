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
    }
}
