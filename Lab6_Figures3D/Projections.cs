using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math; 

namespace Lab6_Figures3D
{
    public static class Projection
    {
        public static double DeltaX3D(Point3D p1, Point3D p2) => Abs(p1.X - p2.X);
        public static double DeltaY3D(Point3D p1, Point3D p2) => Abs(p1.Y - p2.Y);
        public static double DeltaZ3D(Point3D p1, Point3D p2) => Abs(p1.Z - p2.Z);

        public static double Point3DDistance(Point3D p1, Point3D p2)
        {
            return Sqrt(Pow(DeltaX3D(p1, p2), 2) + Pow(DeltaY3D(p1, p2), 2) + Pow(DeltaZ3D(p1, p2), 2));
        }

        public static Point3D ParallelPoint(Point3D point, Flat3D flat)
        {
            var normalVector = new double[3] { flat.X, flat.Y, flat.Z };
            var eqX = new Line2D(normalVector[0], point.X);
            var eqY = new Line2D(normalVector[1], point.Y);
            var eqZ = new Line2D(normalVector[2], point.Z);
            eqX.K *= flat.X; eqX.B *= flat.X;
            eqY.K *= flat.Y; eqY.B *= flat.Y;
            eqZ.K *= flat.Z; eqZ.B *= flat.Z;
            var Tcoef = eqX.K + eqY.K + eqZ.K;
            var A = eqX.B + eqY.B + eqZ.B;
            var T = -A / Tcoef;

            return new Point3D(eqX.K * T + eqX.B, eqY.K * T + eqY.B, eqZ.K * T + eqZ.B);
        }

        public static Point3D CentralPoint(Point3D point, Flat3D flat, Point3D where)
        {
            var cameraProjection = ParallelPoint(where, flat);
            var pointProjection = ParallelPoint(point, flat);

            var cameraDist = Point3DDistance(where, cameraProjection);
            var pointDist = Point3DDistance(point, pointProjection);

            var difference = cameraProjection - pointProjection;
            var coef = cameraDist / pointDist;

            return cameraProjection + difference * coef; 
        }

        public static (Point2D, Point2D) ParallelEdge(Edge3D edge, Flat3D flat)
        {
            return new Edge2D(ParallelPoint(edge.P1), ParallelPoint(edge.P2)); 
        }
    }
}
