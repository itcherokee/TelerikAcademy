using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class NumberOfLetters
{
    // Write a program that reads a string from the console and prints all different 
    // letters in the string along with information how many times each letter is found. 

    public static void Main()
    {
        Console.Title = "Find the number of any letter in the string";
        string userInput = "ABBA is the most fancy pop group of the 70's. All programs must be started from the executable file that ends with exe.";
        Regex pattern = new Regex(@"[A-Za-z]");
        MatchCollection onlyLetters = pattern.Matches(userInput);
        SortedList<string, int> alphabet = new SortedList<string, int>();
        foreach (Match matched in onlyLetters)
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

        Console.WriteLine("Different letters and their number of appearance:");
        foreach (KeyValuePair<string, int> item in alphabet)
        {
            Console.WriteLine("{0} = {1}", item.Key.ToString(), item.Value.ToString());
        }
    }
}