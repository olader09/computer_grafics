using System;
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
        // Цвет, которым будем рисовать, задается при нажатии на Choose Color
        Color SelectedColor;
        // Картинка для рисования на Canvas
        Bitmap picture;

        public Form1()
        {
            InitializeComponent();
            this.Work.Items.AddRange(new object[] { "Floodfill", "Flood fill ps", "Draw line by Wu", "Gradient", "Draw by mouse", "Draw line by Bresenham" });
            // Заполняем белым цветом при загрузке
            picture = new Bitmap(Canvas.Width, Canvas.Height);
            for (int i = 0; i < Canvas.Width; ++i)
                for (int j = 0; j < Canvas.Height; ++j)
                    picture.SetPixel(i, j, Color.White);
            Canvas.SizeMode = PictureBoxSizeMode.StretchImage;
            Canvas.Image = picture;
        }

        // Диалог выбора цвета
        private void ColorButton_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.ShowDialog(); 
            SelectedColor = cd.Color;
        }

        // Диалог загрузки картинки для заливки
        private void BrouseButton_Click(object sender, EventArgs e)
        {
            FFImage.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                var p = new Bitmap(open.FileName);
                FFImage.Image = p;
                FFImageName.Text = open.FileName;
            }
        }

        // Цветовое расстояние, используется в Flood fill ps
        private double ColorDistance(Color c1, Color c2)
        {
            return Math.Sqrt((c1.R - c2.R)*(c1.R - c2.R) + (c1.G - c2.G)*(c1.G - c2.G) + (c1.B - c2.B)*(c1.B - c2.B));
        }

        private void FloodFill(object send, MouseEventArgs ev)
        {
            int x = ev.X, y = ev.Y;

            // Заливать будем все пиксели этого цвета
            Color col = picture.GetPixel(x, y);
            // Если это уже нужный цвет то выходим
            if (col == SelectedColor)
                return;

            // Очередь пикселейй для закраски (исправить)
            // TODO: 
            // Сделать закраску по линиям
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((x, y));
            while (q.Count > 0)
            {
                int pix_x, pix_y;
                (pix_x, pix_y) = q.Dequeue();
                if (pix_y < 0 || pix_y >= picture.Height || picture.GetPixel(pix_x, pix_y) != col)
                    continue;
                for (int cur = pix_x; cur > 0 && picture.GetPixel(cur, pix_y) == col; --cur)
                {
                    picture.SetPixel(cur, pix_y, SelectedColor);
                    q.Enqueue((cur, pix_y - 1));
                    q.Enqueue((cur, pix_y + 1));
                }
                for (int cur = pix_x + 1; cur < picture.Width && picture.GetPixel(cur, pix_y) == col; ++cur)
                {
                    picture.SetPixel(cur, pix_y, SelectedColor);
                    q.Enqueue((cur, pix_y - 1));
                    q.Enqueue((cur, pix_y + 1));
                }
                /*if (pix_x - 1 > 0 && picture.GetPixel(pix_x - 1, pix_y) == col)
                    q.Enqueue((pix_x - 1, pix_y));
                if (pix_x + 1 < picture.Width && picture.GetPixel(pix_x + 1, pix_y) == col)
                    q.Enqueue((pix_x + 1, pix_y));
                if (pix_y - 1 > 0 && picture.GetPixel(pix_x, pix_y - 1) == col)
                    q.Enqueue((pix_x, pix_y - 1));
                if (pix_y + 1 < picture.Height && picture.GetPixel(pix_x, pix_y + 1) == col)
                    q.Enqueue((pix_x, pix_y + 1));
                picture.SetPixel(pix_x, pix_y, SelectedColor);*/
            }


            // Выводим полученное изображение
            Canvas.Image = picture;
        }

        private void FloodFillImage(object send, MouseEventArgs ev)
        {
            int x = ev.X, y = ev.Y;

            // Заливать будем все пиксели этого цвета
            Color col = picture.GetPixel(x, y);
            // Если это уже нужный цвет то выходим
            if (col == SelectedColor)
                return;

            Bitmap b = new Bitmap(FFImageName.Text);
            int bx = 0, by = 0;

            // Очередь пикселейй для закраски (исправить)
            // TODO: 
            // Сделать закраску по линиям
            Queue<(int, int)> q = new Queue<(int, int)>();
            q.Enqueue((x, y));
            while (q.Count > 0)
            {
                int pix_x, pix_y;
                (pix_x, pix_y) = q.Dequeue();
                if (pix_y < 0 || pix_y >= picture.Height || picture.GetPixel(pix_x, pix_y) != col)
                    continue;
                for (int cur = pix_x; cur > 0 && picture.GetPixel(cur, pix_y) == col; --cur)
                {
                    picture.SetPixel(cur, pix_y, b.GetPixel((cur % b.Width + b.Width) % b.Width, (pix_y % b.Height + b.Height) % b.Height));
                    q.Enqueue((cur, pix_y - 1));
                    q.Enqueue((cur, pix_y + 1));
                }
                for (int cur = pix_x + 1; cur < picture.Width && picture.GetPixel(cur, pix_y) == col; ++cur)
                {
                    picture.SetPixel(cur, pix_y, b.GetPixel((cur % b.Width + b.Width) % b.Width, (pix_y % b.Height + b.Height) % b.Height));
                    q.Enqueue((cur, pix_y - 1));
                    q.Enqueue((cur, pix_y + 1));
                }
                /*if (pix_x - 1 > 0 && picture.GetPixel(pix_x - 1, pix_y) == col)
                    q.Enqueue((pix_x - 1, pix_y));
                if (pix_x + 1 < picture.Width && picture.GetPixel(pix_x + 1, pix_y) == col)
                    q.Enqueue((pix_x + 1, pix_y));
                if (pix_y - 1 > 0 && picture.GetPixel(pix_x, pix_y - 1) == col)
                    q.Enqueue((pix_x, pix_y - 1));
                if (pix_y + 1 < picture.Height && picture.GetPixel(pix_x, pix_y + 1) == col)
                    q.Enqueue((pix_x, pix_y + 1));
                picture.SetPixel(pix_x, pix_y, SelectedColor);*/
            }


            // Выводим полученное изображение
            Canvas.Image = picture;
        }

        private (int, int) GetTopLeft(int x, int y)
        {
            Color c = picture.GetPixel(x, y); 

            var to_see = new Queue<(int, int)>();
            var seen = new SortedSet<(int, int)>();

            to_see.Enqueue((x, y)); 
            while (to_see.Count > 0)
            {
                int px, py;
                (px, py) = to_see.Dequeue();
                if (px < x)
                    x = px;
                if (py < y)
                    y = py;

                if (px - 1 > 0 && picture.GetPixel(px - 1, py) == c && !seen.Contains((px - 1, py)) && !to_see.Contains((px - 1, py)))
                    to_see.Enqueue((px - 1, py));
                if (px + 1 < picture.Height && picture.GetPixel(px + 1, py) == c && !seen.Contains((px + 1, py)) && !to_see.Contains((px + 1, py)))
                    to_see.Enqueue((px + 1, py));
                if (py - 1 > 0 && picture.GetPixel(px, py - 1) == c && !seen.Contains((px, py - 1)) && !to_see.Contains((px, py - 1)))
                    to_see.Enqueue((px, py - 1));
                if (py + 1 < picture.Height && picture.GetPixel(px, py + 1) == c && !seen.Contains((px, py + 1)) && !to_see.Contains((px, py + 1)))
                    to_see.Enqueue((px, py + 1));

                seen.Add((px, py));
            }
            return (x, y);
        }

        // При выборе режима поведение при нажатии на картинку меняется
        private void Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Work.SelectedIndex)
            {
                // ======================================================
                case 0: // FloodFill
                        // ======================================================
                        Canvas.MouseDown += null;
                        // При клике на точку должна происходить заливка области
                        Canvas.MouseClick += FloodFill;
                    break;
                // ======================================================
                case 1: // Floodfill with picture
                        // ======================================================
                        // То же самое что и  Flood fill, но закрашиваются пиксели
                        // Цветовое расстояние от которых меньше заданного в delta
                        Canvas.MouseDown += null;
                        Canvas.MouseClick += FloodFillImage;
                        break;
                // ======================================================
                case 2: // Line by Wu
                        // ======================================================
                    {
                        Canvas.MouseClick += null;
                        bool drawSegment = false;
                        int x_0 = 0, y_0 = 0, x_1, y_1;
                        Graphics g = Canvas.CreateGraphics();

                        void swap(ref int a, ref int b)
                        {
                            int c = a;
                            a = b;
                            b = c;
                        }
                        void plot(int x, int y, double c, bool st)
                        {
                            int red = (int)(SelectedColor.R * c);
                            int green = (int)(SelectedColor.G * c);
                            int blue = (int)(SelectedColor.B * c);

                            Color color = Color.FromArgb(red, green, blue);
                            if (st)
                            {
                                swap(ref x, ref y);
                            }

                            picture.SetPixel(x, y, color);
                            Canvas.Image = picture;

                        }

                        void drawPoint(int x0, int y0, int x1, int y1)
                        {
                            var st = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

                            if (st)
                            {
                                swap(ref x0, ref y0);
                                swap(ref x1, ref y1);
                            }

                            if (x0 > x1)
                            {
                                swap(ref x0, ref x1);
                                swap(ref y0, ref y1);
                            }

                            plot(x0, y0, 1, st);
                            plot(x1, y1, 1, st);
                            float dx = x1 - x0, dy = y1 - y0;
                            float gradient = dy / dx;


                            {
                                float y = y0 + gradient;
                                for (int x = x0 + 1; x <= x1 - 1; x++)
                                {
                                    plot(x, (int)y, 1 - (y - (int)y), st);
                                    plot(x, (int)y + 1, y - (int)y, st);
                                    y += gradient;
                                }
                            }
                            /* else
                             {
                                 gradient = Math.Abs(dx / dy);
                                 float x = x0 + gradient;
                                 for (int y = y0 + 1; y <= y1 - 1; y++)
                                 {
                                     plot((int)x, y, 1 - (x - (int)x));
                                     plot((int)x + 1, y, x - (int)x);
                                     x += gradient;
                                 }
                             }*/
                        }

                        Canvas.MouseClick += (object send, MouseEventArgs ev) =>
                        {
                            if (drawSegment)
                            {
                                x_1 = ev.X;
                                y_1 = ev.Y;

                                drawPoint(x_0, y_0, x_1, y_1);

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
                    }
                // ======================================================
                case 3: // Gradient
                        // ======================================================
                    {

                    }
                    break;

                // ======================================================
                case 4: // Draw by mouse
                        // ======================================================
                    {
                        void TurnOnDrawing()
                        {
                            Canvas.MouseMove += (object sendd, MouseEventArgs evv) =>
                            {
                                int xx = (int)((double)evv.X / Canvas.Width * picture.Width),
                                yy = (int)((double)evv.Y / Canvas.Height * picture.Height);
                                picture.SetPixel(xx, yy, SelectedColor);
                                if (xx - 1 > 0)
                                    picture.SetPixel(xx - 1, yy, SelectedColor);
                                if (xx + 1 < picture.Width)
                                    picture.SetPixel(xx + 1, yy, SelectedColor);
                                if (yy - 1 > 0)
                                    picture.SetPixel(xx, yy - 1, SelectedColor);
                                if (yy + 1 < picture.Height)
                                    picture.SetPixel(xx, yy + 1, SelectedColor);
                            };
                        }

                        Canvas.MouseClick += null;

                        Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                            TurnOnDrawing();

                        Canvas.MouseUp += (object send, MouseEventArgs ev) =>
                        {
                            Canvas.MouseMove += null;
                            Canvas.Image = picture;
                        };
                        break;
                    }
                // ======================================================
                case 5: // Brasenham
                        // ======================================================
                    {
                        Canvas.MouseClick += null;
                        bool drawSegment_ = false;
                        int x_0_ = 0, y_0_ = 0, x_1_, y_1_;
                        //g = Canvas.CreateGraphics();

                        void swap_(ref int a, ref int b)
                        {
                            int c = a;
                            a = b;
                            b = c;
                        }
                        Graphics g = Canvas.CreateGraphics();
                        void plot_(int x, int y)
                        {
                            Color color = SelectedColor;
                            g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                            //picture.SetPixel(x, y, color);
                            //Canvas.Image = picture;
                        }

                        void drawPoint_(int x0, int y0, int x1, int y1)
                        {
                            var st = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

                            if (st)
                            {
                                swap_(ref x0, ref y0);
                                swap_(ref x1, ref y1);
                            }

                            if (x0 > x1)
                            {
                                swap_(ref x0, ref x1);
                                swap_(ref y0, ref y1);
                            }

                            int dx = x1 - x0;
                            int dy = Math.Abs(y1 - y0);
                            int error = dx / 2;
                            int ystep = (y0 < y1) ? 1 : -1;
                            int y = y0;
                            for (int x = x0; x <= x1; x++)
                            {
                                plot_(st ? y : x, st ? x : y);
                                error -= dy;
                                if (error < 0)
                                {
                                    y += ystep;
                                    error += dx;
                                }
                            }
                        }

                        Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                        {
                            if (drawSegment_)
                            {
                                x_1_ = ev.X;
                                y_1_ = ev.Y;

                                drawPoint_(x_0_, y_0_, x_1_, y_1_);

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
}

