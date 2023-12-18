namespace RandomArrayGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            double a1 = rand.Next(-100, 100) + rand.NextDouble();
            for (int i = 2; i <= 70; i++)
            {
                double a = rand.Next(-100, 100) + rand.NextDouble();
                Console.WriteLine($"a[{i}] = {a}");
            }
            Console.WriteLine("a[1] = " + a1);

        }
    }
}

        

   
