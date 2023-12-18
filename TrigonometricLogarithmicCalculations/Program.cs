namespace TrigonometricLogarithmicCalculations
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
            a = 5 * (1 / Math.Tan(Math.PI * x / 180)) - 1.0 / 4 * (Math.PI / 2 - Math.Atan(Math.PI * y / 180));
            Console.WriteLine("a) " + a);
            zn = Math.Pow(Math.Abs(x - y), 2) - Math.Pow(z, 2);
            ch = Math.Log(x) + Math.Abs(x - y) + Math.Pow(x, 2);
            b = ch / zn;
            Console.WriteLine("b) " + b);
        }
    }
}