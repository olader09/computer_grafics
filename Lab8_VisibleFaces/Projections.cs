using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
using static Lab6_Figures3D.Methods; 

namespace Lab6_Figures3D
{
    public static class Projections
    {
        public static Point3D ProjectionPointToLine3D(Point3D point, Line3D line)
        {
            Flat3D flat = NormalFlat(line, point);
            return ParallelPoint(new Point3D(line.LX.B, line.LY.B, line.LZ.B), flat);
        }

        public static Point3D ParallelPoint(Point3D point, Flat3D flat)
        {
            var normalVector = new double[3] { flat.X, flat.Y, flat.Z };
            var eqX = new Line2D(normalVector[0], point.X);
            var eqY = new Line2D(normalVector[1], point.Y);
            var eqZ = new Line2D(normalVector[2], point.Z);
            var new_eqX = new Line2D(eqX.K, eqX.B);
            var new_eqY = new Line2D(eqY.K, eqY.B);
            var new_eqZ = new Line2D(eqZ.K, eqZ.B);
            new_eqX.K *= flat.X; new_eqX.B *= flat.X;
            new_eqY.K *= flat.Y; new_eqY.B *= flat.Y;
            new_eqZ.K *= flat.Z; new_eqZ.B *= flat.Z;
            var Tcoef = new_eqX.K + new_eqY.K + new_eqZ.K;
            var A = new_eqX.B + new_eqY.B + new_eqZ.B + flat.A;
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
            var coef = pointDist / (cameraDist + pointDist);

            return pointProjection + difference * coef; 
        }
    }
}
