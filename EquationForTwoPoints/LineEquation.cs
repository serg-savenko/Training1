using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class LineEquation<T>
    {
        private readonly Point<T> P1;
        private readonly Point<T> P2;

        public ICoordinate<T> Slope { get; }
        public ICoordinate<T> YIntercept { get; }

        public LineEquation(Point<T> p1, Point<T> p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Unable to determine equation for equal points");
            }

            P1 = p1;
            P2 = p2;
            if (!p1.X.Sub(p2.X).IsZero) {
                Slope = p1.Y.Sub(p2.Y).Div(p1.X.Sub(p2.X));
                YIntercept = p1.Y.Sub(Slope.Mul(p1.X));
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Slope is null) // vertical line
            {
                result = $"x = {P1.X}";
            } else if (Slope.IsZero) // horizonal line
            {
                result = $"y = {YIntercept}";
            } else
            {
                result = "y = ";
                if (Slope.IsAbsOne) { // omit slope
                    result += Slope.IsNegative ? "-x" : "x";
                } else
                {
                    result += Slope.IsAbsOne ? "x" : $"{Slope}x";
                }
                if (!YIntercept.IsZero) // omit zero y-intercept
                {
                    result += YIntercept.IsNegative ? $" - {YIntercept.GetAbs()}" : $" + {YIntercept}";
                }
            }

            return result;
        }
    }
}
