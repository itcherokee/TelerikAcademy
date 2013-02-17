using System;
using System.Text.RegularExpressions;

public class Palindromes
{
    // Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    public static void Main()
    {
        Console.Title = "Extract palindromes from text";
        string userInput = "ABBA is the most fancy pop group of the 70's. All programs must be started from the executable file that ends with exe.";
        Regex pattern = new Regex(@"\b(\w+)\b");
        MatchCollection words = pattern.Matches(userInput);
        foreach (Match match in words)
        {
            if (match.Value.Length > 1)
            {
                if (IsItPalindrome(match.Value))
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }

    private static bool IsItPalindrome(string word)
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