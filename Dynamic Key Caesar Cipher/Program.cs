namespace Dynamic_Key_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a random number generator
            Random rnd = new Random();

            // Get user input
            Console.Write("Enter text to encode: ");
            string text = Console.ReadLine().ToLower();

            // Generate a random key between 1 and 20
            int key = rnd.Next(1, 20);

            // Encrypt the text using the dynamic key Caesar cipher
            string encryptedText = EncryptWithDynamicKey(text, key);

            // Display the encrypted text
            Console.WriteLine("Encrypted text: " + encryptedText);

            // Decrypt the text using the dynamic key Caesar cipher
            string decryptedText = DecryptWithDynamicKey(encryptedText, key);

            // Display the decrypted text
            Console.WriteLine("Decrypted text: " + decryptedText);
        }

        // Function to encrypt text using the dynamic key Caesar cipher
        public static string EncryptWithDynamicKey(string text, int key)
        {
            // Initialize an empty string to store the encoded text
            string encodedText = " ";

            // Define the alphabet
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Create a combined alphabet (uppercase and lowercase)
            string combinedAlphabet = alphabet + alphabet.ToLower();

            // Loop through each character in the input text
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];

                // Find the index of the letter in the combined alphabet
                int index = combinedAlphabet.IndexOf(letter);

                // Check if the character is not in the alphabet
                if (index < 0)
                {
                    // Append the character as is to the encoded text
                    encodedText += letter.ToString();
                }

                // Calculate the index of the encoded character with dynamic key
                int codeIndex = (index + key) % combinedAlphabet.Length;

                // Append the encoded character to the result
                encodedText += combinedAlphabet[codeIndex];
            }

            // Return the encoded text
            return encodedText;
        }

        // Function to decrypt text using the dynamic key Caesar cipher
        public static string DecryptWithDynamicKey(string encodedText, int key)
        {
            // Initialize an empty string to store the decoded text
            string decodedText = " ";

            // Define the alphabet
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Create a combined alphabet (uppercase and lowercase)
            string combinedAlphabet = alphabet + alphabet.ToLower();

            // Loop through each character in the encoded text
            for (int i = 0; i < encodedText.Length; i++)
            {
                char letter = encodedText[i];

                // Find the index of the letter in the combined alphabet
                int index = combinedAlphabet.IndexOf(letter);

                // Check if the character is not in the alphabet
                if (index < 0)
                {
                    // Append the character as is to the decoded text
                    decodedText += letter.ToString();
                }
                else
                {
                    // Calculate the index of the decoded character with dynamic key
                    int codeIndex = (combinedAlphabet.Length + index - key) % combinedAlphabet.Length;

                    // Append the decoded character to the result
                    decodedText += combinedAlphabet[codeIndex];
                }
            }

            // Return the decoded text
            return decodedText;
        }
    }
}