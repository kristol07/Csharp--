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
            int xCoordinate = (int)Math.Round(X);
            int yCoordinate = (int)Math.Round(Y);

            return "(" + xCoordinate + "," + yCoordinate + ")";
        }
    }

}