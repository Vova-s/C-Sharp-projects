using System;
using static System.Console;

namespace ApproximateSeriesSumCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            int i = 1;
            bool cnt = true;
            Write("input E : "); double e = double.Parse(ReadLine());
            while (cnt)
            {
                double k = 1.0 / Math.Pow(4 + Math.Sin((i * Math.PI) / 180.0), i);
                if (Math.Abs(k) > e)
                {
                    sum += k;
                    i++;

                }
                else
                {
                    cnt = false;
                }
            }
            WriteLine($"sum is : {sum}");


        }
    }
}