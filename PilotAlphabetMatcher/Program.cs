namespace PilotAlphabetMatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputted;
            string word;
            string[] pilot_alpha;
            pilot_alpha = new string[26] { "Alfa", "Bravo", "Charlie", "Delta", "Echo",
            "Foxtrot", "Golf", "Hotel", "India", "Juliett",
            "Kilo", "Lima", "Mike", "November", "Oscar",
            "Papa", "Quebec", "Romeo", "Sierra", "Tango",
            "Uniform", "Victor", "Whiskey", "Xray", "Yankee", "Zulu" };

            Console.Write("Input letters: ");
            inputted = Console.ReadLine().ToLower();

            if (inputted != null && inputted.Trim() != "")
            {
                for (int i = 0; i < inputted.Length; i++)
                {
                    for (int j = 0; j < pilot_alpha.Length; j++)
                    {
                        word = pilot_alpha[j].ToLower();

                        if (word[0] == inputted[i])
                        {
                            Console.WriteLine(word);
                        }
                    }
                }
            }

            else
            {
                Console.WriteLine("Input is null or empty. Please provide valid input.");
            }
        }
    }
}