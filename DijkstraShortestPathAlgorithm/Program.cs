namespace DijkstraShortestPathAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Matrix Data

            var filePath = @".\matrix.txt"; // Path
            var matrixData = File.ReadAllLines(filePath); // Read all lines from the file
            var adjacencyMatrix = new int[matrixData.Length, matrixData[0].Split(' ').Length]; // Initialize a two-dimensional array
            adjacencyMatrix = FillAdjacencyMatrix(matrixData, adjacencyMatrix); // Fill the adjacency matrix
            var matrixSize = matrixData.Length; // Matrix size

            #endregion

            var shortestPathFinder = new DijkstraAlgorithm(adjacencyMatrix, matrixSize);

            shortestPathFinder.PrintMatrix(); // Display the adjacency matrix

            shortestPathFinder.FindShortestPaths(adjacencyMatrix, 0);
        }

        #region Fill Adjacency Matrix

        static int[,] FillAdjacencyMatrix(string[] matrixData, int[,] adjacencyMatrix)
        {
            for (int i = 0; i < matrixData.Length; i++)
            {
                var rowValues = matrixData[i].Split(' ');
                for (int j = 0; j < rowValues.Length; j++)
                {
                    try
                    {
                        adjacencyMatrix[i, j] = Convert.ToInt32(rowValues[j]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("There are incorrect data types in your matrix");
                        Environment.Exit(0);
                    }
                }
            }

            return adjacencyMatrix;
        }

        #endregion
    }

    public class DijkstraAlgorithm
    {
        public DijkstraAlgorithm(int[,] adjacencyMatrix, int matrixSize)
        {
            AdjacencyMatrix = adjacencyMatrix;
            MatrixSize = matrixSize;
        }

        private int[,] AdjacencyMatrix { get; }
        private int MatrixSize { get; }

        public void PrintMatrix()
        {
            Console.WriteLine("Your adjacency matrix: ");
            Console.WriteLine();
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdjacencyMatrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}", AdjacencyMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private int MinDistance(int[] distances, bool[] shortestPathSet)
        {
            var min = int.MaxValue;
            var minIndex = -1;

            for (int i = 0; i < MatrixSize; i++)
            {
                if (shortestPathSet[i] == false && distances[i] <= min)
                {
                    min = distances[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void FindShortestPaths(int[,] adjacencyMatrix, int startNode)
        {
            var distances = new int[MatrixSize];
            var paths = new int[MatrixSize];
            var shortestPathSet = new bool[MatrixSize];

            for (int i = 0; i < MatrixSize; i++)
            {
                distances[i] = int.MaxValue;
                shortestPathSet[i] = false;
            }

            distances[startNode] = 0;

            for (int i = 0; i < MatrixSize - 1; i++)
            {
                var minDistanceNode = MinDistance(distances, shortestPathSet);

                shortestPathSet[minDistanceNode] = true;

                for (int j = 0; j < MatrixSize; j++)
                {
                    if (!shortestPathSet[j] && adjacencyMatrix[minDistanceNode, j] != 0 &&
                        distances[minDistanceNode] != int.MaxValue &&
                        distances[minDistanceNode] + adjacencyMatrix[minDistanceNode, j] < distances[j])
                    {
                        distances[j] = distances[minDistanceNode] + adjacencyMatrix[minDistanceNode, j];
                        paths[j] = minDistanceNode;
                    }
                }
            }

            Console.WriteLine("Path data (Dijkstra's algorithm):");
            Console.WriteLine();
            Console.WriteLine($"Starting node: 1");

            for (int i = 1; i < MatrixSize; i++)
            {
                if (paths[i] == 0)
                    Console.WriteLine($"Shortest path: from 1 -> {i + 1} direct | Minimum distance: {distances[i]}");
                else
                {
                    var stack = new Stack<int>();
                    stack.Push(paths[i] + 1);

                    Console.Write($"Shortest path: from 1 -> ");

                    for (int j = paths[i]; j != 0; j = paths[j])
                    {
                        if (paths[j] == 0)
                            break;
                        else
                        {
                            stack.Push(paths[j]);
                            j = paths[j];
                        }
                    }

                    for (int j = 0; j <= stack.Count; j++)
                    {
                        if (j == stack.Count)
                            Console.Write($"{i + 1} | Minimum distance: {distances[i]}");
                        else
                        {
                            Console.Write(stack.Pop() + " -> ");
                            j = -1;
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}