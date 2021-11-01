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
            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = new double[1, 4];
            res = Matrix.Mult(beg, Matrix.ShiftMatrix(vector.X, vector.Y, vector.Z));
            return new Point3D(res[0,0], res[0,1], res[0,2]);
        }

        public static Point3D RotateAroundLine(Line3D line, Point3D point, double angle)
        {
            throw new NotImplementedException("TODO");
        }

        public static Point3D Rotate(Point3D point, double angle)
        {

            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = new double[1, 4];
            res = Matrix.Mult(beg, Matrix.RotateX(angle));
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        // We have
        // from *--------->* point
        // We want 
        // from *----------|------------------> new_point (was scaled by ~ 2.7)
        public static Point3D Scale(Point3D point, Point3D from, double coef)
        {
            var vec = point - from;
            vec *= coef;
            from += vec;
            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = new double[1, 4];
            res = Matrix.Mult(beg, Matrix.ScaleMatrix(from.X, from.Y, from.Z));
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        public static Point3D Reflect(Flat3D flat, Point3D point)
        {
            throw new NotImplementedException("TODO"); 
        }
    }
}
