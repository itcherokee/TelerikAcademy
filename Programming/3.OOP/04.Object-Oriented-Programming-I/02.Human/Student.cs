namespace MyHuman
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student : Human
    {
        public enum GradeScores
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6
        }

        public GradeScores Grade { get; private set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, GradeScores grade)
            : this(firstName, lastName)
        {
            this.Grade = grade;
        }

        public void SetGrade(GradeScores grade)
        {
            this.Grade = grade;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Name: " + this.FirstName + " " + this.LastName);
            return output.ToString();
        }
    }
}
