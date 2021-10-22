using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions; 

namespace Lab4_Fracts
{
    public partial class Form1 : Form
    {
        public LSystem Lsys; 

        public class LSystem
        {
            public string axiom;
            public List<(char, string)> rules;
            public double angle;
            public (double, double) startPoint;
            public double startAngle;
            public double startThickness;
            public (Color, Color) colors;
            public int generations;
            public (double, double) randomRange;
            public double lineLength;

            public string result;

            public void Generate()
            {
                result = axiom; 
                for (int i = 0; i < generations; ++i)
                {
                    foreach (var rule in rules)
                    {
                        Regex.Replace(axiom, "" + rule.Item1, rule.Item2);
                    }
                }
                Console.WriteLine(result); 
            }
        }

        public void Draw(Position start)
        {

            var g = Canvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            /*if (start.curGen == start.generations)
                return; */
            Stack<Position> stack = new Stack<Position>();

            foreach (var symbol in Lsys.result)
            {
                switch (symbol)
                {
                    case 'F':
                        g.DrawLine(new Pen(Color.Black),
                            new Point((int)start.x, Canvas.Height - (int)start.y),
                            new Point((int)(start.x + Lsys.lineLength * Math.Cos(Lsys.angle)), Canvas.Height - (int)(start.y + Lsys.lineLength * Math.Sin(Lsys.angle))));
                        break;
                    case 'X':
                        break;
                    case '-':
                        start.angle -= 20;
                        break;
                    case '+':
                        start.angle += 20;
                        break;
                }
            }
        }

        public class Position
        {
            public double x, y, angle;
            public Color c;
            public double thickness; 
            // public int generations, curGen; 
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BrouseLSystemFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text Files(*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                LSystemFile.Text = open.FileName;
            }
        }

        private void DrawLSystemButton_Click(object sender, EventArgs e)
        {
            LSystem system = new LSystem(); 
            string[] text = File.ReadAllLines(LSystemFile.Text);
            string[] sets = text[0].Split(' ');
            system.axiom = sets[0];
            system.angle = double.Parse(sets[1]);
            system.startAngle = double.Parse(sets[2]);
            system.startPoint = (Canvas.Width / 2, 0);
            system.startThickness = 20;
            system.colors = (Color.Brown, Color.Green);
            system.generations = int.Parse(Generations.Text);
            var d = Randoms.Text.Split(new char[] { ' ', ';', ',' }).Select(x => double.Parse(x));
            system.randomRange = (d.ElementAt(0), d.ElementAt(1));
            system.lineLength = 50;
            system.rules = new List<(char, string)>(); 
            foreach (var line in text.Skip(1))
            {
                var words = line.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                system.rules.Add((words[0][0], words[1]));
            }
            system.Generate(); 
            Lsys = system;
            Position p = new Position();
            p.x = Lsys.startPoint.Item1;
            p.y = Lsys.startPoint.Item2;
            p.angle = Lsys.startAngle;
            Draw(p);
        }
    }
}
