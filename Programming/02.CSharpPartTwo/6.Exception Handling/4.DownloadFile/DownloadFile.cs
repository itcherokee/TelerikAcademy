using System;
using System.Net;

public class DownloadFile
{
    // Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and 
    // stores it the current directory. Find in Google how to download files in C#. Be sure to catch all 
    // exceptions and to free any used resources in the finally block.

    public static void Main()
    {
        Console.Title = "Download file from the Internet";
        string addressUri = @"http://www.devbg.org/img/Logo-BASD.jpg";
        string currentFolder = Environment.CurrentDirectory + "Logo-BASD.jpg";
        WebClient webDownloader = new WebClient();
        try
        {
            webDownloader.DownloadFile(new Uri(addressUri), currentFolder);
        }
        catch (WebException)
        {
            Console.Error.WriteLine("Error: Error while downloading or wrong web address provided.");
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Error: URI and/or file name can not be empty!");
        }
        catch (NotSupportedException)
        {
            Console.Error.WriteLine("Error: The method has been called simultaneously on multiple threads.");
        }
        catch
        {
            Console.Error.WriteLine("There were a major problem! Try again later.");
        }
        finally
        {
            webDownloader.Dispose();
        }
    }
}