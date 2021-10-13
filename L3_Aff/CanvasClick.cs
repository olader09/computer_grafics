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
                    break;

                case Action.PointToLine:
                    {
                        var b = PointToLine(me.Location, (figures[selectedFigure].ElementAt(int.Parse(PointLineTB.Text)),
                                                          figures[selectedFigure].ElementAt(int.Parse(PointLineTB.Text) + 1)));
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
            }
        }

        
        
    }
}