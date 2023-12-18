namespace IntervalCheckProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());
            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());
            Console.Write("z = ");
            z = Convert.ToDouble(Console.ReadLine());

            if (x < 3 && x > 1)
            {
                Console.WriteLine("x belongs to the interval");
            }
            else
            {
                Console.WriteLine("x does not belong to the interval");
            }

            if (y < 3 && y > 1)
            {
                Console.WriteLine("y belongs to the interval");
            }
            else
            {
                Console.WriteLine("y does not belong to the interval");
            }

            if (z < 3 && z > 1)
            {
                Console.WriteLine("z belongs to the interval");
            }
            else
            {
                Console.WriteLine("z does not belong to the interval");
            }
        }
    }
}