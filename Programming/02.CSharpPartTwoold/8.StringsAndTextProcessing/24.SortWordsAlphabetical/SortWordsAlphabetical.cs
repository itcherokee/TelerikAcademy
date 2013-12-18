using System;

public class SortWordsAlphabetical
{
    // Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

    public static void Main()
    {
        Console.Title = "Read a list and sorts words alphabetically";
        string userInput = "home word aplhabet and castle tuple windows waste aero crunch etc";
        string[] words = userInput.Split();
        Array.Sort(words);
        Console.WriteLine("Result: {0}", string.Join(", ", words));
    }
}