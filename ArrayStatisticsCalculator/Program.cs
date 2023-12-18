using System;
using static System.Math;
using static System.Console;

namespace ArrayStatisticsCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n;
            int i, j;
            Write("n = ");
            n = Convert.ToByte(ReadLine());
            double[,] a = new double[n, 9];
            Random rnd = new Random();
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    a[i, j] = rnd.Next(-200, 200) + rnd.NextDouble();
                    Write(a[i, j].ToString() + "\t");
                }
                WriteLine();
            }
            double summ;
            double m = 0;
            WriteLine("**************** а *******************");
            for (j = 0; j < 9; j++)
            {
                summ = 0;
                for (i = 0; i < n; i++)
                {
                    summ += a[i, j];
                }
                m = summ / n;
                WriteLine("ser ar " + j + " = " + m);
            }
            summ = 0;
            WriteLine("************ б *************************");
            for (j = 0; j < 9; j += 2)
            {
                for (i = 0; i < n; i += 2)
                {
                    summ += a[i, j];
                }
                m = summ / n;
                WriteLine("avg " + j + " = " + m);
            }
        }
    }
}