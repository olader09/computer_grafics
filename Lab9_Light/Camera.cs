using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureParts.Point;
using FigureParts.Edge;
using GeometricFunctions;

namespace Cam
{
    public enum ProjectionType { Parallel, Central }

    public class Camera
    {
        private Point3D Location, Forward, Right, Up;

        public ProjectionType projectionType;

        private Matrix Transform;

        public Camera()
        {
            Transform = Matrix.IdentityMatrix();
            Location = new Point3D(0, 0, 0);
            Forward = new Point3D(0, 0, 1);
            Right = new Point3D(1, 0, 0);
            Up = new Point3D(0, 1, 0);
        } 

        private void Shift(Point3D vector)
        {
            var change = Matrix.ShiftMatrix(vector);

            Transform *= change;

            Location += vector;
            Right += vector;
            Up += vector;
            Forward += vector; 
        }

        private void Rotate(Edge3D edge, double angle)
        {
            var shift = Matrix.ShiftMatrix(edge.P1);
            var change = Matrix.BigOne(edge.P2 - edge.P1, angle);
            var shiftBack = Matrix.ShiftMatrix(-edge.P1);

            Location = GeometricFunctions.Transform.RotateAroundLine(edge, Location, angle);
            Right = GeometricFunctions.Transform.RotateAroundLine(edge, Right, angle);
            Up = GeometricFunctions.Transform.RotateAroundLine(edge, Up, angle);
            Forward = GeometricFunctions.Transform.RotateAroundLine(edge, Forward, angle);

            /*
            var l = Matrix.Point(Location);
            var r = Matrix.Point(Right);
            var u = Matrix.Point(Up);
            var f = Matrix.Point(Forward);

            Location = Matrix.To3DPoint(l * shift * change * shiftBack);
            Right = Matrix.To3DPoint(r * shift * change * shiftBack);
            Up = Matrix.To3DPoint(u * shift * change * shiftBack);
            Forward = Matrix.To3DPoint(f * shift * change * shiftBack);
            */

            Transform *= shift * change * shiftBack; 
        }

        public Matrix GetView()
        {
            return (Matrix)Accord.Math.Matrix.Inverse(Transform.Value);
        }

        // MOVE

        public void MoveForward() => Shift((Forward - Location) / 10); 

        public void MoveBack() => Shift(-(Forward - Location) / 10);

        public void MoveRight() => Shift((Right - Location) / 10);

        public void MoveLeft() => Shift(-(Right - Location) / 10);

        public void MoveUp() => Shift((Up - Location) / 10);

        public void MoveDown() => Shift(-(Up - Location) / 10);

        // ROTATE 

        public void TurnUp() => Rotate(new Edge3D(Location, Right), 5);

        public void TurnDown() => Rotate(new Edge3D(Location, Right), -5);

        public void TurnRight() => Rotate(new Edge3D(Location, Up), 5);

        public void TurnLeft() => Rotate(new Edge3D(Location, Up), -5);

        public void TurnClockwise() => Rotate(new Edge3D(Location, Forward), 5);

        public void TurnClockfool() => Rotate(new Edge3D(Location, Forward), -5);
    }
}
