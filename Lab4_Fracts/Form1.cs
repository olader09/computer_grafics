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
using System.Drawing.Drawing2D;

namespace Lab4_Fracts
{
    public partial class Form1 : Form
    {
        #region Forms and buttons
        public Form1()
        {
            InitializeComponent();
            ColoringButton(ClearButton, Color.Red);
            Clear();
        }

        public void ColoringButton(Button b, Color c)
        {
            Bitmap bmp = new Bitmap(b.Width, b.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    c,
                                                    Color.FromArgb(c.R - 20 < 0 ? 0 : c.R - 20,
                                                                   c.G - 20 < 0 ? 0 : c.G - 20,
                                                                   c.B - 20 < 0 ? 0 : c.B - 20),
                                                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(br, r);
                }
            }
            b.BackgroundImage = bmp;
            b.ForeColor = Color.White;
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

        private void Clear()
        {
            var g = Canvas.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, Canvas.Width, Canvas.Height));
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        #endregion

        #region L Systems

        public LSystem Lsys;
        public List<SimpleLine> fract;

        public class SimpleLine
        {
            public (double, double) p1, p2;
            public Color c;
            public int thickness;

            public SimpleLine((double, double) point1, (double, double) point2)
            {
                p1 = point1;
                p2 = point2;
                c = Color.Black;
                thickness = 1; 
            }

