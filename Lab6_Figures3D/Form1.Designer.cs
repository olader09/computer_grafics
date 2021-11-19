
namespace Lab6_Figures3D
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.TransformGroup = new System.Windows.Forms.GroupBox();
            this.RotateButton = new System.Windows.Forms.Button();
            this.ShiftButton = new System.Windows.Forms.Button();
            this.ScaleButton = new System.Windows.Forms.Button();
            this.ReflectButton = new System.Windows.Forms.Button();
            this.CoefGB = new System.Windows.Forms.GroupBox();
            this.LabelAngle = new System.Windows.Forms.Label();
            this.LabelScale = new System.Windows.Forms.Label();
            this.NumericAngle = new System.Windows.Forms.NumericUpDown();
            this.NumericScale = new System.Windows.Forms.NumericUpDown();
            this.FlatGB = new System.Windows.Forms.GroupBox();
            this.LabelFlatP2 = new System.Windows.Forms.Label();
            this.LabelFlatP1 = new System.Windows.Forms.Label();
            this.FlatTBP2 = new System.Windows.Forms.TextBox();
            this.FlatTBP1 = new System.Windows.Forms.TextBox();
            this.LineGB = new System.Windows.Forms.GroupBox();
            this.LabelLineP2 = new System.Windows.Forms.Label();
            this.LabelLineP1 = new System.Windows.Forms.Label();
            this.LineTBP2 = new System.Windows.Forms.TextBox();
            this.LineTBP1 = new System.Windows.Forms.TextBox();
            this.PointGB = new System.Windows.Forms.GroupBox();
            this.NumericRotationSplitCount = new System.Windows.Forms.NumericUpDown();
            this.BuildRotationFigureButton = new System.Windows.Forms.Button();
            this.richPointsTB = new System.Windows.Forms.RichTextBox();
            this.LabelPointZ = new System.Windows.Forms.Label();
            this.LabelPointY = new System.Windows.Forms.Label();
            this.LabelPointX = new System.Windows.Forms.Label();
            this.NumericPointZ = new System.Windows.Forms.NumericUpDown();
            this.NumericPointY = new System.Windows.Forms.NumericUpDown();
            this.NumericPointX = new System.Windows.Forms.NumericUpDown();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SceneFiguresList = new System.Windows.Forms.ListBox();
            this.AddFigureButton = new System.Windows.Forms.Button();
            this.CameraGroup = new System.Windows.Forms.GroupBox();
            this.MoveRightButton = new System.Windows.Forms.Button();
            this.MoveLeftButton = new System.Windows.Forms.Button();
            this.Focus = new System.Windows.Forms.NumericUpDown();
            this.ScreenHeight = new System.Windows.Forms.NumericUpDown();
            this.ScreenWidth = new System.Windows.Forms.NumericUpDown();
            this.ProjectionButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.TurnDownButton = new System.Windows.Forms.Button();
            this.TurnUpButton = new System.Windows.Forms.Button();
            this.TurnRightButton = new System.Windows.Forms.Button();
            this.TurnLeftButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.BackwardButton = new System.Windows.Forms.Button();
            this.FocusLabel = new System.Windows.Forms.Label();
            this.ScreenParamsLabel = new System.Windows.Forms.Label();
            this.FigureCenter = new System.Windows.Forms.Label();
            this.GraphGB = new System.Windows.Forms.GroupBox();
            this.DeltaYLabel = new System.Windows.Forms.Label();
            this.DeltaXLabel = new System.Windows.Forms.Label();
            this.DeltaYTB = new System.Windows.Forms.TextBox();
            this.DeltaXTB = new System.Windows.Forms.TextBox();
            this.FunctionCB = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.TransformGroup.SuspendLayout();
            this.CoefGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericScale)).BeginInit();
            this.FlatGB.SuspendLayout();
            this.LineGB.SuspendLayout();
            this.PointGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRotationSplitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointX)).BeginInit();
            this.CameraGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Focus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenWidth)).BeginInit();
            this.GraphGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(624, 102);
            this.Canvas.Margin = new System.Windows.Forms.Padding(2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(746, 588);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // TransformGroup
            // 
            this.TransformGroup.Controls.Add(this.RotateButton);
            this.TransformGroup.Controls.Add(this.ShiftButton);
            this.TransformGroup.Controls.Add(this.ScaleButton);
            this.TransformGroup.Controls.Add(this.ReflectButton);
            this.TransformGroup.Controls.Add(this.CoefGB);
            this.TransformGroup.Controls.Add(this.FlatGB);
            this.TransformGroup.Controls.Add(this.LineGB);
            this.TransformGroup.Controls.Add(this.PointGB);
            this.TransformGroup.Location = new System.Drawing.Point(318, 12);
            this.TransformGroup.Margin = new System.Windows.Forms.Padding(2);
            this.TransformGroup.Name = "TransformGroup";
            this.TransformGroup.Padding = new System.Windows.Forms.Padding(2);
            this.TransformGroup.Size = new System.Drawing.Size(300, 678);
            this.TransformGroup.TabIndex = 2;
            this.TransformGroup.TabStop = false;
            this.TransformGroup.Text = "Transform";
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(152, 622);
            this.RotateButton.Margin = new System.Windows.Forms.Padding(2);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(141, 49);
            this.RotateButton.TabIndex = 10;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(6, 566);
            this.ShiftButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(140, 49);
            this.ShiftButton.TabIndex = 9;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            this.ShiftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ScaleButton
            // 
            this.ScaleButton.Location = new System.Drawing.Point(150, 566);
            this.ScaleButton.Margin = new System.Windows.Forms.Padding(2);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(141, 49);
            this.ScaleButton.TabIndex = 8;
            this.ScaleButton.Text = "Scale";
            this.ScaleButton.UseVisualStyleBackColor = true;
            this.ScaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // ReflectButton
            // 
            this.ReflectButton.Location = new System.Drawing.Point(6, 622);
            this.ReflectButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReflectButton.Name = "ReflectButton";
            this.ReflectButton.Size = new System.Drawing.Size(140, 49);
            this.ReflectButton.TabIndex = 7;
            this.ReflectButton.Text = "Reflect";
            this.ReflectButton.UseVisualStyleBackColor = true;
            this.ReflectButton.Click += new System.EventHandler(this.ReflectButton_Click);
            // 
            // CoefGB
            // 
            this.CoefGB.Controls.Add(this.LabelAngle);
            this.CoefGB.Controls.Add(this.LabelScale);
            this.CoefGB.Controls.Add(this.NumericAngle);
            this.CoefGB.Controls.Add(this.NumericScale);
            this.CoefGB.Location = new System.Drawing.Point(8, 464);
            this.CoefGB.Margin = new System.Windows.Forms.Padding(2);
            this.CoefGB.Name = "CoefGB";
            this.CoefGB.Padding = new System.Windows.Forms.Padding(2);
            this.CoefGB.Size = new System.Drawing.Size(288, 98);
            this.CoefGB.TabIndex = 6;
            this.CoefGB.TabStop = false;
            this.CoefGB.Text = "Coefficients";
            // 
            // LabelAngle
            // 
            this.LabelAngle.AutoSize = true;
            this.LabelAngle.Location = new System.Drawing.Point(184, 65);
            this.LabelAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelAngle.Name = "LabelAngle";
            this.LabelAngle.Size = new System.Drawing.Size(58, 25);
            this.LabelAngle.TabIndex = 3;
            this.LabelAngle.Text = "Angle";
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(22, 65);
            this.LabelScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(91, 25);
            this.LabelScale.TabIndex = 2;
            this.LabelScale.Text = "Scale coef";
            // 
            // NumericAngle
            // 
            this.NumericAngle.Location = new System.Drawing.Point(146, 31);
            this.NumericAngle.Margin = new System.Windows.Forms.Padding(2);
            this.NumericAngle.Name = "NumericAngle";
            this.NumericAngle.Size = new System.Drawing.Size(135, 31);
            this.NumericAngle.TabIndex = 1;
            // 
            // NumericScale
            // 
            this.NumericScale.Location = new System.Drawing.Point(8, 31);
            this.NumericScale.Margin = new System.Windows.Forms.Padding(2);
            this.NumericScale.Name = "NumericScale";
            this.NumericScale.Size = new System.Drawing.Size(132, 31);
            this.NumericScale.TabIndex = 0;
            // 
            // FlatGB
            // 
            this.FlatGB.Controls.Add(this.LabelFlatP2);
            this.FlatGB.Controls.Add(this.LabelFlatP1);
            this.FlatGB.Controls.Add(this.FlatTBP2);
            this.FlatGB.Controls.Add(this.FlatTBP1);
            this.FlatGB.Location = new System.Drawing.Point(8, 358);
            this.FlatGB.Margin = new System.Windows.Forms.Padding(2);
            this.FlatGB.Name = "FlatGB";
            this.FlatGB.Padding = new System.Windows.Forms.Padding(2);
            this.FlatGB.Size = new System.Drawing.Size(288, 102);
            this.FlatGB.TabIndex = 4;
            this.FlatGB.TabStop = false;
            this.FlatGB.Text = "Flat";
            // 
            // LabelFlatP2
            // 
            this.LabelFlatP2.AutoSize = true;
            this.LabelFlatP2.Location = new System.Drawing.Point(176, 68);
            this.LabelFlatP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelFlatP2.Name = "LabelFlatP2";
            this.LabelFlatP2.Size = new System.Drawing.Size(68, 25);
            this.LabelFlatP2.TabIndex = 4;
            this.LabelFlatP2.Text = "normal";
            // 
            // LabelFlatP1
            // 
            this.LabelFlatP1.AutoSize = true;
            this.LabelFlatP1.Location = new System.Drawing.Point(62, 68);
            this.LabelFlatP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelFlatP1.Name = "LabelFlatP1";
            this.LabelFlatP1.Size = new System.Drawing.Size(32, 25);
            this.LabelFlatP1.TabIndex = 3;
            this.LabelFlatP1.Text = "P1";
            // 
            // FlatTBP2
            // 
            this.FlatTBP2.Location = new System.Drawing.Point(148, 31);
            this.FlatTBP2.Margin = new System.Windows.Forms.Padding(2);
            this.FlatTBP2.Name = "FlatTBP2";
            this.FlatTBP2.Size = new System.Drawing.Size(130, 31);
            this.FlatTBP2.TabIndex = 1;
            this.FlatTBP2.Text = "0 1 0";
            // 
            // FlatTBP1
            // 
            this.FlatTBP1.Location = new System.Drawing.Point(8, 31);
            this.FlatTBP1.Margin = new System.Windows.Forms.Padding(2);
            this.FlatTBP1.Name = "FlatTBP1";
            this.FlatTBP1.Size = new System.Drawing.Size(134, 31);
            this.FlatTBP1.TabIndex = 0;
            this.FlatTBP1.Text = "1 0 0";
            // 
            // LineGB
            // 
            this.LineGB.Controls.Add(this.LabelLineP2);
            this.LineGB.Controls.Add(this.LabelLineP1);
            this.LineGB.Controls.Add(this.LineTBP2);
            this.LineGB.Controls.Add(this.LineTBP1);
            this.LineGB.Location = new System.Drawing.Point(8, 256);
            this.LineGB.Margin = new System.Windows.Forms.Padding(2);
            this.LineGB.Name = "LineGB";
            this.LineGB.Padding = new System.Windows.Forms.Padding(2);
            this.LineGB.Size = new System.Drawing.Size(288, 98);
            this.LineGB.TabIndex = 1;
            this.LineGB.TabStop = false;
            this.LineGB.Text = "Line";
            // 
            // LabelLineP2
            // 
            this.LabelLineP2.AutoSize = true;
            this.LabelLineP2.Location = new System.Drawing.Point(192, 65);
            this.LabelLineP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLineP2.Name = "LabelLineP2";
            this.LabelLineP2.Size = new System.Drawing.Size(32, 25);
            this.LabelLineP2.TabIndex = 3;
            this.LabelLineP2.Text = "P2";
            // 
            // LabelLineP1
            // 
            this.LabelLineP1.AutoSize = true;
            this.LabelLineP1.Location = new System.Drawing.Point(60, 65);
            this.LabelLineP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLineP1.Name = "LabelLineP1";
            this.LabelLineP1.Size = new System.Drawing.Size(32, 25);
            this.LabelLineP1.TabIndex = 2;
            this.LabelLineP1.Text = "P1";
            // 
            // LineTBP2
            // 
            this.LineTBP2.Location = new System.Drawing.Point(146, 31);
            this.LineTBP2.Margin = new System.Windows.Forms.Padding(2);
            this.LineTBP2.Name = "LineTBP2";
            this.LineTBP2.Size = new System.Drawing.Size(135, 31);
            this.LineTBP2.TabIndex = 1;
            this.LineTBP2.Text = "2 2 2";
            // 
            // LineTBP1
            // 
            this.LineTBP1.Location = new System.Drawing.Point(8, 31);
            this.LineTBP1.Margin = new System.Windows.Forms.Padding(2);
            this.LineTBP1.Name = "LineTBP1";
            this.LineTBP1.Size = new System.Drawing.Size(132, 31);
            this.LineTBP1.TabIndex = 0;
            this.LineTBP1.Text = "1 1 1";
            // 
            // PointGB
            // 
            this.PointGB.Controls.Add(this.NumericRotationSplitCount);
            this.PointGB.Controls.Add(this.BuildRotationFigureButton);
            this.PointGB.Controls.Add(this.richPointsTB);
            this.PointGB.Controls.Add(this.LabelPointZ);
            this.PointGB.Controls.Add(this.LabelPointY);
            this.PointGB.Controls.Add(this.LabelPointX);
            this.PointGB.Controls.Add(this.NumericPointZ);
            this.PointGB.Controls.Add(this.NumericPointY);
            this.PointGB.Controls.Add(this.NumericPointX);
            this.PointGB.Location = new System.Drawing.Point(8, 25);
            this.PointGB.Margin = new System.Windows.Forms.Padding(2);
            this.PointGB.Name = "PointGB";
            this.PointGB.Padding = new System.Windows.Forms.Padding(2);
            this.PointGB.Size = new System.Drawing.Size(288, 228);
            this.PointGB.TabIndex = 0;
            this.PointGB.TabStop = false;
            this.PointGB.Text = "Point";
            // 
            // NumericRotationSplitCount
            // 
            this.NumericRotationSplitCount.Location = new System.Drawing.Point(158, 96);
            this.NumericRotationSplitCount.Margin = new System.Windows.Forms.Padding(2);
            this.NumericRotationSplitCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NumericRotationSplitCount.Name = "NumericRotationSplitCount";
            this.NumericRotationSplitCount.Size = new System.Drawing.Size(122, 31);
            this.NumericRotationSplitCount.TabIndex = 8;
            this.NumericRotationSplitCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // BuildRotationFigureButton
            // 
            this.BuildRotationFigureButton.Location = new System.Drawing.Point(158, 136);
            this.BuildRotationFigureButton.Margin = new System.Windows.Forms.Padding(2);
            this.BuildRotationFigureButton.Name = "BuildRotationFigureButton";
            this.BuildRotationFigureButton.Size = new System.Drawing.Size(122, 86);
            this.BuildRotationFigureButton.TabIndex = 7;
            this.BuildRotationFigureButton.Text = "Build Rotation";
            this.BuildRotationFigureButton.UseVisualStyleBackColor = true;
            this.BuildRotationFigureButton.Click += new System.EventHandler(this.BuildRotationFigureButton_Click);
            // 
            // richPointsTB
            // 
            this.richPointsTB.Location = new System.Drawing.Point(8, 96);
            this.richPointsTB.Margin = new System.Windows.Forms.Padding(2);
            this.richPointsTB.Name = "richPointsTB";
            this.richPointsTB.Size = new System.Drawing.Size(143, 126);
            this.richPointsTB.TabIndex = 6;
            this.richPointsTB.Text = "";
            this.richPointsTB.TextChanged += new System.EventHandler(this.richPointsTB_TextChanged);
            // 
            // LabelPointZ
            // 
            this.LabelPointZ.AutoSize = true;
            this.LabelPointZ.Location = new System.Drawing.Point(220, 65);
            this.LabelPointZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointZ.Name = "LabelPointZ";
            this.LabelPointZ.Size = new System.Drawing.Size(22, 25);
            this.LabelPointZ.TabIndex = 5;
            this.LabelPointZ.Text = "Z";
            // 
            // LabelPointY
            // 
            this.LabelPointY.AutoSize = true;
            this.LabelPointY.Location = new System.Drawing.Point(129, 65);
            this.LabelPointY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointY.Name = "LabelPointY";
            this.LabelPointY.Size = new System.Drawing.Size(22, 25);
            this.LabelPointY.TabIndex = 4;
            this.LabelPointY.Text = "Y";
            // 
            // LabelPointX
            // 
            this.LabelPointX.AutoSize = true;
            this.LabelPointX.Location = new System.Drawing.Point(39, 65);
            this.LabelPointX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointX.Name = "LabelPointX";
            this.LabelPointX.Size = new System.Drawing.Size(23, 25);
            this.LabelPointX.TabIndex = 3;
            this.LabelPointX.Text = "X";
            // 
            // NumericPointZ
            // 
            this.NumericPointZ.Location = new System.Drawing.Point(192, 31);
            this.NumericPointZ.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointZ.Name = "NumericPointZ";
            this.NumericPointZ.Size = new System.Drawing.Size(88, 31);
            this.NumericPointZ.TabIndex = 2;
            // 
            // NumericPointY
            // 
            this.NumericPointY.Location = new System.Drawing.Point(102, 31);
            this.NumericPointY.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointY.Name = "NumericPointY";
            this.NumericPointY.Size = new System.Drawing.Size(84, 31);
            this.NumericPointY.TabIndex = 1;
            // 
            // NumericPointX
            // 
            this.NumericPointX.Location = new System.Drawing.Point(8, 31);
            this.NumericPointX.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointX.Name = "NumericPointX";
            this.NumericPointX.Size = new System.Drawing.Size(90, 31);
            this.NumericPointX.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(166, 12);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(145, 61);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.Clear_Click);
            // 
            // SceneFiguresList
            // 
            this.SceneFiguresList.FormattingEnabled = true;
            this.SceneFiguresList.ItemHeight = 25;
            this.SceneFiguresList.Location = new System.Drawing.Point(12, 78);
            this.SceneFiguresList.Margin = new System.Windows.Forms.Padding(2);
            this.SceneFiguresList.Name = "SceneFiguresList";
            this.SceneFiguresList.Size = new System.Drawing.Size(299, 179);
            this.SceneFiguresList.TabIndex = 4;
            this.SceneFiguresList.SelectedIndexChanged += new System.EventHandler(this.SceneFiguresList_SelectedIndexChanged);
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.Location = new System.Drawing.Point(12, 12);
            this.AddFigureButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(144, 61);
            this.AddFigureButton.TabIndex = 5;
            this.AddFigureButton.Text = "Add Figure";
            this.AddFigureButton.UseVisualStyleBackColor = true;
            this.AddFigureButton.Click += new System.EventHandler(this.AddFigureButton_Click);
            // 
            // CameraGroup
            // 
            this.CameraGroup.Controls.Add(this.MoveRightButton);
            this.CameraGroup.Controls.Add(this.MoveLeftButton);
            this.CameraGroup.Controls.Add(this.Focus);
            this.CameraGroup.Controls.Add(this.ScreenHeight);
            this.CameraGroup.Controls.Add(this.ScreenWidth);
            this.CameraGroup.Controls.Add(this.ProjectionButton);
            this.CameraGroup.Controls.Add(this.MoveDownButton);
            this.CameraGroup.Controls.Add(this.MoveUpButton);
            this.CameraGroup.Controls.Add(this.TurnDownButton);
            this.CameraGroup.Controls.Add(this.TurnUpButton);
            this.CameraGroup.Controls.Add(this.TurnRightButton);
            this.CameraGroup.Controls.Add(this.TurnLeftButton);
            this.CameraGroup.Controls.Add(this.ForwardButton);
            this.CameraGroup.Controls.Add(this.BackwardButton);
            this.CameraGroup.Controls.Add(this.FocusLabel);
            this.CameraGroup.Controls.Add(this.ScreenParamsLabel);
            this.CameraGroup.Location = new System.Drawing.Point(12, 338);
            this.CameraGroup.Margin = new System.Windows.Forms.Padding(2);
            this.CameraGroup.Name = "CameraGroup";
            this.CameraGroup.Padding = new System.Windows.Forms.Padding(2);
            this.CameraGroup.Size = new System.Drawing.Size(300, 352);
            this.CameraGroup.TabIndex = 6;
            this.CameraGroup.TabStop = false;
            this.CameraGroup.Text = "Camera";
            // 
            // MoveRightButton
            // 
            this.MoveRightButton.Location = new System.Drawing.Point(202, 151);
            this.MoveRightButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveRightButton.Name = "MoveRightButton";
            this.MoveRightButton.Size = new System.Drawing.Size(91, 42);
            this.MoveRightButton.TabIndex = 18;
            this.MoveRightButton.Text = "Right";
            this.MoveRightButton.UseVisualStyleBackColor = true;
            this.MoveRightButton.Click += new System.EventHandler(this.MoveRightButton_Click);
            // 
            // MoveLeftButton
            // 
            this.MoveLeftButton.Location = new System.Drawing.Point(202, 106);
            this.MoveLeftButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveLeftButton.Name = "MoveLeftButton";
            this.MoveLeftButton.Size = new System.Drawing.Size(91, 42);
            this.MoveLeftButton.TabIndex = 17;
            this.MoveLeftButton.Text = "Left";
            this.MoveLeftButton.UseVisualStyleBackColor = true;
            this.MoveLeftButton.Click += new System.EventHandler(this.MoveLeftButton_Click);
            // 
            // Focus
            // 
            this.Focus.Location = new System.Drawing.Point(151, 69);
            this.Focus.Margin = new System.Windows.Forms.Padding(2);
            this.Focus.Name = "Focus";
            this.Focus.Size = new System.Drawing.Size(142, 31);
            this.Focus.TabIndex = 16;
            this.Focus.ValueChanged += new System.EventHandler(this.Focus_ValueChanged);
            // 
            // ScreenHeight
            // 
            this.ScreenHeight.Location = new System.Drawing.Point(228, 31);
            this.ScreenHeight.Margin = new System.Windows.Forms.Padding(2);
            this.ScreenHeight.Name = "ScreenHeight";
            this.ScreenHeight.Size = new System.Drawing.Size(66, 31);
            this.ScreenHeight.TabIndex = 15;
            this.ScreenHeight.ValueChanged += new System.EventHandler(this.ScreenHeight_ValueChanged);
            // 
            // ScreenWidth
            // 
            this.ScreenWidth.Location = new System.Drawing.Point(151, 31);
            this.ScreenWidth.Margin = new System.Windows.Forms.Padding(2);
            this.ScreenWidth.Name = "ScreenWidth";
            this.ScreenWidth.Size = new System.Drawing.Size(68, 31);
            this.ScreenWidth.TabIndex = 14;
            this.ScreenWidth.ValueChanged += new System.EventHandler(this.ScreenWidth_ValueChanged);
            // 
            // ProjectionButton
            // 
            this.ProjectionButton.Location = new System.Drawing.Point(8, 296);
            this.ProjectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectionButton.Name = "ProjectionButton";
            this.ProjectionButton.Size = new System.Drawing.Size(285, 50);
            this.ProjectionButton.TabIndex = 13;
            this.ProjectionButton.Text = "Projection type : Parallel";
            this.ProjectionButton.UseVisualStyleBackColor = true;
            this.ProjectionButton.Click += new System.EventHandler(this.ProjectionButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(104, 151);
            this.MoveDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(92, 42);
            this.MoveDownButton.TabIndex = 12;
            this.MoveDownButton.Text = "Down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(104, 106);
            this.MoveUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(92, 42);
            this.MoveUpButton.TabIndex = 11;
            this.MoveUpButton.Text = "Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // TurnDownButton
            // 
            this.TurnDownButton.Location = new System.Drawing.Point(151, 248);
            this.TurnDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnDownButton.Name = "TurnDownButton";
            this.TurnDownButton.Size = new System.Drawing.Size(142, 41);
            this.TurnDownButton.TabIndex = 10;
            this.TurnDownButton.Text = "Turn Down";
            this.TurnDownButton.UseVisualStyleBackColor = true;
            this.TurnDownButton.Click += new System.EventHandler(this.TurnDownButton_Click);
            // 
            // TurnUpButton
            // 
            this.TurnUpButton.Location = new System.Drawing.Point(6, 248);
            this.TurnUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnUpButton.Name = "TurnUpButton";
            this.TurnUpButton.Size = new System.Drawing.Size(138, 41);
            this.TurnUpButton.TabIndex = 9;
            this.TurnUpButton.Text = "Turn Up";
            this.TurnUpButton.UseVisualStyleBackColor = true;
            this.TurnUpButton.Click += new System.EventHandler(this.TurnUpButton_Click);
            // 
            // TurnRightButton
            // 
            this.TurnRightButton.Location = new System.Drawing.Point(152, 201);
            this.TurnRightButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnRightButton.Name = "TurnRightButton";
            this.TurnRightButton.Size = new System.Drawing.Size(142, 41);
            this.TurnRightButton.TabIndex = 8;
            this.TurnRightButton.Text = "Turn Right";
            this.TurnRightButton.UseVisualStyleBackColor = true;
            this.TurnRightButton.Click += new System.EventHandler(this.TurnRightButton_Click);
            // 
            // TurnLeftButton
            // 
            this.TurnLeftButton.Location = new System.Drawing.Point(6, 201);
            this.TurnLeftButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnLeftButton.Name = "TurnLeftButton";
            this.TurnLeftButton.Size = new System.Drawing.Size(138, 41);
            this.TurnLeftButton.TabIndex = 7;
            this.TurnLeftButton.Text = "Turn Left";
            this.TurnLeftButton.UseVisualStyleBackColor = true;
            this.TurnLeftButton.Click += new System.EventHandler(this.TurnLeftButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Location = new System.Drawing.Point(8, 105);
            this.ForwardButton.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(92, 42);
            this.ForwardButton.TabIndex = 6;
            this.ForwardButton.Text = "Forward";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackwardButton
            // 
            this.BackwardButton.Location = new System.Drawing.Point(8, 151);
            this.BackwardButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(92, 42);
            this.BackwardButton.TabIndex = 5;
            this.BackwardButton.Text = "Back";
            this.BackwardButton.UseVisualStyleBackColor = true;
            this.BackwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
            // 
            // FocusLabel
            // 
            this.FocusLabel.AutoSize = true;
            this.FocusLabel.Location = new System.Drawing.Point(6, 70);
            this.FocusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FocusLabel.Name = "FocusLabel";
            this.FocusLabel.Size = new System.Drawing.Size(108, 25);
            this.FocusLabel.TabIndex = 4;
            this.FocusLabel.Text = "Focal length";
            // 
            // ScreenParamsLabel
            // 
            this.ScreenParamsLabel.AutoSize = true;
            this.ScreenParamsLabel.Location = new System.Drawing.Point(6, 32);
            this.ScreenParamsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScreenParamsLabel.Name = "ScreenParamsLabel";
            this.ScreenParamsLabel.Size = new System.Drawing.Size(128, 25);
            this.ScreenParamsLabel.TabIndex = 2;
            this.ScreenParamsLabel.Text = "Screen params";
            // 
            // FigureCenter
            // 
            this.FigureCenter.AutoSize = true;
            this.FigureCenter.Location = new System.Drawing.Point(12, 312);
            this.FigureCenter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FigureCenter.Name = "FigureCenter";
            this.FigureCenter.Size = new System.Drawing.Size(59, 25);
            this.FigureCenter.TabIndex = 7;
            this.FigureCenter.Text = "label1";
            // 
            // GraphGB
            // 
            this.GraphGB.Controls.Add(this.DeltaYLabel);
            this.GraphGB.Controls.Add(this.DeltaXLabel);
            this.GraphGB.Controls.Add(this.DeltaYTB);
            this.GraphGB.Controls.Add(this.DeltaXTB);
            this.GraphGB.Controls.Add(this.FunctionCB);
            this.GraphGB.Location = new System.Drawing.Point(624, 12);
            this.GraphGB.Margin = new System.Windows.Forms.Padding(2);
            this.GraphGB.Name = "GraphGB";
            this.GraphGB.Padding = new System.Windows.Forms.Padding(2);
            this.GraphGB.Size = new System.Drawing.Size(746, 84);
            this.GraphGB.TabIndex = 8;
            this.GraphGB.TabStop = false;
            this.GraphGB.Text = "Graph";
            // 
            // DeltaYLabel
            // 
            this.DeltaYLabel.AutoSize = true;
            this.DeltaYLabel.Location = new System.Drawing.Point(512, 34);
            this.DeltaYLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeltaYLabel.Name = "DeltaYLabel";
            this.DeltaYLabel.Size = new System.Drawing.Size(68, 25);
            this.DeltaYLabel.TabIndex = 4;
            this.DeltaYLabel.Text = "Delta Y";
            // 
            // DeltaXLabel
            // 
            this.DeltaXLabel.AutoSize = true;
            this.DeltaXLabel.Location = new System.Drawing.Point(268, 34);
            this.DeltaXLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeltaXLabel.Name = "DeltaXLabel";
            this.DeltaXLabel.Size = new System.Drawing.Size(69, 25);
            this.DeltaXLabel.TabIndex = 3;
            this.DeltaXLabel.Text = "Delta X";
            // 
            // DeltaYTB
            // 
            this.DeltaYTB.Location = new System.Drawing.Point(588, 31);
            this.DeltaYTB.Margin = new System.Windows.Forms.Padding(2);
            this.DeltaYTB.Name = "DeltaYTB";
            this.DeltaYTB.Size = new System.Drawing.Size(150, 31);
            this.DeltaYTB.TabIndex = 2;
            this.DeltaYTB.Text = "-5 5";
            // 
            // DeltaXTB
            // 
            this.DeltaXTB.Location = new System.Drawing.Point(342, 31);
            this.DeltaXTB.Margin = new System.Windows.Forms.Padding(2);
            this.DeltaXTB.Name = "DeltaXTB";
            this.DeltaXTB.Size = new System.Drawing.Size(150, 31);
            this.DeltaXTB.TabIndex = 1;
            this.DeltaXTB.Text = "-5 5";
            // 
            // FunctionCB
            // 
            this.FunctionCB.FormattingEnabled = true;
            this.FunctionCB.Location = new System.Drawing.Point(8, 31);
            this.FunctionCB.Margin = new System.Windows.Forms.Padding(2);
            this.FunctionCB.Name = "FunctionCB";
            this.FunctionCB.Size = new System.Drawing.Size(236, 33);
            this.FunctionCB.TabIndex = 0;
            this.FunctionCB.SelectedIndexChanged += new System.EventHandler(this.FunctionCB_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "RotateCam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 702);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.GraphGB);
            this.Controls.Add(this.FigureCenter);
            this.Controls.Add(this.CameraGroup);
            this.Controls.Add(this.AddFigureButton);
            this.Controls.Add(this.SceneFiguresList);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.TransformGroup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.TransformGroup.ResumeLayout(false);
            this.CoefGB.ResumeLayout(false);
            this.CoefGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericScale)).EndInit();
            this.FlatGB.ResumeLayout(false);
            this.FlatGB.PerformLayout();
            this.LineGB.ResumeLayout(false);
            this.LineGB.PerformLayout();
            this.PointGB.ResumeLayout(false);
            this.PointGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericRotationSplitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointX)).EndInit();
            this.CameraGroup.ResumeLayout(false);
            this.CameraGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Focus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenWidth)).EndInit();
            this.GraphGB.ResumeLayout(false);
            this.GraphGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.GroupBox TransformGroup;
        private System.Windows.Forms.ListBox SceneFiguresList;
        private System.Windows.Forms.Button AddFigureButton;
        private System.Windows.Forms.GroupBox CameraGroup;
        private System.Windows.Forms.Label FocusLabel;
        private System.Windows.Forms.Label ScreenParamsLabel;
        private System.Windows.Forms.Button TurnDownButton;
        private System.Windows.Forms.Button TurnUpButton;
        private System.Windows.Forms.Button TurnRightButton;
        private System.Windows.Forms.Button TurnLeftButton;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button BackwardButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button ProjectionButton;
        private System.Windows.Forms.NumericUpDown Focus;
        private System.Windows.Forms.NumericUpDown ScreenHeight;
        private System.Windows.Forms.NumericUpDown ScreenWidth;
        private System.Windows.Forms.GroupBox PointGB;
        private System.Windows.Forms.Label LabelPointZ;
        private System.Windows.Forms.Label LabelPointY;
        private System.Windows.Forms.Label LabelPointX;
        private System.Windows.Forms.NumericUpDown NumericPointZ;
        private System.Windows.Forms.NumericUpDown NumericPointY;
        private System.Windows.Forms.NumericUpDown NumericPointX;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button ShiftButton;
        private System.Windows.Forms.Button ScaleButton;
        private System.Windows.Forms.Button ReflectButton;
        private System.Windows.Forms.GroupBox CoefGB;
        private System.Windows.Forms.Label LabelAngle;
        private System.Windows.Forms.Label LabelScale;
        private System.Windows.Forms.NumericUpDown NumericAngle;
        private System.Windows.Forms.NumericUpDown NumericScale;
        private System.Windows.Forms.GroupBox FlatGB;
        private System.Windows.Forms.Label LabelFlatP2;
        private System.Windows.Forms.Label LabelFlatP1;
        private System.Windows.Forms.TextBox FlatTBP2;
        private System.Windows.Forms.TextBox FlatTBP1;
        private System.Windows.Forms.GroupBox LineGB;
        private System.Windows.Forms.Label LabelLineP2;
        private System.Windows.Forms.Label LabelLineP1;
        private System.Windows.Forms.TextBox LineTBP2;
        private System.Windows.Forms.TextBox LineTBP1;
        private System.Windows.Forms.Label FigureCenter;
        private System.Windows.Forms.Button MoveRightButton;
        private System.Windows.Forms.Button MoveLeftButton;
        private System.Windows.Forms.RichTextBox richPointsTB;
        private System.Windows.Forms.GroupBox GraphGB;
        private System.Windows.Forms.Label DeltaYLabel;
        private System.Windows.Forms.Label DeltaXLabel;
        private System.Windows.Forms.TextBox DeltaYTB;
        private System.Windows.Forms.TextBox DeltaXTB;
        private System.Windows.Forms.ComboBox FunctionCB;
        private System.Windows.Forms.NumericUpDown NumericRotationSplitCount;
        private System.Windows.Forms.Button BuildRotationFigureButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button button1;
    }
}

