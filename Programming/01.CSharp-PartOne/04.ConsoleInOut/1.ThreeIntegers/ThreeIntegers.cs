using System;

/// <summary>
/// Task: "1. Write a program that reads 3 integer numbers from the console and prints their sum."
/// </summary>
public class ThreeIntegers
{
    public static void Main()
    {
        Console.Title = "Sum of 3 numbers";
        Console.WriteLine("Calculating sum of three numbers.");
        Console.ForegroundColor = ConsoleColor.White;
        int numberOne = EnterData("Enter first number:");
        int numberTwo = EnterData("Enter second number:");
        int numberThree = EnterData("Enter third number:");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("The Sum of numbers {0}, {1} and {2} is {3}", numberOne, numberTwo, numberThree, numberOne + numberTwo + numberThree);
        Console.ReadKey();
    }

    private static int EnterData(string message)
    {
        bool isValidInput = default(bool);
        int enteredValue = default(int);
        do
        {
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