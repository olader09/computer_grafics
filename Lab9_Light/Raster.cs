using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Room
{
    /*
    public class Raster
    {
        int X, Y;
        double Z;
        Color C;
        int TX, TY; 

        public Raster(int x, int y, double z, Color c, double tx, double ty)
        {
            X = x;
            Y = y;
            Z = z; 
            C = c;
            TX = tx;
            TY = ty;
        }

        public static IEnumerable<Raster> Triangle(Raster r1, Raster r2, Raster r3)
        {

        }

        // Draws triangle where r2 and r3 is horisontal line and r1 is (down ? under: above)
        // r2 is on left to the r3
        private static IEnumerable<Raster> HorizontalTriangle(Raster r1, Raster r2, Raster r3, bool down)
        {
            if (down)
            {
                int rows = r2.Y - r1.Y;

                double deltaX = (r2.X - r1.X) / rows;
                double deltaZ = (r2.Z - r1.Z) / rows; 
                double deltaR = (r2.C.R - r1.C.R) / rows;
                double deltaG = (r2.C.G - r1.C.G) / rows;
                double deltaB = (r2.C.B - r1.C.B) / rows;
                double deltaTX = (r2.TX - r1.TX) / rows;
                double deltaTY = (r2.TY - r1.TY) / rows; 

                List<Raster> left = new List<Raster>();
                for (int i = 0; i < rows; ++i)
                    left.Add(
                        new Raster(
                            (int)(r1.X + deltaX),
                            r1.Y + i,
                            r1.Z + deltaZ,
                            Color.FromArgb(
                                (int)(r1.C.R + deltaR),
                                (int)(r1.C.G + deltaG),
                                (int)(r1.C.B + deltaB)),
                            (int)(r1.TX + deltaTX),
                            (int)(r1.TY + deltaTY)
                        )
                    );
            }
        }
    }
    */
}
