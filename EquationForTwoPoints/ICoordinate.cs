using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{

    public interface ICoordinate<T> where T : ICoordinate<T>
    {
        T Coordinate { get; }
        ICoordinate<T> Add(ICoordinate<T> other);
        ICoordinate<T> Sub(ICoordinate<T> other);
        ICoordinate<T> Mul(ICoordinate<T> other);
        ICoordinate<T> Div(ICoordinate<T> other);
        ICoordinate<T> Negate();
        bool IsZero { get; }
        bool IsNegative { get; }
        bool IsAbsOne { get; }
    }
}
