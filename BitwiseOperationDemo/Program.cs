using System;
using static System.Console;

namespace BitwiseOperationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int x = rnd.Next(50, 151);
            int y = rnd.Next(50, 151);
            int z = rnd.Next(50, 151);

            int rez = (((y & x) | y) | ((((((x & z) ^ y) ^ x) ^ z) | y) | x));

            int action_1 = y & x;
            WriteLine($"action_1 = {y}&{x};  {Convert.ToString(y, 2)}&{Convert.ToString(x, 2)} = {action_1}");
            int action_2 = x & z;
            WriteLine($"action_2 = {x}&{z};  {Convert.ToString(x, 2)}&{Convert.ToString(z, 2)} = {action_2}");
            int action_3 = action_2 ^ y;
            WriteLine($"action_3 = {action_2}^{y};  {Convert.ToString(action_2, 2)}^{Convert.ToString(y, 2)} = {action_3}");
            int action_4 = action_3 ^ x;
            WriteLine($"action_4 = {action_3}^{x};  {Convert.ToString(action_3, 2)}^{Convert.ToString(x, 2)} = {action_4}");
            int action_5 = action_4 ^ z;
            WriteLine($"action_5 = {action_4}^{z};  {Convert.ToString(action_4, 2)}^{Convert.ToString(z, 2)} = {action_5}");
            int action_6 = action_5 | y;
            WriteLine($"action_6 = {action_5}|{y};  {Convert.ToString(action_5, 2)}|{Convert.ToString(y, 2)} = {action_6}");
            int action_7 = action_6 | x;
            WriteLine($"action_7 = {action_6}|{x};  {Convert.ToString(action_6, 2)}|{Convert.ToString(x, 2)} = {action_7}");
            int action_8 = action_1 | y;
            WriteLine($"action_8 = {action_1}&{y};  {Convert.ToString(action_1, 2)}&{Convert.ToString(y, 2)} = {action_8}");
            int action_9 = action_7 | action_1;
            WriteLine($"action_9 = {action_1}&{action_7};  {Convert.ToString(action_1, 2)}&{Convert.ToString(action_7, 2)} = {action_9}");

            WriteLine("rez  : " + rez);
        }
    }
}