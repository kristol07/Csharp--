using System;
using System.Collections.Generic;
using Xunit;
using PlotTool;
using GeometricObject;
using FluentAssertions;

namespace DrillTrajectoryPlot.Tests
{
    public class RasterizeToolTests
    {
        private readonly List<Pixel> _pixelsToPlot;
        private readonly List<Point> _pointsOfPolyLineNodes;

        public RasterizeToolTests()
        {
            _pixelsToPlot = new List<Pixel>();
            _pointsOfPolyLineNodes = new List<Point>();
        }

        [Fact]
        public void GetPixelsOfLineLow_HorizonalLine_ReturnPixelsOfSymbolDash()
        {
            _pixelsToPlot.Add(new Pixel(1, 0, '-'));
            _pixelsToPlot.Add(new Pixel(2, 0, '-'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 3, y1 = 0;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);
            
            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfLineLow_NormalLineUp_ReturnPixelsWithCorrectSymbols()
        {
            _pixelsToPlot.Add(new Pixel(1, 1, '\\'));
            _pixelsToPlot.Add(new Pixel(2, 1, '-'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 3, y1 = 2;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfLineLow_NormalLineDown_ReturnPixelsWithCorrectSymbols()
        {
            _pixelsToPlot.Add(new Pixel(1, 0, '-'));
            _pixelsToPlot.Add(new Pixel(2, -1, '/'));
            _pixelsToPlot.Add(new Pixel(3, -1, '-'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 4, y1 = -2;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfLineHigh_VerticalLine_ReturnPixelsOfSymbolVertical()
        {
            _pixelsToPlot.Add(new Pixel(0, 1, '|'));
            _pixelsToPlot.Add(new Pixel(0, 2, '|'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 0, y1 = 3;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfLineHigh_NormalLineUp_ReturnPixelsWithCorrectSymbols()
        {
            _pixelsToPlot.Add(new Pixel(1, 1, '\\'));
            _pixelsToPlot.Add(new Pixel(1, 2, '|'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 2, y1 = 3;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfLineHigh_NormalLineDown_ReturnPixelsWithCorrectSymbols()
        {
            _pixelsToPlot.Add(new Pixel(2, -3, '|'));
            _pixelsToPlot.Add(new Pixel(1, -2, '/'));
            _pixelsToPlot.Add(new Pixel(1, -1, '|'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            int x0 = 0, y0 = 0, x1 = 2, y1 = -4;
            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1));
            List<Pixel> result = RasterizeTool.GetPixelsOfLine(x0, y0, x1, y1);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfPolyLine_ValidInputs_ReturnPixelsOfLine()
        {
            double magnification = 1.0;
            _pointsOfPolyLineNodes.Add(new Point(3.1, 0));
            _pointsOfPolyLineNodes.Add(new Point(0.1, -0.1));
            _pointsOfPolyLineNodes.Add(new Point(3.9, -1.9));

            _pixelsToPlot.Add(new Pixel(1, 0, '-'));
            _pixelsToPlot.Add(new Pixel(2, 0, '-'));
            _pixelsToPlot.Add(new Pixel(1, 0, '-'));
            _pixelsToPlot.Add(new Pixel(2, -1, '/'));
            _pixelsToPlot.Add(new Pixel(3, -1, '-'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfPolyLine(_pointsOfPolyLineNodes, magnification));
            List<Pixel> result = RasterizeTool.GetPixelsOfPolyLine(_pointsOfPolyLineNodes, magnification);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }

        [Fact]
        public void GetPixelsOfPolyLineNodes_ValidInputs_ReturnPixelsOfLineNodes()
        {
            double magnification = 1.0;
            _pointsOfPolyLineNodes.Add(new Point(0, 0.1));
            _pixelsToPlot.Add(new Pixel(0, 0, '+'));
            _pointsOfPolyLineNodes.Add(new Point(2.1, 2.9));
            _pixelsToPlot.Add(new Pixel(2, 3, '+'));
            _pointsOfPolyLineNodes.Add(new Point(0.8, 1.2));
            _pixelsToPlot.Add(new Pixel(1, 1, '+'));
            // LineInPlot expected = new LineInPlot(_pixelsToPlot);

            // LineInPlot result = new LineInPlot(RasterizeTool.GetPixelsOfPolyLineNodes(_pointsOfPolyLineNodes, magnification));
            List<Pixel> result = RasterizeTool.GetPixelsOfPolyLineNodes(_pointsOfPolyLineNodes, magnification);

            // Assert.True(result.AreEqual(expected));
            result.Should().BeEquivalentTo(_pixelsToPlot);
        }
    }
}
