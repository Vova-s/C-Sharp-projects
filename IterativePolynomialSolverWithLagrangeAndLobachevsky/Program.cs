using System;
using static System.Console;
using static System.Math;
using System.Linq;
using System.Collections.Generic;

namespace IterativePolynomialSolverWithLagrangeAndLobachevsky
{
    public class Lagrange_Loba_Lokalization
    {
        static void Main(string[] args)
        {

            WriteLine("*********************************************************************************************************");
            WriteLine("The general equation is a_7 * x + a_6 * x + a_5 * x + a_4 * x + a_3 * x + a_2 * x + a_1 * x + a_0 * x = 0");
            WriteLine("*********************************************************************************************************");
            WriteLine("If you want to solve  example put 1 \n or 2 if you want to solve your equation ");
            Write("Choose 1 or 2 : "); int w = int.Parse(Console.ReadLine()); WriteLine();
            if (w == 1)
            {
                List<double> example = new List<double>() { 14, -73, -184, 971, 159, -432, -37, 33 };
                Lobachevkyi.list = example;
                Lobachevkyi.temp_list = example;
                Lobachevkyi.Lobachevkyi_submission();
                Lagrange.Set_positive_upper();
                Lagrange.Set_positive_lower();
                Lagrange.Set_negative_lower();
                Lagrange.Set_negative_upper();
                Lobachevkyi.Lobachevskyi_quadrature();

            }
            else
            {
                WriteLine("Let's set the variables");
                Lobachevkyi.set_a();
                Lobachevkyi.Lobachevkyi_submission();
                Lagrange.Set_positive_upper();
                Lagrange.Set_positive_lower();
                Lagrange.Set_negative_lower();
                Lagrange.Set_negative_upper();
                Lobachevkyi.Lobachevskyi_quadrature();
            }
        }
    }
    public class Lagrange
    {
        public static double negative_lower, negative_upper;
        public static double positive_lower, positive_upper;
        public static double Set_positive_upper()
        {
            double k = 0;
            List<double> l1 = new List<double>();
            List<double> list_copy = new List<double>();
            clone(list_copy);
            if (list_copy[list_copy.Count - 1] < 0)
            {
                remake(list_copy);
            }
            double a_n = list_copy[list_copy.Count - 1];
            for (int i = list_copy.Count - 1; i > 0; i--)
            {
                if (list_copy[i] < 0)
                {
                    k = list_copy.Count - 1 - i;
                    break;
                }
            }
            foreach (double b in list_copy)
            {
                if (b < 0)
                {
                    l1.Add(b);
                }

            }
            double c = Abs(l1.Min());
            positive_upper = 1 + Pow(c / a_n, 1 / k);
            WriteLine($"Positive upper boundary  is : {positive_upper}");
            return positive_upper;
        }
        public static double Set_positive_lower()
        {
            double k = 0;
            List<double> list_copy = new List<double>();
            clone(list_copy);
            List<double> l1 = new List<double>();
            reshaflle(list_copy);
            if (list_copy[list_copy.Count - 1] < 0)
            {
                list_copy = remake(list_copy);
            }
            double a_n = list_copy[list_copy.Count - 1];
            for (int i = list_copy.Count - 1; i > 0; i--)
            {
                if (list_copy[i] < 0)
                {
                    k = list_copy.Count - 1 - i;
                    break;
                }
            }
            foreach (double b in list_copy)
            {
                if (b < 0)
                {
                    l1.Add(b);
                }

            }
            double c = Abs(l1.Min());
            double R = 1 + Pow(c / a_n, 1 / k);
            positive_lower = 1 / R;
            WriteLine($"Positive lower boundary  is : {positive_lower}");
            return positive_lower;
        }
        public static double Set_negative_upper()
        {
            double k = 0;
            List<double> l1 = new List<double>();
            List<double> list_copy = new List<double>();
            clone(list_copy);
            reshaflle(list_copy);
            remake_negatives(list_copy);
            if (list_copy[list_copy.Count - 1] < 0)
            {
                remake(list_copy);
            }
            double a_n = list_copy[list_copy.Count - 1];
            for (int i = list_copy.Count - 1; i > 0; i--)
            {
                if (list_copy[i] < 0)
                {
                    k = list_copy.Count - 1 - i;
                    break;
                }
            }
            foreach (double b in list_copy)
            {
                if (b < 0)
                {
                    l1.Add(b);
                }

            }
            double c = Abs(l1.Min());
            negative_upper = -1 / (1 + Pow(c / a_n, 1 / k));
            WriteLine($"Negative upper boundary  is : {negative_upper}");
            return negative_upper;
        }

