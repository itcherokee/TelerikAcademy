using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Task: "21. Write a program that reads a string from the console and prints all different letters 
/// in the string along with information how many times each letter is found."
/// </summary>
public class NumberOfLetters
{
    public static void Main()
    {
        Console.Title = "Find the number of any letter in the string";
        string input = "ABBA is the most fancy pop group of the 70's. All programs must be started from the executable file that ends with exe.";

        // Deaffine and assign a regular expression pattern that match any letter (only letters, no numbers, etc.)
        Regex pattern = new Regex(@"[A-Za-z]");

        // Evaluate regex pattern against text and collect only letters (all of them)
        // Before applying pattern, text is converted to capital letters as it doesn't 
        // matter if letter is Upper or Lower case, it is one and the same letter.
        MatchCollection onlyLetters = pattern.Matches(input.ToUpper());

        // As in the alphabet there are no duplicate letters, we use SortedList 
        // It is like List, but sorted and providing options for storing inside key/value pairs
        // - key will be found letters and in each value we will store counter of appearances for that letter in text
        SortedList<string, int> alphabet = new SortedList<string, int>();
        foreach (Match matched in onlyLetters)
        {
            // Check did we already discovered current letter
            if (alphabet.ContainsKey(matched.Value))
            {
                // letter has been discovered previously, so we just increase the counter
                alphabet[matched.Value]++;
            }
            else
            {
                // letter is first occurance, so we add it to SortedList and set the counter to one
                alphabet.Add(matched.Value, 1);
            }
        }

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDifferent letters and how many time they have been found:");
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (KeyValuePair<string, int> item in alphabet)
        {
            Console.WriteLine("{0} = {1}", item.Key.ToString(CultureInfo.InvariantCulture), item.Value);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}