using System;
using static System.Console;

namespace SimpleEncryptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("input word: "); string word = Convert.ToString(ReadLine());
            Write("input coding word: "); string codingWord = Convert.ToString(ReadLine());
            string coded = "";
            string decoded = "";
            for (int i = 0; i < codingWord.Length; i++)
            {
                int key = word[i] ^ codingWord[i];
                coded += ((char)key).ToString();

            }
            WriteLine(coded);

            for (int i = 0; i < codingWord.Length; i++)
            {
                int key = coded[i] ^ codingWord[i];
                decoded += ((char)key).ToString();

            }
            WriteLine(decoded);
        }
    }
}