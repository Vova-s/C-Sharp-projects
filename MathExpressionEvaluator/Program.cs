namespace MathExpressionEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, x, y, z, b1, b2;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());

            Console.Write("z = ");
            z = Convert.ToDouble(Console.ReadLine());

            a = Math.Pow(y, x) + Math.Pow((Math.Abs(x) - Math.Abs(y)), 1.0 / 3.0);
            Console.WriteLine("a) " + a);

            b = x - Math.Pow(y, 2) / (x + z);

            if (x + z == 0 || b == 0)
            {
                Console.Write("b) The denominator cannot be zero");
            }
            else
            {
                b1 = x + Math.Pow(y, 3) / b;
                Console.WriteLine("b) " + b1);
            }
        }
    }
}