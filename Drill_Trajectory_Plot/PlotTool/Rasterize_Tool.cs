using System;
using System.Collections.Generic;
using GeometricObject;

namespace PlotTool
{
    public static class RasterizeTool
    {
        public static List<Pixel> GetPixelsOfLineLow(int x0, int y0, int x1, int y1)
        {

            List<Pixel> pixelsToPlot = new List<Pixel>();

            int dx = x1 - x0, dy = y1 - y0;

            int yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -1 * dy;
            }

            int D = 2 * dy - dx;

            int j = y0;
            for (int i = x0 + 1; i < x1; i++)
            {
                char symbol = '-';

                if (D > 0)
                {
                    j = j + yi;
                    D = D - 2 * dx;
                    if (yi > 0)
                    {
                        symbol = '\\';
                    }
                    else
                    {
                        symbol = '/';
                    }
                }
                D = D + 2 * dy;
                pixelsToPlot.Add(new Pixel(i, j, symbol));
            }

            return pixelsToPlot;
        }

        public static List<Pixel> GetPixelsOfLineHigh(int x0, int y0, int x1, int y1)
        {

            List<Pixel> pixelsToPlot = new List<Pixel>();

            int dx = x1 - x0, dy = y1 - y0;

            int xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -1 * dx;
            }

            int D = 2 * dx - dy;

            int i = x0;
            for (int j = y0 + 1; j < y1; j++)
            {
                char symbol = '|';

                if (D > 0)
                {
                    i = i + xi;
                    D = D - 2 * dy;
                    if (xi > 0)
                    {
                        symbol = '\\';
                    }
                    else
                    {
                        symbol = '/';
                    }
                }
                D = D + 2 * dx;
                pixelsToPlot.Add(new Pixel(i, j, symbol));
            }

            return pixelsToPlot;
        }

        public static List<Pixel> GetPixelsOfLine(int x0, int y0, int x1, int y1)
        {
            if (Math.Abs(y1 - y0) < Math.Abs(x1 - x0))
            {
                if (x0 > x1)
                {
                    return GetPixelsOfLineLow(x1, y1, x0, y0);
                }
                else
                {
                    return GetPixelsOfLineLow(x0, y0, x1, y1);
                }
            }
            else
            {
                if (y0 > y1)
                {
                    return GetPixelsOfLineHigh(x1, y1, x0, y0);
                }
                else
                {
                    return GetPixelsOfLineHigh(x0, y0, x1, y1);
                }
            }
        }

        public static List<Pixel> GetPixelsOfPolyLineNodes(List<Point> polyLineNodes, double magnification)
        {
            List<Pixel> pixelsOfNodes = new List<Pixel>();

            foreach (var node in polyLineNodes)
            {
                int x = (int)Math.Round(node.X * magnification);
                int y = (int)Math.Round(node.Y * magnification);

                pixelsOfNodes.Add(new Pixel(x, y, '+'));
            }

            return pixelsOfNodes;
        }

        public static List<Pixel> GetPixelsOfPolyLine(List<Point> polyLineNodes, double magnification)
        {
            List<Pixel> pixelsOfLines = new List<Pixel>();

            for (int i = 0; i < polyLineNodes.Count - 1; i++)
            {
                int x0 = (int)Math.Round(polyLineNodes[i].X * magnification), y0 = (int)Math.Round(polyLineNodes[i].Y * magnification);
                int x1 = (int)Math.Round(polyLineNodes[i + 1].X * magnification), y1 = (int)Math.Round(polyLineNodes[i + 1].Y * magnification);

                pixelsOfLines.AddRange(GetPixelsOfLine(x0, y0, x1, y1));
            }

            return pixelsOfLines;
        }

        public static Dictionary<Point, Pixel> MapNodeToPixel(List<Point> polyLineNodes, double magnification)
        {
            Dictionary<Point, Pixel> map = new Dictionary<Point, Pixel>();

            foreach (var node in polyLineNodes)
            {
                int x = (int)Math.Round(node.X * magnification);
                int y = (int)Math.Round(node.Y * magnification);

                map[node] = new Pixel(x, y, '+');
            }

            return map;
        }
    }

}