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
        Color SelectedColor;
        Bitmap picture;
        bool drawing;
        System.Threading.Thread drawThread = null;
        System.Threading.Thread showThread = null;

        public Form1()
        {
            InitializeComponent();
            this.Work.Items.AddRange(new object[] { "Floodfill", "Draw line", "Gradient", "Draw by mouse" });
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
            var cl = (MouseEventArgs)e;
            int x = (int)((double)cl.X / Canvas.Width * picture.Width), 
                y = (int)((double)cl.Y / Canvas.Height * picture.Height);
            // using (var fb = new GraphFunc.FastBitmap(picture))
            {
                switch (Work.SelectedIndex)
                {
                    case 0: // Flood Fill
                        // Console.WriteLine(SelectedColor.A + " " + SelectedColor.G + " " + SelectedColor.B);
                        // Console.WriteLine($"X = {x}, Y = {y}");
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
                        break;

                }
            }

            Canvas.Image = picture;
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

                case 3:

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
            }
        }
    }
}
