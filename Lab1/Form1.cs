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

        public Form1()
        {
            InitializeComponent();
        }

        private void Task3Button_Click(object sender, EventArgs e)
        {

        }

        private void BrouseButton_Click(object sender, EventArgs e)
        {
            /*string text = PictureName.Text;
            MainPicture.Image = Image.FromFile(text);*/
            MainPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                MainPicture.Image = new Bitmap(open.FileName);
                // image file path  
                PictureName.Text = open.FileName;
                file = open.FileName; 
            }

        }

        private void Task1Button_Click(object sender, EventArgs e)
        {
            Bitmap o = new Bitmap(file);
            Bitmap b = new Bitmap(MainPicture.Width, MainPicture.Height);
            for (int i = 0; i < b.Width; ++i)
                for (int j = 0; j < b.Height; ++j)
                {
                    int y = (int)((0.299 * o.GetPixel(i, j).R) + (0.587 * o.GetPixel(i, j).G) + (0.114 * o.GetPixel(i, j).B));
                    b.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; 
            PictureBox1.Image = b;

            Bitmap bb = new Bitmap(MainPicture.Width, MainPicture.Height);
            for (int i = 0; i < b.Width; ++i)
                for (int j = 0; j < b.Height; ++j)
                {
                    int y = (int)((0.2126 * o.GetPixel(i, j).R) + (0.7152 * o.GetPixel(i, j).G) + (0.0722 * o.GetPixel(i, j).B));
                    b.SetPixel(i, j, Color.FromArgb(y, y, y));
                }

            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox2.Image = bb;
        }
    }
}
