using System;
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

        public DistanceUnit Unit
        {
            get; set;
        }

        public PointIn3D(double x, double y, double z, DistanceUnit unit = DistanceUnit.meter)
        {
            X = x;
            Y = y;
            Z = z;
            Unit = unit;
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }

        public string FormatForSave()
        {
            return X + "," + Y + "," + Z;
        }

        public string GetAnnotation()
        {
            double xCoordinate = Math.Round(X, 0);
            double yCoordinate = Math.Round(Y, 0);
            double zCoordinate = Math.Round(Z, 0);

            return "(" + xCoordinate + "," + yCoordinate+ "," + zCoordinate + ")";
        }
    }
}