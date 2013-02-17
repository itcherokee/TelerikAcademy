using System;
using System.IO;
using System.Text;

public class ConcatenateTwoFiles
{
    // Write a program that concatenates two text files into another text file.

    public static void Main()
    {
        Console.Title = "Concatenate two text files into another text file.";
        Console.WriteLine("In order to run this application, you need all\ninput files to be copied into \"Debug\" folder.\nPress Enter when you are ready to go.");
        Console.ReadLine();
        bool overwrite = true;
        string pathFirst = Environment.CurrentDirectory + "\\FileOne.txt";
        string pathSecond = Environment.CurrentDirectory + "\\FileTwo.txt";
        string pathOutput = Environment.CurrentDirectory + "\\ConcatFile.txt";
        try
        {
            using (StreamReader readerOne = new StreamReader(pathFirst, Encoding.GetEncoding("Windows-1251")))
            {
                using (StreamWriter outputFile = new StreamWriter(pathOutput, !overwrite, Encoding.GetEncoding("Windows-1251")))
                {
                    string fileOneLine = string.Empty;
                    while (readerOne.Peek() >= 0)
                    {
                        fileOneLine = readerOne.ReadLine();
                        outputFile.WriteLine(fileOneLine);
                    }

                    using (StreamReader readerTwo = new StreamReader(pathSecond, Encoding.GetEncoding("Windows-1251")))
                    {
                        string fileTwoLine = string.Empty;
                        while (readerTwo.Peek() >= 0)
                        {
                            fileTwoLine = readerTwo.ReadLine();
                            outputFile.WriteLine(fileTwoLine);
                        }
                    }
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
