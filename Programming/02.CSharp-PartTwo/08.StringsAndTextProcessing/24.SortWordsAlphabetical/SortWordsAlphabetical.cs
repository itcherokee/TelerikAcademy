using System;

/// <summary>
/// Task: "24. Write a program that reads a list of words, separated by spaces and prints the list 
/// in an alphabetical order."
/// </summary>
public class SortWordsAlphabetical
{
    public static void Main()
    {
        Console.Title = "Read a list and sorts words alphabetically";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Please enter some words: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string input = Console.ReadLine();
        if (input != null)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nSorted words: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Join(" ", words));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No data!");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}