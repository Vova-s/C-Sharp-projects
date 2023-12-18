using System;
using static System.Console;
using static System.Math;

namespace LongestCommonSubsequenceFinder
{
    class Program
    {
        public static string subsequence = "";
        static void Main()
        {
            string a, b;
            long[,] S;
            char[,] B;
            Write("input 1 row = ");
            a = Convert.ToString(ReadLine());
            Write("input 2 row = ");
            b = Convert.ToString(ReadLine());
            S = generateMatrix1(a.Length, b.Length, a, b);
            printMatrix(S);
            B = generateMatrix2(S, a.Length, b.Length, a, b);
            printMatrix2(B);
            s_subsequence(B, a.Length, b.Length, b);
            Write(subsequence);
        }
        static long[,] generateMatrix1(int r, int c, string a, string b)
        {
            long[,] Matrix = new long[r + 1, c + 1];
            for (long i = 0; i < r + 1; i++)
            {
                for (long j = 0; j < 1; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
            for (int i = 1; i < r + 1; i++)
            {
                for (int j = 1; j < c + 1; j++)
                {
                    if (a[i - 1] == b[j - 1])
                        Matrix[i, j] = Matrix[i - 1, j - 1] + 1;
                    else
                        Matrix[i, j] = Math.Max(Matrix[i - 1, j], Matrix[i, j - 1]);
                }
            }
            return Matrix;
        }
        static char[,] generateMatrix2(long[,] S, int r, int c, string a, string b)
        {
            char[,] Matrix2 = new char[r + 1, c + 1];
            for (int i = 1; i < r + 1; i++)
            {
                for (int j = 1; j < c + 1; j++)
                {
                    if (a[i - 1] == b[j - 1])
                        Matrix2[i, j] = (char)(0x005C);
                    else if (Math.Max(S[i - 1, j], S[i, j - 1]) == S[i - 1, j])
                    {
                        Matrix2[i, j] = (char)(0x007C);
                    }
                    else if (Math.Max(S[i - 1, j], S[i, j - 1]) == S[i, j - 1])
                        Matrix2[i, j] = (char)(0x002D);
                }
            }
            return Matrix2;
        }
        static void printMatrix(long[,] Matrix)
        {

            for (long i = 0; i < Matrix.GetLength(0); i++)
            {
                for (long j = 0; j < Matrix.GetLength(1); j++)
                    Write(Matrix[i, j].ToString() + "\t");
                WriteLine();
            }
        }
        static void printMatrix2(char[,] Matrix)
        {
            for (long i = 0; i < Matrix.GetLength(0); i++)
            {
                for (long j = 0; j < Matrix.GetLength(1); j++)
                    Write(Matrix[i, j].ToString() + "\t");
                WriteLine();
            }
        }
        static void s_subsequence(char[,] Matrix2, int i, int j, string a)
        {

            if (i >= 1 && j >= 1)
            {
                if (Matrix2[i, j] == (char)(0x005C))
                {
                    s_subsequence(Matrix2, i - 1, j - 1, a);
                    subsequence += a[j - 1];
                }
                else if (Matrix2[i, j] == (char)(0x007C))
                    s_subsequence(Matrix2, i - 1, j, a);
                else
                {
                    s_subsequence(Matrix2, i, j - 1, a);
                }


            }
        }
    }
}