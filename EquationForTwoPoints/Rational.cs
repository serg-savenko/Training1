using System;
using System.Collections.Generic;
using System.Text;

namespace EquationForTwoPoints
{
    public class Rational
    {
        public int Numerator { get; }
        public int Denominator { get; }

        #region public static
        public static bool TryParse(string s, out Rational r)
        {
            try
            {
                r = Parse(s);
                return true;
            }
            catch (Exception) { }
            r = null;
            return false;
        }
        public static Rational Parse(string s)
        {
            s = s.Trim();
            string[] parts = { s, "1" };
            if (s.Contains("/"))
            {
                parts = s.Split('/');
            }
            else if (s.Contains("."))
            {
                parts = s.Split('.');
                string zeros = new string('0', parts[1].Length);
                parts[0] += parts[1];
                parts[1] = "1" + zeros;
            }
            return new Rational(int.Parse(parts[0].Trim()),
                                int.Parse(parts[1].Trim()));
        }

        public static implicit operator Rational(int x)
        {
            return new Rational(x, 1);
        }
#endregion
        public Rational(int num, int denom)
        {
            if (denom == 0) { throw new ArgumentException("Denominator can't be zero"); }

            if (denom < 0) // make denom positive
            {
                num = -num;
                denom = -denom;
            }

            int n = gcd(num, denom);
            Numerator = num / n;
            Denominator = denom / n;
        }

        public override string ToString()
        {
            return Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rational rational &&
                   Numerator == rational.Numerator &&
                   Denominator == rational.Denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public Rational Multiply(Rational other)
        {
            return new Rational(Numerator * other.Numerator, Denominator * other.Denominator);
        }
        public static Rational operator *(Rational x, Rational y)
        {
            return x.Multiply(y);
        }

        public Rational Divide(Rational other)
        {
            return new Rational(Numerator * other.Denominator, Denominator * other.Numerator);
        }

        public static Rational operator /(Rational x, Rational y)
        {
            return x.Divide(y);
        }

        public Rational Add(Rational other)
        {
            return new Rational(Numerator * other.Denominator + Denominator * other.Numerator, Denominator * other.Denominator);
        }
        public static Rational operator +(Rational x, Rational y)
        {
            return x.Add(y);
        }

        public Rational Subtract(Rational other)
        {
            return new Rational(Numerator * other.Denominator - Denominator * other.Numerator, Denominator * other.Denominator);
        }
        public static Rational operator -(Rational x, Rational y)
        {
            return x.Subtract(y);
        }

        /**
         * Return a number that is positive, zero or negative, respectively, if
         *   the value of this Rational is bigger than f,
         *   the values of this Rational and f are equal or
         *   the value of this Rational is smaller than f.
         */
        public int CompareTo(Rational other)
        {
            return Numerator * other.Denominator - Denominator * other.Numerator; //numerator of this - f
        }

        public static bool operator ==(Rational x, Rational y)
        {
            return x.CompareTo(y) == 0;
        }

        public static bool operator !=(Rational x, Rational y)
        {
            return !(x == y);
        }
        public static bool operator >(Rational x, Rational y)
        {
            return x.CompareTo(y) > 0;
        }
        public static bool operator <(Rational x, Rational y)
        {
            return x.CompareTo(y) < 0;
        }

        private static int gcd(int a, int b)
        {
            if (a == 0)
                return Math.Abs(b);
            // Euclid's algorithm
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return Math.Abs(a);
        }
    }
}