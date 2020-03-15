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
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }

        public string GetAnnotation()
        {
            string xCoordinate = Math.Round(X).ToString();
            string yCoordinate = Math.Round(Y).ToString();
            if (xCoordinate.Contains('.'))
            {
                xCoordinate = xCoordinate.Remove(xCoordinate.IndexOf('.'));
            }
            if (yCoordinate.Contains('.'))
            {
                yCoordinate = yCoordinate.Remove(yCoordinate.IndexOf('.'));
            }
            return "(" + xCoordinate + "," + yCoordinate + ")";
        }
    }

}