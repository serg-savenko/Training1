using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{

    public interface ICoordinate<T>
    {
        T Value { get; }
        ICoordinate<T> Add(ICoordinate<T> other);
        ICoordinate<T> Sub(ICoordinate<T> other);
        ICoordinate<T> Mul(ICoordinate<T> other);
        ICoordinate<T> Div(ICoordinate<T> other);
        ICoordinate<T> GetAbs();
        bool IsZero { get; }
        bool IsNegative { get; }
        bool IsAbsOne { get; }
    }
}
