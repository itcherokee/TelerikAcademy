namespace MySchool
{
    using System;

    public abstract class Person
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
