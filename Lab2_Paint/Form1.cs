using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Paint
{
    public partial class Form1 : Form
    {
        Color SelectedColor; 

        public Form1()
        {
            InitializeComponent();
            this.Work.Items.AddRange(new object[] { "Floodfill", "Draw line", "Gradient" });
            Bitmap b = new Bitmap(Canvas.Width, Canvas.Height);
            for (int i = 0; i < Canvas.Width; ++i)
                for (int j = 0; j < Canvas.Height; ++j)
                    b.SetPixel(i, j, Color.White);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            var cl = (MouseEventArgs)e;
            Bitmap b = new Bitmap(Canvas.Image);
            using (var fb = GraphFunc.FastBitmap(b))
            {
                switch (Work.SelectedIndex)
                {
                    case 0: // Flood Fill
                        int x = cl.X, y = cl.Y;
                        Color col = b.GetPixel(x, y);
                        if (col == SelectedColor)
                            return;
                        Queue<(int, int)> q = new Queue<(int, int)>();
                        q.Enqueue((x, y));
                        while (q.Count != 0)
                        {
                            int pix_x, pix_y;
                            (pix_x, pix_y) = q.Dequeue();
                            if (fb.GetPixel(pix_x - 1, pix_y) == col)
                                q.Enqueue((pix_x - 1, pix_y));
                            if (fb.GetPixel(pix_x + 1, pix_y) == col)
                                q.Enqueue((pix_x + 1, pix_y));
                            if (fb.GetPixel(pix_x, pix_y - 1) == col)
                                q.Enqueue((pix_x, pix_y - 1));
                            if (fb.GetPixel(pix_x, pix_y + 1) == col)
                                q.Enqueue((pix_x, pix_y + 1));
                            fb.SetPixel(pix_x, pix_y, SelectedColor);
                        }
                        break;

                }
            }
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
                Bitmap b = new Bitmap(open.FileName);
                FFImage.Image = b;
                FFImageName.Text = open.FileName;
            }

            Canvas.Image = Image.FromFile(FFImageName.Text);
        }
    }
}
