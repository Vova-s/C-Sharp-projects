using System;
using static System.Console;

namespace TwoDimensionalArrayBuilder
{

    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int M = 8;
            Random rnd = new Random();
            double[,] A = new double[M, M];
            WriteLine("******************* A *******************");
            for (i = 1; i < M; i++)
            {
                for (j = 1; j < M; j++)
                {
                    if (i == 1)
                    {
                        A[1, j] = 2 * j + 3;
                        Write(A[1, j].ToString() + "\t");
                    }
                    else if (i == 1)
                    {
                        A[2, j] = j - 3 / (2 + (i / j));
                        Write(A[2, j].ToString() + "\t");
                    }
                    else
                    {
                        A[i, j] = A[i - 2, j] + A[i - 1, j];
                        Write(A[i, j].ToString() + "\t");
                    }
                }
                WriteLine();

            }
        }
    }
}