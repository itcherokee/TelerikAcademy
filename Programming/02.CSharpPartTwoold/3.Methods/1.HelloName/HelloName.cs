using System;

public class HelloName
{
    // Write a method that asks the user for his name and 
    // prints “Hello, <name>” (for example, “Hello, Peter!”). 
    // Write a program to test this method.

    public static void Main()
    {
        Console.Title = "Ask user for name and print \"Hello <name>!\"";
        NameInputAndPrint();
    }

    private static void NameInputAndPrint()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("\nHello, {0}!", firstName);
    }
}
