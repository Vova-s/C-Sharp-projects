namespace MathCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, x, y, z;
            double ch, zn;
            Console.Write("x: ");
            x = float.Parse(Console.ReadLine());
            Console.Write("y: ");
            y = float.Parse(Console.ReadLine());
            Console.Write("z: ");
            z = float.Parse(Console.ReadLine());
            a = Math.Pow(2, -x) * Math.Sqrt(x + Math.Sqrt(y));
            Console.WriteLine("a) " + a);
            b = Math.Pow(Math.Pow(Math.E, x / Math.Sin(z)) - 1, 1 / 4.0);
            Console.WriteLine("b) " + b);
        }
    }
}