        public static double Set_negative_lower()
        {
            double k = 0;
            double l;
            List<double> l1 = new List<double>();
            List<double> list_copy = new List<double>();
            clone(list_copy);
            remake_negatives(list_copy);
            if (list_copy[list_copy.Count - 1] < 0)
            {
                remake(list_copy);
            }
            double a_n = list_copy[list_copy.Count - 1];
            for (int i = list_copy.Count - 1; i > 0; i--)
            {
                if (list_copy[i] < 0)
                {
                    k = list_copy.Count - 1 - i;
                    break;
                }
            }
            foreach (double b in list_copy)
            {
                if (b < 0)
                {
                    l1.Add(b);
                }

            }
            double c = Abs(l1.Min());
            negative_lower = -(1 + Pow(c / a_n, 1 / k));
            WriteLine($"Negative lower boundary  is : {negative_lower}");
            return negative_lower;
        }

        public static List<double> remake(List<double> list)
        {
            double l;
            for (int i = 0; i < list.Count; i++)
            {
                l = list[i] * (-1);
                list[i] = l;
            }
            return list;
        }

        public static List<double> reshaflle(List<double> list)
        {
            double l;
            double r;
            for (int i = 0; i < list.Count / 2; i++)
            {
                l = list[i];
                r = list[list.Count - i - 1];
                list[i] = r;
                list[list.Count - i - 1] = l;
            }
            return list;
        }

