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
            selectedFigure = (string)FigNames.SelectedItem;
            RedrawFigures(selectedFigure);
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

        /*public (bool, Point) IntersectsLineLine((Point, Point) l1, (Point, Point) l2)
        {
            
        }*/
    }
}