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
        private Button button1,
                       button2;

        private bool shift = false;
            //  isDraw = false;

        private List<Point> list = new List<Point>();
        public PictureBox Main;
        private Graphics g;
        private Button DeletePointButton;
        private int selectedIndex = -1;
        private bool delete = false; 

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
            g = Main.CreateGraphics();
            ColoringButton(button1, Color.Red);
        }

        private void DrawBezierWithLines(List<Point> lst)
        {
            switch (lst.Count)
            {
                case 1:
                    {
                        g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                        break;
                    }
                case 2:
                    {
                        g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                        g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                        break;
                    }
                case 3:
                    {
                        g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                        g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                        g.DrawEllipse(new Pen(Color.Black), lst[2].X - 3, lst[2].Y - 3, 6, 6);

                        g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                        g.DrawLine(new Pen(Color.Black), lst[1], lst[2]);

                        drawBezierOfThreePoint(lst[0], lst[1], lst[2]);
                        break;
                    }
                case 4:
                    {
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

        private void DrawSpan(List<Point> lst)
        {
            for (int i = 0; i < lst.Count; ++i)
            {
                g.DrawEllipse(new Pen(Color.Black), lst[i].X - 3, lst[i].Y - 3, 6, 6);
                if (i != lst.Count - 1)
                    g.DrawLine(new Pen(Color.Black), lst[i], lst[i + 1]);
            }
        }

        private void DrawBezierGraph(List<Point> lst)
        {
            g.Clear(DefaultBackColor);
            DrawSpan(lst);
            if (lst.Count < 4)
            {
                DrawBezierWithLines(lst); 
            }
            else
            {
                var new_list = new List<Point>();
                new_list.AddRange(lst);

                int i = 0; 
                while (true)
                {
                    int other = (new_list.Count - 1) - i;
                    if (other == 0)
                        break;
                    else if (other < 3)
                    {
                        for (int j = 0; j < 3 - other; ++j)
                            new_list.Add(new_list[new_list.Count - 1]); 
                    }
                    else if (other == 3)
                    {
                        DrawBezierWithLines(new List<Point>() { new_list[i], new_list[i + 1], new_list[i + 2], new_list[i + 3] });
                        i += 3;
                    }
                    else
                    {
                        new_list.Insert(i + 3, Middle(new_list[i + 2], new_list[i + 3]));
                        DrawBezierWithLines(new List<Point>() { new_list[i], new_list[i + 1], new_list[i + 2], new_list[i + 3] });
                        i += 3;
                    }
                }

                /*
                switch (new_list.Count % 4)
                {
                    case 1:
                        int index = new_list.Count - 2;
                        new_list.Insert(index, Middle(new_list[index - 1], new_list[index])); 
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }*/

                /*
                if (lst.Count % 2 == 0)
                {
                    g.Clear(DefaultBackColor);

                    for (int i = 0; i < lst.Count; i++)
                        g.DrawEllipse(new Pen(Color.Black), lst[i].X - 3, lst[i].Y - 3, 6, 6);
                }
                else
                {
                    for (int i = 0; i + 3 < lst.Count; i += 2)
                    {
                        int r_i_x = (lst[i].X + lst[i + 1].X) / 2;
                        int r_i_y = (lst[i].Y + lst[i + 1].Y) / 2;

                        int r_ii_x = (lst[i + 2].X + lst[i + 3].X) / 2;
                        int r_ii_y = (lst[i + 2].Y + lst[i + 3].Y) / 2;

                        g.DrawLine(new Pen(Color.Black), lst[i], lst[i + 1]);
                        g.DrawLine(new Pen(Color.Black), lst[i + 2], lst[i + 3]);

                        g.DrawEllipse(new Pen(Color.Red), r_i_x - 2, r_i_y - 2, 4, 4);
                        g.DrawEllipse(new Pen(Color.Red), r_ii_x - 2, r_ii_y - 2, 4, 4);

                        g.DrawEllipse(new Pen(Color.Black), lst[lst.Count - 1].X - 3, lst[lst.Count - 1].Y - 3, 6, 6);
                        drawBezierOfFourPoint(new Point(r_i_x, r_i_y), lst[i + 1], lst[i + 2], new Point(r_ii_x, r_ii_y));
                    }
                }*/ 
            }
        }

        private Point Middle(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2); 
        }

        private void Main_Click(object sender, MouseEventArgs ev)
        {
            if (delete)
            {
                for (int i = 0; i < list.Count; i++)
                    if (Math.Abs(list[i].X - ev.X) < 5 && Math.Abs(list[i].Y - ev.Y) < 5)
                    {
                        list.RemoveAt(i);
                        DrawBezierGraph(list);
                        break;
                    }
                return; 
            }

            if (!shift)
            {
                list.Add(new Point(ev.X, ev.Y));
                DrawBezierGraph(list); 
            }
            else
            {
                if (selectedIndex == -1)
                {
                    for (int i = 0; i < list.Count; i++)
                        if (Math.Abs(list[i].X - ev.X) < 5 && Math.Abs(list[i].Y - ev.Y) < 5)
                        {
                            selectedIndex = i;
                            g.DrawEllipse(new Pen(Color.Green), list[i].X - 3, list[i].Y - 3, 6, 6);
                        }
                }
                else
                {
                    list[selectedIndex] = new Point(ev.X, ev.Y);
                    // isDraw = true;
                    selectedIndex = -1;
                    DrawBezierGraph(list); 
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(DefaultBackColor);
            list.Clear();
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            //isDraw = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!shift)
            {
                ColoringButton(button2, Color.Green);
                shift = true;
            }
            else
            {
                button2.BackgroundImage = null;
                button2.ForeColor = Color.Black; 
                shift = false;
            }
        }

        /*
        private void Main_MouseMove(object sender, MouseEventArgs ev)
        {
            while (isDraw)
            {
                if (lst.Count <= 4)
                {
                    switch (lst.Count)
                    {
                        case 1:
                            {
                                g.Clear(DefaultBackColor);

                                g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                                isDraw = false;
                                break;
                            }
                        case 2:
                            {
                                g.Clear(DefaultBackColor);

                                g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);

                                g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                                isDraw = false;
                                break;
                            }
                        case 3:
                            {
                                g.Clear(DefaultBackColor);

                                g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[2].X - 3, lst[2].Y - 3, 6, 6);

                                g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                                g.DrawLine(new Pen(Color.Black), lst[1], lst[2]);

                                drawBezierOfThreePoint(lst[0], lst[1], lst[2]);
                                isDraw = false;
                                break;
                            }
                        case 4:
                            {
                                g.Clear(DefaultBackColor);

                                g.DrawEllipse(new Pen(Color.Black), lst[0].X - 3, lst[0].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[1].X - 3, lst[1].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[2].X - 3, lst[2].Y - 3, 6, 6);
                                g.DrawEllipse(new Pen(Color.Black), lst[3].X - 3, lst[3].Y - 3, 6, 6);

                                g.DrawLine(new Pen(Color.Black), lst[0], lst[1]);
                                g.DrawLine(new Pen(Color.Black), lst[1], lst[2]);
                                g.DrawLine(new Pen(Color.Black), lst[2], lst[3]);

                                drawBezierOfFourPoint(lst[0], lst[1], lst[2], lst[3]);
                                isDraw = false;
                                break;
                            }
                    }
                }
                else
                {
                    if (lst.Count % 2 != 0)
                    {
                        g.Clear(DefaultBackColor);

                        for (int i = 0; i < lst.Count; i++)
                            g.DrawEllipse(new Pen(Color.Black), lst[i].X - 3, lst[i].Y - 3, 6, 6);
                        isDraw = false;
                    }
                    else
                    {
                        g.Clear(DefaultBackColor);
                        for (int i = 0; i + 3 < lst.Count; i += 2)
                        {
                            for (int k = 0; k < lst.Count; k++)
                                g.DrawEllipse(new Pen(Color.Black), lst[k].X - 3, lst[k].Y - 3, 6, 6);

                            int r_i_x = (lst[i].X + lst[i + 1].X) / 2;
                            int r_i_y = (lst[i].Y + lst[i + 1].Y) / 2;

                            int r_ii_x = (lst[i + 2].X + lst[i + 3].X) / 2;
                            int r_ii_y = (lst[i + 2].Y + lst[i + 3].Y) / 2;

                            g.DrawLine(new Pen(Color.Black), lst[i], lst[i + 1]);
                            g.DrawLine(new Pen(Color.Black), lst[i + 2], lst[i + 3]);

                            g.DrawEllipse(new Pen(Color.Red), r_i_x - 2, r_i_y - 2, 4, 4);
                            g.DrawEllipse(new Pen(Color.Red), r_ii_x - 2, r_ii_y - 2, 4, 4);
                            
                            drawBezierOfFourPoint(new Point(r_i_x, r_i_y), lst[i + 1], lst[i + 2], new Point(r_ii_x, r_ii_y));
                        }
                        isDraw = false;
                    }
                }
            }
        }*/

        #region Init and helpfunc
        private void InitializeComponent()
        {
            this.Main = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DeletePointButton = new System.Windows.Forms.Button();
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(698, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Двигать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeletePointButton
            // 
            this.DeletePointButton.Location = new System.Drawing.Point(445, 363);
            this.DeletePointButton.Name = "DeletePointButton";
            this.DeletePointButton.Size = new System.Drawing.Size(105, 40);
            this.DeletePointButton.TabIndex = 3;
            this.DeletePointButton.Text = "Удалить";
            this.DeletePointButton.UseVisualStyleBackColor = true;
            this.DeletePointButton.Click += new System.EventHandler(this.DeletePointButton_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(812, 424);
            this.Controls.Add(this.DeletePointButton);
            this.Controls.Add(this.button2);
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

        private void DeletePointButton_Click(object sender, EventArgs e)
        {
            if (!delete)
            {
                delete = true;
                ColoringButton(DeletePointButton, Color.Red);
            }
            else
            {
                delete = false;
                DeletePointButton.BackgroundImage = null;
                DeletePointButton.ForeColor = Color.Black; 
            }
        }

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
        #endregion
    }
}