using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public abstract class LibrarianWorker : Person
    {
        public DateTime EmployeeSince { get; set; }
        public PersonTypes personType = PersonTypes.Employee;

        protected LibrarianWorker(string firstName, string lastName, string address, string personalID, DateTime employeeSince)
            : base(firstName, lastName, address, personalID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PersonalID = personalID;
            this.EmployeeSince = DateTime.Today;
        }

        public override string ToString()
        {
            return "Employee: " + this.FirstName + " " + this.LastName + ", " + this.Address + " " + this.PersonalID + ", "
                + this.EmployeeSince;
        }
    }
}
