namespace Education
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private readonly Dictionary<int, Student> attendingStudents;
        private string name;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.attendingStudents = new Dictionary<int, Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Course's name can not be null, empty or only white spaces!");
                }

                this.name = value;
            }
        }

        public bool Join(Student attendingStudent)
        {
            bool isSuccesfulJoin = true;
            if (this.attendingStudents.Count < 30 && this.attendingStudents.Count + 1 < 30)
            {
                if (!this.attendingStudents.ContainsKey(attendingStudent.Uid))
                {
                    this.attendingStudents.Add(attendingStudent.Uid, attendingStudent);
                }
                else
                {
                    throw new ArgumentException("This student already enrolled in that course!");
                }
            }
            else
            {
                isSuccesfulJoin = false;
            }

            return isSuccesfulJoin;
        }

        public bool JoinMultiple(List<Student> students)
        {
            bool isSuccesfulJoin = true;
            if (this.attendingStudents.Count < 30 && this.attendingStudents.Count + students.Count < 30)
            {
                foreach (var student in students)
                {
                    if (!this.attendingStudents.ContainsKey(student.Uid))
                    {
                        this.attendingStudents.Add(student.Uid, student);
                    }
                    else
                    {
                        throw new ArgumentException("Student with ID = " + student.Uid + " already enrolled in that course!");
                    }
                }
            }
            else
            {
                isSuccesfulJoin = false;
            }

            return isSuccesfulJoin;
        }

        public bool Leave(Student leavingStudent)
        {
            if (this.attendingStudents.ContainsKey(leavingStudent.Uid))
            {
                this.attendingStudents.Remove(leavingStudent.Uid);
            }
            else
            {
                throw new ArgumentException("No such student enrolled in the course!");
            }

            return true;
        }

        public List<Student> GetEnrolledStudents()
        {
            return this.attendingStudents.Count != 0
                ? this.attendingStudents.Select(student => student.Value).ToList()
                : null;
        }
    }
}
