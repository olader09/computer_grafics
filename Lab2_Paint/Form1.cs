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
            this.Work.Items.AddRange(new object[] { "Floodfill", "Flood fill ps", "Draw line by Wu", "Gradient", "Draw by mouse", "Draw line by Bresenham", "Border" });
            // Заполняем белым цветом при загрузке
            picture = new Bitmap(Canvas.Width, Canvas.Height);
            for (int i = 0; i < Canvas.Width; ++i)
                for (int j = 0; j < Canvas.Height; ++j)
                    picture.SetPixel(i, j, Color.White);
            Canvas.SizeMode = PictureBoxSizeMode.StretchImage;
            Canvas.Image = picture;
//<<<<<<< HEAD
            
//=======
            // this.listBox1.Items.AddRange(new object[] { "Floodfill", "Flood fill ps", "Draw line by Wu", "Gradient", "Draw by mouse", "Draw line by Bresenham" }); 
//>>>>>>> cf89474c81055212a31ac223756f6308ea769d07
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
                    picture.SetPixel(cur, pix_y, b.GetPixel(((b.Width / 2 - (cur - x)) % b.Width + b.Width) % b.Width, (((b.Height / 2 - (y - pix_y)) % b.Height) + b.Height) % b.Height));
                    q.Enqueue((cur, pix_y - 1));
                    q.Enqueue((cur, pix_y + 1));
                }
                for (int cur = pix_x + 1; cur < picture.Width && picture.GetPixel(cur, pix_y) == col; ++cur)
                {
                    picture.SetPixel(cur, pix_y, b.GetPixel(((b.Width / 2 - (cur - x)) % b.Width + b.Width) % b.Width, (((b.Height / 2 - (y - pix_y)) % b.Height) + b.Height) % b.Height));
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
        /*
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
        }*/

        // При выборе режима поведение при нажатии на картинку меняется
        private void Work_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Work.SelectedIndex)
            {
                // ======================================================
                case 0: // FloodFill
                        // ======================================================
                    Canvas.MouseUp += null;
                    Canvas.MouseDown += null;
                    Canvas.MouseClick += null;
                    label2.Text = string.Join("", Work.SelectedIndex);
                    // При клике на точку должна происходить заливка области
                    Canvas.MouseDown += new MouseEventHandler( FloodFill);
                    break;
                // ======================================================
                case 1: // Floodfill with picture
                        // ======================================================
                        // То же самое что и  Flood fill, но закрашиваются пиксели
                        // Цветовое расстояние от которых меньше заданного в delta
                        Canvas.MouseDown += null;
                        Canvas.MouseDown += FloodFillImage;
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
                        int x1_ = 0, y1_ = 1, x2_ = 0, y2_ = 2, x3_ = 0, y3_ = 3;
                        Color c1_ = Color.FromArgb(1, 2, 3), c2_ = Color.FromArgb(4, 5, 6), c3_ = Color.FromArgb(7, 8, 9);
                        bool firstPoint = true, secondPoint = false, thirdPoint = false; // для рисования мышью

                        void swap(ref int x, ref int y)
                        {
                            int a = x;
                            x = y;
                            y = a;
                        }

                        void drawGradient(int x1, int y1, Color c1, int x2, int y2, Color c2, int x3, int y3, Color c3)
                        {

                            if (y1 < y2) // в решении вторая точка всегда верхняя, поэтому делаем её такой по оси y //
                            {                                                                                       //
                                swap(ref x2, ref x1);                                                               //
                                swap(ref y2, ref y1);                                                               //
                                                                                                                    //
                                int q1 = c1.R, q2 = c1.G, q3 = c1.B;                                                //
                                c1 = Color.FromArgb(c2.R, c2.G, c2.B);                                              //
                                c2 = Color.FromArgb(q1, q2, q3);                                                    //
                                                                                                                    //
                            }                                                                                       //  
                                                                                                                    //  
                            if (y3 < y2)                                                                            //
                            {                                                                                       //
                                swap(ref x2, ref x3);                                                               //
                                swap(ref y2, ref y3);                                                               //
                                                                                                                    //
                                int q1 = c2.R, q2 = c2.G, q3 = c2.B;                                                //
                                c2 = Color.FromArgb(c3.R, c3.G, c3.B);                                              //
                                c3 = Color.FromArgb(q1, q2, q3);                                                    //
                            }                                                                                       //

                            if (x1 > x3)
                            {
                                swap(ref x1, ref x3);
                                swap(ref y1, ref y3);

                                int q1 = c1.R, q2 = c1.G, q3 = c1.B;
                                c1 = Color.FromArgb(c3.R, c3.G, c3.B);
                                c3 = Color.FromArgb(q1, q2, q3);
                            }

                            if (y1 < y3)
                            {
                                Tuple<int,int,int> p = drawGradientUpToDown1(x1, y1, c1, x2, y2, c2, x3, y3, c3);
                                
                                float x_new = x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2);

                                int red_new = (c2.R + c3.R) * (y1 - y2) / (y3 - y2);
                                int green_new = (c2.G + c3.G) * (y1 - y2) / (y3 - y2);
                                int blue_new = (c2.B + c3.B) * (y1 - y2) / (y3 - y2);

                                if (red_new > 255)   // ну, не без этого
                                    red_new = 255;
                                if (green_new > 255)
                                    green_new = 255;
                                if (blue_new > 255)
                                    blue_new = 255;
                                if (red_new < 0)
                                    red_new = 0;
                                if (green_new < 0)
                                    green_new = 0;
                                if (blue_new < 0)
                                    blue_new = 0;

                                //Color c_new = Color.FromArgb(red_new, green_new, blue_new);
                                Color c_new = Color.FromArgb(p.Item1, p.Item2, p.Item3);

                                drawGradientUpToDown(x1, y1, c1, x2, y2, c2, (int)x_new, y1, c_new);

                                drawGradientDownToUp(x1, y1, c1, x3, y3, c3, (int)x_new, y1, c_new);
                                
                            }
                            
                            else
                            {
                                float x_new = x2 - (x2 - x1) * (y3 - y2) / (float)(y1 - y2);
                                Tuple<int,int,int> p = drawGradientUpToDown1(x1, y1, c1, x2, y2, c2, x3, y3, c3);
                                int red_new = (c2.R + c1.R) * (y3 - y2) / (y1 - y2);
                                int green_new = (c2.G + c1.G) * (y3 - y2) / (y1 - y2);
                                int blue_new = (c2.B + c1.B) * (y3 - y2) / (y1 - y2);

                                Color c_new = Color.FromArgb(p.Item1, p.Item2, p.Item3);
                                //Color c_new = Color.FromArgb(red_new, green_new, blue_new);
                                if (red_new > 255)   // ну, не без этого
                                    red_new = 255;
                                if (green_new > 255)
                                    green_new = 255;
                                if (blue_new > 255)
                                    blue_new = 255;
                                if (red_new < 0)
                                    red_new = 0;
                                if (green_new < 0)
                                    green_new = 0;
                                if (blue_new < 0)
                                    blue_new = 0;

                                drawGradientUpToDown((int)x_new, y3, c_new, x2, y2, c2, x3, y3, c3);
                                drawGradientDownToUp((int)x_new, y3, c_new, x1, y1, c1, x3, y3, c3);
                            }
                        }
                        /////////
                        // **********
                        void drawGradientUpToDown(int x1, int y1, Color c1, int x2, int y2, Color c2, int x3, int y3, Color c3)
                        {
                            int i = 0; // каждый пиксель по оси у
                            int j = 0; // каждый пиксель по оси х, когда рисуем прямые

                            int r1_begin = c1.R; // начальные цвета
                            int g1_begin = c1.G;
                            int b1_begin = c1.B;

                            int r2_begin = c2.R;
                            int g2_begin = c2.G;
                            int b2_begin = c2.B;

                            int r3_begin = c3.R;
                            int g3_begin = c3.G;
                            int b3_begin = c3.B;

                            
                            if (y1 == y2)
                                y1++;
                            if (y1 == y3)
                                y3++;
                            if (y2 == y3)
                                y2++;


                            int color_right_red = 0;  // цвет правой точки
                            int color_right_green = 0;
                            int color_right_blue = 0;

                            for (int y = y2; y < y3; y++)
                            {

                                i++;
                                
                                int xleft = x2 - (x2 - x1) * i / (y3 - y2); // левая точка текущей прямой
                                int deltax = i * (x3 - x1) / (y3 - y2);     // длина текущей прямой

                                int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y1 - y2)); // цвет левой точки
                                int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y1 - y2));
                                int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y1 - y2));

                                color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - y2));  // цвет правой точки
                                color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - y2));
                                color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - y2));

                                j = 0;


                                for (int x = xleft; x < xleft + deltax ; x++)
                                {
                                    j++;
                                    int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));    // текущие цвета
                                    int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                                    int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));
                                    
                                    if (red_cur > 255)   // ну, не без этого
                                        red_cur = 255;
                                    if (green_cur > 255)
                                        green_cur = 255;
                                    if (blue_cur > 255)
                                        blue_cur = 255;
                                    if (red_cur < 0)
                                        red_cur = 0;
                                    if (green_cur < 0)
                                        green_cur = 0;
                                    if (blue_cur < 0)
                                        blue_cur = 0;

                                    Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                                    if (x < 0)
                                        picture.SetPixel(1, y, cur_color);
                                    else
                                        picture.SetPixel(x, y, cur_color);
                                    Canvas.Image = picture;

                                }
                                //if (y == y1)
                                  // break;

                            }
                            

                        }
                        // **********------
                        Tuple<int,int,int> drawGradientUpToDown1(int x1, int y1, Color c1, int x2, int y2, Color c2, int x3, int y3, Color c3)
                        {
                            int i = 0; // каждый пиксель по оси у
                            int j = 0; // каждый пиксель по оси х, когда рисуем прямые

                            int r1_begin = c1.R; // начальные цвета
                            int g1_begin = c1.G;
                            int b1_begin = c1.B;

                            int r2_begin = c2.R;
                            int g2_begin = c2.G;
                            int b2_begin = c2.B;

                            int r3_begin = c3.R;
                            int g3_begin = c3.G;
                            int b3_begin = c3.B;

                            
                            if (y1 == y2)
                                y1++;
                            if (y1 == y3)
                                y3++;
                            if (y2 == y3)
                                y2++;


                            int color_right_red = 0;  // цвет правой точки
                            int color_right_green = 0;
                            int color_right_blue = 0;

                            for (int y = y2; y < y3; y++)
                            {

                                i++;
                                float x_new_ = x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2);
                                int xleft = x2 - (x2 - x1) * i / (y3 - y2); // левая точка текущей прямой
                                int deltax = i * (x3 - x1) / (y3 - y2);     // длина текущей прямой

                                int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y1 - y2)); // цвет левой точки
                                int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y1 - y2));
                                int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y1 - y2));

                                color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - y2));  // цвет правой точки
                                color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - y2));
                                color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - y2));

                                j = 0;


                                for (int x = xleft; x < xleft + deltax; x++)
                                {
                                    j++;
                                    int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));    // текущие цвета
                                    int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                                    int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));

                                    if (red_cur > 255)   // ну, не без этого
                                        red_cur = 255;
                                    if (green_cur > 255)
                                        green_cur = 255;
                                    if (blue_cur > 255)
                                        blue_cur = 255;
                                    if (red_cur < 0)
                                        red_cur = 0;
                                    if (green_cur < 0)
                                        green_cur = 0;
                                    if (blue_cur < 0)
                                        blue_cur = 0;

                                    Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                                    if (x < 0)
                                        picture.SetPixel(1, y, cur_color);
                                    else
                                        picture.SetPixel(x, y, cur_color);
                                    Canvas.Image = picture;

                                }
                                if (y == y1)
                                    break;

                            }
                            //drawGradientDownToUp(x1, y1, c1, x3, y3, c3, (int)x_new, y1, c_new);
                            //x3 = ((int)(x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2)));
                            //float x_new = x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2);
                            Color c_new = Color.FromArgb(color_right_red, color_right_green, color_right_blue);
                            return Tuple.Create(color_right_red, color_right_green, color_right_blue);

                        }
                        //-------------
                        void drawGradientDownToUp(int x1, int y1, Color c1, int x2, int y2, Color c2, int x3, int y3, Color c3)
                        {
                            int i = 0;
                            int j = 0;

                            int r1_begin = c1.R;
                            int g1_begin = c1.G;
                            int b1_begin = c1.B;

                            int r2_begin = c2.R;
                            int g2_begin = c2.G;
                            int b2_begin = c2.B;

                            int r3_begin = c3.R;
                            int g3_begin = c3.G;
                            int b3_begin = c3.B;

                            if (y1 == y2)
                                y1++;
                            if (y1 == y3)
                                y3++;
                            if (y2 == y3)
                                y3++;

                            for (int y = y2; y >= y3; y--)
                            {
                                i++;
                                int xleft = x2 - (x2 - x1) * i / (y2 - y3);
                                int deltax = i * (x3 - x1) / (y2 - y3);

                                int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y2 - y1));
                                int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y2 - y1));
                                int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y2 - y1));

                                int color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y2 - y3));
                                int color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y2 - y3));
                                int color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y2 - y3));

                                j = 0;

                                for (int x = xleft; x < xleft + deltax; x++)
                                {
                                    j++;
                                    int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));
                                    int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                                    int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));

                                    if (red_cur > 255)
                                        red_cur = 255;
                                    if (green_cur > 255)
                                        green_cur = 255;
                                    if (blue_cur > 255)
                                        blue_cur = 255;

                                    if (red_cur < 0)
                                        red_cur = 0;
                                    if (green_cur < 0)
                                        green_cur = 0;
                                    if (blue_cur < 0)
                                        blue_cur = 0;


                                    Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                                    if (x < 0)
                                        picture.SetPixel(1, y, cur_color);
                                    else
                                        picture.SetPixel(x, y, cur_color);
                                    Canvas.Image = picture;
                                }
                            }
                        }

                        Canvas.MouseDown += (object send, MouseEventArgs ev) =>
                        {
                            if (firstPoint)
                            {
                                x1_ = ev.X;
                                y1_ = ev.Y;
                                c1_ = SelectedColor;

                                firstPoint = false;
                                secondPoint = true;

                            }
                            else if (secondPoint)
                            {
                                x2_ = ev.X;
                                y2_ = ev.Y;
                                c2_ = SelectedColor;

                                secondPoint = false;
                                thirdPoint = true;
                            }
                            else if (thirdPoint)
                            {
                                x3_ = ev.X;
                                y3_ = ev.Y;
                                c3_ = SelectedColor;

                                thirdPoint = false;
                                firstPoint = true;

                                drawGradient(x1_, y1_, c1_, x2_, y2_, c2_, x3_, y3_, c3_);

                            }
                        };


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

                            int err = dx / 2;
                            int ystep = (y0 < y1) ? 1 : -1;
                            int y = y0;

                            for (int x = x0; x <= x1; x++)
                            {
                                if (st)
                                    plot_(y, x);
                                else
                                    plot_(x, y);
                                err -= dy;
                                if (err < 0)
                                {
                                    y += ystep;
                                    err += dx;
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

                case 6:
                    Canvas.MouseDown += new MouseEventHandler(
                        (o, ev) =>
                        {
                            int x = ev.X, y = ev.Y;
                            Color col = picture.GetPixel(x, y);
                            // Если это уже нужный цвет то выходим
                            if (col == SelectedColor)
                                return;

                            
                            while (picture.GetPixel(x, y) == col && ((x + 1 < picture.Width && picture.GetPixel(x + 1, y) == col)
                                       && (x - 1 >= 0 && picture.GetPixel(x - 1, y) == col)
                                       && (y + 1 < picture.Height && picture.GetPixel(x, y + 1) == col)
                                       && (y - 1 >= 0 && picture.GetPixel(x, y - 1) == col)))
                                    
                                { ++x; }

                            Console.WriteLine("Border: " + x + " " + y);
                            // return; 

                            List<(int, int)> Points = new List<(int, int)>();
                            Stack<(int, int)> st = new Stack<(int, int)>();

                            do
                            {
                                //System.Threading.Thread.Sleep(10);
                                // Console.WriteLine(x + " " + y);
                                Points.Add((x, y));
                                st.Push((x, y));
                            check:
                                if (CheckPoint(x - 1, y, col, Points))
                                    --x;
                                else if (CheckPoint(x, y - 1, col, Points))
                                    --y;
                                else if (CheckPoint(x + 1, y, col, Points))
                                    ++x;
                                else if (CheckPoint(x, y + 1, col, Points))
                                    ++y;
                                else if (CheckPoint(x + 1, y + 1, col, Points))
                                { ++x; ++y; }
                                else if (CheckPoint(x - 1, y - 1, col, Points))
                                { --x; --y; }
                                else if (CheckPoint(x + 1, y - 1, col, Points))
                                { ++x; --y; }
                                else if (CheckPoint(x - 1, y + 1, col, Points))
                                { --x; ++y; }
                                else if (st.Count != 0)
                                {
                                    (x, y) = st.Pop();
                                    goto check;
                                }
                                else break;  
                            } while (true);

                            foreach (var p in Points)
                                picture.SetPixel(p.Item1, p.Item2, SelectedColor);

                            // Выводим полученное изображение
                            Canvas.Image = picture;
                        });
                    break; 
            }
        }

        private bool CheckPoint(int x, int y, Color col, List<(int, int)> l)
        {
           return picture.GetPixel(x, y) == col && !l.Contains((x, y)) && ((x + 1 < picture.Width && picture.GetPixel(x + 1, y) != col)
                                       || (x - 1 >= 0 && picture.GetPixel(x - 1, y) != col)
                                       || (y + 1 < picture.Height && picture.GetPixel(x, y + 1) != col)
                                       || (y - 1 >= 0 && picture.GetPixel(x, y - 1) != col));
                                    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            RadioButton btn = sender as RadioButton;
            if (btn != null && btn.Checked)
            {
                switch(btn.Name)
                {
                    case "radioButton1":
                        Canvas.MouseClick += FloodFill;
                        break;
                    case "radioButton2":
                        Canvas.MouseClick += FloodFill;
                        break;

                }
            }
            */
        }
//<<<<<<< HEAD
        
    
        
//=======

//>>>>>>> cf89474c81055212a31ac223756f6308ea769d07
    }
}

