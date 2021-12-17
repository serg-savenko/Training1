using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class LineEquation<T> where T : ICoordinate<T>
    {
        public ICoordinate<T> Slope { get; }
        private ICoordinate<T> XIntercept { get; }
        public ICoordinate<T> YIntercept { get; }

        public LineEquation(Point<T> p1, Point<T> p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Unable to determine equation for equal points");
            }

            if (!p1.X.Sub(p2.X).IsZero) {
                Slope = p1.Y.Sub(p2.Y).Div(p1.X.Sub(p2.X));
                YIntercept = p1.Y.Sub(Slope.Mul(p1.X));
            }
            if (!p1.Y.Sub(p2.Y).IsZero)
            {
                XIntercept = Slope is null ? p1.X : YIntercept.Negate().Div(Slope);
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Slope is null) // vertical line - fall back to standard form
            {
                result = $"x = {XIntercept}";
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
                    result += $"{Slope}x";
                }
                if (!YIntercept.IsZero) // omit zero y-intercept
                {
                    result += YIntercept.IsNegative ? $" - {YIntercept.Negate()}" : $" + {YIntercept}";
                }
            }

            return result;
        }
    }
}
