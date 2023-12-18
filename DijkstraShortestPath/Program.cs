using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace DijkstraShortestPath
{
    class Program
    {
        static int numberOfPoints;

        static double[,] distanceToPoints = new double[5, 5] { { 0, 6, 0, 0, 11 }, { 6, 0, 8, 0, 0 }, { 0, 8, 0, 12, 7 }, { 0, 0, 12, 0, 4 }, { 11, 0, 7, 4, 0 } };
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.UTF8;

            numberOfPoints = 5;

            Write("Start point: ");
            int startPoint = Convert.ToInt32(Console.ReadLine()) - 1;
            FillGraph();
            DisplayGraph();
            double[] distances = Dijkstra(startPoint);
            DisplayDistances(startPoint, distances);
        }

        private static void FillGraph()
        {
            for (int i = 0; i < distanceToPoints.GetLength(0); i++)
            {
                for (int j = i; j < distanceToPoints.GetLength(0); j++)
                {
                    if (distanceToPoints[i, j] == 0)
                    {
                        distanceToPoints[i, j] = double.PositiveInfinity;
                    }
                    distanceToPoints[j, i] = distanceToPoints[i, j];
                }
            }
        }
        private static void DisplayGraph()
        {
            WriteLine("------------------------------------- My Graph -------------------------------------");
            for (int i = 0; i < distanceToPoints.GetLength(0); i++)
            {
                for (int j = 0; j < distanceToPoints.GetLength(0); j++)
                {
                    Write($"{distanceToPoints[j, i],-3}");
                }
                WriteLine();
            }
        }
        private static double[] Dijkstra(int startPoint)
        {
            double[] dist = new double[numberOfPoints];
            List<int> s = new List<int>();
            for (int j = 0; j < numberOfPoints; j++)
            {
                dist[j] = distanceToPoints[startPoint, j];
                s.Add(j);
            }
            s.Remove(startPoint);
            for (int i = 0; i < numberOfPoints - 1; i++)
            {
                int minValueIndex = Array.IndexOf(dist, dist.Where(j => s.Contains(Array.IndexOf(dist, j))).DefaultIfEmpty(int.MinValue).Min());
                s.Remove(minValueIndex);

                for (int j = 0; j < s.Count; j++)
                {
                    dist[s[j]] = Math.Min(dist[s[j]], dist[minValueIndex] + distanceToPoints[minValueIndex, s[j]]);
                }
            }
            return dist;
        }
        private static void DisplayDistances(int startPoint, double[] distances)
        {
            for (int i = 0; i < distances.Length; i++)
            {
                WriteLine($"Your distance {startPoint + 1} to {i + 1} is {distances[i]}");
            }
        }
    }
}