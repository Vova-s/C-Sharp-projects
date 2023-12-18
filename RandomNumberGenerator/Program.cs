using System;
using static System.Console;
using static System.Random;

namespace RandomNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = 70, i, a, b;
            Random rnd = new Random();
            b = rnd.Next(-200, 200) + Math.Round(rnd.NextDouble(), 4);
            for (i = 2; i <= n; i++)
            {
                a = rnd.Next(-200, 200) + Math.Round(rnd.NextDouble(), 4);
                Console.WriteLine($"a[{i}] =" + a);
            }
            WriteLine("a[1] = " + b);
        }
    }
}