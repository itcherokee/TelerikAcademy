using System;
using System.Text;

public class TagsUpperCaseStringBuilder
{
    // You are given a text. Write a program that changes the text in all regions surrounded 
    // by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. 

    // Version 2 = Using StringBuilder for the result

    public static void Main()
    {
        Console.Title = "Convert to UpperCase text in tags";
        string userInput = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string startTag = "<upcase>";
        string endTag = "</upcase>";
        int startIndex = -1;
        int endIndex = -1;
        int token = 0;
        string tempContent = string.Empty;
        StringBuilder result = new StringBuilder();
        while (true)
        {
            startIndex = userInput.IndexOf(startTag, ++startIndex);
            if (startIndex < 0)
            {
                if (endIndex > 0 && endIndex < userInput.Length)
                {
                    result.Append(userInput, endIndex + endTag.Length, userInput.Length - (endIndex + endTag.Length));
                }

                break;
            }
            else
            {
                result.Append(userInput, token, startIndex - token);
                endIndex = userInput.IndexOf(endTag, startIndex);
                result.Append(userInput.Substring(startIndex + startTag.Length, endIndex - startIndex - startTag.Length).ToUpper());
                token = endIndex + endTag.Length;
            }
        }

        Console.WriteLine("Modified text: " + result.ToString());
    }
}