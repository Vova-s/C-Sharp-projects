using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;


namespace NumericalEquationSolverWithIterations___Steffensen_Method
{
    internal class Program
    {
        public static double eps = Pow(10, -10);

        static void Main(string[] args)
        {
            Write("input 1 to solve first task\ninput 2 to solve second task :"); int i = int.Parse(ReadLine());
            if (i == 1)
            {
                halfdividinig();
            }
            else
            {
                steffensen();
                simple_iteration();
            }
        }
        public static double first_equ(double x)
        {
            double f = Pow(x, 2) * Cos(x) + Log2(Pow(E, x)) + PI - 9 * PI * Pow(x, 3);
            return f;
        }
        public static double second_equ(double x)
        {
            double f = Pow(E, Cosh(x)) + Pow(x, 5) + Pow(x, 15) * Sin(x) - 13;
            return f;
        }
        public static double derivative_sec(double x)
        {
            double f = Sinh(x) * Pow(E, Cosh(x)) + 5 * Pow(x, 4) + 15 * Pow(x, 14) * Sin(x) + Pow(x, 15) * Cos(x);
            return f;
        }

        public static void halfdividinig()
        {
            List<double> lis_x = new List<double>();
            WriteLine("Half dividinig method");
            double fx_c, fx_l, fx_r;
            double left_bound, right_bound;
            double center = 0;
            Write("Input left bound : "); left_bound = double.Parse(ReadLine());
            Write("Input right bound : "); right_bound = double.Parse(ReadLine());
            while (Abs(left_bound - right_bound) >= eps)
            {
                center = (left_bound + right_bound) / 2;
                lis_x.Add(center);
                WriteLine(center);
                fx_c = first_equ(center);
                fx_l = first_equ(left_bound);
                fx_r = first_equ(right_bound);
                if (Sign(fx_c) == Sign(fx_l))
                {
                    left_bound = center;
                }
                else if (Sign(fx_c) == Sign(fx_r))
                {
                    right_bound = center;
                }

            }
            WriteLine($"X = {center}");
        }
        public static void simple_iteration()
        {
            List<double> lis_x = new List<double>();
            WriteLine("Simple iteration method");
            double f, f1, f_x = 0, g, g1, q, i = 0; ;
            double left_bound, right_bound, x1 = 0;
            double x = 0, lambda;
            double left, right = 0;
            left_bound = -4;
            right_bound = 4;
            left = left_bound;
            while (right <= right_bound)
            {
                right = left + 0.1;
                f = second_equ(left);
                f1 = second_equ(right);
                if (Sign(f) == Sign(f1))
                {
                    left = right;
                }
                else
                {
                    x = left;
                    x1 = x;
                    g = derivative_sec(left);
                    g1 = derivative_sec(right);
                    lambda = 2 / (g + g1);
                    q = (g1 - g) / (g + g1);
                    do
                    {
                        i++;
                        x = x1;
                        lis_x.Add(x);
                        x1 = x - lambda * second_equ(x);
                    }
                    while (Abs(x1 - x) > Abs((1 - q) / q * eps));

                    WriteLine($"X = {x},{i}");
                    left = right;
                }

            }
        }


        public static void steffensen()
        {
            List<double> lis_x = new List<double>();
            List<double> lisR_x = new List<double>();
            WriteLine("steffencen method");
            double f, f1, f_x = 1, g, g1, q, f0, g0;
            double left_bound, right_bound, x1 = 0;
            double x = 0, lambda, i = 0;
            double left, right = 0;
            bool flag = true;
            left_bound = -4;
            right_bound = 4;
            left = left_bound;
            while (right <= right_bound)
            {
                right = left + 0.1;
                f = second_equ(left);
                f1 = second_equ(right);
                if (Sign(f) == Sign(f1))
                {
                    left = right;
                }
                else
                {
                    i = 0;
                    x = (left + right) / 2;
                    lis_x.Clear();
                    while (Abs(second_equ(x)) > 0.1)
                    {

                        i++;
                        f0 = second_equ(x);
                        g0 = derivative_sec(x);
                        x1 = x - f0 / g0;
                        x = x1;
                        lis_x.Add(x);

                    }
                    i = 0;
                    lisR_x.Clear();
                    while (f_x > eps)
                    {

                        i++;
                        f_x = second_equ(x1);
                        g = Pow(f_x, 2);
                        g1 = second_equ(x1 + f_x);
                        x1 = x1 - (g) / (g1 - f_x);
                        lisR_x.Add(x1);
                    }

                    WriteLine($"X = {x1}");
                    left = right;
                }

            }

        }
    }
}