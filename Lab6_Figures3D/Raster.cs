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
        public static void Triangle(double[,] canvas, Point p1, Point p2, Point p3, double z1, double z2, double z3, Color color, Color[,] color_canvas)
        { 
            //int x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y, x3 = p3.X, y3 = p3.Y;
            //double z1_ = Color.FromArgb(1, 2, 3), c2_ = Color.FromArgb(4, 5, 6), c3_ = Color.FromArgb(7, 8, 9);
            //bool firstPoint = true, secondPoint = false, thirdPoint = false; // для рисования мышью

            

            void swap(ref int x, ref int y)
            {
                int a = x;
                x = y;
                y = a;
            }

            void drawGradient()
            {
                int x1 = p1.X, x2 = p2.X, x3 = p3.X,
                    y1 = p1.Y, y2 = p2.Y, y3 = p3.Y;
                int z1 =0,
                    z2 = 0, 
                    z3 = 0;

                if (y1 < y2) // в решении вторая точка всегда верхняя, поэтому делаем её такой по оси y //
                {                                                                                       //
                    swap(ref x2, ref x1);                                                               //
                    swap(ref y2, ref y1);                                                               //
                    swap(ref z2, ref z1);                                                               //
                                                                                                        //int q1 = c1.R, q2 = c1.G, q3 = c1.B;                                                //
                                                                                                        //c1 = Color.FromArgb(c2.R, c2.G, c2.B);                                              //
                                                                                                        //c2 = Color.FromArgb(q1, q2, q3);                                                    //
                                                                                                       //
                }                                                                                       //  
                                                                                                        //  
                if (y3 < y2)                                                                            //
                {                                                                                       //
                    swap(ref x2, ref x3);                                                               //
                    swap(ref y2, ref y3);                                                               //
                    swap(ref z2, ref z3);                                                                                //
                    //int q1 = c2.R, q2 = c2.G, q3 = c2.B;                                                //
                    //c2 = Color.FromArgb(c3.R, c3.G, c3.B);                                              //
                    //c3 = Color.FromArgb(q1, q2, q3);                                                    //
                }                                                                                       //

                if (x1 > x3)
                {
                    swap(ref x1, ref x3);
                    swap(ref y1, ref y3);
                    swap(ref z1, ref z3);
                    //int q1 = c1.R, q2 = c1.G, q3 = c1.B;
                    //c1 = Color.FromArgb(c3.R, c3.G, c3.B);
                    //c3 = Color.FromArgb(q1, q2, q3);
                }

                if (y1 < y3)
                {
                    //Tuple<int, int, int> p = drawGradientUpToDown1(x1, y1, c1, x2, y2, c2, x3, y3, c3);
                    double z_point = drawGradientUpToDown1(x1, y1, z1, x2, y2, z2, x3, y3, z3);

                    float x_new = x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2);


                     //int z_new = (z2 + z3) * (y1 - y2) / (y3 - y2);

                    //int red_new = (c2.R + c3.R) * (y1 - y2) / (y3 - y2);
                    //int green_new = (c2.G + c3.G) * (y1 - y2) / (y3 - y2);
                    //int blue_new = (c2.B + c3.B) * (y1 - y2) / (y3 - y2);

                    //if (red_new > 255)   // ну, не без этого
                      //  red_new = 255;
                    /*if (green_new > 255)
                        green_new = 255;
                    if (blue_new > 255)
                        blue_new = 255;
                    if (red_new < 0)
                        red_new = 0;
                    if (green_new < 0)
                        green_new = 0;
                    if (blue_new < 0)
                        blue_new = 0;*/

                    //Color c_new = Color.FromArgb(red_new, green_new, blue_new);
                    //Color c_new = Color.FromArgb(p.Item1, p.Item2, p.Item3);

                    drawGradientUpToDown(x1, y1, z1, x2, y2, z2, (int)x_new, y1, z_point);

                    drawGradientDownToUp(x1, y1, z1, x3, y3, z3, (int)x_new, y1, z_point);

                }

                else
                {
                    double x_new = x2 - (x2 - x1) * (y3 - y2) / (double)(y1 - y2);
                    double z_point = drawGradientUpToDown1(x1, y1, z1, x2, y2, z2, x3, y3, z3);
                    //int red_new = (c2.R + c1.R) * (y3 - y2) / (y1 - y2);
                    //int green_new = (c2.G + c1.G) * (y3 - y2) / (y1 - y2);
                    //int blue_new = (c2.B + c1.B) * (y3 - y2) / (y1 - y2);
                    //int z_new = (z2 + z1) * (y3 - y2) / (y1 - y2);

                    //Color c_new = Color.FromArgb(p.Item1, p.Item2, p.Item3);
                    //Color c_new = Color.FromArgb(red_new, green_new, blue_new);
                   /* if (red_new > 255)   // ну, не без этого
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
                        blue_new = 0;*/

                    drawGradientUpToDown((int)x_new, y3, z_point, x2, y2, z2, x3, y3, z3);
                    drawGradientDownToUp((int)x_new, y3, z_point, x1, y1, z1, x3, y3, z3);
                }
            }
            /////////
            // **********
            void drawGradientUpToDown(int x1, int y1, double z1, int x2, int y2, double z2, int x3, int y3, double z3)
            {
                int i = 0; // каждый пиксель по оси у
                int j = 0; // каждый пиксель по оси х, когда рисуем прямые

                /*int r1_begin = c1.R; // начальные цвета
                int g1_begin = c1.G;
                int b1_begin = c1.B;

                int r2_begin = c2.R;
                int g2_begin = c2.G;
                int b2_begin = c2.B;

                int r3_begin = c3.R;
                int g3_begin = c3.G;
                int b3_begin = c3.B;
                */
                


                if (y1 == y2)
                    y1++;
                if (y1 == y3)
                    y3++;
                if (y2 == y3)
                    y2++;


                // int color_right_red = 0;  // цвет правой точки
                //int color_right_green = 0;
                //int color_right_blue = 0;
                double z_right = 0;

                for (int y = y2; y < y3; y++)
                {

                    i++;

                    int xleft = x2 - (x2 - x1) * i / (y3 - y2); // левая точка текущей прямой
                    int deltax = i * (x3 - x1) / (y3 - y2);     // длина текущей прямой

                    // int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y1 - y2)); // цвет левой точки
                    // int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y1 - y2));
                    // int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y1 - y2));
                    double z_left = z2 + (i * (z1 - z2) / (y1 - y2));

                   // color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - y2));  // цвет правой точки
                    //color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - y2));
                    //color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - y2));
                    z_right = z2 + (i * (z3 - z2) / (y3 - y2));

                    j = 0;


                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        //int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));    // текущие цвета
                        //int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                        //int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));
                        double z_cur = z_left + (j * (z_right - z_left) / (double)(x3 - x1));

                        /* if (red_cur > 255)   // ну, не без этого
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
                             blue_cur = 0;*/


                        //Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                        if (x < 0)
                            if (canvas[1, y] > z_cur)
                            {
                                canvas[1, y] = z_cur;
                                color_canvas[1, y] = color;
                            }
                            else
                            {
                                canvas[x, y] = z_cur;
                                color_canvas[x, y] = color;
                            }

                        
                    }
                    //if (y == y1)
                    // break;

                }


            }
            // **********------
            double drawGradientUpToDown1(int x1, int y1, double z1, int x2, int y2, double z2, int x3, int y3, double z3)
            {
                int i = 0; // каждый пиксель по оси у
                int j = 0; // каждый пиксель по оси х, когда рисуем прямые

                /*int r1_begin = c1.R; // начальные цвета
                int g1_begin = c1.G;
                int b1_begin = c1.B;

                int r2_begin = c2.R;
                int g2_begin = c2.G;
                int b2_begin = c2.B;

                int r3_begin = c3.R;
                int g3_begin = c3.G;
                int b3_begin = c3.B;*/


                if (y1 == y2)
                    y1++;
                if (y1 == y3)
                    y3++;
                if (y2 == y3)
                    y2++;


                //int color_right_red = 0;  // цвет правой точки
                //int color_right_green = 0;
                //int color_right_blue = 0;
                double z_right = 0;

                for (int y = y2; y < y3; y++)
                {

                    i++;
                    int x_new_ = x2 + (x3 - x2) * (y1 - y2) / (y3 - y2);
                    int xleft = x2 - (x2 - x1) * i / (y3 - y2); // левая точка текущей прямой
                    int deltax = i * (x3 - x1) / (y3 - y2);     // длина текущей прямой

                    //int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y1 - y2)); // цвет левой точки
                    //int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y1 - y2));
                    //int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y1 - y2));
                    double z_left = z2 + (i * (z1 - z2) / (double)(y1 - y2));

                    /*color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y3 - y2));  // цвет правой точки
                    color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y3 - y2));
                    color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y3 - y2));*/
                    z_right = z2 + (i * (z3 - z2) / (double)(y2 - y2));

                    j = 0;


                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        // int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));    // текущие цвета
                        //int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                        //int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));
                        double z_cur = z_left + (j * (z_right- z_left) / (double)(x3 - x1));

                        /*
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
                        */


                        //Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                        if (x < 0)
                            if (canvas[1, y] > z_cur)
                            {
                                canvas[1, y] = z_cur;
                                color_canvas[1, y] = color;
                            }
                            else
                            {
                                canvas[x, y] = z_cur;
                                color_canvas[x, y] = color;
                            }


                    }
                    if (y == y1)
                        break;

                }
                //drawGradientDownToUp(x1, y1, c1, x3, y3, c3, (int)x_new, y1, c_new);
                //x3 = ((int)(x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2)));
                //float x_new = x2 + (x3 - x2) * (y1 - y2) / (float)(y3 - y2);
                //Color c_new = Color.FromArgb(color_right_red, color_right_green, color_right_blue);
                //return Tuple.Create(color_right_red, color_right_green, color_right_blue);
                return z_right;

            }
            //-------------
            void drawGradientDownToUp(int x1, int y1, double z1, int x2, int y2, double z2, int x3, int y3, double z3)
            {
                int i = 0;
                int j = 0;

               /* 
                int r1_begin = c1.R;
                int g1_begin = c1.G;
                int b1_begin = c1.B;

                int r2_begin = c2.R;
                int g2_begin = c2.G;
                int b2_begin = c2.B;

                int r3_begin = c3.R;
                int g3_begin = c3.G;
                int b3_begin = c3.B;
               */

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

                    // int color_left_red = r2_begin + (i * (r1_begin - r2_begin) / (y2 - y1));
                    // int color_left_green = g2_begin + (i * (g1_begin - g2_begin) / (y2 - y1));
                    // int color_left_blue = b2_begin + (i * (b1_begin - b2_begin) / (y2 - y1));
                    double z_left = z2 + (i * (z1 - z2) / (double)(y2 - y1));

                    //int color_right_red = r2_begin + (i * (r3_begin - r2_begin) / (y2 - y3));
                    //int color_right_green = g2_begin + (i * (g3_begin - g2_begin) / (y2 - y3));
                    //int color_right_blue = b2_begin + (i * (b3_begin - b2_begin) / (y2 - y3));
                    double z_right = z2 + (i * (z3 - z2) / (double)(y2 - y3));

                    j = 0;

                    for (int x = xleft; x < xleft + deltax; x++)
                    {
                        j++;
                        //int red_cur = color_left_red + (j * (color_right_red - color_left_red) / (x3 - x1));
                        //int green_cur = color_left_green + (j * (color_right_green - color_left_green) / (x3 - x1));
                        //int blue_cur = color_left_blue + (j * (color_right_blue - color_left_blue) / (x3 - x1));
                        double z_cur = z_left + (j * (z_right - z_left) / (x3 - x1));

                        /*
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
                        */


                        // Color cur_color = Color.FromArgb(red_cur, green_cur, blue_cur);
                        if (x < 0)
                            if (canvas[1, y] > z_cur)
                            {
                                canvas[1, y] = z_cur;
                                color_canvas[1, y] = color;
                            }
                            else
                            {
                                canvas[x, y] = z_cur;
                                color_canvas[x, y] = color;
                            }
                    }
                }
            }
            /*
            void do_gradient (Point ev)
            {
                if (firstPoint)
                {
                    x1_ = ev.X;
                    y1_ = ev.Y;
                    c1_ = SelectedColor; // Z

                    firstPoint = false;
                    secondPoint = true;

                }
                else if (secondPoint)
                {
                    x2_ = ev.X;
                    y2_ = ev.Y;
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

                    drawGradient(x1_, y1_, c1_, x2_, y2_, c2_, x3_, y3_, c3_);

                }
            };
            */


        }
    }
}
