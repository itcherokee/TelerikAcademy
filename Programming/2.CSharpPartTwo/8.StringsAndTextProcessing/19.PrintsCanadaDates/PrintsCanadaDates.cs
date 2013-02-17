using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class PrintsCanadaDates
{
    // Write a program that extracts from a given text all dates that 
    // match the format DD.MM.YYYY. Display them in the standard date format for Canada. 

    public static void Main()
    {
        Console.Title = "Extract dates from text and print in Canada format";
        string userInput = "Today 20.12.2012 was a beatiful day. All birds are flying and nobody is thinking that tomorrow is 21.12.2012.";
        Regex pattern = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)[0-9]{2}", RegexOptions.IgnoreCase);
        MatchCollection result = pattern.Matches(userInput);
        Console.WriteLine("Dates found: ");
        DateTime date = new DateTime();
        foreach (Match match in result)
        {
            try
            {
                date = DateTime.ParseExact(match.Value, "dd.mm.yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA")));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong date format!");
            }
        }
    }
}