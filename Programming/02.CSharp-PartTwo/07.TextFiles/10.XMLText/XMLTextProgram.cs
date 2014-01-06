namespace XMLText
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Task: "10. Write a program that extracts from given XML file all the text without the tags."
    /// </summary>
    public class XMLTextProgram
    {
        public static void Main()
        {
            Console.Title = "Extracts from given XML file all the text without the tags";
            const string FileName = "XML.xml";
            string pathInput = Environment.CurrentDirectory + "\\" + FileName;
            var encoding = Encoding.GetEncoding("Windows-1251");
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;

                // Generate source file from embedded XML resource file
                // If you want to review the source, see the XML file in the project folder
                GenerateFile("XML.xml");
                var xmlFile = new List<string>();
                using (var reader = new StreamReader(pathInput, encoding))
                {
                    xmlFile.Add(reader.ReadLine());
                    while (reader.Peek() >= 0)
                    {
                        xmlFile.Add(reader.ReadLine());
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Extracted text from XML file (without tags):\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(string.Join(" ", ExtractContentFromXml(xmlFile)));
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

        // Extracts only text from XML file without the tags
        private static IEnumerable<string> ExtractContentFromXml(List<string> xmlContent)
        {
            var extractedText = new List<string>();
            for (int index = 0; index < xmlContent.Count; index++)
            {
                int startIndex = xmlContent[index].IndexOf('>');
                while (startIndex != -1)
                {
                    int endIndex = xmlContent[index].IndexOf("</", startIndex + 1, System.StringComparison.Ordinal);
                    if (endIndex - startIndex > 1)
                    {
                        extractedText.Add(xmlContent[index].Substring(startIndex + 1, endIndex - startIndex - 1));
                    }

                    startIndex = xmlContent[index].IndexOf('>', startIndex + 1);
                }
            }

            return extractedText;
        }

        // Generates content - new XML file from embedded resource using reflection
        private static void GenerateFile(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string SourceFile = "XMLText.XML.xml";
            using (Stream resource = assembly.GetManifestResourceStream(SourceFile))
            {
                if (resource == null)
                {
                    throw new NullReferenceException("XML resource is missing, so source XML file can not be generated!");
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
