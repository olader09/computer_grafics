using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using FigureParts.Point;
using FigureParts.Edge;

namespace Lab6_Figures3D
{
    public static class Matrix
    {
        // FOR MULTIPLICATION FROM LEFT SIDE:
        // [x, y, z, 1] * [change matrix] => result

        public static double[,] IdentityMatrix()
        {
            return new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
        }

        public static double[,] RX(Point3D point)
        {
            double l = point.X, m = point.Y, n = point.Z; 
            var d = Sqrt(m * m + n * n);
            return new double[4, 4] { {     1,     0,     0,     0 },
                                      {     0,   n/d,   m/d,     0 },
                                      {     0,  -m/d,   n/d,     0 },
                                      {     0,     0,     0,     1 } };
        }

        public static double[,] RY(Point3D point)
        {
            double l = point.X, m = point.Y, n = point.Z;
            var d = Sqrt(m * m + n * n);
            return new double[4, 4] { {     l,     0,     d,     0 },
                                      {     0,     1,     0,     0 },
                                      {     d,     0,     l,     0 },
                                      {     0,     0,     0,     1 } };
        }

        public static double[,] BigOne(Point3D point, double angle)
        {
            double l = point.X, m = point.Y, n = point.Z;
            double rad = DegreesToRadians(angle);
            double f = Cos(rad);
            double s = Sin(rad);
            double c = 1 - f;
            return new double[4, 4]
                 { 
                     {     l * l + f * (1 - l * l),            l * c * m - n * s,           l * c * n + m * s,      0 },
                     {           l * c * m + n * s,      m * m + f * (1 - m * m),           m * c * n - l * s,      0 },
                     {           l * c * n - m * s,            m * c * n + l * s,     n * n + f * (1 - n * n),      0 },
                     {                   0,                            0,                           0,              1 } 
                 };
        }

        public static double[,] ScaleMatrix(double dx, double dy, double dz)
        {
            return new double[4, 4] { {     dx,     0,     0,     0 },
                                      {     0,     dy,     0,     0 },
                                      {     0,      0,    dz,     0 },
                                      {     0,      0,     0,     1 } };
        }

        public static double[,] ScaleMatrix(Point3D p)
        {
            return new double[4, 4] { {   p.X,     0,     0,     0 },
                                      {     0,   p.Y,     0,     0 },
                                      {     0,     0,   p.Z,     0 },
                                      {     0,     0,     0,     1 } };
        }

        public static double[,] ShiftMatrix(double dx, double dy, double dz)
        {
            return new double[4, 4] { {     1,     0,     0,     0 },
                                      {     0,     1,     0,     0 },
                                      {     0,     0,     1,     0 },
                                      {    dx,    dy,    dz,     1 } };
        }

        public static double[,] ShiftMatrix(Point3D p)
        {
            return new double[4, 4] { {     1,     0,     0,     0 },
                                      {     0,     1,     0,     0 },
                                      {     0,     0,     1,     0 },
                                      {   p.X,   p.Y,   p.Z,     1 } };
        }

        public static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180);

        // Angle in degrees
        public static double[,] RotateX(double angle)
        {
            double rad = DegreesToRadians(angle);
            return new double[4, 4] {
                { 1,       0,           0,        0 },
                { 0,    Cos(rad),    Sin(rad),    0 },
                { 0,   -Sin(rad),    Cos(rad),    0 },
                { 0,       0,           0,        1 }
            };
        }

        // Angle in degrees
        public static double[,] RotateY(double angle)
        {
            double rad = DegreesToRadians(angle);
            return new double[4, 4] {
                { Cos(rad),   0,  -Sin(rad),   0 },
                {    0,       1,      0,       0 },
                { Sin(rad),   0,   Cos(rad),   0 },
                {    0,       0,      0,       1 }
            };
        }

        // Angle in degrees
        public static double[,] RotateZ(double angle)
        {
            double rad = DegreesToRadians(angle);
            return new double[4, 4] {
                {  Cos(rad),    Sin(rad),    0,    0 },
                { -Sin(rad),    Cos(rad),    0,    0 },
                {     0,           0,        1,    0 },
                {     0,           0,        0,    1 }
            };
        }

        // a.Mult(b)
        public static double[,] Mult(this double[,] a, double[,] b)
        {
            double[,] res = new double[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < a.GetLength(1); k++)
                    {
                        res[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return res;
        }

        /*public static double[] Rotate(double[] vector)
        {

        }*/
    }
}
