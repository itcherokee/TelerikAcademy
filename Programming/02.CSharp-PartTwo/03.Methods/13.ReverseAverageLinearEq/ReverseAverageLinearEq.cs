using System;
using System.Globalization;
using System.Linq;

/// <summary>
/// Task: "13. Write a program that can solve these tasks:
/// - Reverses the digits of a number
/// - Calculates the average of a sequence of integers
/// - Solves a linear equation a * x + b = 0
/// Create appropriate methods.
/// Provide a simple text-based menu for the user to choose which task to solve.
/// Validate the input data:
/// - The decimal number should be non-negative
/// - The sequence should not be empty 
/// - a should not be equal to 0"
/// </summary>
public class ReverseAverageLinearEq
{
    public static void Main()
    {
        int reverseNumber = 0;
        bool isValidInput = false;
        int selection = 0;
        do
        {
            Console.Title = "Reverse number, Average of sequence & Linear equatation.";
            Console.WriteLine("{0,25}", "MENU");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("1. Reverses the digits of a number\n" +
                              "2. Calculate the average of a sequence of integers\n" +
                              "3. Solves a linear equation a * x + b = 0\n" +
                              "4. Exit");
            Console.WriteLine(new string('=', 50));
            Console.Write("Select operation (1, 2, 3 or 4): ");
            isValidInput = int.TryParse(Console.ReadLine(), out selection);
            switch (selection)
            {
                case 1:
                    isValidInput = ReverseDigit(isValidInput);
                    break;
                case 2:
                    isValidInput = CalculateAverage(isValidInput);
                    break;
                case 3:
                    isValidInput = SolveLinearEquation(isValidInput);
                    break;
                case 4:
                    return;
                default:
                    isValidInput = ReportOnScreen("Wrong menu selection detected!");
                    break;
            }
        }
        while (!isValidInput);
    }

    // Calculates Linear Equation
    private static bool SolveLinearEquation(bool noError)
    {
        bool isValidInput = false;
        do
        {
            Console.Title = "Solves a linear equation a * x + b = 0";
            Console.Clear();
            Console.Write("Enter parameters on one row separated with space (first \"a\" than \"b\"): ");
            string[] textArray = Console.ReadLine().Trim().Split();
            int[] linearParameteres = new int[textArray.Length];
            for (int counter = 0; counter < linearParameteres.Length; counter++)
            {
                isValidInput = int.TryParse(textArray[counter], out linearParameteres[counter]);
                if (!isValidInput)
                {
                    isValidInput = ReportOnScreen("Wrong input detected (symbol, expresion, etc.)");
                    break;
                }

                if (linearParameteres[0] == 0)
                {
                    isValidInput = ReportOnScreen("Parameter \"a\" can not be equal to 0!");
                    break;
                }
            }

            if (isValidInput)
            {
                string result = "In linear equation " + linearParameteres[0] + " * x + " + linearParameteres[1] +
                                " = 0, x = ";
                noError = ReportOnScreen(result + CalculateLinear(linearParameteres[0], linearParameteres[1]));
            }
        }
        while (!isValidInput);
        return noError;
    }

    // Calculates average
    private static bool CalculateAverage(bool noError)
    {
        bool isValidInput = false;
        do
        {
            Console.Title = "Calculate the average of a sequence of integers";
            Console.Clear();
            Console.Write("Enter integers on one row separated with space: ");
            string[] textArray = Console.ReadLine().Trim().Split();
            int[] averageNumbers = new int[textArray.Length];
            for (int counter = 0; counter < averageNumbers.Length; counter++)
            {
                isValidInput = int.TryParse(textArray[counter], out averageNumbers[counter]);
                if (!isValidInput)
                {
                    isValidInput = ReportOnScreen("Wrong input detected (symbol, expresion, etc.)");
                    break;
                }

                if (averageNumbers[counter] < 0)
                {
                    isValidInput = ReportOnScreen("Numbers can not be negative!");
                    break;
                }
            }

            if (isValidInput)
            {
                noError = ReportOnScreen("Calculated average of entered numbers is: " + Average(averageNumbers));
            }
        }
        while (!isValidInput);
        return noError;
    }

    // Reverse digit
    private static bool ReverseDigit(bool noError)
    {
        bool isValidInput;
        int reverseNumber;
        do
        {
            Console.Title = "Reverse the digits of a number";
            Console.Clear();
            Console.Write("Enter integer number to be reversed: ");
            isValidInput = int.TryParse(Console.ReadLine(), out reverseNumber);
            if (!isValidInput)
            {
                isValidInput = ReportOnScreen("Wrong input detected (symbols)");
                continue;
            }

            if (reverseNumber < 0)
            {
                isValidInput = ReportOnScreen("Number can not be negative!");
                continue;
            }

            noError = ReportOnScreen("Reversed number is: " + Reverse(reverseNumber.ToString(CultureInfo.InvariantCulture)));
        }
        while (!isValidInput);
        return noError;
    }

    // Reverses the digits of a number
    private static string Reverse(string number)
    {
        int[] arrayOfNumbers = new int[number.Length];
        int wholeNumber = int.Parse(number);
        for (int index = 0; index < number.Length; index++)
        {
            arrayOfNumbers[index] = wholeNumber % 10;
            wholeNumber /= 10;
        }

        string result = arrayOfNumbers.Aggregate(string.Empty, (current, digit) => current + digit);
        return result.TrimStart('0');
    }

    // Calculates the average of a sequence of integers
    private static decimal Average(params int[] numbers)
    {
        int result = numbers.Sum();
        return (decimal)result / numbers.Length;
    }

    // Solves a linear equation a * x + b = 0
    private static decimal CalculateLinear(int a, int b)
    {
        return (decimal)-b / a;
    }

    // Report user input error
    private static bool ReportOnScreen(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Press <Enter> to continue...");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
}
