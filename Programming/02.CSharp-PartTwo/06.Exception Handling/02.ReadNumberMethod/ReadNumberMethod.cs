using System;

/// <summary>
/// Task: "2. Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
/// If an invalid number or non-number text is entered, the method should throw an exception. 
/// Using this method write a program that enters 10 numbers:
// a1, a2, … a10, such that 1 < a1 < … < a10 < 100"
/// </summary>
public class ReadNumberMethod
{
    private static readonly string[] NumberNameExtension = { "st", "nd", "rd", "th" };

    public static void Main()
    {
        Console.Title = "Implement ReadNumber to enter numbers in range [2..99]";
        Console.WriteLine("Condition for number (a) input is (1 < a1 < … < a10 < 100).");
        const int LeftBorder = 1;
        const int RightBorder = 100;
        const int NumberOfDigits = 10;
        int currentStart = LeftBorder + 1;
        int currentEnd = RightBorder - NumberOfDigits;

        try
        {
            for (int index = 1; index < NumberOfDigits + 1; index++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please enter {0}{1} number: ", index, index < 4 ? NumberNameExtension[index - 1] : NumberNameExtension[3]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                currentStart = ReadNumber(currentStart, currentEnd++) + 1;
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: " + ex.Message);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }

    // Reads number form Console in specified range, throw exception if range is violated
    private static int ReadNumber(int start, int end)
    {
        int enteredNumber;
        var isNumberEntered = int.TryParse(Console.ReadLine(), out enteredNumber);
        const string Parameter = "Console input.";
        string message;
        if (!isNumberEntered)
        {
            message = "Non numeric value has been entered!";
            throw new ArgumentException(message, Parameter);
        }

        if (enteredNumber < start || enteredNumber > end)
        {
            message = string.Format("Number entered was smaller than {0} or bigger than {1}!", start, end);
            throw new ArgumentOutOfRangeException(Parameter, message);
        }

        return enteredNumber;
    }
}