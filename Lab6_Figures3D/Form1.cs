﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;

namespace Lab6_Figures3D
{
    public partial class Form1 : Form
    {
        public List<Figure3D> figures = new List<Figure3D>();
        public int selectedFigure = -1;
        public void Next() => selectedFigure = selectedFigure == figures.Count - 1 ? 0 : (selectedFigure + 1); 

        public Form1()
        {
            InitializeComponent();
            Camera camera = new Camera(new Point3D(-1, 0, 0), new Point3D(1, 0, 0)); 
        }

        public void ShowFigures(Camera cam)
        {

        }

        public void ShowFigure() { }

        private void Form1_KeyPress(object sender, KeyPressEventArgs ke)
        {
            switch (ke.KeyChar)
            {

            };
        }
    }

    

    public class Camera
    {
        public Point3D Location { get; set; }
        public Point3D View { get; set; }
        // public (double, double, double) Angle;

        public double Width { get; init; }
        public double Height { get; init; }

        public Camera(Point3D location, Point3D view)
        {
            Location = location;
            View = view;
            Width = 2;
            Height = 1; 
        }

        public void Shift(Point3D where)
        {
            Location += where; 
        }

        public void Rotate(Line3D axis, double angle)
        {

        }

        public void Rotate(string axis, double angle)
        {

        }
    }
}
