using System;
using static System.Console;
using System.Collections.Generic;

namespace GreedyTravelingSalesmanSolver
{
    internal class Program
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
        static void Main(string[] args)
        {

            OutputEncoding = System.Text.Encoding.UTF8;
            numberOfPoints = 7;
            FillGraph();
            DisplayGraph();
            int[] route = GreedyAlgorithm();
            DisplayRoute(route);
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
        private static int[] GreedyAlgorithm()
        {
            List<int> freePoints = new List<int>();
            int[] route = new int[numberOfPoints];
            for (int i = 1; i < numberOfPoints; i++)
            {
                freePoints.Add(i);
            }
            route[0] = 0;
            for (int i = 1; i < numberOfPoints; i++)
            {
                route[i] = FindNearestPoint(route[i - 1], distanceToPoints, freePoints);
                freePoints.Remove(route[i]);
            }

            return route;
        }
        private static int FindNearestPoint(int point, int[,] distanceToPoints, List<int>
        freePoints)
        {
            int nearestPoint = freePoints[0];
            for (int i = 1; i < freePoints.Count; i++)
            {
                if (distanceToPoints[point, freePoints[i]] != 0 && distanceToPoints[point,
                freePoints[i]] < distanceToPoints[point, nearestPoint])
                {
                    nearestPoint = freePoints[i];
                }
            }
            return nearestPoint;
        }
        private static void DisplayRoute(int[] route)
        {
            WriteLine("My route: ");
            for (int i = 0; i < route.Length; i++)
            {
                if (i != route.Length - 1)
                {
                    Write(route[i] + 1 + " -> ");
                }
                else
                {
                    Write(route[i] + 1 + "; ");
                }
            }
            WriteLine("\nLength of route :" + "\n" + GetRouteLength(route));
        }
        private static int GetRouteLength(int[] route)
        {
            int length = distanceToPoints[route[0], route[route.Length - 1]];
            for (int i = 0; i < route.Length - 1; i++)
            {
                length += distanceToPoints[route[i], route[i + 1]];
            }
            return length;
        }
    }
}