using System;
using System.Net;

/// <summary>
/// Task: "4. Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
/// and stores it the current directory. Find in Google how to download files in C#. Be sure to catch all 
/// exceptions and to free any used resources in the finally block."
/// </summary>
public class DownloadFile
{
    public static void Main()
    {
        Console.Title = "Download file from the Internet";
        const string AddressUri = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string currentFolderAndFileName = Environment.CurrentDirectory + "Logo-BASD.jpg";
        WebClient webDownloader = new WebClient();
        try
        {
            webDownloader.DownloadFile(new Uri(AddressUri), currentFolderAndFileName);
            Console.WriteLine("File downloaded (check program bin folder)!");
        }
        catch (WebException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: Error while downloading or wrong web address provided.");
        }
        catch (ArgumentNullException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: URI and/or file name can not be empty!");
        }
        catch (NotSupportedException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("Error: The method has been called simultaneously on multiple threads.");
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("There were a major problem! Try again later.");
        }
        finally
        {
            webDownloader.Dispose();
        }
    }
}