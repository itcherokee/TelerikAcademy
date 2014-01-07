using System;
using System.Text;

/// <summary>
/// Task: "15. Write a program that replaces in a HTML document given as string all 
/// the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL]."
/// </summary>
public class ReplaceATagsWithURL
{
    public static void Main()
    {
        string input = @"<p>Please visit <a name=""link"" href=""http://academy.telerik.com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";

        // Convert text
        string result = ParseAnchors(input);

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Original document: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nParsed document: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(result);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }

    /// <summary>
    /// Convert all anchor tags (<a href="…">…</a>) to [URL=…]…/URL] tags.
    /// </summary>
    /// <param name="input">Text over which the conversion should take place.</param>
    /// <returns>String with converted tags.</returns>
    private static string ParseAnchors(string input)
    {
        // Constants with tags elements
        const string AnchorStart = "<a ";
        const string AnchorEnd = "</a>";
        const string AnchorHrefStart = @"href=""";
        const string AnchorHrefEnd = @""">";
        const string UrlStart = "[URL=";
        const string UrlStartClose = "]";
        const string UrlEnd = "[/URL]";

        // Algorythm
        int startAIndex = 0;
        int startAddrIndex = 0;
        int endAddrIndex = 0;
        StringBuilder output = new StringBuilder(input);

        // Replace all closing parts of tags
        output.Replace(AnchorEnd, UrlEnd);

        // Find starting anchor index
        startAIndex = output.ToString().IndexOf(AnchorStart, startAIndex, StringComparison.OrdinalIgnoreCase);

        // Find href index of anchor
        startAddrIndex = output.ToString().IndexOf(AnchorHrefStart, startAddrIndex, StringComparison.OrdinalIgnoreCase) + AnchorHrefStart.Length;

        // Replace the anchor with url tag 
        while (startAIndex != -1)
        {
            output.Replace(output.ToString().Substring(startAIndex, startAddrIndex - startAIndex), UrlStart, startAIndex, startAddrIndex - startAIndex);
            endAddrIndex = output.ToString().IndexOf(AnchorHrefEnd, endAddrIndex, StringComparison.OrdinalIgnoreCase);
            output.Replace(output.ToString().Substring(endAddrIndex, AnchorHrefEnd.Length), UrlStartClose, endAddrIndex, AnchorHrefEnd.Length);
            startAIndex = output.ToString().IndexOf(AnchorStart, ++startAIndex, StringComparison.OrdinalIgnoreCase);
            startAddrIndex = output.ToString().IndexOf(AnchorHrefStart, ++startAddrIndex, StringComparison.OrdinalIgnoreCase) + +AnchorHrefStart.Length;
            endAddrIndex++;
        }

        return output.ToString();
    }
}