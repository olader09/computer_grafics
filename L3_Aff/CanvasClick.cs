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

                case Action.PointInside:
                    {
                        if (selectedFigure == null || selectedFigure == "")
                            break; 

                        double angle_sum = 0.0;
                        Point p = me.Location; 
                        for (int i = 1; i < figures[selectedFigure].Count; ++i)
                        {
                            Point p1 = figures[selectedFigure].ElementAt(i - 1);
                            Point p2 = figures[selectedFigure].ElementAt(i);

                            var new_p1 = new Point(p1.X - p.X, p1.Y - p.Y);
                            var new_p2 = new Point(p2.X - p.X, p2.Y - p.Y);

                            double fi = Math.Acos((new_p1.X * new_p2.X + new_p1.Y * new_p2.Y)
                                                               /
                                                (Length(p, p1) * Length(p, p2))) * Math.Sign(new_p1.X * new_p2.Y - new_p1.X * new_p1.Y);

                            angle_sum += fi; 
                        }

                        if (Math.Abs(angle_sum) <= double.Epsilon * 250)
                            ColoringButton(PointInsideButton, Color.Green);
                        else
                            ColoringButton(PointInsideButton, Color.Red);
                    }
                    break;


                /* Deprecated ==============================================
                case Action.PointInside:
                    {
                        if (selectedFigure == null || selectedFigure == "")
                            break;
                        Point p = new Point(me.X, me.Y);
                        (Point, Point) vec = (p, new Point(p.X + 20, p.Y + 20));
                        int intersections = 0;
                        bool start = true;
                        Point one = new Point();
                        foreach (var l in figures[selectedFigure])
                        {
                            if (start)
                            {
                                one = l;
                                start = false;
                            }
                            else
                            {
                                if (IntersectsLineVector((l, one), vec))
                                    ++intersections;
                                one = l;
                            }
                        }
                        if ((intersections / 2) % 2 == 1)
                            ColoringButton(PointInsideButton, Color.Green);
                        else
                            ColoringButton(PointInsideButton, Color.Red);
                    }
                    break;*/

                case Action.PointToLine:
                    {
                        //var b = PointToLine(me.Location, (figures[selectedFigure].ElementAt(int.Parse(PointLineTB.Text)),
                        //                                figures[selectedFigure].ElementAt(int.Parse(PointLineTB.Text) + 1)));
                        var b = PointToLine(me.Location, (figures[selectedFigure].ElementAt(0),
                                                          figures[selectedFigure].ElementAt(1)));
                        if (b == null)
                            ColoringButton(LinePointButton, Color.Blue);
                        else if ((bool)b)
                            ColoringButton(LinePointButton, Color.Green);
                        else
                            ColoringButton(LinePointButton, Color.Red);
                    }
                    break;

                case Action.StretchPoint:
                    {
                        around = (me.X, me.Y, true);
                        Stretch();
                    }
                    break;

                case Action.RotatePoint:
                    {
                        around = (me.X, me.Y, true);
                        Rotate();
                    }
                    break;

                case Action.FindCollision:
                    {
                        if (!line)
                        {
                            line = true;
                            l.Item1 = me.Location; 
                        }
                        else
                        {
                            line = false;
                            a = Action.NoAction;
                            l.Item2 = me.Location;
                            // IntersectsLineLine(); 
                        }
                    }
                    break; 
            }
        }

        
        
    }
}