using System;

/// <summary>
/// Task: "1. Write a program that reads a year from the console and checks whether it is a leap. 
/// Use DateTime."
/// </summary>
public class CheckYearIsLeap
{
    public static void Main()
    {
        Console.Title = "Check does year is leap";
        int year = EnterData("Enter the year to be checked does it leap one: ");
        Console.ForegroundColor = ConsoleColor.Green;
        bool isLeap = DateTime.IsLeapYear(year);
        Console.WriteLine("Year {0} is {1}Leap.", year, isLeap ? string.Empty : "NOT ");
        Console.ReadKey();
    }

    // Handles user input from Console
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
