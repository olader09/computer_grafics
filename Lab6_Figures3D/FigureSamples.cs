using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{

    public class Coord : Figure3D
    {
        public Coord()
        {
            var O = new Point3D(0, 0, 0);
            var X = new Point3D(10, 0, 0);
            var Y = new Point3D(0, 10, 0);
            var Z = new Point3D(0, 0, 10);
            Points.AddRange(new List<Point3D>() { O, X, Y, Z });
            Lines = new()
            {
                (0, 1),
                (0, 2), 
                (0, 3),
            };
        }
    }

    public class Grid : Figure3D
    {
        public Grid()
        {
            var i = 0;
            for (int x = -7; x < 8; ++x)
            {
                var p1 = new Point3D(x, -7, 0);
                var p2 = new Point3D(x, 7, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }

            for (int y = -7; y < 8; ++y)
            {
                var p1 = new Point3D(-7, y, 0);
                var p2 = new Point3D(7, y, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }
        }
    }

    public class F4 : Figure3D
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

            Lines = new List<(int, int)>() 
            {
                (0, 1),
                (0, 2),
                (0, 3),
                (1, 2),
                (1, 3), 
                (2, 3), 
            };

            Planes = new List<List<int>>()
            {
                new() { 0, 1, 2 },
                new() { 0, 2, 3 }, 
                new() { 1, 2, 3 }, 
                new() { 0, 1, 3 },
            };
        }

        // public F4(List<Edge3D> lines) : base(lines) { }
    }
}
