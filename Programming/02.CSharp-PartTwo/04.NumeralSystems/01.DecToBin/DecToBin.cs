using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Task: "1. Write a program to convert decimal numbers to their binary representation."
/// 
/// Note: The method for converting could operate with any type of numbers (sbyte, byte, short, int,...)
///       In demo code int is used, but you can change  the code to see for other types.
/// </summary>
public class DecToBin
{
    public static void Main()
    {
        Console.Title = "Convert Decimal numbers to Binary";
        int numberToConvert = EnterData("Enter decimal number: ");
        Console.WriteLine("Decimal number {0} presented in Binary system is: ", numberToConvert);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ConvertDecToBin(numberToConvert));
        Console.ReadKey();
    }

    // Converts Dcimal number to binary representation
    private static string ConvertDecToBin<T>(T numberToConvert)
    {
        dynamic result = numberToConvert;
        bool isNegative = false;
        int size = 0;

        // Check the type of number and set the size in bits
        // Additionally if number is negative, finds the bin representation
        // without sign bit (MSB)
        if (result is byte || result is sbyte)
        {
            size = 8;
            if (result is sbyte && result < 0)
            {
                result = sbyte.MaxValue - (result * -1) + 1;
                isNegative = true;
            }
        }
        else if (result is ushort || result is short)
        {
            size = 16;
            if (result is short && result < 0)
            {
                result = short.MaxValue - (result * -1) + 1;
                isNegative = true;
            }
        }
        else if (result is uint || result is int)
        {
            size = 32;
            if (result is int && result < 0)
            {
                result = int.MaxValue - (result * -1) + 1;
                isNegative = true;
            }
        }
        else if (result is ulong || result is long)
        {
            size = 64;
            if (result is long && result < 0)
            {
                result = long.MaxValue - (result * -1) + 1;
                isNegative = true;
            }
        }

        // Discover bits in the number and store them in Stack
        const int NumeralBase = 2;
        Stack<long> resultNumber = new Stack<long>();
        while (result > 0)
        {
            resultNumber.Push(result % NumeralBase);
            result /= NumeralBase;
        }

        // Construct the binary representation of number
        StringBuilder binNumber = new StringBuilder();
        int stackSize = resultNumber.Count;
        for (int i = 0; i < stackSize; i++)
        {
            binNumber.Append(resultNumber.Pop());
        }

        // Finalizing binary representation by including negative bit if applicable 
        // and padding as well up to the byte size of type of the number (8-bit, 16-bit, 32-bit, 64-bit)
        string binRepresentation = default(string);
        if (isNegative)
        {
            binRepresentation = "1" + binNumber.ToString().PadLeft(size - 1, '0');
        }
        else
        {
            binRepresentation = binNumber.ToString().PadLeft(size, '0');
        }

        return binRepresentation;
    }

    // Handles user input of single integer value
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}