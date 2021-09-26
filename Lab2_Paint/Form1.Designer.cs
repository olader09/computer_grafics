
namespace Lab2_Paint
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
            this.FFImage = new System.Windows.Forms.PictureBox();
            this.FFImageName = new System.Windows.Forms.TextBox();
            this.BrouseButton = new System.Windows.Forms.Button();
            this.Work = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFImage)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(384, 12);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(575, 612);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // FFImage
            // 
            this.FFImage.Location = new System.Drawing.Point(12, 320);
            this.FFImage.Name = "FFImage";
            this.FFImage.Size = new System.Drawing.Size(350, 171);
            this.FFImage.TabIndex = 1;
            this.FFImage.TabStop = false;
            // 
            // FFImageName
            // 
            this.FFImageName.Location = new System.Drawing.Point(12, 497);
            this.FFImageName.Name = "FFImageName";
            this.FFImageName.Size = new System.Drawing.Size(350, 26);
            this.FFImageName.TabIndex = 2;
            // 
            // BrouseButton
            // 
            this.BrouseButton.Location = new System.Drawing.Point(12, 529);
            this.BrouseButton.Name = "BrouseButton";
            this.BrouseButton.Size = new System.Drawing.Size(350, 95);
            this.BrouseButton.TabIndex = 3;
            this.BrouseButton.Text = "Brouse";
            this.BrouseButton.UseVisualStyleBackColor = true;
            // 
            // Work
            // 
            this.Work.FormattingEnabled = true;
            this.Work.Location = new System.Drawing.Point(188, 12);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(174, 28);
            this.Work.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "What to do";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 636);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Work);
            this.Controls.Add(this.BrouseButton);
            this.Controls.Add(this.FFImageName);
            this.Controls.Add(this.FFImage);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FFImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.PictureBox FFImage;
        private System.Windows.Forms.TextBox FFImageName;
        private System.Windows.Forms.Button BrouseButton;
        private System.Windows.Forms.ComboBox Work;
        private System.Windows.Forms.Label label1;
    }
}

