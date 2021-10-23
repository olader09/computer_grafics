
namespace Lab4_Fracts
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
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.LSystemFile = new System.Windows.Forms.TextBox();
            this.LSystemFileLabel = new System.Windows.Forms.Label();
            this.BrouseLSystemFileButton = new System.Windows.Forms.Button();
            this.DrawLSystemButton = new System.Windows.Forms.Button();
            this.Generations = new System.Windows.Forms.TextBox();
            this.GenerationsLabel = new System.Windows.Forms.Label();
            this.Randoms = new System.Windows.Forms.TextBox();
            this.RandomsLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.StretchButton = new System.Windows.Forms.Button();
            this.StretchTB = new System.Windows.Forms.TextBox();
            this.ShiftButton = new System.Windows.Forms.Button();
            this.ShiftTB = new System.Windows.Forms.TextBox();
            this.BezCur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(149, 98);
            this.Canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1028, 514);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            // 
            // LSystemFile
            // 
            this.LSystemFile.Location = new System.Drawing.Point(11, 52);
            this.LSystemFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LSystemFile.Name = "LSystemFile";
            this.LSystemFile.Size = new System.Drawing.Size(133, 22);
            this.LSystemFile.TabIndex = 2;
            // 
            // LSystemFileLabel
            // 
            this.LSystemFileLabel.AutoSize = true;
            this.LSystemFileLabel.Location = new System.Drawing.Point(21, 75);
            this.LSystemFileLabel.Name = "LSystemFileLabel";
            this.LSystemFileLabel.Size = new System.Drawing.Size(112, 17);
            this.LSystemFileLabel.TabIndex = 3;
            this.LSystemFileLabel.Text = "File for L-system";
            // 
            // BrouseLSystemFileButton
            // 
            this.BrouseLSystemFileButton.Location = new System.Drawing.Point(11, 10);
            this.BrouseLSystemFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrouseLSystemFileButton.Name = "BrouseLSystemFileButton";
            this.BrouseLSystemFileButton.Size = new System.Drawing.Size(132, 38);
            this.BrouseLSystemFileButton.TabIndex = 4;
            this.BrouseLSystemFileButton.Text = "Brouse file";
            this.BrouseLSystemFileButton.UseVisualStyleBackColor = true;
            this.BrouseLSystemFileButton.Click += new System.EventHandler(this.BrouseLSystemFileButton_Click);
            // 
            // DrawLSystemButton
            // 
            this.DrawLSystemButton.Location = new System.Drawing.Point(149, 10);
            this.DrawLSystemButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DrawLSystemButton.Name = "DrawLSystemButton";
            this.DrawLSystemButton.Size = new System.Drawing.Size(89, 82);
            this.DrawLSystemButton.TabIndex = 5;
            this.DrawLSystemButton.Text = "Draw L-system";
            this.DrawLSystemButton.UseVisualStyleBackColor = true;
            this.DrawLSystemButton.Click += new System.EventHandler(this.DrawLSystemButton_Click);
            // 
            // Generations
            // 
            this.Generations.Location = new System.Drawing.Point(288, 10);
            this.Generations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Generations.Name = "Generations";
            this.Generations.Size = new System.Drawing.Size(89, 22);
            this.Generations.TabIndex = 6;
            this.Generations.Text = "4";
            // 
            // GenerationsLabel
            // 
            this.GenerationsLabel.AutoSize = true;
            this.GenerationsLabel.Location = new System.Drawing.Point(244, 12);
            this.GenerationsLabel.Name = "GenerationsLabel";
            this.GenerationsLabel.Size = new System.Drawing.Size(39, 17);
            this.GenerationsLabel.TabIndex = 7;
            this.GenerationsLabel.Text = "gens";
            // 
            // Randoms
            // 
            this.Randoms.Location = new System.Drawing.Point(288, 36);
            this.Randoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Randoms.Name = "Randoms";
            this.Randoms.Size = new System.Drawing.Size(89, 22);
            this.Randoms.TabIndex = 8;
            this.Randoms.Text = "-10 10";
            // 
            // RandomsLabel
            // 
            this.RandomsLabel.AutoSize = true;
            this.RandomsLabel.Location = new System.Drawing.Point(246, 38);
            this.RandomsLabel.Name = "RandomsLabel";
            this.RandomsLabel.Size = new System.Drawing.Size(37, 17);
            this.RandomsLabel.TabIndex = 9;
            this.RandomsLabel.Text = "rand";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(11, 98);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(132, 48);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StretchButton
            // 
            this.StretchButton.Location = new System.Drawing.Point(11, 151);
            this.StretchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchButton.Name = "StretchButton";
            this.StretchButton.Size = new System.Drawing.Size(132, 48);
            this.StretchButton.TabIndex = 11;
            this.StretchButton.Text = "Stretch";
            this.StretchButton.UseVisualStyleBackColor = true;
            this.StretchButton.Click += new System.EventHandler(this.StretchButton_Click);
            // 
            // StretchTB
            // 
            this.StretchTB.Location = new System.Drawing.Point(12, 205);
            this.StretchTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchTB.Name = "StretchTB";
            this.StretchTB.Size = new System.Drawing.Size(132, 22);
            this.StretchTB.TabIndex = 12;
            this.StretchTB.Text = "0,5 0,5";
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(12, 230);
            this.ShiftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(132, 44);
            this.ShiftButton.TabIndex = 13;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            this.ShiftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ShiftTB
            // 
            this.ShiftTB.Location = new System.Drawing.Point(12, 279);
            this.ShiftTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShiftTB.Name = "ShiftTB";
            this.ShiftTB.Size = new System.Drawing.Size(132, 22);
            this.ShiftTB.TabIndex = 14;
            this.ShiftTB.Text = "50 50";
            // 
            // BezCur
            // 
            this.BezCur.Location = new System.Drawing.Point(424, 24);
            this.BezCur.Name = "BezCur";
            this.BezCur.Size = new System.Drawing.Size(152, 23);
            this.BezCur.TabIndex = 15;
            this.BezCur.Text = "Прямые Безье";
            this.BezCur.UseVisualStyleBackColor = true;
            this.BezCur.Click += new System.EventHandler(this.BezCur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 622);
            this.Controls.Add(this.BezCur);
            this.Controls.Add(this.ShiftTB);
            this.Controls.Add(this.ShiftButton);
            this.Controls.Add(this.StretchTB);
            this.Controls.Add(this.StretchButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RandomsLabel);
            this.Controls.Add(this.Randoms);
            this.Controls.Add(this.GenerationsLabel);
            this.Controls.Add(this.Generations);
            this.Controls.Add(this.DrawLSystemButton);
            this.Controls.Add(this.BrouseLSystemFileButton);
            this.Controls.Add(this.LSystemFileLabel);
            this.Controls.Add(this.LSystemFile);
            this.Controls.Add(this.Canvas);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TextBox LSystemFile;
        private System.Windows.Forms.Label LSystemFileLabel;
        private System.Windows.Forms.Button BrouseLSystemFileButton;
        private System.Windows.Forms.Button DrawLSystemButton;
        private System.Windows.Forms.TextBox Generations;
        private System.Windows.Forms.Label GenerationsLabel;
        private System.Windows.Forms.TextBox Randoms;
        private System.Windows.Forms.Label RandomsLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button StretchButton;
        private System.Windows.Forms.TextBox StretchTB;
        private System.Windows.Forms.Button ShiftButton;
        private System.Windows.Forms.TextBox ShiftTB;
        private System.Windows.Forms.Button BezCur;
    }
}

