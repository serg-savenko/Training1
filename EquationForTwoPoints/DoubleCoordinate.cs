using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EquationForTwoPoints
{
    public class DoubleCoordinate : ICoordinate<double>
    {
        public double Value { get; }

        public bool IsZero => Value == 0;

        public bool IsNegative => Value < 0;

        public bool IsAbsOne => Value == 1 || Value == -1;

        public ICoordinate<double> GetAbs() => Value < 0 ? new DoubleCoordinate(Value * -1) : this;

        public DoubleCoordinate(double v) => Value = v;

        public ICoordinate<double> Add(ICoordinate<double> other)
        {
            return new DoubleCoordinate(Value + other.Value);
        }

        public ICoordinate<double> Div(ICoordinate<double> other)
        {
            return new DoubleCoordinate(Value / other.Value);
        }

        public ICoordinate<double> Mul(ICoordinate<double> other)
        {
            return new DoubleCoordinate(Value * other.Value);
        }

        public ICoordinate<double> Sub(ICoordinate<double> other)
        {
            return new DoubleCoordinate(Value - other.Value);
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
