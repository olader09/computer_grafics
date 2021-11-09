using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab6_Figures3D
{
    public class Matrix
    {
        public double[,] Value; 

        public static double DegreesToRadians(double degrees) => degrees * (Math.PI / 180);

        public static explicit operator Matrix(double [,] matr)
        {
            Matrix m = new();
            m.Value = matr;
            return m;
        }

        public static Matrix operator + (Matrix a, Matrix b)
        {
            double[,] res = new double[a.Value.GetLength(0), b.Value.GetLength(1)];

            for (int i = 0; i < a.Value.GetLength(0); i++)
            {
                for (int j = 0; j < b.Value.GetLength(1); j++)
                {
                    res[i, j] = a.Value[i, j] + b.Value[i, j];
                }
            }
            return (Matrix)res;
        }


        public static Matrix operator * (Matrix a, Matrix b)
        {
            double[,] res = new double[a.Value.GetLength(0), b.Value.GetLength(1)];

            for (int i = 0; i < a.Value.GetLength(0); i++)
            {
                for (int j = 0; j < b.Value.GetLength(1); j++)
                {
                    for (int k = 0; k < a.Value.GetLength(1); k++)
                    {
                        res[i, j] += a.Value[i, k] * b.Value[k, j];
                    }
                }
            }
            return (Matrix)res;
        }

        // FOR MULTIPLICATION FROM LEFT SIDE:
        // [x, y, z, 1] * [change matrix] => result

        #region Identity 

        public static Matrix IdentityMatrix()
        {
            return (Matrix)new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
        }

        #endregion

        #region Scale

        public static Matrix ScaleMatrix(double dx, double dy, double dz)
        {
            return (Matrix)
                  new double[4, 4] { {     dx,     0,     0,     0 },
                                   {     0,     dy,     0,     0 },
                                   {     0,      0,    dz,     0 },
                                   {     0,      0,     0,     1 } };
        }

        public static Matrix ScaleMatrix(Point3D p)
        {
            return (Matrix)
                new double[4, 4] { {   p.X,     0,     0,     0 },
                                   {     0,   p.Y,     0,     0 },
                                   {     0,     0,   p.Z,     0 },
                                   {     0,     0,     0,     1 } };
        }

        #endregion

        #region Shift

        public static Matrix ShiftMatrix(double dx, double dy, double dz)
        {
            return (Matrix)
                new double[4, 4] { {     1,     0,     0,     0 },
                                   {     0,     1,     0,     0 },
                                   {     0,     0,     1,     0 },
                                   {    dx,    dy,    dz,     1 } };
        }

        public static Matrix ShiftMatrix(Point3D p)
        {
            return (Matrix)
                new double[4, 4] { {     1,     0,     0,     0 },
                                   {     0,     1,     0,     0 },
                                   {     0,     0,     1,     0 },
                                   {   p.X,   p.Y,   p.Z,     1 } };
        }

        #endregion

        #region Rotate

        // Angle in degrees
        public static Matrix RotateX(double angle)
        {
            double rad = DegreesToRadians(angle);
            return (Matrix) new double[4, 4] {
                { 1,       0,           0,        0 },
                { 0,    Cos(rad),    Sin(rad),    0 },
                { 0,   -Sin(rad),    Cos(rad),    0 },
                { 0,       0,           0,        1 }
            };
        }

        // Angle in degrees
        public static Matrix RotateY(double angle)
        {
            double rad = DegreesToRadians(angle);
            return (Matrix) new double[4, 4] {
                { Cos(rad),   0,  -Sin(rad),   0 },
                {    0,       1,      0,       0 },
                { Sin(rad),   0,   Cos(rad),   0 },
                {    0,       0,      0,       1 }
            };
        }

        // Angle in degrees
        public static Matrix RotateZ(double angle)
        {
            double rad = DegreesToRadians(angle);
            return (Matrix) new double[4, 4] {
                {  Cos(rad),    Sin(rad),    0,    0 },
                { -Sin(rad),    Cos(rad),    0,    0 },
                {     0,           0,        1,    0 },
                {     0,           0,        0,    1 }
            };
        }

        public static Matrix RX(Point3D point)
        {
            double l = point.X, m = point.Y, n = point.Z;
            var d = Sqrt(m * m + n * n);
            return (Matrix) new double[4, 4] { 
                {     1,     0,     0,     0 },
                {     0,   n/d,   m/d,     0 },
                {     0,  -m/d,   n/d,     0 },
                {     0,     0,     0,     1 } 
            };
        }

        public static Matrix RY(Point3D point)
        {
            double l = point.X, m = point.Y, n = point.Z;
            var d = Sqrt(m * m + n * n);
            return (Matrix) new double[4, 4] {
                {     l,     0,     d,     0 },
                {     0,     1,     0,     0 },
                {     d,     0,     l,     0 },
                {     0,     0,     0,     1 }
            };
        }

        public static Matrix BigOne(Point3D point, double angle)
        {
            double l = point.X, m = point.Y, n = point.Z;
            double rad = DegreesToRadians(angle);
            double f = Cos(rad);
            double s = Sin(rad);
            double c = 1 - f;
            return (Matrix) new double[4, 4]
                 {
                     {     l * l + f * (1 - l * l),            l * c * m - n * s,           l * c * n + m * s,      0 },
                     {           l * c * m + n * s,      m * m + f * (1 - m * m),           m * c * n - l * s,      0 },
                     {           l * c * n - m * s,            m * c * n + l * s,     n * n + f * (1 - n * n),      0 },
                     {                   0,                            0,                           0,              1 }
                 };
        }

        #endregion
    }
}
