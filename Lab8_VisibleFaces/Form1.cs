using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab6_Figures3D;

namespace Lab8_VisibleFaces
{
    public partial class Form1 : Form
    {
        public enum Action { NoAction, AddFigure }

        SceneFigures figures = new();
        public Figure3D currentFigure;
        public Action action;
        Graphics g; 

        public Form1()
        {
            InitializeComponent();
            g = Canvas.CreateGraphics(); 
            figures.AddFigure(new Grid());
            figures.AddFigure(new Coord());
            Camera cam = new(); 
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'n':
                    currentFigure = figures.NextFigure(); 
                    break;

                case 'a':
                    action = Action.AddFigure; 
                    break;

                case 't':
                    if (action == Action.AddFigure)
                    {
                        figures.AddFigure(new F4());
                        action = Action.NoAction; 
                    }
                    break;

                case 'd':
                    figures.DeleteFigure(); 
                    break; 
            }
        }
    }
}
