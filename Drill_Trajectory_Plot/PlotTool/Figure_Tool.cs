using System;
using System.Linq;
using System.Collections.Generic;
using GeometricObject;

namespace PlotTool
{
    public static class FigureTool
    {

        public static int GetWidthOfFigure(List<List<char>> matrixOfPixels)
        {
            if (GetHeightOfFigure(matrixOfPixels) > 0)
            {
                return matrixOfPixels[0].Count;
            }
            else
            {
                return 0;
            }
        }


        public static int GetHeightOfFigure(List<List<char>> matrixOfPixels)
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


        public static void AddAxisNotationFoFigure(List<List<char>> matrixOfPixels, string viewName)
        {
            if (GetWidthOfFigure(matrixOfPixels) > 3 && GetHeightOfFigure(matrixOfPixels) > 3)
            {
                matrixOfPixels[0][0] = '+';
                matrixOfPixels[0][1] = '-';
                matrixOfPixels[0][2] = '\u02C3';
                matrixOfPixels[1][0] = '|';
                matrixOfPixels[2][0] = '\u02C5';

                switch (viewName)
                {
                    case "Main":
                        matrixOfPixels[0][3] = 'x';
                        matrixOfPixels[3][0] = 'z';
                        break;
                    case "Left":
                        matrixOfPixels[0][3] = 'y';
                        matrixOfPixels[3][0] = 'z';
                        break;
                    case "Top":
                        matrixOfPixels[0][3] = 'x';
                        matrixOfPixels[3][0] = 'y';
                        break;
                }

                matrixOfPixels[0][4] = '(';
                matrixOfPixels[0][5] = 'f';
                matrixOfPixels[0][6] = 'e';
                matrixOfPixels[0][7] = 'e';
                matrixOfPixels[0][8] = 't';
                matrixOfPixels[0][9] = ')';
            }
        }


        public static void AddGridFoFigure(List<List<char>> matrixOfPixels, int xGridDistance, int yGridDistance)
        {
            if (GetWidthOfFigure(matrixOfPixels) > 0 && GetHeightOfFigure(matrixOfPixels) > 0)
            {
                for (int i = 0; i < matrixOfPixels[0].Count; i = i + xGridDistance)
                {
                    for (int j = 0; j < matrixOfPixels.Count; j++)
                    {
                        matrixOfPixels[j][i] = '.';
                    }
                }
                for (int j = 0; j < matrixOfPixels.Count; j = j + yGridDistance)
                {
                    for (int i = 0; i < matrixOfPixels[0].Count; i++)
                    {
                        matrixOfPixels[j][i] = '.';
                    }
                }
            }
        }

        public static void AddCoordinateGridForPixel(List<List<char>> matrixOfPixels, Pixel pixel)
        {
            int width = GetWidthOfFigure(matrixOfPixels);
            int height = GetHeightOfFigure(matrixOfPixels);

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
            int width = GetWidthOfFigure(matrixOfPixels);
            int height = GetHeightOfFigure(matrixOfPixels);

            if (width > 0 && height > 0 && pixel.X < width && pixel.Y < height)
            {
                char[] charArrayOfAnnotation = annotation.ToCharArray();

                List<int[]> startingPositions = GetStartingPositions();

                int k = 0;
                while (k < 9 && CheckStartingPosition(matrixOfPixels, pixel, charArrayOfAnnotation, startingPositions[k]))
                {
                    k++;
                }
                int[] startingPosition = startingPositions[k];

                for (int i = 0; i < charArrayOfAnnotation.Length; i++)
                {
                    if (startingPosition[1] == -1)
                    {
                        matrixOfPixels[pixel.Y + startingPosition[0]][pixel.X + startingPosition[1] - (charArrayOfAnnotation.Length - 1) + i] = charArrayOfAnnotation[i];
                    }
                    else
                    {
                        matrixOfPixels[pixel.Y + startingPosition[0]][pixel.X + startingPosition[1] + i] = charArrayOfAnnotation[i];
                    }
                }
            }

        }

        // ------------
        // | 8 |   | 7 |
        // -------------
        // | 2 |   | 1 |
        // -------------
        // | 3 | X | 0 |
        // -------------
        // | 4 |   | 5 |
        // -------------
        // | 9 |   | 6 |
        // -------------

        public static List<int[]> GetStartingPositions()
        {
            List<int[]> startingPositions = new List<int[]>();

            startingPositions.Add(new int[] { 0, 1 });
            startingPositions.Add(new int[] { -1, 1 });
            startingPositions.Add(new int[] { -1, -1 });
            startingPositions.Add(new int[] { 0, -1 });
            startingPositions.Add(new int[] { 1, -1 });
            startingPositions.Add(new int[] { 1, 1 });
            startingPositions.Add(new int[] { 2, 1 });
            startingPositions.Add(new int[] { -2, 1 });
            startingPositions.Add(new int[] { -2, -1 });
            startingPositions.Add(new int[] { 2, -1 });

            return startingPositions;
        }

