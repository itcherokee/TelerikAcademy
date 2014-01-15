using System;
using System.ComponentModel;
using System.Text;

/// <summary>
/// Task: "13. Write a program that reverses the words in given sentence."
/// </summary>
public class ReverseWordsInSentence
{
    public static void Main()
    {
        Console.Title = "Reverse words in a sentence";
        
        // string userInput = "Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.";
        string userInput = "C# is not C++, not PHP and not Delphi!";

        // Reverse words
        var result = ReverseWords(userInput);

        // Output to Conosle
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Initial text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(userInput);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nReversed words: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    /// <summary>
    /// Reverses only words in a text without touching any punctuation marks.
    /// </summary>
    /// <param name="text">Initial text where words need to be reversed.</param>
    /// <returns>Text with reversed words.</returns>
    private static string ReverseWords(string text)
    {
        string[] words = text.Split(new[] { ' ', '.', ',', '!', '?', ':', '"', '(', ')', '[', ']', '{', '}', '/', '\\', '-' }, StringSplitOptions.RemoveEmptyEntries);
        int startIndex = 0;
        int endIndex = text.Length - 1;
        var result = new StringBuilder(text);
        for (int index = 0; index < words.Length; index++)
        {
            startIndex = result.ToString().IndexOf(words[index], startIndex, StringComparison.OrdinalIgnoreCase);
            endIndex = result.ToString().LastIndexOf(words[words.Length - 1 - index], endIndex, StringComparison.OrdinalIgnoreCase);
            if (startIndex >= endIndex)
            {
                break;
            }

            result.Replace(words[words.Length - 1 - index], words[index], endIndex, words[words.Length - 1 - index].Length);
            result.Replace(words[index], words[words.Length - 1 - index], startIndex, words[index].Length);
            startIndex += words[words.Length - 1 - index].Length;
            endIndex += words[words.Length - 1 - index].Length - words[index].Length - 1;
        }

        return result.ToString();
    }
}