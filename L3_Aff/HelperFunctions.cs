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

namespace L3_Aff
{

    public partial class Form1 : Form
    {
        // Use before changing points with matricies and afte (changes Point.Y)
        private Point ToFromWorldCoordinates(Point p)
        {
            return new Point(p.X, Canvas.Height - p.Y);
        }

        private (double, double) ToFromWorldCoordinates((double, double) p)
        {
            return (p.Item1, Canvas.Height - p.Item2);
        }

        private bool? PointToLine(Point p, (Point, Point) l)
        {
            //  return a2b3 - a3b2, a3b1 - a1b3, a1b2 - a2b1

            //int res = p.Y * l.Item2.X - p.X * l.Item2.Y;
            Point A = ToFromWorldCoordinates(l.Item1);
            Point B = ToFromWorldCoordinates(l.Item2);
            Point C = ToFromWorldCoordinates(p);

            int ax = B.X - A.X;
            int ay = B.Y - A.Y;

            int bx = C.X - B.X;
            int by = C.Y - B.Y;

            int res = ax * by - ay * bx;

            if (res > 0)
                return true;
            else if (res < 0)
                return false;
            else return null;
        }

        private bool IntersectsLineVector((Point, Point) line, (Point, Point) vector)
        {
            bool? b1 = PointToLine(line.Item1, vector);
            bool? b2 = PointToLine(line.Item2, vector);
            return b1 == null || b2 == null || (bool)(b1 ^ b2);
        }

        private void FigNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (a == Action.PolygonUnion)
            {
                polygon2 = (string)FigNames.SelectedItem;
                // RedrawFigures(polygon1, polygon2);
                string name = FigName.Text == "" ? "Default figure " + ++i : FigName.Text;
                figures.Add(name, PolygonUnion(figures[polygon1], figures[polygon2]));
                FigNames.Items.Add(name);
                // FigNames.SelectedIndex = -1;
                FigNames.EndUpdate();
                RedrawFigures(name);
                a = Action.NoAction;
            }
            else
            {
                selectedFigure = (string)FigNames.SelectedItem;
                RedrawFigures(selectedFigure);
            }
        }

        private double Length(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private (double, double) GetCenterOfFigure(List<Point> figure)
        {
            double x = 0.0, y = 0.0;
            foreach (var point in figure)
            {
                x += point.X;
                y += point.Y;
            }
            return (x / figure.Count, y / figure.Count);
        }

        public (bool, Point) IntersectsLineLine((Point, Point) l1, (Point, Point) l2)
        {
            double p0x = l1.Item1.X, p0y = l1.Item1.Y, p1x = l1.Item2.X, p1y = l1.Item2.Y,
                   p2x = l2.Item1.X, p2y = l2.Item1.Y, p3x = l2.Item2.X, p3y = l2.Item2.Y;

            double s1x = p1x - p0x, s1y = p1y - p0y, s2x = p3x - p2x, s2y = p3y - p2y;

            double s = (-s1y * (p0x - p2x) + s1x * (p0y - p2y)) / (-s2x * s1y + s1x * s2y),
                   t = (s2x * (p0y - p2y) - s2y * (p0x - p2x)) / (-s2x * s1y + s1x * s2y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
                return (true, new Point((int)(p0x + (t * s1x)), (int)(p0y + (t * s1y))));
            else
                return (false, new Point());

        }

        public class PolyIt
        {
            public Point p; 
            public List<Point> cur_polygon;
            public List<Point> oth_polygon;

            public bool InOther()
            {
                return oth_polygon.Contains(p);
            }

            public void Switch()
            {
                (cur_polygon, oth_polygon) = (oth_polygon, cur_polygon);
            }

            public PolyIt(List<Point> l, List<Point> oth, Point pp)
            {
                cur_polygon = l;
                oth_polygon = oth; 
                p = pp; 
            }

            public void Next()
            {
                int i = cur_polygon.FindIndex(point => point == p);
                if (i == cur_polygon.Count - 1)
                    i = 0; 
                p = cur_polygon.ElementAt(++i);  
            }
        }

        public void AddVertices(List<Point> list, (int, List<Point>) add)
        {
            var g = Canvas.CreateGraphics(); 
            var p = list.ElementAt(add.Item1);
            var lp = new List<Point>();
            lp.AddRange(add.Item2);
            lp.Sort((x, y) => Length(p, x).CompareTo(Length(p, y)));
            int i = add.Item1 + 1;
            foreach (var point in lp)
            {
                g.DrawEllipse(new Pen(Color.Blue), point.X - 3, point.Y - 3, 6, 6);
                list.Insert(i++, point);
            }
        }

        public void DrawPoly(List<Point> list)
        {
            var g = Canvas.CreateGraphics();
            for (int i = 0; i < list.Count - 1; ++i)
                g.DrawLine(new Pen(Color.Blue), list.ElementAt(i), list.ElementAt(i + 1)); 
        }

        public List<Point> PolygonUnion(List<Point> pp1, List<Point> pp2)
        {
            List<Point> p1 = new List<Point>();
            p1.AddRange(pp1);
            List<Point> p2 = new List<Point>();
            p2.AddRange(pp2);

            var to_add1 = new Dictionary<int, List<Point>>();
            var to_add2 = new Dictionary<int, List<Point>>();

            var res = new List<Point>();
            // var a1 = new List<(int, Point)>();
            // var a2 = new List<(int, Point)>();

            for (int i = 0; i < p1.Count - 1; ++i)
            {
                // int ii = i + 1; 
                var l1 = (p1.ElementAt(i), p1.ElementAt(i + 1));
                
                for (int j = 0; j < p2.Count - 1; ++j)
                {
                    // int jj = j + 1; 
                    var l2 = (p2.ElementAt(j), p2.ElementAt(j + 1));
                    var t = IntersectsLineLine(l1, l2); 
                    if (t.Item1)
                    {
                        if (to_add1.ContainsKey(i))
                            to_add1[i].Add(t.Item2);
                        else
                            to_add1.Add(i, new List<Point>() { t.Item2 });

                        if (to_add2.ContainsKey(j))
                            to_add2[j].Add(t.Item2);
                        else
                            to_add2.Add(j, new List<Point>() { t.Item2 });

                        // var add = t.Item2;
                        // a1.Add((ii++, add));
                        // a2.Add((jj++, add));
                    }
                }
            }

            int count = 0; 
            foreach (var x in to_add1)
            {
                AddVertices(p1, (x.Key + count , x.Value));
                count += x.Value.Count; 
            }
            count = 0;
            foreach (var x in to_add2)
            {
                AddVertices(p2, (x.Key + count, x.Value));
                count += x.Value.Count;
            }

            DrawPoly(p1);
            DrawPoly(p2); 


            var start = new Point(int.MaxValue, 0);
            var st_poly = p1;
            var oth_poly = p2;
            foreach (var p in p1)
                if (p.X < start.X)
                    start = p;

            foreach (var p in p2)
                if (p.X < start.X)
                {
                    start = p;
                    st_poly = p2;
                    oth_poly = p1; 
                }

            PolyIt it = new PolyIt(st_poly, oth_poly, start);
            do
            {
                res.Add(it.p);
                DrawPoly(res);
                it.Next();
                if (it.InOther())
                    it.Switch(); 
            } while (it.p != start);
            res.Add(res.First());


            return res;
        }
    }
}