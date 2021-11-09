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
        public Form1()
        {
            InitializeComponent();
            SceneFigures figures = new();
            figures.AddFigure(new Grid());
            figures.AddFigure(new Coord());
            figures.AddFigure(new F4());
            Camera cam = new(); 
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'n':
                    Canvas.BackColor = Color.Red;
                    break;
            }
        }
    }
}
