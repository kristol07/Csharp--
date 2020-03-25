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

        public string Annotation { get; set; }

        public Point(double x, double y, string annotation = "")
        {
            X = x;
            Y = y;
            Annotation = annotation;
        }

        public override string ToString()
        {
            return "(" + X + "," + Y + ")";
        }


    }

}