using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace TravelingSalesmanProblemSolver
{
    class Program
    {
        static int numberOfPoints;
        static int[,] distanceToPoints = {
        { 0, 7, 5, 11, 13, 9, 6  },
        { 7, 0, 13, 1, 4, 5, 8   },
        { 5, 13, 0, 6, 3, 15, 10 },
        { 11, 1, 6, 0, 8, 2, 4   },
        { 13, 4, 3, 8, 0, 7, 9   },
        { 9, 5, 15, 2, 7, 0, 16 },
        { 6, 8, 10, 4, 9, 16, 0  }
    };
        static List<int> route = new List<int>();
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;
            numberOfPoints = 7;
            FillGraph();
            DisplayGraph();
            int routeLength = StartLittleAlgorytm(distanceToPoints);
            DisplayRoute();
            WriteLine("\n" + "Length of route: ");
            WriteLine(routeLength);
        }

        private static void FillGraph()
        {
            for (int i = 0; i < distanceToPoints.GetLength(0) - 1; i++)
            {
                for (int j = i; j < distanceToPoints.GetLength(0); j++)
                {
                    distanceToPoints[j, i] = distanceToPoints[i, j];
                }
            }
        }
        private static void DisplayGraph()
        {
            for (int i = 0; i < distanceToPoints.GetLength(0); i++)
            {
                for (int j = 0; j < distanceToPoints.GetLength(0); j++)
                {
                    if (distanceToPoints[i, j] == 0)
                    {
                        Write($"{double.PositiveInfinity,-3}");
                    }
                    else { Write($"{distanceToPoints[j, i],-3}"); }
                }
                WriteLine();
            }
        }
        private static void DisplayRoute()
        {
            WriteLine("My route: ");
            for (int i = 0; i < route.Count; i++)
            {
                if (i != route.Count - 1)
                {
                    Write(route[i] + " -> ");
                }
                else
                {
                    Write(route[i] + "; ");
                }
            }
        }
        private static int StartLittleAlgorytm(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            bool[] visited = new bool[m];
            visited[0] = true;
            int routeLength = int.MaxValue;
            return LittleAlgorytm(matrix, visited, 0, 1, 0, routeLength);
        }
        private static int LittleAlgorytm(int[,] matrix, bool[] visited, int currentPos, int count, int length, int routeLength)
        {
            int tmp = routeLength;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (!visited[i] && matrix[currentPos, i] > 0)

                {
                    visited[i] = true;

                    routeLength = LittleAlgorytm(matrix, visited, i, count + 1, length +

                    matrix[currentPos, i], routeLength);
                    visited[i] = false;
                }
            }
            if (count == matrix.GetLength(0) && matrix[currentPos, 0] > 0)
            {
                routeLength = Math.Min(routeLength, length + matrix[currentPos, 0]);
                if (tmp != routeLength)
                {
                    route.Remove(currentPos + 1); route.Add(currentPos + 1);
                }
                return routeLength;
            }
            if (tmp != routeLength)
            {
                route.Remove(currentPos + 1); route.Add(currentPos + 1);
            }
            return routeLength;
        }
    }
}