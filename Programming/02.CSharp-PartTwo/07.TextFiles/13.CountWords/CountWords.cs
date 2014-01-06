namespace CountWord
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Task: "13. Write a program that reads a list of words from a file words.txt and finds how many times
    /// each of the words is contained in another file test.txt.The result should be written in the file result.txt
    /// and the words should be sorted by the number of their occurrences in descending order. 
    /// Handle all possible exceptions in your methods."
    /// </summary>
    public class CountWords
    {
        public static void Main()
        {
            Console.Title = "Search and replace substring in a text from file.";
            const string FileInput = "test.txt";
            const string FileWords = "words.txt";
            const string FileOutput = "result.txt";
            var encoding = Encoding.GetEncoding("Windows-1251");
            string inputPath = Environment.CurrentDirectory + "\\" + FileInput;
            string wordsPath = Environment.CurrentDirectory + "\\" + FileWords;
            string outputPath = Environment.CurrentDirectory + "\\" + FileOutput;
            string initialLine = string.Empty;
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();
            List<string> wordsList = new List<string>();
            List<string> finalText = new List<string>();
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;

                // Generate source files
                GenerateSourceFile(FileInput);
                GenerateSourceFile(FileWords);
                using (StreamReader readerDic = new StreamReader(wordsPath, encoding))
                {
                    // Loading the vocabulary words
                    while (readerDic.Peek() >= 0)
                    {
                        wordsList.Add(readerDic.ReadLine());
                    }
                }

                using (StreamReader reader = new StreamReader(inputPath, encoding))
                {
                    // Loading the text by spliting every word as separate record
                    while (reader.Peek() >= 0)
                    {
                        finalText.AddRange(reader.ReadLine().Trim().Split());
                    }
                }

                // Counting appearances of every word from vocabulary in the text
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

                // Sorting results by exporting Dictionary to List using lambda expression -> result is sorted, but in ascending order
                List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>(wordsCount);
                sortedList.Sort((firstPair, nextPair) => { return firstPair.Value.CompareTo(nextPair.Value); });

                // Reverse the List to be in descending order
                sortedList.Reverse();

                // Write result to file
                using (StreamWriter writer = new StreamWriter(outputPath, false, encoding))
                {
                    foreach (var item in sortedList)
                    {
                        writer.WriteLine("{0} - {1}", item.Key, item.Value);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Done. Check program folder for result (file: {0})", FileOutput);
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
                Console.Error.WriteLine("General fault protection error. :)");
            }

            Console.ReadKey();
        }

        // Helper method - Generating source files using embedded resources and Reflection
        private static void GenerateSourceFile(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceFile = "CountWord." + fileName;
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