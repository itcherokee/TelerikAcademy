using System;
using System.Text;

/// <summary>
/// Task: "23. Write a program that reads a string from the console and replaces all series of 
/// consecutive identical letters with a single one. 
/// Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa"."
/// </summary>
public class ReplaceSequencesOneLetter
{
    public static void Main()
    {
        Console.Title = "Replace sequences of character with single one";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Please enter some text with duplicate letters in words.\nYour input: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string input = Console.ReadLine().Trim() + " ";
        if (input.Length >= 1)
        {
            StringBuilder result = new StringBuilder();
            char currentChar = input[0];

            // Check current char with next ones - if not same => add to final string
            for (int index = 1; index < input.Length; index++)
            {
                if (currentChar != input[index])
                {
                    result.Append(currentChar);
                    currentChar = input[index];
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Initial: {0}", input);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Result: {0}", result.ToString());
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
