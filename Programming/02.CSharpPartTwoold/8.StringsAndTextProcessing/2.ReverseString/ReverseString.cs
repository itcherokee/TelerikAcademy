using System;
using System.Text;

public class ReverseString
{
    // Write a program that reads a string, reverses it and prints the result at the console.

    public static void Main()
    {
        Console.Title = "Reverse a string";
        Console.Write("Enter a string to reverse it: ");
        Console.WriteLine("Here is the result: " + Reverse(Console.ReadLine()));
    }

    private static string Reverse(string text)
    {
        StringBuilder result = new StringBuilder();
        for (int index = text.Length - 1; index >= 0; index--)
        {
            result.Append(text[index]);
        }

        return result.ToString();
    }
}