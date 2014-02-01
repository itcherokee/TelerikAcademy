using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Client : Person
    {
        public DateTime? ClientSince { get; set; }

        public Client(string firstName, string lastName, string address, string personalID, PersonStatus status, PersonTypes personType = PersonTypes.Client, DateTime? clientSince = null)
        {
            this.PersonType = personType;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalID = personalID;
            this.PrsonStatus = status;
            this.Address = address;
            this.ClientSince = clientSince ?? DateTime.Today;
        }

        public override string ToString()
        {
            return "Client: " + this.FullName + ", " + this.Address + " " + this.PersonalID + ", " +
                this.PrsonStatus + ", " + this.ClientSince;
        }
    }
}
