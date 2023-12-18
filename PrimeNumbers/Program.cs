namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 2;
            int a = 1;
            while (a <= 100)
            {
                bool Prime = true;
                for (int j = 2; j < i; ++j)
                {
                    if (i % j == 0)
                    {
                        Prime = false;

                    }
                }

                if (Prime)
                {
                    Console.WriteLine(($"a[{a}] {i}"));
                    ++a;
                }
                ++i;
            }

        }
    }
}