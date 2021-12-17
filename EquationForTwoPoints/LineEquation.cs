using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class LineEquation
    {
        public Rational Slope { get; }
        private Rational XIntercept { get; }
        public Rational YIntercept { get; }

        public LineEquation(Point p1, Point p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Unable to determine equation for equal points");
            }

            if (p1.X - p2.X != 0) {
                Slope = (p1.Y - p2.Y) / (p1.X - p2.X);
                YIntercept = p1.Y - (Slope * p1.X);
            }
            if (p1.Y - p2.Y != 0)
            {
                XIntercept = Slope is null ? p1.X : (-1*YIntercept)/Slope;
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Slope is null) // vertical line - fall back to standard form
            {
                result = $"x = {XIntercept}";
            } else if (Slope == 0) // horizonal line
            {
                result = $"y = {YIntercept}";
            } else
            {
                result = "y = ";
                if (Slope == 1 || Slope == -1) { // omit slope
                    result += Slope == 1 ? "x" : "-x";
                } else
                {
                    result += $"{Slope}x";
                }
                if (YIntercept != 0) // omit zero y-intercept
                {
                    result += YIntercept < 0 ? $" - {-1*YIntercept}" : $" + {YIntercept}";
                }
            }

            return result;
        }
    }
}
