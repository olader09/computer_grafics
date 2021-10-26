using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace Lab4_Fracts
{
    public partial class Form3 : Form
    {
        private Button NextButton;
        private PictureBox Picture;

        private bool line = false;
        private bool sharping = false;
        private TextBox RandomTB;
        private Label RandTB;
        private List<Point> mountain = new List<Point>();
        private double coef = 1.0; 
        private Queue<(Point, Point)> queue = new Queue<(Point, Point)>();
        private int to_go = 1; 

        private void InitializeComponent()
        {
            this.NextButton = new System.Windows.Forms.Button();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.RandomTB = new System.Windows.Forms.TextBox();
            this.RandTB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(12, 556);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(193, 94);
            this.NextButton.TabIndex = 0;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // Picture
            // 
            this.Picture.Location = new System.Drawing.Point(13, 13);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(1046, 537);
            this.Picture.TabIndex = 1;
            this.Picture.TabStop = false;
            this.Picture.Click += new System.EventHandler(this.Picture_Click);
            // 
            // RandomTB
            // 
            this.RandomTB.Location = new System.Drawing.Point(212, 623);
            this.RandomTB.Name = "RandomTB";
            this.RandomTB.Size = new System.Drawing.Size(189, 26);
            this.RandomTB.TabIndex = 2;
            this.RandomTB.Text = "25";
            // 
            // RandTB
            // 
            this.RandTB.AutoSize = true;
            this.RandTB.Location = new System.Drawing.Point(211, 600);
            this.RandTB.Name = "RandTB";
            this.RandTB.Size = new System.Drawing.Size(196, 20);
            this.RandTB.TabIndex = 3;
            this.RandTB.Text = "Randomness in percent %";
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(1071, 662);
            this.Controls.Add(this.RandTB);
            this.Controls.Add(this.RandomTB);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.NextButton);
            this.Name = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Picture_Click(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;
            if (!sharping)
            {
                if (!line)
                    mountain.Add(me.Location);
                else
                {
                    mountain.Add(me.Location);
                    sharping = true;
                    queue.Enqueue((mountain.ElementAt(0), mountain.ElementAt(1)));
                }
            }
        }

        private void RedrawMount()
        {
            var g = Picture.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Picture.Width, Picture.Height);
            foreach (var line in queue)
                g.DrawLine(new Pen(Color.Black), line.Item1, line.Item2);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Random r = new Random(); 
            for (int i = 0; i < to_go; ++i)
            {
                var line = queue.Dequeue();
                Point mid = new Point((line.Item1.X + line.Item2.X) / 2, (line.Item1.Y + line.Item2.Y) / 2);
                mid.Y = (int)(mid.Y * (1 + r.NextDouble() * double.Parse(RandomTB.Text) * coef));
                queue.Enqueue((line.Item1, mid));
                queue.Enqueue((mid, line.Item2)); 
            }
            to_go *= 2;
            coef *= 0.95; 
            RedrawMount(); 
        }
    }
}
