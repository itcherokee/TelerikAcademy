using System;
using System.Globalization;
using System.Text.RegularExpressions;

/// <summary>
/// Task: "19. Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
/// Display them in the standard date format for Canada."
/// </summary>
public class PrintsCanadaDates
{
    public static void Main()
    {
        Console.Title = "Extract dates from text and print in Canada format";
        string[] formats = { "dd/MM/yyyy", "d/M/yyyy", "d/MM/yyyy", "dd/M/yyyy" };

        // Source texts - one has dates other no - comment/uncomment to test routine or write down your own.
        // string input = "Today was a beatiful day. All birds are flying and nobody is thinking that tomorrow is new day.";
        string input = "Today 30.09.2013 was a beatiful day. All birds are flying and nobody is thinking that tomorrow is 01.10.2013.";

        // Define & assign regular expression pattern coresponding to dates
        Regex pattern = new Regex(@"(0{0,1}[1-9]|[12][0-9]|3[01])[- /.](0{0,1}[1-9]|1[012])[- /.][0-9]{4}", RegexOptions.IgnoreCase);

        // Find all matches in source of defined pattern
        MatchCollection dates = pattern.Matches(input);

        // Output to Console
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Source text :");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(input);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDates found (shown in Canadian format yyyy-dd-mm): ");

        // Print each matched string to Console
        DateTime date = new DateTime();
        if (dates.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Match match in dates)
            {
                try
                {
                    // Parsing each discovered date as string to DateTime type variable
                    date = DateTime.ParseExact(match.Value, formats, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);

                    // Print the DateTime variable to Console by using CultureInfo specific for Canada as atribute of to String()
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA")));
                }
                catch (ArgumentException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong date format!");
                }
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