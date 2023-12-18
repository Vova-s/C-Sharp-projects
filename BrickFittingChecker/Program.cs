namespace BrickFittingChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            double brickHeight, brickLength, brickWidth, openingLength, openingWidth;

            Console.Write("Brick height:");
            brickHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Brick length:");
            brickLength = Convert.ToDouble(Console.ReadLine());

            Console.Write("Brick width:");
            brickWidth = Convert.ToDouble(Console.ReadLine());

            Console.Write("Length of the rectangular opening:");
            openingLength = Convert.ToDouble(Console.ReadLine());

            Console.Write("Width of the rectangular opening:");
            openingWidth = Convert.ToDouble(Console.ReadLine());

            if (brickLength < openingLength && brickWidth < openingWidth)
            {
                Console.Write("The brick will fit");
            }
            else
            {
                Console.Write("The brick is too large");
            }
        }
    }
}