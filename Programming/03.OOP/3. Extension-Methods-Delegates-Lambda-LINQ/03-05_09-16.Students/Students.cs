namespace MyStudents
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Students : IEnumerable
    {
        /// <summary>
        /// Instantiates the list to be used for storing Student objects
        /// </summary>
        public Students()
        {
            this.AllStudents = new List<Student>();
        }

        /// <summary>
        /// Total number of Students within the list.
        /// </summary>
        public int Count
        {
            get
            {
                return this.AllStudents.Count;
            }
        }

        private List<Student> AllStudents { get; set; }

        /// <summary>
        /// Sets or gets an Student item at the specified index.
        /// </summary>
        /// <param name="index">Index in the list, where is the Student item located.</param>
        /// <returns>Student object.</returns>
        public Student this[int index]
        {
            get
            {
                return this.AllStudents[index];
            }
        }

        /// <summary>
        /// Returns read-only collection of Student objects in the list.
        /// </summary>
        /// <returns>List of currently holded Students.</returns>
        public IList<Student> GetAllStudents()
        {
            return this.AllStudents.AsReadOnly();
        }

        /// <summary>
        /// Adds element of type Student to the list. Required in order to befit from object initializers in the code.
        /// </summary>
        /// <param name="student">Single instance of Student type</param>
        public void Add(Student student)
        {
            this.AllStudents.Add(student);
        }

        /// <summary>
        /// Discovers students who's first name is before their last name alphabeticaly.
        /// </summary>
        /// <returns>Custom IEnumerable<Student> list of elements fulfiling the condition.</Student></returns>
        public IEnumerable<Student> FirstBeforeLast()
        {
            var query = from student in this.AllStudents
                        where string.Compare(student.FirstName, student.LastName, StringComparison.Ordinal) < 0
                        select student;
            return query;
        }

        /// <summary>
        /// Discovers students names where the age is between 18 and 24 years
        /// </summary>
        /// <returns>Custom IEnumerable<Student> list of elements fulfiling the condition</returns>
        public IEnumerable AgeBetween(int startAge, int endAge)
        {
            var query = from student in this.AllStudents
                        where student.Age >= startAge && student.Age <= endAge
                        select student;
            return query;
        }

        /// <summary>
        /// Sorts list by using Extension methods & lambda in descending order
        /// </summary>
        /// <returns>Sorted IEnumerable list - FirstName descending, LastName descending</returns>
        public IEnumerable SortExtension()
        {
            var query = this.AllStudents.OrderByDescending((x) => x.FirstName).ThenByDescending((x) => x.LastName).Select((x) => x);
            return query;
        }

        /// <summary>
        /// Sorts list by using LINQ in descending order
        /// </summary>
        /// <returns>Sorted IEnumerable list - FirstName descending, LastName descending</returns>
        public IEnumerable SortLinq()
        {
            var query = from student in this.AllStudents
                        orderby student.FirstName descending, student.LastName descending
                        select student;
            return query;
        }

        /// <summary>
        /// Filter students using LINQ on GroupMember number.
        /// </summary>
        /// <param name="groupNumber">Group memebership.</param>
        /// <returns></returns>
        public IEnumerable<Student> GroupLinq(uint groupNumber)
        {
            var query = from student in this.AllStudents
                        where student.GroupNumber == groupNumber
                        orderby student.FirstName
                        select student;
            return query;
        }

        /// <summary>
        /// Filter students using Extension Methods on GroupMember number.
        /// </summary>
        /// <param name="groupNumber">Group memebership.</param>
        /// <returns>Student object from requested group.</returns>
        public IEnumerable<Student> GroupExtension(uint groupNumber)
        {
            return this.AllStudents.Where(g => g.GroupNumber == groupNumber).OrderBy(fn => fn.FirstName);
        }

        /// <summary>
        /// Filter students using LINQ based on e-mail domain.
        /// </summary>
        /// <param name="emailDomain">E-mail domain as filter criteria.</param>
        /// <returns>Student object with e-mail in requested e-mail domain.</returns>
        public IEnumerable<Student> MatchEmailDomain(string emailDomain)
        {
            var query = from student in this.AllStudents
                        where student.Email.EndsWith(emailDomain)
                        select student;
            return query;
        }

        /// <summary>
        /// Filter students using LINQ based on e-mail domain.
        /// </summary>
        /// <param name="emailDomain">E-mail domain as filter criteria.</param>
        /// <returns>Student object with e-mail in requested e-mail domain.</returns>
        public IEnumerable<Student> MatchPhoneCode(string code)
        {
            var query = from student in this.AllStudents
                        where student.Tel.StartsWith(code)
                        select student;
            return query;
        }

        /// <summary>
        /// Filter students using LINQ based on year graduated.
        /// </summary>
        /// <param name="year">Year when student graduated.</param>
        /// <returns>Student object graduated.</returns>
        public IEnumerable<Student> Graduated(uint year)
        {
            var yearStr = year.ToString();
            var query = from student in this.AllStudents
                        where student.Fn.ToString().Substring(4, 2) == yearStr.Substring(yearStr.Length - 2, 2)
                        select student;
            return query;
        }

        /// <summary>
        /// Convert and creates custom look of the Students class to be printed
        /// </summary>
        /// <returns>String.string</returns>
        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var studentName in this.AllStudents)
            {
                output.AppendLine("\nStudent:");
                output.Append(studentName);
            }

            return output.ToString();
        }

        /// <summary>
        /// Enumerating over AllStudents list
        /// </summary>
        /// <returns>Element from the list</returns>
        public IEnumerator GetEnumerator()
        {
            return this.AllStudents.GetEnumerator();
        }
    }
}