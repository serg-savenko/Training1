using System;
using static System.Console;

namespace EquationForTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point<DoubleCoordinate>(new DoubleCoordinate(0), new DoubleCoordinate(0));
            var p2 = new Point<DoubleCoordinate>(new DoubleCoordinate(1), new DoubleCoordinate(2));
            WriteLine(new LineEquation<DoubleCoordinate>(p1, p2).ToString());

            var p3 = new Point<RationalCoordinate>(new RationalCoordinate(new Rational(0, 1)),
                new RationalCoordinate(new Rational(3, 2)));
            var p4 = new Point<RationalCoordinate>(new RationalCoordinate(new Rational(5, 14)),
                new RationalCoordinate(new Rational(2, 13)));
            WriteLine(new LineEquation<RationalCoordinate>(p3, p4).ToString());
        }
    }
}
