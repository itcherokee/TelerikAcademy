using System;
using System.IO;
using System.Text;

/// <summary>
/// Task: "4. Write a program that compares two text files line by line and prints the number of lines that 
/// are the same and the number of lines that are different. Assume the files have equal number of lines."
/// </summary>
public class CompareFileLines
{
    public static void Main()
    {
        Console.Title = "Compare two text files and print number of sameness and diferences";
        const string FileOne = "input.txt";
        const string FileTwo = "output.txt"; 
        string pathOne = Environment.CurrentDirectory + "\\" + FileOne;
        string pathTwo = Environment.CurrentDirectory + "\\" + FileTwo;
        var encoding = Encoding.GetEncoding("Windows-1251");
        int sameLines = 0;
        int differentLines = 0;
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate source files
            GenerateFile(FileOne, new[] { "CSS - Thu 14:00", "CSS - Fri 10:00", "CSS - Fri 18:00", "CSS - Sat 10:00", "CSS - Thu 14:00", "CSS - Fri 10:00", "CSS - Fri 18:00", "CSS - Sat 10:00", "CSS - Thu 14:00" });
            GenerateFile(FileTwo, new[] { "XML - Thu 14:00", "CSS - Fri 10:00", "xxxxxxxxxxxxxxx", "CSS - Sat 10:00", "CSS - Thu 14:00", "CSS - Fri 10:00", "CSS - Fri 18:00", "CSS - Sat 11:11", "CSS - Thu 14:00" });
            using (var readerOne = new StreamReader(pathOne, encoding))
            {
                using (var readerTwo = new StreamReader(pathTwo, encoding))
                {
                    while (readerOne.Peek() >= 0)
                    {
                        string lineFromOne = readerOne.ReadLine();
                        string lineFromTwo = readerTwo.ReadLine();
                        if (lineFromTwo != null && (lineFromOne != null && lineFromOne.Trim() == lineFromTwo.Trim()))
                        {
                            sameLines++;
                        }
                        else
                        {
                            differentLines++;
                        }
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Identical lines: {0}", sameLines);
            Console.WriteLine("Different lines: {0}", differentLines);
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
            Console.Error.WriteLine("Something went terribly wrong with I/O.");
        }
        catch (Exception)
        {
            Console.Error.WriteLine("General fault protection error. :)");
        }

        Console.ReadKey();
    }

    // Generates content - new text file
    private static void GenerateFile(string fileName, string[] content)
    {
        string[] lines = content;
        using (var writer = new StreamWriter(fileName, false))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }
}