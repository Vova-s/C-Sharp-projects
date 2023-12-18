namespace TrigonometricExponentials
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
        zn = 1.0 / 2 - Math.Pow(Math.Sin(y * Math.PI / 180), 2);
        ch = 2 * Math.Cos(x * Math.PI / 180 - Math.PI / 6);
        a = ch / zn;
        Console.WriteLine("a)" + a);
        b = Math.Pow(Math.E, Math.Abs(x - y)) * Math.Pow(Math.Pow(Math.Tan(z * Math.PI / 180), 2) - 1, x);
        Console.WriteLine("b)" + b);

    }
}