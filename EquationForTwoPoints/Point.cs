using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class Point : IEquatable<Point>
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y)
        {
            (X, Y) = (x, y);
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }

        public override bool Equals(object obj) => this.Equals(obj as Point);

        public bool Equals(Point other)
        {
            if (other is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (X == other.X) && (Y == other.Y);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
