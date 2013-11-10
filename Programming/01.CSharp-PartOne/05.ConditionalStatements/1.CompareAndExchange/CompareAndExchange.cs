using System;

/// <summary>
/// Task: "1. Write an if statement that examines two integer variables and 
/// exchanges their values if the first one is greater than the second one."
/// </summary>
public class CompareAndExchange
{
    public static void Main()
    {
        Console.Title = "Enter two integers to sort them if necessary.";

        int numberOne = EnterData("Enter first number: ");
        int numberTwo = EnterData("Enter second number: ");
        if (numberOne > numberTwo)
        {
            numberOne = numberOne ^ numberTwo;
            numberTwo = numberOne ^ numberTwo;
            numberOne = numberOne ^ numberTwo;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Your ascending sorted numbers are: {0}, {1}", numberOne, numberTwo);
        Console.ReadKey();
    }

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