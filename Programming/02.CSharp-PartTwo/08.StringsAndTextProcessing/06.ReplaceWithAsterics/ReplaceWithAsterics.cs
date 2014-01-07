using System;

/// <summary>
/// Task: "6. Write a program that reads from the console a string of maximum 20 characters. 
/// If the length of the string is less than 20, the rest of the characters should be filled 
/// with '*'. Print the result string into the console."
/// </summary>
public class ReplaceWithAsterics
{
    public static void Main()
    {
        Console.Title = "Modify string of 20 characters";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter string to be edited: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var userInput = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nParsed string: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Parse(userInput));
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    // Parse input string.
    // - if it is > 20 chars => truncate; 
    // - if it is < 20 chars => add asterics (*) at the end 
    private static string Parse(string input)
    {
        string result = string.Empty;
        if (input != null)
        {
            result = input.Length > 20
                ? input.Remove(20)
                : input + new string('*', 20 - input.Length);
        }

        return result;
    }
}
