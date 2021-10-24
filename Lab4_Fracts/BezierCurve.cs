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
        Point p0 = new Point(0, 0), 
              p1 = new Point(0, 0), 
              p2 = new Point(0, 0), 
              p3 = new Point(0, 0);
        private Button button1;
        int j = 0;
        bool isDraw = false;

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

            switch (j)
            {
                case 0:
                    {
                        p0 = new Point(ev.X, ev.Y);
                        g.DrawEllipse(new Pen(Color.Black), p0.X - 3, p0.Y - 3, 6, 6);
                        j++;
                        break;
                    }
                case 1:
                    {
                        p1 = new Point(ev.X, ev.Y);
                        g.DrawEllipse(new Pen(Color.Black), p1.X - 3, p1.Y - 3, 6, 6);
                        g.DrawLine(new Pen(Color.Black), p0, p1);
                        j++;
                        break;
                    }
                case 2:
                    {
                        p2 = new Point(ev.X, ev.Y);
                        g.DrawEllipse(new Pen(Color.Black), p2.X - 3, p2.Y - 3, 6, 6);
                        g.DrawLine(new Pen(Color.Black), p1, p2);
                        j++;
                        break;
                    }
                case 3:
                    {
                        p3 = new Point(ev.X, ev.Y);
                        g.DrawEllipse(new Pen(Color.Black), p3.X - 3, p3.Y - 3, 6, 6);
                        g.DrawLine(new Pen(Color.Black), p2, p3);
                        j++;

                        double q = 0.0;
                        for (int t = 0; t <= 1000; t++)
                        {

                            Point cur = getPoint(p0, p1, p2, p3, q);
                            g.DrawEllipse(new Pen(Color.Black), cur.X, cur.Y, 1, 1);
                            q += 0.001;
                        }
                        break;
                    }
                case 4:
                    {
                        if (Math.Abs(p0.X - ev.X) < 50 && Math.Abs(p0.Y - ev.Y) < 50)
                        {
                            isDraw = true;
                        }
                        break;
                    }

            }
        }

        public PictureBox Main;
        Graphics g;

        

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            j = 0;
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
                g.Clear(DefaultBackColor);

                p0 = new Point(ev.X, ev.Y);

                g.DrawEllipse(new Pen(Color.Black), p0.X - 3, p0.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p1.X - 3, p1.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p2.X - 3, p2.Y - 3, 6, 6);
                g.DrawEllipse(new Pen(Color.Black), p3.X - 3, p3.Y - 3, 6, 6);

                g.DrawLine(new Pen(Color.Black), p0, p1);
                g.DrawLine(new Pen(Color.Black), p1, p2);
                g.DrawLine(new Pen(Color.Black), p2, p3);

                double q = 0.0;
                for (int t = 0; t <= 1000; t++)
                {

                    Point cur = getPoint(p0, p1, p2, p3, q);
                    g.DrawEllipse(new Pen(Color.Black), cur.X, cur.Y, 1, 1);
                    q += 0.001;
                }


                isDraw = false;
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

        Point getPoint(Point p0, Point p1, Point p2, Point p3, double t)
        {
            double x = p0.X * Math.Pow(1 - t, 3) + 3 * p1.X * Math.Pow(1 - t, 2) * t + 3 * p2.X * (1 - t) * Math.Pow(t, 2) + p3.X * Math.Pow(t, 3);
            double y = p0.Y * Math.Pow(1 - t, 3) + 3 * p1.Y * Math.Pow(1 - t, 2) * t + 3 * p2.Y * (1 - t) * Math.Pow(t, 2) + p3.Y * Math.Pow(t, 3);
            return new Point((int)x,  (int)y);
        }
     
    }
}