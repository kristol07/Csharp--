using System;
using System.Collections.Generic;
using Xunit;
using GeometricObject;
using PlotTool;
using FluentAssertions;

namespace DrillTrajectoryPlot.Tests
{
    public class FigureToolTests
    {
        private readonly List<List<char>> _matrixOfPixels;
        private readonly List<Pixel> _pixelsToPlot;
        private readonly List<Point> _pointsOfPolyLine;

        public FigureToolTests()
        {
            _matrixOfPixels = new List<List<char>>();
            _pixelsToPlot = new List<Pixel>();
            _pointsOfPolyLine = new List<Point>();
        }

        [Fact]
        public void GetHeightOfFigure_ValidMatrixOfPixels_ReturnCorrectHeight()
        {
            _matrixOfPixels.Add(new List<char>());
            int expected = 1;

            int result = FigureTool.GetHeightOfFigure(_matrixOfPixels);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetHeightOfFigure_EmptyMatrix_ReturnZeroHeight()
        {
            int expected = 0;

            int result = FigureTool.GetHeightOfFigure(_matrixOfPixels);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetWidthOfFigure_ValidMatrixOfPixels_ReturnCorrectWidth()
        {
            _matrixOfPixels.Add(new List<char>());
            _matrixOfPixels[0].Add('_');
            int expected = 1;

            int result = FigureTool.GetWidthOfFigure(_matrixOfPixels);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetWidthOfFigure_EmptyMatrix_ReturnZeroWidth()
        {
            int expected = 0;

            int result = FigureTool.GetWidthOfFigure(_matrixOfPixels);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetAxis_ValidPixels_ReturnCorrectAxis()
        {
            _pixelsToPlot.Add(new Pixel(0, 1));
            _pixelsToPlot.Add(new Pixel(1, 5));
            _pixelsToPlot.Add(new Pixel(10, 3));
            _pixelsToPlot.Add(new Pixel(-1, -9));

            int[] result = FigureTool.GetAxis(_pixelsToPlot);
            int[] expected = { -1, -9, 10, 5 };

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 3)]
        [InlineData(10, 10)]
        public void InitFigure_WithCorrectHeightAndWidth(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                _matrixOfPixels.Add(new List<char>());
                for (int j = 0; j < width; j++)
                {
                    _matrixOfPixels[i].Add(' ');
                }
            }

            List<List<char>> result = FigureTool.InitFigure(width, height);

            result.Should().BeEquivalentTo(_matrixOfPixels);
        }



    }
}