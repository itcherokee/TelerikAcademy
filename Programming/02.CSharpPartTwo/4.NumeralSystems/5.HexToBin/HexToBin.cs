using System;
using System.Collections.Generic;

public class HexToBin
{
    // Write a program to convert hexadecimal numbers to binary numbers (directly).

    public static void Main()
    {
        Console.Title = "Convert Hexadecimal number to Binary (directly)";
        int numeralSystemBase = 2;
        string numberToConvert = string.Empty;
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        int[] decValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        Console.Write("Enter the Hexadecimal number: ");
        numberToConvert = Console.ReadLine().ToUpper();
        Console.Write("Hexadecimal number 0x{0} represented in Binary system is: ", numberToConvert);
        Stack<int> resultNumber = new Stack<int>();
        int hexByte = 0;
        for (int index = 0; index < numberToConvert.Length; index++)
        {
            try
            {
                hexByte = decValues[Array.BinarySearch(hexNumbers, numberToConvert[index].ToString())];
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Wrong input!");
                return;
            }

            int iterations = 4;
            while (hexByte > 0)
            {
                resultNumber.Push(hexByte % numeralSystemBase);
                hexByte /= numeralSystemBase;
                iterations--;
            }

            if (iterations > 0)
            {
                resultNumber.Push(0);
            }

            int sizeOfSteak = resultNumber.Count;
            for (int i = 0; i < sizeOfSteak; i++)
            {
                Console.Write(resultNumber.Pop());
            }

            resultNumber.Clear();
        }

        Console.WriteLine();
    }
}
