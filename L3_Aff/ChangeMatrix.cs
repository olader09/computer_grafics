using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ChangeMatrix
{
    double[,] matrix;

    public ChangeMatrix()
    {
        matrix = new double[3, 3];
    }

    double[,] mult_matrix(double[,] a, double[,] b)
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
    public double[,] ShiftMatrix(double x, double y, double dx, double dy)
    {
        matrix = new double[3, 3] { { 1,  0,  0 },
                                            { 0,  1,  0 },
                                            {dx, dy,  1 } };

        double[,] beg = new double[1, 3] { { x, y, 1 } };

        double[,] res = new double[1, 3];

        res = mult_matrix(beg, matrix);

        return res;
    }

    public double[,] StretchAroundCenterMatrix(double x, double y, double kx, double ky)
    {
        matrix = new double[3, 3] { { 1 / (double)kx,   0,           0  },
                                            {       0,     1 / (double)ky,   0  },
                                            {       0,          0,           1  } };

        double[,] beg = new double[1, 3] { { x, y, 1 } };

        double[,] res = new double[1, 3];

        res = mult_matrix(beg, matrix);

        return res;
    }

    public double[,] RotateAroundCenterMatrix(double x, double y, double angle)
    {
        matrix = new double[3, 3] { { Math.Cos(angle), Math.Cos(angle), 0 },
                                            {-Math.Cos(angle), Math.Cos(angle), 0 },
                                            {       0,                0,        1 } };

        double[,] beg = new double[1, 3] { { x, y, 1 } };

        double[,] res = new double[1, 3];

        res = mult_matrix(beg, matrix);

        return res;
    }

}