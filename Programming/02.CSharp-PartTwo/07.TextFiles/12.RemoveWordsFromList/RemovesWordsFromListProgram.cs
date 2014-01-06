namespace RemoveWordsFromList
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Task: "12. Write a program that removes from a text file all words listed in given another text file. 
    /// Handle all possible exceptions in your methods."
    /// </summary>
    public class RemovesWordsFromListProgram
    {
        public static void Main()
        {
            Console.Title = "Search and replace substring in a text from file.";
            const string FileInput = "Input.txt";
            const string FileDictionary = "Dictionary.txt";
            const string FileOutput = "Output.txt";
            string pathInput = Environment.CurrentDirectory + "\\" + FileInput;
            string pathDictionary = Environment.CurrentDirectory + "\\" + FileDictionary;
            string pathOutput = Environment.CurrentDirectory + "\\" + FileOutput;
            var encoding = Encoding.GetEncoding("Windows-1251");
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;

                // Generate source files (original text & dictionary)
                GenerateSourceFile(FileInput);
                GenerateSourceFile(FileDictionary);
                var vocabulary = new List<string>();
                using (var dictionaryReader = new StreamReader(pathDictionary, Encoding.GetEncoding("Windows-1251")))
                {
                    while (dictionaryReader.Peek() >= 0)
                    {
                        vocabulary.Add(dictionaryReader.ReadLine());
                    }
                }

                using (var reader = new StreamReader(pathInput, Encoding.GetEncoding("Windows-1251")))
                {
                    using (var writer = new StreamWriter(pathOutput, false, Encoding.GetEncoding("Windows-1251")))
                    {
                        while (reader.Peek() >= 0)
                        {
                            string initialLine = reader.ReadLine();
                            foreach (var word in vocabulary)
                            {
                                var regPattern = new Regex(@"\b" + word + @"\b", RegexOptions.IgnoreCase);
                                if (initialLine != null)
                                {
                                    initialLine = regPattern.Replace(initialLine, string.Empty);
                                }
                            }

                            writer.WriteLine(initialLine);
                        }
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Done.\nFor result check in program folder the file \"{0}\".\nFor original file content see file \"{1}\".", FileOutput, FileInput);
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
                Console.Error.WriteLine("Something went terribly wrong with I/O.");
            }
            catch (NullReferenceException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            catch (Exception)
            {
                Console.Error.WriteLine("General fault protection error! :)");
            }

            Console.ReadKey();
        }

        // Helper method - Generating source files using embedded resources and Reflection
        private static void GenerateSourceFile(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceFile = "RemoveWordsFromList." + fileName;
            using (Stream resource = assembly.GetManifestResourceStream(resourceFile))
            {
                if (resource == null)
                {
                    throw new NullReferenceException("Data resource is missing, so source file can not be generated!");
                }

                using (var reader = new StreamReader(resource))
                {
                    using (var writer = new StreamWriter(fileName, false, Encoding.GetEncoding("Windows-1251")))
                    {
                        writer.WriteLine(reader.ReadToEnd());
                    }
                }
            }
        }
    }
}