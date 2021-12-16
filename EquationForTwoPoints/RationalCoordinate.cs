using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class RationalCoordinate : ICoordinate<Rational>
    {
        public Rational Value { get; }

        public bool IsZero => Value == 0;

        public bool IsNegative => Value < 0;

        public bool IsAbsOne => Value == 1 || Value == -1;

        public ICoordinate<Rational> GetAbs() => Value < 0 ? new RationalCoordinate(Value * -1) : this;

        public RationalCoordinate(Rational v) => Value = v;

        public ICoordinate<Rational> Add(ICoordinate<Rational> other)
        {
            return new RationalCoordinate(Value + other.Value);
        }

        public ICoordinate<Rational> Div(ICoordinate<Rational> other)
        {
            return new RationalCoordinate(Value / other.Value);
        }

        public ICoordinate<Rational> Mul(ICoordinate<Rational> other)
        {
            return new RationalCoordinate(Value * other.Value);
        }

        public ICoordinate<Rational> Sub(ICoordinate<Rational> other)
        {
            return new RationalCoordinate(Value - other.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is RationalCoordinate coordinate &&
                   EqualityComparer<Rational>.Default.Equals(Value, coordinate.Value);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}
