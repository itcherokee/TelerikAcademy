using System;
using System.Globalization;
using System.Text;
using System.Threading;

/// <summary>
/// Task: "4. Write a program that finds how many times a substring is contained in a given text
/// (perform case insensitive search)."
/// </summary>
public class CountSubstring
{
    public static void Main()
    {
        Console.Title = "Find how many times a substring in a string appears";
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        // Define source data - you can change them with other ones to test the routines.
        const string UserInput = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        const string SubstringToCount = "in";

        // Count the appearances of substring within the text
        var counter = Count(UserInput, SubstringToCount);

        // Output to Console the result
        Print(UserInput, SubstringToCount, counter);
        Console.ReadKey();
    }

    /// <summary>
    /// Count how many times substring appears in a text (string)
    /// </summary>
    /// <param name="text">Text that is searched for <paramref name="stringToSearch"/>.</param>
    /// <param name="stringToSearch">Substring to be searched within the <paramref name="text"/>.</param>
    /// <returns>Number of times a <paramref name="stringToSearch"/> appeared in a <paramref name="text"/>.</returns>
    private static int Count(string text, string stringToSearch)
    {
        int index = -1;
        int counter = 0;
        while (index < text.Length)
        {
            int currentCounter = text.IndexOf(stringToSearch, ++index, StringComparison.OrdinalIgnoreCase);
            if (currentCounter < 0)
            {
                // End of text reached without discovery of any presence of substring
                break;
            }

            // Move one position of index to right after last discovery of the string
            index = currentCounter;

            // If substring has been discovered, increase counter with one
            counter += currentCounter > -1 ? 1 : 0;
        }

        return counter;
    }

    /// <summary>
    /// Output the result to Console in color format.
    /// </summary>
    /// <param name="text">Text that is searched for <paramref name="stringToSearch"/>.</param>
    /// <param name="stringToSearch">Substring to be searched within the <paramref name="text"/>.</param>
    /// <param name="numberOfAppearances">Total count of appearances of <paramref name="stringToSearch"/> within <paramref name="text"/>.</param>
    private static void Print(string text, string stringToSearch, int numberOfAppearances)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("In text: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nSubstring \"");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(stringToSearch);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\" detected ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(numberOfAppearances);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" times.");
    }
}