using System;
using System.Collections.Generic;

public class HexToDec
{
    // Write a program to convert hexadecimal numbers to their decimal representation

    public static void Main()
    {
        Console.Title = "Convert Hexadecimal number to Decimal";
        int numeralSystemBase = 2;
        string numberToConvert = string.Empty;
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        int[] decValues = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        Console.Write("Enter the Hexadecimal number: ");
        numberToConvert = Console.ReadLine().ToUpper();
        Console.Write("Hexadecimal number 0x{0} represented in Decimal system is: ", numberToConvert);
        Stack<int> resultByte = new Stack<int>();
        List<int> resultFinal = new List<int>();
        int hexByte = 0;
        for (int index = 0; index < numberToConvert.Length; index++)
        {
            try
            {
                hexByte = decValues[Array.BinarySearch(hexNumbers, numberToConvert[index].ToString())];
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
                result += (long)resultFinal[position - index] * (long)Math.Pow((double)numeralSystemBase, (double)index);
            }
        }

        Console.WriteLine(result);
        Console.WriteLine();
    }
}
