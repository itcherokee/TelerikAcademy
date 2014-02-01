using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Librarian : Person
    {
        public DateTime? EmployeeSince { get; set; }

        public Librarian(string firstName, string lastName, string address, string personalID, PersonStatus status, PersonTypes personType = PersonTypes.Employee, DateTime? employeeSince = null)
        {
            this.PersonType = personType;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PersonalID = personalID;
            this.PrsonStatus = status;
            this.Address = address;
            this.EmployeeSince = employeeSince ?? DateTime.Today; ;
        }

        public override string ToString()
        {
            return "Employee: " + this.FullName + "\nAddress: " + this.Address + "\nPersonalID: " + this.PersonalID + string.Format("\nEmployee since: {0:dd.mm.yyyy}", this.EmployeeSince);
        }
    }
}
