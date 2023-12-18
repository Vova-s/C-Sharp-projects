namespace QuadraticRootCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d, x, x1;

            Console.Write("Input a:");
            a = double.Parse(Console.ReadLine());

            Console.Write("Input b:");
            b = double.Parse(Console.ReadLine());

            Console.Write("Input c:");
            c = double.Parse(Console.ReadLine());

            d = Math.Pow(b, 2) - 4 * a * c;

            if (a == 0)
            {
                x = -c / b;
                Console.WriteLine("x:" + x);
            }
            else
            {
                if (d > 0)
                {
                    x = (-b + Math.Sqrt(d)) / (2 * a);
                    x1 = (-b - Math.Sqrt(d)) / (2 * a);

                    Console.WriteLine("X :" + x);
                    Console.WriteLine("X1 : " + x1);
                }
                else if (d == 0)
                {
                    x = -b / (2 * a);
                    Console.WriteLine("x:" + x);
                }
                else
                {
                    Console.Write("No real roots exist");
                }
            }
        }
    }
}