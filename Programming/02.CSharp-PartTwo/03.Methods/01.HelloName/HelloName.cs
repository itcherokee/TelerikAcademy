using System;

/// <summary>
/// Task: "1. Write a method that asks the user for his name and prints “Hello, "name"!" 
/// (for example, “Hello, Peter!”). Write a program to test this method."
/// </summary>
public class HelloName
{
    public static void Main()
    {
        Console.Title = "Ask user for name and print \"Hello <name>!\"";
        Print(EnterName());
        Console.ReadKey();
    }

    // Handles user input
    private static string EnterName()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter your first name: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string firstName = Console.ReadLine();
        return firstName;
    }

    // Output to Console
    private static void Print(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nHello, {0}!\n", name);
    }
}