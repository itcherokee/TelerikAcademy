using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class SortNames
{
    // Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

    public static void Main()
    {
        Console.Title = "Sort names comming from one file and write them to another";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        string inputPath = Environment.CurrentDirectory + "\\Input.txt";
        string outputPath = Environment.CurrentDirectory + "\\Output.txt";
        List<string> namesList = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(inputPath, Encoding.GetEncoding("Windows-1251")))
            {
                while (reader.Peek() >= 0)
                {
                    namesList.Add(reader.ReadLine());
                }

                namesList.Sort();
            }

            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.GetEncoding("Windows-1251")))
            {
                for (int index = 0; index < namesList.Count; index++)
                {
                    writer.WriteLine(namesList[index]);
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