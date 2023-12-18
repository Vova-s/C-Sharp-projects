using System;
using static System.Console;

namespace SquaredSeriesSum
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            Write("input  n : "); int n = int.Parse(ReadLine());

            for (int k = 1; k <= n; k++)
            {
                sum += 1.0 / (Math.Pow(2 * k + 1, 2));
            }
            WriteLine($"sum is : {sum}");
        }
    }
}