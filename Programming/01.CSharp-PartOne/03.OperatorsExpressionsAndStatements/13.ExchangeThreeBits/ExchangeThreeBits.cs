using System;
using System.Text;

/// <summary>
/// Task: "13.Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer."
/// </summary>
public class ExchangeThreeBits
{
    public static void Main()
    {
        uint initialBits = 2147483392u;
        StringBuilder resultBits = new StringBuilder();
        Tuple<int, int> swapedBits;
        Console.Title = "Exchange 2 groups of 3 bits preselected in a given number";
        initialBits = EnterData("Enter unsigned integer to swap folowing bits [3..5] vs. [24..26]: ");
        resultBits.Append(Convert.ToString(initialBits, 2).PadLeft(32, '0'));
        for (int i = 5; i <= 7; i++)
        {
            swapedBits = SwapBits(resultBits[i], resultBits[21 + i]);
            resultBits.Remove(i, 1).Insert(i, (char)swapedBits.Item1);
            resultBits.Remove(21 + i, 1).Insert(21 + i, (char)swapedBits.Item2);
        }

        Console.WriteLine("Original binary number {0}", Convert.ToString(initialBits, 2).PadLeft(32, '0'));
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
                    Console.Write(resultBits[i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default: 
                    Console.Write(resultBits[i]); 
                    break;
            }
        }

        Console.ReadKey();
    }

    private static Tuple<int, int> SwapBits(int bitOne, int bitTwo)
    {
        bitOne = bitOne ^ bitTwo;
        bitTwo = bitOne ^ bitTwo;
        bitOne = bitOne ^ bitTwo;
        return new Tuple<int, int>(bitOne, bitTwo);
    }

    private static uint EnterData(string message)
    {
        bool isValidInput = false;
        uint enteredValue = 0;
        do
        {
            Console.Write(message);
            isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
            if (isValidInput)
            { 
                isValidInput = true; 
            }
            else
            {
                Console.WriteLine("You have entered incorrect number or symbol(s). Try again (press key).");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);
        
        Console.Clear();
        return enteredValue;
    }
}