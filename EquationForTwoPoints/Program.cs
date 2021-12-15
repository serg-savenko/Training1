using System;
using static System.Console;

namespace EquationForTwoPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new double[4];

            do
            {
                AskUserSomeNumbers(numbers);

                var p1 = new Point(numbers[0], numbers[1]);
                var p2 = new Point(numbers[2], numbers[3]);
                try
                {
                    var equation = new LineEquation(p1, p2);
                    WriteLine($"Equation: {equation}");
                }
                catch (Exception ex)
                {
                    WriteLine("Something went wrong: " + ex.ToString());
                }

                Write("Press y to try once more. ");
            } while (ReadKey().KeyChar == 'y');
        }

        static void AskUserSomeNumbers(double[] array)
        {
            WriteLine();
            for (int i = 0; i < array.Length;)
            {
                if (i % 2 == 0) Write($"Enter x coordinate of point #{(i / 2) + 1}: ");
                else Write($"Enter y coordinate of point #{(i / 2) + 1}: ");

                string input = ReadLine();
                if (double.TryParse(input, out array[i]))
                {
                    i++;
                }
                else
                {
                    WriteLine("Wrong number format. Please try again.");
                }
            }

        }
    }
}
