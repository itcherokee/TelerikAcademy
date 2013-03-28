using System;
using System.Text;

public class ReplaceATagsWithURL
{
    // Write a program that replaces in a HTML document given as string 
    // all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

    public static void Main()
    {
        string userInput = @"<p>Please visit <a name=""link"" href=""http://academy.telerik. com"">our site</a> to choose a training course. Also visit <a href=""www.devbg.org"">our forum</a> to discuss the courses.</p>";
        string toSearchABegin = "<a ";
        string toSearchHref = @"href=""";
        string toSearchAEnd = @""">";
        string toSearchEnd = "</a>";
        string newStartBegin = "[URL=";
        string newStartEnd = "]";
        string newEnd = "[/URL]";
        int startAIndex = 0;
        int startAddrIndex = 0;
        int endAddrIndex = 0;
        StringBuilder result = new StringBuilder(userInput);
        result.Replace(toSearchEnd, newEnd);
        startAIndex = result.ToString().IndexOf(toSearchABegin, startAIndex);
        startAddrIndex = result.ToString().IndexOf(toSearchHref, startAddrIndex) + 6;
        while (startAIndex != -1)
        {
            result.Replace(result.ToString().Substring(startAIndex, startAddrIndex - startAIndex), newStartBegin, startAIndex, startAddrIndex - startAIndex);
            endAddrIndex = result.ToString().IndexOf(toSearchAEnd, endAddrIndex);
            result.Replace(result.ToString().Substring(endAddrIndex, toSearchAEnd.Length), newStartEnd, endAddrIndex, toSearchAEnd.Length);
            startAIndex = result.ToString().IndexOf(toSearchABegin, ++startAIndex);
            startAddrIndex = result.ToString().IndexOf(toSearchHref, ++startAddrIndex) + 6;
            endAddrIndex++;
        }

        Console.WriteLine(result.ToString());
    }
}