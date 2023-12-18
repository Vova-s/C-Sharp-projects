namespace VariableUpdaterProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, minElement;
            int minIndex;

            Console.Write("x = ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("y = ");
            y = Convert.ToDouble(Console.ReadLine());

            Console.Write("z = ");
            z = Convert.ToDouble(Console.ReadLine());

            if (x + y + z < 1.0)
            {
                minIndex = 1;
                minElement = x;

                if (y < minElement)
                {
                    minIndex = 2;
                    minElement = y;
                }

                if (z < minElement)
                {
                    minIndex = 3;
                    minElement = z;
                }

                switch (minIndex)
                {
                    case 2:
                        y = (x + z) / 2;
                        break;
                    case 3:
                        z = (x + y) / 2;
                        break;
                    default:
                        x = (y + z) / 2;
                        break;
                }
            }
            else
            {
                bool isXLessThanY = x < y;

                switch (isXLessThanY)
                {
                    case true:
                        x = y + z;
                        break;
                    default:
                        y = x + z;
                        break;
                }
            }

            Console.WriteLine("New x, y, and z:");
            Console.WriteLine("x = {1}; y = {2}; z = {0}", z, x, y);
        }
    }
}