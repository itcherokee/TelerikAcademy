using System;

class PrintCurrentDateTime
{
    static void Main()
    {
        Console.Title = "Print current date & time";
        Console.Write("Precise date and time at the moment are: ");
        Console.WriteLine(DateTime.Now.ToString());
        Console.ReadKey();
    }
}

