using System;

public class ReplaceWithAsterics
{
    // Write a program that reads from the console a string of maximum 20 characters. 
    // If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
    // Print the result string into the console

    public static void Main()
    {
        Console.Title = "Modify string of 20 characters";
        Console.Write("Enter string to be edited: ");
        string userInput = Console.ReadLine();
        userInput = userInput.Length > 20 ? userInput.Remove(20) : userInput + new string('*', 20 - userInput.Length);
        Console.WriteLine("Result: " + userInput);
    }
}
