using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class CompanyManager
{
    //A company has name, address, phone number, fax number, web site and manager.
    //The manager has first name, last name, age and a phone number. Write a program 
    //that reads the information about a company and its manager and prints them on the console.

    public struct Manager
    {
        public string field;
        public string value;
    }
    public struct Company
    {
        public string field;
        public string value;
    }
    static void Main()
    {
        string[] fieldsCompany = new string[5] { "Name", "Address", "Phone number", "Fax number", "Web site" };
        string[] fieldsManager = new string[4] { "First Name", "Last Name", "Age", "Phone number" };
        List<Manager> managerList = new List<Manager>();
        List<Company> companyList = new List<Company>();
        Console.Title = "Enter and print details for Company & Manager";
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Enter details for Company.");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i <= fieldsCompany.Length - 1; i++)
        {
            Console.Write("{0}: ", fieldsCompany[i]);
            Company companyDetails = new Company();
            companyDetails.field = fieldsCompany[i];
            companyDetails.value = Console.ReadLine();
            companyList.Add(companyDetails);
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Now enter details for Manager of the company...");
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i <= fieldsManager.Length - 1; i++)
        {
            Console.Write("{0} :", fieldsManager[i]);
            Manager managerDetails = new Manager();
            managerDetails.field = fieldsManager[i];
            managerDetails.value = Console.ReadLine();
            managerList.Add(managerDetails);
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Full information for Company and its Manager:");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Company details:");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var item in companyList)
        {
            Console.WriteLine("{0}: {1}", item.field, item.value);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Manager details:");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var item in managerList)
        {
            Console.WriteLine("{0}: {1}", item.field, item.value);
        }
        Console.ReadKey();
    }
}