            public SimpleLine((double, double) point1, (double, double) point2, Color col, int th)
            {
                p1 = point1;
                p2 = point2;
                c = col;
                thickness = th; 
            }
        }

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
                    string temp = "";
                    foreach (var ch in result)
                    {
                        if (rules.Any(x => x.Item1 == ch))
                        {
                            // result = Regex.Replace(result, "" + rule.Item1, rule.Item2);
                            temp += rules.Find(x => x.Item1 == ch).Item2; 
                        }
                        else
                        {
                            temp += ch; 
                        }
                    }
                    result = temp; 
                }
                // Console.WriteLine(result); 
            }
        }

        public double ToRadians(double deg) => (deg % 360) * Math.PI / 180;

        public int ToY(double y) => Canvas.Height - (int)y;

        public int GetBranchGens(string str)
        {
            int i = 1;
            Stack<bool> stack = new Stack<bool>();
            foreach (var c in str)
            {
                if (c == '[')
                {
                    stack.Push(true);
                    if (stack.Count + 1 > i)
                        i = stack.Count + 1;
                }
                else if (c == ']')
                    stack.Pop();
            }
            return i;
        }

        public void Draw(Position pos, bool rand = false, bool tree = false)
        {

            var g = Canvas.CreateGraphics();
            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            /*if (start.curGen == start.generations)
                return; */
            Stack<Position> stack = new Stack<Position>();
            fract = new List<SimpleLine>();
            Random r = new Random();
            Color c1 = Lsys.colors.Item1;
            Color c2 = Lsys.colors.Item2;
            int gens = GetBranchGens(Lsys.result); 
            double red = (c2.R - c1.R) / (double)gens;
            double green = (c2.G - c1.G) / (double)gens;
            double blue = (c2.B - c1.B) / (double)gens;
            double thickness = (Lsys.startThickness - 1) / (double)gens;
            double length = (Lsys.lineLength - 5) / (double)gens; 

            foreach (var symbol in Lsys.result)
            {
                switch (symbol)
                {
                    case 'F':
                    case 'A':
                    case 'B':
                        /*g.DrawLine(new Pen(Color.Black),
                            new Point((int)pos.x, Canvas.Height - (int)pos.y),
                            new Point((int)(pos.x + Lsys.lineLength * Math.Cos(Lsys.angle)), Canvas.Height - (int)(start.y + Lsys.lineLength * Math.Sin(Lsys.angle))));
                       */
                        
                        if (tree)
                        {
                            // double len = Lsys.lineLength / Lsys.generations;
                            Position p2 = new Position();
                            p2.angle = pos.angle;
                            Color c = Color.FromArgb((int)(c1.R + stack.Count * red),
                                                     (int)(c1.G + stack.Count * green),
                                                     (int)(c1.B + stack.Count * blue));
                            int thick = (int)(Lsys.startThickness - stack.Count * thickness);
                            p2.x = pos.x + ((Lsys.lineLength - (length * stack.Count)) * Math.Cos(ToRadians(pos.angle)));
                            p2.y = pos.y + ((Lsys.lineLength - (length * stack.Count)) * Math.Sin(ToRadians(pos.angle)));
                            g.DrawLine(new Pen(c, thick),
                                       new Point((int)pos.x, ToY(pos.y)),
                                       new Point((int)p2.x, ToY(p2.y)));
                            fract.Add(new SimpleLine((pos.x, pos.y), (p2.x, p2.y), c, thick));
                            pos = p2;
                        }
                        else
                        {
                            double len = Lsys.lineLength / Lsys.generations;
                            Position p2 = new Position();
                            p2.angle = pos.angle;
                            p2.x = pos.x + (len * Math.Cos(ToRadians(pos.angle)));
                            p2.y = pos.y + (len * Math.Sin(ToRadians(pos.angle)));
                            g.DrawLine(new Pen(Color.Black), 
                                       new Point((int)pos.x, ToY(pos.y)),
                                       new Point((int)p2.x, ToY(p2.y)));
                            fract.Add(new SimpleLine((pos.x, pos.y), (p2.x, p2.y)));
                            pos = p2;
                        }
                        break;
                    case 'X':
                        break;
                    case '+':
                        pos.angle -= rand ? r.NextDouble() * Lsys.angle : Lsys.angle;
                        break;
                    case '-':
                        pos.angle += rand ? r.NextDouble() * Lsys.angle : Lsys.angle;
                        break;
                    case '[':
                        stack.Push(pos);
                        break;
                    case ']':
                        pos = stack.Pop();
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
        

        private void DrawLSystemButton_Click(object sender, EventArgs e)
        {
            LSystem system = new LSystem(); 
            string[] text = File.ReadAllLines(LSystemFile.Text);
            string[] sets = text[0].Split(' ');
            system.axiom = sets[0];
            system.angle = double.Parse(sets[1]);
            system.startAngle = double.Parse(sets[2]);
            system.startPoint = (Canvas.Width / 2, Canvas.Height / 2);
            system.startThickness = 20;
            system.colors = (Color.Brown, Color.Green);
            system.generations = int.Parse(Generations.Text);
            var d = Randoms.Text.Split(new char[] { ' ', ';', ',' }).Select(x => double.Parse(x));
            system.randomRange = (d.ElementAt(0), d.ElementAt(1));
            system.lineLength = 75;
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
            if (TreeCB.Checked)
                Draw(p, false, false);
            else
                Draw(p, true, true); 
        }

        private void RedrawFract()
        {
            var g = Canvas.CreateGraphics();
            foreach (var line in fract)
                g.DrawLine(new Pen(line.c, line.thickness),
                    new Point((int)line.p1.Item1, ToY(line.p1.Item2)),
                    new Point((int)line.p2.Item1, ToY(line.p2.Item2))); 
        }

        private void StretchLine(SimpleLine line, double x, double y)
        {
            line.p1.Item1 *= x;
            line.p1.Item2 *= y;

            line.p2.Item1 *= x;
            line.p2.Item2 *= y;

            //if (line.thickness > 1)
              //  line.thickness = (int)(line.thickness / x); 
        }

        private void ShiftLine(SimpleLine line, double x, double y)
        {
            line.p1.Item1 += x;
            line.p1.Item2 += y;

            line.p2.Item1 += x;
            line.p2.Item2 += y;
        }

        private void StretchButton_Click(object sender, EventArgs e)
        {
            var w = StretchTB.Text.Split(' ');
            double x = double.Parse(w[0]);
            double y = double.Parse(w[1]);
            for (int i = 0; i < fract.Count; ++i)
                StretchLine(fract[i], x, y);
            Clear(); 
            RedrawFract(); 
        }

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            var w = ShiftTB.Text.Split(' ');
            double x = double.Parse(w[0]);
            double y = double.Parse(w[1]);
            for (int i = 0; i < fract.Count; ++i)
                ShiftLine(fract[i], x, y);
            Clear();
            RedrawFract();
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BezCur_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void ThicknessButton_Click(object sender, EventArgs e)
        {
            foreach (var line in fract)
                if (line.thickness > 1)
                    line.thickness = (int)(line.thickness / double.Parse(ThicknessTB.Text));
            Clear(); 
            RedrawFract();
        }

        private void MidDpButton_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
