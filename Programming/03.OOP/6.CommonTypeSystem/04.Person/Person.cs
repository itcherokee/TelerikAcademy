// Create a class Person with two fields – name and age. Age can be left unspecified 
// (may contain null value. Override ToString() to display the information of a person
// and if age is not specified – to say so. Write a program to test this functionality.

namespace MyPerson
{
    using System;

    public class Person
    {
        private string name;
        private object age;

        public Person(string fullName, int currentAge = 0)
        {
            this.Name = fullName;
            this.Age = currentAge;
        }

        public int Age
        {
            get
            {
                return (int)(this.age ?? 0);
            }

            set
            {
                this.age = value == 0 ? null : (object)value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentOutOfRangeException("Name can not be empty!");
                }

                this.name = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age == 0 ? "(not specified)" : this.Age.ToString());
        }
    }
}
