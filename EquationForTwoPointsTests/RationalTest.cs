using EquationForTwoPoints;
using System;
using Xunit;

namespace LineEquationForTwoPointsTests
{
    public class RationalTest
    {
        [Fact]
        public void NormalizationCheck()
        {
            var r = new Rational(6, -10);
            Assert.Equal(new Rational(-3, 5), r);
        }

        [Fact]
        public void Addition()
        {
            var r = new Rational(1, 2);
            Assert.Equal(new Rational(1, 1), r + r);
        }

        [Fact]
        public void Substraction()
        {
            var r1 = new Rational(4, 2);
            var r2 = new Rational(2, 2);
            Assert.Equal(r2, r1 - r2);
        }

        [Fact]
        public void Multiplication()
        {
            var r1 = new Rational(1, 2);
            var r2 = new Rational(2, 1);
            Assert.Equal(new Rational(1, 1), r1 * r2);
        }

        [Fact]
        public void Division()
        {
            var r1 = new Rational(4, 1);
            var r2 = new Rational(2, 1);
            Assert.Equal(new Rational(2, 1), r1 / r2);
        }


        [Fact]
        public void ToStringWithoutDenominatorIfInt()
        {
            var r1 = new Rational(4, 1);
            Assert.Equal("4", r1.ToString());
        }

        [Fact]
        public void ToStringWithDenominatorIfNotInt()
        {
            var r1 = new Rational(1, 2);
            Assert.Equal("1/2", r1.ToString());
        }

        [Fact]
        public void ThrowsExceptionForZeroInDenominator()
        {
            Assert.Throws<ArgumentException>(() => new Rational(2, 0));
        }

    }
}
