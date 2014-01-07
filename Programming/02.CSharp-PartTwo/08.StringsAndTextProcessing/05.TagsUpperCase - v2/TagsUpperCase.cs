using System;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Task: "5. You are given a text. Write a program that changes the text in all regions surrounded 
/// by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested."
/// 
/// Note: This is a second varinat with using of StringBuilder for result.
/// </summary>
public class TagsUpperCase
{
    public static void Main()
    {
        Console.Title = "Convert to UpperCase text in tags";

        // Source data - you can change the values in order to test the routine
        string input = "We are <l>living</l> in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string tag = "upcase";

        // Convert the content to upper case between the tags
        var result = TagContentToUpper(input, tag);

        // Output to Console
        Print(tag, input, result);
        Console.ReadKey();
    }

    /// <summary>
    /// Convert to upper case any content surounded by specified <paramref name="tag"/>s.
    /// </summary>
    /// <param name="input">Text that is going to be searched for specified <paramref name="tag"/>.</param>
    /// <param name="tag">Tag that is going to be searched within <paramref name="input"/>.</param>
    /// <returns>Text without tags, but content converted to upper case.</returns>
    private static string TagContentToUpper(string input, string tag)
    {
        string startTag = "<" + tag + ">";
        string endTag = "</" + tag + ">";
        int startIndex = -1;
        int endIndex = -1;
        int token = 0;
        var result = new StringBuilder();
        while (true)
        {
            startIndex = input.IndexOf(startTag, ++startIndex, System.StringComparison.OrdinalIgnoreCase);
            if (startIndex < 0)
            {
                if (endIndex > 0 && endIndex < input.Length)
                {
                    result.Append(input, endIndex + endTag.Length, input.Length - (endIndex + endTag.Length));
                }

                break;
            }

            result.Append(input, token, startIndex - token);
            endIndex = input.IndexOf(endTag, startIndex, System.StringComparison.OrdinalIgnoreCase);
            result.Append(input.Substring(startIndex + startTag.Length, endIndex - startIndex - startTag.Length).ToUpper());
            token = endIndex + endTag.Length;
        }

        return result.ToString();
    }

    /// <summary>
    /// Print result to Console in color formating.
    /// </summary>
    /// <param name="tag">Tag searched within <paramref name="input"/>.</param>
    /// <param name="input">Source text used to be searched for specified <paramref name="tag"/>.</param>
    /// <param name="result">Text without tags, but content converted to upper case.</param>
    private static void Print(string tag, string input, string result)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\"Tag\" to be searched: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("<" + tag + "></" + tag + ">\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Original text: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nModified text: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ForegroundColor = ConsoleColor.White;
    }
}