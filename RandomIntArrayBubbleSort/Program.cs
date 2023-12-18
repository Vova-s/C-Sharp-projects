using System;
using static System.Console;

namespace RandomIntArrayBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int i, j, n, temp;
            n = rnd.Next(10, 30);
            int[] a = new int[n];
            WriteLine("Input Array:");
            for (i = 0; i < n; i++)
            {
                Write("a[" + (i + 1).ToString() + "] = ");
                a[i] = rnd.Next(-50, 51);
                WriteLine(a[i].ToString());
            }
            for (j = 0; j < n; j++)
            {
                for (i = 0; i < n - 1 - j; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
                }
            }
            WriteLine("\nSorted Array:");
            for (i = 0; i < n; i++)
            {
                WriteLine("a[" + (i + 1).ToString() + "] =" + a[i].ToString());
            }
        }
    }