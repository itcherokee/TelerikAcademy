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


            allUsers.Add(new Client("pepo", "pepov", "1234567890", PersonStatus.Operational));
            allUsers.Add(new Client("pepo", "pepov", "1234567891", PersonStatus.Operational));

            Console.WriteLine();
            allUsers.Remove(allUsers.SearchByPersonalID("1234567890").First());
            //allUsers.Remove(
            Console.WriteLine();

 
        }
    }
}
