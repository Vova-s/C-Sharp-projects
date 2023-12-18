using System;
using static System.Console;
using static System.Math;

namespace RandomNumberSquareRootSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            double sum, m;
            sum = 0;
            Random rnd = new Random();
            Write("n : "); int n = int.Parse(ReadLine());
            for (int i = 1; i <= n; i++)
            {
                a = rnd.Next(-100, 100);
                WriteLine($"a[{i}] {a}");
                m = Sqrt(10 + (a * a));
                WriteLine($"m[{i}] {m}");
                sum += m;
            }
            WriteLine("sum :" + sum);
        }
    }
}