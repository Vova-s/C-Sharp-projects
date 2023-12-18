namespace TrigonometricPowerCalculations
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
            ch = 1 + y + Math.Pow(y, 3) / 3.0 + Math.Pow(y, 5) / 5.0; ;
            a = Math.Pow(Math.Abs(Math.Tan(x) + Math.Tan(y)), ch);
            Console.WriteLine("a) " + a);
            b = Math.PI / 2 - Math.Atan(x) + Math.Tan(z);
            Console.WriteLine("b) " + b);
        }
    }
}