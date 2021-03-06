using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
    public static class Transform
    {
        #region Shift

        public static Point3D Shift(Point3D point, Point3D vector)
        {
            Matrix begin = (Matrix)new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            Matrix res = begin * Matrix.Shift(vector);
            return new Point3D(res.Value[0,0], res.Value[0,1], res.Value[0,2]);
        }

        #endregion

        #region Rotate

        public static Point3D RotateAroundEdge(Edge3D edge, Point3D point, double angle)
        {
            var shiftToCenter = Matrix.Shift(edge.P1);

            point -= edge.P1; 

            var p = (Matrix) new double[1, 4] { { point.X, point.Y, point.Z, 1} };
            var lp = edge.P2 - edge.P1;
            var lpLen = Methods.Point3DDistance(edge.P1, edge.P2);
            lp /= lpLen; 
            p *= Matrix.BigOne(lp, angle);
            var pp = new Point3D(p.Value[0, 0], p.Value[0, 1], p.Value[0, 2]); 
            return pp + edge.P1; 
        }

        public static Point3D RotateAroundX(Point3D point, double angle)
        {
            Matrix begin = (Matrix) new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            Matrix res = begin * Matrix.RotateX(angle);
            return new Point3D(res.Value[0, 0], res.Value[0, 1], res.Value[0, 2]);
        }

        public static Point3D RotateAroundY(Point3D point, double angle)
        {

            Matrix begin = (Matrix) new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            Matrix res = begin * Matrix.RotateY(angle);
            return new Point3D(res.Value[0, 0], res.Value[0, 1], res.Value[0, 2]);
        }

        public static Point3D RotateAroundZ(Point3D point, double angle)
        {
            Matrix begin = (Matrix) new double[1, 4] { { point.X, point.Y, point.Z, 1 } };
            Matrix res = begin * Matrix.RotateZ(angle);
            return new Point3D(res.Value[0, 0], res.Value[0, 1], res.Value[0, 2]);
        }

        #endregion

        #region Scale

        // We have
        // from *--------->* point
        // We want 
        // from *----------|------------------> new_point (was scaled by ~ 2.7)
        public static Point3D Scale(Point3D point, Point3D from, double coef)
        {
            Matrix begin = (Matrix) new double[1, 4] { { point.X, point.Y, point.Z, 1 } };

            Matrix shift = Matrix.Shift(-from);
            Matrix shiftBack = Matrix.Shift(from);

            Matrix res = begin * shift * Matrix.Scale(coef, coef, coef) * shiftBack; 
            return new Point3D(res.Value[0, 0], res.Value[0, 1], res.Value[0, 2]);
        }

        #endregion

        #region Reflect

        public static Point3D Reflect(Flat3D flat, Point3D point)
        {
            var pointOnFlat = Projections.ParallelPoint(point, flat);
            var vec = pointOnFlat - point;
            return point + vec * 2;
        }

        #endregion
    }
}
