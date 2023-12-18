namespace ConditionalValuesCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, x1, y1;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());

            if (x == y)
            {
                Console.Write("Condition is not satisfied");
            }
            else
            {
                if (x < y)
                {
                    x1 = (x + y) / 2;
                    y1 = (x * y) * 2;

                    Console.WriteLine("x = " + x1);
                    Console.WriteLine("y = " + y1);
                }
                else
                {
                    y1 = (x + y) / 2;
                    x1 = (x * y) * 2;

                    Console.WriteLine("x = " + x1);
                    Console.WriteLine("y = " + y1);
                }
            }
        }
    }
}