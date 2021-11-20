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
            figures.ForEach(x => x.SetNormalVectors());
            figures.ForEach(x => x.MarkPlanesAsFaceOrNonFace());
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

        public static List<Figure3D> GetProjectedFigures(List<Figure3D> figures)
        {
            return figures.Select(f => f.Project()).ToList(); 
        }

        public static void DrawFullCarcass(List<Figure3D> figures, Graphics graphics, int sW, int sH)
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
                        Methods.PointOnRealScreen(p1, sW, sH),
                        Methods.PointOnRealScreen(p2, sW, sH)
                    );
                }
            }
        }

        public static void DrawFaceCarcass(List<Figure3D> figures, Graphics graphics, int sW, int sH)
        {
            DrawFullCarcass(figures.Where(x => x.Planes.Count == 0).ToList(), graphics, sW, sH);
            
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
                        Methods.PointOnRealScreen(p1, sW, sH),
                        Methods.PointOnRealScreen(p2, sW, sH)
                    );
                }
            }
        }

        public static void DrawZBuffer(List<Figure3D> figures, Graphics graphics, int sW, int sH)
        {
            double[,] ZBuffer = new double[sW, sH];
            Color[,] ColorBuffer = new Color[sW, sH];

            for (int i = 0; i < sW; ++i)
                for (int j = 0; j < sH; ++j)
                {
                    ZBuffer[i, j] = double.MaxValue;
                    ColorBuffer[i, j] = Color.White;
                }

        }
    }
}
