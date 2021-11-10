using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
    public enum ProjectionType { Parallel, Central }

    public class Camera
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
        // ScI and ScJ are scale points to scale unit vectors by ScI/ScJ - View

        public Point3D Location, View, I, J, ScF;
         
        // Scale in unit vectors I and J respectively of camera screen

        public double Width { get; set; }
        public double Height { get; set; }
        public (double, double) Resolution { get; set; }

        // Parallel or Central
        public ProjectionType Projection { get; set; }

        public Camera(Point3D location, Point3D view, Point3D i, Point3D j)
        {
            Location = location;
            View = view;
            I = i;
            J = j;
            ScF = (View - Location) / 10; 
            Width = 2;
            Height = 1; 
            Resolution = (800, 400);
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

            Location = new(0, 0, 3);
            View = new(0, 0, 2);
            I = new(1, 0, 2);
            J = new(0, 1, 2);
            ScF = (View - Location) / 10;
            Width = 2;
            Height = 1;
            Resolution = (800, 400);
        }

        public void Shift(Point3D vector)
        {
            Location += vector;
            View += vector;
            I += vector;
            J += vector;
        }

        public void RotateUpDown(bool up, double angle)
        {
            var vec = I - View;
            var edge = new Edge3D(Location, Location + vec);
            View = Transform.RotateAroundLine(edge, View, up ? angle : -angle);
            I = Transform.RotateAroundLine(edge, I, up ? angle : -angle);
            J = Transform.RotateAroundLine(edge, J, up ? angle : -angle);
            ScF = Transform.RotateAroundLine(edge, ScF, up ? angle : -angle);
        }

        public void RotateLeftRight(bool left, double angle)
        {
            var vec = J - View;
            var edge = new Edge3D(Location, Location + vec);
            View = Transform.RotateAroundLine(edge, View, left ? angle : -angle);
            I = Transform.RotateAroundLine(edge, I, left ? angle : -angle);
            J = Transform.RotateAroundLine(edge, J, left ? angle : -angle);
            ScF = Transform.RotateAroundLine(edge, ScF, left ? angle : -angle);
        }

        public void Rotate(Edge3D edge, double angle)
        {
            Location = Transform.RotateAroundLine(edge, Location, angle);
            View = Transform.RotateAroundLine(edge, View, angle);
            I = Transform.RotateAroundLine(edge, I, angle);
            J = Transform.RotateAroundLine(edge, J, angle);
            ScF = Transform.RotateAroundLine(edge, ScF, angle);
        }

        public void ScaleI(bool more) => Width += more ? 0.1 : -0.1;
        public void ScaleJ(bool more) => Height += more ? 0.1 : -0.1;

        public void ScaleFocus(bool more)
        {
            var screen = GetScreenFlat();
            // var vector = new Point3D(screen.X, screen.Y, screen.Z);
            // vector /= 10;
            if (more)
            {
                View += ScF;
                I += ScF;
                J += ScF;
            } 
            else
            {
                View -= ScF;
                I -= ScF;
                J -= ScF;
            }
        }

        public Point2D ToRealScreen(Point2D onScreenFlat)
        {
            return new Point2D(
                onScreenFlat.X / Width * (Resolution.Item1 / 2), 
                onScreenFlat.Y / Height * (Resolution.Item2 / 2)
                );
        }

        /// <summary>
        /// Getting flat on which screen lays by 3 points: (View, I, J)
        /// </summary>
        /// <returns>Flat of screen</returns>
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

            var i = Methods.GetUnitScale(new Edge3D(View, I), onScreen);
            var j = Methods.GetUnitScale(new Edge3D(View, J), onScreen);
            return new Point2D(i, j);
        }

        /// <summary>
        /// Getting figure in unit vectors I and J coordinates on screen flat
        /// </summary>
        /// <param name="f">Figure in 3D</param>
        /// <returns>Projection of f to screen flat in unit vectors</returns>
        public Figure2D GetFigure2D(Figure3D f)
        {
            var f2d = new Figure2D();
            Console.WriteLine(f.Points.Count);
            var l = new List<Point2D>();
            foreach (var p in f.Points)
            {
                l.Add(GetIJCoordinates(p));
            }
            f2d.Points = l; // f.Points.Select(p => GetIJCoordinates(p)).ToList();
            f2d.Lines = f.Lines;
            f2d.Planes = f.Planes;
            return f2d; 
        }

        /// <summary>
        /// Main method for displaying figures, each is projectod onto screen flat
        /// </summary>
        /// <param name="figs">List of figures in 3D</param>
        /// <returns>List of figures on screen flat in unit vectors</returns>
        public List<Figure2D> GetFigures(List<Figure3D> figs) => figs.Select(x => GetFigure2D(x)).ToList();

    }
}
