using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class NumberOfWords
{
    // Write a program that reads a string from the console and lists all 
    // different words in the string along with information how many times each word is found.

    public static void Main()
    {
        Console.Title = "Find the number of any word in a string";
        string userInput = "ABBA is the most fancy pop group of the 70's. And here comes the new pop culture in 80's - Sandra, Madona, etc. Madona, Sandra, ABBA and the others was awesome";
        Regex pattern = new Regex(@"[a-zA-Z]+");
        MatchCollection onlyWords = pattern.Matches(userInput);
        SortedList<string, int> alphabet = new SortedList<string, int>();
        foreach (Match matched in onlyWords)
        {
            if (matched.Value.Length > 1)
            {
                if (alphabet.ContainsKey(matched.Value))
                {
                    alphabet[matched.Value]++;
                }
                else
                {
                    alphabet.Add(matched.Value, 1);
                }
            }
        }

        Console.WriteLine("Different words and their number of appearance:");
        foreach (KeyValuePair<string, int> item in alphabet)
        {
            Console.WriteLine("{0} = {1}", item.Key.ToString(), item.Value.ToString());
        }
    }
}