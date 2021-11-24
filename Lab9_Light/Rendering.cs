using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureParts.Plane;
using System.Drawing;
using Figure;
using GeometricFunctions;

namespace Rendering
{
    public static class RenderingPipeline
    {
        public static List<Figure3D> GetFiguresInViewCoordinates(List<Figure3D> figures, Matrix view)
        {
            List<Figure3D> result = new List<Figure3D>();
            foreach (var f in figures)
            {
                var figureToAdd = new Figure3D(f);
                figureToAdd.Points = figureToAdd.Points.Select(p => Matrix.To3DPoint(Matrix.Point(p) * view)).ToList();
                result.Add(figureToAdd);
            }
            return result;
        }

        public static void CutNonFacePlanes(List<Figure3D> figures)
        {
            figures.Where(x => x.Planes.Count > 0).ToList().ForEach(x => x.SetNormalVectors());
            figures.Where(x => x.Planes.Count > 0).ToList().ForEach(x => x.MarkPlanesAsFaceOrNonFace());
        }

        /*
        public static List<Plane3D> GetAllPlanes(List<Figure3D> figures)
        {
            List<Plane3D> planes = new List<Plane3D>();
            foreach (var f in figures)
                foreach (var p in f.Planes)
                    planes.AddRange(p.Triangulate());
            return planes; 
        }
        */

        public static List<Figure3D> GetProjectedFigures(List<Figure3D> figures, Func<Figure3D, Figure3D> Projector)
        {
            return figures.Select(f => Projector(f)).ToList();
        }

        public static void DrawFullCarcass(List<Figure3D> figures, Graphics graphics, int sW, int sH, int scale)
        {
            foreach (var f in figures)
            {
                foreach (var l in f.Lines)
                {
                    var p1 = f.Points[l.Item1];
                    var p2 = f.Points[l.Item2];
                    if (p1.Z < 0 || p2.Z < 0 || p1.X is double.NaN || p1.Y is double.NaN || p2.X is double.NaN || p2.Y is double.NaN)
                        continue;
                    graphics.DrawLine(
                        new Pen(f.LinesColor),
                        Methods.PointOnRealScreen(p1, sW, sH, scale),
                        Methods.PointOnRealScreen(p2, sW, sH, scale)
                    );
                }
            }
        }

        public static void DrawFaceCarcass(List<Figure3D> figures, Graphics graphics, int sW, int sH, int scale)
        {
            DrawFullCarcass(figures.Where(x => x.Planes.Count == 0).ToList(), graphics, sW, sH, scale);

            foreach (var f in figures.Where(x => x.Planes.Count > 0))
            {
                for (var i = 0; i < f.Lines.Count; ++i)
                {
                    if (!f.LinesVisibility[i])
                        continue;
                    var p1 = f.Points[f.Lines[i].Item1];
                    var p2 = f.Points[f.Lines[i].Item2];
                    if (p1.Z < 0 || p2.Z < 0 || p1.X is double.NaN || p1.Y is double.NaN || p2.X is double.NaN || p2.Y is double.NaN)
                        continue;
                    graphics.DrawLine(
                        new Pen(f.LinesColor),
                        Methods.PointOnRealScreen(p1, sW, sH, scale),
                        Methods.PointOnRealScreen(p2, sW, sH, scale)
                    );
                }
            }
        }

        public static void DrawZBuffer(List<Figure3D> figures, double[,] ZB, Color[,] CB, int sW, int sH, int scale)
        {
            foreach (var f in figures.Where(x => x.Planes.Count > 0))
                foreach (var p in f.Planes.Where(x => x.Visible))
                    foreach (var subp in p.Triangulate())
                    {
                        var p1 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[0]], sW, sH, scale);
                        var p2 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[1]], sW, sH, scale);
                        var p3 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[2]], sW, sH, scale);

#if DEBUG
                        Console.WriteLine($"Subplane: {p1.X}:{p1.Y}, {p2.X}:{p2.Y}, {p3.X}:{p3.Y}");