        public static bool CheckStartingPosition(List<List<char>> matrixOfPixels, Pixel pixel, char[] charArrayOfAnnotation, int[] startingPosition)
        {
            for (int i = 0; i < charArrayOfAnnotation.Length; i++)
            {
                if (startingPosition[1] == -1)
                {
                    if (matrixOfPixels[pixel.Y + startingPosition[0]][pixel.X + startingPosition[1] - (charArrayOfAnnotation.Length - 1) + i] != ' ')
                    {
                        return true;
                    }
                }
                else
                {
                    if (matrixOfPixels[pixel.Y + startingPosition[0]][pixel.X + startingPosition[1] + i] != ' ')
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // public static int[] GetAnnotationStartingPosition(List<List<char>> matrixOfPixels, Pixel pixel)
        // {
        //     int[] startingPosition = { 1, 1 }; // Y, X

        //     // up
        //     if (matrixOfPixels[pixel.Y - 1][pixel.X - 1] == ' ' && matrixOfPixels[pixel.Y - 1][pixel.X] == ' ' && matrixOfPixels[pixel.Y - 1][pixel.X + 1] == ' ')
        //     {
        //         startingPosition[0] = -1;
        //         startingPosition[1] = 0;
        //         return startingPosition;
        //     }
        //     //down
        //     if (matrixOfPixels[pixel.Y + 1][pixel.X - 1] == ' ' && matrixOfPixels[pixel.Y + 1][pixel.X] == ' ' && matrixOfPixels[pixel.Y + 1][pixel.X + 1] == ' ')
        //     {
        //         startingPosition[0] = 1;
        //         startingPosition[1] = -1;
        //         return startingPosition;
        //     }
        //     //left
        //     if (matrixOfPixels[pixel.Y - 1][pixel.X - 1] == ' ' && matrixOfPixels[pixel.Y][pixel.X - 1] == ' ' && matrixOfPixels[pixel.Y + 1][pixel.X - 1] == ' ')
        //     {
        //         startingPosition[0] = 0;
        //         startingPosition[1] = -1;
        //         return startingPosition;
        //     }
        //     //right
        //     if (matrixOfPixels[pixel.Y - 1][pixel.X + 1] == ' ' && matrixOfPixels[pixel.Y][pixel.X + 1] == ' ' && matrixOfPixels[pixel.Y + 1][pixel.X + 1] == ' ')
        //     {
        //         startingPosition[0] = 0;
        //         startingPosition[1] = 1;
        //         return startingPosition;
        //     }

        //     // left-down
        //     if (matrixOfPixels[pixel.Y + 1][pixel.X - 1] == ' ')
        //     {
        //         startingPosition[0] = 1;
        //         startingPosition[1] = -1;
        //         return startingPosition;
        //     }
        //     // // right-up
        //     // if (matrixOfPixels[pixel.Y - 1][pixel.X + 1] == ' ')
        //     // {
        //     //     startingPosition[0] = -1;
        //     //     startingPosition[1] = 1;
        //     // }

        //     // if(matrixOfPixels[pixel.Y + 1][pixel.X + 1] == ' ')
        //     // {
        //     //     startingPosition[0] = 1;
        //     //     startingPosition[1] = 1;
        //     // }

        //     return startingPosition;
        // }


        public static void AddCoordinateAnnotationForPolyLineNodes(List<List<char>> matrixOfPixels, Dictionary<Point, Pixel> dictAnnotation)
        {
            foreach (var point in dictAnnotation.Keys)
            {
                AddAnnotationForPixel(matrixOfPixels, dictAnnotation[point], point.Annotation);
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
                pixelToFigure[pixel] = new Pixel(pixel.X - axis[0] + 20, pixel.Y - axis[1] + 10, pixel.Symbol);
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

        public static List<Pixel> GetPolyLinePixels(List<Point> polyLineNodes, double magnification = 1.0)
        {
            List<Pixel> pixelsOfLines = RasterizeTool.GetPixelsOfPolyLine(polyLineNodes, magnification);
            List<Pixel> pixelsOfNodes = RasterizeTool.GetPixelsOfPolyLineNodes(polyLineNodes, magnification);

            List<Pixel> pixelsToPlot = new List<Pixel>();
            pixelsToPlot.AddRange(pixelsOfLines); // plot lines at first
            pixelsToPlot.AddRange(pixelsOfNodes); // plot nodes at last

            Pixel polyLineHead = new Pixel(pixelsOfNodes[0].X, pixelsOfNodes[0].Y, '=');
            Pixel polyLineTail = new Pixel(pixelsOfNodes[pixelsOfNodes.Count - 1].X, pixelsOfNodes[pixelsOfNodes.Count - 1].Y, '#');
            pixelsToPlot.Add(polyLineHead);
            pixelsToPlot.Add(polyLineTail);

            return pixelsToPlot;
        }


        public static List<List<char>> PlotPolyLine(List<Point> polyLineNodes, double magnification = 1.0)
        {

            List<Pixel> pixelsToPlot = GetPolyLinePixels(polyLineNodes, magnification);

            int[] axis = GetAxis(pixelsToPlot);
            int width = axis[2] - axis[0] + 40;
            int height = axis[3] - axis[1] + 20;

            List<List<char>> matrixOfPixels = InitFigure(width, height);

            // // label original point
            // AddCoordinateGridForPixel(matrixOfPixels, new Pixel(-axis[0]+5, -axis[1]+5, '*'));

            // // add grid
            // AddGridFoFigure(matrixOfPixels, 10, 10);

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