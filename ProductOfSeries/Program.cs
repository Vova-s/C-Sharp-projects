using System;
using static System.Console;

namespace ProductOfSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            double m, m1;
            m1 = 1;
            Write("n : "); int n = int.Parse(ReadLine());
            for (int i = 1; i <= n; i++)
            {
                m = 1 + 1.0 / (i * i);
                Console.WriteLine("Add element = " + m.ToString());
                m1 *= m;
            }
            WriteLine("Product : " + Math.Round(m1, 4));
        }
    }
}