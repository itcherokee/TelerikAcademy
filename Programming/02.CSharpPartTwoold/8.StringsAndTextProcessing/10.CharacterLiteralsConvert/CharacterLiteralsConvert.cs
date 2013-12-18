using System;

public class CharacterLiteralsConvert
{
    // Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 

    public static void Main()
    {
        Console.Title = "Convert string to seq  uence of character literals";
        string userInput = "Hi!";
        for (int index = 0; index < userInput.Length; index++)
        {
            Console.Write("\\u{0:X4}", (int)userInput[index]);
        }

        Console.WriteLine();
    }
}