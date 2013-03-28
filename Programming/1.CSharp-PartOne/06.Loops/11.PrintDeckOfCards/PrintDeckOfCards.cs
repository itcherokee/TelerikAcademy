using System;

class PrintDeckOfCards
{
    // Write a program that prints all possible cards from a standard deck 
    // of 52 cards (without jokers). The cards should be printed with their English names. 
    // Use nested for loops and switch-case.

    static ConsoleColor[] deckColor = new ConsoleColor[4] { ConsoleColor.Black, ConsoleColor.Red, ConsoleColor.Red, ConsoleColor.Black };
    static char[] symbol = new char[4] { '\u2660', '\u2665', '\u2666', '\u2663' };
    static string[] suits = new string[4] { "spades", "hearts", "diamonds", "clubs" };
    static string[,] cards = new string[13, 2] { { "Two", "2" }, { "Three", "3" }, { "Four", "4" }, { "Five", "5" }, { "Six", "6" }, { "Seven", "7" }, 
                            { "Eight", "8" }, { "Nine", "9" }, { "Ten", "10" }, { "Jack", "J" }, { "Queen", "Q" }, { "King", "K" }, { "Ace", "A" } };

    static void Main()
    {
        Console.Title = "Print cards from standard deck";
        Console.SetWindowSize(100, 15);
        string formatString = "";
        for (int k = 0; k <= 12; k++)
        {
            int offset = 0;
            for (int i = 0; i <= 3; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                formatString = "{0,2}{1,-2}";
                PrintOnScreenSymbol(offset, k, i, deckColor[i], formatString, cards[k, 1], symbol[i]);
                offset += 25;
                formatString =" {0} of {1}";
                PrintOnScreenText(k, formatString, cards[k, 0], suits[i]);
            }
        }
        Console.WriteLine();
        Console.ReadKey();
    }

    private static void PrintOnScreenSymbol(int offset, int row, int deck, ConsoleColor color, 
                                           string formating, string card, char symbol)
    {
        Console.ForegroundColor = color;
        Console.BackgroundColor = ConsoleColor.White;
        Console.SetCursorPosition(offset, row);
        Console.Write(formating, card, symbol);
    }

    private static void PrintOnScreenText(int row, string formating, string card, string suit)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(formating, card, suit);
    }
}
