using System;
using static System.Console;

namespace PowerOfTwoCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double n, i, c;
            Write("n = "); n = Convert.ToDouble(ReadLine());
            c = 2;
            for (i = 1; i < n; i++)
            {
                c *= 2;


            }
            WriteLine("2^n =" + c.ToString());
        }
    }
}