using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool
{
    public class Student : Person, ICommentable
    {
        public int ClassNumber { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// Instantiate an Student object
        /// </summary>
        /// <param name="firstName">String value holding Student first name</param>
        /// <param name="lastName">String value holding Student last name</param>
        /// <param name="classNumber">Integer value holding unique Student identifier in the class</param>
        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
        }

        /// <summary>
        /// Prints object's Student details in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Name: {0}\n", this.FullName));
            output.Append(string.Format("Unique Class Number: {0}\n", this.ClassNumber));
            return output.ToString();
        }
    }
}
