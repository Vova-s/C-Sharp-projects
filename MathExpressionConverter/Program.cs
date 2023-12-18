using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace MathExpressionConverter
{
    class LinkedListNode<T>
    {
        public T Data;

        public LinkedListNode<T> Next;

        public LinkedListNode(T data, LinkedListNode<T> next = null)
        {
            Data = data;
            Next = next;
        }
    }
    class Stack<T>
    {

        private LinkedListNode<T> top;
        private bool empty = true;
        private int capacity;
        static int size;


        public void Push(T value)
        {
            top = new LinkedListNode<T>(value, top);
            capacity++;
        }

        public T Pop()
        {
            T value = top.Data;

            top = top.Next;
            capacity--;

            return value;
        }
        public int Size()
        {
            size = capacity;
            return size;
        }
        public bool IsEmpty()
        {
            if (top == null)
            {
                empty = false;
            }

            return empty;
        }

        public T Peek()
        {
            if (capacity == 0)
            {
                return default(T);
            }
            else
                return top.Data;
        }

        public void PrintStack()
        {
            LinkedListNode<T> node = top;
            IsEmpty();
            Size();
            if (!empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Stack is Empty");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int i = size;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Stack Items: ");
                Console.ForegroundColor = ConsoleColor.White;
                while (node != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i}.{node.Data}");
                    node = node.Next;
                    i--;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int t;
            WriteLine("************************** Converter of mathematical expressions in reverse Polish notation ***************************************");
            Write("1.Write your own mathematical expressions.\n2.Create control example to show how it work.\nYour choose : ");
            while (!int.TryParse(ReadLine(), out t) || (t <= 0) || (t > 2))
            {
                Write("choose between 1 and 2 and try one more time : ");
            }
            if (t == 1)
            {
                Console.Clear();
                UserExample();
            }
            else
            {
                Console.Clear();
                Example();
            }
        }
        static void Example()
        {
            string example = "345*2*n-53+(3/n*2-5*6)/2";

            ConverterToPLNotation(example);
        }

        private static void UserExample()
        {
            bool Continue = true;

            string example = "";

            while (Continue)
            {
                Console.WriteLine("Write your mathematical example and press Enter to see it in reverse Polish notation: ");

                example = Console.ReadLine();

                for (int i = 0; i < example.Length; i++)
                {
                    if ((int)example[i] == 32 || ((int)example[i] >= 40 && (int)example[i] < 44) || (int)example[i] == 45 || ((int)example[i] >= 47 && (int)example[i] < 58) || ((int)example[i] >= 65 && (int)example[i] <= 90) || ((int)example[i] >= 97 && (int)example[i] <= 122))
                    {
                        if (i > 0 && (((int)example[i] > 64 && (int)example[i] < 91 || (int)example[i] > 96 && (int)example[i] < 123) && ((int)example[i - 1] > 64 && (int)example[i - 1] < 91 || (int)example[i - 1] > 96 && (int)example[i - 1] < 123)))
                        {
                            Console.WriteLine("There must be an arithmetic operation between Latin letters!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && ((int)example[i] == 40 && ((int)example[i - 1] == 32 || ((int)example[i - 1] >= 65 && (int)example[i - 1] <= 90) || ((int)example[i - 1] >= 97 && (int)example[i - 1] <= 122))))
                        {
                            Console.WriteLine("In front \"(\" must be a sign of the arithmetic operation!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && ((int)example[i] >= 65 && (int)example[i] <= 90 || (int)example[i] >= 97 && (int)example[i] <= 122) && ((int)example[i - 1] >= 48 && (int)example[i - 1] <= 57))
                        {
                            Console.WriteLine("Between the letter and number must be a sign of the arithmetic operation!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && ((int)example[i] == 48 && (int)example[i - 1] == 47))
                        {
                            Console.WriteLine("Сannot be divided by zero!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i == 0 && ((int)example[i] == 42 || (int)example[i] == 43 || (int)example[i] == 45 || (int)example[i] == 47))
                        {
                            Console.WriteLine("Arithmetic operation cannot be the first sign!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && (((int)example[i] >= 48 && (int)example[i] <= 57) || ((int)example[i] >= 65 && (int)example[i] <= 90) || ((int)example[i] >= 97 && (int)example[i] <= 122)) && (int)example[i - 1] == 41)
                        {
                            Console.WriteLine("After \")\" must be either the end of the expression or an arithmetic sign!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i == example.Length - 1 && ((int)example[i] == 42 || (int)example[i] == 43 || (int)example[i] == 45 || (int)example[i] == 47))
                        {
                            Console.WriteLine("A mathematical expression cannot end in an arithmetic sign!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && ((int)example[i] == 42 || (int)example[i] == 43 || (int)example[i] == 45 || (int)example[i] == 47) && ((int)example[i - 1] == 42 || (int)example[i - 1] == 43 || (int)example[i - 1] == 45 || (int)example[i - 1] == 47))
                        {
                            Console.WriteLine("A mathematical expression cannot have two arithmetic signs in a row!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (i > 0 && (int)example[i] == 41 && (int)example[i - 1] == 40)
                        {
                            Console.WriteLine("Fill in the space between the brackets!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if ((i > 0 && (int)example[i] == 40 && (int)example[i - 1] == 41) || (i == 0 && (int)example[i] == 41))
                        {
                            Console.WriteLine("Invalid input character!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input character!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }


                    if (i == example.Length - 1)
                    {
                        Continue = false;
                    }
                }
            }

            ConverterToPLNotation(example);
        }

        static void ConverterToPLNotation(string example)
        {

            List<string> PolishNotation = new List<string>();

            Stack<string> stack = new Stack<string>();

            Console.Clear();

            Console.WriteLine("Your expression: " + example + "\n");


            for (int i = 0; i < example.Length; i++)
            {
                if (example[i].ToString() != "*" && example[i].ToString() != "/" && example[i].ToString() != "+" && example[i].ToString() != "-" && example[i].ToString() != "(" && example[i].ToString() != ")" && example[i].ToString() != " ")
                {
                    if (Char.IsDigit(example[i]))
                    {
                        while (Char.IsDigit(example[i]))
                        {
                            PolishNotation.Add(example[i].ToString());
                            if (i != example.Length - 1)
                                i++;
                            else
                            {
                                i++;
                                break;
                            }
                        }
                        i--;
                        PolishNotation.Add(" ");
                    }
                    else
                    {
                        PolishNotation.Add(example[i].ToString());
                        PolishNotation.Add(" ");
                    }
                }
                else if (example[i].ToString() != " " && example[i].ToString() != ")")
                {
                    stack.Push(example[i].ToString());

                    stack.PrintStack();
                }
                else if (example[i].ToString() == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        PolishNotation.Add(stack.Pop());

                        PolishNotation.Add(" ");

                        stack.PrintStack();
                    }
                    stack.Pop();

                    stack.PrintStack();
                }
            }

            while (stack.Peek() != null)
            {
                PolishNotation.Add(stack.Pop());

                PolishNotation.Add(" ");

                stack.PrintStack();
            }

            Console.WriteLine("\nReverse Polish notation:");

            foreach (var item in PolishNotation)
            {
                Console.Write(item);
            }

        }
    }
}