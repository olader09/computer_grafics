using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static GeometricFunctions.Methods;
using FigureParts.Point;
using GeometricPrimitives.CanonicFlat;
using GeometricPrimitives.ParametricLine;
using Figure;

namespace GeometricFunctions
{
    public static class Projections
    {
        public static Figure3D ProjectP1(Figure3D figure)
        {
            Figure3D result = new Figure3D(figure);
            result.Points = result.Points.Select(p => new Point3D(p.X / (p.Z + 1), p.Y / (p.Z + 1), p.Z)/*Projections.Perspective1(p)*/).ToList();
            return result;
        }

        public static Figure3D ProjectParallel(Figure3D figure)
        {
            return new Figure3D(figure);
        }

        public static Point3D Perspective1(Point3D point)
        {
            var pointMatrix = Matrix.Point(point);
            var projectionMatrix = Matrix.CentralProjection();
            var result = pointMatrix * projectionMatrix;
            return Matrix.To2DPoint(result);
        }
    }
}
