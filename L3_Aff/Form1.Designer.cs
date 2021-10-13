
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
            this.StretchKX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LineTB = new System.Windows.Forms.TextBox();
            this.CollisButton = new System.Windows.Forms.Button();
            this.PointInsideButton = new System.Windows.Forms.Button();
            this.LinePointButton = new System.Windows.Forms.Button();
            this.PointLineTB = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.StretchKY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(348, 80);
            this.Canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(876, 517);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // DotButton
            // 
            this.DotButton.Location = new System.Drawing.Point(11, 10);
            this.DotButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DotButton.Name = "DotButton";
            this.DotButton.Size = new System.Drawing.Size(76, 32);
            this.DotButton.TabIndex = 1;
            this.DotButton.Text = "Dot";
            this.DotButton.UseVisualStyleBackColor = true;
            this.DotButton.Click += new System.EventHandler(this.DotButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(11, 43);
            this.LineButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(76, 32);
            this.LineButton.TabIndex = 2;
            this.LineButton.Text = "Line";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // PolyButton
            // 
            this.PolyButton.Location = new System.Drawing.Point(92, 10);
            this.PolyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PolyButton.Name = "PolyButton";
            this.PolyButton.Size = new System.Drawing.Size(114, 66);
            this.PolyButton.TabIndex = 3;
            this.PolyButton.Text = "Polygon";
            this.PolyButton.UseVisualStyleBackColor = true;
            this.PolyButton.Click += new System.EventHandler(this.PolyButton_Click);
            // 
            // FigNames
            // 
            this.FigNames.FormattingEnabled = true;
            this.FigNames.ItemHeight = 16;
            this.FigNames.Location = new System.Drawing.Point(11, 113);
            this.FigNames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FigNames.Name = "FigNames";
            this.FigNames.Size = new System.Drawing.Size(333, 308);
            this.FigNames.TabIndex = 4;
            this.FigNames.SelectedIndexChanged += new System.EventHandler(this.FigNames_SelectedIndexChanged);
            // 
            // FigName
            // 
            this.FigName.Location = new System.Drawing.Point(11, 80);
            this.FigName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FigName.Name = "FigName";
            this.FigName.Size = new System.Drawing.Size(332, 22);
            this.FigName.TabIndex = 5;
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.SystemColors.Control;
            this.ClearButton.Location = new System.Drawing.Point(212, 10);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(131, 66);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(348, 10);
            this.ShiftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(74, 66);
            this.ShiftButton.TabIndex = 7;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            this.ShiftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // DXTB
            // 
            this.DXTB.Location = new System.Drawing.Point(461, 15);
            this.DXTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DXTB.Name = "DXTB";
            this.DXTB.Size = new System.Drawing.Size(53, 22);
            this.DXTB.TabIndex = 8;
            // 
            // DYTB
            // 
            this.DYTB.Location = new System.Drawing.Point(461, 49);
            this.DYTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DYTB.Name = "DYTB";
            this.DYTB.Size = new System.Drawing.Size(53, 22);
            this.DYTB.TabIndex = 9;
            // 
            // DXLabel
            // 
            this.DXLabel.AutoSize = true;
            this.DXLabel.Location = new System.Drawing.Point(434, 18);
            this.DXLabel.Name = "DXLabel";
            this.DXLabel.Size = new System.Drawing.Size(22, 17);
            this.DXLabel.TabIndex = 10;
            this.DXLabel.Text = "dx";
            // 
            // DYLabel
            // 
            this.DYLabel.AutoSize = true;
            this.DYLabel.Location = new System.Drawing.Point(434, 51);
            this.DYLabel.Name = "DYLabel";
            this.DYLabel.Size = new System.Drawing.Size(23, 17);
            this.DYLabel.TabIndex = 11;
            this.DYLabel.Text = "dy";
            // 
            // RotatePointButton
            // 
            this.RotatePointButton.Location = new System.Drawing.Point(532, 14);
            this.RotatePointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RotatePointButton.Name = "RotatePointButton";
            this.RotatePointButton.Size = new System.Drawing.Size(157, 28);
            this.RotatePointButton.TabIndex = 12;
            this.RotatePointButton.Text = "Rotate around point";
            this.RotatePointButton.UseVisualStyleBackColor = true;
            // 
            // RAPTB
            // 
            this.RAPTB.Location = new System.Drawing.Point(700, 44);
            this.RAPTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RAPTB.Name = "RAPTB";
            this.RAPTB.Size = new System.Drawing.Size(64, 22);
            this.RAPTB.TabIndex = 13;
            // 
            // RAPLabel
            // 
            this.RAPLabel.AutoSize = true;
            this.RAPLabel.Location = new System.Drawing.Point(711, 18);
            this.RAPLabel.Name = "RAPLabel";
            this.RAPLabel.Size = new System.Drawing.Size(43, 17);
            this.RAPLabel.TabIndex = 14;
            this.RAPLabel.Text = "angle";
            // 
            // StretchCoefLabel
            // 
            this.StretchCoefLabel.AutoSize = true;
            this.StretchCoefLabel.Location = new System.Drawing.Point(967, 18);
            this.StretchCoefLabel.Name = "StretchCoefLabel";
            this.StretchCoefLabel.Size = new System.Drawing.Size(71, 17);
            this.StretchCoefLabel.TabIndex = 15;
            this.StretchCoefLabel.Text = "how much";
            // 
            // StretchButton
            // 
            this.StretchButton.Location = new System.Drawing.Point(779, 15);
            this.StretchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchButton.Name = "StretchButton";
            this.StretchButton.Size = new System.Drawing.Size(164, 25);
            this.StretchButton.TabIndex = 16;
            this.StretchButton.Text = "Stretch around point";
            this.StretchButton.UseVisualStyleBackColor = true;
            // 
            // StretchKX
            // 
            this.StretchKX.Location = new System.Drawing.Point(970, 51);
            this.StretchKX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchKX.Name = "StretchKX";
            this.StretchKX.Size = new System.Drawing.Size(33, 22);
            this.StretchKX.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1051, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Rotate line";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LineTB
            // 
            this.LineTB.Location = new System.Drawing.Point(1146, 15);
            this.LineTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LineTB.Name = "LineTB";
            this.LineTB.Size = new System.Drawing.Size(69, 22);
            this.LineTB.TabIndex = 19;
            // 
            // CollisButton
            // 
            this.CollisButton.Location = new System.Drawing.Point(1051, 46);
            this.CollisButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CollisButton.Name = "CollisButton";
            this.CollisButton.Size = new System.Drawing.Size(164, 29);
            this.CollisButton.TabIndex = 20;
            this.CollisButton.Text = "Find collision";
            this.CollisButton.UseVisualStyleBackColor = true;
            // 
            // PointInsideButton
            // 
            this.PointInsideButton.Location = new System.Drawing.Point(10, 437);
            this.PointInsideButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointInsideButton.Name = "PointInsideButton";
            this.PointInsideButton.Size = new System.Drawing.Size(332, 61);
            this.PointInsideButton.TabIndex = 21;
            this.PointInsideButton.Text = "Point inside?";
            this.PointInsideButton.UseVisualStyleBackColor = true;
            this.PointInsideButton.Click += new System.EventHandler(this.PointInsideButton_Click);
            // 
            // LinePointButton
            // 
            this.LinePointButton.Location = new System.Drawing.Point(10, 502);
            this.LinePointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LinePointButton.Name = "LinePointButton";
            this.LinePointButton.Size = new System.Drawing.Size(332, 58);
            this.LinePointButton.TabIndex = 22;
            this.LinePointButton.Text = "Point to line";
            this.LinePointButton.UseVisualStyleBackColor = true;
            this.LinePointButton.Click += new System.EventHandler(this.LinePointButton_Click);
            // 
            // PointLineTB
            // 
            this.PointLineTB.Location = new System.Drawing.Point(11, 565);
            this.PointLineTB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointLineTB.Name = "PointLineTB";
            this.PointLineTB.Size = new System.Drawing.Size(331, 22);
            this.PointLineTB.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 27);
            this.button2.TabIndex = 24;
            this.button2.Text = "Rotate around center";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(779, 48);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 25);
            this.button3.TabIndex = 25;
            this.button3.Text = "Stretch around center";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StretchKY
            // 
            this.StretchKY.Location = new System.Drawing.Point(1009, 51);
            this.StretchKY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StretchKY.Name = "StretchKY";
            this.StretchKY.Size = new System.Drawing.Size(33, 22);
            this.StretchKY.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(978, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1018, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 595);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StretchKY);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PointLineTB);
            this.Controls.Add(this.LinePointButton);
            this.Controls.Add(this.PointInsideButton);
            this.Controls.Add(this.CollisButton);
            this.Controls.Add(this.LineTB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.StretchKX);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.TextBox StretchKX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox LineTB;
        private System.Windows.Forms.Button CollisButton;
        private System.Windows.Forms.Button PointInsideButton;
        private System.Windows.Forms.Button LinePointButton;
        private System.Windows.Forms.TextBox PointLineTB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox StretchKY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

