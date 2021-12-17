using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class RationalCoordinate : ICoordinate<RationalCoordinate>
    {
        private Rational Value { get; }

        public RationalCoordinate Coordinate => this;

        public bool IsZero => Value == 0;

        public bool IsNegative => Value < 0;

        public bool IsAbsOne => Value == 1 || Value == -1;

        public ICoordinate<RationalCoordinate> Negate() => new RationalCoordinate(Value * -1);

        public RationalCoordinate(Rational v) => Value = v;

        public ICoordinate<RationalCoordinate> Add(ICoordinate<RationalCoordinate> other)
        {
            return new RationalCoordinate(Value + other.Coordinate.Value);
        }

        public ICoordinate<RationalCoordinate> Div(ICoordinate<RationalCoordinate> other)
        {
            return new RationalCoordinate(Value / other.Coordinate.Value);
        }

        public ICoordinate<RationalCoordinate> Mul(ICoordinate<RationalCoordinate> other)
        {
            return new RationalCoordinate(Value * other.Coordinate.Value);
        }

        public ICoordinate<RationalCoordinate> Sub(ICoordinate<RationalCoordinate> other)
        {
            return new RationalCoordinate(Value - other.Coordinate.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is RationalCoordinate coordinate &&
                   Value.Equals(coordinate.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
