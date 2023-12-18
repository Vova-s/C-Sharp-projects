using System;
using static System.Console;
using System.Collections.Generic;

namespace SortMaxValues
{
    class Program
    {
        static List<(int, int)> index = new List<(int, int)>();
        static List<int> maxvalue = new List<int>();
        static void Main(string[] args)
        {
            int[,] Matrix = null;
            int n, m;
            Write("Input n :");
            while (!int.TryParse(ReadLine(), out n) || (n <= 0))
            {
                Write("wrong n, try one more time : ");
            }
            Write("Input m :");
            while (!int.TryParse(ReadLine(), out m) || (m <= 0))
            {
                Write("wrong m, try one more time : ");
            }
            Matrix = generateRandomM(n, m);
            SearchMax(Matrix, n, m);
            sorting1(maxvalue);
            WriteLine("-------------------------------Matrix--------------------------------");
            PrintM(Matrix, index);
            WriteLine("-----------------------------New Matrix--------------------------------");
            PrintM1(Matrix, index, maxvalue);
            WriteLine();


        }
        static int[,] generateRandomM(int row, int col)
        {
            Random rnd = new Random();
            int[,] Matrix = new int[row, col];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    Matrix[i, j] = rnd.Next(0, 100);
                }

            return Matrix;
        }

        static void PrintM(int[,] Matrix, List<(int, int)> index)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    int k = i;
                    int h = j;
                    if ((k, h) == index[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Write(Matrix[k, h].ToString() + "\t");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    else
                    {
                        Write(Matrix[i, j].ToString() + "\t");
                    }
                }
                WriteLine();
            }
        }
        static void SearchMax(int[,] Matrix, int i, int j)
        {
            int max;
            int k = 0;
            int h = 0;
            for (i = 0; i < Matrix.GetLength(0); i++)
            {
                max = 0;
                Console.WriteLine();
                for (j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (Matrix[i, j] > max)
                    {
                        max = Matrix[i, j];
                        k = i;
                        h = j;
                    }
                }
                maxvalue.Add(max);
                index.Add((k, h));
            }
        }
        static List<int> sorting1(List<int> maxvalue)
        {
            int r = 0;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int k = 0; k <= maxvalue.Count - 2; k += 2)
                {
                    if (maxvalue[k] < maxvalue[k + 1])
                    {
                        r = maxvalue[k];
                        maxvalue[k] = maxvalue[k + 1];
                        maxvalue[k + 1] = r;
                        sorted = false;
                    }
                }
                for (int k = 1; k <= maxvalue.Count - 2; k += 2)
                {
                    if (maxvalue[k] < maxvalue[k + 1])
                    {
                        r = maxvalue[k];
                        maxvalue[k] = maxvalue[k + 1];
                        maxvalue[k + 1] = r;
                        sorted = false;
                    }
                }
            }

            return maxvalue;
        }

        static void PrintM1(int[,] Matrix, List<(int, int)> index, List<int> maxvalue)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    int k = i;
                    int h = j;
                    if ((k, h) == index[i])
                    {
                        Matrix[k, h] = maxvalue[i];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Write(Matrix[k, h].ToString() + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Write(Matrix[i, j].ToString() + "\t");
                    }
                }
                WriteLine();
            }
        }
    }
}