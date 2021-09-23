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

namespace Lab1
{
    public partial class Form1 : Form
    {
        string file;
        Bitmap picture;
        Tuple<double, double, double>[,] hsv;
        double hh, ss, vv; 

        public void ClearHistograms()
        {
            Graphics g1 = Histogram1.CreateGraphics();
            Graphics g2 = Histogram2.CreateGraphics();
            Graphics g3 = Histogram3.CreateGraphics();

            Pen p = new Pen(Color.White);

            SolidBrush grayBrush = new SolidBrush(DefaultBackColor);

            Rectangle r1 = new Rectangle(0, 0, Histogram1.Width, Histogram1.Height);
            g1.FillRectangle(grayBrush, r1);

            Rectangle r2 = new Rectangle(0, 0, Histogram2.Width, Histogram2.Height);
            g2.FillRectangle(grayBrush, r2);

            Rectangle r3 = new Rectangle(0, 0, Histogram3.Width, Histogram3.Height);
            g3.FillRectangle(grayBrush, r3);

            g1.DrawRectangle(p, r1);
            g2.DrawRectangle(p, r2);
            g3.DrawRectangle(p, r3);

            g1.DrawRectangle(p, r1);
            g2.DrawRectangle(p, r2);
            g3.DrawRectangle(p, r3);
        }

        public void ClearPictures()
        {
            Graphics g1 = PictureBox1.CreateGraphics();
            Graphics g2 = PictureBox2.CreateGraphics();
            Graphics g3 = PictureBox3.CreateGraphics();

            Pen p = new Pen(Color.White);

            g1.DrawRectangle(p, new Rectangle(0, 0, PictureBox1.Width, PictureBox1.Height));
            g2.DrawRectangle(p, new Rectangle(0, 0, PictureBox2.Width, PictureBox2.Height));
            g3.DrawRectangle(p, new Rectangle(0, 0, PictureBox3.Width, PictureBox3.Height));
        }

        public void ClearHSV()
        {
            HBar.Visible = false;
            SBar.Visible = false;
            VBar.Visible = false;
            SaveButton.Visible = false; 
        }

        public Form1()
        {
            InitializeComponent();
            HBar.Minimum = 0;
            HBar.Maximum = 360;
            SBar.Minimum = 0;
            SBar.Maximum = 100;
            VBar.Minimum = 0;
            VBar.Maximum = 100;
            SBar.Value = 50;
            VBar.Value = 50; 

            
        }

        private void BrouseButton_Click(object sender, EventArgs e)
        {
            MainPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picture = new Bitmap(open.FileName);
                MainPicture.Image = picture; 
                PictureName.Text = open.FileName;
                file = open.FileName; 
            }

        }

        private void Task1Button_Click(object sender, EventArgs e)
        {
            ClearHistograms();
            ClearPictures();
            ClearHSV();

            PictureBox2.Visible = true;
            PictureBox3.Visible = true;

            // Picture 1
            Bitmap b = new Bitmap(picture.Width, picture.Height);
            int[] vec1 = new int[256];
            using (var fb = new GraphFunc.FastBitmap(b))
            using (var fpicture = new GraphFunc.FastBitmap(picture))
            {
                for (int i = 0; i < picture.Width; ++i)
                    for (int j = 0; j < picture.Height; ++j)
                    {

                        int y = (int)((0.299 * fpicture.GetPixel(new Point(i, j)).R) +
                                    (0.587 * fpicture.GetPixel(new Point(i, j)).G) +
                                    (0.114 * fpicture.GetPixel(new Point(i, j)).B));
                        vec1[y] += 1;

                        fb.SetPixel(new Point(i, j), Color.FromArgb(y, y, y));
                    }
            }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.Image = b;

            // Picture 2
            Bitmap bb = new Bitmap(picture.Width, picture.Height);
            int[] vec2 = new int[256];
            using (var fbb = new GraphFunc.FastBitmap(bb))
            {
                using (var fpicture = new GraphFunc.FastBitmap(picture))
                {
                    for (int i = 0; i < picture.Width; ++i)
                        for (int j = 0; j < picture.Height; ++j)
                        {
                            int y = (int)((0.2126 * fpicture.GetPixel(new Point(i, j)).R) +
                                          (0.7152 * fpicture.GetPixel(new Point(i, j)).G) +
                                          (0.0722 * fpicture.GetPixel(new Point(i, j)).B));
                            vec2[y] += 1;
                            fbb.SetPixel(new Point(i, j), Color.FromArgb(y, y, y));
                        }
                }
            }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;

            // Picture 3
            Bitmap bbb = new Bitmap(picture.Width, picture.Height);
            int[] vec3 = new int[256];
            using (var fbbb = new GraphFunc.FastBitmap(bbb))
            {
                for (int i = 0; i < picture.Width; ++i)
                    for (int j = 0; j < picture.Height; ++j)
                    {
                        int diff = Math.Abs(b.GetPixel(i, j).R - bb.GetPixel(i, j).R);
                        fbbb.SetPixel(new Point(i, j), Color.FromArgb(diff, diff, diff));
                        vec3[diff] += 1;
                    }
            }

            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox3.Image = bbb;

            // ------------------------------
            Pen p = new Pen(Color.Black); 
            // ------------------------------

            // Histogram 1 
            Graphics g1 = Histogram1.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g1.DrawLine(p, i, Histogram1.Height, i, 
                    (int)(Histogram1.Height - (vec1[i] / (double)vec1.Max()) * Histogram1.Height ));

            // Histogram 2 
            Graphics g2 = Histogram2.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g2.DrawLine(p, i, Histogram2.Height, i,
                    (int)(Histogram2.Height - (vec2[i] / (double)vec2.Max()) * Histogram2.Height));

            // Histogram 2 
            Graphics g3 = Histogram3.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g3.DrawLine(p, i, Histogram3.Height, i,
                    (int)(Histogram3.Height - (vec3[i] / (double)vec3.Max()) * Histogram3.Height));
        }

