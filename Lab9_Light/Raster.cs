using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeometricFunctions
{
    public class Raster
    {
        public static List<(Point, double[])> Triangle((Point, double[]) p1, (Point, double[]) p2, (Point, double[]) p3)
        {
            if (p1.Item1.Y == p2.Item1.Y)
                return HorizontalTriangle(p3.Item1, p1.Item1, p2.Item1, p3.Item2, p1.Item2, p2.Item2);
            else if (p1.Item1.Y == p3.Item1.Y)
                return HorizontalTriangle(p2.Item1, p1.Item1, p3.Item1, p2.Item2, p1.Item2, p3.Item2);
            else if (p2.Item1.Y == p3.Item1.Y)
                return HorizontalTriangle(p1.Item1, p2.Item1, p3.Item1, p1.Item2, p2.Item2, p3.Item2); 
            else
            {
                var l = new List<(Point, double[])>() { p1, p2, p3 };
                l.Sort((x, y) => x.Item1.Y.CompareTo(y.Item1.Y));

                var middle = l[1];
                var one = l[0];
                var two = l[2];

                double mo = middle.Item1.Y - one.Item1.Y;

                double d = mo / (two.Item1.Y - one.Item1.Y);

                Point horizon = new Point(
                    (int)(one.Item1.X + (two.Item1.X - one.Item1.X) * d),
                    middle.Item1.Y);

                double[] h = new double[p1.Item2.Length];
                for (int i = 0; i < p1.Item2.Length; ++i)
                    h[i] = one.Item2[i] + (two.Item2[i] - one.Item2[i]) * d;

                var result =
                    HorizontalTriangle(one.Item1, middle.Item1, horizon, one.Item2, middle.Item2, h);
                result.AddRange(
                    HorizontalTriangle(two.Item1, middle.Item1, horizon, two.Item2, middle.Item2, h));

                return result;
            }
        }

        // Draws triangle where r2 and r3 is horisontal line and r1 is (down ? under: above)
        // r2 is on left to the r3
        private static List<(Point, double[])> HorizontalTriangle(Point p1, Point p2, Point p3, double[] a1, double[] a2, double[] a3)
        {
            // P1 -> P2

            List<(Point, double[])> p1p2 = new List<(Point, double[])>();
            int rows = p2.Y - p1.Y;
            if (rows == 0) return new List<(Point, double[])>(); 

            double[] p1p2diff = new double[a1.Length];
            for (int i = 0; i < a1.Length; ++i)
                p1p2diff[i] = (a2[i] - a1[i]) / Math.Abs(rows);

            for (int i = 0; i < Math.Abs(rows) + 1; ++i)
                p1p2.Add(
                    (new Point((int)(p1.X + (p2.X - p1.X) / (double)Math.Abs(rows) * i), p1.Y + i * (rows / Math.Abs(rows))),
                    a1.Zip(p1p2diff, (x, y) => x + y * i).ToArray())
                );

            // P1 -> P3 

            List<(Point, double[])> p1p3 = new List<(Point, double[])>();
            rows = p3.Y - p1.Y;

            double[] p1p3diff = new double[a1.Length];
            for (int i = 0; i < a1.Length; ++i)
                p1p3diff[i] = (a3[i] - a1[i]) / Math.Abs(rows);

            for (int i = 0; i < Math.Abs(rows) + 1; ++i)
                p1p3.Add(
                    (new Point((int)(p1.X + (p3.X - p1.X) / (double)Math.Abs(rows) * i), p1.Y + i * (rows / Math.Abs(rows))),
                    a1.Zip(p1p3diff, (x, y) => x + y * i).ToArray())
                );

            // Triangle 
            List<(Point, double[])> result = new List<(Point, double[])>(); 

            for (int i = 0; i < Math.Abs(rows) + 1; ++i)
            {
                int cols = Math.Abs(p1p2[i].Item1.X - p1p3[i].Item1.X);
                double[] diff = new double[a1.Length];
                for (int k = 0; k < a1.Length; ++k)
                    diff[k] = (p1p3[i].Item2[k] - p1p2[i].Item2[k]) / cols;
                
                for (int j = 0; j < cols; ++j)
                {
                    result.Add(
                        (
                            new Point((int)(p1p2[i].Item1.X + (p1p3[i].Item1.X - p1p2[i].Item1.X) / (double)cols * j), p1p2[i].Item1.Y),
                            p1p2[i].Item2.Zip(diff, (x, y) => x + y * j).ToArray()
                        ));
                }
            }

            return result;
        }
    }
}
