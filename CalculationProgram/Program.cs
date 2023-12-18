namespace CalculationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, x, y, z;
            double ch, zn;
            Console.WriteLine("x:");
            x = float.Parse(Console.ReadLine());
            Console.WriteLine("y:");
            y = float.Parse(Console.ReadLine());
            Console.WriteLine("z:");
            z = float.Parse(Console.ReadLine());
            zn = 1 - x * Math.Abs(y - Math.Tan(z));
            ch = x * Math.Pow(x, y) + (1 / Math.E) * Math.Pow(Math.E, y);
            a = ch / zn;
            Console.WriteLine("a) " + a);
            b = 1 + Math.Abs(y - x) + (Math.Pow(Math.Abs(y - x), 2) / z) + (Math.Pow(Math.Abs(y - x), 3) / 2 * z);
            Console.WriteLine("b) " + b);

        }
    }
}