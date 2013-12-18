using System;

public class NumberOfWorkdays
{
    // Write a method that calculates the number of workdays between today and given date, 
    // passed as parameter. Consider that workdays are all days from Monday to Friday 
    // except a fixed list of public holidays specified preliminary as array.

    public static void Main()
    {
        Console.Title = "Calculate workdays between today and given date";
        bool noError = false;
        DateTime givenDate;
        do
        {
            Console.Write("Enter the date in the future (format: DD/MM/YYYY):");
            noError = DateTime.TryParse(Console.ReadLine(), out givenDate);
            if (!noError)
            {
                Console.WriteLine("Wrong input detected!\nTry again <press Enter>....");
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!noError);
        Console.WriteLine("Number of working days between both dates is/are: {0}", CalculateWorkingDays(givenDate));
    }

    private static int CalculateWorkingDays(DateTime futureDate)
    {
        DateTime currentDate = DateTime.Today;
        int workDays = 0;
        DateTime[] publicHolidays = new DateTime[] 
            {   
              new DateTime(2013, 3, 3), new DateTime(2013, 5, 1), new DateTime(2013, 5, 2), 
              new DateTime(2013, 5, 3), new DateTime(2013, 5, 4), new DateTime(2013, 5, 5), 
              new DateTime(2013, 5, 6), new DateTime(2013, 5, 24), new DateTime(2013, 9, 6), 
              new DateTime(2013, 9, 22), new DateTime(2013, 12, 24), new DateTime(2013, 12, 25), 
              new DateTime(2013, 12, 26), new DateTime(2013, 12, 31) 
            };

        TimeSpan totalDays = futureDate - currentDate;
        DateTime workingDate;
        Array.Sort(publicHolidays);
        for (int count = 0; count < totalDays.Days; count++)
        {
            workingDate = currentDate.AddDays(count);
            if (workingDate.DayOfWeek != DayOfWeek.Saturday && workingDate.DayOfWeek != DayOfWeek.Sunday)
            {
                if (Array.BinarySearch(publicHolidays, workingDate) < 0)
                {
                    workDays++;
                }
            }
        }

        return workDays;
    }
}