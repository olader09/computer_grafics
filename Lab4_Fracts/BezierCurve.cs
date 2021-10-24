using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace Lab4_Fracts
{
    public partial class Form2 : Form
    {
        private Button button1;
        bool isDraw = false;
        List<Point> lst = new List<Point>();
        public PictureBox Main;
        Graphics g;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Main_Click(object sender, MouseEventArgs ev)
        {

            g = Main.CreateGraphics();

            if (lst.Count < 4)
            {
                switch (lst.Count)
                {
                    case 0:
                        {
                            lst.Add(new Point(ev.X, ev.Y));
                            g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                            break;
                        }
                    case 1:
                        {
                            lst.Add(new Point(ev.X, ev.Y));
                            g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                            g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                            break;
                        }
                    case 2:
                        {
                            lst.Add(new Point(ev.X, ev.Y));
                            g.Clear(DefaultBackColor);

                            g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                            g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                            g.DrawEllipse(new Pen(Color.Black), lst[2].X - 3, lst[2].Y - 3, 6, 6);

                            g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                            g.DrawLine(new Pen(Color.Black), lst[1], lst[2]);

                            drawBezierOfThreePoint(lst[0], lst[1], lst[2]);
                            break;
                        }
                    case 3:
                        {
                            lst.Add(new Point(ev.X, ev.Y));
                            g.Clear(DefaultBackColor);

                            g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                            g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                            g.DrawEllipse(new Pen(Color.Black), lst[2].X - 3, lst[2].Y - 3, 6, 6);
                            g.DrawEllipse(new Pen(Color.Black), lst[3].X - 3, lst[3].Y - 3, 6, 6);

                            g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                            g.DrawLine(new Pen(Color.Black), lst[1], lst[2]);
                            g.DrawLine(new Pen(Color.Black), lst[2], lst[3]);

                            drawBezierOfFourPoint(lst[0], lst[1], lst[2], lst[3]);
                            break;
                        }
                }
            }
            else
            {
                if (lst.Count % 2 == 0)
                {
                    lst.Add(new Point(ev.X, ev.Y));
                    g.Clear(DefaultBackColor);

                    for (int i = 0; i < lst.Count; i++)
                        g.DrawEllipse(new Pen(Color.Black), lst[i].X - 3, lst[i].Y - 3, 6, 6);
                }
                else 
                {
                    lst.Add(new Point(ev.X, ev.Y));
                    for (int i = 0; i + 3 < lst.Count; i+=2)
                    {
                        int r_i_x = (lst[i].X + lst[i + 1].X) / 2;
                        int r_i_y = (lst[i].Y + lst[i + 1].Y) / 2;

                        int r_ii_x = (lst[i + 2].X + lst[i + 3].X) / 2;
                        int r_ii_y = (lst[i + 2].Y + lst[i + 3].Y) / 2;

                        g.DrawLine(new Pen(Color.Black), lst[i], lst[i + 1]);
                        g.DrawLine(new Pen(Color.Black), lst[i + 2], lst[i + 3]);

                        g.DrawEllipse(new Pen(Color.Red), r_i_x-2, r_i_y-2, 4, 4);
                        g.DrawEllipse(new Pen(Color.Red), r_ii_x-2, r_ii_y-2, 4, 4);

                        g.DrawEllipse(new Pen(Color.Black), lst[lst.Count - 1].X - 3, lst[lst.Count - 1].Y - 3, 6, 6);
                        drawBezierOfFourPoint(new Point(r_i_x, r_i_y), lst[i + 1], lst[i + 2], new Point(r_ii_x, r_ii_y));
                    }
                }
            }
            
            //case 4:
            //  {
            //    if (Math.Abs(p0.X - ev.X) < 50 && Math.Abs(p0.Y - ev.Y) < 50)
            //  {
            //    isDraw = true;
            //}
            //break;
            //}


        }

  

        

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            lst.Clear();
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            //isDraw = false;
        }

        private void Main_MouseMove(object sender, MouseEventArgs ev)
        {
            while (isDraw)
            {
                //g.DrawEllipse(new Pen(DefaultBackColor), p0.X - 3, p0.Y - 3, 6, 6);
                /*
                g.Clear(DefaultBackColor);

                p0 = new Point(ev.X, ev.Y);

                g.DrawEllipse(new Pen(Color.Black), p0.X - 3, p0.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p1.X - 3, p1.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p2.X - 3, p2.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p3.X - 3, p3.Y - 3, 6, 6);

                g.DrawLine(new Pen(Color.Black), p0, p1);
                g.DrawLine(new Pen(Color.Black), p1, p2);
                g.DrawLine(new Pen(Color.Black), p2, p3);

                


                isDraw = false;
                */
            }
        }

        private void InitializeComponent()
        {
            this.Main = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Main)).BeginInit();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.Location = new System.Drawing.Point(-1, -1);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(815, 423);
            this.Main.TabIndex = 0;
            this.Main.TabStop = false;
            this.Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_Click);
            this.Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(717, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(812, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Main);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main)).EndInit();
            this.ResumeLayout(false);

        }

        Point getPointOf4(Point p0, Point p1, Point p2, Point p3, double t)
        {
            double x = p0.X * Math.Pow(1 - t, 3) + 3 * p1.X * Math.Pow(1 - t, 2) * t + 3 * p2.X * (1 - t) * Math.Pow(t, 2) + p3.X * Math.Pow(t, 3);
            double y = p0.Y * Math.Pow(1 - t, 3) + 3 * p1.Y * Math.Pow(1 - t, 2) * t + 3 * p2.Y * (1 - t) * Math.Pow(t, 2) + p3.Y * Math.Pow(t, 3);
            return new Point((int)x,  (int)y);
        }

        void drawBezierOfFourPoint(Point p0, Point p1, Point p2, Point p3)
        {
            double t = 0.0;
            for (int q = 0; q<= 1000; q++)
            {

                Point cur = getPointOf4(p0, p1, p2, p3, t);
                g.DrawEllipse(new Pen(Color.Black), cur.X, cur.Y, 1, 1);
                t += 0.001;
            }
        }

        Point getPointOf3(Point p0, Point p1, Point p2, double t)
        {
            double x = p0.X * Math.Pow(1 - t, 2) + 2 * p1.X * (1 - t) * t + p2.X * Math.Pow(t, 2);
            double y = p0.Y * Math.Pow(1 - t, 2) + 2 * p1.Y * (1 - t) * t + p2.Y * Math.Pow(t, 2);
            return new Point((int)x, (int)y);
        }

        void drawBezierOfThreePoint(Point p0, Point p1, Point p2)
        {
            double t = 0.0;
            for (int q = 0; q <= 1000; q++)
            {

                Point cur = getPointOf3(p0, p1, p2, t);
                g.DrawEllipse(new Pen(Color.Black), cur.X, cur.Y, 1, 1);
                t += 0.001;
            }
        }
    }
}