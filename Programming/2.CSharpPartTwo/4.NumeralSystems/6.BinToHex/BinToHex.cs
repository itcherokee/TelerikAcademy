using System;
using System.Collections.Generic;

public class BinToHex
{
    // Write a program to convert binary numbers to hexadecimal numbers (directly).

    public static void Main()
    {
        Console.Title = "Convert Binary number to Hexadecimal (directly)";
        int numeralSystemBase = 2;
        string numberToConvert = string.Empty;
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        int[] decValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        List<int> digitsInNumberToConvert = new List<int>();
        Console.Write("Enter the Binary number: ");
        numberToConvert = Console.ReadLine();
        for (int i = numberToConvert.Length - 1; i >= 0; i--)
        {
            if (numberToConvert[i] == '0' || numberToConvert[i] == '1')
            {
                digitsInNumberToConvert.Add(int.Parse(numberToConvert[i].ToString()));
            }
            else
            {
                Console.WriteLine("Not a Binary digit has been entered!");
                Console.WriteLine("Good bye...");
                Console.ReadLine();
            }
        }

        Console.Write("This Binary number, represented in Hexadecimal system is: 0x", numberToConvert);
        Stack<string> resultNumber = new Stack<string>();
        int result = 0;
        while (digitsInNumberToConvert.Count > 0)
        {
            if (digitsInNumberToConvert.Count < 4 && digitsInNumberToConvert.Count > 0)
            {
                while (digitsInNumberToConvert.Count < 4)
                {
                    digitsInNumberToConvert.Add(0);
                }
            }

            for (int position = 0; position < 4; position++)
            {
                result += digitsInNumberToConvert[position] * (int)Math.Pow((double)numeralSystemBase, (double)position);
            }

            resultNumber.Push(hexNumbers[Array.BinarySearch(decValues, result)]);
            digitsInNumberToConvert.RemoveRange(0, 4);
            result = 0;
        }

        int sizeOfSteak = resultNumber.Count;
        for (int i = 0; i < sizeOfSteak; i++)
        {
            Console.Write(resultNumber.Pop());
        }

        Console.WriteLine();
    }
}
