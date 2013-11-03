using System;

/// <summary>
/// Task: "12. * Write a program to read your age from the console and print how old you will be after 10 years."
/// </summary>
public class PrintMyAgeAfterTenYears
{
    public static void Main()
    {
        Console.Title = "Calculate your age after 10 years.";
        int currentAge = 0;
        bool isConverted = false;
        while (!isConverted)
        {
            Console.Write("Type you current age: ");
            isConverted = int.TryParse(Console.ReadLine(), out currentAge);
            if (!isConverted)
            {
                Console.WriteLine("Wrong input! Enter your age using digits. \n<Press any key...>");
                Console.ReadKey();
                Console.Clear();
            }
        }

        DateTime ageAfterTenYears = new DateTime(currentAge, 1, 1).AddYears(10);
        Console.WriteLine("Your age after 10 years will be: {0}", ageAfterTenYears.Year);
        Console.ReadKey();
    }
}