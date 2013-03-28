using System;
using System.Collections.Generic;
using System.Text;

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

    public class WordDocument : OfficeDocument, IEditable
    {
        public int NumberOfChars { get; set; }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "chars":
                    this.NumberOfChars = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfChars));
        }
    }

    public class VideoDocument : MultimediaDocument
    {
        public byte FrameRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "framerate":
                    this.FrameRate = byte.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
    }


    public class TextDocument : Document, IEditable
    {
        private string charset;

        public string Charset
        {
            get
            {
                return charset;
            }
            set
            {
                if (value == "utf-8" || value == "windows-1251")
                {
                    this.charset = value;
                }
                else
                {
                    this.charset = string.Empty;
                }
            }
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "charset":
                    this.Charset = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }
    }


    public class PDFDocument : BinaryDocument, IEncryptable
    {

        public int Pages { get; set; }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            if (!IsEncrypted)
            {
                this.IsEncrypted = true;
            };
        }

        public void Decrypt()
        {
            if (IsEncrypted)
            {
                this.IsEncrypted = false;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "pages":
                    this.Pages = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }
    }


    public abstract class OfficeDocument : BinaryDocument, IEncryptable
    {

        public string Verison { get; set; }

        public bool IsEncrypted { get; set; }

        public void Encrypt()
        {
            if (!IsEncrypted)
            {
                this.IsEncrypted = true;
            };
        }

        public void Decrypt()
        {
            if (IsEncrypted)
            {
                this.IsEncrypted = false;
            }
        }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "version":
                    this.Verison = value;
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Verison));
        }
    }

    public abstract class MultimediaDocument : BinaryDocument
    {
        public TimeSpan Length { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "lenght":
                    this.Length = TimeSpan.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }

    public class ExcelDocument : OfficeDocument
    {
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "rows":
                    this.NumberOfRows = int.Parse(value);
                    break;
                case "cols":
                    this.NumberOfColumns = int.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
        }
    }

    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "name":
                    this.Name = value;
                    break;
                case "content":
                    this.Content = value;
                    break;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("key", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            List<KeyValuePair<string, object>> contents = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(contents);
            contents.Sort((x, y) => x.Key.CompareTo(y.Key));
            output.Append(this.GetType().Name);
            output.Append("[");
            List<string> attributes = new List<string>();
            foreach (var item in contents)
            {
                attributes.Add(item.Key + "=" + item.Value);
            }
            output.Append(string.Join(";", attributes));
            output.Append("]");
            return output.ToString();
        }

        //public int Compare(IDocument x, IDocument y)
        //{
        //    if (x.Name.CompareTo(y.Name) < 0)
        //    {
        //        return -1;
        //    }
        //    else if (x.Name.CompareTo(y.Name) > 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public int CompareTo(IDocument other)
        //{
        //    IDocument secondDoc = other as IDocument;
        //    if (this.Name.CompareTo(secondDoc.Name) < 0)
        //    {
        //        return -1;
        //    }
        //    else if (this.Name.CompareTo(secondDoc.Name) > 0)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }

    public abstract class BinaryDocument : Document
    {
        public ulong Size { get; set; }


        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "size":
                    this.Size = ulong.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }

    }

    public class AudioDocument : MultimediaDocument
    {
        public double SampleRate { get; set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "samplerate":
                    this.SampleRate = double.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
    }



}