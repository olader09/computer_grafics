﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Paint
{
    public partial class Form1 : Form
    {
        Color SelectedColor;
        Bitmap picture;
        bool drawing;
        System.Threading.Thread drawThread = null;
        System.Threading.Thread showThread = null;

        public Form1()
        {
            InitializeComponent();
            this.Work.Items.AddRange(new object[] { "Floodfill", "Flood fill ps", "Draw line by Wu", "Gradient", "Draw by mouse", "Draw line by Bresenham" });
            picture = new Bitmap(Canvas.Width, Canvas.Height);
            for (int i = 0; i < Canvas.Width; ++i)
                for (int j = 0; j < Canvas.Height; ++j)
                    picture.SetPixel(i, j, Color.White);
            Canvas.SizeMode = PictureBoxSizeMode.StretchImage;
            Canvas.Image = picture;
            drawing = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Canvas_Click(object sender, EventArgs e)
        {

        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.ShowDialog(); 
            SelectedColor = cd.Color;
        }

        private void BrouseButton_Click(object sender, EventArgs e)
        {
            FFImage.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picture = new Bitmap(open.FileName);
                FFImage.Image = picture;
                FFImageName.Text = open.FileName;
            }

            Canvas.Image = picture;
        }

        private double ColorDistance(Color c1, Color c2)
        {
            return Math.Sqrt((c1.R - c2.R)*(c1.R - c2.R) + (c1.G - c2.G)*(c1.G - c2.G) + (c1.B - c2.B)*(c1.B - c2.B));
        }

        private void Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Work.SelectedIndex)
            {
                case 0:

                    Canvas.MouseClick += (object send, MouseEventArgs ev) =>
                    {
                        // using (var fb = new GraphFunc.FastBitmap(picture))
                        {
                            int x = (int)((double)ev.X / Canvas.Width * picture.Width),
                            y = (int)((double)ev.Y / Canvas.Height * picture.Height);
                            Color col = picture.GetPixel(x, y);
                            if (col == SelectedColor)
                                return;
                            Queue<(int, int)> q = new Queue<(int, int)>();
                            q.Enqueue((x, y));
                            while (q.Count != 0)
                            {
                                int pix_x, pix_y;
                                // Console.WriteLine("Before deq: " + q.Count);
                                (pix_x, pix_y) = q.Dequeue();
                                // Console.WriteLine("After deq: " + q.Count);
                                // if (pix_x - 1 < 0 || pix_x + 1 >= picture.Width || pix_y - 1 < 0 || pix_y + 1 >= picture.Height)
                                // continue;
                                if (pix_x - 1 > 0 && picture.GetPixel(pix_x - 1, pix_y) == col)
                                    q.Enqueue((pix_x - 1, pix_y));
                                if (pix_x + 1 < picture.Width && picture.GetPixel(pix_x + 1, pix_y) == col)
                                    q.Enqueue((pix_x + 1, pix_y));
                                if (pix_y - 1 > 0 && picture.GetPixel(pix_x, pix_y - 1) == col)
                                    q.Enqueue((pix_x, pix_y - 1));
                                if (pix_y + 1 < picture.Height && picture.GetPixel(pix_x, pix_y + 1) == col)
                                    q.Enqueue((pix_x, pix_y + 1));
                                picture.SetPixel(pix_x, pix_y, SelectedColor);
                            }
                        }
                        Canvas.Image = picture;
                    };
                    break;

                case 1:
                    Canvas.MouseClick += (object send, MouseEventArgs ev) =>
                    {
                        double delta = 2.3; 
                        // using (var fb = new GraphFunc.FastBitmap(picture))
                        {
                            int x = (int)((double)ev.X / Canvas.Width * picture.Width),
                            y = (int)((double)ev.Y / Canvas.Height * picture.Height);
                            Color col = picture.GetPixel(x, y);
                            if (col == SelectedColor)
                                return;
                            Queue<(int, int)> q = new Queue<(int, int)>();
                            q.Enqueue((x, y));
                            while (q.Count != 0)
                            {
                                int pix_x, pix_y;
                                // Console.WriteLine("Before deq: " + q.Count);
                                (pix_x, pix_y) = q.Dequeue();
                                // Console.WriteLine("After deq: " + q.Count);
                                // if (pix_x - 1 < 0 || pix_x + 1 >= picture.Width || pix_y - 1 < 0 || pix_y + 1 >= picture.Height)
                                // continue;
                                if (pix_x - 1 > 0 && ColorDistance(picture.GetPixel(pix_x - 1, pix_y), col) <= delta)
                                    q.Enqueue((pix_x - 1, pix_y));
                                if (pix_x + 1 < picture.Width && ColorDistance(picture.GetPixel(pix_x + 1, pix_y), col) <= delta)
                                    q.Enqueue((pix_x + 1, pix_y));
                                if (pix_y - 1 > 0 && ColorDistance(picture.GetPixel(pix_x, pix_y - 1), col) <= delta)
                                    q.Enqueue((pix_x, pix_y - 1));
                                if (pix_y + 1 < picture.Height && ColorDistance(picture.GetPixel(pix_x, pix_y + 1), col) <= delta)
                                    q.Enqueue((pix_x, pix_y + 1));
                                picture.SetPixel(pix_x, pix_y, SelectedColor);
                            }
                        }
                        Canvas.Image = picture;
                    };
                    break;

                case 2:
                    Canvas.MouseClick += null;
                    bool drawSegment = false;
                    int x_0 = 0, y_0 = 0, x_1, y_1;
                    Graphics g = Canvas.CreateGraphics();

                    void plot (int x, int y, double c)
                    {
                        int red = (int)(SelectedColor.R * c);
                        int green = (int)(SelectedColor.G * c);
                        int blue = (int)(SelectedColor.B * c);

                        Color color = Color.FromArgb(red,green,blue);
                        picture.SetPixel(x, y, color);
                        Canvas.Image = picture;
                        //g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                    }

                    void drawPoint(int x0, int y0, int x1, int y1)
                    {
                        float dx = x1 - x0, dy = y1 - y0;
                        float gradient = Math.Abs(dy / dx);

                        if (gradient > 0 && gradient <= 1)
                        {
                            float y = y0 + gradient;
                            for (int x = x0 + 1; x <= x1 - 1; x++)
                            {
                                plot(x, (int)y, 1 - (y - (int)y));
                                plot(x, (int)y + 1, y - (int)y);
                                y += gradient;
                            }
                        }
                        else if (gradient > 1)
                        {
                            gradient = dx / dy;
                            float x = x0 + gradient;
                            for (int y = y0 + 1; y <= y1 - 1; y++)
                            {
                                plot((int)x, y, 1 - (x - (int)x));
                                plot((int)x + 1, y, x - (int)x);
                                x += gradient;
                            }
                        }
                    }
                    
                    Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                    {      
                        if (drawSegment)
                        {
                            x_1 = ev.X;
                            y_1 = ev.Y;
                            if (x_1 >= x_0)
                                drawPoint(x_0, y_0, x_1, y_1);
                            else
                                drawPoint(x_1, y_1, x_0, y_0);
                            x_0 = x_1;
                            y_0 = y_1; 
                        }         
                        else
                        {
                            x_0 = ev.X;
                            y_0 = ev.Y;
                            drawSegment = true;
                        }
                    };
                    break;

                case 4:

                    Canvas.MouseClick += null;
                    
                    Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                    {
                        Canvas.MouseMove += (object sendd, MouseEventArgs evv) =>
                        {
                            int xx = (int)((double)evv.X / Canvas.Width * picture.Width),
                            yy = (int)((double)evv.Y / Canvas.Height * picture.Height);
                            picture.SetPixel(xx, yy, SelectedColor);
                            picture.SetPixel(xx - 1, yy, SelectedColor);
                            picture.SetPixel(xx + 1, yy, SelectedColor);
                            picture.SetPixel(xx, yy - 1, SelectedColor);
                            picture.SetPixel(xx, yy + 1, SelectedColor);
                        };
                    };

                    Canvas.MouseUp += (object send, MouseEventArgs ev) =>
                    {
                        Canvas.MouseMove += null; 
                        Canvas.Image = picture;
                    };
                    break;
                    
                case 5:
                    //Canvas.MouseClick += null;
                    bool drawSegment_ = false;
                    int x_0_ = 0, y_0_ = 0, x_1_, y_1_;
                    g = Canvas.CreateGraphics();

                    void plot_(int x, int y)
                    {
                        Color color = SelectedColor;
                        g.FillRectangle(new SolidBrush(color), x, y, 2, 2);
                    }

                    void drawPoint_(int x0, int y0, int x1, int y1)
                    {
                        int deltax = Math.Abs(x1 - x0);
                        int deltay = Math.Abs(y1 - y0);
                        double error = 0;
                        double deltaerr = (deltay + 1) / (deltax + 1);
                        int y = y0;
                        int diry = y1 - y0;
                        if (diry > 0)
                            diry = 1;
                        if (diry < 0)
                            diry = -1;
                        for (int x = x0; x <= x1; x++)
                        {
                            plot_(x, y);
                            error += deltaerr;
                            if (error >= 1.0)
                            {
                                y += diry;
                                error -= 1.0;
                            }
                        }
                    }

                    Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                    {
                        if (drawSegment_)
                        {
                            x_1_ = ev.X;
                            y_1_ = ev.Y;
                            if (x_1_ >= x_0_)
                                drawPoint_(x_0_, y_0_, x_1_, y_1_);
                            else
                                drawPoint_(x_1_, y_1_, x_0_, y_0_);
                            x_0_ = x_1_;
                            y_0_ = y_1_;
                        }
                        else
                        {
                            x_0_ = ev.X;
                            y_0_ = ev.Y;
                            drawSegment_ = true;
                        }
                    };
                    break;
                    
            }
        }
    }
}
