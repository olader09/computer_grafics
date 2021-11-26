
namespace Room
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
            this.SceneFigures = new System.Windows.Forms.ListBox();
            this.AddFigureButton = new System.Windows.Forms.Button();
            this.ActionLabel = new System.Windows.Forms.Label();
            this.radioButtonParallel = new System.Windows.Forms.RadioButton();
            this.radioButtonCentralP1 = new System.Windows.Forms.RadioButton();
            this.CamSize = new System.Windows.Forms.NumericUpDown();
            this.ProjectionGB = new System.Windows.Forms.GroupBox();
            this.RenderingGB = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.HorizonRadioButton = new System.Windows.Forms.RadioButton();
            this.ShadeRadioButton = new System.Windows.Forms.RadioButton();
            this.ZBufferRB = new System.Windows.Forms.RadioButton();
            this.FaceCarcassRB = new System.Windows.Forms.RadioButton();
            this.CarcassRB = new System.Windows.Forms.RadioButton();
            this.NumericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDownZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSize)).BeginInit();
            this.ProjectionGB.SuspendLayout();
            this.RenderingGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownZ)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(221, 10);
            this.Canvas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(687, 492);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // SceneFigures
            // 
            this.SceneFigures.FormattingEnabled = true;
            this.SceneFigures.ItemHeight = 16;
            this.SceneFigures.Location = new System.Drawing.Point(12, 53);
            this.SceneFigures.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SceneFigures.Name = "SceneFigures";
            this.SceneFigures.Size = new System.Drawing.Size(205, 148);
            this.SceneFigures.TabIndex = 1;
            this.SceneFigures.SelectedIndexChanged += new System.EventHandler(this.SceneFigures_SelectedIndexChanged);
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.Location = new System.Drawing.Point(12, 10);
            this.AddFigureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(204, 38);
            this.AddFigureButton.TabIndex = 2;
            this.AddFigureButton.Text = "Add Figure";
            this.AddFigureButton.UseVisualStyleBackColor = true;
            this.AddFigureButton.Click += new System.EventHandler(this.AddFigureButton_Click);
            // 
            // ActionLabel
            // 
            this.ActionLabel.AutoSize = true;
            this.ActionLabel.Location = new System.Drawing.Point(11, 202);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(116, 17);
            this.ActionLabel.TabIndex = 3;
            this.ActionLabel.Text = "Action: No Action";
            // 
            // radioButtonParallel
            // 
            this.radioButtonParallel.AutoSize = true;
            this.radioButtonParallel.Location = new System.Drawing.Point(5, 20);
            this.radioButtonParallel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonParallel.Name = "radioButtonParallel";
            this.radioButtonParallel.Size = new System.Drawing.Size(76, 21);
            this.radioButtonParallel.TabIndex = 5;
            this.radioButtonParallel.TabStop = true;
            this.radioButtonParallel.Text = "Parallel";
            this.radioButtonParallel.UseVisualStyleBackColor = true;
            this.radioButtonParallel.CheckedChanged += new System.EventHandler(this.radioButtonParallel_CheckedChanged);
            // 
            // radioButtonCentralP1
            // 
            this.radioButtonCentralP1.AutoSize = true;
            this.radioButtonCentralP1.Location = new System.Drawing.Point(5, 44);
            this.radioButtonCentralP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonCentralP1.Name = "radioButtonCentralP1";
            this.radioButtonCentralP1.Size = new System.Drawing.Size(95, 21);
            this.radioButtonCentralP1.TabIndex = 6;
            this.radioButtonCentralP1.TabStop = true;
            this.radioButtonCentralP1.Text = "Central P1";
            this.radioButtonCentralP1.UseVisualStyleBackColor = true;
            this.radioButtonCentralP1.CheckedChanged += new System.EventHandler(this.radioButtonCentralP1_CheckedChanged);
            // 
            // CamSize
            // 
            this.CamSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CamSize.Location = new System.Drawing.Point(5, 90);
            this.CamSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CamSize.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.CamSize.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.CamSize.Name = "CamSize";
            this.CamSize.Size = new System.Drawing.Size(107, 22);
            this.CamSize.TabIndex = 7;
            this.CamSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.CamSize.ValueChanged += new System.EventHandler(this.CamSize_ValueChanged);
            // 
            // ProjectionGB
            // 
            this.ProjectionGB.Controls.Add(this.radioButtonParallel);
            this.ProjectionGB.Controls.Add(this.CamSize);
            this.ProjectionGB.Controls.Add(this.radioButtonCentralP1);
            this.ProjectionGB.Location = new System.Drawing.Point(12, 222);
            this.ProjectionGB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectionGB.Name = "ProjectionGB";
            this.ProjectionGB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProjectionGB.Size = new System.Drawing.Size(120, 115);
            this.ProjectionGB.TabIndex = 8;
            this.ProjectionGB.TabStop = false;
            this.ProjectionGB.Text = "Projection";
            // 
            // RenderingGB
            // 
            this.RenderingGB.Controls.Add(this.listBox1);
            this.RenderingGB.Controls.Add(this.HorizonRadioButton);
            this.RenderingGB.Controls.Add(this.ShadeRadioButton);
            this.RenderingGB.Controls.Add(this.ZBufferRB);
            this.RenderingGB.Controls.Add(this.FaceCarcassRB);
            this.RenderingGB.Controls.Add(this.CarcassRB);
            this.RenderingGB.Location = new System.Drawing.Point(12, 342);
            this.RenderingGB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RenderingGB.Name = "RenderingGB";
            this.RenderingGB.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RenderingGB.Size = new System.Drawing.Size(204, 160);
            this.RenderingGB.TabIndex = 9;
            this.RenderingGB.TabStop = false;
            this.RenderingGB.Text = "Rendering";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(85, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 84);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // HorizonRadioButton
            // 
            this.HorizonRadioButton.AutoSize = true;
            this.HorizonRadioButton.Location = new System.Drawing.Point(7, 122);
            this.HorizonRadioButton.Name = "HorizonRadioButton";
            this.HorizonRadioButton.Size = new System.Drawing.Size(78, 21);
            this.HorizonRadioButton.TabIndex = 4;
            this.HorizonRadioButton.TabStop = true;
            this.HorizonRadioButton.Text = "Horizon";
            this.HorizonRadioButton.UseVisualStyleBackColor = true;
            this.HorizonRadioButton.CheckedChanged += new System.EventHandler(this.HorizonRadioButton_CheckedChanged);
            // 
            // ShadeRadioButton
            // 
            this.ShadeRadioButton.AutoSize = true;
            this.ShadeRadioButton.Location = new System.Drawing.Point(6, 95);
            this.ShadeRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShadeRadioButton.Name = "ShadeRadioButton";
            this.ShadeRadioButton.Size = new System.Drawing.Size(70, 21);
            this.ShadeRadioButton.TabIndex = 3;
            this.ShadeRadioButton.TabStop = true;
            this.ShadeRadioButton.Text = "Shade";
            this.ShadeRadioButton.UseVisualStyleBackColor = true;
            this.ShadeRadioButton.CheckedChanged += new System.EventHandler(this.ShadeRadioButton_CheckedChanged);
            // 
            // ZBufferRB
            // 
            this.ZBufferRB.AutoSize = true;
            this.ZBufferRB.Location = new System.Drawing.Point(5, 70);
            this.ZBufferRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZBufferRB.Name = "ZBufferRB";
            this.ZBufferRB.Size = new System.Drawing.Size(81, 21);
            this.ZBufferRB.TabIndex = 2;
            this.ZBufferRB.TabStop = true;
            this.ZBufferRB.Text = "Z-Buffer";
            this.ZBufferRB.UseVisualStyleBackColor = true;
            this.ZBufferRB.CheckedChanged += new System.EventHandler(this.ZBufferRB_CheckedChanged);
            // 
            // FaceCarcassRB
            // 
            this.FaceCarcassRB.AutoSize = true;
            this.FaceCarcassRB.Location = new System.Drawing.Point(5, 46);
            this.FaceCarcassRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FaceCarcassRB.Name = "FaceCarcassRB";
            this.FaceCarcassRB.Size = new System.Drawing.Size(115, 21);
            this.FaceCarcassRB.TabIndex = 1;
            this.FaceCarcassRB.TabStop = true;
            this.FaceCarcassRB.Text = "Face Carcass";
            this.FaceCarcassRB.UseVisualStyleBackColor = true;
            this.FaceCarcassRB.CheckedChanged += new System.EventHandler(this.FaceCarcassRB_CheckedChanged);
            // 
            // CarcassRB
            // 
            this.CarcassRB.AutoSize = true;
            this.CarcassRB.Location = new System.Drawing.Point(6, 21);
            this.CarcassRB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarcassRB.Name = "CarcassRB";
            this.CarcassRB.Size = new System.Drawing.Size(110, 21);
            this.CarcassRB.TabIndex = 0;
            this.CarcassRB.TabStop = true;
            this.CarcassRB.Text = "Just Carcass";
            this.CarcassRB.UseVisualStyleBackColor = true;
            this.CarcassRB.CheckedChanged += new System.EventHandler(this.CarcassRB_CheckedChanged);
            // 
            // NumericUpDownX
            // 
            this.NumericUpDownX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumericUpDownX.Location = new System.Drawing.Point(138, 235);
            this.NumericUpDownX.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumericUpDownX.Name = "NumericUpDownX";
            this.NumericUpDownX.Size = new System.Drawing.Size(79, 22);
            this.NumericUpDownX.TabIndex = 10;
            this.NumericUpDownX.ValueChanged += new System.EventHandler(this.NumericUpDownX_ValueChanged);
            // 
            // NumericUpDownY
            // 
            this.NumericUpDownY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumericUpDownY.Location = new System.Drawing.Point(138, 263);
            this.NumericUpDownY.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumericUpDownY.Name = "NumericUpDownY";
            this.NumericUpDownY.Size = new System.Drawing.Size(79, 22);
            this.NumericUpDownY.TabIndex = 11;
            this.NumericUpDownY.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // NumericUpDownZ
            // 
            this.NumericUpDownZ.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumericUpDownZ.Location = new System.Drawing.Point(138, 291);
            this.NumericUpDownZ.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumericUpDownZ.Name = "NumericUpDownZ";
            this.NumericUpDownZ.Size = new System.Drawing.Size(79, 22);
            this.NumericUpDownZ.TabIndex = 12;
            this.NumericUpDownZ.ValueChanged += new System.EventHandler(this.NumericUpDownZ_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 512);
            this.Controls.Add(this.NumericUpDownZ);
            this.Controls.Add(this.NumericUpDownY);
            this.Controls.Add(this.NumericUpDownX);
            this.Controls.Add(this.RenderingGB);
            this.Controls.Add(this.ProjectionGB);
            this.Controls.Add(this.ActionLabel);
            this.Controls.Add(this.AddFigureButton);
            this.Controls.Add(this.SceneFigures);
            this.Controls.Add(this.Canvas);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKey);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSize)).EndInit();
            this.ProjectionGB.ResumeLayout(false);
            this.ProjectionGB.PerformLayout();
            this.RenderingGB.ResumeLayout(false);
            this.RenderingGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.ListBox SceneFigures;
        private System.Windows.Forms.Button AddFigureButton;
        private System.Windows.Forms.Label ActionLabel;
        private System.Windows.Forms.RadioButton radioButtonParallel;
        private System.Windows.Forms.RadioButton radioButtonCentralP1;
        private System.Windows.Forms.NumericUpDown CamSize;
        private System.Windows.Forms.GroupBox ProjectionGB;
        private System.Windows.Forms.GroupBox RenderingGB;
        private System.Windows.Forms.RadioButton ZBufferRB;
        private System.Windows.Forms.RadioButton FaceCarcassRB;
        private System.Windows.Forms.RadioButton CarcassRB;
        private System.Windows.Forms.RadioButton ShadeRadioButton;
        private System.Windows.Forms.RadioButton HorizonRadioButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.NumericUpDown NumericUpDownX;
        private System.Windows.Forms.NumericUpDown NumericUpDownY;
        private System.Windows.Forms.NumericUpDown NumericUpDownZ;
    }
}

