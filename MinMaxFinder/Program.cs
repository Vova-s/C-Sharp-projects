namespace MinMaxFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, m;
            double maxValue, minValue;

            Console.Write("x = "); x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = "); y = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("If you want to find the maximum value, enter 1");
            Console.WriteLine("If you want to find the minimum value, enter 2");
            Console.WriteLine("If you want both, enter 3");
            Console.Write("m: "); m = Convert.ToDouble(Console.ReadLine());

            if (m == 1)
            {
                maxValue = (x < y) ? y : x;
                Console.WriteLine("Max({0};{1}) = {2}", x, y, maxValue);
            }
            else if (m == 2)
            {
                minValue = (x < y) ? x : y;
                Console.WriteLine("Min({0};{1}) = {2}", x, y, minValue);
            }
            else if (m == 3)
            {
                maxValue = (x < y) ? y : x;
                Console.WriteLine("Max({0};{1}) = {2}", x, y, maxValue);

                minValue = (x < y) ? x : y;
                Console.WriteLine("Min({0};{1}) = {2}", x, y, minValue);
            }
            else
            {
                Console.Write("Invalid value for m");
            }
        }
    }
}