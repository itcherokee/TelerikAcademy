using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

public class CountWords
{
    // Write a program that reads a list of words from a file words.txt and finds 
    // how many times each of the words is contained in another file test.txt.
    // The result should be written in the file result.txt and the words should be 
    // sorted by the number of their occurrences in descending order. Handle all 
    // possible exceptions in your methods.

    public static void Main()
    {
        Console.Title = "Search and replace substring in a text from file.";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string dictionary = Environment.CurrentDirectory + "\\words.txt";
        string outputPath = Environment.CurrentDirectory + "\\result.txt";
        string initialLine = string.Empty;
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        List<string> wordsList = new List<string>();
        List<string> finalText = new List<string>();
        try
        {
            using (StreamReader readerDic = new StreamReader(dictionary, Encoding.GetEncoding("Windows-1251")))
            {
                // loading the vocabulary words
                while (readerDic.Peek() >= 0)
                {
                    wordsList.Add(readerDic.ReadLine());
                }
            }

            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                // loading the text by spliting every word as separate record
                while (reader.Peek() >= 0)
                {
                    finalText.AddRange(reader.ReadLine().Trim().Split());
                }
            }

            // counting appearances of every word from vocabulary in the text
            for (int index = 0; index < finalText.Count; index++)
            {
                foreach (string key in wordsList)
                {
                    if (finalText[index] == key)
                    {
                        if (!wordsCount.ContainsKey(key))
                        {
                            wordsCount[key] = 0;
                        }

                        wordsCount[key]++;
                    }
                }
            }

            // sorting results by exporting Dictionary to List using lambda expression -> result is sorted, but in ascending order
            List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordsCount);
            sortedList.Sort((firstPair, nextPair) => { return firstPair.Value.CompareTo(nextPair.Value); });

            // reverse the List to be in descending order
            sortedList.Reverse();

            // write result to file
            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
            {
                foreach (var item in sortedList)
                {
                    writer.WriteLine("{0} - {1}", item.Key, item.Value);
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