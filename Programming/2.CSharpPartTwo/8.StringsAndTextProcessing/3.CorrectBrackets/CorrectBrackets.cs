using System;
using System.Text;

public class CorrectBrackets
{
    // Write a program to check if in a given expression the brackets are put correctly.

    public static void Main()
    {
        Console.Title = "Check for correct brackets within expression";
        Console.Write("Enter the esxpression: ");
        string userInput = Console.ReadLine();
        StringBuilder onlyBrackets = new StringBuilder();
        for (int index = 0; index < userInput.Length; index++)
        {
            if (userInput[index] == '(' || userInput[index] == ')')
            {
                onlyBrackets.Append(userInput[index]);
            }
        }

        string result = onlyBrackets.ToString();
        int bracketCount = 0;
        for (int index = 0; index < result.Length; index++)
        {
            bracketCount += result[index] == '(' ? 1 : -1;
            if (bracketCount < 0)
            {
                break;
            }
        }

        if (bracketCount > 0 || bracketCount < 0)
        {
            Console.WriteLine("There are wrong brackets within expression!");
        }
        else
        {
            Console.WriteLine("Everything is OK with your brackets.");
        }
    }
}