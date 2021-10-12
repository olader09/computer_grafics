
namespace L3_Aff
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
            this.DotButton = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.PolyButton = new System.Windows.Forms.Button();
            this.FigNames = new System.Windows.Forms.ListBox();
            this.FigName = new System.Windows.Forms.TextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ShiftButton = new System.Windows.Forms.Button();
            this.DXTB = new System.Windows.Forms.TextBox();
            this.DYTB = new System.Windows.Forms.TextBox();
            this.DXLabel = new System.Windows.Forms.Label();
            this.DYLabel = new System.Windows.Forms.Label();
            this.RotatePointButton = new System.Windows.Forms.Button();
            this.RAPTB = new System.Windows.Forms.TextBox();
            this.RAPLabel = new System.Windows.Forms.Label();
            this.StretchCoefLabel = new System.Windows.Forms.Label();
            this.StretchButton = new System.Windows.Forms.Button();
            this.StretchTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LineTB = new System.Windows.Forms.TextBox();
            this.CollisButton = new System.Windows.Forms.Button();
            this.PointInsideButton = new System.Windows.Forms.Button();
            this.LinePointButton = new System.Windows.Forms.Button();
            this.PointLineTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(392, 100);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(986, 646);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // DotButton
            // 
            this.DotButton.Location = new System.Drawing.Point(12, 12);
            this.DotButton.Name = "DotButton";
            this.DotButton.Size = new System.Drawing.Size(86, 40);
            this.DotButton.TabIndex = 1;
            this.DotButton.Text = "Dot";
            this.DotButton.UseVisualStyleBackColor = true;
            this.DotButton.Click += new System.EventHandler(this.DotButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(12, 54);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(86, 40);
            this.LineButton.TabIndex = 2;
            this.LineButton.Text = "Line";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // PolyButton
            // 
            this.PolyButton.Location = new System.Drawing.Point(104, 12);
            this.PolyButton.Name = "PolyButton";
            this.PolyButton.Size = new System.Drawing.Size(128, 82);
            this.PolyButton.TabIndex = 3;
            this.PolyButton.Text = "Polygon";
            this.PolyButton.UseVisualStyleBackColor = true;
            this.PolyButton.Click += new System.EventHandler(this.PolyButton_Click);
            // 
            // FigNames
            // 
            this.FigNames.FormattingEnabled = true;
            this.FigNames.ItemHeight = 20;
            this.FigNames.Location = new System.Drawing.Point(12, 141);
            this.FigNames.Name = "FigNames";
            this.FigNames.Size = new System.Drawing.Size(374, 384);
            this.FigNames.TabIndex = 4;
            this.FigNames.SelectedIndexChanged += new System.EventHandler(this.FigNames_SelectedIndexChanged);
            // 
            // FigName
            // 
            this.FigName.Location = new System.Drawing.Point(12, 100);
            this.FigName.Name = "FigName";
            this.FigName.Size = new System.Drawing.Size(373, 26);
            this.FigName.TabIndex = 5;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.SystemColors.Control;
            this.ClearButton.Location = new System.Drawing.Point(238, 12);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(147, 82);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(392, 12);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(83, 82);
            this.ShiftButton.TabIndex = 7;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            // 
            // DXTB
            // 
            this.DXTB.Location = new System.Drawing.Point(519, 19);
            this.DXTB.Name = "DXTB";
            this.DXTB.Size = new System.Drawing.Size(100, 26);
            this.DXTB.TabIndex = 8;
            // 
            // DYTB
            // 
            this.DYTB.Location = new System.Drawing.Point(519, 61);
            this.DYTB.Name = "DYTB";
            this.DYTB.Size = new System.Drawing.Size(100, 26);
            this.DYTB.TabIndex = 9;
            // 
            // DXLabel
            // 
            this.DXLabel.AutoSize = true;
            this.DXLabel.Location = new System.Drawing.Point(488, 22);
            this.DXLabel.Name = "DXLabel";
            this.DXLabel.Size = new System.Drawing.Size(25, 20);
            this.DXLabel.TabIndex = 10;
            this.DXLabel.Text = "dx";
            // 
            // DYLabel
            // 
            this.DYLabel.AutoSize = true;
            this.DYLabel.Location = new System.Drawing.Point(488, 64);
            this.DYLabel.Name = "DYLabel";
            this.DYLabel.Size = new System.Drawing.Size(25, 20);
            this.DYLabel.TabIndex = 11;
            this.DYLabel.Text = "dy";
            // 
            // RotatePointButton
            // 
            this.RotatePointButton.Location = new System.Drawing.Point(641, 12);
            this.RotatePointButton.Name = "RotatePointButton";
            this.RotatePointButton.Size = new System.Drawing.Size(93, 82);
            this.RotatePointButton.TabIndex = 12;
            this.RotatePointButton.Text = "Rotate around point";
            this.RotatePointButton.UseVisualStyleBackColor = true;
            // 
            // RAPTB
            // 
            this.RAPTB.Location = new System.Drawing.Point(740, 40);
            this.RAPTB.Name = "RAPTB";
            this.RAPTB.Size = new System.Drawing.Size(100, 26);
            this.RAPTB.TabIndex = 13;
            // 
            // RAPLabel
            // 
            this.RAPLabel.AutoSize = true;
            this.RAPLabel.Location = new System.Drawing.Point(766, 17);
            this.RAPLabel.Name = "RAPLabel";
            this.RAPLabel.Size = new System.Drawing.Size(48, 20);
            this.RAPLabel.TabIndex = 14;
            this.RAPLabel.Text = "angle";
            // 
            // StretchCoefLabel
            // 
            this.StretchCoefLabel.AutoSize = true;
            this.StretchCoefLabel.Location = new System.Drawing.Point(983, 17);
            this.StretchCoefLabel.Name = "StretchCoefLabel";
            this.StretchCoefLabel.Size = new System.Drawing.Size(81, 20);
            this.StretchCoefLabel.TabIndex = 15;
            this.StretchCoefLabel.Text = "how much";
            // 
            // StretchButton
            // 
            this.StretchButton.Location = new System.Drawing.Point(868, 12);
            this.StretchButton.Name = "StretchButton";
            this.StretchButton.Size = new System.Drawing.Size(99, 82);
            this.StretchButton.TabIndex = 16;
            this.StretchButton.Text = "Stretch";
            this.StretchButton.UseVisualStyleBackColor = true;
            // 
            // StretchTB
            // 
            this.StretchTB.Location = new System.Drawing.Point(973, 40);
            this.StretchTB.Name = "StretchTB";
            this.StretchTB.Size = new System.Drawing.Size(100, 26);
            this.StretchTB.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1101, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 40);
            this.button1.TabIndex = 18;
            this.button1.Text = "Rotate line";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LineTB
            // 
            this.LineTB.Location = new System.Drawing.Point(1210, 19);
            this.LineTB.Name = "LineTB";
            this.LineTB.Size = new System.Drawing.Size(156, 26);
            this.LineTB.TabIndex = 19;
            // 
            // CollisButton
            // 
            this.CollisButton.Location = new System.Drawing.Point(1101, 58);
            this.CollisButton.Name = "CollisButton";
            this.CollisButton.Size = new System.Drawing.Size(265, 36);
            this.CollisButton.TabIndex = 20;
            this.CollisButton.Text = "Find collision";
            this.CollisButton.UseVisualStyleBackColor = true;
            // 
            // PointInsideButton
            // 
            this.PointInsideButton.Location = new System.Drawing.Point(11, 546);
            this.PointInsideButton.Name = "PointInsideButton";
            this.PointInsideButton.Size = new System.Drawing.Size(373, 76);
            this.PointInsideButton.TabIndex = 21;
            this.PointInsideButton.Text = "Point inside?";
            this.PointInsideButton.UseVisualStyleBackColor = true;
            // 
            // LinePointButton
            // 
            this.LinePointButton.Location = new System.Drawing.Point(11, 628);
            this.LinePointButton.Name = "LinePointButton";
            this.LinePointButton.Size = new System.Drawing.Size(373, 72);
            this.LinePointButton.TabIndex = 22;
            this.LinePointButton.Text = "Point to line";
            this.LinePointButton.UseVisualStyleBackColor = true;
            // 
            // PointLineTB
            // 
            this.PointLineTB.Location = new System.Drawing.Point(12, 706);
            this.PointLineTB.Name = "PointLineTB";
            this.PointLineTB.Size = new System.Drawing.Size(372, 26);
            this.PointLineTB.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 744);
            this.Controls.Add(this.PointLineTB);
            this.Controls.Add(this.LinePointButton);
            this.Controls.Add(this.PointInsideButton);
            this.Controls.Add(this.CollisButton);
            this.Controls.Add(this.LineTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StretchTB);
            this.Controls.Add(this.StretchButton);
            this.Controls.Add(this.StretchCoefLabel);
            this.Controls.Add(this.RAPLabel);
            this.Controls.Add(this.RAPTB);
            this.Controls.Add(this.RotatePointButton);
            this.Controls.Add(this.DYLabel);
            this.Controls.Add(this.DXLabel);
            this.Controls.Add(this.DYTB);
            this.Controls.Add(this.DXTB);
            this.Controls.Add(this.ShiftButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.FigName);
            this.Controls.Add(this.FigNames);
            this.Controls.Add(this.PolyButton);
            this.Controls.Add(this.LineButton);
            this.Controls.Add(this.DotButton);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.Button DotButton;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button PolyButton;
        private System.Windows.Forms.ListBox FigNames;
        private System.Windows.Forms.TextBox FigName;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ShiftButton;
        private System.Windows.Forms.TextBox DXTB;
        private System.Windows.Forms.TextBox DYTB;
        private System.Windows.Forms.Label DXLabel;
        private System.Windows.Forms.Label DYLabel;
        private System.Windows.Forms.Button RotatePointButton;
        private System.Windows.Forms.TextBox RAPTB;
        private System.Windows.Forms.Label RAPLabel;
        private System.Windows.Forms.Label StretchCoefLabel;
        private System.Windows.Forms.Button StretchButton;
        private System.Windows.Forms.TextBox StretchTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox LineTB;
        private System.Windows.Forms.Button CollisButton;
        private System.Windows.Forms.Button PointInsideButton;
        private System.Windows.Forms.Button LinePointButton;
        private System.Windows.Forms.TextBox PointLineTB;
    }
}

