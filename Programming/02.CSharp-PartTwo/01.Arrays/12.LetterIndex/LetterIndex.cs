using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Task: "12. Write a program that creates an array containing all letters from the alphabet (A-Z). 
/// Read a word from the console and print the index of each of its letters in the array."
/// </summary>
public class LetterIndex
{
    public static void Main()
    {
        // Create the array with alphabet (A-Z) - no small letters
        char[] alphabet = new char[26];
        for (int index = 0; index < 26; index++)
        {
            alphabet[index] = (char)(index + 65);
        }

        // Read word from Console and change the case of letters to capital 
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Plaese enter a word to search for letter indexes: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string word = Console.ReadLine().ToUpper();
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n*** Solution ***\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Alphabet: \n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(string.Join(",", alphabet));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLetter   Index   ASCII");
        Console.WriteLine(new string('-', 22));
        Console.ForegroundColor = ConsoleColor.Yellow;
        int letterIndex = 0;
        string arrayIndex = string.Empty;
        for (int index = 0; index < word.Length; index++)
        {
            letterIndex = Array.BinarySearch(alphabet, word[index]);

            // checks does symbol exists in our array - everything else than capital Letters A..Z
            if (letterIndex < 0)
            {
                arrayIndex = "-";
            }
            else
            {
                arrayIndex = letterIndex.ToString();
            }

            Console.WriteLine("  {0,-7}  {1,-6} {2}", word[index], arrayIndex, (int)letterIndex + 65);
        }
    }
}