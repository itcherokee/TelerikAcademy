using System;
using System.Text;

/// <summary>
/// Task: "3. Write a program to check if in a given expression the brackets are put correctly.
/// Example of correct expression: ((a+b)/5-d).
/// Example of incorrect expression: )(a+b))."
/// </summary>
public class CorrectBrackets
{
    public static void Main()
    {
        Console.Title = "Check for correct brackets within expression";
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Enter the esxpression: ");
        if (IsBracketCorrect(Console.ReadLine()))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Everything is OK with your brackets.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("There are wrong brackets within expression!");
        }

        Console.ReadKey();
    }

    /// <summary>
    /// Checks does the brackets in expression are correct.
    /// </summary>
    /// <param name="expression">Mathematical expression.</param>
    /// <returns>Returns true - if brackets are OK, else returns false.</returns>
    private static bool IsBracketCorrect(string expression)
    {
        var brackets = ExtractBrackets(expression);
        int bracketCount = 0;
        for (int index = 0; index < brackets.Length; index++)
        {
            bracketCount += brackets[index] == '(' ? 1 : -1;
            if (bracketCount < 0)
            {
                break;
            }
        }

        return bracketCount == 0;
    }

    /// <summary>
    /// Extracts brackets from  expression.
    /// </summary>
    /// <param name="expression">Mathematical expression.</param>
    /// <returns>String containing only brackets, keeping their position in expression.</returns>
    private static string ExtractBrackets(string expression)
    {
        var brackets = new StringBuilder(expression.Length);
        for (int index = 0; index < expression.Length; index++)
        {
            if (expression[index] == '(' || expression[index] == ')')
            {
                brackets.Append(expression[index]);
            }
        }

        return brackets.ToString();
    }
}