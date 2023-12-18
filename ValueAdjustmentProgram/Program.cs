namespace ValueAdjustmentProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());

            if (x < 0 && y < 0)
            {
                x = Math.Abs(x);
                y = Math.Abs(y);
            }
            else if ((x < 0 && y >= 0) || (x >= 0) && (y < 0))
            {
                x += 0.5;
                y += 0.5;
            }
            else if ((x >= 0) && (y >= 0) && ((x < 0.5) || (x > 2))
                && ((y < 0.5) || (y > 2)))
            {
                x /= 10;
                y /= 10;
            }

            Console.WriteLine("New x and y:");
            Console.WriteLine($"x = {x}\ny = {y}");
        }
    }
}