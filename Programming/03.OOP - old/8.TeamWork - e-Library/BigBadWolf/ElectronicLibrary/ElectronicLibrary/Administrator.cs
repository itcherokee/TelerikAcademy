using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Administrator : LibrarianWorker
    {
        public Administrator(string firstName, string lastName, string address, string personalID, DateTime employeeSince) 
            : base(firstName, lastName, address, personalID, employeeSince)
        {
        }
    }
}
