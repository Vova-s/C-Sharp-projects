using System;
using static System.Console;
using static System.Math;

namespace QuadraticEquationSolverExtended
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d, x, x1, x2, x3, x4, x5;

            Write("Input a: ");
            a = double.Parse(ReadLine());

            Write("Input b: ");
            b = double.Parse(ReadLine());

            Write("Input c: ");
            c = double.Parse(ReadLine());

            d = Pow(b, 2) - 4 * a * c;

            if (a == 0)
            {
                x = -c / b;

                if (x >= 0)
                {
                    x1 = Sqrt(x);
                    x2 = -Sqrt(x);

                    WriteLine("x: " + x1);
                    WriteLine("x: " + x2);
                }
                else
                {
                    Write("X^2 must be > 0");
                }
            }
            else
            {
                if (d > 0)
                {
                    x = (-b + Sqrt(d)) / (2 * a);
                    x1 = (-b - Sqrt(d)) / (2 * a);

                    if (x >= 0)
                    {
                        x2 = Sqrt(x);
                        x3 = -Sqrt(x);

                        WriteLine("X : " + x3);
                        WriteLine("X : " + x2);

                        if (x1 >= 0)
                        {
                            x4 = Sqrt(x1);
                            x5 = -Sqrt(x1);

                            WriteLine("X : " + x4);
                            WriteLine("X : " + x5);
                        }
                    }
                    else
                    {
                        Write("X^2 must be > 0");
                    }
                }
                else if (d == 0)
                {
                    x = -b / (2 * a);

                    if (x < 0)
                    {
                        Write("No real roots");
                    }
                    else
                    {
                        x3 = Sqrt(x);
                        x2 = -Sqrt(x);

                        WriteLine("x: " + x3);
                        WriteLine("x: " + x2);
                    }
                }
                else
                {
                    Write("No real roots");
                }
            }
        }
    }
}