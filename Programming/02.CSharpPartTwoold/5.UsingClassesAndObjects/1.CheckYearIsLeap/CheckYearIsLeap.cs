using System;

public class CheckYearIsLeap
{
    // Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

    public static void Main()
    {
        Console.Title = "Check year is leap";
        bool noError = false;
        int yearChecked;
        do
        {
            Console.Write("Enter the year to be checked is it leap: ");
            noError = int.TryParse(Console.ReadLine(), out yearChecked);
            if (!noError)
            {
                Console.WriteLine("Wrong input detected!\nTry again <press Enter>....");
                Console.ReadKey();
                Console.Clear();
            }
        } 
        while (!noError);
        bool isLeap = DateTime.IsLeapYear(yearChecked);
        Console.WriteLine("Year {0} {1} Leap.", yearChecked, isLeap ? "is" : "is NOT");
    }
}
