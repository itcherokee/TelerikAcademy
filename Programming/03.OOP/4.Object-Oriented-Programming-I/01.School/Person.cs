namespace MySchool
{
    using System;

    public abstract class Person
    {
        private string firstName;
        private string lastName;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name can not be null, empty or whitespace!");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name can not be null, empty or whitespace!");
                }
            }
        }

        /// <summary>
        /// Gets full name: combination of First + Second names.
        /// `</summary>
        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}