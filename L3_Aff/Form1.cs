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
    public class ChangeMatrix
    {
        double[,] matrix; 
    }


    public enum Figure {Dot, Line, Polygon}
    public enum Action { NoAction, CreateFigure }

    public partial class Form1 : Form
    {
        public Figure f;
        public Action a;
        public int i = 0;
        bool line = false;
        public string selectedFigure; 

        public Dictionary<string,List<Point>> figures;
        public List<Point> currentFigure; 

        public void ColoringButton(Button b, Color c)
        {
            Bitmap bmp = new Bitmap(b.Width, b.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    c,
                                                    Color.FromArgb(c.R - 20 < 0 ? 0 : c.R - 20, 
                                                                   c.G - 20 < 0 ? 0 : c.G - 20, 
                                                                   c.B - 20 < 0 ? 0 : c.B - 20),
                                                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(br, r);
                }
            }
            b.BackgroundImage = bmp;
            b.ForeColor = Color.White; 
        }

        public void RedrawFigures(string selectedName)
        {
            Graphics g = Canvas.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas.Width, Canvas.Height));
            Pen pen = new Pen(Color.Black); 
            foreach (var fig in figures)
            {
                if (fig.Key == selectedName)
                    pen.Color = Color.Red;
                else
                    pen.Color = Color.Black; 

                if (fig.Value.Count == 1)
                {
                    g.DrawEllipse(pen, fig.Value.ElementAt(0).X, fig.Value.ElementAt(0).Y, 5, 5); 
                }
                else if (fig.Value.Count == 2)
                {
                    g.DrawLine(pen, fig.Value.ElementAt(0), fig.Value.ElementAt(1));
                }
                else
                {
                    Point p = new Point(-1, -1);
                    foreach (var point in fig.Value)
                    {
                        if (p.X == -1 && p.Y == -1)
                            p = point;
                        else
                        {
                            g.DrawLine(pen, p, point);
                            p = point; 
                        }
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            Graphics g = Canvas.CreateGraphics(); 
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas.Width, Canvas.Height));
            ColoringButton(ClearButton, Color.Red);
            FigNames.SelectionMode = SelectionMode.One;
            figures = new Dictionary<string, List<Point>>(); 
        }

        private void DotButton_Click(object sender, EventArgs e)
        {
            a = Action.CreateFigure; 
            f = Figure.Dot;
            currentFigure = new List<Point>();
        }

        private void LineButton_Click(object sender, EventArgs e)
        {
            a = Action.CreateFigure;
            f = Figure.Line;
            currentFigure = new List<Point>();
        }

        private void PolyButton_Click(object sender, EventArgs e)
        {
            if (!line)
            {
                a = Action.CreateFigure;
                f = Figure.Polygon;
                currentFigure = new List<Point>();
                line = true;
                ColoringButton(PolyButton, Color.Green);
            }
            else
            {
                if (line)
                {
                    currentFigure.Add(currentFigure.ElementAt(0));
                    string name = FigName.Text == "" ? "Default figure " + ++i : FigName.Text;
                    figures.Add(name, currentFigure);
                    FigNames.Items.Add(name);
                    a = Action.NoAction;
                    FigNames.EndUpdate();
                    line = false;
                    RedrawFigures(null);
                }
                line = false;
                PolyButton.BackgroundImage = null;
                PolyButton.ForeColor = Color.Black; 
            }

        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e; 

            switch (a)
            {
                case Action.CreateFigure:
                    switch (f)
                    {
                        case Figure.Dot:
                            {
                                currentFigure.Add(me.Location);
                                string name = FigName.Text == "" ? "Default figure " + ++i : FigName.Text;
                                figures.Add(name, currentFigure);
                                FigNames.Items.Add(name);
                                a = Action.NoAction;
                                FigNames.EndUpdate();
                                RedrawFigures(null);
                                break;
                            }

                        case Figure.Line:
                            {
                                currentFigure.Add(me.Location);
                                if (line)
                                {
                                    string name = FigName.Text == "" ? "Default figure " + ++i : FigName.Text;
                                    figures.Add(name, currentFigure);
                                    FigNames.Items.Add(name);
                                    a = Action.NoAction;
                                    FigNames.EndUpdate();
                                    line = false;
                                    RedrawFigures(null);
                                    break; 
                                }
                                line = true;
                            }
                            break;

                        case Figure.Polygon:
                            {
                                currentFigure.Add(me.Location);
                            }
                            break;
                    }

                    break; 
            }
        }

        private void FigNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFigure = (string)FigNames.SelectedItem;
            RedrawFigures(selectedFigure);
        }
    }
}
