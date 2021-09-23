﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Task3Button_Click(object sender, EventArgs e)
        {

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
            // Picture 1
            Bitmap b = new Bitmap(picture.Width, picture.Height);
            int[] vec1 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = (int)((0.299 * picture.GetPixel(i, j).R) +
                                  (0.587 * picture.GetPixel(i, j).G) +
                                  (0.114 * picture.GetPixel(i, j).B));
                    vec1[y] += 1; 
                    b.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.Image = b;

            // Picture 2
            Bitmap bb = new Bitmap(picture.Width, picture.Height);
            int[] vec2 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = (int)((0.2126 * picture.GetPixel(i, j).R) +
                                  (0.7152 * picture.GetPixel(i, j).G) +
                                  (0.0722 * picture.GetPixel(i, j).B));
                    vec2[y] += 1;
                    bb.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;

            // Picture 3
            Bitmap bbb = new Bitmap(picture.Width, picture.Height);
            int[] vec3 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int diff = Math.Abs(b.GetPixel(i, j).R - bb.GetPixel(i, j).R);
                    bbb.SetPixel(i, j, Color.FromArgb(diff, diff, diff));
                    vec3[diff] += 1;
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
            // Picture 1
            Bitmap b = new Bitmap(picture.Width, picture.Height);
            int[] vec1 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = picture.GetPixel(i, j).R;
                    vec1[y] += 1;
                    b.SetPixel(i, j, Color.FromArgb(y, 0, 0));
                }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.Image = b;

            // Picture 2
            Bitmap bb = new Bitmap(picture.Width, picture.Height);
            int[] vec2 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = picture.GetPixel(i, j).G;
                    vec2[y] += 1;
                    bb.SetPixel(i, j, Color.FromArgb(0, y, 0));
                }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;

            // Picture 3
            Bitmap bbb = new Bitmap(picture.Width, picture.Height);
            int[] vec3 = new int[256];
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = picture.GetPixel(i, j).B;
                    vec3[y] += 1;
                    bbb.SetPixel(i, j, Color.FromArgb(0, 0, y));
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
    }
}
