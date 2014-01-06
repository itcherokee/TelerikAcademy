using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Task: "9. Write a program that deletes from given text file all odd lines. 
/// The result should be in the same file."
/// </summary>
public class DeleteOddLines
{
    public static void Main()
    {
        Console.Title = "Delete from given text file all odd lines";
        const string FileName = "content.txt";
        string pathInput = Environment.CurrentDirectory + "\\" + FileName;
        var encoding = Encoding.GetEncoding("Windows-1251");
        const bool OverwriteFile = true;
        var content = new List<string>();
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generates source file
            GenerateFile(FileName, "Write a program that deletes from given text file all odd lines. The result should be in the same file.");
            using (var reader = new StreamReader(pathInput, encoding))
            {
                content.Add(reader.ReadLine());
                while (reader.Peek() >= 0)
                {
                    content.Add(reader.ReadLine());
                }
            }

            using (var writer = new StreamWriter(pathInput, !OverwriteFile, encoding))
            {
                for (int count = 1; count < content.Count; count += 2)
                {
                    writer.WriteLine(content[count]);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check the program \"bin\" folder for result (file: {0}).", FileName);
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