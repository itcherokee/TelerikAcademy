using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DeleteOddLines
{
    // Write a program that deletes from given text file all odd lines. The result should be in the same file.

    public static void Main()
    {
        Console.Title = "Delete from given text file all odd lines";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        bool overwrite = true;
        string pathInput = Environment.CurrentDirectory + "\\Input.txt";
        List<string> content = new List<string>();
        try
        {
            using (StreamReader reader = new StreamReader(pathInput, Encoding.GetEncoding("Windows-1251")))
            {
                content.Add(reader.ReadLine());
                while (reader.Peek() >= 0)
                {
                    content.Add(reader.ReadLine());
                }
            }

            using (StreamWriter writer = new StreamWriter(pathInput, !overwrite, Encoding.GetEncoding("Windows-1251")))
            {
                for (int count = 1; count < content.Count; count += 2)
                {
                    writer.WriteLine(content[count]);
                }
            }

            Console.WriteLine("Done. Check the \"bin\\debug\" folder for result. Results are in the Input.txt");
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