﻿
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
            this.LabelFlatP3 = new System.Windows.Forms.Label();
            this.LabelFlatP2 = new System.Windows.Forms.Label();
            this.LabelFlatP1 = new System.Windows.Forms.Label();
            this.FlatTBP3 = new System.Windows.Forms.TextBox();
            this.FlatTBP2 = new System.Windows.Forms.TextBox();
            this.FlatTBP1 = new System.Windows.Forms.TextBox();
            this.LineGB = new System.Windows.Forms.GroupBox();
            this.LabelLineP2 = new System.Windows.Forms.Label();
            this.LabelLineP1 = new System.Windows.Forms.Label();
            this.LineTBP2 = new System.Windows.Forms.TextBox();
            this.LineTBP1 = new System.Windows.Forms.TextBox();
            this.PointGB = new System.Windows.Forms.GroupBox();
            this.LabelPointZ = new System.Windows.Forms.Label();
            this.LabelPointY = new System.Windows.Forms.Label();
            this.LabelPointX = new System.Windows.Forms.Label();
            this.NumericPointZ = new System.Windows.Forms.NumericUpDown();
            this.NumericPointY = new System.Windows.Forms.NumericUpDown();
            this.NumericPointX = new System.Windows.Forms.NumericUpDown();
            this.FiguresList = new System.Windows.Forms.ComboBox();
            this.SceneFiguresList = new System.Windows.Forms.ListBox();
            this.AddFigureButton = new System.Windows.Forms.Button();
            this.CameraGroup = new System.Windows.Forms.GroupBox();
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
            this.ShiftGB = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShiftZ = new System.Windows.Forms.NumericUpDown();
            this.ShiftY = new System.Windows.Forms.NumericUpDown();
            this.ShiftX = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.TransformGroup.SuspendLayout();
            this.CoefGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericScale)).BeginInit();
            this.FlatGB.SuspendLayout();
            this.LineGB.SuspendLayout();
            this.PointGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointX)).BeginInit();
            this.CameraGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Focus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenWidth)).BeginInit();
            this.ShiftGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftX)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(499, 10);
            this.Canvas.Margin = new System.Windows.Forms.Padding(2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(597, 542);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // TransformGroup
            // 
            this.TransformGroup.Controls.Add(this.ShiftGB);
            this.TransformGroup.Controls.Add(this.RotateButton);
            this.TransformGroup.Controls.Add(this.ShiftButton);
            this.TransformGroup.Controls.Add(this.ScaleButton);
            this.TransformGroup.Controls.Add(this.ReflectButton);
            this.TransformGroup.Controls.Add(this.CoefGB);
            this.TransformGroup.Controls.Add(this.FlatGB);
            this.TransformGroup.Controls.Add(this.LineGB);
            this.TransformGroup.Controls.Add(this.PointGB);
            this.TransformGroup.Location = new System.Drawing.Point(254, 10);
            this.TransformGroup.Margin = new System.Windows.Forms.Padding(2);
            this.TransformGroup.Name = "TransformGroup";
            this.TransformGroup.Padding = new System.Windows.Forms.Padding(2);
            this.TransformGroup.Size = new System.Drawing.Size(240, 542);
            this.TransformGroup.TabIndex = 2;
            this.TransformGroup.TabStop = false;
            this.TransformGroup.Text = "Transform";
            // 
            // RotateButton
            // 
            this.RotateButton.Location = new System.Drawing.Point(122, 497);
            this.RotateButton.Margin = new System.Windows.Forms.Padding(2);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(113, 40);
            this.RotateButton.TabIndex = 10;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // ShiftButton
            // 
            this.ShiftButton.Location = new System.Drawing.Point(4, 458);
            this.ShiftButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftButton.Name = "ShiftButton";
            this.ShiftButton.Size = new System.Drawing.Size(112, 35);
            this.ShiftButton.TabIndex = 9;
            this.ShiftButton.Text = "Shift";
            this.ShiftButton.UseVisualStyleBackColor = true;
            this.ShiftButton.Click += new System.EventHandler(this.ShiftButton_Click);
            // 
            // ScaleButton
            // 
            this.ScaleButton.Location = new System.Drawing.Point(122, 458);
            this.ScaleButton.Margin = new System.Windows.Forms.Padding(2);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(113, 35);
            this.ScaleButton.TabIndex = 8;
            this.ScaleButton.Text = "Scale";
            this.ScaleButton.UseVisualStyleBackColor = true;
            this.ScaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // ReflectButton
            // 
            this.ReflectButton.Location = new System.Drawing.Point(5, 497);
            this.ReflectButton.Margin = new System.Windows.Forms.Padding(2);
            this.ReflectButton.Name = "ReflectButton";
            this.ReflectButton.Size = new System.Drawing.Size(112, 40);
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
            this.CoefGB.Location = new System.Drawing.Point(6, 354);
            this.CoefGB.Margin = new System.Windows.Forms.Padding(2);
            this.CoefGB.Name = "CoefGB";
            this.CoefGB.Padding = new System.Windows.Forms.Padding(2);
            this.CoefGB.Size = new System.Drawing.Size(230, 78);
            this.CoefGB.TabIndex = 6;
            this.CoefGB.TabStop = false;
            this.CoefGB.Text = "Coefficients";
            // 
            // LabelAngle
            // 
            this.LabelAngle.AutoSize = true;
            this.LabelAngle.Location = new System.Drawing.Point(147, 52);
            this.LabelAngle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelAngle.Name = "LabelAngle";
            this.LabelAngle.Size = new System.Drawing.Size(48, 20);
            this.LabelAngle.TabIndex = 3;
            this.LabelAngle.Text = "Angle";
            // 
            // LabelScale
            // 
            this.LabelScale.AutoSize = true;
            this.LabelScale.Location = new System.Drawing.Point(18, 52);
            this.LabelScale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelScale.Name = "LabelScale";
            this.LabelScale.Size = new System.Drawing.Size(77, 20);
            this.LabelScale.TabIndex = 2;
            this.LabelScale.Text = "Scale coef";
            // 
            // NumericAngle
            // 
            this.NumericAngle.Location = new System.Drawing.Point(117, 25);
            this.NumericAngle.Margin = new System.Windows.Forms.Padding(2);
            this.NumericAngle.Name = "NumericAngle";
            this.NumericAngle.Size = new System.Drawing.Size(108, 27);
            this.NumericAngle.TabIndex = 1;
            // 
            // NumericScale
            // 
            this.NumericScale.Location = new System.Drawing.Point(6, 25);
            this.NumericScale.Margin = new System.Windows.Forms.Padding(2);
            this.NumericScale.Name = "NumericScale";
            this.NumericScale.Size = new System.Drawing.Size(106, 27);
            this.NumericScale.TabIndex = 0;
            // 
            // FlatGB
            // 
            this.FlatGB.Controls.Add(this.LabelFlatP3);
            this.FlatGB.Controls.Add(this.LabelFlatP2);
            this.FlatGB.Controls.Add(this.LabelFlatP1);
            this.FlatGB.Controls.Add(this.FlatTBP3);
            this.FlatGB.Controls.Add(this.FlatTBP2);
            this.FlatGB.Controls.Add(this.FlatTBP1);
            this.FlatGB.Location = new System.Drawing.Point(5, 267);
            this.FlatGB.Margin = new System.Windows.Forms.Padding(2);
            this.FlatGB.Name = "FlatGB";
            this.FlatGB.Padding = new System.Windows.Forms.Padding(2);
            this.FlatGB.Size = new System.Drawing.Size(230, 82);
            this.FlatGB.TabIndex = 4;
            this.FlatGB.TabStop = false;
            this.FlatGB.Text = "Flat";
            // 
            // LabelFlatP3
            // 
            this.LabelFlatP3.AutoSize = true;
            this.LabelFlatP3.Location = new System.Drawing.Point(177, 54);
            this.LabelFlatP3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelFlatP3.Name = "LabelFlatP3";
            this.LabelFlatP3.Size = new System.Drawing.Size(25, 20);
            this.LabelFlatP3.TabIndex = 5;
            this.LabelFlatP3.Text = "P3";
            // 
            // LabelFlatP2
            // 
            this.LabelFlatP2.AutoSize = true;
            this.LabelFlatP2.Location = new System.Drawing.Point(106, 54);
            this.LabelFlatP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelFlatP2.Name = "LabelFlatP2";
            this.LabelFlatP2.Size = new System.Drawing.Size(25, 20);
            this.LabelFlatP2.TabIndex = 4;
            this.LabelFlatP2.Text = "P2";
            // 
            // LabelFlatP1
            // 
            this.LabelFlatP1.AutoSize = true;
            this.LabelFlatP1.Location = new System.Drawing.Point(32, 55);
            this.LabelFlatP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelFlatP1.Name = "LabelFlatP1";
            this.LabelFlatP1.Size = new System.Drawing.Size(25, 20);
            this.LabelFlatP1.TabIndex = 3;
            this.LabelFlatP1.Text = "P1";
            // 
            // FlatTBP3
            // 
            this.FlatTBP3.Location = new System.Drawing.Point(156, 25);
            this.FlatTBP3.Margin = new System.Windows.Forms.Padding(2);
            this.FlatTBP3.Name = "FlatTBP3";
            this.FlatTBP3.Size = new System.Drawing.Size(70, 27);
            this.FlatTBP3.TabIndex = 2;
            this.FlatTBP3.Text = "0 0 1";
            // 
            // FlatTBP2
            // 
            this.FlatTBP2.Location = new System.Drawing.Point(83, 25);
            this.FlatTBP2.Margin = new System.Windows.Forms.Padding(2);
            this.FlatTBP2.Name = "FlatTBP2";
            this.FlatTBP2.Size = new System.Drawing.Size(68, 27);
            this.FlatTBP2.TabIndex = 1;
            this.FlatTBP2.Text = "0 1 0";
            // 
            // FlatTBP1
            // 
            this.FlatTBP1.Location = new System.Drawing.Point(6, 25);
            this.FlatTBP1.Margin = new System.Windows.Forms.Padding(2);
            this.FlatTBP1.Name = "FlatTBP1";
            this.FlatTBP1.Size = new System.Drawing.Size(73, 27);
            this.FlatTBP1.TabIndex = 0;
            this.FlatTBP1.Text = "1 0 0";
            // 
            // LineGB
            // 
            this.LineGB.Controls.Add(this.LabelLineP2);
            this.LineGB.Controls.Add(this.LabelLineP1);
            this.LineGB.Controls.Add(this.LineTBP2);
            this.LineGB.Controls.Add(this.LineTBP1);
            this.LineGB.Location = new System.Drawing.Point(6, 183);
            this.LineGB.Margin = new System.Windows.Forms.Padding(2);
            this.LineGB.Name = "LineGB";
            this.LineGB.Padding = new System.Windows.Forms.Padding(2);
            this.LineGB.Size = new System.Drawing.Size(230, 78);
            this.LineGB.TabIndex = 1;
            this.LineGB.TabStop = false;
            this.LineGB.Text = "Line";
            // 
            // LabelLineP2
            // 
            this.LabelLineP2.AutoSize = true;
            this.LabelLineP2.Location = new System.Drawing.Point(154, 52);
            this.LabelLineP2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLineP2.Name = "LabelLineP2";
            this.LabelLineP2.Size = new System.Drawing.Size(25, 20);
            this.LabelLineP2.TabIndex = 3;
            this.LabelLineP2.Text = "P2";
            // 
            // LabelLineP1
            // 
            this.LabelLineP1.AutoSize = true;
            this.LabelLineP1.Location = new System.Drawing.Point(48, 52);
            this.LabelLineP1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLineP1.Name = "LabelLineP1";
            this.LabelLineP1.Size = new System.Drawing.Size(25, 20);
            this.LabelLineP1.TabIndex = 2;
            this.LabelLineP1.Text = "P1";
            // 
            // LineTBP2
            // 
            this.LineTBP2.Location = new System.Drawing.Point(117, 25);
            this.LineTBP2.Margin = new System.Windows.Forms.Padding(2);
            this.LineTBP2.Name = "LineTBP2";
            this.LineTBP2.Size = new System.Drawing.Size(109, 27);
            this.LineTBP2.TabIndex = 1;
            this.LineTBP2.Text = "2 2 2";
            // 
            // LineTBP1
            // 
            this.LineTBP1.Location = new System.Drawing.Point(6, 25);
            this.LineTBP1.Margin = new System.Windows.Forms.Padding(2);
            this.LineTBP1.Name = "LineTBP1";
            this.LineTBP1.Size = new System.Drawing.Size(106, 27);
            this.LineTBP1.TabIndex = 0;
            this.LineTBP1.Text = "1 1 1";
            // 
            // PointGB
            // 
            this.PointGB.Controls.Add(this.LabelPointZ);
            this.PointGB.Controls.Add(this.LabelPointY);
            this.PointGB.Controls.Add(this.LabelPointX);
            this.PointGB.Controls.Add(this.NumericPointZ);
            this.PointGB.Controls.Add(this.NumericPointY);
            this.PointGB.Controls.Add(this.NumericPointX);
            this.PointGB.Location = new System.Drawing.Point(6, 20);
            this.PointGB.Margin = new System.Windows.Forms.Padding(2);
            this.PointGB.Name = "PointGB";
            this.PointGB.Padding = new System.Windows.Forms.Padding(2);
            this.PointGB.Size = new System.Drawing.Size(230, 78);
            this.PointGB.TabIndex = 0;
            this.PointGB.TabStop = false;
            this.PointGB.Text = "Point";
            this.PointGB.Enter += new System.EventHandler(this.PointGB_Enter);
            // 
            // LabelPointZ
            // 
            this.LabelPointZ.AutoSize = true;
            this.LabelPointZ.Location = new System.Drawing.Point(176, 52);
            this.LabelPointZ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointZ.Name = "LabelPointZ";
            this.LabelPointZ.Size = new System.Drawing.Size(18, 20);
            this.LabelPointZ.TabIndex = 5;
            this.LabelPointZ.Text = "Z";
            // 
            // LabelPointY
            // 
            this.LabelPointY.AutoSize = true;
            this.LabelPointY.Location = new System.Drawing.Point(103, 52);
            this.LabelPointY.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointY.Name = "LabelPointY";
            this.LabelPointY.Size = new System.Drawing.Size(17, 20);
            this.LabelPointY.TabIndex = 4;
            this.LabelPointY.Text = "Y";
            // 
            // LabelPointX
            // 
            this.LabelPointX.AutoSize = true;
            this.LabelPointX.Location = new System.Drawing.Point(31, 52);
            this.LabelPointX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelPointX.Name = "LabelPointX";
            this.LabelPointX.Size = new System.Drawing.Size(18, 20);
            this.LabelPointX.TabIndex = 3;
            this.LabelPointX.Text = "X";
            // 
            // NumericPointZ
            // 
            this.NumericPointZ.Location = new System.Drawing.Point(154, 25);
            this.NumericPointZ.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointZ.Name = "NumericPointZ";
            this.NumericPointZ.Size = new System.Drawing.Size(70, 27);
            this.NumericPointZ.TabIndex = 2;
            // 
            // NumericPointY
            // 
            this.NumericPointY.Location = new System.Drawing.Point(82, 25);
            this.NumericPointY.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointY.Name = "NumericPointY";
            this.NumericPointY.Size = new System.Drawing.Size(67, 27);
            this.NumericPointY.TabIndex = 1;
            // 
            // NumericPointX
            // 
            this.NumericPointX.Location = new System.Drawing.Point(6, 25);
            this.NumericPointX.Margin = new System.Windows.Forms.Padding(2);
            this.NumericPointX.Name = "NumericPointX";
            this.NumericPointX.Size = new System.Drawing.Size(72, 27);
            this.NumericPointX.TabIndex = 0;
            // 
            // FiguresList
            // 
            this.FiguresList.FormattingEnabled = true;
            this.FiguresList.Location = new System.Drawing.Point(10, 10);
            this.FiguresList.Margin = new System.Windows.Forms.Padding(2);
            this.FiguresList.Name = "FiguresList";
            this.FiguresList.Size = new System.Drawing.Size(240, 28);
            this.FiguresList.TabIndex = 3;
            // 
            // SceneFiguresList
            // 
            this.SceneFiguresList.FormattingEnabled = true;
            this.SceneFiguresList.ItemHeight = 20;
            this.SceneFiguresList.Location = new System.Drawing.Point(10, 82);
            this.SceneFiguresList.Margin = new System.Windows.Forms.Padding(2);
            this.SceneFiguresList.Name = "SceneFiguresList";
            this.SceneFiguresList.Size = new System.Drawing.Size(240, 184);
            this.SceneFiguresList.TabIndex = 4;
            this.SceneFiguresList.SelectedIndexChanged += new System.EventHandler(this.SceneFiguresList_SelectedIndexChanged);
            // 
            // AddFigureButton
            // 
            this.AddFigureButton.Location = new System.Drawing.Point(10, 42);
            this.AddFigureButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddFigureButton.Name = "AddFigureButton";
            this.AddFigureButton.Size = new System.Drawing.Size(239, 35);
            this.AddFigureButton.TabIndex = 5;
            this.AddFigureButton.Text = "Add Figure";
            this.AddFigureButton.UseVisualStyleBackColor = true;
            this.AddFigureButton.Click += new System.EventHandler(this.AddFigureButton_Click);
            // 
            // CameraGroup
            // 
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
            this.CameraGroup.Location = new System.Drawing.Point(10, 270);
            this.CameraGroup.Margin = new System.Windows.Forms.Padding(2);
            this.CameraGroup.Name = "CameraGroup";
            this.CameraGroup.Padding = new System.Windows.Forms.Padding(2);
            this.CameraGroup.Size = new System.Drawing.Size(240, 282);
            this.CameraGroup.TabIndex = 6;
            this.CameraGroup.TabStop = false;
            this.CameraGroup.Text = "Camera";
            // 
            // Focus
            // 
            this.Focus.Location = new System.Drawing.Point(121, 55);
            this.Focus.Margin = new System.Windows.Forms.Padding(2);
            this.Focus.Name = "Focus";
            this.Focus.Size = new System.Drawing.Size(114, 27);
            this.Focus.TabIndex = 16;
            this.Focus.ValueChanged += new System.EventHandler(this.Focus_ValueChanged);
            // 
            // ScreenHeight
            // 
            this.ScreenHeight.Location = new System.Drawing.Point(182, 25);
            this.ScreenHeight.Margin = new System.Windows.Forms.Padding(2);
            this.ScreenHeight.Name = "ScreenHeight";
            this.ScreenHeight.Size = new System.Drawing.Size(53, 27);
            this.ScreenHeight.TabIndex = 15;
            this.ScreenHeight.ValueChanged += new System.EventHandler(this.ScreenHeight_ValueChanged);
            // 
            // ScreenWidth
            // 
            this.ScreenWidth.Location = new System.Drawing.Point(121, 25);
            this.ScreenWidth.Margin = new System.Windows.Forms.Padding(2);
            this.ScreenWidth.Name = "ScreenWidth";
            this.ScreenWidth.Size = new System.Drawing.Size(54, 27);
            this.ScreenWidth.TabIndex = 14;
            this.ScreenWidth.ValueChanged += new System.EventHandler(this.ScreenWidth_ValueChanged);
            // 
            // ProjectionButton
            // 
            this.ProjectionButton.Location = new System.Drawing.Point(6, 237);
            this.ProjectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectionButton.Name = "ProjectionButton";
            this.ProjectionButton.Size = new System.Drawing.Size(229, 40);
            this.ProjectionButton.TabIndex = 13;
            this.ProjectionButton.Text = "Projection type : Parallel";
            this.ProjectionButton.UseVisualStyleBackColor = true;
            this.ProjectionButton.Click += new System.EventHandler(this.ProjectionButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(122, 122);
            this.MoveDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(114, 34);
            this.MoveDownButton.TabIndex = 12;
            this.MoveDownButton.Text = "Move Down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(5, 122);
            this.MoveUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(110, 34);
            this.MoveUpButton.TabIndex = 11;
            this.MoveUpButton.Text = "Move Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // TurnDownButton
            // 
            this.TurnDownButton.Location = new System.Drawing.Point(121, 198);
            this.TurnDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnDownButton.Name = "TurnDownButton";
            this.TurnDownButton.Size = new System.Drawing.Size(114, 33);
            this.TurnDownButton.TabIndex = 10;
            this.TurnDownButton.Text = "Turn Down";
            this.TurnDownButton.UseVisualStyleBackColor = true;
            // 
            // TurnUpButton
            // 
            this.TurnUpButton.Location = new System.Drawing.Point(5, 198);
            this.TurnUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnUpButton.Name = "TurnUpButton";
            this.TurnUpButton.Size = new System.Drawing.Size(110, 33);
            this.TurnUpButton.TabIndex = 9;
            this.TurnUpButton.Text = "Turn Up";
            this.TurnUpButton.UseVisualStyleBackColor = true;
            // 
            // TurnRightButton
            // 
            this.TurnRightButton.Location = new System.Drawing.Point(122, 161);
            this.TurnRightButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnRightButton.Name = "TurnRightButton";
            this.TurnRightButton.Size = new System.Drawing.Size(114, 33);
            this.TurnRightButton.TabIndex = 8;
            this.TurnRightButton.Text = "Turn Right";
            this.TurnRightButton.UseVisualStyleBackColor = true;
            // 
            // TurnLeftButton
            // 
            this.TurnLeftButton.Location = new System.Drawing.Point(5, 161);
            this.TurnLeftButton.Margin = new System.Windows.Forms.Padding(2);
            this.TurnLeftButton.Name = "TurnLeftButton";
            this.TurnLeftButton.Size = new System.Drawing.Size(110, 33);
            this.TurnLeftButton.TabIndex = 7;
            this.TurnLeftButton.Text = "Turn Left";
            this.TurnLeftButton.UseVisualStyleBackColor = true;
            // 
            // ForwardButton
            // 
            this.ForwardButton.Location = new System.Drawing.Point(5, 84);
            this.ForwardButton.Margin = new System.Windows.Forms.Padding(2);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(111, 34);
            this.ForwardButton.TabIndex = 6;
            this.ForwardButton.Text = "Forward";
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackwardButton
            // 
            this.BackwardButton.Location = new System.Drawing.Point(121, 84);
            this.BackwardButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackwardButton.Name = "BackwardButton";
            this.BackwardButton.Size = new System.Drawing.Size(114, 34);
            this.BackwardButton.TabIndex = 5;
            this.BackwardButton.Text = "Backward";
            this.BackwardButton.UseVisualStyleBackColor = true;
            this.BackwardButton.Click += new System.EventHandler(this.BackwardButton_Click);
            // 
            // FocusLabel
            // 
            this.FocusLabel.AutoSize = true;
            this.FocusLabel.Location = new System.Drawing.Point(5, 56);
            this.FocusLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FocusLabel.Name = "FocusLabel";
            this.FocusLabel.Size = new System.Drawing.Size(90, 20);
            this.FocusLabel.TabIndex = 4;
            this.FocusLabel.Text = "Focal length";
            // 
            // ScreenParamsLabel
            // 
            this.ScreenParamsLabel.AutoSize = true;
            this.ScreenParamsLabel.Location = new System.Drawing.Point(5, 26);
            this.ScreenParamsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ScreenParamsLabel.Name = "ScreenParamsLabel";
            this.ScreenParamsLabel.Size = new System.Drawing.Size(106, 20);
            this.ScreenParamsLabel.TabIndex = 2;
            this.ScreenParamsLabel.Text = "Screen params";
            // 
            // ShiftGB
            // 
            this.ShiftGB.Controls.Add(this.ShiftY);
            this.ShiftGB.Controls.Add(this.label1);
            this.ShiftGB.Controls.Add(this.label2);
            this.ShiftGB.Controls.Add(this.label3);
            this.ShiftGB.Controls.Add(this.ShiftZ);
            this.ShiftGB.Controls.Add(this.ShiftX);
            this.ShiftGB.Location = new System.Drawing.Point(2, 102);
            this.ShiftGB.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftGB.Name = "ShiftGB";
            this.ShiftGB.Padding = new System.Windows.Forms.Padding(2);
            this.ShiftGB.Size = new System.Drawing.Size(230, 77);
            this.ShiftGB.TabIndex = 6;
            this.ShiftGB.TabStop = false;
            this.ShiftGB.Text = "Shift";
            this.ShiftGB.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            // 
            // ShiftZ
            // 
            this.ShiftZ.Location = new System.Drawing.Point(154, 25);
            this.ShiftZ.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftZ.Name = "ShiftZ";
            this.ShiftZ.Size = new System.Drawing.Size(70, 27);
            this.ShiftZ.TabIndex = 2;
            // 
            // ShiftY
            // 
            this.ShiftY.Location = new System.Drawing.Point(82, 25);
            this.ShiftY.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftY.Name = "ShiftY";
            this.ShiftY.Size = new System.Drawing.Size(67, 27);
            this.ShiftY.TabIndex = 1;
            // 
            // ShiftX
            // 
            this.ShiftX.Location = new System.Drawing.Point(6, 25);
            this.ShiftX.Margin = new System.Windows.Forms.Padding(2);
            this.ShiftX.Name = "ShiftX";
            this.ShiftX.Size = new System.Drawing.Size(72, 27);
            this.ShiftX.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 562);
            this.Controls.Add(this.CameraGroup);
            this.Controls.Add(this.AddFigureButton);
            this.Controls.Add(this.SceneFiguresList);
            this.Controls.Add(this.FiguresList);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.TransformGroup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPointX)).EndInit();
            this.CameraGroup.ResumeLayout(false);
            this.CameraGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Focus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenWidth)).EndInit();
            this.ShiftGB.ResumeLayout(false);
            this.ShiftGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.GroupBox TransformGroup;
        private System.Windows.Forms.ComboBox FiguresList;
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
        private System.Windows.Forms.Label LabelFlatP3;
        private System.Windows.Forms.Label LabelFlatP2;
        private System.Windows.Forms.Label LabelFlatP1;
        private System.Windows.Forms.TextBox FlatTBP3;
        private System.Windows.Forms.TextBox FlatTBP2;
        private System.Windows.Forms.TextBox FlatTBP1;
        private System.Windows.Forms.GroupBox LineGB;
        private System.Windows.Forms.Label LabelLineP2;
        private System.Windows.Forms.Label LabelLineP1;
        private System.Windows.Forms.TextBox LineTBP2;
        private System.Windows.Forms.TextBox LineTBP1;
        private System.Windows.Forms.GroupBox ShiftGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ShiftZ;
        private System.Windows.Forms.NumericUpDown ShiftY;
        private System.Windows.Forms.NumericUpDown ShiftX;
    }
}

