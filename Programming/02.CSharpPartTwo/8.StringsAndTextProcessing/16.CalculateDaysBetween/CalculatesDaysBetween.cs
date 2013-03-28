using System;

public class CalculatesDaysBetween
{
    // Write a program that reads two dates in the format: day.month.year 
    // and calculates the number of days between them. 

    public static void Main()
    {
        Console.Title = "Calculate days between two dates";
        Console.Write("Enter the first date (dd.mm.yyyy): ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Entered date: {0}", firstDate.ToString("d"));
        Console.Write("Enter the second date (dd.mm.yyyy): ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Entered date: {0}", secondDate.ToString("d"));
        TimeSpan deltaTime = new TimeSpan();
        deltaTime = secondDate - firstDate;
        Console.WriteLine("Distance: {0}", Math.Abs(deltaTime.TotalDays).ToString());
    }
}