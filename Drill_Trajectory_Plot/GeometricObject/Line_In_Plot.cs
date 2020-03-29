using System;
using System.Collections.Generic;

namespace GeometricObject
{
    public class LineInPlot
    {
        public List<Pixel> pixelsOfLine { get; set; }

        public LineInPlot()
        {
            pixelsOfLine = new List<Pixel>();
        }

        public LineInPlot(List<Pixel> pixels)
        {
            pixelsOfLine = pixels;
        }

        public bool AreEqual(LineInPlot anotherLine)
        {
            if (pixelsOfLine.Count != anotherLine.pixelsOfLine.Count)
            {
                return false;
            }

            int i = 0;
            while(i < pixelsOfLine.Count)
            {
                Pixel pixel = pixelsOfLine[i];
                Pixel pixelToCompare = anotherLine.pixelsOfLine[i];
                if(pixel.X != pixelToCompare.X || pixel.Y != pixelToCompare.Y || pixel.Symbol != pixelToCompare.Symbol)
                {
                    break;
                }
                i++;
            }

            if(i == pixelsOfLine.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}