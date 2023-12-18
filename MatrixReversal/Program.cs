namespace MatrixReversal
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int n = 5;
            int m = 5;
            int[,] mass = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mass[i, j] = rnd.Next(9);
            Console.WriteLine("До: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mass[i, j] + " ");
                Console.WriteLine();
            }
            for (int i = 0; i < n / 2; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int x = mass[i, j];
                    mass[i, j] = mass[(m - 1) - i, j];
                    mass[(m - 1) - i, j] = x;
                }
            }
            Console.WriteLine("После: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mass[i, j] + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}