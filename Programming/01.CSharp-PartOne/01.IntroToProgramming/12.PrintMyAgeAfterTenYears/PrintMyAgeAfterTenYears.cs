using System;

class PrintMyAgeAfterTenYears
{
    static void Main()
    {
        Console.Write("Type you current age: ");
        int MyCurrentYears = int.Parse(Console.ReadLine()); //този ред може директно да се вмъкне в следващият (без променлива), но става по-нечетимо
        DateTime myAgeAfterTenYears = new DateTime(MyCurrentYears, 1, 1);
        Console.WriteLine("Your age after 10 years will be: {0}", myAgeAfterTenYears.AddYears(10).Year);
    }
}

