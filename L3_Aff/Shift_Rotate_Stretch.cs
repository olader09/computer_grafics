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
        private void ShiftButton_Click(object sender, EventArgs e)
        {
            if (selectedFigure == null || selectedFigure == "")
                return;

            List<Point> new_list = new List<Point>();
            foreach (var point in figures[selectedFigure])
            {
                double[,] new_coord = new double[1, 3];
                ChangeMatrix matr = new ChangeMatrix();
                var temp_point = ToFromWorldCoordinates(point);
                new_coord = matr.ShiftMatrix(temp_point.X, temp_point.Y, int.Parse(DYTB.Text), int.Parse(DXTB.Text));
                Point p = new Point((int)new_coord[0, 0], (int)new_coord[0, 1]);
                new_list.Add(ToFromWorldCoordinates(p));
            }

            figures[selectedFigure] = new_list;
            RedrawFigures(selectedFigure);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void PointInsideButton_Click(object sender, EventArgs e)
        {
            a = Action.PointInside;
        }

        private void Stretch()
        {
            if (selectedFigure == null || selectedFigure == "")
                return;

            List<Point> new_list = new List<Point>();
            var center = ToFromWorldCoordinates(around.Item3 ? (around.Item1, around.Item2) : GetCenterOfFigure(figures[selectedFigure]));

            foreach (var point in figures[selectedFigure])
            {
                double[,] new_coord = new double[1, 3];
                ChangeMatrix matr = new ChangeMatrix();
                var temp_point = ToFromWorldCoordinates(point);
                new_coord = matr.ShiftMatrix(temp_point.X, temp_point.Y, -center.Item1, -center.Item2);
                new_coord = matr.StretchAroundCenterMatrix(new_coord[0, 0], new_coord[0, 1], int.Parse(StretchKX.Text), int.Parse(StretchKY.Text));
                new_coord = matr.ShiftMatrix(new_coord[0, 0], new_coord[0, 1], center.Item1, center.Item2);
                Point p = new Point((int)new_coord[0, 0], (int)new_coord[0, 1]);
                new_list.Add(ToFromWorldCoordinates(p));
            }

            figures[selectedFigure] = new_list;
            RedrawFigures(selectedFigure);
        }

        private void Rotate()
        {
            if (selectedFigure == null || selectedFigure == "")
                return;

            List<Point> new_list = new List<Point>();
            var center = ToFromWorldCoordinates(around.Item3 ? (around.Item1, around.Item2) : GetCenterOfFigure(figures[selectedFigure]));

            foreach (var point in figures[selectedFigure])
            {
                double[,] new_coord = new double[1, 3];
                ChangeMatrix matr = new ChangeMatrix();
                var temp_point = ToFromWorldCoordinates(point);
                new_coord = matr.ShiftMatrix(temp_point.X, temp_point.Y, -center.Item1, -center.Item2);
                new_coord = matr.RotateAroundCenterMatrix(new_coord[0, 0], new_coord[0, 1], int.Parse(RAPTB.Text));
                new_coord = matr.ShiftMatrix(new_coord[0, 0], new_coord[0, 1], center.Item1, center.Item2);
                Point p = new Point((int)new_coord[0, 0], (int)new_coord[0, 1]);
                new_list.Add(ToFromWorldCoordinates(p));
            }

            figures[selectedFigure] = new_list;
            RedrawFigures(selectedFigure);
        }

        private void StretchCenter_Click(object sender, EventArgs e) // stretch around center
        {
            around.Item3 = false;
            Stretch();
        }

        private void RotateCenterButton_Click(object sender, EventArgs e) // rotate around center
        {
            around.Item3 = false;
            Rotate();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            figures.Clear();
            FigNames.Items.Clear();
            Graphics g = Canvas.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas.Width, Canvas.Height));
        }

        private void LinePointButton_Click(object sender, EventArgs e)
        {
            a = Action.PointToLine;
        }

        private void RotatePointButton_Click(object sender, EventArgs e)
        {
            a = Action.RotatePoint; 
        }

        private void StretchButton_Click(object sender, EventArgs e)
        {
            a = Action.StretchPoint;
        }

    }


}