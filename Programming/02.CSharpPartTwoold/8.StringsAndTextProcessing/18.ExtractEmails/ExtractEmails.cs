using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class ExtractEmails
{
    // Write a program for extracting all email addresses from given text. 
    // All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

    public static void Main()
    {
        Console.Title = "Extract all e-mails";
        string userInput = "a@alo.com sdfjsfdkjhsdkjfsk wer@gogo.com";
        Regex pattern = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        MatchCollection result = pattern.Matches(userInput);
        Console.WriteLine("E-mails found: ");
        foreach (Match match in result)
        {
            Console.WriteLine(match.Value);
        }
    }
}