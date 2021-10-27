using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Figures3D
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Figure> figures = new Dictionary<string, Figure>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs ke)
        {
            switch (ke.KeyChar)
            {

            };
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
