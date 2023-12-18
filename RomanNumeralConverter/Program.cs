using System;
using static System.Console;
using System.Collections.Generic;

namespace RomanNumeralConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = ReadLine();
            Solution.RomanToInt(s);
        }
        public class Solution
        {
            public static int RomanToInt(string s)
            {
                int sum = 0;
                int index, index1;
                List<string> list_romanian = new List<string>() { "I", "V", "X", "L", "C", "D", "M" };
                List<int> list_value = new List<int>() { 1, 5, 10, 50, 100, 500, 1000 };
                List<int> list_index = new List<int>();
                foreach (var c in s)
                {
                    index = list_romanian.IndexOf(c.ToString());
                    list_index.Add(index);
                    sum += list_value[index];
                }
                for (int i = 0; i < list_index.Count; i++)
                {
                    if (i == list_index.Count - 1)
                    {

                        list_index.RemoveAt(i);
                        i = -1;

                    }
                    else
                    {
                        if (list_index[i] < list_index[i + 1])
                        {
                            sum = sum - 2 * list_value[list_index[i]];
                            list_index.RemoveAt(i);
                            list_index.RemoveAt(i);
                            i = -1;
                        }
                        else if (list_index[i] == list_index[i + 1])
                        {
                            list_index.RemoveAt(i);
                            list_index.RemoveAt(i);
                            i = -1;
                        }
                        else
                        {
                            list_index.RemoveAt(i);
                            i = -1;
                        }
                    }
                }


                Console.WriteLine(s + " = " + sum);
                return sum;

            }
        }
    }
}