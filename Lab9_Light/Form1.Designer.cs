
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
            this.ZBufferRB = new System.Windows.Forms.RadioButton();
            this.FaceCarcassRB = new System.Windows.Forms.RadioButton();
            this.CarcassRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSize)).BeginInit();
            this.ProjectionGB.SuspendLayout();
            this.RenderingGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(249, 13);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(773, 615);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // SceneFigures
            // 
            this.SceneFigures.FormattingEnabled = true;
            this.SceneFigures.ItemHeight = 20;
            this.SceneFigures.Location = new System.Drawing.Point(13, 66);
            this.SceneFigures.Name = "SceneFigures";
            this.SceneFigures.Size = new System.Drawing.Size(230, 184);
            this.SceneFigures.TabIndex = 1;
            this.SceneFigures.SelectedIndexChanged += new System.EventHandler(this.SceneFigures_SelectedIndexChanged);
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.Location = new System.Drawing.Point(13, 13);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(230, 47);
            this.AddFigureButton.TabIndex = 2;
            this.AddFigureButton.Text = "Add Figure";
            this.AddFigureButton.UseVisualStyleBackColor = true;
            this.AddFigureButton.Click += new System.EventHandler(this.AddFigureButton_Click);
            // 
            // ActionLabel
            // 
            this.ActionLabel.AutoSize = true;
            this.ActionLabel.Location = new System.Drawing.Point(12, 253);
            this.ActionLabel.Name = "ActionLabel";
            this.ActionLabel.Size = new System.Drawing.Size(131, 20);
            this.ActionLabel.TabIndex = 3;
            this.ActionLabel.Text = "Action: No Action";
            // 
            // radioButtonParallel
            // 
            this.radioButtonParallel.AutoSize = true;
            this.radioButtonParallel.Location = new System.Drawing.Point(6, 25);
            this.radioButtonParallel.Name = "radioButtonParallel";
            this.radioButtonParallel.Size = new System.Drawing.Size(85, 24);
            this.radioButtonParallel.TabIndex = 5;
            this.radioButtonParallel.TabStop = true;
            this.radioButtonParallel.Text = "Parallel";
            this.radioButtonParallel.UseVisualStyleBackColor = true;
            this.radioButtonParallel.CheckedChanged += new System.EventHandler(this.radioButtonParallel_CheckedChanged);
            // 
            // radioButtonCentralP1
            // 
            this.radioButtonCentralP1.AutoSize = true;
            this.radioButtonCentralP1.Location = new System.Drawing.Point(6, 55);
            this.radioButtonCentralP1.Name = "radioButtonCentralP1";
            this.radioButtonCentralP1.Size = new System.Drawing.Size(108, 24);
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
            this.CamSize.Location = new System.Drawing.Point(6, 112);
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
            this.CamSize.Size = new System.Drawing.Size(120, 26);
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
            this.ProjectionGB.Location = new System.Drawing.Point(13, 277);
            this.ProjectionGB.Name = "ProjectionGB";
            this.ProjectionGB.Size = new System.Drawing.Size(230, 144);
            this.ProjectionGB.TabIndex = 8;
            this.ProjectionGB.TabStop = false;
            this.ProjectionGB.Text = "Projection";
            // 
            // RenderingGB
            // 
            this.RenderingGB.Controls.Add(this.ZBufferRB);
            this.RenderingGB.Controls.Add(this.FaceCarcassRB);
            this.RenderingGB.Controls.Add(this.CarcassRB);
            this.RenderingGB.Location = new System.Drawing.Point(13, 428);
            this.RenderingGB.Name = "RenderingGB";
            this.RenderingGB.Size = new System.Drawing.Size(230, 200);
            this.RenderingGB.TabIndex = 9;
            this.RenderingGB.TabStop = false;
            this.RenderingGB.Text = "Rendering";
            // 
            // ZBufferRB
            // 
            this.ZBufferRB.AutoSize = true;
            this.ZBufferRB.Location = new System.Drawing.Point(6, 88);
            this.ZBufferRB.Name = "ZBufferRB";
            this.ZBufferRB.Size = new System.Drawing.Size(93, 24);
            this.ZBufferRB.TabIndex = 2;
            this.ZBufferRB.TabStop = true;
            this.ZBufferRB.Text = "Z-Buffer";
            this.ZBufferRB.UseVisualStyleBackColor = true;
            this.ZBufferRB.CheckedChanged += new System.EventHandler(this.ZBufferRB_CheckedChanged);
            // 
            // FaceCarcassRB
            // 
            this.FaceCarcassRB.AutoSize = true;
            this.FaceCarcassRB.Location = new System.Drawing.Point(6, 57);
            this.FaceCarcassRB.Name = "FaceCarcassRB";
            this.FaceCarcassRB.Size = new System.Drawing.Size(132, 24);
            this.FaceCarcassRB.TabIndex = 1;
            this.FaceCarcassRB.TabStop = true;
            this.FaceCarcassRB.Text = "Face Carcass";
            this.FaceCarcassRB.UseVisualStyleBackColor = true;
            this.FaceCarcassRB.CheckedChanged += new System.EventHandler(this.FaceCarcassRB_CheckedChanged);
            // 
            // CarcassRB
            // 
            this.CarcassRB.AutoSize = true;
            this.CarcassRB.Location = new System.Drawing.Point(7, 26);
            this.CarcassRB.Name = "CarcassRB";
            this.CarcassRB.Size = new System.Drawing.Size(126, 24);
            this.CarcassRB.TabIndex = 0;
            this.CarcassRB.TabStop = true;
            this.CarcassRB.Text = "Just Carcass";
            this.CarcassRB.UseVisualStyleBackColor = true;
            this.CarcassRB.CheckedChanged += new System.EventHandler(this.CarcassRB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 640);
            this.Controls.Add(this.RenderingGB);
            this.Controls.Add(this.ProjectionGB);
            this.Controls.Add(this.ActionLabel);
            this.Controls.Add(this.AddFigureButton);
            this.Controls.Add(this.SceneFigures);
            this.Controls.Add(this.Canvas);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKey);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamSize)).EndInit();
            this.ProjectionGB.ResumeLayout(false);
            this.ProjectionGB.PerformLayout();
            this.RenderingGB.ResumeLayout(false);
            this.RenderingGB.PerformLayout();
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
    }
}

