using System;

/// <summary>
/// Task: "7. Create a console application that prints the current date and time.".
/// </summary>
public class PrintCurrentDateTime
{
    public static void Main()
    {
        Console.Title = "Print current date & time";
        Console.WriteLine("Precise date and time at the moment are: ");
        DateTime currentDateTime = DateTime.Now;
        Console.WriteLine("Date: {0}", currentDateTime.ToLongDateString());
        Console.WriteLine("Time: {0}", currentDateTime.ToLongTimeString());
        Console.ReadKey();
    }
}