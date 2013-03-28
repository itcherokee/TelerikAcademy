// Write a LINQ query that finds the first name and last name 
// of all students with age between 18 and 24.

namespace MyStudentsAge
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public int Age { get; set; }

        /// <summary>
        /// Convert and creates custom look of the Student class fields to be printed
        /// </summary>
        /// <returns>String.string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            {
                output.Append(string.Format("\tFirst name: {0}\n", this.FirstName));
                output.Append(string.Format("\tLast name: {0}\n", this.LastName));
                output.Append(string.Format("\tAge name: {0}\n", this.Age));
            }

            return output.ToString();
        }
    }

    public class Students : IEnumerable
    {
        public List<Student> AllStudents { get; private set; }

        /// <summary>
        /// Adds element of type Student to the list. Required in order to befit from object initializers in the code.
        /// </summary>
        /// <param name="student">Single instance of Student type</param>
        public void Add(Student student)
        {
            this.AllStudents.Add(student);
        }

        /// <summary>
        /// Instantiates the list to be used for storing Student objects
        /// </summary>
        public Students()
        {
            this.AllStudents = new List<Student>();
        }

        /// <summary>
        /// Discovers students who's first name is before their last name alphabeticaly
        /// </summary>
        /// <returns>Custom IEnumerable<Student> list of elements fulfiling the condition</Student></returns>
        public IEnumerable<Student> FirstBeforeLast()
        {
            var query = from student in this.AllStudents
                        where student.FirstName.CompareTo(student.LastName) < 0
                        select student;
            return query;
        }

        /// <summary>
        /// Discovers students names where the age is between 18 and 24 years
        /// </summary>
        /// <returns>Custom IEnumerable<Student> list of elements fulfiling the condition</returns>
        public IEnumerable AgeBetween()
        {
            var query = from student in this.AllStudents
                        where student.Age >= 18 && student.Age <= 24
                        select new Student { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age };
            return query;
        }

        /// <summary>
        /// Convert and creates custom look of the Students instance to be printed
        /// </summary>
        /// <returns>String.string</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach (var studentName in this.AgeBetween())
            {
                output.Append("\nStudent names:\n");
                output.Append(studentName.ToString());
            }

            return output.ToString();
        }

        /// <summary>
        /// Enumerating over AllStudents list
        /// </summary>
        /// <returns>Element from the list</returns>
        public IEnumerator GetEnumerator()
        {
            return (this.AllStudents as IEnumerable<Student>).GetEnumerator();
        }
    }
}