        private void Task2Button_Click(object sender, EventArgs e)
        {
            ClearHistograms();
            ClearPictures();
            ClearHSV();

            PictureBox2.Visible = true;
            PictureBox3.Visible = true;

            // Picture 1
            Bitmap b = new Bitmap(picture.Width, picture.Height);
            int[] vec1 = new int[256];
            using (var fb = new GraphFunc.FastBitmap(b))
            {
                using (var fpicture = new GraphFunc.FastBitmap(picture))
                {
                    for (int i = 0; i < picture.Width; ++i)
                        for (int j = 0; j < picture.Height; ++j)
                        {
                            int y = fpicture.GetPixel(new Point(i, j)).R;
                            vec1[y] += 1;
                            fb.SetPixel(new Point(i, j), Color.FromArgb(y, 0, 0));
                        }
                }
            }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.Image = b;

            // Picture 2
            Bitmap bb = new Bitmap(picture.Width, picture.Height);
            int[] vec2 = new int[256];
            using (var fbb = new GraphFunc.FastBitmap(bb))
            {
                using (var fpicture = new GraphFunc.FastBitmap(picture))
                {
                    for (int i = 0; i < picture.Width; ++i)
                        for (int j = 0; j < picture.Height; ++j)
                        {
                            int y = fpicture.GetPixel(new Point(i, j)).G;
                            vec2[y] += 1;
                            fbb.SetPixel(new Point(i, j), Color.FromArgb(0, y, 0));
                        }
                }
            }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;

            // Picture 3
            Bitmap bbb = new Bitmap(picture.Width, picture.Height);
            int[] vec3 = new int[256];
            using (var fbbb = new GraphFunc.FastBitmap(bbb))
            {
                using (var fpicture = new GraphFunc.FastBitmap(picture))
                {
                    for (int i = 0; i < picture.Width; ++i)
                        for (int j = 0; j < picture.Height; ++j)
                        {
                            int y = fpicture.GetPixel(new Point(i, j)).B;
                            vec3[y] += 1;
                            fbbb.SetPixel(new Point(i, j), Color.FromArgb(0, 0, y));
                        }
                }
            }

            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox3.Image = bbb;

            // Histogram 1 
            Graphics g1 = Histogram1.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g1.DrawLine(new Pen(Color.Red), i, Histogram1.Height, i,
                    (int)(Histogram1.Height - (vec1[i] / (double)vec1.Max()) * Histogram1.Height));

            // Histogram 2 
            Graphics g2 = Histogram2.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g2.DrawLine(new Pen(Color.Green), i, Histogram2.Height, i,
                    (int)(Histogram2.Height - (vec2[i] / (double)vec2.Max()) * Histogram2.Height));

            // Histogram 2 
            Graphics g3 = Histogram3.CreateGraphics();
            for (int i = 0; i < 256; ++i)
                g3.DrawLine(new Pen(Color.Blue), i, Histogram3.Height, i,
                    (int)(Histogram3.Height - (vec3[i] / (double)vec3.Max()) * Histogram3.Height));
        }

