using System;
using System.Text;

/// <summary>
/// Task: "25. Write a program that extracts from given HTML file its title (if available), 
/// and its body text without the HTML tags."
/// </summary>
public class ExtractTextFromHTML
{
    public static void Main()
    {
        Console.Title = "Return only text from HTML file (no tags)";
        string input = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik " +
                            "Academy</a>aims to provide free real-world practical training for young people who want to turn" +
                            " into skillful .NET software engineers.</p></body></html>";
        StringBuilder result = new StringBuilder();
        bool inString = false;
        for (int index = 1; index < input.Length; index++)
        {
            char previousChar = input[index - 1];
            if (previousChar == '>' && input[index] != '<')
            {
                inString = true;
            }
            else if (input[index] == '<' && inString)
            {
                result.Append(" ");
                inString = false;
            }

            if (inString)
            {
                result.Append(input[index]);
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("HTML code (original): ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nOnly text extracted: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result.ToString());
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}