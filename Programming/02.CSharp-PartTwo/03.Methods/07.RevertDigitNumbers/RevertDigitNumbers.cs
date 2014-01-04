using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "7. Write a method that reverses the digits of given decimal number. 
/// Example: 256 -> 652"
/// </summary>
public class RevertDigitNumbers
{
    public static void Main()
    {
        Console.Title = "Reverse the digits in a number";
        int number = EnterData("Enter a number:");
        Console.WriteLine("Entered number reversed looks like that: {0}", Reverse(number));
    }

    private static string Reverse(int number)
    {
        int size = number.ToString(CultureInfo.InvariantCulture).Length;
        int[] arrayOfNumbers = new int[size];
        for (int index = 0; index < size; index++)
        {
            arrayOfNumbers[index] = number % 10;
            number /= 10;
        }

        // Accumulates all array elements into one string value using LINQ + lambda expression
        // Below line is equivalent to commneted code after it
        string result = arrayOfNumbers.Aggregate(string.Empty, (current, digit) => current + digit);

        // string result = string.Empty;
        // foreach (var digit in arrayOfNumbers)
        // {
        //    result += digit;
        // }

        // Because there is no numbers starting with zero, next line removes it if it exist as leading number
        return result.TrimStart('0');
    }

    // Handles user input of single integer number from Console 
    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = int.TryParse(Console.ReadLine(), out enteredValue);
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