#endif

                        if (p.PlaneFill == PlaneFillType.Color)
                        {
                            double[] c1 = new double[] { f.Points[subp.PointIndices[0]].Z, subp.VertexColors[0].R, subp.VertexColors[0].G, subp.VertexColors[0].B };
                            double[] c2 = new double[] { f.Points[subp.PointIndices[1]].Z, subp.VertexColors[1].R, subp.VertexColors[1].G, subp.VertexColors[1].B };
                            double[] c3 = new double[] { f.Points[subp.PointIndices[2]].Z, subp.VertexColors[2].R, subp.VertexColors[2].G, subp.VertexColors[2].B };

                            foreach (var pix in Raster.Triangle((p1, c1), (p2, c2), (p3, c3)))
                            {
                                int x = pix.Item1.X, y = pix.Item1.Y;
                                double z = pix.Item2[0];

                                if (z > 0 && x > 0 && x < sW && y > 0 && y < sH && ZB[x, y] > z)
                                {
                                    ZB[x, y] = z;
                                    Color c = Color.FromArgb((int)pix.Item2[1], (int)pix.Item2[2], (int)pix.Item2[3]);
                                    CB[x, y] = c;
                                }
                            }
                        }
                        else if (p.PlaneFill == PlaneFillType.Texture)
                        {
                            double[] t1 = new double[] { f.Points[subp.PointIndices[0]].Z, subp.TextureCoordinates[0].Item1, subp.TextureCoordinates[0].Item2 };
                            double[] t2 = new double[] { f.Points[subp.PointIndices[1]].Z, subp.TextureCoordinates[1].Item1, subp.TextureCoordinates[1].Item2 };
                            double[] t3 = new double[] { f.Points[subp.PointIndices[2]].Z, subp.TextureCoordinates[2].Item1, subp.TextureCoordinates[2].Item2 };

                            var t = new Bitmap(p.Texture);

                            foreach (var pix in Raster.Triangle((p1, t1), (p2, t2), (p3, t3)))
                            {
                                int x = pix.Item1.X, y = pix.Item1.Y;
                                double z = pix.Item2[0];

                                if (z > 0 && x > 0 && x < sW && y > 0 && y < sH && ZB[x, y] > z)
                                {
                                    ZB[x, y] = z;
                                    Color c = t.GetPixel((int)pix.Item2[1], (int)pix.Item2[2]);
                                    CB[x, y] = c;
                                }
                            }
                        }
                    }
        }


        public static void DrawShade(List<Figure3D> figures, double[,] ZB, Color[,] CB, int sW, int sH, int scale)
        {
            foreach (var f in figures.Where(x => x.Planes.Count > 0))
                foreach (var p in f.Planes.Where(x => x.Visible))
                    foreach (var subp in p.Triangulate())
                    {
                        var p1 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[0]], sW, sH, scale);
                        var p2 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[1]], sW, sH, scale);
                        var p3 = Methods.PointOnRealScreen(f.Points[subp.PointIndices[2]], sW, sH, scale);

                        if (p.PlaneFill == PlaneFillType.Color)
                        {
                            var bulb = figures.Find(x => x.Tag.Equals("Bulb"));

                            FigureParts.Point.Point3D point1 = f.Points[subp.PointIndices[0]];
                            Color color1 = Methods.GetColorOfPointWithLight(point1, subp.VertexColors[0], f.NormalPoints[subp.PointIndices[0]], bulb);
                            double[] c1 = new double[] { point1.Z, color1.R, color1.G, color1.B };

                            FigureParts.Point.Point3D point2 = f.Points[subp.PointIndices[1]];
                            Color color2 = Methods.GetColorOfPointWithLight(point2, subp.VertexColors[1], f.NormalPoints[subp.PointIndices[1]], bulb);
                            double[] c2 = new double[] { point2.Z, color2.R, color2.G, color2.B };

                            FigureParts.Point.Point3D point3 = f.Points[subp.PointIndices[2]];
                            Color color3 = Methods.GetColorOfPointWithLight(point3, subp.VertexColors[2], f.NormalPoints[subp.PointIndices[2]], bulb);
                            double[] c3 = new double[] { point3.Z, color3.R, color3.G, color3.B };

                            foreach (var pix in Raster.Triangle((p1, c1), (p2, c2), (p3, c3)))
                            {
                                int x = pix.Item1.X, y = pix.Item1.Y;
                                double z = pix.Item2[0];

                                if (z > 0 && x > 0 && x < sW && y > 0 && y < sH && ZB[x, y] > z)
                                {
                                    ZB[x, y] = z;
                                    Color c = Color.FromArgb((int)pix.Item2[1], (int)pix.Item2[2], (int)pix.Item2[3]);
                                    CB[x, y] = c;
                                }
                            }
                        }
                        else if (p.PlaneFill == PlaneFillType.Texture)
                        {
                            double[] t1 = new double[] { f.Points[subp.PointIndices[0]].Z, subp.TextureCoordinates[0].Item1, subp.TextureCoordinates[0].Item2 };
                            double[] t2 = new double[] { f.Points[subp.PointIndices[1]].Z, subp.TextureCoordinates[1].Item1, subp.TextureCoordinates[1].Item2 };
                            double[] t3 = new double[] { f.Points[subp.PointIndices[2]].Z, subp.TextureCoordinates[2].Item1, subp.TextureCoordinates[2].Item2 };

                            var t = new Bitmap(p.Texture);

                            foreach (var pix in Raster.Triangle((p1, t1), (p2, t2), (p3, t3)))
                            {
                                int x = pix.Item1.X, y = pix.Item1.Y;
                                double z = pix.Item2[0];

                                if (z > 0 && x > 0 && x < sW && y > 0 && y < sH && ZB[x, y] > z)
                                {
                                    ZB[x, y] = z;
                                    Color c = t.GetPixel((int)pix.Item2[1], (int)pix.Item2[2]);
                                    CB[x, y] = c;
                                }
                            }
                        }
                    }
        }


    }
}
