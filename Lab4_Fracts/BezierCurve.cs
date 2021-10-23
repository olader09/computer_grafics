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
        Point p0, p1, p2, p3;
        bool firstPoint = true,
             secondPoint = false,
             thirdPoint = false,
             fourthPoint = false; 

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Main_Click(object sender, EventArgs e)
        {
            drawPoints();
        }

        public PictureBox Main;
        Graphics g;

        private void InitializeComponent()
        {
            this.Main = new System.Windows.Forms.PictureBox();
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
            this.Main.Click += new System.EventHandler(this.Main_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(812, 424);
            this.Controls.Add(this.Main);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main)).EndInit();
            this.ResumeLayout(false);

        }

        Point getPoint(Point p0, Point p1, Point p2, Point p3, double t)
        {
            double x = p0.X * Math.Pow(1 - t, 3) + 3 * p1.X * Math.Pow(1 - t, 2) * t + 3 * p2.X * (1 - t) * Math.Pow(t, 2) + p3.X * Math.Pow(t, 3);
            double y = p0.Y * Math.Pow(1 - t, 3) + 3 * p1.Y * Math.Pow(1 - t, 2) * t + 3 * p2.Y * (1 - t) * Math.Pow(t, 2) + p3.Y * Math.Pow(t, 3);
            return new Point((int)x,  (int)y);
        }
        public void drawPoints()
        {

            Main.MouseDown += (object send, MouseEventArgs ev) =>
            {
                g = Main.CreateGraphics();
                //firstPoint = true;
                if (firstPoint)
                {
                    p0 = new Point(ev.X, ev.Y);

                    g.DrawEllipse(new Pen(Color.Black), p0.X-3, p0.Y-3, 6, 6);

                    secondPoint = true;
                    firstPoint = false;
                }
                else if (secondPoint)
                {
                    p1 = new Point(ev.X, ev.Y);
                    g.DrawEllipse(new Pen(Color.Black), p1.X-3, p1.Y-3, 6, 6);

                    g.DrawLine(new Pen(Color.Black), p0, p1);

                    thirdPoint = true;
                    secondPoint = false;
                }
                else if (thirdPoint)
                {
                    p2 = new Point(ev.X, ev.Y);
                    g.DrawEllipse(new Pen(Color.Black), p2.X-3, p2.Y-3, 6, 6);

                    g.DrawLine(new Pen(Color.Black), p1, p2);

                    fourthPoint = true;
                    thirdPoint = false;
                }
                else if (fourthPoint)
                {
                    p3 = new Point(ev.X, ev.Y);
                    g.DrawEllipse(new Pen(Color.Black), p3.X-3, p3.Y-3, 6, 6);

                    g.DrawLine(new Pen(Color.Black), p2, p3);

                    fourthPoint = false;

                    for (int t = 0; t <= 100; t++)
                    {

                        Point cur = getPoint(p0, p1, p2, p3, t / 100);
                        g.DrawEllipse(new Pen(Color.Black), cur.X, cur.Y, 1, 1);
                    }
                }
            };
        }

        

        
    }
}