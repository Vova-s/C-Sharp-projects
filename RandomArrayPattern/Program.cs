using static System.Console;
namespace RandomArrayPattern
{
    class Program
    {
        private static void Main()
        {
            int[][] A = RectangularArrays.RectangularIntArray(DefineConstants.N, DefineConstants.N);
            int a, b, i, j, c, p = 0;

            // User input for the range of random numbers
            Console.Write("Enter the left and right boundaries of the range: ");
            a = int.Parse(ReadLine());
            b = int.Parse(ReadLine());

            // Fill the 2D array with random numbers
            Console.Write("Original array\n");
            for (i = 0; i < DefineConstants.N; i++)
            {
                for (j = 0; j < DefineConstants.N; j++)
                {
                    A[i][j] = a + RandomNumbers.NextNumber() % (b - a);
                    Console.Write("{0,3:D}", A[i][j]);
                }
                Console.Write("\n");
            }

            Console.Write("\n\n");

            // Print the elements in a specific pattern
            for (i = 0, j = DefineConstants.N - 1, c = 0; c < DefineConstants.N * DefineConstants.N;)
            {
                if (p == 0)
                {
                    if (j == DefineConstants.N || i == DefineConstants.N)
                    {
                        j--;
                        if (i == DefineConstants.N)
                        {
                            j--;
                            i--;
                        }
                        p = 1;
                    }
                    else
                    {
                        Console.WriteLine("{0,2:D}", A[i][j]);
                        i++;
                        j++;
                        c++;
                    }
                }
                else
                {
                    if (i == (DefineConstants.N - 1) - DefineConstants.N || j == (DefineConstants.N - 1) - DefineConstants.N)
                    {
                        i++;
                        if (j == (DefineConstants.N - 1) - DefineConstants.N)
                        {
                            i++;
                            j++;
                        }
                        p = 0;
                    }
                    else
                    {
                        Console.WriteLine("{0,2:D}", A[i][j]);
                        i--;
                        j--;
                        c++;
                    }
                }
            }
            Console.ReadKey(true);
        }

        internal static class DefineConstants
        {
            public const int N = 5;
        }

        internal static class RandomNumbers
        {
            private static System.Random r;

            public static int NextNumber()
            {
                if (r == null)
                    Seed();

                return r.Next();
            }

            public static int NextNumber(int ceiling)
            {
                if (r == null)
                    Seed();

                return r.Next(ceiling);
            }

            public static void Seed()
            {
                r = new System.Random();
            }

            public static void Seed(int seed)
            {
                r = new System.Random(seed);
            }
        }

        internal static class RectangularArrays
        {
            public static int[][] RectangularIntArray(int size1, int size2)
            {
                int[][] newArray = new int[size1][];
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }
        }
    }
}