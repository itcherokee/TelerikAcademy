using System;

/// <summary>
/// Task: "8. Write a program that reads an integer number n from the console 
/// and prints all the numbers in the interval [1..n], each on a single line."
/// </summary>
public class PrintScope
{
    public static void Main()
    {
        Console.Title = "Print all numbers in range [1..n]";
        uint numberOne = EnterData("Enter number (n): ");
        for (uint i = 1; i < (numberOne + 1); i++)
        {
            Console.WriteLine(i);
        }

        Console.ReadKey();
    }

    private static uint EnterData(string message)
    {
        bool isValidInput = default(bool);
        uint enteredValue = default(uint);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput || enteredValue == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid number! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();

                // set to false in case 0 has been entered
                isValidInput = false;
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}