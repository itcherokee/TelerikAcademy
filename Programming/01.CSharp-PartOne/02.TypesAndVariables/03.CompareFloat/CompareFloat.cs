using System;

/// <summary>
/// Task: "3. Write a program that safely compares floating-point numbers with precision of 0.000001. 
/// Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true"
/// </summary>
public class CompareFloat
{
    public static void Main()
    {
        Console.Title = "Check two numbers for parity";
        Console.WriteLine("Parity check of 2 numbers (precision up to 6th digits after deciaml point)");
        decimal numberOne = EnterValue("first");
        decimal numberTwo = EnterValue("second");
        decimal result = Math.Abs(numberOne - numberTwo);
        string message = string.Empty;
        if (result < 0.000001m)
        {
            message = "Numbers are equal!";
        }
        else
        {
            message = "Numbers are NOT equal!.";
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ReadKey();
    }

    private static decimal EnterValue(string counter)
    {
        bool isValidInput = false;
        decimal number = 0.0M;
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter {0} number: ", counter);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = decimal.TryParse(Console.ReadLine(), out number);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Try again.");
            }
        } while (!isValidInput);

        return number;
    }
}