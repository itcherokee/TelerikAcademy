using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Task: "3. Write a program to convert decimal numbers to their hexadecimal representation."
/// </summary>
public class DecToHex
{
    public static void Main()
    {
        Console.Title = "Convert Decimal number to Hexadecimal";
        var numberToConvert = EnterData("Enter the decimal number (positive): ");
        Console.Write("Decimal number {0} presented in Hexadecimal system is: ", numberToConvert);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ConvertDecToHex(numberToConvert));
        Console.WriteLine();
        Console.ReadKey();
    }

    private static string ConvertDecToHex(int numberToConvert)
    {
        var hexNumbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        long number = numberToConvert;

        var resultNumber = new Stack<long>();
        while (number > 0)
        {
            resultNumber.Push(number % 16);
            number /= 16;
        }

        var sizeOfSteak = resultNumber.Count;
        StringBuilder result = new StringBuilder();
        for (var i = 0; i < sizeOfSteak; i++)
        {
            result.Append(hexNumbers[resultNumber.Pop()]);
        }

        result.Insert(0, new string('0', 8 - result.Length));
        result.Insert(0, "0x");
        return result.ToString();
    }

    // Handles user input of single integer value
    private static int EnterData(string message)
    {
        var isValidInput = default(bool);
        var enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || enteredValue < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}
