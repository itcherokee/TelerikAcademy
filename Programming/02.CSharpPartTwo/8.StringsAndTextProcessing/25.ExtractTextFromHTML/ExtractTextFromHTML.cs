using System;
using System.Text;

public class ExtractTextFromHTML
{
    // Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. 

    public static void Main()
    {
        Console.Title = "Return only text from HTML file (no tags)";
        string userInput = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik " +
                            "Academy</a>aims to provide free real-world practical training for young people who want to turn" +
                            " into skillful .NET software engineers.</p></body></html>";
        StringBuilder result = new StringBuilder();
        char previousChar;
        bool inString = false;
        for (int index = 1; index < userInput.Length; index++)
        {
            previousChar = userInput[index - 1];
            if (previousChar == '>' && userInput[index] != '<')
            {
                inString = true;
            }
            else if (userInput[index] == '<' && inString)
            {
                result.Append(" ");
                inString = false;
            }

            if (inString)
            {
                result.Append(userInput[index]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}