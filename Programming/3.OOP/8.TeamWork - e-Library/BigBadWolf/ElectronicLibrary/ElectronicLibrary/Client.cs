using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Client : Person
    {
        public DateTime ClientSince { get;  set; }

        public PersonStatus Status { get; set; }

        public PersonTypes PersonType { get; set; }

        public Client(string firstName, string lastName, string personlaID, PersonStatus status, string address)
        {
            this.PersonType = PersonTypes.Client;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalID = personlaID;
            this.Status = status;
            this.Address = address;
            this.ClientSince = DateTime.Today;

        }
    }
}
