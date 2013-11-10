using System;

/// <summary>
/// Task: "5. Write a program that gets two numbers from the console and prints the greater of them.
/// Don’t use if statements."
/// </summary>
public class GreaterNumber
{
    public static void Main()
    {
        Console.Title = "Find greater number v.1";
        double numberOne = EnterData("Enter first number: ");
        double numberTwo = EnterData("Enter second number: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Bigger number is: {0}", Math.Max(numberOne, numberTwo));
        Console.ReadKey();
    }

    private static double EnterData(string message)
    {
        bool isValidInput = default(bool);
        double enteredValue = default(double);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = double.TryParse(Console.ReadLine(), out enteredValue);
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