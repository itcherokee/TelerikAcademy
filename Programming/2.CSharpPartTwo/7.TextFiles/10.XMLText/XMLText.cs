using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class XMLText
{
    // Write a program that extracts from given XML file all the text without the tags. 

    public static void Main()
    {
        Console.Title = "Extracts from given XML file all the text without the tags";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        List<string> xmlFile = new List<string>();
        List<string> content = new List<string>();
        string pathInput = Environment.CurrentDirectory + "\\XML.xml";
        try
        {
            StreamReader reader = new StreamReader(pathInput, Encoding.GetEncoding("Windows-1251"));
            using (reader)
            {
                xmlFile.Add(reader.ReadLine());
                while (reader.Peek() >= 0)
                {
                    xmlFile.Add(reader.ReadLine());
                }
            }

            int startIndex = -1;
            int endIndex = -1;
            for (int index = 0; index < xmlFile.Count; index++)
            {
                startIndex = xmlFile[index].IndexOf('>');
                while (startIndex != -1)
                {
                    endIndex = xmlFile[index].IndexOf("</", startIndex + 1);
                    if (endIndex - startIndex > 1)
                    {
                        content.Add(xmlFile[index].Substring(startIndex + 1, endIndex - startIndex - 1));
                    }

                    startIndex = xmlFile[index].IndexOf('>', startIndex + 1);
                }
            }

            for (int count = 0; count < content.Count; count++)
            {
                Console.WriteLine(content[count]);
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