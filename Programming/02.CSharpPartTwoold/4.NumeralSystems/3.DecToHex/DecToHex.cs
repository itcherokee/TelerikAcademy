using System;
using System.Collections.Generic;

public class DecToHex
{
    // Write a program to convert decimal numbers to their hexadecimal representation.

    public static void Main()
    {
        Console.Title = "Convert Decimal number to Hexadecimal";
        bool noError = true;
        int numeralSystemBase = 16;
        int numberToConvert = 0;
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        do
        {
            noError = true;
            Console.Write("Enter the decimal number: ");
            try
            {
                numberToConvert = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Try again <press Enter>...");
                Console.ReadLine();
                noError = false;
                Console.Clear();
            }
        }
        while (!noError);
        Console.Write("Decimal number {0} presented in Hexadecimal system is: 0x", numberToConvert);
        Stack<int> resultNumber = new Stack<int>();
        while (numberToConvert > 0)
        {
            resultNumber.Push(numberToConvert % numeralSystemBase);
            numberToConvert /= numeralSystemBase;
        }

        int sizeOfSteak = resultNumber.Count;
        for (int i = 0; i < sizeOfSteak; i++)
        {
            Console.Write(hexNumbers[resultNumber.Pop()]);
        }

        Console.WriteLine();
    }
}
