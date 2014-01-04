using System;
using System.Globalization;
using System.Linq;
using System.Text;

/// <summary>
/// Task: "5. Write a program to convert hexadecimal numbers to binary numbers (directly)."
/// and
/// Task: "6. Write a program to convert binary numbers to hexadecimal numbers (directly)."
/// </summary>
public class HexToBinAndBinToHex
{
    private enum NumeralSystem
    {
        Binary,
        Hexadecimal,
    }

    public static void Main()
    {
        Console.Title = "Convert Hexadecimal number to Binary (directly)";
        NumeralSystem fromBase = SelectConversionBase();
        Console.Clear();
        string[] number = null;

        // Entering number to be converted
        switch (fromBase)
        {
            case NumeralSystem.Binary:
                number = EnterData("Enter Binary number (1 and 0): ", fromBase);
                break;
            case NumeralSystem.Hexadecimal:
                number = EnterData("Enter Hexadecimal number (0..F): ", fromBase);
                break;
        }

        Console.Clear();
        Console.Write("Converted number is: ");
        Console.ForegroundColor = ConsoleColor.Green;

        // Convert and output to Console byte by byte the result
        for (int i = 0; i < number.Length; i++)
        {
            Console.Write(Convert(number[i], fromBase));
        }

        Console.WriteLine();
        Console.ReadKey();
    }

    // Handles user selection of conversion: BinToHex or HexToBin
    private static NumeralSystem SelectConversionBase()
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select conversion:");
            Console.WriteLine("1. Binary to Hexadecimal");
            Console.WriteLine("2. Hexadecimal to Binary");
            Console.Write("Your selection: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || (enteredValue < 1 && enteredValue > 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                isValidInput = false;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue == 1 ? NumeralSystem.Binary : NumeralSystem.Hexadecimal;
    }

    // Handles user input of Binary or Hexadecimal number
    private static string[] EnterData(string message, NumeralSystem numberConversion)
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
                    switch (numberConversion)
                    {
                        case NumeralSystem.Binary:
                            if (result[i] != "0" && result[i] != "1")
                            {
                                throw new FormatException("There is a digit different from 0 or 1 in the number!");
                            }

                            break;
                        case NumeralSystem.Hexadecimal:
                            string[] hex = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
                            if (!hex.Contains(result[i]))
                            {
                                throw new FormatException("There is a digit/char different from allowed for Hex in the number!");
                            }

                            break;
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
        if (numberConversion == NumeralSystem.Hexadecimal)
        {
            return result;
        }
        else
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
    }

    // Converts a string representing Binary digit group to Hex and oposite and vice versa
    private static string Convert(string numberToSearch, NumeralSystem convertFrom)
    {
        string[] hexNumbers = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        string[] binNumbers =
        {
            "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010",
            "1011", "1100", "1101", "1110", "1111"
        };

        string[] formBase = convertFrom == NumeralSystem.Binary ? binNumbers : hexNumbers;
        string[] toBase = convertFrom == NumeralSystem.Binary ? hexNumbers : binNumbers;
        int index = Array.BinarySearch(formBase, 0, 16, numberToSearch);
        return toBase[index];
    }
}