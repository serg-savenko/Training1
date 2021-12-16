using System;
using static System.Console;

namespace EquationForTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point<double>(1.2, 2);
            var p2 = new Point<double>(1, 0.4);
            WriteLine(new LineEquation<double>(p1, p2).ToString());

            var p3 = new Point<Rational>(1, 2);
            var p4 = new Point<Rational>(new Rational(1, 2), new Rational(1, 19));
            WriteLine(new LineEquation<Rational>(p3, p4).ToString());

        }
    }
}
