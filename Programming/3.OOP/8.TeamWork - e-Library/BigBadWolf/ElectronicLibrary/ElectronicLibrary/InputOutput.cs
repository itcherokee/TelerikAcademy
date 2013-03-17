namespace ElectronicLibrary
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    /// <summary>
    ///  Manages the IO operations of the different objects in the program 
    ///  Possible operations SAve to file, Read from file, Initialize file storage (required files)
    /// </summary>

    public class InputOutput
    {
        public string pathPerson = @"../../InputOutputPerson.txt";
        public string pathMedia = @"../../InputOutputMedia.txt";

       
         //Record fields:
         //0. PersonType
         //1. FirstName
         //2.LastName
         //3.Personal ID
         //4. personalStatus
         //5. Address
        //6. clientSince

        public List<Person> GetPersonList()
        {
           
            List<Person> objPeople = new List<Person>();

            using (StreamReader file = new StreamReader("../../InputOutputPerson.txt"))
            {
                while (file.Peek()!=null)
                {

                    char[] delimiters = new char[] {' '};
                    string[] parts = file.ReadLine().Split((char)9);
                    Client client;
                    for (int index=0; index< parts.Length;index++)
                    {
                        if (parts[index] == PersonTypes.Client.ToString())
                        {
                            client = new Client(parts[1],parts[2],parts[3],PersonStatus.Unknown,parts[5]);
                        }
                    }
                }
                file.Close();
            }
            return objPeople;
        }











        public void OutputPerson(IList<Person> person)
        {
            using (StreamWriter sw = File.AppendText(pathPerson))
            {
                sw.WriteLine(person);
            }
        }

        public void InputMedia()
        {
            int rowMedia = 1;
            using (StreamReader input = new StreamReader("../../InputOutputMedia.txt"))
                for (string line; (line = input.ReadLine()) != null; rowMedia++)
                {
                    Console.WriteLine(line);
                }
        }

        public void OutputMedia(IList<Media> media)
        {
            using (StreamWriter sw = File.AppendText(pathPerson))
            {
                sw.WriteLine(media);
            }
        }

        public void OutputPersonAdd(string player)
        {
            using (StreamWriter sw = File.AppendText(pathPerson))
            {
                sw.WriteLine(player);
            }
        }
    }
}
