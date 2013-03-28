using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public interface IDocument
    {
        string Name { get; }
        string Content { get; }
        void LoadProperty(string key, string value);
        void SaveAllProperties(IList<KeyValuePair<string, object>> output);
        string ToString();
    }

    public interface IEditable
    {
        void ChangeContent(string newContent);
    }

    public interface IEncryptable
    {
        bool IsEncrypted { get; }
        void Encrypt();
        void Decrypt();
    }

    public class DocumentSystem
    {
        private static List<Document> documents = new List<Document>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            TextDocument textDoc = new TextDocument();
            AddDocument(attributes, textDoc);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            PDFDocument pdfDoc = new PDFDocument();
            AddDocument(attributes, pdfDoc);
        }

        private static void AddWordDocument(string[] attributes)
        {
            WordDocument wordDoc = new WordDocument();
            AddDocument(attributes, wordDoc);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            ExcelDocument excelDoc = new ExcelDocument();
            AddDocument(attributes, excelDoc);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AudioDocument audioDoc = new AudioDocument();
            AddDocument(attributes, audioDoc);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            VideoDocument videoDoc = new VideoDocument();
            AddDocument(attributes, videoDoc);
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (var item in documents)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            Encryption(name, true);
        }

        private static void DecryptDocument(string name)
        {
            Encryption(name, false);
        }

        private static void EncryptAllDocuments()
        {
            if (documents.Count > 0)
            {
                bool found = false;
                for (int index = 0; index < documents.Count; index++)
                {
                    if (documents[index] is IEncryptable)
                    {
                        (documents[index] as IEncryptable).Encrypt();
                        found = true;
                    }
                }
                if (found)
                {
                    Console.WriteLine("All documents encrypted");
                }
                else
                {
                    Console.WriteLine("No encryptable documents found");
                }
            }
        }

        private static void ChangeContent(string name, string content)
        {
            if (documents.Count > 0)
            {
                bool found = false;
                for (int index = 0; index < documents.Count; index++)
                {
                    if (documents[index].Name == name)
                    {
                        if (documents[index] is IEditable)
                        {
                            (documents[index] as IEditable).ChangeContent(content);
                            Console.WriteLine("Document content changed: {0}", documents[index].Name);
                            found = true;
                        }
                        else
                        {
                            Console.WriteLine("Document is not editable: {0}", documents[index].Name);
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Document not found: {0}", name);
                }
            }
        }

        private static void AddDocument(string[] attributes, Document docType)
        {
            int position = 0;
            foreach (var item in attributes)
            {
                position = item.IndexOf('=');
                docType.LoadProperty(item.Substring(0, position), item.Substring(position + 1));
            }
            if (!string.IsNullOrEmpty(docType.Name))
            {
                documents.Add(docType);
                Console.WriteLine("Document added: {0}", docType.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void Encryption(string name, bool encrypt)
        {
            if (documents.Count > 0)
            {
                bool found = false;
                string action = encrypt ? "encrypt" : "decrypt";
                for (int index = 0; index < documents.Count; index++)
                {
                    if (documents[index].Name == name)
                    {
                        if (documents[index] is IEncryptable)
                        {
                            switch (encrypt)
                            {
                                case true:
                                    (documents[index] as IEncryptable).Encrypt();
                                    break;
                                case false:
                                    (documents[index] as IEncryptable).Decrypt();
                                    break;
                            }
                            Console.WriteLine("Document {1}ed: {0}", documents[index].Name, action);
                            found = true;
                        }
                        else
                        {
                            Console.WriteLine("Document does not support {1}ion: {0}", documents[index].Name, action);
                        }
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Document not found: {0}", name);
                }
            }
        }
    }
}