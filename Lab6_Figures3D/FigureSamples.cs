﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
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

            Lines = new List<Edge3D>() {
                new Edge3D(p1, p2),
                new Edge3D(p1, p3),
                new Edge3D(p1, p4),
                new Edge3D(p2, p1),
                new Edge3D(p2, p3),
                new Edge3D(p2, p4),
                new Edge3D(p3, p1),
                new Edge3D(p3, p2),
                new Edge3D(p3, p4),
                new Edge3D(p4, p1),
                new Edge3D(p4, p2),
                new Edge3D(p4, p3),
            };

            Center = new Point3D(
                (p1.X + p2.X + p3.X + p4.X) / 4,
                (p1.Y + p2.Y + p3.Y + p4.Y) / 4,
                (p1.Z + p2.Z + p3.Z + p4.Z) / 4
            );
        }

        // public F4(List<Edge3D> lines) : base(lines) { }
    }
}
