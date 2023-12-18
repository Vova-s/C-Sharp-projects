using System;
using static System.Console;
using static System.Math;

namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            double h, a, b, c, m, d, x, x1;

            Write("Input h: ");
            h = Convert.ToDouble(ReadLine());

            a = (Sqrt((Abs(Sin(8 * h))) + 17) / Pow(1 - Sin(4 * h) * Cos(Pow(h, 2) + 18), 2));
            b = 1 - Sqrt(3 / 3 + Abs(Tan(a * Pow(h, 2) - Sin(a * h))));
            c = a * Pow(h, 2) * Sin(b * h) + b * Pow(h, 3) * Cos(a * h);
            d = Pow(b, 2) - 4 * a * c;

            if (d > 0)
            {
                x = (-b + Sqrt(Pow(b, 2) - 4 * a * c)) / (2 * a);
                x1 = (-b - Sqrt(Pow(b, 2) - 4 * a * c)) / (2 * a);
                WriteLine($"X: {x}");
                WriteLine($"X1: {x1}");
            }
            else if (d == 0)
            {
                x = -b / (2 * a);
                WriteLine($"x: {x}");
            }
            else
            {
                WriteLine("No real roots exist");
            }
        }
    }
}