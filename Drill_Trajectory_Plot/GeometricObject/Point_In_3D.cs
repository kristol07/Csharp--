using System.Collections.Generic;

namespace GeometricObject
{
    public struct PointIn3D
    {
        public double X
        {
            get; set;
        }
        public double Y
        {
            get; set;
        }
        public double Z
        {
            get; set;
        }

        public PointIn3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        public string FormatForSave()
        {
            List<string> coordinates = new List<string>();

            coordinates.Add(X.ToString());
            coordinates.Add(Y.ToString());
            coordinates.Add(Z.ToString());

            string seperator = ",";

            return string.Join(seperator, coordinates);
        }
    }
}