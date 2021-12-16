using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class Point<T> : IEquatable<Point<T>>
    {
        public ICoordinate<T> X { get; }
        public ICoordinate<T> Y { get; }
        public Point(ICoordinate<T> x, ICoordinate<T> y)
        {
            (X, Y) = (x, y);
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }

        public override bool Equals(object obj) => this.Equals(obj as Point<T>);

        public bool Equals(Point<T> other)
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
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();
    }
}
