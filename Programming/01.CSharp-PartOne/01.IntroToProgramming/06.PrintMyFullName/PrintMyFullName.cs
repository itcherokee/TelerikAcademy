using System;

/// <summary>
/// Task: "6. Create console application that prints your first and last name."
/// </summary>
public class PrintMyFullName
{
    public static void Main()
    {
        Console.Title = "Print my First and Last name";
        string firstName = "P***r";
        string lastName = "S******v";
        Console.WriteLine("My full name is: {0} {1}", firstName, lastName);
        Console.WriteLine("\n* - Some privacy to keep as requested by the Academy :)");
        Console.ReadKey();
    }
}