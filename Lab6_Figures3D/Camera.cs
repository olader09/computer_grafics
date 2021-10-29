using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
    public enum ProjectionType { Parallel, Central }

    class Camera
    {
        // Location is camera center
        // View is projection of Location on screen surface 
        // I is unit vector on this surface
        // And so is J
        // So on surface where figures will be projected onto we have coordinates:
        //           
        //            Width
        // |--------------------------|                                               
        // |                       * - Random point (projection of point in 3D)
        // |          J            So Coordinates of this point are ~(2 * I, 1.5 * J) 
        // |          /\              |
        // |          ||              |
        // |         View => I        |
        // 
        // This should work as normal coordinates plane
        // In this example on picture your eye is like camera center
        // And the computer screen with this pictire is surface of projection
        //
        // Because we have to transform this I and J coordinates to pixel coordinates
        // We define flat of 'screen' (rectangle which will be stretched to real screen)
        // With our unit vectors I and J 
        //
        // To get this I and J coordinates see GetIJCoordinates method below

        public Point3D Location, View, I, J; 
        // public (double, double, double) Angle;

        public double Width { get; set; }
        public double Height { get; set; }

        public ProjectionType Projection { get; set; }

        public Camera(Point3D location, Point3D view, Point3D i, Point3D j)
        {
            Location = location;
            View = view;
            I = i;
            J = j;
            Width = 4;
            Height = 2;
        }

        public Camera()
        {
            // Let our world coordinates be 
            // 
            //    Y
            //    /\  
            //    |  /
            //    | /
            //    |/
            //    ---------------------> X
            //   /
            //  /
            // Z

            Location = new(0, 0, 5);
            View = new(0, 0, 4);
            I = new(1, 0, 4);
            J = new(0, 1, 4);
        }

        public void Shift(Point3D where)
        {
            Location += where;
        }

        public void Rotate(Line3D axis, double angle)
        {

        }

        public void Rotate(string axis, double angle)
        {

        }

        public Flat3D GetScreenFlat()
        {
            var nv = Location - View; 
            return new Flat3D(nv.X, nv.Y, nv.Z, (-View.X * nv.X) + (-View.Y * nv.Y) + (-View.Z * nv.Z)); 
        }

        // We assume that point is already on screen flat
        // So to get I and J coordinates we hawe to use trigonometric
        // Let us draw a line from our point to View point
        // The I coordinate is projection of our line to (View I) line
        // And so is J
        // So to implement this we hav to find projection of point
        // To (View I) line and this will be it
        // 
        //                          *
        //                          |
        //                          |  
        // View -----> I -------------------------
        //                          i
        // 
        // Let us do it with helper method ProjectionPointLine3D
        //
        public Point2D GetIJCoordinates(Point3D point)
        {
            var screen = GetScreenFlat(); 
            Point3D onScreen = Projection switch
            {
                ProjectionType.Parallel => Projections.ParallelPoint(point, screen),
                ProjectionType.Central => Projections.CentralPoint(point, screen, Location), 
            };

            var i = Methods.GetUnitScale(new Edge3D(View, I), point);
            var j = Methods.GetUnitScale(new Edge3D(View, J), point);
            return new Point2D(i, j);
        }

        public Figure2D GetFigure2D(Figure3D f)
        {
            var f2d = new Figure2D();
            f2d.Points = f.Points.Select(p => GetIJCoordinates(p)).ToList();
            f2d.Lines = f.Lines;
            f2d.Planes = f.Planes;
            return f2d; 
        }

        // Main method for displaying results
        public List<Figure2D> GetFigures(List<Figure3D> figs) => figs.Select(x => GetFigure2D(x)).ToList();

    }
}
