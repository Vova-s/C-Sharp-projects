namespace NumericProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, d;

            Console.Write("a = ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("b = ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("c = ");
            c = Convert.ToDouble(Console.ReadLine());

            Console.Write("d = ");
            d = Convert.ToDouble(Console.ReadLine());

            if (a <= b && b <= c && c <= d)
            {
                a = d;
                b = d;
                c = d;
                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
                Console.WriteLine("c: " + c);
                Console.WriteLine("d: " + d);
            }
            else if (a > b && b > c && c > d)
            {
                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
                Console.WriteLine("c: " + c);
                Console.WriteLine("d: " + d);
            }
            else
            {
                a = Math.Pow(a, 2);
                b = Math.Pow(b, 2);
                c = Math.Pow(c, 2);
                d = Math.Pow(d, 2);

                Console.WriteLine("a: " + a);
                Console.WriteLine("b: " + b);
                Console.WriteLine("c: " + c);
                Console.WriteLine("d: " + d);
            }
        }
    }
}