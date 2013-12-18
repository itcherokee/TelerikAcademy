using System;
using System.Collections.Generic;

public class AnyToAny
{
    // Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).

    public static void Main()
    {
        Console.Title = "Convert any to any numeral system [2 ≤ from, to ≤ 16]";
        bool noError;
        int fromBase = 0;
        int toBase = 0;
        string numberToConvert = string.Empty;
        try
        {
            do
            {
                noError = true;
                Console.Write("FROM base (number): ");
                fromBase = int.Parse(Console.ReadLine());
                if (!(fromBase > 1 && fromBase < 16))
                {
                    noError = ShowError();
                }

                Console.Write("TO base (number): ");
                toBase = int.Parse(Console.ReadLine());
                if (!(toBase > fromBase && toBase < 17))
                {
                    noError = ShowError();
                }

                Console.Write("Enter the number: ");
                numberToConvert = Console.ReadLine().ToUpper();
            }
            while (!noError);
            Console.WriteLine(ConvertFromTen(toBase, ConvertToTen(fromBase, numberToConvert)));
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static long ConvertToTen(int fbase, string numberToConvert)
    {
        int position = numberToConvert.Length - 1;
        long convertedNumber = 0;
        for (int index = 0; index <= position; index++)
        {
            convertedNumber += long.Parse(numberToConvert[position - index].ToString()) * (long)Math.Pow((double)fbase, (double)index);
        }

        return convertedNumber;
    }

    private static string ConvertFromTen(int tbase, long number)
    {
        string convertedNumber = string.Empty;
        List<int> result = new List<int>();
        while (number > 0)
        {
            result.Add((int)(number % tbase));
            number /= tbase;
        }

        char letterDigit;
        for (int count = 0; count < result.Count; count++)
        {
            letterDigit = (char)(result[count] > 9 ? 'A' + result[count] - 10 : '0' + result[count]);
            convertedNumber = letterDigit + convertedNumber;
        }

        return convertedNumber;
    }

    private static bool ShowError()
    {
        Console.WriteLine("There were error in your input data.");
        Console.WriteLine("Try again <press ENTER>...");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
}