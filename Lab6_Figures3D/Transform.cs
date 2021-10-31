using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
    public static class Transform
    {
        public static Point3D Shift(Point3D point, Point3D vector)
        {
            throw new NotImplementedException("TODO");
        }

        public static Point3D RotateAroundLine(Line3D line, Point3D point, double angle)
        {
            throw new NotImplementedException("TODO");
        }

        // We have
        // from *--------->* point
        // We want 
        // from *----------|------------------> new_point (was scaled by ~ 2.7)
        public static Point3D Scale(Point3D point, Point3D from, double coef)
        {
            throw new NotImplementedException("TODO");
        }

        public static Point3D Reflect(Flat3D flat, Point3D point)
        {
            throw new NotImplementedException("TODO"); 
        }
    }
}
