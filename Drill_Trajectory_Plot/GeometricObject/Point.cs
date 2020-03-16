using System;

namespace GeometricObject
{
    public struct Point
    {
        public double X
        {
            get; set;
        }

        public double Y
        {
            get; set;
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }

        public string GetAnnotation()
        {
            double xCoordinate = Math.Round(X, 1);
            double yCoordinate = Math.Round(Y, 1);
            

            return "(" + xCoordinate + "," + yCoordinate + ")";
        }
    }

}