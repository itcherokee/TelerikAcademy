using System;
using System.Collections.Generic;

public class DecToBin
{
    // Write a program to convert decimal numbers to their binary representation.

    public static void Main()
    {
        Console.Title = "Convert Decimal numbers to Binary";
        bool noError = true;
        int numeralSystemBase = 2;
        int numberToConvert = 0;
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
        Console.Write("Decimal number {0} presented in Binary system is: ", numberToConvert);
        Stack<int> resultNumber = new Stack<int>();
        while (numberToConvert > 0)
        {
            resultNumber.Push(numberToConvert % numeralSystemBase);
            numberToConvert /= numeralSystemBase;
        }

        int sizeOfSteak = resultNumber.Count;
        for (int i = 0; i < sizeOfSteak; i++)
        {
            Console.Write(resultNumber.Pop());
        }

        Console.WriteLine();
    }
}
