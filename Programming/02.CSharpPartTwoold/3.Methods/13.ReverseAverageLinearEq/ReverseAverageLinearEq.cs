using System;

public class ReverseAverageLinearEq
{
    // Write a program that can solve these tasks:
    // - Reverses the digits of a number
    // - Calculates the average of a sequence of integers
    // - Solves a linear equation a * x + b = 0
    // Create appropriate methods.
    // Provide a simple text-based menu for the user to choose which task to solve.
    // Validate the input data:
    // - The decimal number should be non-negative
    // - The sequence should not be empty
    // - a should not be equal to 0

    public static void Main()
    {
        int reverseNumber = 0;
        int[] averageNumbers;
        int[] linearParameteres;
        bool noError = false;
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
            noError = int.TryParse(Console.ReadLine(), out selection);
            bool noErrorInternal = false;
            switch (selection)
            {
                case 1:
                    do
                    {
                        Console.Title = "Reverse the digits of a number";
                        Console.Clear();
                        Console.Write("Enter integer number to be reversed: ");
                        noErrorInternal = int.TryParse(Console.ReadLine(), out reverseNumber);
                        if (!noErrorInternal)
                        {
                            noErrorInternal = ReportOnScreen("Wrong input detected (symbols)");
                            continue;
                        }
                        else if (reverseNumber < 0)
                        {
                            noErrorInternal = ReportOnScreen("Number can not be negative!");
                            continue;
                        }

                        noError = ReportOnScreen("Reversed number is: " + Reverse(reverseNumber.ToString()));
                    }
                    while (!noErrorInternal);
                    break;
                case 2:
                    do
                    {
                        Console.Title = "Calculate the average of a sequence of integers";
                        Console.Clear();
                        Console.Write("Enter integers on one row separated with space: ");
                        string[] textArray = Console.ReadLine().Trim().Split();
                        averageNumbers = new int[textArray.Length];
                        for (int counter = 0; counter < averageNumbers.Length; counter++)
                        {
                            noErrorInternal = int.TryParse(textArray[counter], out averageNumbers[counter]);
                            if (!noErrorInternal)
                            {
                                noErrorInternal = ReportOnScreen("Wrong input detected (symbol, expresion, etc.)");
                                break;
                            }
                            else if (averageNumbers[counter] < 0)
                            {
                                noErrorInternal = ReportOnScreen("Numbers can not be negative!");
                                break;
                            }
                        }

                        if (noErrorInternal)
                        {
                            noError = ReportOnScreen("Calculated average of entered numbers is: " + Average(averageNumbers));
                        }
                    }
                    while (!noErrorInternal);
                    break;
                case 3:
                    do
                    {
                        Console.Title = "Solves a linear equation a * x + b = 0";
                        Console.Clear();
                        Console.Write("Enter parameters on one row separated with space (first \"a\" than \"b\"): ");
                        string[] textArray = Console.ReadLine().Trim().Split();
                        linearParameteres = new int[textArray.Length];
                        for (int counter = 0; counter < linearParameteres.Length; counter++)
                        {
                            noErrorInternal = int.TryParse(textArray[counter], out linearParameteres[counter]);
                            if (!noErrorInternal)
                            {
                                noErrorInternal = ReportOnScreen("Wrong input detected (symbol, expresion, etc.)");
                                break;
                            }
                            else if (linearParameteres[0] == 0)
                            {
                                noErrorInternal = ReportOnScreen("Parameter \"a\" can not be equal to 0!");
                                break;
                            }
                        }

                        if (noErrorInternal)
                        {
                            string result = "In linear equation " + linearParameteres[0] + " * x + " + linearParameteres[1] + " = 0, x = ";
                            noError = ReportOnScreen(result + CalculateLinear(linearParameteres[0], linearParameteres[1]));
                        }
                    }
                    while (!noErrorInternal);
                    break;
                case 4:
                    return;
                    break;
                default:
                    noError = ReportOnScreen("Wrong menu selection detected!");
                    break;
            }
        }
        while (!noError);
    }

    // Reverses the digits of a number
    private static string Reverse(string number)
    {
        int[] arrayOfNumbers = new int[number.Length];
        int wholeNumber = int.Parse(number);
        int multiplyer = 10;
        for (int index = 0; index < number.Length; index++)
        {
            arrayOfNumbers[index] = wholeNumber % multiplyer;
            wholeNumber /= multiplyer;
        }

        string result = string.Empty;
        foreach (var digit in arrayOfNumbers)
        {
            result += digit;
        }

        return result.TrimStart('0');
    }

    // Calculates the average of a sequence of integers
    private static decimal Average(params int[] numbers)
    {
        int result = 0;
        foreach (var number in numbers)
        {
            result += number;
        }

        return (decimal)result / numbers.Length;
    }

    // Solves a linear equation a * x + b = 0
    private static decimal CalculateLinear(int a, int b)
    {
        return (decimal)-b / a;
    }

    // method used to report user input error
    private static bool ReportOnScreen(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Press <Enter> to continue...");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
}
