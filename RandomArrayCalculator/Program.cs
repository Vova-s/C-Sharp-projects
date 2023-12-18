using System;
using static System.Console;

namespace RandomArrayCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int M = 29;
            int N = 30;
            Random rnd = new Random();
            double[] A = new double[M];
            double[] B = new double[M];
            double[] C = new double[N];
            C[29] = 0;
            WriteLine("******************* A *******************");
            for (i = 1; i < M; i++)
            {
                A[i] = rnd.Next(-100, 100) + rnd.NextDouble();
                WriteLine(A[i].ToString() + "\t");

            }
            WriteLine("******************* B *******************");
            for (i = 1; i < M; i++)
            {
                B[i] = rnd.Next(-10, 10) + rnd.NextDouble();
                WriteLine(B[i].ToString() + "\t");
            }
            WriteLine("******************* C *******************");
            for (i = 1; i < M; i++)
            {

                C[29 - i] = A[29 - i] / (B[29 - i] - C[29 - i + 1]);
                WriteLine(C[29 - i].ToString() + "\t");
            }
        }
    }
}