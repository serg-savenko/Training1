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
            var p1 = new Point<double>(1, 1);
            var p2 = new Point<double>(1, 1);
            Assert.Throws<ArgumentException>(() => new LineEquation<double>(p1, p2));
        }

        [Fact]
        public void VerticalLine()
        {
            var p1 = new Point<double>(1, 10);
            var p2 = new Point<double>(1, 3);
            Assert.Equal("x = 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void HorizontalLine()
        {
            var p1 = new Point<double>(22, 1);
            var p2 = new Point<double>(3, 1);
            Assert.Equal("y = 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqX()
        {
            var p1 = new Point<double>(0, 0);
            var p2 = new Point<double>(1, 1);
            Assert.Equal($"y = x", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusX()
        {
            var p1 = new Point<double>(0, 0);
            var p2 = new Point<double>(-1, 1);
            Assert.Equal($"y = -x", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqTwoX()
        {
            var p1 = new Point<double>(0, 0);
            var p2 = new Point<double>(1, 2);
            Assert.Equal($"y = 2x", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusTwoX()
        {
            var p1 = new Point<double>(0, 0);
            var p2 = new Point<double>(2, -4);
            Assert.Equal($"y = -2x", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqXPlusOne()
        {
            var p1 = new Point<double>(0, 1);
            var p2 = new Point<double>(1, 2);
            Assert.Equal($"y = x + 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqXMinusOne()
        {
            var p1 = new Point<double>(0, -1);
            var p2 = new Point<double>(1, 0);
            Assert.Equal($"y = x - 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusXPlusOne()
        {
            var p1 = new Point<double>(0, 1);
            var p2 = new Point<double>(1, 0);
            Assert.Equal($"y = -x + 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusXMinusOne()
        {
            var p1 = new Point<double>(0, -1);
            var p2 = new Point<double>(1, -2);
            Assert.Equal($"y = -x - 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqTwoXPlusOne()
        {
            var p1 = new Point<double>(0, 1);
            var p2 = new Point<double>(1, -1);
            Assert.Equal($"y = -2x + 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void YEqMinusTwoXMinusOne()
        {
            var p1 = new Point<double>(0, -1);
            var p2 = new Point<double>(1, -3);
            Assert.Equal($"y = -2x - 1", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void LineWithNegativeSlope()
        {
            var p1 = new Point<double>(10, 10);
            var p2 = new Point<double>(5, 20);
            Assert.Equal($"y = -2x + 30", new LineEquation<double>(p1, p2).ToString());
        }

        [Fact]
        public void EquationNotContainsUnnecessaryRationalSeparators()
        {
            var x = new Point<double>(-1, 3);
            var y = new Point<double>(3, 11);
            Assert.Equal("y = 2x + 5", new LineEquation<double>(x, y).ToString());
        }

        [Fact]
        public void EquationContainsRationalSeparatorsIfNeeded()
        {
            var x = new Point<double>(6, 4);
            var y = new Point<double>(2, 3);
            Assert.Equal($"y = 0{NDS}25x + 2{NDS}5", new LineEquation<double>(x, y).ToString());
        }
    }
}
