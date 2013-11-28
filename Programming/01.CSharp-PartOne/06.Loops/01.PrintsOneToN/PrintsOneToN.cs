using System;

/// <summary>
/// Task: "1. Write a program that prints all the numbers from 1 to N."
/// </summary>
public class PrintsOneToN
{
    public static void Main()
    {
        Console.Title = "Prints all numbers from 1 to N";
        uint upperBoundary = EnterData("Please enter the upper boundary of the range to print.\nN=");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Result = ");
        for (int i = 1; i <= upperBoundary; i++)
        {
            Console.Write(i);
            if (i < upperBoundary)
            {
                Console.Write(", ");
            }
        }

        Console.WriteLine();
        Console.ReadKey();
    }

    private static uint EnterData(string message)
    {
        bool isValidInput = default(bool);
        uint enteredValue = default(int);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = uint.TryParse(Console.ReadLine(), out enteredValue);
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