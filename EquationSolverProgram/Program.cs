namespace EquationSolverProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, m;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("If you want to solve equation a), enter 1");
            Console.WriteLine("If you want to solve equation b), enter 2");
            Console.WriteLine("If you want to solve equation c), enter 3");
            Console.WriteLine("If you want to solve equation d), enter 4");
            Console.Write("m = ");
            m = Convert.ToDouble(Console.ReadLine());

            if (m == 1)
            {
                if (x < 2 && x >= -2)
                    y = Math.Pow(x, 2);
                else
                    y = 4;
                Console.WriteLine("y = " + y.ToString());
            }
            else if (m == 2)
            {
                if (x <= 2)
                    y = Math.Pow(x, 2) + 4 * x + 5;
                else
                    y = 1 / (Math.Pow(x, 2) + 4 * x + 5);
                Console.WriteLine("y = " + y.ToString());
            }
            else if (m == 3)
            {
                if (x <= 0)
                    y = 0.0;
                else if (x <= 1)
                    y = x;
                else
                    y = Math.Pow(x, 4.0);
                Console.WriteLine("y = " + y.ToString());
            }
            else if (m == 4)
            {
                if (x <= 0)
                    y = 0.0;
                else if (x <= 1 && x > 0)
                    y = Math.Pow(x, 2) - x;
                else
                    y = Math.Pow(x, 2.0) - Math.Sin(Math.PI * Math.Pow(x, 2));
                Console.WriteLine("y = " + y.ToString());
            }
            else
            {
                Console.Write("Invalid value for m");
            }
        }
    }
}