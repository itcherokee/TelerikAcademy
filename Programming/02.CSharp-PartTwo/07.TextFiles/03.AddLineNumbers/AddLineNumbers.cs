using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "3. Write a program that reads a text file and inserts line numbers in front of each of its lines. 
/// The result should be written to another text file."
/// </summary>
public class AddLineNumbers
{
    public static void Main()
    {
        Console.Title = "Insert line numbers in a text file content";
        const string FileOne = "input.txt";
        const string FileTwo = "output.txt";
        const bool OverwriteFile = true;
        var encoding = Encoding.GetEncoding("Windows-1251");
        string pathInput = Environment.CurrentDirectory + "\\" + FileOne;
        string pathOutput = Environment.CurrentDirectory + "\\" + FileTwo;
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate source file
            GenerateFile(FileOne, "Write a program that reads a text file and inserts line numbers in front of each of its lines.");
            using (var writer = new StreamWriter(pathOutput, !OverwriteFile, encoding))
            {
                using (var reader = new StreamReader(pathInput, Encoding.GetEncoding("Windows-1251")))
                {
                    int numbering = 1;
                    while (reader.Peek() >= 0)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine("{0}. {1}", numbering++, line);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Check in the program folder for result (file: {0})", FileTwo);
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
    private static void GenerateFile(string fileName, string content)
    {
        string[] lines = content.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        using (var writer = new StreamWriter(fileName, false))
        {
            for (int index = 0; index < lines.Length; index++)
            {
                writer.WriteLine(lines[index]);
            }
        }
    }
}
