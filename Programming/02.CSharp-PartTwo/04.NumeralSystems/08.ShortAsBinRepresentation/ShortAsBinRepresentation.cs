using System;
using System.Collections.Generic;

/// <summary>
/// Task: "8. Write a program that shows the binary representation of given 16-bit
/// signed integer number (the C# type short)."
/// </summary>
public class ShortAsBinRepresentation
{
    public static void Main()
    {
        Console.Title = "16-bit signed integer binary representation";
        bool noError = true;
        short numberToConvert = EnterData("Enter the decimal number (short): ");
        Console.WriteLine("Decimal number {0} in binary presentation is: ", numberToConvert);
        Console.ForegroundColor = ConsoleColor.Green;
        List<int> resultNumber = new List<int>();
        bool negativeNumber = numberToConvert < 0 ? true : false;
        int bits;

        // Take bit per bit and invert it if negative
        for (int index = 0; index < 15; index++)
        {
            bits = numberToConvert % 2;
            if (negativeNumber)
            {
                bits = Math.Abs(numberToConvert % 2) > 0 ? 0 : 1;
            }

            resultNumber.Add(bits);
            numberToConvert /= 2;
        }

        // If negative - two's compliment - adds 1
        int carryOver = 1;
        if (negativeNumber)
        {
            for (int index = 0; index < 15; index++)
            {
                resultNumber[index] += carryOver;
                if (resultNumber[index] == 2)
                {
                    resultNumber[index] = 0;
                }
                else
                {
                    carryOver = 0;
                    break;
                }
            }
        }

        // Add sign if necessary
        resultNumber.Add(negativeNumber ? 1 : 0);

        // Output to Console 
        Console.WriteLine(new string('=', 66));
        Console.Write("|{0}|{1,30}", "Sign", "Number");
        Console.WriteLine("{0,30}\n{1}", "|", new string('=', 66));
        for (int index = 15; index >= 0; index--)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("| ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0,-2}", resultNumber[index]);
            Console.ForegroundColor = ConsoleColor.Green;
            if (index == 15)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine("|\n" + new string('=', 66));
        Console.WriteLine();
    }

    // Handles user input of single short number
    private static short EnterData(string message)
    {
        bool isValidInput = default(bool);
        short enteredValue = default(short);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = short.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}