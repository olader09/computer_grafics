
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
            this.TreeCB = new System.Windows.Forms.CheckBox();
            this.ThicknessButton = new System.Windows.Forms.Button();
            this.ThicknessTB = new System.Windows.Forms.TextBox();
            this.MidDpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(168, 122);
            this.Canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(1156, 642);
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            // 
            // LSystemFile
            // 
            this.LSystemFile.Location = new System.Drawing.Point(12, 65);
            this.LSystemFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.BrouseLSystemFileButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrouseLSystemFileButton.Name = "BrouseLSystemFileButton";
            this.BrouseLSystemFileButton.Size = new System.Drawing.Size(148, 48);
            this.BrouseLSystemFileButton.TabIndex = 4;
            this.BrouseLSystemFileButton.Text = "Brouse file";
            this.BrouseLSystemFileButton.UseVisualStyleBackColor = true;
            this.BrouseLSystemFileButton.Click += new System.EventHandler(this.BrouseLSystemFileButton_Click);
            // 
            // DrawLSystemButton
            // 
            this.DrawLSystemButton.Location = new System.Drawing.Point(168, 12);
            this.DrawLSystemButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.Generations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Generations.Name = "Generations";
            this.Generations.Size = new System.Drawing.Size(100, 26);
            this.Generations.TabIndex = 6;
            this.Generations.Text = "4";
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
            this.Randoms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(12, 122);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(148, 60);
            this.ClearButton.TabIndex = 10;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StretchButton
            // 
            this.StretchButton.Location = new System.Drawing.Point(12, 189);
            this.StretchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchButton.Name = "StretchButton";
            this.StretchButton.Size = new System.Drawing.Size(148, 60);
            this.StretchButton.TabIndex = 11;
            this.StretchButton.Text = "Stretch";
            this.StretchButton.UseVisualStyleBackColor = true;
            this.StretchButton.Click += new System.EventHandler(this.StretchButton_Click);
            // 
            // StretchTB
            // 
            this.StretchTB.Location = new System.Drawing.Point(14, 256);
            this.StretchTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchTB.Name = "StretchTB";
            this.StretchTB.Size = new System.Drawing.Size(148, 26);
            this.StretchTB.TabIndex = 12;
            this.StretchTB.Text = "0,5 0,5";
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(14, 288);
            this.ShiftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(148, 55);
            this.ShiftButton.TabIndex = 13;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            this.ShiftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ShiftTB
            // 
            this.ShiftTB.Location = new System.Drawing.Point(14, 349);
            this.ShiftTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShiftTB.Name = "ShiftTB";
            this.ShiftTB.Size = new System.Drawing.Size(148, 26);
            this.ShiftTB.TabIndex = 14;
            this.ShiftTB.Text = "50 50";
            // 
            // BezCur
            // 
            this.BezCur.Location = new System.Drawing.Point(447, 11);
            this.BezCur.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BezCur.Name = "BezCur";
            this.BezCur.Size = new System.Drawing.Size(229, 103);
            this.BezCur.TabIndex = 15;
            this.BezCur.Text = "Bezier curves";
            this.BezCur.UseVisualStyleBackColor = true;
            this.BezCur.Click += new System.EventHandler(this.BezCur_Click);
            // 
            // TreeCB
            // 
            this.TreeCB.AutoSize = true;
            this.TreeCB.Location = new System.Drawing.Point(324, 76);
            this.TreeCB.Name = "TreeCB";
            this.TreeCB.Size = new System.Drawing.Size(67, 24);
            this.TreeCB.TabIndex = 16;
            this.TreeCB.Text = "Tree";
            this.TreeCB.UseVisualStyleBackColor = true;
            // 
            // ThicknessButton
            // 
            this.ThicknessButton.Location = new System.Drawing.Point(13, 381);
            this.ThicknessButton.Name = "ThicknessButton";
            this.ThicknessButton.Size = new System.Drawing.Size(148, 57);
            this.ThicknessButton.TabIndex = 17;
            this.ThicknessButton.Text = "Thickness";
            this.ThicknessButton.UseVisualStyleBackColor = true;
            this.ThicknessButton.Click += new System.EventHandler(this.ThicknessButton_Click);
            // 
            // ThicknessTB
            // 
            this.ThicknessTB.Location = new System.Drawing.Point(12, 445);
            this.ThicknessTB.Name = "ThicknessTB";
            this.ThicknessTB.Size = new System.Drawing.Size(148, 26);
            this.ThicknessTB.TabIndex = 18;
            this.ThicknessTB.Text = "0,5";
            // 
            // MidDpButton
            // 
            this.MidDpButton.Location = new System.Drawing.Point(698, 13);
            this.MidDpButton.Name = "MidDpButton";
            this.MidDpButton.Size = new System.Drawing.Size(232, 101);
            this.MidDpButton.TabIndex = 19;
            this.MidDpButton.Text = "Midpoint Displacement";
            this.MidDpButton.UseVisualStyleBackColor = true;
            this.MidDpButton.Click += new System.EventHandler(this.MidDpButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 778);
            this.Controls.Add(this.MidDpButton);
            this.Controls.Add(this.ThicknessTB);
            this.Controls.Add(this.ThicknessButton);
            this.Controls.Add(this.TreeCB);
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
        private System.Windows.Forms.CheckBox TreeCB;
        private System.Windows.Forms.Button ThicknessButton;
        private System.Windows.Forms.TextBox ThicknessTB;
        private System.Windows.Forms.Button MidDpButton;
    }
}

