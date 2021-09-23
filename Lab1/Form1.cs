using System;
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
            Bitmap b = new Bitmap(picture.Width, picture.Height);
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = (int)((0.299 * picture.GetPixel(i, j).R) +
                                  (0.587 * picture.GetPixel(i, j).G) +
                                  (0.114 * picture.GetPixel(i, j).B));
                    b.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox1.Image = b;

            Bitmap bb = new Bitmap(picture.Width, picture.Height);
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int y = (int)((0.2126 * picture.GetPixel(i, j).R) +
                                  (0.7152 * picture.GetPixel(i, j).G) +
                                  (0.0722 * picture.GetPixel(i, j).B));
                    bb.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;

            Bitmap bbb = new Bitmap(picture.Width, picture.Height);
            for (int i = 0; i < picture.Width; ++i)
                for (int j = 0; j < picture.Height; ++j)
                {
                    int diff = Math.Abs(b.GetPixel(i, j).R - bb.GetPixel(i, j).R);
                    bbb.SetPixel(i, j, Color.FromArgb(diff, diff, diff));
                }

            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox3.Image = bbb;
        }
                
    }
}
