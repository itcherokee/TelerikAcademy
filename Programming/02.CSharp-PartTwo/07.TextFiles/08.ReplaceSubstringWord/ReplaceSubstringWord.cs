using System;
using System.IO;
using System.Text;

/// <summary>
/// Task: "8. Modify the solution of the previous problem to replace only whole words (not substrings)."
/// 
///  "Start" are lexicographically different word from "start" (capital letter), that is why it is not handled.
/// </summary>
public class ReplaceSubstring
{
    private const string Text = "start|In the current chapter, we will start with strings.|" +
        "Starting with strings is a whole new era.|Before that you have to already started with chars.|" +
        "Bla bla bla bla blastart bla bla startedbla...|start start start finish start finish start finish start|" +
        "starting........ start";

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
        string initialLine = string.Empty;
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generates source file
            GenerateFile(FileInput, Text);
            using (var reader = new StreamReader(inputPath, encoding))
            {
                using (var writer = new StreamWriter(outputPath, !OverwriteFile, encoding))
                {
                    bool startChar = false;
                    bool endChar = false;
                    while (reader.Peek() >= 0)
                    {
                        initialLine = reader.ReadLine();
                        if (initialLine != null)
                        {
                            int index = initialLine.IndexOf(WordToFind, System.StringComparison.Ordinal);
                            if (index != -1)
                            {
                                while (index != -1)
                                {
                                    if (index != 0)
                                    {
                                        if (initialLine[index - 1] < 'a' || initialLine[index - 1] > 'z')
                                        {
                                            if (initialLine[index - 1] < 'A' || initialLine[index - 1] > 'Z')
                                            {
                                                startChar = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        startChar = true;
                                    }

                                    if (index + WordToFind.Length != initialLine.Length)
                                    {
                                        if (initialLine[index + WordToFind.Length] < 'a' || initialLine[index + WordToFind.Length] > 'z')
                                        {
                                            if (initialLine[index + WordToFind.Length] < 'A' || initialLine[index + WordToFind.Length] > 'Z')
                                            {
                                                endChar = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        endChar = true;
                                    }

                                    if (startChar && endChar)
                                    {
                                        initialLine = initialLine.Remove(index, WordToFind.Length);
                                        initialLine = initialLine.Insert(index, WordToReplace);
                                    }

                                    index = initialLine.IndexOf(WordToFind, index + 1, System.StringComparison.Ordinal);
                                    startChar = false;
                                    endChar = false;
                                }
                            }
                        }

                        writer.WriteLine(initialLine);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Done. Check the program folder for result (file:{0})", FileOutput);
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