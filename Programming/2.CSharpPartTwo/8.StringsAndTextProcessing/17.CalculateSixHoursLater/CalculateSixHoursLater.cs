using System;
using System.Globalization;
using System.Threading;

public class CalculateSixHoursLater
{
    // Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
    // and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

    public static void Main()
    {
        Console.Title = "Calculate the time six hours and 30 minutes later";
        Console.Write("Enter the date and time (dd.mm.yyyy hh:mm:ss): ");
        DateTime dateTime = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        TimeSpan deltaTime = new TimeSpan(6, 30, 0);
        dateTime = dateTime + deltaTime;
        Console.WriteLine("Result: {0}", dateTime.ToString("dd.MM.yyyy hh.mm.ss dddd"));
    }
}