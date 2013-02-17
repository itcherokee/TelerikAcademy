using System;

public class TagsUpperCase
{
    // You are given a text. Write a program that changes the text in all regions surrounded 
    // by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 

    public static void Main()
    {
        Console.Title = "Convert to UpperCase text in tags";
        string userInput = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string startTag = "<upcase>";
        string endTag = "</upcase>";
        int startIndex = -1;
        int endIndex = -1;
        string tempContent = string.Empty;
        while (true)
        {
            startIndex = userInput.IndexOf(startTag, ++startIndex);
            if (startIndex < 0)
            {
                break;
            }
            else
            {
                endIndex = userInput.IndexOf(endTag, startIndex);
                tempContent = userInput.Substring(startIndex + startTag.Length, endIndex - startIndex - startTag.Length).ToUpper();
                userInput = userInput.Remove(startIndex, endIndex + endTag.Length - startIndex);
                userInput = userInput.Insert(startIndex, tempContent);
            }
        }

        Console.WriteLine("Modified text: " + userInput);
    }
}