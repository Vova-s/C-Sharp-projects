using System;
using static System.Console;
using static System.Math;

namespace RandomNumberAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, i, sum;
            Write(" n = "); n = int.Parse(ReadLine());
            Random rnd = new Random();
            sum = 0;
            for (i = 1; i <= n; i++)
            {
                int a = rnd.Next(1, n);
                WriteLine($"a[{i}] = {a}");
                if (Sqrt(a) % 2 == 0 && a != 0)
                {
                    sum++;
                }
            }
            WriteLine("Here are " + sum + "squares of even numbers");
        }
    }
}