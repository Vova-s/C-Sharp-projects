using System;
using static System.Console;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int m, n, new_n;
            new_n = 0;
            Write(" m : "); m = int.Parse(ReadLine());
            Write(" n : "); n = int.Parse(ReadLine());
            for (int i = 1; i <= m; i++)
            {
                new_n += n % 10;
                n /= 10;
            }
            WriteLine("sum " + new_n);
        }
    }
}