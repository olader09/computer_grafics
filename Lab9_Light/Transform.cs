using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureParts.Point;
using FigureParts.Edge;
using GeometricPrimitives.CanonicFlat;

namespace GeometricFunctions
{
    public static class Transform
    {
        public static Point3D Shift(Point3D point, Point3D vector)
        {
            return Matrix.To3DPoint(Matrix.Point(point) * Matrix.ShiftMatrix(vector));
        }

        public static Point3D RotateAroundLine(Edge3D edge, Point3D point, double angle)
        {
            point -= edge.P1;
            Matrix p = Matrix.Point(point);
            //var lp = new double[1, 4] { { edge.P2.X, edge.P2.Y, edge.P2.Z, 1} };
            var lp = edge.P2 - edge.P1;
            var lpLen = Methods.Point3DDistance(edge.P1, edge.P2);
            lp /= lpLen; 
            p = p * Matrix.BigOne(lp, angle);
            var pp = Matrix.To3DPoint(p); 

            //var shiftBack = Matrix.ShiftMatrix(edge.P1);
            //p = p.Mult(shiftBack);
            return pp + edge.P1; 
        }

        public static Point3D RotateX(Point3D point, double angle)
        {
            return Matrix.To3DPoint(Matrix.Point(point) * Matrix.RotateX(angle));
        }

        public static Point3D RotateY(Point3D point, double angle)
        {
            return Matrix.To3DPoint(Matrix.Point(point) * Matrix.RotateY(angle));
        }

        public static Point3D RotateZ(Point3D point, double angle)
        {
            return Matrix.To3DPoint(Matrix.Point(point) * Matrix.RotateZ(angle));
        }

        // We have
        // from *--------->* point
        // We want 
        // from *----------|------------------> new_point (was scaled by ~ 2.7)
        public static Point3D Scale(Point3D point, Point3D from, double coef)
        {
            Matrix beg = Matrix.Point(point);
            Matrix shift = Matrix.ShiftMatrix(-from);
            Matrix shiftBack = Matrix.ShiftMatrix(from);

            var res = beg * shift * Matrix.ScaleMatrix(coef, coef, coef) * shiftBack;
            return Matrix.To3DPoint(res);
        }

        public static Point3D Reflect(Flat3D flat, Point3D point)
        {
            var pointOnFlat = Projections.Parallel(point, flat);
            var vec = pointOnFlat - point;
            return point + vec * 2;
        }
    }
}
