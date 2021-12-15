using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class LineEquation
    {
        private readonly Point P1;
        private readonly Point P2;

        public double? Slope { get; }
        public double? YIntercept { get; }

        public LineEquation(Point p1, Point p2)
        {
            if (p1.Equals(p2))
            {
                throw new ArgumentException("Unable to determine equation for equal points");
            }

            P1 = p1;
            P2 = p2;
            if (p1.X - p2.X != 0) {
                Slope = (p1.Y - p2.Y) / (p1.X - p2.X);
                YIntercept = p1.Y - (Slope * p1.X);
            }
        }
        public override string ToString()
        {
            string result = "";
            if (Slope == null) // vertical line
            {
                result = $"x = {P1.X:0.##}";
            } else if (Slope == 0) // horizonal line
            {
                result = $"y = {YIntercept:0.##}";
            } else
            {
                result = "y = ";
                if (Slope == 1 || Slope == -1) { // omit slope
                    result += Slope == 1 ? "x" : "-x";
                } else
                {
                    result += Slope == 1 ? "x" : $"{Slope:0.##}x";
                }
                if (YIntercept != 0) // omit zero y-intercept
                {
                    result += YIntercept < 0 ? $" - {Math.Abs(YIntercept.Value):0.##}" : $" + {YIntercept:0.##}";
                }
            }

            return result;
        }
    }
}
