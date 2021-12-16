using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class LineEquation<T>
    {
        private readonly Point<T> P1;
        private readonly Point<T> P2;

        public dynamic Slope { get; }
        public dynamic YIntercept { get; }

        public LineEquation(Point<T> p1, Point<T> p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Unable to determine equation for equal points");
            }

            P1 = p1;
            P2 = p2;
            if (((dynamic)p1.X - p2.X) != 0) {
                Slope = ((dynamic)p1.Y - p2.Y) / ((dynamic)p1.X - p2.X);
                YIntercept = p1.Y - (Slope * p1.X);
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Slope is null) // vertical line
            {
                result = $"x = {P1.X}";
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
                    result += Slope == 1 ? "x" : $"{Slope}x";
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
