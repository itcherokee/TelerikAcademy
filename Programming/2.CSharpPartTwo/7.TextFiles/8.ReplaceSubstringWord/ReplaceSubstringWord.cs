using System;
using System.IO;
using System.Text;

public class ReplaceSubstring
{
    // Modify the solution of the previous problem to replace only whole words (not substrings).

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
        string initialLine = string.Empty;
        try
        {
            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
                {
                    int index = -1;
                    bool startChar = false;
                    bool endChar = false;
                    while (reader.Peek() >= 0)
                    {
                        initialLine = reader.ReadLine();
                        index = initialLine.IndexOf(toFind);
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

                                if (index + toFind.Length != initialLine.Length)
                                {
                                    if (initialLine[index + toFind.Length] < 'a' || initialLine[index + toFind.Length] > 'z')
                                    {
                                        if (initialLine[index + toFind.Length] < 'A' || initialLine[index + toFind.Length] > 'Z')
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
                                    initialLine = initialLine.Remove(index, toFind.Length);
                                    initialLine = initialLine.Insert(index, toReplace);
                                }

                                index = initialLine.IndexOf(toFind, index + 1);
                                startChar = false;
                                endChar = false;
                            }
                        }

                        writer.WriteLine(initialLine);
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