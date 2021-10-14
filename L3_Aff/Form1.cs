using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3_Aff
{
   
    public partial class Form1 : Form
    {
        public enum Figure { Dot, Line, Polygon }
        public enum Action { NoAction, CreateFigure, PointToLine, PointInside, StretchPoint, RotatePoint }

        public Figure f;
        public Action a;
        public int i = 0;
        bool line = false;
        (int, int, bool) around; 
        public string selectedFigure; 

        public Dictionary<string, List<Point>> figures;
        public List<Point> currentFigure; 

        
        public Form1()
        {
            InitializeComponent();
            Graphics g = Canvas.CreateGraphics(); 
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas.Width, Canvas.Height));
            ColoringButton(ClearButton, Color.Red);
            FigNames.SelectionMode = SelectionMode.One;
            figures = new Dictionary<string, List<Point>>(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
