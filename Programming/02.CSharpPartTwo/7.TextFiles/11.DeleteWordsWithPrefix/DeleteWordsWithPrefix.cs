using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class DeleteWordsWithPrefix
{
    // Write a program that deletes from a text file all words that start 
    // with the prefix "test". Words contain only the symbols 0...9, a...z, A…Z, _.

    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string outputPath = Environment.CurrentDirectory + "\\Output.txt";
        string initialLine = string.Empty;
        try
        {
            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
                {
                    Regex pattern = new Regex(@"\btest\w+|_+");
                    while (reader.Peek() >= 0)
                    {
                        initialLine = reader.ReadLine();
                        initialLine = pattern.Replace(initialLine, string.Empty);
                        writer.WriteLine(initialLine);
                    }
                }
            }

            File.Delete(inputPath);
            File.Move(outputPath, inputPath);
            Console.WriteLine("Done. Check the folder (bin\\Debug) content. Result is in the Input.txt");
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
    }
}