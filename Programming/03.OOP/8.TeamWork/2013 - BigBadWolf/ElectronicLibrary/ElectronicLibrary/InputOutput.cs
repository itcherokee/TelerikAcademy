namespace ElectronicLibrary
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    /// <summary>
    ///  Manages the IO operations of the different objects in the program 
    ///  Possible operations SAve to file, Read from file, Initialize file storage (required files)
    /// </summary>

    public class InputOutput
    {
        private string pathPerson = Environment.CurrentDirectory + @"\Persons.txt";
        private string pathMedia = Environment.CurrentDirectory + @"\Media.txt";

        // Record fields order:
        // 0. PersonType
        // 1. ClentSince/EmployeeSince
        // 2. FirstName
        // 3. LastName
        // 4. Personal ID
        // 5. personalStatus
        // 6. Address

        public Users LoadPersons()
        {
            if (File.Exists(pathPerson))
            {
                Users listPersons = new Users();

                using (StreamReader inputFile = new StreamReader(pathPerson, Encoding.UTF8))
                {
                    while (inputFile.Peek() != -1)
                    {                        
                        Person record = Parse(inputFile.ReadLine().Split((char)9));
                        listPersons.Add(record);

                    }
                    inputFile.Close();
                }
                return listPersons;
            }
            else
            {
                return null;
            }
        }

        public void SavePersons(IEnumerable<Person> list)
        {
            using (StreamWriter outputFile = new StreamWriter(pathPerson, false, Encoding.UTF8))
            {
                StringBuilder outputRecord = new StringBuilder();
                try
                {
                    foreach (var record in list)
                    {
                        if (record is Client)
                        {
                            var item = record as Client;
                            //outputRecord.Append((record as Client).personType.ToString());
                            outputRecord.Append(item.PersonType.ToString() + "\t");
                            outputRecord.Append(item.ClientSince.ToString() + "\t");
                        }
                        else
                        {
                            var item = record as Librarian;
                            outputRecord.Append(item.PersonType.ToString() + "\t");
                            outputRecord.Append(item.EmployeeSince.ToString() + "\t");
                        }
                        outputRecord.Append(record.FirstName + "\t");
                        outputRecord.Append(record.LastName + "\t");
                        outputRecord.Append(record.PersonalID + "\t");
                        outputRecord.Append(record.PrsonStatus.ToString() + "\t");
                        outputRecord.Append(record.Address);

                        // Write record to file
                        outputFile.WriteLine(outputRecord.ToString());
                        outputRecord.Clear();
                    }
                }
                catch (IOException)
                {
                    throw new IOException("There were problem saving your data to DataBase!");
                }
                finally
                {
                    outputFile.Close();
                }

            }
        }

        private Person Parse(string[] data)
        {
            PersonTypes personType = (PersonTypes)Enum.Parse(typeof(PersonTypes), data[0]);
            if (personType == PersonTypes.Client)
            {
                Client client = new Client(data[2], data[3], data[6], data[4],
                    (PersonStatus)Enum.Parse(typeof(PersonStatus), data[5]), personType, Convert.ToDateTime(data[1]));
                return client;
            }
            else if (personType == PersonTypes.Employee)
            {
                Librarian client = new Librarian(data[2], data[3], data[6], data[4],
                    (PersonStatus)Enum.Parse(typeof(PersonStatus), data[5]), personType, Convert.ToDateTime(data[1]));
                return client;
            }
            else
            {
                throw new LibraryException.NonImplementedInterfaceException("Only IO operations with Client & Librarian types has been implemented!");
            }
        }

        //public void OutputPerson(IList<Person> person)
        //{
        //    using (StreamWriter sw = File.AppendText(pathPerson))
        //    {
        //        sw.WriteLine(person);
        //    }
        //}

        //public void InputMedia()
        //{
        //    int rowMedia = 1;
        //    using (StreamReader input = new StreamReader("../../InputOutputMedia.txt"))
        //        for (string line; (line = input.ReadLine()) != null; rowMedia++)
        //        {
        //            Console.WriteLine(line);
        //        }
        //}

        //public void OutputMedia(IList<Media> media)
        //{
        //    using (StreamWriter sw = File.AppendText(pathPerson))
        //    {
        //        sw.WriteLine(media);
        //    }
        //}

        //public void OutputPersonAdd(string player)
        //{
        //    using (StreamWriter sw = File.AppendText(pathPerson))
        //    {
        //        sw.WriteLine(player);
        //    }
        //}
    }
}
