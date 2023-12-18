namespace QCalculationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, m, n, q, f, g;
            double maxValue, minValue;

            Console.Write("x = "); x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = "); y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z = "); z = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("If a) press - 1");
            Console.WriteLine("If b) press - 2");
            q = Convert.ToDouble(Console.ReadLine());

            if (q == 1)
            {
                m = x + y + z;
                n = x * y * z;

                if (m < n)
                    maxValue = n;
                else
                    maxValue = m;

                Console.Write($"Max({x}+{y}+{z};{x}*{y}*{z}) = ");
                Console.WriteLine("Max({0};{1}) = {2}", m, n, maxValue);
            }
            else if (q == 2)
            {
                f = (x + y + z) / 2;
                g = x * y * z;

                if (f < g)
                {
                    m = Math.Pow(f, 2) + 1;
                    minValue = m;
                }
                else
                {
                    n = Math.Pow(g, 2) + 1;
                    minValue = n;
                }

                Console.Write($"Min^2({x}+{y}+{z / 2};{x}*{y}*{z}) + 1= ");
                Console.WriteLine("Min^2({0};{1}) + 1 = {2}", f, g, minValue);
            }
            else
            {
                Console.Write("Such q does not exist");
            }
        }
    }
}