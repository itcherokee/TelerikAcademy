using System;
using System.Text;

public class ForbiddenWords
{
    // We are given a string containing a list of forbidden words and a text containing some of these words. 
    // Write a program that replaces the forbidden words with asterisks. 

    public static void Main(string[] args)
    {
        Console.Title = "Replace forbidden words in text";
        string userInput = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string forbiddenWords = "PHP, CLR, Microsoft, today, 4.0";
        string[] blockedWords = forbiddenWords.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder result = new StringBuilder(userInput);
        for (int index = 0; index < blockedWords.Length; index++)
        {
            result.Replace(blockedWords[index], new string('*', blockedWords[index].Length));
        }

        Console.WriteLine(result.ToString());
    }
}