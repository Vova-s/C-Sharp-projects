namespace MinMaxFinder3Values
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, m;
            double maxValue, minValue;

            Console.Write("x = "); x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = "); y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z = "); z = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("If you want to find the maximum value, enter 1");
            Console.WriteLine("If you want both minimum and maximum, enter 2");
            Console.Write("m: "); m = Convert.ToDouble(Console.ReadLine());

            if (m == 1)
            {
                if (x < y && z < y)
                    maxValue = y;
                else if (x < y && y < z)
                    maxValue = z;
                else
                {
                    maxValue = x;
                }
                Console.WriteLine("Max({0};{1};{2}) = {3}", x, y, z, maxValue);
            }
            else if (m == 2)
            {
                if (x < y && z < y)
                    maxValue = y;
                else if (x < y && y < z)
                    maxValue = z;
                else
                {
                    maxValue = x;
                }
                Console.WriteLine("Max({0};{1};{2}) = {3}", x, y, z, maxValue);

                if (x < y && y < z)
                    minValue = x;
                else if (y < x && x < z)
                    minValue = y;
                else
                {
                    minValue = z;
                }
                Console.WriteLine("Min({0};{1};{2}) = {3}", x, y, z, minValue);
            }
            else
            {
                Console.Write("Invalid value for m");
            }
        }
    }
}