namespace DiamondPattern
{
    internal class Program
    {
        public static void Main()
        {
            int a, b, size = 15;

            for (a = size / 2; a <= size; a = a + 2)
            {


                for (b = 1; b < size - a; b = b + 2)
                    Console.Write(" ");

                for (b = 1; b <= a; b++)
                    Console.Write("0");

                for (b = 1; b <= size - a; b++)
                    Console.Write(" ");

                for (b = 1; b <= a - 1; b++)
                    Console.Write("0");

                Console.WriteLine();
            }

            for (a = size; a >= 0; a--)
            {

                for (b = a; b < size; b++)
                    Console.Write(" ");

                for (b = 1; b <= ((a * 2) - 1); b++)
                    Console.Write("0");

                Console.WriteLine(" ");
            }
        }
    }
}