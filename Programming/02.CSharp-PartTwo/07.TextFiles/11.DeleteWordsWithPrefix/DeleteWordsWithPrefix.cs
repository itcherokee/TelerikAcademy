using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Task: "11. Write a program that deletes from a text file all words that start 
/// with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _."
/// </summary>
public class DeleteWordsWithPrefix
{
    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        const string FileInput = "content.txt";
        const string FileOutput = "temp.txt";
        const bool OverwriteFile = true;
        const string PatternToUse = @"\btest\w+|_+";
        string inputPath = Environment.CurrentDirectory + "\\" + FileInput;
        string outputPath = Environment.CurrentDirectory + "\\" + FileOutput;
        var encoding = Encoding.GetEncoding("Windows-1251");
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate source file 
            GenerateFile(FileInput, "adada  testkj shafhtest test ffftestffff");
            using (var reader = new StreamReader(inputPath, encoding))
            {
                using (var writer = new StreamWriter(outputPath, !OverwriteFile, encoding))
                {
                    Regex pattern = new Regex(PatternToUse);
                    while (reader.Peek() >= 0)
                    {
                        string initialLine = reader.ReadLine();
                        if (initialLine != null)
                        {
                            initialLine = pattern.Replace(initialLine, string.Empty);
                            writer.WriteLine(initialLine);
                        }
                    }
                }
            }

            File.Delete(inputPath);
            File.Move(outputPath, inputPath);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check the program folder for the result (file: {0}).", FileInput);
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
        using (var writer = new StreamWriter(fileName, false, Encoding.GetEncoding("Windows-1251")))
        {
            writer.WriteLine(content);
        }
    }
}