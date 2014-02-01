namespace ElectronicLibrary
{
    using System;

    public abstract class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        internal string PersonalID { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public PersonStatus PrsonStatus { get; set; }

        public PersonTypes PersonType { get; set; }
        
        public override string ToString()
        {
            return FullName;
        }

    }
}
