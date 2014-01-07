using System;
using System.Text;

/// <summary>
/// Task: "2. Write a program that reads a string, reverses it and prints the result at the console.
/// Example: "sample" -> "elpmas"."
/// </summary>
public class ReverseString
{
    public static void Main()
    {
        Console.Title = "Reverse a string";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter a string to reverse it: ");
        Console.WriteLine("Here is the string reversed: " + Reverse(Console.ReadLine()));
    }

    /// <summary>
    /// Reverse the string.
    /// </summary>
    /// <param name="text">String to be reversed.</param>
    /// <returns>Reversed string.</returns>
    private static string Reverse(string text)
    {
        var reversedString = new StringBuilder(text.Length);
        for (int index = text.Length - 1; index >= 0; index--)
        {
            reversedString.Append(text[index]);
        }

        return reversedString.ToString();
    }
}