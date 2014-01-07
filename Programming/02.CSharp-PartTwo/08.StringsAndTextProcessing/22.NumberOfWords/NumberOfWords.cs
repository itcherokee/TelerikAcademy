using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Task: "22. Write a program that reads a string from the console and lists all different words 
/// in the string along with information how many times each word is found."
/// 
/// Note:   The same approach as in task 21 has been used, but instead of letters, we count words.
///         Code is totally reused from there, only the regular expression pattern has been changed.
///         You can see the detailed comments there as they apply to this task as well.
/// </summary>
public class NumberOfWords
{
    public static void Main()
    {
        Console.Title = "Find the number of any word in a string";
        string input = "ABBA is the most fancy pop group of the 70's. And here comes the new pop culture in 80's - Sandra, Madona, etc. Madona, Sandra, ABBA and the others was awesome";
        Regex pattern = new Regex(@"[a-zA-Z]+");
        MatchCollection allWords = pattern.Matches(input);
        SortedList<string, int> distinctWords = new SortedList<string, int>();
        foreach (Match matched in allWords)
        {
            if (matched.Value.Length > 1)
            {
                if (distinctWords.ContainsKey(matched.Value))
                {
                    distinctWords[matched.Value]++;
                }
                else
                {
                    distinctWords.Add(matched.Value, 1);
                }
            }
        }

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Different words and how many times they have been found:");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (KeyValuePair<string, int> item in distinctWords)
        {
            Console.WriteLine("{0} = {1}", item.Key.ToString(), item.Value.ToString());
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}