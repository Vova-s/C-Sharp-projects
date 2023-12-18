namespace TriangleTypeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.Write("a = ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("b = ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("c = ");
            c = Convert.ToDouble(Console.ReadLine());

            if (a <= 0 || b <= 0 || c <= 0)
            {
                Console.Write("These sides do not form a triangle");
            }
            else
            {
                if ((a + b) < c && (a + c) < b && (c + b) < a)
                {
                    Console.Write("A triangle cannot be formed from these segments");
                }
                else if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) == c || Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2)) == b || Math.Sqrt(Math.Pow(c, 2) + Math.Pow(b, 2)) == a)
                {
                    Console.Write("This is a right-angled triangle");
                }
                else if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) > c || Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2)) > b || Math.Sqrt(Math.Pow(c, 2) + Math.Pow(b, 2)) > a)
                {
                    Console.Write("This is an acute-angled triangle");
                }
                else if (Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2)) < c || Math.Sqrt(Math.Pow(a, 2) + Math.Pow(c, 2)) < b || Math.Sqrt(Math.Pow(c, 2) + Math.Pow(b, 2)) < a)
                {
                    Console.Write("This is an obtuse-angled triangle");
                }
            }
        }
    }
}