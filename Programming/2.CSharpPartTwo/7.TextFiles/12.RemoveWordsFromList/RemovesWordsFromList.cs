using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class RemovesWordsFromList
{
    // Write a program that removes from a text file all words listed in 
    // given another text file. Handle all possible exceptions in your methods.

    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string dictionary = Environment.CurrentDirectory + "\\Dictionary.txt";
        string outputPath = Environment.CurrentDirectory + "\\Output.txt";
        string initialLine = string.Empty;
        List<string> vocabulary = new List<string>();
        List<string> finalText = new List<string>();
        try
        {
            using (StreamReader readerDic = new StreamReader(dictionary, Encoding.GetEncoding("Windows-1251")))
            {
                while (readerDic.Peek() >= 0)
                {
                    vocabulary.Add(readerDic.ReadLine());
                }
            }

            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
                {
                    Regex regPattern;
                    while (reader.Peek() >= 0)
                    {
                        initialLine = reader.ReadLine();
                        foreach (var word in vocabulary)
                        {
                            regPattern = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
                            initialLine = regPattern.Replace(initialLine, string.Empty);
                        }

                        writer.WriteLine(initialLine);
                    }
                }
            }

            //File.Delete(inputPath);
            //File.Move(outputPath, inputPath);
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