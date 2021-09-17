
namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Picture = new System.Windows.Forms.PictureBox();
            this.Brouse = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Grey = new System.Windows.Forms.Button();
            this.RGB = new System.Windows.Forms.Button();
            this.HSV = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.hist1 = new System.Windows.Forms.PictureBox();
            this.hist2 = new System.Windows.Forms.PictureBox();
            this.hist3 = new System.Windows.Forms.PictureBox();
            this.Hue = new System.Windows.Forms.TrackBar();
            this.Saturation = new System.Windows.Forms.TrackBar();
            this.Value = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value)).BeginInit();
            this.SuspendLayout();
            // 
            // Picture
            // 
            this.Picture.Location = new System.Drawing.Point(23, 12);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(136, 168);
            this.Picture.TabIndex = 0;
            this.Picture.TabStop = false;
            // 
            // Brouse
            // 
            this.Brouse.Location = new System.Drawing.Point(23, 186);
            this.Brouse.Name = "Brouse";
            this.Brouse.Size = new System.Drawing.Size(136, 23);
            this.Brouse.TabIndex = 1;
            this.Brouse.Text = "Brouse";
            this.Brouse.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(181, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(137, 168);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Grey
            // 
            this.Grey.Location = new System.Drawing.Point(651, 12);
            this.Grey.Name = "Grey";
            this.Grey.Size = new System.Drawing.Size(133, 23);
            this.Grey.TabIndex = 3;
            this.Grey.Text = "Grey";
            this.Grey.UseVisualStyleBackColor = true;
            // 
            // RGB
            // 
            this.RGB.Location = new System.Drawing.Point(651, 41);
            this.RGB.Name = "RGB";
            this.RGB.Size = new System.Drawing.Size(133, 23);
            this.RGB.TabIndex = 6;
            this.RGB.Text = "RGB";
            this.RGB.UseVisualStyleBackColor = true;
            // 
            // HSV
            // 
            this.HSV.Location = new System.Drawing.Point(651, 70);
            this.HSV.Name = "HSV";
            this.HSV.Size = new System.Drawing.Size(133, 23);
            this.HSV.TabIndex = 7;
            this.HSV.Text = "HSV";
            this.HSV.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(335, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(141, 168);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(491, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(140, 167);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // hist1
            // 
            this.hist1.Location = new System.Drawing.Point(12, 243);
            this.hist1.Name = "hist1";
            this.hist1.Size = new System.Drawing.Size(256, 220);
            this.hist1.TabIndex = 10;
            this.hist1.TabStop = false;
            // 
            // hist2
            // 
            this.hist2.Location = new System.Drawing.Point(278, 243);
            this.hist2.Name = "hist2";
            this.hist2.Size = new System.Drawing.Size(256, 220);
            this.hist2.TabIndex = 11;
            this.hist2.TabStop = false;
            // 
            // hist3
            // 
            this.hist3.Location = new System.Drawing.Point(540, 243);
            this.hist3.Name = "hist3";
            this.hist3.Size = new System.Drawing.Size(256, 220);
            this.hist3.TabIndex = 12;
            this.hist3.TabStop = false;
            // 
            // Hue
            // 
            this.Hue.Location = new System.Drawing.Point(651, 99);
            this.Hue.Name = "Hue";
            this.Hue.Size = new System.Drawing.Size(133, 45);
            this.Hue.TabIndex = 13;
            // 
            // Saturation
            // 
            this.Saturation.Location = new System.Drawing.Point(651, 142);
            this.Saturation.Name = "Saturation";
            this.Saturation.Size = new System.Drawing.Size(133, 45);
            this.Saturation.TabIndex = 14;
            // 
            // Value
            // 
            this.Value.Location = new System.Drawing.Point(651, 186);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(133, 45);
            this.Value.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Saturation);
            this.Controls.Add(this.Hue);
            this.Controls.Add(this.hist3);
            this.Controls.Add(this.hist2);
            this.Controls.Add(this.hist1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.HSV);
            this.Controls.Add(this.RGB);
            this.Controls.Add(this.Grey);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Brouse);
            this.Controls.Add(this.Picture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hist3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

