using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "1. Write a program that reads a text file and prints on the console its odd lines."
/// </summary>
public class PrintOddLines
{
    public static void Main()
    {
        Console.Title = "Print to console the odd lines of a file";
        const string FileName = "input.txt";
        string pathInput = Environment.CurrentDirectory + "\\" + FileName;
        var encoding = Encoding.GetEncoding("Windows-1251");
        try
        {
            Console.ForegroundColor = ConsoleColor.White;

            // Generate source file
            GenerateFile(FileName, "Write a program that reads a text file and prints on the console its odd lines.");
            using (var reader = new StreamReader(pathInput, encoding))
            {
                bool isOdd = false;
                string content = reader.ReadLine();
                while (reader.Peek() >= 0)
                {
                    if (isOdd)
                    {
                        Console.WriteLine(content);
                    }

                    isOdd = !isOdd;
                    content = reader.ReadLine();
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
            int index = 0;
            while (index < lines.Length)
            {
                writer.WriteLine("{0}. {1}", index, lines[index]);

                index++;
            }
        }
    }
}