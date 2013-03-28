using System;
using System.Text;

class ExchangeThreeBits
{
    // Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

    //Exchange two values (represent bits) without temp variable
    static Tuple<int, int> ChangeBits(int bit1, int bit2)
    {
        bit1 = bit1 ^ bit2;
        bit2 = bit1 ^ bit2;
        bit1 = bit1 ^ bit2;
        return new Tuple<int, int>(bit1, bit2);
    }

    // Console input management
    static uint EnterData(string message)
    {
        bool correctUInteger = false;
        uint enteredValue = 0;
        do
        {
            Console.Write(message);
            correctUInteger = uint.TryParse(Console.ReadLine(), out enteredValue);
            if (correctUInteger)
            { correctUInteger = true; }
            else
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        } while (!correctUInteger);
        Console.Clear();
        return enteredValue;
    }

    static void Main()
    {
        uint numberInitialInt = 2147483392u;
        StringBuilder numberChangedStr = new StringBuilder();
        Tuple<int, int> exchangedBits;
        Console.Title = "Exchange 2 groups of 3 bits preselected in a given number";
        numberInitialInt = EnterData("Enter unsigned integer to swap folowing bits [3..5] vs. [24..26]: ");
        numberChangedStr.Append(Convert.ToString(numberInitialInt, 2).PadLeft(32, '0'));
        for (int i = 5; i <= 7; i++)
        {
            exchangedBits = ChangeBits(numberChangedStr[i], numberChangedStr[21 + i]);
            numberChangedStr.Remove(i, 1).Insert(i, (char)exchangedBits.Item1);
            numberChangedStr.Remove(21 + i, 1).Insert(21 + i, (char)exchangedBits.Item2);
        }
        Console.WriteLine("Original binary number {0}", Convert.ToString(numberInitialInt, 2).PadLeft(32, '0'));
        Console.Write("Modified binary number ");
        for (int i = 0; i <= 31; i++)
        {
            switch (i)
            {
                case 5:
                case 6:
                case 7:
                case 26:
                case 27:
                case 28:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(numberChangedStr[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default: Console.Write(numberChangedStr[i]); break;
            }
        }
        Console.ReadKey();
    }
}