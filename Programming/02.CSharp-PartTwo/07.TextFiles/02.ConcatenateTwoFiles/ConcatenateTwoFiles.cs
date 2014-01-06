using System;
using System.IO;
using System.Text;

/// <summary>
/// Task: "2. Write a program that concatenates two text files into another text file."
/// </summary>
public class ConcatenateTwoFiles
{
    public static void Main()
    {
        Console.Title = "Concatenate two text files into another text file.";
        const string FileOne = "FileOne.txt";
        const string FileTwo = "FileTwo.txt";
        const string CombinedFile = "CombinedFile.txt";
        const bool OverwriteFile = true;
        var encoding = Encoding.GetEncoding("Windows-1251");
        string pathFileOne = Environment.CurrentDirectory + "\\" + FileOne;
        string pathFileTwo = Environment.CurrentDirectory + "\\" + FileTwo;
        string pathCombined = Environment.CurrentDirectory + "\\" + CombinedFile;
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;

            // Generate source files
            GenerateFile(FileOne, "Write a program that concatenates two");
            GenerateFile(FileTwo, "text files into another text file.");
            using (StreamWriter writer = new StreamWriter(pathCombined, !OverwriteFile, encoding))
            {
                using (StreamReader readerOne = new StreamReader(pathFileOne, encoding))
                {
                    ReadAndWrite(readerOne, writer);
                }

                using (StreamReader readerTwo = new StreamReader(pathFileTwo, encoding))
                {
                    ReadAndWrite(readerTwo, writer);
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Check in the program folder for result (file: {0})", CombinedFile);
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

    // Read one line from one file and write it to another file
    private static void ReadAndWrite(StreamReader reader, StreamWriter output)
    {
        while (reader.Peek() >= 0)
        {
            string fileOneLine = reader.ReadLine();
            output.WriteLine(fileOneLine);
        }
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
