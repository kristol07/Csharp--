using System;
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

            int kneeIndex = GetKneeNodeIndex();
            double sideLength = Math.Pow(PolyLineNodes[kneeIndex].X, 2) + Math.Pow(PolyLineNodes[kneeIndex].Y, 2);
            double cosQ = PolyLineNodes[kneeIndex].X / (Math.Sqrt(sideLength));
            double sinQ = PolyLineNodes[kneeIndex].Y / (Math.Sqrt(sideLength));

            foreach (var point in PolyLineNodes)
            {
                string annotation = point.GetAnnotation();
                switch (view)
                {
                    case "Main":
                        pojectionInPlane.Add(new Point(point.X, point.Z, annotation));
                        break;
                    case "Left":
                        pojectionInPlane.Add(new Point(point.Y, point.Z, annotation));
                        break;
                    case "Top":
                        pojectionInPlane.Add(new Point(point.X, point.Y, annotation));
                        break;
                    case "Knee":
                        pojectionInPlane.Add(new Point(point.X * cosQ + point.Y * sinQ, point.Z, annotation));
                        break;
                }
            }

            return pojectionInPlane;
        }

        public int GetKneeNodeIndex()
        {
            for (int i = 0; i < PolyLineNodes.Count; i++)
            {
                if (PolyLineNodes[i].X != 0 || PolyLineNodes[i].Y != 0)
                {
                    return i;
                }
            }

            return -1;
        }





        // public List<double> GetxCoordinates()
        // {
        //     List<double> xCoordinates = new List<double>();

        //     foreach (var node in PolyLineNodes)
        //     {
        //         xCoordinates.Add(node.X);
        //     }
        //     xCoordinates.Sort();

        //     return xCoordinates;
        // }

        // public List<double> GetyCoordinates()
        // {
        //     List<double> yCoordinates = new List<double>();

        //     foreach (var node in PolyLineNodes)
        //     {
        //         yCoordinates.Add(node.Y);
        //     }
        //     yCoordinates.Sort();

        //     return yCoordinates;
        // }

        // public List<double> GetzCoordinates()
        // {
        //     List<double> zCoordinates = new List<double>();

        //     foreach (var node in PolyLineNodes)
        //     {
        //         zCoordinates.Add(node.Z);
        //     }
        //     zCoordinates.Sort();

        //     return zCoordinates;
        // }

        // public double GetxMin()
        // {
        //     List<double> xCoordinates = GetxCoordinates();
        //     return xCoordinates[0];
        // }

        // public double GetxMax()
        // {
        //     List<double> xCoordinates = GetxCoordinates();
        //     return xCoordinates[xCoordinates.Count - 1];
        // }

        // public double GetyMin()
        // {
        //     List<double> yCoordinates = GetyCoordinates();
        //     return yCoordinates[0];
        // }

        // public double GetyMax()
        // {
        //     List<double> yCoordinates = GetyCoordinates();
        //     return yCoordinates[yCoordinates.Count - 1];
        // }

        // public double GetzMin()
        // {
        //     List<double> zCoordinates = GetzCoordinates();
        //     return zCoordinates[0];
        // }

        // public double GetzMax()
        // {
        //     List<double> zCoordinates = GetzCoordinates();
        //     return zCoordinates[zCoordinates.Count - 1];
        // }
    }
}