        private void Task3Button_Click(object sender, EventArgs e)
        {
            ClearHistograms();
            ClearPictures();

            PictureBox2.Visible = false;
            PictureBox3.Visible = false;

            HBar.Visible = true;
            SBar.Visible = true;
            VBar.Visible = true;
            SaveButton.Visible = true; 

            hsv = new Tuple<double, double, double>[picture.Width, picture.Height]; 
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    Color c = picture.GetPixel(i, j);
                    double max = new int[] { c.R, c.G, c.B }.Max();
                    double min = new int[] { c.R, c.G, c.B }.Min();

                    double h = 0.0;
                    if (max == min)
                        h = 0;
                    else if (max == c.R && c.G >= c.B)
                        h = 60 * ((c.G - c.B) / (max - min)); 
                    else if (max == c.R && c.G < c.B)
                        h = 60 * ((c.G - c.B) / (max - min)) + 360;
                    else if (max == c.G)
                        h = 60 * ((c.B - c.R) / (max - min)) + 120;
                    else if (max == c.B)
                        h = 60 * ((c.R - c.G) / (max - min)) + 240;

                    double s;
                    if (max == 0)
                        s = 0;
                    else
                        s = 1 - min / max;

                    double v = max;

                    hsv[i, j] = new Tuple<double, double, double>(h, s, v);
                }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            PictureBox1.Image = picture; 

        }

        

        private Bitmap HSVtoRGB(Tuple<double, double, double>[,] matrix)
        {
            Bitmap map = new Bitmap(picture.Width, picture.Height);
            using (var fmap = new GraphFunc.FastBitmap(map))
            {
                for (int i = 0; i < picture.Width; ++i)
                    for (int j = 0; j < picture.Height; ++j)
                    {
                        var elem = matrix[i, j];
                        var h = elem.Item1;
                        var s = elem.Item2;
                        var v = elem.Item3;
                        double temp = h / 60;
                        int hi = (int)Math.Floor(temp) % 6;
                        double f = temp - Math.Floor(temp);
                        int p = (int)(v * (1 - s));
                        int q = (int)(v * (1 - s * f));
                        int t = (int)(v * (1 - (1 - f) * s));

                        int r = 0, g = 0, b = 0;

                        switch (hi)
                        {
                            case 0:
                                r = (int)v; b = t; g = p;
                                break;
                            case 1:
                                r = q; b = (int)v; g = p;
                                break;
                            case 2:
                                r = p; b = (int)v; g = t;
                                break;
                            case 3:
                                r = p; b = q; g = (int)v;
                                break;
                            case 4:
                                r = t; b = p; g = (int)v;
                                break;
                            case 5:
                                r = (int)v; b = p; g = q;
                                break;
                        }

                        fmap.SetPixel(new Point(i, j), Color.FromArgb(r, g, b));
                    }
            }

            return map; 
        }

        private void HBar_Scroll(object sender, EventArgs e)
        {
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            hh = HBar.Value;
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    hsv[i,j] = new Tuple<double, double, double>((hsv[i, j].Item1 + hh) % 360, hsv[i, j].Item2, hsv[i, j].Item3);
                }
            PictureBox1.Image = HSVtoRGB(hsv); 
        }

       
        private void SBar_Scroll(object sender, EventArgs e)
        {
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            ss = (SBar.Value - 50) / 100.0;
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    hsv[i, j] = new Tuple<double, double, double>(hsv[i, j].Item1, hsv[i, j].Item2 + ss < 0 ? 0 : (hsv[i, j].Item2 + ss > 1 ? 1 : hsv[i, j].Item2 + ss), hsv[i, j].Item3);
                }
            PictureBox1.Image = HSVtoRGB(hsv);
        }

        private void VBar_Scroll(object sender, EventArgs e)
        {
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            vv = (VBar.Value - 50) / 700.0;
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    hsv[i, j] = new Tuple<double, double, double>(hsv[i, j].Item1, hsv[i, j].Item2, hsv[i, j].Item3 + vv < 0 ? 0 : (hsv[i, j].Item3 + vv > 1 ? 1 : hsv[i, j].Item3 + vv));
                }
            PictureBox1.Image = HSVtoRGB(hsv);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            HSVtoRGB(hsv).Save(System.IO.Path.GetFileNameWithoutExtension(file) + "-new" + System.IO.Path.GetExtension(file));
        }

    }
}
