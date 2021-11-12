using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureParts.Point;
using FigureParts.Edge;
using GeometricPrimitives.CanonicFlat; 

namespace Lab6_Figures3D
{
    public static class Transform
    {
        public static Point3D Shift(Point3D point, Point3D vector)
        {
            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = beg.Mult(Matrix.ShiftMatrix(vector));
            return new Point3D(res[0,0], res[0,1], res[0,2]);
        }

        public static Point3D RotateAroundLine(Edge3D edge, Point3D point, double angle)
        {
            point -= edge.P1; 
            var p = new double[1, 4] { { point.X, point.Y, point.Z, 1} };
            //var lp = new double[1, 4] { { edge.P2.X, edge.P2.Y, edge.P2.Z, 1} };
            var lp = edge.P2 - edge.P1;
            var lpLen = Methods.Point3DDistance(edge.P1, edge.P2);
            lp /= lpLen; 

            // Shifted to origin
            // var shiftMatrix = Matrix.ShiftMatrix(-edge.P1);
            // lp -= edge.P1; 
            // p = p.Mult(shiftMatrix);
            // Rotate around OX
            /* var Ox = Matrix.RX(new Point3D(lp[0, 0], lp[0, 1], lp[0, 2]));
            lp = lp.Mult(Ox);
            p = p.Mult(Ox);
            // Rotate around OY
            var Oy = Matrix.RY(new Point3D(lp[0, 0], lp[0, 1], lp[0, 2]));
            lp = lp.Mult(Oy);
            p = p.Mult(Oy);
            // Rotate around OZ 
            var Oz = Matrix.RotateZ(angle);
            p = p.Mult(Oz); 
            // Rotate back around OY
            */
            p = p.Mult(Matrix.BigOne(lp, angle));
            var pp = new Point3D(p[0, 0], p[0, 1], p[0, 2]); 

            //var shiftBack = Matrix.ShiftMatrix(edge.P1);
            //p = p.Mult(shiftBack);
            return pp + edge.P1; 
        }

        public static Point3D RotateX(Point3D point, double angle)
        {
            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = beg.Mult(Matrix.RotateX(angle));
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        public static Point3D RotateY(Point3D point, double angle)
        {

            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = beg.Mult(Matrix.RotateY(angle));
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        public static Point3D RotateZ(Point3D point, double angle)
        {

            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] res = beg.Mult(Matrix.RotateZ(angle));
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        // We have
        // from *--------->* point
        // We want 
        // from *----------|------------------> new_point (was scaled by ~ 2.7)
        public static Point3D Scale(Point3D point, Point3D from, double coef)
        {
            double[,] beg = new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            double[,] shift = Matrix.ShiftMatrix(-from);
            double[,] shiftBack = Matrix.ShiftMatrix(from);

            double[,] res = beg.Mult(shift); 
            res = res.Mult(Matrix.ScaleMatrix(coef, coef, coef));
            res = res.Mult(shiftBack); 
            return new Point3D(res[0, 0], res[0, 1], res[0, 2]);
        }

        public static Point3D Reflect(Flat3D flat, Point3D point)
        {
            var pointOnFlat = Projections.ParallelPoint(point, flat);
            var vec = pointOnFlat - point;
            return point + vec * 2;
        }
    }
}
