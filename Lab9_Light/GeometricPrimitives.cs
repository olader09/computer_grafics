using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricPrimitives
{
    namespace ParametricLine
    {
        public class Line2D
        {
            public double K, B;

            public Line2D(double k, double b) { K = k; B = b; }
        }

        // Line in 3D
        public class Line3D
        {
            public Line2D LX, LY, LZ;
            public Line3D(Line2D lx, Line2D ly, Line2D lz)
            {
                LX = lx;
                LY = ly;
                LZ = lz;
            }
        }
    }

    namespace CanonicFlat
    {
        // Surface like line but in 3D
        public class Flat3D
        {
            public double X, Y, Z, A;

            public Flat3D(double x, double y, double z, double a)
            {
                X = x;
                Y = y;
                Z = z;
                A = a;
            }
        }
    }
}
