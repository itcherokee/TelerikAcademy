using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ReplaceSubstring
{
    // Write a program that replaces all occurrences of the substring "start" with 
    // the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).

    // "Start" are lexicographically different word from "start" (capital letter), that is why it is not handled.

    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string outputPath = Environment.CurrentDirectory + "\\Output.txt";
        string toFind = "start";
        string toReplace = "finish";
        StringBuilder modifiedLine = new StringBuilder();
        try
        {
            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
                {
                    while (reader.Peek() >= 0)
                    {
                        modifiedLine.Append(reader.ReadLine());
                        modifiedLine.Replace(toFind, toReplace);
                        writer.WriteLine(modifiedLine);
                        modifiedLine.Clear();
                    }
                }
            }

            Console.WriteLine("Done. Check the folder (bin\\Debug) content");
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