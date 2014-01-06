using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "7. Write a program that replaces all occurrences of the substring "start" with 
/// the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
///
/// "Start" are lexicographically different word from "start" (capital letter), that is why it is not handled."
/// </summary>
public class ReplaceSubstring
{
    private const string Text = "In the current chapter, we will start with strings.|"
        + "Starting with strings is a whole new era.|"
        + "Before that you have to already started with chars.|"
        + "Bla bla bla bla blastart bla bla startedbla...";

    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        const string FileInput = "input.txt";
        const string FileOutput = "output.txt";
        const bool OverwriteFile = true;
        var encoding = Encoding.GetEncoding("Windows-1251");
        string inputPath = Environment.CurrentDirectory + "\\" + FileInput;
        string outputPath = Environment.CurrentDirectory + "\\" + FileOutput;
        const string WordToFind = "start";
        const string WordToReplace = "finish";
        var line = new StringBuilder();
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generates source file
            GenerateFile(FileInput, Text);
            using (var reader = new StreamReader(inputPath, encoding))
            {
                using (var writer = new StreamWriter(outputPath, !OverwriteFile, encoding))
                {
                    while (reader.Peek() >= 0)
                    {
                        line.Append(reader.ReadLine());
                        line.Replace(WordToFind, WordToReplace);
                        writer.WriteLine(line);
                        line.Clear();
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check program folder for result (file: {0})", FileOutput);
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
        string[] lines = content.Trim().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        using (var writer = new StreamWriter(fileName, false))
        {
            int index = 0;
            while (index < lines.Length)
            {
                writer.WriteLine(lines[index]);

                index++;
            }
        }
    }
}