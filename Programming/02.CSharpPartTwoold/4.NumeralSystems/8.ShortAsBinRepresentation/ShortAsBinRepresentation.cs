using System;
using System.Collections.Generic;

public class ShortAsBinRepresentation
{
    // Write a program that shows the binary representation of 
    // given 16-bit signed integer number (the C# type short).

    public static void Main()
    {
        Console.Title = "16-bit signed integer binary representation";
        bool noError = true;
        short numberToConvert = 0;
        do
        {
            noError = true;
            Console.Write("Enter the decimal number: ");
            try
            {
                numberToConvert = short.Parse(Console.ReadLine());
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
        Console.WriteLine("Decimal number {0} in binary presentation is: ", numberToConvert);
        List<int> resultNumber = new List<int>();
        bool negativeNumber = numberToConvert < 0 ? true : false;
        int bits;

        // take bit per bit and invert it if negative
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

        // if negative - two's compliment - adds 1
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

        // add sign if necessary 
        resultNumber.Add(negativeNumber ? 1 : 0);

        // print to the console
        Console.WriteLine(new string('=', 66));
        Console.Write("|{0}|{1,30}", "Sign", "Number");
        Console.WriteLine("{0,30}\n{1}", "|", new string('=', 66));
        for (int index = 15; index >= 0; index--)
        {
            Console.Write("| {0,-2}", resultNumber[index], "|");
            if (index == 15)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine("|\n" + new string('=', 66));
        Console.WriteLine();
    }
}