using System.Text;

namespace ConsoleChessBoardWithFactoryPattern
{
    internal class Program
    {

        static string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };
        static string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8" };
        static string[] correctPositions = { "R", "KN", "B", "Q", "K", "B", "KN", "R" };
        static FiguresFactory figureFactory = new FiguresFactory();
        private static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i < 8; i++)
            {
                ChessMan figure = figureFactory.GetFigure(correctPositions[i]);
                ChessMan pawn = figureFactory.GetFigure("P");
                ChessMan cr = figureFactory.GetFigure("c");
                figure.Location(i, 0, ConsoleColor.Red);
                pawn.Location(i, 1, ConsoleColor.Red);
                cr.Location(i, 2, ConsoleColor.Blue);
                cr.Location(i, 3, ConsoleColor.Blue);
                cr.Location(i, 4, ConsoleColor.Blue);
                cr.Location(i, 5, ConsoleColor.Blue);
                figure.Location(i, 7, ConsoleColor.White);
                pawn.Location(i, 6, ConsoleColor.White);
                Console.WriteLine();
                Console.WriteLine();
                Console.SetCursorPosition(i + 2, 8);
                Console.Write(letters[i]);
                Console.SetCursorPosition(0, i);
                Console.Write(numbers[i]);
            }
            Console.ReadKey();
        }

        public class ChessMan
        {

            protected int x, y;
            protected char symbol;
            protected ConsoleColor Color;
            public void Location(int x, int y, ConsoleColor color)
            {
                this.x = x;
                this.y = y;
                this.Color = color;
                Console.ForegroundColor = Color;
                Console.SetCursorPosition(x + 2, y);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }
        public class King : ChessMan
        {
            public King()
            {
                symbol = '♕';
            }
        }
        public class Queen : ChessMan
        {
            public Queen()
            {
                symbol = '♕';
            }
        }
        public class Knight : ChessMan
        {
            public Knight()
            {
                symbol = '♘';
            }
        }
        public class Rook : ChessMan
        {
            public Rook()
            {
                symbol = '♖';
            }
        }
        public class Bishop : ChessMan
        {
            public Bishop()
            {
                symbol = '♗';
            }
        }
        public class Pawn : ChessMan
        {
            public Pawn()
            {
                symbol = '♙';
            }
        }
        public class cross : ChessMan
        {
            public cross()
            {
                symbol = '-';
            }
        }
        public class FiguresFactory
        {
            private Dictionary<string, ChessMan> figures = new Dictionary<string, ChessMan>();
            public ChessMan GetFigure(string type)
            {
                ChessMan figure = null;
                if (figures.ContainsKey(type))
                {
                    figure = figures[type];
                }
                else

                {
                    switch (type)
                    {
                        case "K": figure = new King(); break;
                        case "Q": figure = new Queen(); break;
                        case "R": figure = new Rook(); break;
                        case "B": figure = new Bishop(); break;
                        case "KN": figure = new Knight(); break;
                        case "P": figure = new Pawn(); break;
                        case "c": figure = new cross(); break;
                    }
                    figures.Add(type, figure);
                }
                return figure;
            }
        }
    }
}