using System;
using static System.Console;

namespace CezarCipherProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Write("input text to encode : "); string text = ReadLine().ToLower();
            int key = 6;
            int value = 2;
            string enc = encryptingCezar(text, key, value);
            WriteLine("encrypted text is : " + enc);
            string decoded = decryptingCezar(enc, key);
            WriteLine("decrypted text is : " + decoded);
        }
        public static string encryptingCezar(string text, int key, int value)
        {
            string encodedtext = " ";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabet1 = alphabet + alphabet.ToLower();
            for (int i = 0; i < text.Length; i += 2)
            {
                char letter = text[i];
                int index = alphabet1.IndexOf(letter);
                if (index < 0)
                {
                    encodedtext += letter.ToString();
                }
                int codeIndex = (index + key) % alphabet1.Length;
                encodedtext += alphabet1[codeIndex];
            }
            for (int i = 1; i < text.Length; i += 2)
            {
                char letter = text[i];
                int index = alphabet1.IndexOf(letter);
                if (index < 0)
                {
                    encodedtext += letter.ToString();
                }
                int codeIndex = (index - value) % alphabet1.Length;
                encodedtext += alphabet1[codeIndex];
            }
            return encodedtext;

        }
        public static string decryptingCezar(string encodedtext, int key)
        {
            string decodedtext = " ";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabet1 = alphabet + alphabet.ToLower();
            for (int i = 0; i < encodedtext.Length; i++)
            {
                char letter = encodedtext[i];
                int index = alphabet1.IndexOf(letter);
                if (index < 0)
                {

                    decodedtext += letter.ToString();
                }
                else
                {
                    int codeIndex = (alphabet1.Length + index - key) % alphabet1.Length;
                    decodedtext += alphabet1[codeIndex];
                }
            }
            return decodedtext;


        }

    }
}