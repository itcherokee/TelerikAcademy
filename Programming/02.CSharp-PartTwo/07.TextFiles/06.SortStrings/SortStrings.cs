using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "6. Write a program that reads a text file containing a list of strings, sorts them and
/// saves them to another text file."
/// </summary>
public class SortStrings
{
    public static void Main()
    {
        Console.Title = "Sort strings comming from one file and write them to another";
        const string FileInput = "Input.txt";
        const string FileOutput = "Output.txt";
        string inputPath = Environment.CurrentDirectory + "\\" + FileInput;
        string outputPath = Environment.CurrentDirectory + "\\" + FileOutput;
        var encoding = Encoding.GetEncoding("Windows-1251");
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate content
            GenerateFile(FileInput, "Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file");
            List<string> namesList = new List<string>();
            using (var reader = new StreamReader(inputPath, encoding))
            {
                while (reader.Peek() >= 0)
                {
                    namesList.Add(reader.ReadLine());
                }

                namesList.Sort();
            }

            using (var writer = new StreamWriter(outputPath, false, encoding))
            {
                for (int index = 0; index < namesList.Count; index++)
                {
                    writer.WriteLine(namesList[index]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check program folder for result (file: {0}).", FileOutput);
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
                writer.WriteLine(lines[index]);
                index++;
            }
        }
    }
}