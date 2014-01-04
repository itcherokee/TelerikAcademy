using System;

/// <summary>
/// Task: "3. Write a method that returns the last digit of given integer as an English word. 
/// Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine"."
/// </summary>
public class ReturnDigitAsWord
{
    public static void Main()
    {
        Console.Title = "Return last digit as a word.";
        int inputNumber = EnterData("Enter an integer number: ");
        Print(LastDigit(inputNumber));
        Console.ReadKey();
    }

    // Finds and returns last digit of number as an English word
    private static string LastDigit(int number)
    {
        string[] digitWords = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        return digitWords[number % 10];
    }

    // Output to Console of the result
    private static void Print(string result)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nLast digit in that number is ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("{0}.", result);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Handles user input
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