        public static List<double> remake_negatives(List<double> list)
        {
            double l;
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 != 0)
                {
                    l = list[i] * (-1);
                    list[i] = l;
                }

            }
            return list;
        }

        public static List<double> clone(List<double> list)
        {
            double l;
            for (int i = 0; i < Lobachevkyi.list.Count; i++)
            {
                l = Lobachevkyi.list[i];
                list.Add(l);
            }
            return list;
        }
    }
    public class Lobachevkyi
    {
        public static char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
        public static List<double> list = new List<double>();
        public static List<double> temp_list = new List<double>();
        public static int d = 0;
        public static List<double> list_x = new List<double>();

        public static void set_a()
        {
            int a = 0;
            for (int i = 7; i >= 0; i--)
            {
                Write($"Set value to a{i}: "); a = int.Parse(ReadLine());
                if (a != 0)
                {
                    list.Add(a);
                    temp_list.Add(a);
                }
            }
            Lagrange.reshaflle(list);
            Lagrange.reshaflle(temp_list);



        }

        public static void Lobachevkyi_submission()
        {
            string sign = " ";
            string equ = $"The equation is x : ";
            List<string> list_signs = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    sign = "";
                    list_signs.Add(sign);
                    equ += $" {list_signs[i]}{list[i]}x";
                }
                else if (i == 0)
                {
                    if (list[i] > 0)
                    {
                        sign = " ";
                        list_signs.Add(sign);
                        equ += $" {list_signs[i]}{list[i]}x";
                    }
                }
                else if (list[i] >= 0)
                {
                    sign = "+";
                    list_signs.Add(sign);
                    equ += $" {list_signs[i]}{list[i]}x";
                }

            }
            WriteLine(equ);
            WriteLine("**********************************************************************************************************");
            WriteLine("Let's write the coefficients of the original equation as a_i");
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{alpha[0]}{list.Count - i - 1} = {list[i]};");
            }
        }

        public static void Lobachevskyi_quadrature()
        {
            d++;
            double sum = 0;
            double precision = Pow(10, -25);
            List<double> New_list = new List<double>();
            string lett = alpha[d].ToString();
            int n = list.Count();
            New_list.Clear();

            for (int k = 0; k < n; k++)
            {
                double x = 0;
                x = Pow(list[k], 2);
                for (int j = 1; k + j < n && k - j >= 0; j++)
                {
                    x += 2 * Pow(-1, j) * list[k - j] * list[k + j];
                }
                New_list.Add(x);

            }



            WriteLine($"Let's write the coefficients of the next equation as {lett}_i");
            for (int i = 0; i < New_list.Count; i++)
            {
                double max = New_list[i] - Pow(list[i], 2);
                sum += Pow(max, 2);
                WriteLine($"{lett}{New_list.Count - i - 1} = {New_list[i]}");
            }


            if (Sqrt(sum) > precision)
            {
                WriteLine($"Norm of the comparative vector:{Sqrt(sum)}> {precision} ");
                list = New_list;
                double norma = norm(New_list);
                for (int l = 0; l < New_list.Count; l++)
                {
                    New_list[l] = New_list[l] / norma;
                }

                Lobachevkyi.Lobachevskyi_quadrature();
            }
            else
            {
                list = New_list;
                WriteLine($"Norm of the comparative vector:{Sqrt(sum)}< {precision} ");
                create_x(New_list);
                check_bound(list_x);
                Newthon_lokalization.localization();

            }

        }

        public static List<double> create_x(List<double> New_list)
        {

            double p = Pow(2, (double)d);
            int k = New_list.Count - 1;
            for (int i = k; i > 0; i--)
            {
                double x = 0;
                x = Pow(New_list[k - i] / New_list[k - i + 1], 1.0 / p);
                list_x.Add(x);
                list_x.Add(-x);


            }

            WriteLine("All X its :");
            for (int l = 0; l < list_x.Count - 1; l += 2)
            {
                WriteLine($"X{k} = {list_x[l]}; {list_x[l + 1]}");
                k--;
            }

            for (int j = 0; j < list_x.Count; j++)
            {

                double g = Newthon_lokalization.value_substitution(list_x[j]);
                double g1 = Newthon_lokalization.value_substitution(list_x[j + 1]);
                if (Abs(g) > Abs(g1))
                {
                    list_x.RemoveAt(j);
                }
                else
                {
                    list_x.RemoveAt(j + 1);
                }

            }
            int m = New_list.Count - 1;
            WriteLine("All X its :");
            for (int l = 0; l < list_x.Count; l++)
            {
                WriteLine($"X{m} = {list_x[l]};");
                m--;
            }

            return list_x;
        }

        public static void check_bound(List<double> list_x)
        {
            for (int i = 0; i < list_x.Count; i++)
            {
                if (list_x[i] > 0)
                {
                    if (list_x[i] >= Lagrange.positive_lower && list_x[i] <= Lagrange.positive_upper)
                    {

                    }
                    else
                    {
                        list_x.RemoveAt(i);
                        i--;
                    }

                }
                else
                {
                    if (list_x[i] >= Lagrange.negative_lower && list_x[i] <= Lagrange.negative_upper)
                    {

                    }
                    else
                    {
                        list_x.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        public static double norm(List<double> New_list)
        {
            double normal = 0;
            foreach (double c in New_list)
            {
                normal += Pow(c, 2);
            }
            return Sqrt(normal);
        }
    }

    public class Newthon_lokalization
    {
        private static List<double> derivative_list = new List<double>();
        public static List<double> New_list_x = new List<double>();
        public static List<double> localization()
        {
            double precision1 = Pow(10, -7);
            double f0 = 0;
            double g0 = 0;
            int a = Lobachevkyi.list_x.Count;
            derivative();
            for (int i = 0; i < Lobachevkyi.list_x.Count; i++)
            {
                bool flag = true;
                double x1 = 0;
                double x = Lobachevkyi.list_x[i];
                while (flag)
                {

                    f0 = value_substitution(x);
                    g0 = value_substitution_derivatives(x);
                    x1 = x - f0 / g0;
                    if (value_substitution(x1) > precision1)
                    {
                        flag = true;
                        x = x1;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                New_list_x.Add(x);
            }

            Lobachevkyi.check_bound(New_list_x);
            WriteLine("All lokalized  X its :");
            for (int l = 0; l < New_list_x.Count; l++)
            {
                WriteLine($"X{a} = {New_list_x[l]};");
                a--;
            }

            return New_list_x;
        }
        public static List<double> derivative()
        {

            for (int i = 1; i < Lobachevkyi.list.Count; i++)
            {
                double item = 0;
                item = Lobachevkyi.temp_list[i] * (i);
                derivative_list.Add(item);
            }
            return derivative_list;
        }

        public static double value_substitution(double x)
        {
            double f0 = 0;
            for (int i = 1; i < Lobachevkyi.temp_list.Count; i++)
            {
                f0 += Lobachevkyi.temp_list[i] * Pow(x, i);
            }
            f0 += Lobachevkyi.temp_list[0];
            return f0;
        }

        public static double value_substitution_derivatives(double x)
        {
            double g0 = 0;
            for (int i = 1; i < derivative_list.Count; i++)
            {
                g0 += derivative_list[i] * Pow(x, i);
            }
            g0 += derivative_list[0];
            return g0;
        }
    }
}