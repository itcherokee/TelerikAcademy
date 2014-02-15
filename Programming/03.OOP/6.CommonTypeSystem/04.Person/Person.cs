// Task 4:  Create a class Person with two fields – name and age. Age can be left unspecified 
//          (may contain null value. Override ToString() to display the information of a person 
//          and if age is not specified – to say so. Write a program to test this functionality.

namespace MyPerson
{
    using System;

    public class Person
    {
        private readonly object age;
        private string name;

        /// <summary>
        /// Instantiates an object of type Person.
        /// </summary>
        /// <param name="fullName">Name of the Person.</param>
        /// <param name="currentAge">Age of the Person.</param>
        public Person(string fullName, int? currentAge = null)
        {
            this.Name = fullName;
            this.age = currentAge;
        }

        /// <summary>
        /// Gets the current age of the Person instance object.
        /// If there are no age specified, returns note about it.
        /// </summary>
        public string Age
        {
            get
            {
                return (this.age ?? "<not specified>").ToString();
            }
        }

        /// <summary>
        /// Gets and sets the name of the Person instance object.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Name can not be null, empty or whitespace!");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Format the current instance members into appropriate string representation.
        /// </summary>
        /// <returns>Formated string representation of current instamce.</returns>
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}