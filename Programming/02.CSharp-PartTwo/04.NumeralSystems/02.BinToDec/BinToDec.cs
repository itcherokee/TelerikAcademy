using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "2. Write a program to convert binary numbers to their decimal representation."
/// 
/// Note: Handles positive and negative BInary numbers, restricted to int type representations.
/// </summary>
public class BinToDec
{
    public static void Main()
    {
        Console.Title = "Convert Binary number to Decimal";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Algorythm can convert Binary to Decimal (positive or negative).\nWorks with binary representation of \"int\" type of .NET.");
        byte[] numberToConvert = EnterData("Enter the binary number (0 and 1): ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Binary number presented in Decimal numeral system is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        var result = ConvertBinToDec(numberToConvert);
        Console.WriteLine(result);
        Console.WriteLine();
        Console.ReadKey();
    }

    // Converts Binary number (type int) to Decimal representation (negative or positive)
    private static int ConvertBinToDec(byte[] numberToConvert)
    {
        bool isNegative = numberToConvert.Length == 32 && numberToConvert[0] == 1;
        byte[] number = numberToConvert.Select(x => x).ToArray();
        int startIndex = isNegative ? 1 : 0;
        bool absoluteMinValue = false;
        int result = default(int);
        if (isNegative)
        {
            int bitIndex = 31;
            int bitValue = 0;
            while (bitValue == 0)
            {
                bitValue = number[bitIndex];
                if (bitValue == 1 && bitIndex != 0)
                {
                    if (bitIndex != 0)
                    {
                        number[bitIndex] = 0;
                    }

                    while (bitIndex < 31)
                    {
                        bitIndex++;
                        if (bitIndex == 31)
                        {
                            bitValue = 1;
                        }

                        number[bitIndex] = 1;
                    }
                }
                else
                {
                    if (bitIndex != 0)
                    {
                        bitIndex--;
                    }
                    else
                    {
                        // absolute MinValue detected
                        absoluteMinValue = true;
                        break;
                    }
                }
            }

            // invert bits
            if (!absoluteMinValue)
            {
                for (int index = 0; index < number.Length; index++)
                {
                    number[index] = (byte)(number[index] == 1 ? 0 : 1);
                }
            }
        }

        // Calculate Binary to Decimal using Horner Scheme
        result = number[startIndex];
        for (int index = startIndex + 1; index < number.Length; index++)
        {
            result = (result << 1) + number[index];
        }

        return isNegative ? (absoluteMinValue ? int.MinValue : result * -1) : result;
    }

    // Handles user input of binary number
    private static byte[] EnterData(string message)
    {
        string input = default(string);
        byte[] result = null;
        bool isValidInput;
        do
        {
            isValidInput = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            try
            {
                input = Console.ReadLine();
                if (input != null)
                {
                    result = new byte[input.Length];
                    for (int i = input.Length - 1; i >= 0; i--)
                    {
                        byte element = byte.Parse(input[i].ToString(CultureInfo.InvariantCulture));
                        if ((element != 0 && element != 1) || input.Length > 32)
                        {
                            throw new FormatException(
                                "There is a digit different from 0 or 1 in the number or too much digits has been typed!");
                        }

                        result[i] = element;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Try again <press any key>...");
                Console.ReadKey();
                isValidInput = false;
                Console.Clear();
            }
        }
        while (!isValidInput);
        return result ?? new byte[0];
    }
}