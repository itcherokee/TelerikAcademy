namespace DocSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class DocumentSystem
    {
        // Holds all docuemtns that are currently within the systems.
        private static readonly IList<IDocument> allDocuments = new List<IDocument>();

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
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void ListDocuments()
        {
            if (allDocuments.Count > 0)
            {
                foreach (var document in allDocuments)
                {
                    Console.WriteLine(document.ToString());
                }
            }
            else
            {
                Console.WriteLine("No documents found");
            }

        }

        private static void EncryptDocument(string name)
        {
            bool atLeastOne = false;
            foreach (var document in allDocuments.Where(document => document.Name.Equals(name)))
            {
                atLeastOne = true;
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", document.Name);
                }
            }

            if (!atLeastOne)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool atLeastOne = false;
            foreach (var document in allDocuments.Where(document => document.Name.Equals(name)))
            {
                atLeastOne = true;
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", document.Name);
                }
            }

            if (!atLeastOne)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool atLeastOne = false;
            foreach (var document in allDocuments)
            {
                if (document is IEncryptable)
                {
                    (document as IEncryptable).Encrypt();
                    atLeastOne = true;
                }
            }

            Console.WriteLine(atLeastOne ? "All documents encrypted" : "No encryptable documents found");
        }

        private static void ChangeContent(string name, string content)
        {
            bool atLeastOne = false;
            foreach (var document in allDocuments.Where(document => document.Name.Equals(name)))
            {
                atLeastOne = true;
                if (document is IEditable)
                {
                    (document as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", document.Name);
                }
            }

            if (!atLeastOne)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void AddDocument(IDocument document, string[] attributes)
        {
            foreach (var attribute in attributes)
            {
                var pair = attribute.Split('=');
                document.LoadProperty(pair[0], pair[1]);
            }

            if (string.IsNullOrWhiteSpace(document.Name))
            {
                Console.WriteLine("Document has no name");
            }
            else
            {
                Console.WriteLine("Document added: {0}", document.Name);
                allDocuments.Add(document);
            }

        }
    }

}