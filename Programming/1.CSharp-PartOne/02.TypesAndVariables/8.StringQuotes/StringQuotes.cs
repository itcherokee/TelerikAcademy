using System;

class StringQuotes
{
    static void Main()
    {
        // Declare two string variables and assign them with following value: 
        // The "use" of quotations causes difficulties."
        // Do the above in two different ways: with and without using quoted strings.
        string quotedString = @"The ""use"" of quotations causes difficulties.";
        string nonQuotedString = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(quotedString);
        Console.WriteLine(nonQuotedString);
        Console.ReadKey();
    }
}
