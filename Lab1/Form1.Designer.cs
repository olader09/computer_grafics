﻿
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
            this.MainPicture = new System.Windows.Forms.PictureBox();
            this.PictureName = new System.Windows.Forms.TextBox();
            this.BrouseButton = new System.Windows.Forms.Button();
            this.Task1Button = new System.Windows.Forms.Button();
            this.Task2Button = new System.Windows.Forms.Button();
            this.Task3Button = new System.Windows.Forms.Button();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.PictureBox3 = new System.Windows.Forms.PictureBox();
            this.Histogram1 = new System.Windows.Forms.PictureBox();
            this.Histogram2 = new System.Windows.Forms.PictureBox();
            this.Histogram3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram3)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPicture
            // 
            this.MainPicture.Location = new System.Drawing.Point(12, 12);
            this.MainPicture.Name = "MainPicture";
            this.MainPicture.Size = new System.Drawing.Size(260, 315);
            this.MainPicture.TabIndex = 0;
            this.MainPicture.TabStop = false;
            // 
            // PictureName
            // 
            this.PictureName.Location = new System.Drawing.Point(12, 333);
            this.PictureName.Name = "PictureName";
            this.PictureName.Size = new System.Drawing.Size(260, 26);
            this.PictureName.TabIndex = 1;
            // 
            // BrouseButton
            // 
            this.BrouseButton.Location = new System.Drawing.Point(12, 365);
            this.BrouseButton.Name = "BrouseButton";
            this.BrouseButton.Size = new System.Drawing.Size(260, 100);
            this.BrouseButton.TabIndex = 2;
            this.BrouseButton.Text = "Brouse picture";
            this.BrouseButton.UseVisualStyleBackColor = true;
            // 
            // Task1Button
            // 
            this.Task1Button.Location = new System.Drawing.Point(12, 493);
            this.Task1Button.Name = "Task1Button";
            this.Task1Button.Size = new System.Drawing.Size(260, 60);
            this.Task1Button.TabIndex = 3;
            this.Task1Button.Text = "Grey shades";
            this.Task1Button.UseVisualStyleBackColor = true;
            // 
            // Task2Button
            // 
            this.Task2Button.Location = new System.Drawing.Point(12, 584);
            this.Task2Button.Name = "Task2Button";
            this.Task2Button.Size = new System.Drawing.Size(260, 60);
            this.Task2Button.TabIndex = 4;
            this.Task2Button.Text = "R G B";
            this.Task2Button.UseVisualStyleBackColor = true;
            // 
            // Task3Button
            // 
            this.Task3Button.Location = new System.Drawing.Point(12, 672);
            this.Task3Button.Name = "Task3Button";
            this.Task3Button.Size = new System.Drawing.Size(260, 60);
            this.Task3Button.TabIndex = 5;
            this.Task3Button.Text = "H S V";
            this.Task3Button.UseVisualStyleBackColor = true;
            this.Task3Button.Click += new System.EventHandler(this.Task3Button_Click);
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(335, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(260, 315);
            this.PictureBox1.TabIndex = 6;
            this.PictureBox1.TabStop = false;
            // 
            // PictureBox2
            // 
            this.PictureBox2.Location = new System.Drawing.Point(623, 12);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(260, 315);
            this.PictureBox2.TabIndex = 7;
            this.PictureBox2.TabStop = false;
            // 
            // PictureBox3
            // 
            this.PictureBox3.Location = new System.Drawing.Point(906, 12);
            this.PictureBox3.Name = "PictureBox3";
            this.PictureBox3.Size = new System.Drawing.Size(260, 315);
            this.PictureBox3.TabIndex = 8;
            this.PictureBox3.TabStop = false;
            // 
            // Histogram1
            // 
            this.Histogram1.Location = new System.Drawing.Point(335, 365);
            this.Histogram1.Name = "Histogram1";
            this.Histogram1.Size = new System.Drawing.Size(260, 367);
            this.Histogram1.TabIndex = 9;
            this.Histogram1.TabStop = false;
            // 
            // Histogram2
            // 
            this.Histogram2.Location = new System.Drawing.Point(623, 365);
            this.Histogram2.Name = "Histogram2";
            this.Histogram2.Size = new System.Drawing.Size(260, 367);
            this.Histogram2.TabIndex = 10;
            this.Histogram2.TabStop = false;
            // 
            // Histogram3
            // 
            this.Histogram3.Location = new System.Drawing.Point(906, 365);
            this.Histogram3.Name = "Histogram3";
            this.Histogram3.Size = new System.Drawing.Size(260, 367);
            this.Histogram3.TabIndex = 11;
            this.Histogram3.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.Histogram3);
            this.Controls.Add(this.Histogram2);
            this.Controls.Add(this.Histogram1);
            this.Controls.Add(this.PictureBox3);
            this.Controls.Add(this.PictureBox2);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Task3Button);
            this.Controls.Add(this.Task2Button);
            this.Controls.Add(this.Task1Button);
            this.Controls.Add(this.BrouseButton);
            this.Controls.Add(this.PictureName);
            this.Controls.Add(this.MainPicture);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPicture;
        private System.Windows.Forms.TextBox PictureName;
        private System.Windows.Forms.Button BrouseButton;
        private System.Windows.Forms.Button Task1Button;
        private System.Windows.Forms.Button Task2Button;
        private System.Windows.Forms.Button Task3Button;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.PictureBox PictureBox2;
        private System.Windows.Forms.PictureBox PictureBox3;
        private System.Windows.Forms.PictureBox Histogram1;
        private System.Windows.Forms.PictureBox Histogram2;
        private System.Windows.Forms.PictureBox Histogram3;
    }
}

