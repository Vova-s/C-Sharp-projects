namespace HuffmanCodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Console.WriteLine("Enter a string:");
            input = Console.ReadLine();
            Console.WriteLine("Entered string: " + input);

            // Copy the string for displaying without repetitions
            string uniqueCharacters = input;
            List<string> symbols = new List<string>();

            // Display the string without repetitions
            uniqueCharacters = new string(uniqueCharacters.Distinct().ToArray());
            for (int i = 0; i < uniqueCharacters.Length; i++)
                symbols.Add(uniqueCharacters[i].ToString());
            Console.WriteLine("All unique characters: " + uniqueCharacters);
            List<int> counter = new List<int>(); // counter
            List<string> sortedCharacters = new List<string>(); // string for sorting
            Console.WriteLine("Character frequencies:");

            // Count repeated characters
            for (int i = 0; i < input.Length; i++)
                counter.Add(0);
            for (int i = 0; i < input.Length; i++)
                for (int j = 0; j < uniqueCharacters.Length; j++)
                    if (input[i] == uniqueCharacters[j])
                        counter[j] += 1;
            for (int i = 0; i < input.Length; i++)
                if (counter[i] != 0)
                    Console.WriteLine(uniqueCharacters[i] + ":" + counter[i]);

            Console.WriteLine("Sorting begins:");

            Dictionary<string, string> codeDictionary = new Dictionary<string, string>();

            for (int i = 0; i < symbols.Count; i++)
            {
                codeDictionary.Add(symbols[i], null);
            }

            // Sorting for future Huffman Coding
            while (symbols.Count != 1)
            {
                (symbols, counter, sortedCharacters) = SortCharacters(symbols, counter, sortedCharacters);
                (symbols, counter, codeDictionary) = SmallFrequency(symbols, counter, codeDictionary);
            }

            foreach (var pair in codeDictionary)
            {
                Console.WriteLine($"Key: {pair.Key}. Value: {pair.Value}");
            }

            Console.WriteLine("\nHuffman code:\n");
            for (int i = 0; i < input.Length; i++)
            {
                string characterCode = input[i].ToString();
                Console.Write(codeDictionary[characterCode]);
            }
        }

        static (List<string>, List<int>, List<string>) SortCharacters(List<string> symbols, List<int> counter, List<string> sortedCharacters)
        {
            int temp = 0;

            List<string> garbage = new List<string>(); // string for garbage
            for (int i = 0; i < symbols.Count; i++)
            {
                garbage.Add("");
            }
            for (int i = 0; i < symbols.Count - 1; i++)
            {
                for (int j = 0; j < symbols.Count - 1; j++)
                {
                    if (counter[j] < counter[j + 1])
                    {
                        temp = counter[j];
                        garbage[j] = symbols[j];
                        counter[j] = counter[j + 1];
                        symbols[j] = symbols[j + 1];
                        counter[j + 1] = temp;
                        symbols[j + 1] = garbage[j];
                    }
                }
            }

            for (int i = 0; i < symbols.Count; i++)
                if (counter[i] != 0)
                    Console.WriteLine(symbols[i] + ":" + counter[i]);
            Console.WriteLine("Sorting finished");
            return (symbols, counter, sortedCharacters);
        }

        static (List<string>, List<int>, Dictionary<string, string>) SmallFrequency(List<string> symbols, List<int> counter, Dictionary<string, string> codeDictionary)
        {
            int index = symbols.Count;
            string str = symbols[index - 1];
            for (int i = 0; i < symbols[index - 1].Length; i++)
            {
                codeDictionary[str[i].ToString()] = "0" + codeDictionary[str[i].ToString()];
            }
            str = symbols[index - 2];
            for (int i = 0; i < symbols[index - 2].Length; i++)
            {
                codeDictionary[str[i].ToString()] = "1" + codeDictionary[str[i].ToString()];
            }
            symbols[index - 2] = symbols[index - 1] + symbols[index - 2];
            symbols.RemoveAt(index - 1);
            counter[index - 2] = counter[index - 2] + counter[index - 1];
            counter.RemoveAt(index - 1);
            return (symbols, counter, codeDictionary);
        }
    }
}
