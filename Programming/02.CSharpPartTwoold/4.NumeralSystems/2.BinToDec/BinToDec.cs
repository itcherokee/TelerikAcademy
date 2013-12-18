using System;
using System.Collections.Generic;

public class BinToDec
{
    // Write a program to convert binary numbers to their decimal representation.

    public static void Main()
    {
        Console.Title = "Convert Binary number to Decimal";
        bool noError = true;
        int numeralSystemBase = 2;
        string numberToConvert = string.Empty;
        List<int> digitsInNumberToConvert = new List<int>();
        do
        {
            noError = true;
            Console.Write("Enter the binary number: ");
            try
            {
                numberToConvert = Console.ReadLine();
                for (int i = numberToConvert.Length - 1; i >= 0; i--)
                {
                    digitsInNumberToConvert.Add(int.Parse(numberToConvert[i].ToString()));
                }
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
        Console.Write("Binary number {0} presented in Decimal numeral system is: ", numberToConvert);
        int result = 0;
        for (int position = 0; position < digitsInNumberToConvert.Count; position++)
        {
            result += digitsInNumberToConvert[position] * (int)Math.Pow((double)numeralSystemBase, (double)position);
        }

        Console.Write(result);
        Console.WriteLine();
    }
}
