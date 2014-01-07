using System;
using System.Text;

/// <summary>
/// Task: "20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe"."
/// </summary>
public class Palindromes
{
    public static void Main()
    {
        Console.Title = "Extract palindromes from text";

        // Source data - you can change it with your text in order to check the routine
        string input = "ABBA is the most fancy pop group of the 70's. All programs must be started from the executable file that ends with exe.";

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPalindromes found: ");
        Console.ForegroundColor = ConsoleColor.Green;

        // Remove any possible (attached to words) punctuation signs.
        var modifiedInput = new StringBuilder(input);
        modifiedInput.Replace(".", " ");
        modifiedInput.Replace(",", " ");
        modifiedInput.Replace("!", " ");
        modifiedInput.Replace("?", " ");
        modifiedInput.Replace(":", " ");
        modifiedInput.Replace(";", " ");
        modifiedInput.Replace("\'", " ");
        modifiedInput.Replace("\"", " ");
        modifiedInput.Replace("\\", " ");
        modifiedInput.Replace("|", " ");
        modifiedInput.Replace("@", " ");
        modifiedInput.Replace("(", " ");
        modifiedInput.Replace(")", " ");
        modifiedInput.Replace("-", " ");

        // Split text into words
        string[] words = modifiedInput.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Check each word does it a palindrome
        bool isTherePalindromes = false;
        foreach (var word in words)
        {
            if (word.Length > 1)
            {
                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                    isTherePalindromes = true;
                }
            }
        }

        if (!isTherePalindromes)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<none>");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    /// <summary>
    /// Checks does the privoded string (<paramref name="word"/>) is palindrome.
    /// </summary>
    /// <param name="word">String to be checked is it a palindrome.</param>
    /// <returns>True is string is palindrome, False if not.</returns>
    private static bool IsPalindrome(string word)
    {
        bool palindrome = true;

        for (int index = 0; index < word.Length; index++)
        {
            if (index >= word.Length - 1 - index)
            {
                break;
            }

            if (word[index] != word[word.Length - 1 - index])
            {
                palindrome = false;
                break;
            }
        }

        return palindrome;
    }
}