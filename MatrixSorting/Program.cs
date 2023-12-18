using System;
using System.Collections.Generic;
using static System.Console;

namespace MatrixSorting
{
    internal class Program
    {
        static List<(int, int)> index = new List<(int, int)>();
        static List<int> maxvalue = new List<int>();

        static void Main(string[] args)
        {
            int[,] Matrix = null;
            int n, m;

            // Get user input for the number of rows (n)
            Write("Input n: ");
            while (!int.TryParse(ReadLine(), out n) || (n <= 0))
            {
                Write("Invalid input for n, please try again: ");
            }

            // Get user input for the number of columns (m)
            Write("Input m: ");
            while (!int.TryParse(ReadLine(), out m) || (m <= 0))
            {
                Write("Invalid input for m, please try again: ");
            }

            // Generate a random matrix with n rows and m columns
            Matrix = GenerateRandomMatrix(n, m);

            // Search for the maximum values in each row and store indices and values
            SearchMax(Matrix, n, m);

            // Sort the max values list in descending order
            Sorting1(maxvalue);

            // Display the original matrix
            WriteLine("-------------------------------Matrix--------------------------------");
            PrintMatrix(Matrix, index);

            // Display the matrix with sorted maximum values
            WriteLine("-----------------------------New Matrix--------------------------------");
            PrintMatrixWithSortedValues(Matrix, index, maxvalue);
            WriteLine();
        }

        // Function to generate a random matrix with given rows and columns
        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rnd.Next(0, 100);
                }
            }

            return matrix;
        }

        // Function to print the matrix highlighting maximum values in each row
        static void PrintMatrix(int[,] matrix, List<(int, int)> indices)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int k = i;
                    int h = j;

                    // Check if the current index matches the index of the maximum value in the row
                    if ((k, h) == indices[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Write(matrix[k, h].ToString() + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Write(matrix[i, j].ToString() + "\t");
                    }
                }
                WriteLine();
            }
        }

        // Function to search for the maximum values in each row and store indices and values
        static void SearchMax(int[,] matrix, int rows, int cols)
        {
            int max;
            int k = 0;
            int h = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max = 0;
                Console.WriteLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                        k = i;
                        h = j;
                    }
                }

                // Store the index and maximum value in the lists
                maxvalue.Add(max);
                index.Add((k, h));
            }
        }

        // Function to sort the max values list in descending order
        static List<int> Sorting1(List<int> maxValues)
        {
            int r = 0;
            bool sorted = false;

            while (!sorted)
            {
                sorted = true;

                // Sort the list in descending order (even indices)
                for (int k = 0; k <= maxValues.Count - 2; k += 2)
                {
                    if (maxValues[k] < maxValues[k + 1])
                    {
                        r = maxValues[k];
                        maxValues[k] = maxValues[k + 1];
                        maxValues[k + 1] = r;
                        sorted = false;
                    }
                }

                // Sort the list in descending order (odd indices)
                for (int k = 1; k <= maxValues.Count - 2; k += 2)
                {
                    if (maxValues[k] < maxValues[k + 1])
                    {
                        r = maxValues[k];
                        maxValues[k] = maxValues[k + 1];
                        maxValues[k + 1] = r;
                        sorted = false;
                    }
                }
            }

            return maxValues;
        }

        // Function to print the matrix with sorted maximum values
        static void PrintMatrixWithSortedValues(int[,] matrix, List<(int, int)> indices, List<int> sortedValues)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int k = i;
                    int h = j;

                    // Check if the current index matches the index of the maximum value in the row
                    if ((k, h) == indices[i])
                    {
                        // Replace the original value with the sorted maximum value
                        matrix[k, h] = sortedValues[i];

                        Console.ForegroundColor = ConsoleColor.Red;
                        Write(matrix[k, h].ToString() + "\t");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Write(matrix[i, j].ToString() + "\t");
                    }
                }
                WriteLine();
            }
        }
    }
}