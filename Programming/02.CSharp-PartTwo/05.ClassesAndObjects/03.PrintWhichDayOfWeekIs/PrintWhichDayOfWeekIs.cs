using System;

/// <summary>
/// Task: "3. Write a program that prints to the console which day of the week is today. Use System.DateTime."
/// </summary>
public class PrintWhichDayOfWeekIs
{
    public static void Main()
    {
        Console.Title = "Check which day of the week is today.";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Today {0} is: ", DateTime.Today.ToString("dd.MMMM.yyyy"));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(DateTime.Today.DayOfWeek);
        Console.WriteLine();
        Console.ReadKey();
    }
}