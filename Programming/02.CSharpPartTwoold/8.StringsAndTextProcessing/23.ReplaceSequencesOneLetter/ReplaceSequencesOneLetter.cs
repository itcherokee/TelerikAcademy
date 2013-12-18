using System;
using System.Text;

public class ReplaceSequencesOneLetter
{
    // Write a program that reads a string from the console and replaces 
    // all series of consecutive identical letters with a single one. 

    public static void Main()
    {
        Console.Title = "Replace sequences of character with single one";
        string userInput = "aaaaabbbbbcdddeeeedssaa";
        StringBuilder result = new StringBuilder();
        char currentChar;
        if (userInput.Length < 1)
        {
            Console.WriteLine("No data!");
            return;
        }
        else
        {
            currentChar = userInput[0];
        }

        for (int index = 1; index < userInput.Length; index++)
        {
            if (currentChar != userInput[index] || index == userInput.Length - 1)
            {
                result.Append(currentChar);
                currentChar = userInput[index];
            }
        }

        Console.WriteLine("Initial: {0}", userInput);
        Console.WriteLine("Result: {0}", result.ToString());
    }
}
