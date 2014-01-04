using System;
using System.Collections.Generic;
using System.Globalization;

/// <summary>
/// Task: "4. Write a program to convert hexadecimal numbers to their decimal representation."
/// 
/// Note: Handles only positive hex numbers as for negative we need rules how to enter them, which are not set.
/// </summary>
public class HexToDec
{
    public static void Main()
    {
        Console.Title = "Convert Hexadecimal number to Decimal";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the Hexadecimal number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string numberToConvert = Console.ReadLine().ToUpper();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Hexadecimal number 0x{0} represented in Decimal system is: ", numberToConvert);
        Console.ForegroundColor = ConsoleColor.Green;
        Stack<int> resultByte = new Stack<int>();
        List<int> resultFinal = new List<int>();
        int hexByte = 0;
        int numeralSystemBase = 2;
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        int[] decValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        for (int index = 0; index < numberToConvert.Length; index++)
        {
            try
            {
                hexByte = decValues[Array.BinarySearch(hexNumbers, numberToConvert[index].ToString(CultureInfo.InvariantCulture))];
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Error: Wrong input!");
                return;
            }

            int iterations = 4;
            while (hexByte > 0)
            {
                resultByte.Push(hexByte % numeralSystemBase);
                hexByte /= numeralSystemBase;
                iterations--;
            }

            if (iterations > 0)
            {
                resultByte.Push(0);
            }

            int sizeOfSteak = resultByte.Count;
            for (int i = 0; i < sizeOfSteak; i++)
            {
                resultFinal.Add(resultByte.Pop());
            }

            resultByte.Clear();
        }

        int position = resultFinal.Count - 1;
        long result = resultFinal[position];
        for (int index = 1; index < resultFinal.Count; index++)
        {
            checked
            {
                result += resultFinal[position - index] * (long)Math.Pow(numeralSystemBase, index);
            }
        }

        Console.WriteLine(result);
        Console.WriteLine();
    }
}