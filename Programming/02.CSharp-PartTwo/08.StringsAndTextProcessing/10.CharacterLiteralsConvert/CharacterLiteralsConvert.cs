using System;

/// <summary>
/// Task: "Write a program that converts a string to a sequence of C# Unicode character literals.
/// Use format strings."
/// </summary>
public class CharacterLiteralsConvert
{
    public static void Main()
    {
        Console.Title = "Convert string to seq  uence of character literals";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Please, enter some letters, words or sentance: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string userInput = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nYour input converted to Unicode: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int index = 0; index < userInput.Length; index++)
        {
            Console.Write("\\u{0:X4}", (int)userInput[index]);
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.ReadKey();
    }
}