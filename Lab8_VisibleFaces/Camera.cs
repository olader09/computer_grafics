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
        public double Width, Height; 
        public double Focus
        {
            get => Focus; 
            set
            {
                if (value > 0 && value < double.PositiveInfinity)
                    Focus = value; 
            }
        }

        public ProjectionType Projection;

        public Matrix S, RX, RY, RZ;

        public Camera()
        {
            Projection = ProjectionType.Central;
            Width = 2;
            Height = 1;
            Focus = 1; 
            S = Matrix.IdentityMatrix();
            RX = Matrix.IdentityMatrix();
            RY = Matrix.IdentityMatrix();
            RZ = Matrix.IdentityMatrix();
        }

        public void Shift(Point3D vector)
        {
            S += Matrix.ShiftMatrix(vector);
        }

        public void RotateUp(double angle)
        {

        }

        public void RotateDown(double angle)
        {

        }

        public void RotateLeft(double angle)
        {

        }

        public void RotateRight(double angle)
        {

        }

        public void Rotate(Edge3D edge, double angle)
        {

        }

        public Figure3D GetFigureInViewCoordinates(Figure3D f)
        {
            throw new NotImplementedException("TODO");
        }

        public List<Figure3D> GetAllFiguresInViewCoordinates(List<Figure3D> figs)
            => figs.Select(x => GetFigureInViewCoordinates(x)).ToList();
    }
}
