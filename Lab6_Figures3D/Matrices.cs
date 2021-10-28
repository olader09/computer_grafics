using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

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

        public static double[,] ScaleMatrix(double dx, double dy, double dz)
        {
            return new double[4, 4] { {     dx,     0,     0,     0 },
                                      {     0,     dy,     0,     0 },
                                      {     0,      0,    dz,     0 },
                                      {     0,      0,     0,     1 } };
        }

        public static double[,] ShiftMatrix(double dx, double dy, double dz)
        {
            return new double[4, 4] { {     1,     0,     0,     0 },
                                      {     0,     1,     0,     0 },
                                      {     0,     0,     1,     0 },
                                      {    dx,    dy,    dz,     1 } };
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
