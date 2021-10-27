using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace Lab6_Figures3D
{
    public partial class Form1 : Form
    {
        public List<Figure> figures = new List<Figure>();
        public int selectedFigure = -1;
        public void Next() => selectedFigure = selectedFigure == figures.Count - 1 ? 0 : (selectedFigure + 1); 

        public Form1()
        {
            InitializeComponent();
            Camera camera = new Camera(new Point3D(-1, 0, 0), new Point3D(1, 0, 0)); 
        }

        public void ShowFigures(Camera cam)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs ke)
        {
            switch (ke.KeyChar)
            {

            };
        }
    }

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

        public static double[,] MultMatrix(double[,] a, double[,] b)
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

    public class Camera
    {
        public Point3D Location { get; set; }
        public Point3D View { get; set; }
        // public (double, double, double) Angle;

        public double Width { get; init; }
        public double Height { get; init; }

        public Camera(Point3D location, Point3D view)
        {
            Location = location;
            View = view;
            Width = 2;
            Height = 1; 
        }

        public void Shift(Point3D where)
        {
            Location += where; 
        }

        public void Rotate(Line3D axis, double angle)
        {

        }

        public void Rotate(string axis, double angle)
        {

        }
    }

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

        public static Point3D operator +(Point3D one, Point3D other)
        {
            return new Point3D(one.X + other.X, one.Y + other.Y, one.Z + other.Z);
        }
    }

    public class Plane
    {
        public List<Point3D> Value { get; set; }

        public Plane(List<Point3D> list)
        {
            Value = new List<Point3D>(list);
        }
    }

    public class Line3D
    {
        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }

        public Line3D(Point3D p1, Point3D p2)
        {
            P1 = new Point3D(p1.X, p1.Y, p1.Z);
            P2 = new Point3D(p2.X, p2.Y, p2.Z);
        }
    }

    public class Figure
    {
        public List<Point3D> Points;
        public List<Line3D> Lines;
        public List<Plane> Planes;

        // In world coordinates 
        public Point3D Center { get; set; }

        public Figure() { }

        public Figure(List<Line3D> lines)
        {
            Lines = new List<Line3D>(lines);
        }
    }

    public class F4 : Figure
    {
        public F4()
        {
            // 4 Dots 
            // 1 -> (0, 0, 0)
            // 2 -> (1, 0, 0)
            // 3 -> (1/2, sqrt(3)/2, 0)
            // 4 -> (1/2, 1/(2*sqrt(3)), sqrt(2/3))
            var p1 = new Point3D(0, 0, 0);
            var p2 = new Point3D(1, 0, 0);
            var p3 = new Point3D(1 / 2.0, Math.Sqrt(3) / 2, 0);
            var p4 = new Point3D(1 / 2.0, 1 / (2 * Math.Sqrt(3)), Math.Sqrt(2.0 / 3));

            Points = new List<Point3D>() { p1, p2, p3, p4 };

            Lines = new List<Line3D>() {
                new Line3D(p1, p2),
                new Line3D(p1, p3),
                new Line3D(p1, p4),
                new Line3D(p2, p1),
                new Line3D(p2, p3),
                new Line3D(p2, p4),
                new Line3D(p3, p1),
                new Line3D(p3, p2),
                new Line3D(p3, p4),
                new Line3D(p4, p1),
                new Line3D(p4, p2),
                new Line3D(p4, p3),
            };

            Center = new Point3D(
                (p1.X + p2.X + p3.X + p4.X) / 4,
                (p1.Y + p2.Y + p3.Y + p4.Y) / 4,
                (p1.Z + p2.Z + p3.Z + p4.Z) / 4
            );
        }

        // public F4(List<Line3D> lines) : base(lines) { }
    }
}
