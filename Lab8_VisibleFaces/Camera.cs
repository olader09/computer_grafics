using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_Figures3D
{
    public enum ProjectionType { Isometric, Dimetric, Trimetric, Cabinet, Cavalier, Millitary, P1, P2, P3, Parallel, Central }

    class Camera
    {
        public double Width, Height, Focus;

        public Point3D Location, Up, Right, View;

        public ProjectionType Projection;

        public Camera()
        {
            Projection = ProjectionType.P1;
            Location = new(0, 0, 0);
            Right = new(1, 0, 0);
            Up = new(0, 1, 0);
            View = new(0, 0, 1);
            Width = 2;
            Height = 1;
            Focus = 0.001; 
        }

        public void Shift(Point3D vector)
        {

        }

        public (bool, Point2D) Project(Point3D point)
        {
            switch (Projection)
            {
                case ProjectionType.P1:
                    var matr = Matrix.P1(Focus);
                    var p = Matrix.Point(point);
                    var result = Matrix.GetPoint(p * matr * (1/ (Focus * point.Z + 1)));
                    if (point.Z < 0)
                        return (false, new());
                    if (point.Z == 0)
                        return (true, new(point.X, point.Y));
                    else
                        return (true, new Point2D(point.X / point.Z, point.Y / point.Z)); //new(point.X / (1 - point.Z * Focus), point.Y / (1 - point.Z * Focus)));
                    break; 
            }

            return (false, new Point2D()); 
        }

        public void MoveForward() => Location += View / 4;
        public void MoveBackward() => Location -= View / 4;
        public void MoveRight() => Location += Right / 4;
        public void MoveLeft() => Location -= Right / 4;
        public void MoveUp() => Location += Up / 4;
        public void MoveDown() => Location -= Up / 4;

        public void RotateUpDown(bool up, double angle)
        {
            var vec = Right - View;
            var edge = new Edge3D(Location, Location + vec);
            View = Transform.RotateAroundEdge(edge, View, up ? angle : -angle);
            Right = Transform.RotateAroundEdge(edge, Right, up ? angle : -angle);
            Up = Transform.RotateAroundEdge(edge, Up, up ? angle : -angle);
        }

        public void RotateLeftRight(bool left, double angle)
        {
            var vec = Up - View;
            var edge = new Edge3D(Location, Location + vec);
            View = Transform.RotateAroundEdge(edge, View, left ? angle : -angle);
            Right = Transform.RotateAroundEdge(edge, Right, left ? angle : -angle);
            Up = Transform.RotateAroundEdge(edge, Up, left ? angle : -angle);
        }

        public void Rotate(Edge3D edge, double angle)
        {
            Location = Transform.RotateAroundEdge(edge, Location, angle);
            View = Transform.RotateAroundEdge(edge, View, angle);
            Right = Transform.RotateAroundEdge(edge, Right, angle);
            Up = Transform.RotateAroundEdge(edge, Up, angle);
        }

        public Figure3D GetFigureInViewCoordinates(Figure3D f)
        {
            Matrix ViewMatrix = GetViewMatrix(); 
            Figure3D fNew = new();
            fNew.Lines = new(f.Lines);
            fNew.Planes = new(f.Planes);
            fNew.Points = f.Points.Select(p =>
            {
                Matrix tr = (Matrix)new double[,] { { p.X, p.Y, p.Z, 1 } };
                var newP = tr * ViewMatrix;
                return new Point3D(newP[0, 0], newP[0, 1], newP[0, 2]);
            }).ToList();
            return fNew; 
        }

        public List<Figure3D> GetAllFiguresInViewCoordinates(List<Figure3D> figs)
            => figs.Select(x => GetFigureInViewCoordinates(x)).ToList();

        public Matrix GetViewMatrix() => Matrix.View(Up - Location, Right - Location, View, Location);
    }
}
