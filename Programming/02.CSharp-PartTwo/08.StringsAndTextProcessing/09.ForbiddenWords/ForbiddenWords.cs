using System;
using System.Text;

/// <summary>
/// Таск: "9. We are given a string containing a list of forbidden words and a text containing some 
/// of these words. Write a program that replaces the forbidden words with asterisks."
/// </summary>
public class ForbiddenWords
{
    public static void Main(string[] args)
    {
        Console.Title = "Replace forbidden words in text";

        // Source data - you can change it with other values to test the routine
        string userInput = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string forbiddenWords = "PHP, CLR, Microsoft, today, 4.0";

        // Censor the text
        var result = Censor(userInput, forbiddenWords);

        // Output to Console
        Print(userInput, forbiddenWords, result);
        Console.ReadKey();
    }

    /// <summary>
    /// Apply censorship by evaluating text (<paramref name="input"/>) for forbidden words and if available overides them with asterisks.
    /// </summary>
    /// <param name="input">Text to be analyzed.</param>
    /// <param name="forbiddenWords">List of forbidden words to be "asterisked" in text (<paramref name="input"/>).</param>
    /// <returns>Censored version of text (<paramref name="input"/>).</returns>
    private static string Censor(string input, string forbiddenWords)
    {
        string[] blockedWords = forbiddenWords.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        var result = new StringBuilder(input);
        for (int index = 0; index < blockedWords.Length; index++)
        {
            result.Replace(blockedWords[index], new string('*', blockedWords[index].Length));
        }

        return result.ToString();
    }

    /// <summary>
    /// Output the result to Console in color format.
    /// </summary>
    private static void Print(string text, string forbiddenWords, string censoredText)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Forbidden words: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(forbiddenWords);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nOriginal text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("\nCensored text: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(censoredText);
        Console.ForegroundColor = ConsoleColor.White;
    }
}