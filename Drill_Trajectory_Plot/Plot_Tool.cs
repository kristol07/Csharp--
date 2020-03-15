using System;
using System.Linq;
using System.Collections.Generic;

namespace CsharpTest
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

                pixelsOfLines.AddRange(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
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

    public static class FigureTool
    {

        public static int GetWidth(List<List<char>> matrixOfPixels)
        {
            if (GetHeight(matrixOfPixels) > 0)
            {
                return matrixOfPixels[0].Count;
            }
            else
            {
                return 0;
            }

        }


        public static int GetHeight(List<List<char>> matrixOfPixels)
        {
            return matrixOfPixels.Count;
        }


        public static List<List<char>> InitFigure(int width, int height)
        {
            List<List<char>> matrixOfPixels = new List<List<char>>();

            if (width <= 0 || height <= 0)
            {
                throw new Exception("Figure size (width/height) should not be negative!");
            }

            for (int i = 0; i < height; i++)
            {
                matrixOfPixels.Add(new List<char>());
                for (int j = 0; j < width; j++)
                {
                    matrixOfPixels[i].Add(' ');
                }
            }

            return matrixOfPixels;
        }

        public static void AddGridFoFigure(List<List<char>> matrixOfPixels, int xGridDistance, int yGridDistance)
        {
            if (GetWidth(matrixOfPixels) > 0 && GetHeight(matrixOfPixels) > 0)
            {
                for (int i = 0; i < matrixOfPixels[0].Count; i = i + xGridDistance)
                {
                    for (int j = 0; j < matrixOfPixels.Count; j = j + yGridDistance)
                    {
                        matrixOfPixels[j][i] = '.';
                    }
                }
            }
        }

        public static void AddCoordinateGridForPixel(List<List<char>> matrixOfPixels, Pixel pixel)
        {
            int width = GetWidth(matrixOfPixels);
            int height = GetHeight(matrixOfPixels);

            if (width > 0 && height > 0 && pixel.X < width && pixel.Y < height)
            {

                for (int i = 0; i < pixel.X; i++)
                {
                    matrixOfPixels[pixel.Y][i] = '.';
                }
                for (int i = 0; i < pixel.Y; i++)
                {
                    matrixOfPixels[i][pixel.X] = '.';
                }

            }
        }

        public static void AddAnnotationForPixel(List<List<char>> matrixOfPixels, Pixel pixel, string annotation)
        {
            int width = GetWidth(matrixOfPixels);
            int height = GetHeight(matrixOfPixels);

            if (width > 0 && height > 0 && pixel.X < width && pixel.Y < height)
            {
                char[] charArrayOfAnnotation = annotation.ToCharArray();
                if (charArrayOfAnnotation.Length + pixel.X < width)
                {
                    for (int i = 0; i < charArrayOfAnnotation.Length; i++)
                    {
                        matrixOfPixels[pixel.Y][pixel.X + i + 1] = charArrayOfAnnotation[i];
                    }
                }
            }
        }


        public static void AddCoordinateAnnotationForPolyLineNodes(List<List<char>> matrixOfPixels, Dictionary<Point, Pixel> dictAnnotation)
        {
            foreach (var point in dictAnnotation.Keys)
            {
                string annotation = point.GetAnnotation();
                AddAnnotationForPixel(matrixOfPixels, dictAnnotation[point], annotation);
            }
        }

        public static int[] GetAxis(List<Pixel> pixels)
        {
            List<int> xcoordinate = new List<int>();
            List<int> ycoordinate = new List<int>();

            foreach (var pixel in pixels)
            {
                xcoordinate.Add(pixel.X);
                ycoordinate.Add(pixel.Y);
            }

            xcoordinate.Sort();
            ycoordinate.Sort();

            int xmin = xcoordinate[0];
            int xmax = xcoordinate[xcoordinate.Count - 1];
            int ymin = ycoordinate[0];
            int ymax = ycoordinate[ycoordinate.Count - 1];

            return new int[] { xmin, ymin, xmax, ymax };
        }

        public static Dictionary<Pixel, Pixel> MapPixelToFigure(List<Pixel> pixels)
        {
            int[] axis = GetAxis(pixels);

            Dictionary<Pixel, Pixel> pixelToFigure = new Dictionary<Pixel, Pixel>();

            foreach (var pixel in pixels)
            {
                pixelToFigure[pixel] = new Pixel(pixel.X - axis[0] + 5, pixel.Y - axis[1] + 5, pixel.Symbol);
            }

            return pixelToFigure;
        }

        public static Dictionary<Point, Pixel> MapNodeToFigure(Dictionary<Point, Pixel> pixelOfNodes)
        {
            Dictionary<Pixel, Pixel> pixeltoFigure = MapPixelToFigure(pixelOfNodes.Values.ToList());

            Dictionary<Point, Pixel> pixelOfNodesInFigure = new Dictionary<Point, Pixel>();
            foreach (var point in pixelOfNodes.Keys)
            {
                pixelOfNodesInFigure[point] = pixeltoFigure[pixelOfNodes[point]];
            }

            return pixelOfNodesInFigure;
        }


        // if x or y is negative ????
        public static List<List<char>> PlotPolyLine(List<Point> polyLineNodes, double magnification = 1.0)
        {
            List<Pixel> pixelsOfLines = RasterizeTool.GetPixelsOfPolyLine(polyLineNodes, magnification);
            List<Pixel> pixelsOfNodes = RasterizeTool.GetPixelsOfPolyLineNodes(polyLineNodes, magnification);

            List<Pixel> pixelsToPlot = new List<Pixel>();
            pixelsToPlot.AddRange(pixelsOfLines); // plot lines at first
            pixelsToPlot.AddRange(pixelsOfNodes); // plot nodes at last

            int[] axis = GetAxis(pixelsToPlot);
            int width = axis[2] - axis[0] + 20;
            int height = axis[3] - axis[1] + 10;

            List<List<char>> matrixOfPixels = InitFigure(width, height);


            foreach (var pixel in MapPixelToFigure(pixelsToPlot).Values)
            {
                // Console.WriteLine("{0}, {1}, {2}", pixel.X, pixel.Y, pixel.Symbol);
                if (pixel.X < width && pixel.Y < height)
                {
                    matrixOfPixels[pixel.Y][pixel.X] = pixel.Symbol;
                }
            }

            return matrixOfPixels;
        }

        public static List<List<char>> PlotPolyLineWithAnnotation(List<Point> polyLineNodes, double magnification = 1.0)
        {
            List<List<char>> figure = PlotPolyLine(polyLineNodes, magnification);

            Dictionary<Point, Pixel> pixelOfNodes = RasterizeTool.MapNodeToPixel(polyLineNodes, magnification);

            Dictionary<Point, Pixel> pixelOfNodesInFigure = MapNodeToFigure(pixelOfNodes);

            AddCoordinateAnnotationForPolyLineNodes(figure, pixelOfNodesInFigure);

            return figure;
        }
    }
}