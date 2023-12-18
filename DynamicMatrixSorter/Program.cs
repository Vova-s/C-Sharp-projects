using System;
using static System.Console;

namespace DynamicMatrixSorter
{

    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] Matrix = null;
            int n, m, t;
            Write("1.Create random Matrix.\n2.Create control example to show how it work.\nYour choose : ");
            while (!int.TryParse(ReadLine(), out t) || (t <= 0) || (t > 2))
            {
                Write("choose between 1 and 2 and try one more time : ");
            }
            if (t == 1)
            {
                Write("Input height of Matrix :");
                while (!int.TryParse(ReadLine(), out n) || (n <= 0) || (n == 1))
                {
                    Write("wrong height, try one more time : ");
                }
                Write("Input width of Matrix :");
                while (!int.TryParse(ReadLine(), out m) || (m <= 0) || (m == 1))
                {
                    Write("wrong width, try one more time : ");
                }
                Matrix = generateRandomM(n, m);
                WriteLine("-------------------------------Matrix--------------------------------");
                PrintM(Matrix);
                Console.ForegroundColor = ConsoleColor.White;
                SortedM(Matrix);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int[,] massive = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
                WriteLine("-------------------------------Control Matrix--------------------------------");
                PrintM(massive);
                Console.ForegroundColor = ConsoleColor.White;

                SortedM(massive);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        static int[,] generateRandomM(int row, int col)
        {
            Random rnd = new Random();
            int[,] Matrix = new int[row, col];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    Matrix[i, j] = rnd.Next(-100, 100);
                }

            return Matrix;
        }

        static void PrintM(int[,] Matrix)
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (j % 2 == 0)
                    {

                        Write(Matrix[i, j].ToString() + "\t", Console.ForegroundColor);
                    }
                    else
                    {

                        Write(Matrix[i, j].ToString() + "\t", Console.ForegroundColor);
                    }
                }
                WriteLine();
            }
        }

        static void PrintNewM(int[] evenM, int[] oddM, int b, int n)
        {
            int[,] Matrix1 = new int[b, n];

            int k = 0;
            int c = 0;
            for (int j = 0; j < n; j++)
            {

                for (int i = 0; i < b; i++)
                {

                    if (j % 2 == 0)
                    {
                        while (k < evenM.Length)
                        {
                            Matrix1[i, j] = (int)evenM[k];
                            break;
                        }
                        k++;
                    }
                    else
                    {
                        while (c < oddM.Length)
                        {
                            Matrix1[i, j] = (int)oddM[c];
                            break;
                        }
                        c++;

                    }
                }
            }
            WriteLine("-------------------------------Sorted Matrix--------------------------------");
            PrintM(Matrix1);
        }

        static void SortedM(int[,] Matrix)
        {

            int k = 0;
            int c = 0;
            int length = (Matrix.GetLength(1) / 2) * Matrix.GetLength(0);
            double length1 = (Math.Ceiling(Matrix.GetLength(1) / 2.0)) * Matrix.GetLength(0);
            int[] evenM = new int[(int)length1];
            int[] oddM = new int[length];
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    if (j % 2 == 0)
                    {
                        while (k < length1)
                        {
                            evenM[k] = Matrix[i, j];
                            break;
                        }
                        k++;
                    }
                    else
                    {
                        while (c < length)
                        {
                            oddM[c] = Matrix[i, j];
                            break;
                        }
                        c++;

                    }
                }
            }
            WriteLine("------------------Start Sorting-------------------");
            QuicksortForEven(evenM, 0, evenM.Length - 1, Matrix.GetLength(0));
            WriteLine();
            WriteLine("-------------------Final even massive-------------------");
            for (int q = 0; q < evenM.Length; q++)
            {

                Write(evenM[q] + "; ");
            }
            WriteLine();
            WriteLine("------------------Start Sorting-------------------");
            QuicksortForOdd(oddM, 0, oddM.Length - 1, Matrix.GetLength(0));
            WriteLine();
            WriteLine("-------------------Final odd massive-------------------");
            for (int w = 0; w < oddM.Length; w++)
            {

                Write(oddM[w] + "; ");
            }
            WriteLine();
            PrintNewM(evenM, oddM, Matrix.GetLength(0), Matrix.GetLength(1));
        }

        private static void QuicksortForOdd(int[] valuesM, int left, int right, int m)
        {

            int i = left;
            int j = right;
            var pivot = valuesM[(left + right) / 2];
            if (j - i < m - 1)
            {
                InsertSortForOdd(valuesM, i, j);
            }
            else
            {
                while (i <= j)
                {
                    while (valuesM[i] > pivot)
                    {
                        i++;
                    }

                    while (valuesM[j] < pivot)
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        PrintBeforeQuicksortForOdd(left, right, i, j, valuesM, ConsoleColor.Red, ConsoleColor.Yellow);
                        var tmp = valuesM[i];
                        valuesM[i] = valuesM[j];
                        valuesM[j] = tmp;
                        PrintAftereQuicksortForOdd(left, right, i, j, valuesM, ConsoleColor.Cyan, ConsoleColor.Yellow);
                        WriteLine();

                        i++;
                        j--;
                    }
                }

                if (left < j)
                {
                    QuicksortForOdd(valuesM, left, j, m);
                }

                if (i < right)
                {
                    QuicksortForOdd(valuesM, i, right, m);
                }
            }
        }

        private static void QuicksortForEven(int[] valuesM, int left, int right, int m)
        {

            int i = left;
            int j = right;
            var pivot = valuesM[(left + right) / 2];
            if (j - i < m - 1)
            {
                InsertSortForEven(valuesM, i, j);
            }
            else
            {
                while (i <= j)
                {
                    while (Math.Abs(valuesM[i]) < Math.Abs(pivot))
                    {
                        i++;
                    }

                    while (Math.Abs(valuesM[j]) > Math.Abs(pivot))
                    {
                        j--;
                    }

                    if (i <= j)
                    {
                        PrintBeforeQuicksortForEven(left, right, i, j, valuesM, ConsoleColor.Red, ConsoleColor.Yellow);
                        var tmp = valuesM[i];
                        valuesM[i] = valuesM[j];
                        valuesM[j] = tmp;
                        PrintAfterQuicksortForEven(left, right, i, j, valuesM, ConsoleColor.Cyan, ConsoleColor.Yellow);
                        WriteLine();
                        i++;
                        j--;
                    }
                }

                if (left < j)
                {
                    QuicksortForEven(valuesM, left, j, m);
                }

                if (i < right)
                {
                    QuicksortForEven(valuesM, i, right, m);
                }
            }
        }

        private static void InsertSortForOdd(int[] valuesM, int left, int right)
        {

            for (int i = left; i <= right; i++)
            {
                int index = i;
                int cur = valuesM[index];
                while (index > left && cur > valuesM[index - 1])
                {
                    PrintBeforeInsertSortForOdd(left, right, index, valuesM, ConsoleColor.DarkYellow);
                    var tmp = valuesM[index];
                    valuesM[index] = valuesM[index - 1];
                    valuesM[index - 1] = tmp;
                    PrintAfterInsertSortForOdd(left, right, index, valuesM, ConsoleColor.Cyan);
                    index--;
                }


            }
        }

        private static void InsertSortForEven(int[] valuesM, int left, int right)
        {

            for (int i = left; i <= right; i++)
            {
                int index = i;
                int cur = valuesM[index];
                while (index > left && Math.Abs(cur) < Math.Abs(valuesM[index - 1]))
                {
                    PrintBeforeInsertSortForEven(left, right, index, valuesM, ConsoleColor.DarkYellow);
                    var tmp = valuesM[index];
                    valuesM[index] = valuesM[index - 1];
                    valuesM[index - 1] = tmp; ;
                    PrintAfterInsertSortForEven(left, right, index, valuesM, ConsoleColor.Cyan);
                    index--;
                }

            }
        }

        private static void PrintBeforeQuicksortForOdd(int start, int end, int i, int j, int[] array, ConsoleColor cl, ConsoleColor c)
        {
            WriteLine();
            WriteLine("Start position in quicksort for odd");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == j)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else if (k == (start + end) / 2)
                {
                    ForegroundColor = c;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                    Write(array[k] + "; ");
            }
        }

        private static void PrintAftereQuicksortForOdd(int start, int end, int i, int j, int[] array, ConsoleColor cl, ConsoleColor c)
        {
            WriteLine();
            WriteLine("Changed position in quicksort for odd");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == j)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else if (k == (start + end) / 2)
                {
                    ForegroundColor = c;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                    Write(array[k] + "; ");
            }
        }

        private static void PrintBeforeQuicksortForEven(int start, int end, int i, int j, int[] array, ConsoleColor cl, ConsoleColor c)
        {
            WriteLine();
            WriteLine("Start position in quicksort for even");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == j)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else if (k == (start + end) / 2)
                {
                    ForegroundColor = c;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                    Write(array[k] + "; ");
            }
        }

        private static void PrintAfterQuicksortForEven(int start, int end, int i, int j, int[] array, ConsoleColor cl, ConsoleColor c)
        {
            WriteLine();
            WriteLine("Changed position in quicksort for even");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == j)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else if (k == (start + end) / 2)
                {
                    ForegroundColor = c;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                    Write(array[k] + "; ");
            }
        }

        private static void PrintAfterInsertSortForEven(int start, int end, int i, int[] array, ConsoleColor cl)
        {
            WriteLine();
            WriteLine("Changed position in Insert sort in even massive ");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == i - 1)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Write(array[k] + "; ");
                }
            }
        }

        private static void PrintBeforeInsertSortForEven(int start, int end, int i, int[] array, ConsoleColor cl)
        {
            WriteLine();
            WriteLine("Start position in Insert sort in even massive ");
            for (int k = start; k <= end; k++)
            {
                if (k == i || k == i - 1)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Write(array[k] + "; ");
                }
            }
        }

        private static void PrintAfterInsertSortForOdd(int start, int end, int i, int[] array, ConsoleColor cl)
        {
            WriteLine();
            WriteLine("Changed position in Insert sort in odd massive ");
            for (int k = start; k <= end; k++)
            {

                if (k == i || k == i - 1)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Write(array[k] + "; ");
                }
            }
        }

        private static void PrintBeforeInsertSortForOdd(int start, int end, int i, int[] array, ConsoleColor cl)
        {
            WriteLine();
            WriteLine("Start position in Insert sort in odd massive ");
            for (int k = start; k <= end; k++)
            {

                if (k == i || k == i - 1)
                {
                    ForegroundColor = cl;
                    Write(array[k] + "; ");
                    ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Write(array[k] + "; ");
                }
            }

        }

    }
}
