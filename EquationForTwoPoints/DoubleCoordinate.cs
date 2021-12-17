using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class DoubleCoordinate : ICoordinate<DoubleCoordinate>
    {
        private double Value { get; }

        public DoubleCoordinate Coordinate => this;

        public bool IsZero => Value == 0;

        public bool IsNegative => Value < 0;

        public bool IsAbsOne => Value == 1 || Value == -1;

        public ICoordinate<DoubleCoordinate> GetAbs() => Value < 0 ? new DoubleCoordinate(Value * -1) : this;

        public ICoordinate<DoubleCoordinate> Negate() => new DoubleCoordinate(Value * -1);

        public DoubleCoordinate(double v) => Value = v;

        public ICoordinate<DoubleCoordinate> Add(ICoordinate<DoubleCoordinate> other)
        {
            return new DoubleCoordinate(Value + other.Coordinate.Value);
        }

        public ICoordinate<DoubleCoordinate> Div(ICoordinate<DoubleCoordinate> other)
        {
            return new DoubleCoordinate(Value / other.Coordinate.Value);
        }

        public ICoordinate<DoubleCoordinate> Mul(ICoordinate<DoubleCoordinate> other)
        {
            return new DoubleCoordinate(Value * other.Coordinate.Value);
        }

        public ICoordinate<DoubleCoordinate> Sub(ICoordinate<DoubleCoordinate> other)
        {
            return new DoubleCoordinate(Value - other.Coordinate.Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is DoubleCoordinate coordinate &&
                   Value == coordinate.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
    
}
