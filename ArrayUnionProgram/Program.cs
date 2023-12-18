namespace ArrayUnionProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length1, length2;
            Console.WriteLine("Arrays can have different length. \n Enter the length of first array: ");
            int input_lengh = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the length of second array: ");
            int input_lengh_1 = int.Parse(Console.ReadLine());
            int[] input_array = new int[input_lengh];
            int[] input_array1 = new int[input_lengh_1];
            int c = 0;
            for (int i = 0; i < input_lengh; i++)
            {
                Console.Write("Enter a number of first array: ");
                input_array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < input_lengh_1; i++)
            {
                Console.Write("Enter a number of second array: ");
                input_array1[i] = int.Parse(Console.ReadLine());
            }

            int length3 = input_lengh + input_lengh_1;

            for (int i = 0; i < input_lengh; i++)
            {
                for (int j = 0; j < input_lengh_1; j++)
                {
                    if (input_array1[j] == input_array[i])
                    {
                        length3--;
                        break;
                    }

                }
            }
            int[] array_union = new int[length3];
            for (int i = 0; i < input_lengh; i++)
            {
                array_union[i] = input_array[i];
            }

            for (int i = 0; i < input_lengh_1; i++)
            {
                int count = 0;
                for (int j = 0; j < length3; j++)
                {
                    if (array_union[j] != input_array1[i])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == length3)
                {

                    array_union[input_lengh + c] = input_array1[i];
                    c++;
                }


            }
            foreach (var item in array_union)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}