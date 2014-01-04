using System;

/// <summary>
/// Task: "5. Write a method that calculates the number of workdays between today and given date, 
/// passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed 
/// list of public holidays specified preliminary as array."
/// </summary>
public class NumberOfWorkdays
{
    public static void Main()
    {
        Console.Title = "Calculate workdays between today and given date";
        DateTime givenDate = EnterDate("Enter the date in the future (format: DD/MM/2014):");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Number of working days between both dates is/are: {0}", CalculateWorkingDays(givenDate));
    }

    private static int CalculateWorkingDays(DateTime futureDate)
    {
        DateTime currentDate = DateTime.Today;
        int workDays = 0;
        DateTime[] publicHolidays = 
            {   
              new DateTime(2014, 3, 3), new DateTime(2014, 4, 18), new DateTime(2014, 4, 19),
              new DateTime(2014, 4, 20), new DateTime(2014, 4, 21), new DateTime(2014, 5, 1),
              new DateTime(2014, 5, 6), new DateTime(2014, 5, 24), new DateTime(2014, 9, 6), 
              new DateTime(2014, 9, 22), new DateTime(2014, 12, 24), new DateTime(2014, 12, 25), 
              new DateTime(2014, 12, 26) 
            };

        TimeSpan totalDays = futureDate - currentDate;
        Array.Sort(publicHolidays);
        for (int count = 0; count < totalDays.Days; count++)
        {
            DateTime workingDate = currentDate.AddDays(count);
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

    private static DateTime EnterDate(string message)
    {
        bool isValidInput = default(bool);
        DateTime enteredValue = default(DateTime);
        do
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Yellow;
            isValidInput = DateTime.TryParse(Console.ReadLine(), out enteredValue);
            if (!isValidInput)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered invalid date! Try again <press any key...>");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
            }
        }
        while (!isValidInput);

        Console.ForegroundColor = ConsoleColor.White;
        return enteredValue;
    }
}