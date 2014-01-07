using System;

/// <summary>
/// Task: "16. Write a program that reads two dates in the format: day.month.year and 
/// calculates the number of days between them."
/// </summary>
public class CalculatesDaysBetween
{
    public static void Main()
    {
        Console.Title = "Calculate days between two dates";

        DateTime firstDate = EnterDate("Enter the first date (dd.mm.yyyy): ");
        DateTime secondDate = EnterDate("Enter the second date (dd.mm.yyyy): ");
        TimeSpan deltaDays = secondDate - firstDate;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nDistance between two dates are: {0} days", Math.Abs(deltaDays.TotalDays));
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    // Handles user input of date
    private static DateTime EnterDate(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime enteredDate = new DateTime();
        try
        {
            enteredDate = DateTime.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid date entered!\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(1);
        }

        Console.WriteLine("Entered date: {0}", enteredDate.ToString("dd.MM.yyyy"));
        return enteredDate;
    }
}