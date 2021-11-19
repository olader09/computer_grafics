using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace Lab6And7_Figures3D
{
    public static class Raster
    {
        public static UInt32 ShadeBackgroundPixel(int x, int y, Point p1, Point p2, Point p3, Color A, Color B, Color C)
        {
            UInt32 pixelValue;

            double l1, l2, l3;
            int i;
            pixelValue = 0xFFFFFFFF;

                l1 = ((p2.Y - p3.Y) * ((double)(x) - p3.X) + (p3.X - p2.X) * ((double)(y) - p3.Y)) /
                    ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));
                l2 = ((p3.Y - p1.Y) * ((double)(x) - p3.X) + (p1.X - p3.X) * ((double)(y) - p3.Y)) /
                    ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));
                l3 = 1 - l1 - l2;

                if (l1 >= 0 && l1 <= 1 && l2 >= 0 && l2 <= 1 && l3 >= 0 && l3 <= 1)
                {
                    pixelValue = (UInt32)0xFF000000 |
                        ((UInt32)(l1 * ((A.ToArgb() & 0x00FF0000) >> 16) + l2 * ((B.ToArgb() & 0x00FF0000) >> 16) + l3 * ((C.ToArgb() & 0x00FF0000) >> 16)) << 16) |
                        ((UInt32)(l1 * ((A.ToArgb() & 0x0000FF00) >> 8) + l2 * ((B.ToArgb() & 0x0000FF00) >> 8) + l3 * ((C.ToArgb() & 0x0000FF00) >> 8)) << 8) |
                        (UInt32)(l1 * (A.ToArgb() & 0x000000FF) + l2 * (B.ToArgb() & 0x000000FF) + l3 * (C.ToArgb() & 0x000000FF));
                    
                }
            

            return pixelValue;
        }
        /*
        public static void swap(object x, object y) { var t = x; x = y; y = t; }

        public static List<int> Interpolate(int i0, int d0, int i1, int d1)
        {
            if (i0 == i1) {
                return new() { d0 };
            }
            var values = new List<int>();
            var a = (d1 - d0) / (i1 - i0);
            var d = d0;
            for (int i = i0; i < i1; ++i) {
                values.Add(d);
                d = d + a;
            }
            return values;
        }

        public static void DrawFilledTriangle(Point p0, Point p1, Point p2, Color color)
        {
   // Sort the points so that p0.Y <= p1.Y <= p2.Y
    if (p1.Y < p0.Y) { swap(p1, p0); }
            if (p2.Y < p0.Y) { swap(p2, p0); }
            if (p2.Y < p1.Y) { swap(p2, p1); }

            // Compute the x coordinates of the triangle edges
            var x01 = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
            var x12 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            var x02 = Interpolate(p0.Y, p0.X, p2.Y, p2.X);

   // Concatenate the short sides
    remove_last(p0.p1.X)
    p0.p1.p2.X = p0.p1.X + p1.p2.X

   ❹// Determine which is left and which is right
    m = floor(p0.p1.p2.X.length / 2)
    if p0.p2.X[m] < p0.p1.p2.X[m] {
                x_left = p0.p2.X
        x_right = p0.p1.p2.X
    }
            else
            {
                x_left = p0.p1.p2.X
              x_right = p0.p2.X
          }

   ❺// Draw the horizontal segments
    for y = p0.Y to p2.Y {
                for x = x_left[y - p0.Y] to x_right[y - p0.Y] {
                    canvas.PutPixel(x, y, color)
                }
            }
        }*/
        /*
        public static void Triangle(ref double[,] canvas, Point p1, Point p2, Point p3)
        { 
            int p1.X_ = 0, p1.Y_ = 1, p2.X_ = 0, p2.Y_ = 2, x3_ = 0, y3_ = 3;
            Color c1_ = Color.FromArgb(1, 2, 3), c2_ = Color.FromArgb(4, 5, 6), c3_ = Color.FromArgb(7, 8, 9);
            bool firstPoint = true, secondPoint = false, thirdPoint = false; // для рисования мышью

            void swap(ref int x, ref int y)
            {
                int a = x;
                x = y;
                y = a;
            }

            void drawGradient(int p1.X, int p1.Y, Color c1, int p2.X, int p2.Y, Color c2, int x3, int y3, Color c3)
            {

                if (p1.Y < p2.Y) // в решении вторая точка всегда верхняя, поэтому делаем её такой по оси y //
                {                                                                                       //
                    swap(ref p2.X, ref p1.X);                                                               //
                    swap(ref p2.Y, ref p1.Y);                                                               //
                                                                                                        //
                    int q1 = c1.R, q2 = c1.G, q3 = c1.B;                                                //
                    c1 = Color.FromArgb(c2.R, c2.G, c2.B);                                              //
                    c2 = Color.FromArgb(q1, q2, q3);                                                    //
                                                                                                        //
                }                                                                                       //  
                                                                                                        //  
                if (y3 < p2.Y)                                                                            //
                {                                                                                       //
                    swap(ref p2.X, ref x3);                                                               //
                    swap(ref p2.Y, ref y3);                                                               //
                                                                                                        //
                    int q1 = c2.R, q2 = c2.G, q3 = c2.B;                                                //
                    c2 = Color.FromArgb(c3.R, c3.G, c3.B);                                              //
                    c3 = Color.FromArgb(q1, q2, q3);                                                    //
                }                                                                                       //

                if (p1.X > x3)
                {
                    swap(ref p1.X, ref x3);
                    swap(ref p1.Y, ref y3);

                    int q1 = c1.R, q2 = c1.G, q3 = c1.B;
                    c1 = Color.FromArgb(c3.R, c3.G, c3.B);
                    c3 = Color.FromArgb(q1, q2, q3);
                }

                if (p1.Y < y3)
                {
                    Tuple<int, int, int> p = drawGradientUpToDown1(p1.X, p1.Y, c1, p2.X, p2.Y, c2, x3, y3, c3);

                    float x_new = p2.X + (x3 - p2.X) * (p1.Y - p2.Y) / (float)(y3 - p2.Y);

                    int red_new = (c2.R + c3.R) * (p1.Y - p2.Y) / (y3 - p2.Y);
                    int green_new = (c2.G + c3.G) * (p1.Y - p2.Y) / (y3 - p2.Y);
                    int blue_new = (c2.B + c3.B) * (p1.Y - p2.Y) / (y3 - p2.Y);

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

                    drawGradientUpToDown(p1.X, p1.Y, c1, p2.X, p2.Y, c2, (int)x_new, p1.Y, c_new);

                    drawGradientDownToUp(p1.X, p1.Y, c1, x3, y3, c3, (int)x_new, p1.Y, c_new);

                }

                else
                {
                    float x_new = p2.X - (p2.X - p1.X) * (y3 - p2.Y) / (float)(p1.Y - p2.Y);
                    Tuple<int, int, int> p = drawGradientUpToDown1(p1.X, p1.Y, c1, p2.X, p2.Y, c2, x3, y3, c3);
                    int red_new = (c2.R + c1.R) * (y3 - p2.Y) / (p1.Y - p2.Y);
                    int green_new = (c2.G + c1.G) * (y3 - p2.Y) / (p1.Y - p2.Y);
                    int blue_new = (c2.B + c1.B) * (y3 - p2.Y) / (p1.Y - p2.Y);

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

                    drawGradientUpToDown((int)x_new, y3, c_new, p2.X, p2.Y, c2, x3, y3, c3);
                    drawGradientDownToUp((int)x_new, y3, c_new, p1.X, p1.Y, c1, x3, y3, c3);
                }
            }
            /////////
            // **********
            void drawGradientUpToDown(int p1.X, int p1.Y, Color c1, int p2.X, int p2.Y, Color c2, int x3, int y3, Color c3)
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


                if (p1.Y == p2.Y)
                    p1.Y++;
                if (p1.Y == y3)
                    y3++;
                if (p2.Y == y3)
                    p2.Y++;


                int color_right_red = 0;  // цвет правой точки
                int color_right_green = 0;
                int color_right_blue = 0;

                for (int y = p2.Y; y < y3; y++)
                {

                    i++;

                    int xleft = p2.X - (p2.X - p1.X) * i / (y3 - p2.Y); // левая точка текущей прямой
                    int deltax = i * (x3 - p1.X) / (y3 - p2.Y);     // длина текущей прямой

                    int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (p1.Y - p2.Y)); // цвет левой точки
                    int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (p1.Y - p2.Y));
                    int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (p1.Y - p2.Y));

                    color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - p2.Y));  // цвет правой точки
                    color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - p2.Y));
                    color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - p2.Y));

                    j = 0;


                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - p1.X));    // текущие цвета
                        int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - p1.X));
                        int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - p1.X));

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
                            canvas[1, y] = cur_color;
                        else
                            canvas[x, y] = cur_color;

                    }
                    //if (y == p1.Y)
                    // break;

                }


            }
            // **********------
            Tuple<int, int, int> drawGradientUpToDown1(int p1.X, int p1.Y, Color c1, int p2.X, int p2.Y, Color c2, int x3, int y3, Color c3)
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


                if (p1.Y == p2.Y)
                    p1.Y++;
                if (p1.Y == y3)
                    y3++;
                if (p2.Y == y3)
                    p2.Y++;


                int color_right_red = 0;  // цвет правой точки
                int color_right_green = 0;
                int color_right_blue = 0;

                for (int y = p2.Y; y < y3; y++)
                {

                    i++;
                    float x_new_ = p2.X + (x3 - p2.X) * (p1.Y - p2.Y) / (float)(y3 - p2.Y);
                    int xleft = p2.X - (p2.X - p1.X) * i / (y3 - p2.Y); // левая точка текущей прямой
                    int deltax = i * (x3 - p1.X) / (y3 - p2.Y);     // длина текущей прямой

                    int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (p1.Y - p2.Y)); // цвет левой точки
                    int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (p1.Y - p2.Y));
                    int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (p1.Y - p2.Y));

                    color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - p2.Y));  // цвет правой точки
                    color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - p2.Y));
                    color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - p2.Y));

                    j = 0;


                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - p1.X));    // текущие цвета
                        int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - p1.X));
                        int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - p1.X));

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
                            canvas[1, y] = cur_color;
                        else
                            canvas[x, y] = cur_color;

                    }
                    if (y == p1.Y)
                        break;

                }
                //drawGradientDownToUp(p1.X, p1.Y, c1, x3, y3, c3, (int)x_new, p1.Y, c_new);
                //x3 = ((int)(p2.X + (x3 - p2.X) * (p1.Y - p2.Y) / (float)(y3 - p2.Y)));
                //float x_new = p2.X + (x3 - p2.X) * (p1.Y - p2.Y) / (float)(y3 - p2.Y);
                Color c_new = Color.FromArgb(color_right_red, color_right_green, color_right_blue);
                return Tuple.Create(color_right_red, color_right_green, color_right_blue);

            }
            //-------------
            void drawGradientDownToUp(int p1.X, int p1.Y, Color c1, int p2.X, int p2.Y, Color c2, int x3, int y3, Color c3)
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

                if (p1.Y == p2.Y)
                    p1.Y++;
                if (p1.Y == y3)
                    y3++;
                if (p2.Y == y3)
                    y3++;

                for (int y = p2.Y; y >= y3; y--)
                {
                    i++;
                    int xleft = p2.X - (p2.X - p1.X) * i / (p2.Y - y3);
                    int deltax = i * (x3 - p1.X) / (p2.Y - y3);

                    int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (p2.Y - p1.Y));
                    int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (p2.Y - p1.Y));
                    int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (p2.Y - p1.Y));

                    int color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (p2.Y - y3));
                    int color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (p2.Y - y3));
                    int color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (p2.Y - y3));

                    j = 0;

                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - p1.X));
                        int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - p1.X));
                        int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - p1.X));

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
                            canvas[1, y] = cur_color;
                        else
                            canvas[x, y] = cur_color;
                    }
                }
            }

            void do_gradient (Point ev)
            {
                if (firstPoint)
                {
                    p1.X_ = ev.X;
                    p1.Y_ = ev.Y;
                    c1_ = SelectedColor; // Z

                    firstPoint = false;
                    secondPoint = true;

                }
                else if (secondPoint)
                {
                    p2.X_ = ev.X;
                    p2.Y_ = ev.Y;
                    c2_ = SelectedColor; // Z

                    secondPoint = false;
                    thirdPoint = true;
                }
                else if (thirdPoint)
                {
                    x3_ = ev.X;
                    y3_ = ev.Y;
                    c3_ = SelectedColor; // Z

                    thirdPoint = false;
                    firstPoint = true;

                    drawGradient(p1.X_, p1.Y_, c1_, p2.X_, p2.Y_, c2_, x3_, y3_, c3_);

                }
            };
        
         }
         */


    }
}
