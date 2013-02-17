using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class CompareFileLines
{
    // Write a program that compares two text files line by line and prints 
    // the number of lines that are the same and the number of lines that are 
    // different. Assume the files have equal number of lines.

    public static void Main()
    {
        Console.Title = "Compare two text files and print number of sameness and diferences";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string pathOne = Environment.CurrentDirectory + "\\FileOne.txt";
        string pathTwo = Environment.CurrentDirectory + "\\FileTwo.txt";
        int sameLines = 0;
        int differentLines = 0;
        try
        {
            using (StreamReader readerOne = new StreamReader(pathOne, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamReader readerTwo = new StreamReader(pathTwo, Encoding.GetEncoding("Windows-1251")))
                {
                    string lineFromOne = readerOne.ReadLine();
                    string lineFromTwo = readerTwo.ReadLine();
                    while (readerOne.Peek() >= 0)
                    {
                        if (lineFromOne.Trim() == lineFromTwo.Trim())
                        {
                            sameLines++;
                        }
                        else
                        {
                            differentLines++;
                        }

                        lineFromOne = readerOne.ReadLine();
                        lineFromTwo = readerTwo.ReadLine();
                    }
                }
            }
        }
        catch (ArgumentException)
        {
            Console.Error.WriteLine("The selected encoding is not availbale.");
        }
        catch (FileNotFoundException)
        {
            Console.Error.WriteLine("File not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.Error.WriteLine("Directory not found.");
        }
        catch (IOException)
        {
            Console.Error.WriteLine("Something went terribly wrong.");
        }

        Console.WriteLine("Identical lines: {0}", sameLines);
        Console.WriteLine("Different lines: {0}", differentLines);
    }
}