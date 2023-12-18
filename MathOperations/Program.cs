namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, x, y, z, m;
            double ch, zn, m1, b1;

            // User input
            Console.Write("x: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("y: ");
            y = double.Parse(Console.ReadLine());
            Console.Write("z: ");
            z = double.Parse(Console.ReadLine());

            // Intermediate calculation
            m = x + y;
            m1 = m * 2 + 2 * m - Math.Tan(m / 2);

            // Calculations for variable 'a'
            ch = 1 + Math.Pow(m1, 2);
            zn = Math.Abs(x - (2 * y / (1 - Math.Pow(x, 2) * Math.Pow(y, 2))));
            a = ch / zn;

            // Output result for variable 'a'
            Console.WriteLine("a) " + a);

            // Calculations for variable 'b'
            b = Math.Cos(Math.Atan(1 / z));
            b1 = Math.Pow(b, 2);

            // Output result for variable 'b'
            Console.WriteLine("b) " + b1);
        }
    }

}