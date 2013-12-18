using System;

public class PrintWhichDayOfWeekIs
{
    // Write a program that prints to the console which day of the week is today. Use System.DateTime.

    public static void Main()
    {
        Console.Title = "Check which day of the week is today.";
        Console.Write("Today is: {0} ", DateTime.Today.DayOfWeek);
        Console.WriteLine();
    }
}