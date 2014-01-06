using System;
using System.IO;
using System.Security;

/// <summary>
/// Task: "3. Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
/// reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). 
/// Be sure to catch all possible exceptions and print user-friendly error messages."
/// </summary>
public class ReadTextFile
{
    public static void Main()
    {
        Console.Title = "Show content of Win.ini file in the Console";
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Enter file to open along with the path (e.g. C:\\WINDOWS\\win.ini)");
        Console.WriteLine(" - you can use Windows Environment Variables as well (%SystemRoot%).");
        Console.Write("Path + File name: ");
        Console.ForegroundColor = ConsoleColor.Green;
        string pathAndFile = Console.ReadLine();
        try
        {
            try
            {
                string fileText = File.ReadAllText(Environment.ExpandEnvironmentVariables(pathAndFile));
                Console.WriteLine("\nFile's content follows:\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
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

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
    }
}