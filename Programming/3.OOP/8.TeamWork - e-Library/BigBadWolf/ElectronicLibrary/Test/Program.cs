using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicLibrary;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            Users allUsers = new Users();
            MediaList allMedias = new MediaList();
            InputOutput io = new InputOutput();


            //bool mainMenu = true;
            //while (mainMenu)
            //{
            //    Console.WriteLine("Main menu:");
            //    Console.WriteLine("1. Load DataBase");
            //    Console.WriteLine("2. Save DataBase");
            //    Console.WriteLine("3. Client Management");
            //    Console.WriteLine("4. Media Management");
            //    Console.WriteLine("5. Exit");
            //    Console.Write("Selection: ");
            //    int mainSelection = int.Parse(Console.ReadLine());
            //    switch (mainSelection)
            //    {
            //        case 1:
            //            allUsers = io.LoadPersons();
            //            // allMedias = io.LoadMedias();
            //            break;
            //            case 2.
            //        default:
            //            break;
            //    }

            //}

            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "12345678232390", PersonStatus.Operational));
            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "1234567890", PersonStatus.Operational));
            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "01234567890", PersonStatus.Operational));
            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "00000000", PersonStatus.Operational));
            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "12345690", PersonStatus.Operational));
            allUsers.Add(new Client("Pepo", "Pepov", "Sofia", "12345887890", PersonStatus.Operational));
            allUsers.Add(new Librarian("Pepo", "Pepov", "Sofia", "1111", PersonStatus.Operational));
            allUsers.Add(new Librarian("Pepo", "Pepov", "Sofia", "123451111690", PersonStatus.Operational));
            allUsers.Add(new Librarian("Pepo", "Pepov", "Sofia", "1231111156645887890", PersonStatus.Operational));


            //  allMedias.RecordMediaHasBeenChanged += new MediaList.MediaChangeEventHandler(io.SaveMedia);
            allMedias.Add(new Book("Tongo", "Tongo Tongov", "Tongo Press", 1234567890, 10, 230, "978-954-400-527-6", new DateTime(1989, 1, 1)));
            allMedias.Add(new Book("Mango", "Mango Mangov", "Mango Press", 1234243567890, 10, 230, "978-954-400-527-6", new DateTime(1989, 1, 1)));
            allMedias.Add(new Book("Kongo", "Kongo Kongov", "Kongo Press", 12345, 10, 230, "978-954-400-527-6", new DateTime(1989, 1, 1)));
            allMedias.Add(new Magazine("Elvis", "Boyko", "BAN", 00000000, 1, 1, "123-123-123-123-1", new DateTime(2014, 1, 1)));
            allMedias.Add(new Magazine("Ganyo", "Tsetsko", "BAN", 000001000, 1, 1, "123-123-123-123-1", new DateTime(2015, 1, 1)));
            allMedias.Add(new Newspaper("124-Chasa", "Parlament", "TEAM", 0022220001000, 1, 1, "123-122-123-123-1", new DateTime(2010, 1, 1)));
            //allMedias.Add(new Newspaper("124-Chasa", "Parlament", "TEAM", 0022220001000, 1, 1, "123-122-123-123-1", new DateTime(2010, 1, 1)));
            allMedias.Add(new Movie("Titanic", "Kameron", "20th CF", 1111111111, 100, new TimeSpan(2, 55, 00), 1000.0m));






            //allUsers = io.LoadPersons();

            //allUsers.RecordUserHasBeenChanged += new Users.UserChangeEventHandler(io.SavePersons);




            //Console.WriteLine(allUsers.CountByPersonType(PersonTypes.Client));
            //io.SavePersons(allUsers.GetUsers());
            //Console.WriteLine();
            ////allUsers = null;
            ////allUsers = io.LoadPersons();

            //Console.WriteLine();

            //Console.WriteLine();
            //allUsers.Remove(allUsers.SearchByPersonalID("1234567890").First());
            //Console.WriteLine();



            Console.WriteLine("Number of Newspapers in Library: " + allMedias.CountByMediaType(MediaType.Newspaper));
            allMedias.Remove(allMedias.SearchByBarcode(0022220001000).First());
            Console.WriteLine("Number of Newspapers in Library: " + allMedias.CountByMediaType(MediaType.Newspaper));
        }


    }
}
