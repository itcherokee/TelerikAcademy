namespace GroupName
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Students : IEnumerable
    {
        /// <summary>
        /// Instantiates the list to be used for storing Student objects
        /// </summary>
        public Students()
        {
            this.AllStudents = new List<Student>();
        }

        private List<Student> AllStudents { get; set; }

        /// <summary>
        /// Adds element of type Student to the list. Required in order to befit from object initializers in the code.
        /// </summary>
        /// <param name="student">Single instance of Student type</param>
        public void Add(Student student)
        {
            this.AllStudents.Add(student);
        }

        /// <summary>
        /// Group students using LINQ.
        /// </summary>
        /// <returns>Student objects.</returns>
        public IEnumerable<IGrouping<string, Student>> GroupByGroupNameLinq()
        {
            var query = from student in this.AllStudents
                        group student by student.GroupName;
            return query;
        }

        /// <summary>
        /// Group students using Extension methods.
        /// </summary>
        /// <returns>Student objects.</returns>
        public IEnumerable<IGrouping<string, Student>> GroupByGroupNameExt()
        {
            var query = this.AllStudents.GroupBy(x => x.GroupName);
            return query;
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