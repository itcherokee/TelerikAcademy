using System;
using System.Globalization;
using System.Threading;

/// <summary>
/// Task: "17. Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
/// and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week 
/// in Bulgarian."
/// </summary>
public class CalculateSixHoursLater
{
    public static void Main()
    {
        Console.Title = "Calculate the time six hours and 30 minutes later";
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        DateTime enteredDate = EnterDateTime("Enter the date and time (dd.mm.yyyy hh:mm:ss): ");
        TimeSpan deltaTime = new TimeSpan(6, 30, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("After 6 hours and 30 minutes will be: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine((enteredDate + deltaTime).ToString("dd.MM.yyyy HH.mm.ss dddd"));
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    // Handles user input of date and time
    private static DateTime EnterDateTime(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime enteredDate = new DateTime();
        try
        {
            enteredDate = DateTime.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not a valid date entered!\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(1);
        }

        Console.WriteLine("Entered date: {0}", enteredDate.ToString("dd.MMMM.yyyy"));
        return enteredDate;
    }
}