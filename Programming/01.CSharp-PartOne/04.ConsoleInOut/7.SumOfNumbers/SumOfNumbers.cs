using System;

/// <summary>
/// Task: "7. Write a program that gets a number n and after that gets more n numbers 
/// and calculates and prints their sum."
/// </summary>
public class SumOfNNumbers
{
    public static void Main()
    {
        Console.Title = "Sum of all entered numbers";
        long totalNumbers = EnterData("Enter the count of numbers to be calculated (sum): ");
        long sumOfAllNumbers = default(long);
        for (int i = 0; i < totalNumbers; i++)
        {
            sumOfAllNumbers += EnterData(string.Format("Enter digit number {0}: ", i + 1));
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Sum of all entered numbers is: {0}", sumOfAllNumbers);
        Console.ReadKey();
    }

    private static long EnterData(string message)
    {
        bool isValidInput = default(bool);
        long enteredValue = default(long);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = long.TryParse(Console.ReadLine(), out enteredValue);
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