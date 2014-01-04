using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

/// <summary>
/// Task: "7. Write a program to convert from any numeral system of given base s to any other 
/// numeral system of base d (2 ≤ s, d ≤ 16)."
/// </summary>
public class AnyToAny
{
    private static string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
    private static string[] decNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" };
    private static string[] binNumbers =
        {
            "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010",
            "1011", "1100", "1101", "1110", "1111"
        };

    public static void Main()
    {
        Console.Title = "Convert any to any numeral system [2 ≤ from, to ≤ 16]";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("You can convert from/to any numeral system between binary and hexadecimal.\n");
        int fromBase = EnterBase("FROM base (number): ");
        int toBase = EnterBase("TO base (number): ");
        string[] numberToConvert = EnterNumber("Enter the number: ", fromBase);
        Console.Write("Converted number is: ");
        Console.ForegroundColor = ConsoleColor.Green;
        if (fromBase == toBase)
        {
            Console.WriteLine(string.Join(string.Empty, numberToConvert));
        }
        else
        {
            if ((fromBase == 2 || fromBase == 16) && (toBase == 2 || toBase == 16))
            {
                for (int i = 0; i < numberToConvert.Length; i++)
                {
                    Console.Write(Convert(numberToConvert[i], fromBase));
                }
            }
            else
            {
                Console.WriteLine(ConvertFromTen(toBase, ConvertToTen(numberToConvert, fromBase)));
            }
        }

        Console.WriteLine();
        Console.ReadKey();
    }

    // Convert the number to Decimal numeral system
    private static long ConvertToTen(string[] numberToConvert, int fromBase)
    {
        int position = numberToConvert.Length - 1;
        long convertedNumber = 0;
        for (int index = 0; index <= position; index++)
        {
            // Tooks the decimal representation of digit in certain position (if it is from base bigger then 10th: A,B,C...)
            int decNumber = int.Parse(decNumbers[Array.IndexOf(hexNumbers, numberToConvert[position - index])]);
            convertedNumber += decNumber * (long)Math.Pow(fromBase, index);
        }

        return convertedNumber;
    }

    // Converts the number from Decimal to requested numeral system
    private static string ConvertFromTen(int toBase, long number)
    {
        string convertedNumber = string.Empty;
        List<int> result = new List<int>();
        while (number > 0)
        {
            result.Add((int)(number % toBase));
            number /= toBase;
        }

        for (int count = 0; count < result.Count; count++)
        {
            char letterDigit = (char)(result[count] > 9 ? 'A' + result[count] - 10 : '0' + result[count]);
            convertedNumber = letterDigit + convertedNumber;
        }

        return convertedNumber;
    }

    // Handles user input of selecting numeral systems bases
    private static int EnterBase(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || (enteredValue < 1 && enteredValue > 16))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid base! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }

    // Handles user input of Binary or Hexadecimal number
    private static string[] EnterNumber(string message, int numeralBase)
    {
        string[] result = null;
        bool isValidInput;
        do
        {
            isValidInput = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            try
            {
                string input = Console.ReadLine().ToUpper(CultureInfo.InvariantCulture);
                result = new string[input.Length];
                result = input.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray();
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (!hexNumbers.Take(numeralBase).Contains(result[i]))
                    {
                        throw new FormatException("There is a digit/char different from allowed for selected base!");
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

        Console.ForegroundColor = ConsoleColor.White;
        if (numeralBase == 2)
        {
            // Preparare binary number for conversion by grouping it in four bits
            StringBuilder bits = new StringBuilder(string.Join(string.Empty, result));

            // adds a leading zeroes, if neccesary 
            bits.Insert(0, "0", 4 - (bits.Length % 4));
            string[] groupedBits = new string[bits.Length / 4];
            int startIndex = 0;
            for (int i = 0; i < bits.Length / 4; i++)
            {
                groupedBits[i] = bits.ToString(startIndex, 4);
                startIndex += 4;
            }

            return groupedBits;
        }

        return result;
    }

    // Converts a string representing Binary digit group to Hex and oposite and vice versa
    private static string Convert(string numberToSearch, int fromBase)
    {
        string[] formBase = fromBase == 2 ? binNumbers : hexNumbers;
        string[] toBase = fromBase == 2 ? hexNumbers : binNumbers;
        int index = Array.BinarySearch(formBase, 0, 16, numberToSearch);
        return toBase[index];
    }
}
