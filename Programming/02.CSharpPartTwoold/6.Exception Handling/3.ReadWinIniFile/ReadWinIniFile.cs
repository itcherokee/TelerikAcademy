using System;
using System.IO;
using System.Security;

public class ReadWinIniFile
{
    // Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
    // reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
    // Be sure to catch all possible exceptions and print user-friendly error messages.

    public static void Main()
    {
        Console.Title = "Show content of Win.ini file in the Console";
        string path = @"%SystemRoot%\Win.ini";
        try
        {
            string pathToWinIni = Environment.ExpandEnvironmentVariables(path);
            try
            {
                string fileText = File.ReadAllText(pathToWinIni);
                Console.WriteLine(fileText);
            }
            catch (PathTooLongException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine("File {0} is not found!", ex.FileName);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
            catch (SecurityException ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}