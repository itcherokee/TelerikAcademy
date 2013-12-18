using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class AddLineNumbers
{
    // Write a program that reads a text file and inserts line numbers in front 
    // of each of its lines. The result should be written to another text file.

    public static void Main()
    {
        Console.Title = "Insert line numbers in a text file content";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        bool overwrite = true;
        string pathInput = Environment.CurrentDirectory + "\\File.txt";
        string pathOutput = Environment.CurrentDirectory + "\\NumberedFile.txt";
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

            using (StreamWriter writer = new StreamWriter(pathOutput, !overwrite, Encoding.GetEncoding("Windows-1251")))
            {
                for (int count = 0; count < content.Count; count++)
                {
                    writer.WriteLine((count + 1) + ". " + content[count]);
                }
            }
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
