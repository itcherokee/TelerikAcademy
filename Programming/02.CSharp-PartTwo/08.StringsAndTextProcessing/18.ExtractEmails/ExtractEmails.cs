using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Task: "18. Write a program for extracting all email addresses from given text. All substrings that 
/// match the format <identifier>@<host>…<domain> should be recognized as emails."
/// </summary>
public class ExtractEmails
{
    public static void Main()
    {
        Console.Title = "Extract all e-mails";

        // Source - one text has e-mails, other no - comment/uncomment to test routine
        // string input = "This is my house.";
        string input = "This is my email a@alo.com and this one is of my brother wer@gogo.com. Regarding company, it has a web site www.kukuruku.nz";

        // Define & assign regular expression pattern coresponding to e-mails
        Regex pattern = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

        // Find all matches in source of defined pattern
        MatchCollection emails = pattern.Matches(input);

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\ne-Mails found: ");

        // Print each matched string to Console
        if (emails.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Match mail in emails)
            {
                Console.WriteLine(mail.Value);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("<none>");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}