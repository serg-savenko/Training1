using EquationForTwoPoints;
using System;
using Xunit;

namespace LineEquationForTwoPointsTests
{
    public class EquationOfLineTest
    {

        // Number decimal separator
        private static string NDS = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;


        [Fact]
        public void EquationForEqualPointsThrowsArgumentException()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(1));
            Assert.Throws<ArgumentException>(() => new LineEquation<DoubleCoordinate>(p1, p2));
        }

        [Fact]
        public void VerticalLine()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(10));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(3));
            Assert.Equal("x = 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void HorizontalLine()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(22), new DoubleCoordinate(1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(3), new DoubleCoordinate(1));
            Assert.Equal("y = 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqX()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(0));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(1));
            Assert.Equal($"y = x", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusX()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(0));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(-1), new DoubleCoordinate(1));
            Assert.Equal($"y = -x", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqTwoX()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(0));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(2));
            Assert.Equal($"y = 2x", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusTwoX()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(0));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(2), new DoubleCoordinate(-4));
            Assert.Equal($"y = -2x", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqXPlusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(2));
            Assert.Equal($"y = x + 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqXMinusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(-1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(0));
            Assert.Equal($"y = x - 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusXPlusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(0));
            Assert.Equal($"y = -x + 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusXMinusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(-1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(-2));
            Assert.Equal($"y = -x - 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqTwoXPlusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(-1));
            Assert.Equal($"y = -2x + 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusTwoXMinusOne()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(-1));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(-3));
            Assert.Equal($"y = -2x - 1", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void LineWithNegativeSlope()
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(10), new DoubleCoordinate(10));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(5), new DoubleCoordinate(20));
            Assert.Equal($"y = -2x + 30", new LineEquation<DoubleCoordinate>(p1, p2).ToString());
        }

        [Fact]
        public void EquationNotContainsUnnecessaryRationalSeparators()
        {
            var x = new Point<DoubleCoordinate>(new DoubleCoordinate(-1), new DoubleCoordinate(3));
            var y = new Point<DoubleCoordinate>(new DoubleCoordinate(3), new DoubleCoordinate(11));
            Assert.Equal("y = 2x + 5", new LineEquation<DoubleCoordinate>(x, y).ToString());
        }

        [Fact]
        public void EquationContainsRationalSeparatorsIfNeeded()
        {
            var x = new Point<DoubleCoordinate>(new DoubleCoordinate(6), new DoubleCoordinate(4));
            var y = new Point<DoubleCoordinate>(new DoubleCoordinate(2), new DoubleCoordinate(3));
            Assert.Equal($"y = 0{NDS}25x + 2{NDS}5", new LineEquation<DoubleCoordinate>(x, y).ToString());
        }
    }
}
