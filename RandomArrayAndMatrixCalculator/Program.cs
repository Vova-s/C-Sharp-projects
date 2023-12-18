using System;
using static System.Console;

namespace RandomArrayAndMatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double s = 0;
            int i, j;
            double[] A = new double[3];
            double[,] B = new double[3, 3];
            WriteLine("******************* A *******************");
            for (i = 0; i < 3; i++)
            {

                A[i] = rnd.Next(-100, 100);
                WriteLine($"a[{i + 1}] {A[i]}".ToString() + "\t");



            }
            WriteLine();
            WriteLine("******************* B *******************");
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    B[i, j] = A[i] - 3 * A[j];
                    Write(B[i, j].ToString() + "\t");

                }
                WriteLine();
            }

        }
    }
}