namespace PointBelongsToLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d, e, f, g, h, m, n;

            Console.Write("Enter x-coordinate for point a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y-coordinate for point a: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter x-coordinate for point on the line l: ");
            c = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y-coordinate for point on the line l: ");
            d = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter x-coordinate for the start of the line segment: ");
            e = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y-coordinate for the start of the line segment: ");
            f = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter x-coordinate for the end of the line segment: ");
            g = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter y-coordinate for the end of the line segment: ");
            h = Convert.ToDouble(Console.ReadLine());

            m = (a - e) * (h - f) - (b - f) * (g - e);

            if (m == 0)
            {
                Console.WriteLine("Point a does not belong to line l!");
            }
            else
            {
                n = (c - e) * (h - f) - (d - f) * (g - e);

                if (n == 0)
                {
                    Console.WriteLine("Point a does not belong to line l!");
                }
                else
                {
                    if (m > 0 && n > 0 || m < 0 && n < 0)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
            }
        }
    }
}