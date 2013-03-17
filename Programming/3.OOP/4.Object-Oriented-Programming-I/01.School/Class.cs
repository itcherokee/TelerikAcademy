namespace MySchool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Class : ICommentable
    {
        public string NameID { get; private set; }

        public List<Student> Students { get; private set; }

        public List<Teacher> Teachers { get; private set; }

        public string Comment { get; set; }

        /// <summary>
        /// Instantiate an object of type Class. It also instantiates both lists holding collections of Student & Teacher objects
        /// </summary>
        /// <param name="nameID">String value holding class nameID</param>
        public Class(string nameID)
        {
            this.NameID = nameID;
            this.Students = new List<Student>();
            this.Teachers = new List<Teacher>();
        }

        /// <summary>
        /// Add Student to the list 
        /// </summary>
        /// <param name="student">Student object</param>
        public void AddStudent(Student student)
        {
            if (this.Students.Exists(x => x.ClassNumber != student.ClassNumber) || this.Students.Count == 0)
            {
                this.Students.Add(student);
            }
            else
            {
                throw new ArgumentException("Provided Student's ID is not unique!");
            }
        }

        /// <summary>
        /// Add Teacher to the list 
        /// </summary>
        /// <param name="teacher">Student object</param>
        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        /// <summary>
        /// Removes Student from the list
        /// </summary>
        /// <param name="student">Student object</param>
        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        /// <summary>
        /// Removes Teacher from the list
        /// </summary>
        /// <param name="student">Teacher object</param>
        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        /// <summary>
        /// Prints object's Class details in special modified string format
        /// </summary>
        /// <returns>String value</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Class nameID: {0}\n\n", this.NameID));
            output.Append("Students in this class: \n");
            if (this.Students.Count != 0)
            {
                // Students list is not empty, so we can enumerate
                foreach (Student item in this.Students)
                {
                    output.Append(item.ToString());
                }

                output.Append("\n");
            }
            else
            {
                output.Append("None");
            }

            output.Append("Teachers in this class: \n");
            if (this.Teachers.Count != 0)
            {
                // Teacher list is not empty, so we can enumerate
                foreach (Teacher item in this.Teachers)
                {
                    output.Append(item.ToString());
                }
            }
            else
            {
                output.Append("None");
            }

            return output.ToString();
        }
    }
}
