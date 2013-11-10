using System;

/// <summary>
/// Task: "5. Write program that asks for a digit and depending on the input 
/// shows the name of that digit (in English) using a switch statement."
/// </summary>
public class ShowNameOfDigit
{
    public static void Main()
    {
        Console.Title = "Converting digit to name";
        int numOneDigit = EnterData("Enter number between 0 and 10: ");
        string numOneName;
        switch (numOneDigit)
        {
            case 0:
                numOneName = "zero";
                break;
            case 1:
                numOneName = "one";
                break;
            case 2:
                numOneName = "two";
                break;
            case 3:
                numOneName = "three";
                break;
            case 4:
                numOneName = "four";
                break;
            case 5:
                numOneName = "five";
                break;
            case 6:
                numOneName = "six";
                break;
            case 7:
                numOneName = "seven";
                break;
            case 8:
                numOneName = "eight";
                break;
            case 9:
                numOneName = "nine";
                break;
            case 10:
                numOneName = "ten";
                break;
            default:
                numOneName = "out of requested bounadry";
                break;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You have entered number {0}.", numOneName);
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