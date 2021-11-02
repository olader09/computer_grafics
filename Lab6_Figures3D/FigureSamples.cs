using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Lab6_Figures3D
{

    public class Coord : Figure3D
    {
        public Coord()
        {
            var O = new Point3D(0, 0, 0);
            var X = new Point3D(10, 0, 0);
            var Y = new Point3D(0, 10, 0);
            var Z = new Point3D(0, 0, 10);
            Points.AddRange(new List<Point3D>() { O, X, Y, Z });
            Lines = new()
            {
                (0, 1),
                (0, 2),
                (0, 3),
            };
        }
    }

    public class Grid : Figure3D
    {
        public Grid()
        {
            var i = 0;
            for (int x = -7; x < 8; ++x)
            {
                var p1 = new Point3D(x, -7, 0);
                var p2 = new Point3D(x, 7, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }

            for (int y = -7; y < 8; ++y)
            {
                var p1 = new Point3D(-7, y, 0);
                var p2 = new Point3D(7, y, 0);
                Points.Add(p1);
                Points.Add(p2);
                Lines.Add((i, i + 1));
                i += 2;
            }
        }
    }

    public class DownloadFigure
    {
        public string figureName;
        public List<Point3D> points;
        public int pointsCount;
        public List<(int, int)> lines;
        public int linesCount;
        public List<List<int>> planes;
        public int planesCount;
    }

    class Figures
    {
        public List<DownloadFigure> figures = new List<DownloadFigure>();
        public int count;

        public Figures(string fn) // download
        {
            using (StreamReader fs = new StreamReader(fn))
            {
                string c = fs.ReadLine();
                count = int.Parse(c);

                for (int i = 0; i < count; i++)
                {
                    DownloadFigure df = new DownloadFigure();
                    df.figureName = fs.ReadLine();
                    df.pointsCount = int.Parse(fs.ReadLine());
                    df.points = new List<Point3D>();
                    for (int j = 0; j < df.pointsCount; j++)
                    {
                        string PointCoord = fs.ReadLine();
                        string[] arrPointCoord = PointCoord.Split(' ');
                        df.points.Add(new Point3D(double.Parse(arrPointCoord[0]), double.Parse(arrPointCoord[1]), double.Parse(arrPointCoord[2])));
                    }
                    df.linesCount = int.Parse(fs.ReadLine());
                    df.lines = new List<(int, int)>();
                    for (int j = 0; j < df.linesCount; j++)
                    {
                        string Line = fs.ReadLine();
                        string[] arrLines = Line.Split(' ');
                        df.lines.Add((int.Parse(arrLines[0]), int.Parse(arrLines[1])));
                    }
                    df.planesCount = int.Parse(fs.ReadLine());
                    df.planes = new List<List<int>>();
                    for (int j = 0; j < df.planesCount; j++)
                    {
                        string Plane = fs.ReadLine();
                        string[] arrPlanes = Plane.Split(' ');
                        if (arrPlanes.Length == 3)
                            df.planes.Add(new() { int.Parse(arrPlanes[0]), int.Parse(arrPlanes[1]), int.Parse(arrPlanes[2]) });
                        else if (arrPlanes.Length == 4)
                            df.planes.Add(new() { int.Parse(arrPlanes[0]), int.Parse(arrPlanes[1]), int.Parse(arrPlanes[2]), int.Parse(arrPlanes[3]) });
                    }
                    figures.Add(df);
                }
            }
        }
    }

    public class F4 : Figure3D
    {
        public F4()
        {
            // 4 Dots 
            // 1 -> (0, 0, 0)
            // 2 -> (1, 0, 0)
            // 3 -> (1/2, sqrt(3)/2, 0)
            // 4 -> (1/2, 1/(2*sqrt(3)), sqrt(2/3))

            /*
            var p1 = new Point3D(0, 0, 0);
            var p2 = new Point3D(1, 0, 0);
            var p3 = new Point3D(1 / 2.0, Math.Sqrt(3) / 2, 0);
            var p4 = new Point3D(1 / 2.0, 1 / (2 * Math.Sqrt(3)), Math.Sqrt(2.0 / 3));
            */
            //Points = new List<Point3D>() { p1, p2, p3, p4 };

            Figures fs = new Figures("figures.txt");


            Points = new List<Point3D>();
            for (int i = 0; i < fs.figures[0].pointsCount; i++)
                Points.Add(fs.figures[0].points[i]);
            /*
            { fs.figures[0].points[0],
                                           fs.figures[0].points[1],
                                           fs.figures[0].points[2],
                                           fs.figures[0].points[3] };

            */

            Lines = new List<(int, int)>() 
            {
                /*
                fs.figures[0].lines[0],
                fs.figures[0].lines[1],
                fs.figures[0].lines[2],
                fs.figures[0].lines[3],
                fs.figures[0].lines[4],
                fs.figures[0].lines[5]
                */
                /*
                (0, 1),
                (0, 2),
                (0, 3),
                (1, 2),
                (1, 3), 
                (2, 3), 
                */
            };
            for (int i = 0; i < fs.figures[0].linesCount; i++)
                Lines.Add(fs.figures[0].lines[i]);

            Planes = new List<List<int>>()
            {
                /*
                fs.figures[0].planes[0],
                fs.figures[0].planes[1],
                fs.figures[0].planes[2],
                fs.figures[0].planes[3],
                */
                /*
                new() { 0, 1, 2 },
                new() { 0, 2, 3 }, 
                new() { 1, 2, 3 }, 
                new() { 0, 1, 3 },
                */
            };
            for (int i = 0; i < fs.figures[0].planesCount; i++)
                Planes.Add(fs.figures[0].planes[i]);
        }

        // public F4(List<Edge3D> lines) : base(lines) { }
    }

    public class F6 : Figure3D
    {
        public F6()
        {
            Figures fs = new Figures("figures.txt");

            Points = new List<Point3D>();
            for (int i = 0; i < fs.figures[1].pointsCount; i++)
                Points.Add(fs.figures[1].points[i]);


            Lines = new List<(int, int)>();
            
            for (int i = 0; i < fs.figures[1].linesCount; i++)
                Lines.Add(fs.figures[1].lines[i]);

            Planes = new List<List<int>>();

            for (int i = 0; i < fs.figures[1].planesCount; i++)
                Planes.Add(fs.figures[1].planes[i]);
        }

        // public F4(List<Edge3D> lines) : base(lines) { }
    }

    public class F8 : Figure3D
    {
        public F8()
        {
            Figures fs = new Figures("figures.txt");

            Points = new List<Point3D>();
            for (int i = 0; i < fs.figures[2].pointsCount; i++)
                Points.Add(fs.figures[2].points[i]);


            Lines = new List<(int, int)>();

            for (int i = 0; i < fs.figures[2].linesCount; i++)
                Lines.Add(fs.figures[2].lines[i]);

            Planes = new List<List<int>>();

            for (int i = 0; i < fs.figures[2].planesCount; i++)
                Planes.Add(fs.figures[2].planes[i]);
        }

        // public F4(List<Edge3D> lines) : base(lines) { }
    }


}
