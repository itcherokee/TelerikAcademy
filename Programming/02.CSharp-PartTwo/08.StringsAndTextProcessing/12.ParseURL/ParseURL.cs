using System;

/// <summary>
/// Task: "12. Write a program that parses an URL address given in the format:
/// [protocol]://[server]/[resource] 
/// and extracts from it the [protocol], [server] and [resource] elements. "
/// </summary>
public class ParseURL
{
    public static void Main()
    {
        Console.Title = "Parse an URL";
        Console.ForegroundColor = ConsoleColor.White;
        string userInput = "http://www.devbg.org/forum/index.php";

        // string userInput = "https://mail.yahoo.com/login.aspx";
        Console.WriteLine("URL: {0}\n", userInput);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Parsed address\n==============");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0,-10}: \"{1}\"", "[protocol]", userInput.Substring(0, userInput.IndexOf(':')));
        int startIndex = userInput.IndexOf("://", StringComparison.OrdinalIgnoreCase) + 3;
        int endIndex = userInput.IndexOf('/', startIndex);
        Console.WriteLine("{0,-10}: \"{1}\"", "[server]", userInput.Substring(startIndex, endIndex - startIndex));
        Console.WriteLine("{0,-10}: \"{1}\"", "[resource]", userInput.Substring(endIndex, userInput.Length - endIndex));
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}