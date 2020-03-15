using System.Collections.Generic;

namespace GeometricObject
{
    public class PolyLineIn3D
    {
        public List<PointIn3D> PolyLineNodes
        {
            get; set;
        }

        public PolyLineIn3D()
        {
            PolyLineNodes = new List<PointIn3D>();
        }

        public void AddNodes(PointIn3D point)
        {
            PolyLineNodes.Add(point);
        }

        public void AddNodes(double x, double y, double z)
        {
            PointIn3D newNode = new PointIn3D(x, y, z);
            PolyLineNodes.Add(newNode);
        }

        public List<Point> GetProjectionInPlane(string view)
        {
            List<Point> pojectionInPlane = new List<Point>();

            switch (view)
            {
                case "Main":
                    foreach (var point in PolyLineNodes)
                    {
                        pojectionInPlane.Add(new Point(point.X, point.Z));
                    }
                    break;
                case "Left":
                    foreach (var point in PolyLineNodes)
                    {
                        pojectionInPlane.Add(new Point(point.Y, point.Z));
                    }
                    break;
                case "Top":
                    foreach (var point in PolyLineNodes)
                    {
                        pojectionInPlane.Add(new Point(point.X, point.Y));
                    }
                    break;
            }

            return pojectionInPlane;

        }

        public List<double> GetxCoordinates()
        {
            List<double> xCoordinates = new List<double>();

            foreach (var node in PolyLineNodes)
            {
                xCoordinates.Add(node.X);
            }
            xCoordinates.Sort();

            return xCoordinates;
        }

        public List<double> GetyCoordinates()
        {
            List<double> yCoordinates = new List<double>();

            foreach (var node in PolyLineNodes)
            {
                yCoordinates.Add(node.Y);
            }
            yCoordinates.Sort();

            return yCoordinates;
        }

        public List<double> GetzCoordinates()
        {
            List<double> zCoordinates = new List<double>();

            foreach (var node in PolyLineNodes)
            {
                zCoordinates.Add(node.Z);
            }
            zCoordinates.Sort();

            return zCoordinates;
        }

        public double GetxMin()
        {
            List<double> xCoordinates = GetxCoordinates();
            return xCoordinates[0];
        }

        public double GetxMax()
        {
            List<double> xCoordinates = GetxCoordinates();
            return xCoordinates[xCoordinates.Count - 1];
        }

        public double GetyMin()
        {
            List<double> yCoordinates = GetyCoordinates();
            return yCoordinates[0];
        }

        public double GetyMax()
        {
            List<double> yCoordinates = GetyCoordinates();
            return yCoordinates[yCoordinates.Count - 1];
        }

        public double GetzMin()
        {
            List<double> zCoordinates = GetzCoordinates();
            return zCoordinates[0];
        }

        public double GetzMax()
        {
            List<double> zCoordinates = GetzCoordinates();
            return zCoordinates[zCoordinates.Count - 1];
        }
    }
}