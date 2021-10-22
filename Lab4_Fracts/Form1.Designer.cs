
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
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(12, 123);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1108, 554);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            // 
            // LSystemFile
            // 
            this.LSystemFile.Location = new System.Drawing.Point(12, 65);
            this.LSystemFile.Name = "LSystemFile";
            this.LSystemFile.Size = new System.Drawing.Size(149, 26);
            this.LSystemFile.TabIndex = 2;
            // 
            // LSystemFileLabel
            // 
            this.LSystemFileLabel.AutoSize = true;
            this.LSystemFileLabel.Location = new System.Drawing.Point(24, 94);
            this.LSystemFileLabel.Name = "LSystemFileLabel";
            this.LSystemFileLabel.Size = new System.Drawing.Size(125, 20);
            this.LSystemFileLabel.TabIndex = 3;
            this.LSystemFileLabel.Text = "File for L-system";
            // 
            // BrouseLSystemFileButton
            // 
            this.BrouseLSystemFileButton.Location = new System.Drawing.Point(12, 12);
            this.BrouseLSystemFileButton.Name = "BrouseLSystemFileButton";
            this.BrouseLSystemFileButton.Size = new System.Drawing.Size(149, 47);
            this.BrouseLSystemFileButton.TabIndex = 4;
            this.BrouseLSystemFileButton.Text = "Brouse file";
            this.BrouseLSystemFileButton.UseVisualStyleBackColor = true;
            this.BrouseLSystemFileButton.Click += new System.EventHandler(this.BrouseLSystemFileButton_Click);
            // 
            // DrawLSystemButton
            // 
            this.DrawLSystemButton.Location = new System.Drawing.Point(168, 12);
            this.DrawLSystemButton.Name = "DrawLSystemButton";
            this.DrawLSystemButton.Size = new System.Drawing.Size(100, 102);
            this.DrawLSystemButton.TabIndex = 5;
            this.DrawLSystemButton.Text = "Draw L-system";
            this.DrawLSystemButton.UseVisualStyleBackColor = true;
            this.DrawLSystemButton.Click += new System.EventHandler(this.DrawLSystemButton_Click);
            // 
            // Generations
            // 
            this.Generations.Location = new System.Drawing.Point(324, 12);
            this.Generations.Name = "Generations";
            this.Generations.Size = new System.Drawing.Size(100, 26);
            this.Generations.TabIndex = 6;
            this.Generations.Text = "7";
            // 
            // GenerationsLabel
            // 
            this.GenerationsLabel.AutoSize = true;
            this.GenerationsLabel.Location = new System.Drawing.Point(274, 15);
            this.GenerationsLabel.Name = "GenerationsLabel";
            this.GenerationsLabel.Size = new System.Drawing.Size(44, 20);
            this.GenerationsLabel.TabIndex = 7;
            this.GenerationsLabel.Text = "gens";
            // 
            // Randoms
            // 
            this.Randoms.Location = new System.Drawing.Point(324, 45);
            this.Randoms.Name = "Randoms";
            this.Randoms.Size = new System.Drawing.Size(100, 26);
            this.Randoms.TabIndex = 8;
            this.Randoms.Text = "-10 10";
            // 
            // RandomsLabel
            // 
            this.RandomsLabel.AutoSize = true;
            this.RandomsLabel.Location = new System.Drawing.Point(277, 48);
            this.RandomsLabel.Name = "RandomsLabel";
            this.RandomsLabel.Size = new System.Drawing.Size(41, 20);
            this.RandomsLabel.TabIndex = 9;
            this.RandomsLabel.Text = "rand";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 689);
            this.Controls.Add(this.RandomsLabel);
            this.Controls.Add(this.Randoms);
            this.Controls.Add(this.GenerationsLabel);
            this.Controls.Add(this.Generations);
            this.Controls.Add(this.DrawLSystemButton);
            this.Controls.Add(this.BrouseLSystemFileButton);
            this.Controls.Add(this.LSystemFileLabel);
            this.Controls.Add(this.LSystemFile);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

