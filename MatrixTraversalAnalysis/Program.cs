using System;
using static System.Console;
using System.Diagnostics;

namespace MatrixTraversalAnalysis
{
    class Program
    {

        static void Main(string[] args)
        {
            int[,] Matrix = null;

            int n, m, k;
            int i = 0;
            Write("Input n :");
            while (!int.TryParse(ReadLine(), out n) || (n % 2 != 0) || (n <= 0))
            {
                Write("wrong n, try one more time : ");
            }
            Write("Input m :");
            while (!int.TryParse(ReadLine(), out m) || (m <= 0))
            {
                Write("wrong m, try one more time : ");
            }
            Write("input 1, if u want to generate Random matrix or 2, if u want ot generate Control Matrix : ");
            while (!int.TryParse(ReadLine(), out k) || (k != 1 && k != 2))
            {
                Write("wrong input, try one more time : ");
            }
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            if (k == 1)
            {
                Matrix = generateRandomM(n, m);
                PrintM(Matrix);
            }
            else
            {
                Matrix = generateControlM(n, m);
                PrintM(Matrix);
            }
            sw.Start();
            Algoritm(Matrix, n, m);
            sw.Stop();
            WriteLine(sw.Elapsed);
        }
        static int[,] generateControlM(int row, int col)
        {
            int[,] Matrix = new int[row, col];
            int l = 0;
            for (long i = 0; i < row; i++)
            {
                for (long j = 0; j < col; j++)
                {
                    Matrix[i, j] = l;
                    l++;
                }
            }
            return Matrix;
        }
        static int[,] generateRandomM(int row, int col)
        {

            Random rnd = new Random();
            int[,] Matrix = new int[row, col];
            for (long i = 0; i < row; i++)
                for (long j = 0; j < col; j++)
                {
                    Matrix[i, j] = rnd.Next(0, 100);
                }
            return Matrix;
        }
        static void PrintM(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Write(Matrix[i, j].ToString() + "\t");
                }
                WriteLine();
            }
        }

        static void Algoritm(int[,] Matrix, int n, int m)
        {
            int i = 0;
            int[] ans = new int[m * (n / 2)];
            int row = n - 1;
            int col = 0;
            for (i = 0; i < m * (n / 2); i++)
            {
                ans[i] = Matrix[row, col];
                if ((row + col) % 2 == 0)
                {
                    // even sum means upwards

                    if (col == m - 1 && row == n - 1)
                    {
                        row--;
                        col--;
                    }
                    else if (row == (n / 2) && col % 2 == 0)
                    {
                        col++;
                    }
                    else if (col == (m / 2.0) && row == (n / 2))
                    {
                        col++;
                    }
                    else if (col == m - 1)
                    {
                        row--;
                        col--;
                    }
                    else
                    {
                        row--;
                        if (col > 0)
                        {
                            col--;
                        }
                    }
                }
                else
                {
                    // odd sum means downwards
                    if (row == n - 1)
                    {
                        if (col < m - 1)
                        {
                            col++;
                        }
                        else
                        {
                            row--;
                        }
                    }
                    else if (col == 0)
                    {
                        row++;
                        col++;
                    }
                    else if (col == m - 1)
                    {
                        row--;
                    }
                    else
                    {
                        if (row < n - 1)
                        {
                            row++;
                        }
                        col++;
                    }
                }
                WriteLine($"element : {ans[i]}, coordinates {row},{col}");
            }

            for (row = (n / 2) - 1; row > -1; row--)
            {

                if (row % 2 == 0)
                {
                    for (col = 0; col < m; col++)
                    {
                        WriteLine($"element : {Matrix[row, col]}, coordinates {row},{col}");
                    }
                }
                else
                {
                    for (col = m - 1; col > -1; col--)
                    {
                        WriteLine($"element : {Matrix[row, col]}, coordinates {row},{col}");
                    }
                }
            }
            int j = 0;
            long max = Matrix[0, j];
            long max1 = Matrix[0, j];
            int k = 0;
            int l = 0;
            for (j = 0; j < m; j++)
            {
                for (i = n / 2; i < n; i++)
                {
                    if (Matrix[i, j] > max)
                    {
                        max = Matrix[i, j];
                        k = i;
                        l = j;

                    }
                }
            }
            WriteLine("max : " + max + "coordinates : " + k + " " + l);


            for (j = 0; j < m; j++)
            {
                for (i = (n / 2) - 1; i > -1; i--)
                {
                    if (Matrix[i, j] > max)
                    {
                        max1 = Matrix[i, j];
                        k = i;
                        l = j;
                        WriteLine("new max : " + max1 + "coordinates : " + k + " " + l);
                    }

                }
            }
            if (max1 > max)
            {
            }
            else
            {
                WriteLine("can't found");
            }

        }
    }
}